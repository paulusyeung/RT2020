using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Text;
using Westwind.Tools;
using System.IO;

namespace Westwind.Globlization.Data
{
    /// <summary>
    /// Very basic Data Access Layer used for components that don't require
    /// a full business layer.
    /// 
    /// Uses SqlClient so it's SQL Server specific.
    /// </summary>
    internal class wwSqlDataAccess : IDisposable
    {
        /// <summary>
        /// An error message if a method fails
        /// </summary>
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { _ErrorMessage = value; }
        }
        private string _ErrorMessage = "";

        /// <summary>
        /// ConnectionString for the data access component
        /// </summary>
        public string ConnectionString
        {
            get { return _ConnectionString; }
            set { _ConnectionString = value; }
        }
        private string _ConnectionString = "";


        public SqlTransaction Transaction
        {
            get { return _Transaction; }
            set { _Transaction = value; }
        }
        private SqlTransaction _Transaction = null;


        private SqlConnection _Connection = null;

        public wwSqlDataAccess(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }
        public wwSqlDataAccess()
        {
        }


        /// <summary>
        /// Opens a Sql Connection based on the connection string.
        /// Called internally but externally accessible. Sets the internal
        /// _Connection property.
        /// </summary>
        /// <returns></returns>
        public bool OpenConnection()
        {
            try
            {
                if (this._Connection == null)
                    this._Connection = new SqlConnection(this.ConnectionString);               

                if (this._Connection.State != ConnectionState.Open)
                    this._Connection.Open();
            }
            catch(Exception ex)
            {
                this.ErrorMessage = ex.Message;
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates a Command object and opens a connection
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="Sql"></param>
        /// <returns></returns>
        public SqlCommand CreateCommand(string Sql, params SqlParameter[] Parameters)
        {
            this.SetError();

            SqlCommand Command = new SqlCommand();
            Command.CommandText = Sql;

            try
            {
                if (this.Transaction != null)
                {
                    Command.Transaction = this.Transaction;
                    Command.Connection = this.Transaction.Connection;
                }
                else
                {
                    if (!this.OpenConnection())
                        return null;

                    Command.Connection = this._Connection;
                }
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message);
                return null;
            }


            if (Parameters != null)
            {
                foreach (SqlParameter Parm in Parameters)
                {
                    Command.Parameters.Add(Parm);
                }
            }

            return Command;
        }


        public int ExecuteNonQuery(string Sql, params SqlParameter[] Parameters)
        {
            this.SetError();

            SqlCommand Command = this.CreateCommand(Sql, Parameters);
            if (Command == null)
                return -1;

            return this.ExecuteNonQuery(Command);
        }

        /// <summary>
        /// Executes a non-query command and returns the affected records
        /// </summary>
        /// <param name="Command">Command should be created with GetSqlCommand to have open connection</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(SqlCommand Command, params SqlParameter[] Parameters)
        {
            this.SetError();

            int RecordCount = 0;

            foreach (SqlParameter Parameter in Parameters)
            { Command.Parameters.Add(Parameter); }

            try
            {
                RecordCount = Command.ExecuteNonQuery();
                if (RecordCount == -1)
                    RecordCount = 0;
            }
            catch (Exception ex)
            {
                RecordCount = -1;
                this.ErrorMessage = ex.Message;
            }
            finally
            {
                this.CloseConnection();
            }

            return RecordCount;
        }

        /// <summary>
        /// Executes a SQL Command object and returns a SqlDataReader object
        /// </summary>
        /// <param name="Command">Command should be created with GetSqlCommand and open connection</param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        /// <returns>A SqlDataReader. Make sure to call Close() to close the underlying connection.</returns>
        public SqlDataReader ExecuteReader(SqlCommand Command, params SqlParameter[] Parameters)
        {
            this.SetError();

            foreach (SqlParameter Parameter in Parameters)
            {
                Command.Parameters.Add(Parameter);
            }

            SqlDataReader Reader = null;
            try
            {
                Reader = Command.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message);
                this.CloseConnection(Command);
                return null;
            }

            return Reader;
        }


        /// <summary>
        /// Returns a SqlDataReader object from a SQL string.
        /// 
        /// Please ensure you close the Reader object
        /// </summary>
        /// <param name="ConnectionString"></param>
        /// <param name="Sql"></param>
        /// <param name="Parameters"></param>
        /// <returns>A SqlDataReader. Make sure to call Close() to close the underlying connection.</returns>
        public SqlDataReader ExecuteReader(string Sql, params SqlParameter[] Parameters)
        {
            this.SetError();

            SqlCommand Command = this.CreateCommand(Sql);
            if (Command == null)
                return null;
            return this.ExecuteReader(Command, Parameters);
        }

        /// <summary>
        /// Returns a DataTable from a Sql Command string passed in.
        /// </summary>
        /// <param name="Tablename"></param>
        /// <param name="ConnectionString"></param>
        /// <param name="Sql"></param>
        /// <param name="Parameters"></param>
        /// <returns></returns>
        public DataTable ExecuteTable(string Tablename, string Sql, params SqlParameter[] Parameters)
        {
            this.SetError();

            SqlCommand Command = CreateCommand(Sql, Parameters);
            if (Command == null)
                return null;

            SqlDataAdapter Adapter = new SqlDataAdapter(Command);

            DataTable dt = new DataTable(Tablename);

            try
            {
                Adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message);
                return null;
            }
            finally
            {
                CloseConnection(Command);
            }

            return dt;
        }

        /// <summary>
        /// Executes a command and returns a scalar value from it
        /// </summary>
        /// <param name="SqlCommand">A SQL Command object</param>
        /// <returns>value or null on failure</returns>
        public object ExecuteScalar(string Sql, params SqlParameter[] Parameters)
        {
            SqlCommand Command = CreateCommand(Sql, Parameters);
            if (Command == null)
                return null;

            object Result = null;
            try
            {
                Result = Command.ExecuteScalar();
            }
            catch (Exception ex)
            {
                this.SetError(ex.Message);
            }
            finally
            {
                this.CloseConnection();
            }

            return Result;
        }


        /// <summary>
        /// Closes a connection
        /// </summary>
        /// <param name="Command"></param>
        public void CloseConnection(SqlCommand Command)
        {
            if (this.Transaction != null)
                return;

            if (Command.Connection != null &&
                Command.Connection.State == ConnectionState.Open)
                Command.Connection.Close();

            this._Connection = null;
        }

        /// <summary>
        /// Closes an active connection. If a transaction is pending the 
        /// connection is held open.
        /// </summary>
        public void CloseConnection()
        {
            if (this.Transaction != null)
                return;

            if (this._Connection != null &&
                this._Connection.State == ConnectionState.Open)
                this._Connection.Close();

            this._Connection = null;
        }


        /// <summary>
        /// Generic routine to retrieve an object from a database record
        /// The object properties must match the database fields.
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Table"></param>
        /// <param name="KeyField"></param>
        /// <param name="FieldsToSkip"></param>
        /// <returns></returns>
        public bool GetEntity(object Entity, SqlCommand Command, string FieldsToSkip)
        {
            this.SetError();

            SqlDataReader Reader = this.ExecuteReader(Command);
            if (Reader == null)
                return false;

            if (!Reader.Read())
            {
                Reader.Close();
                this.CloseConnection(Command);
                return false;
            }

            Type ObjType = Entity.GetType();

            PropertyInfo[] Properties = ObjType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo Property in Properties)
            {
                if (!Property.CanRead)
                    continue;

                string Name = Property.Name;

                if (FieldsToSkip.IndexOf("," + Name.ToLower() + ",") > -1)
                    continue;

                object Value = null;
                try
                {
                    Value = Reader[Name];
                }
                catch
                {
                    continue;
                }

                Property.SetValue(Entity, Value, null);
            }

            Reader.Close();
            this.CloseConnection();

            return true;
        }

        /// <summary>
        /// Generic routine to return an Entity that matches the field names of a 
        /// table exactly.
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Table"></param>
        /// <param name="KeyField"></param>
        /// <param name="KeyValue"></param>
        /// <param name="FieldsToSkip"></param>
        /// <returns></returns>
        public bool GetEntity(object Entity, string Table, string KeyField, object KeyValue, string FieldsToSkip)
        {
            this.SetError();

            SqlCommand Command = this.CreateCommand("select * from " + Table + " where [" + KeyField + "]=@Key",
                                                    new SqlParameter("@Key", KeyValue));
            if (Command == null)
                return false;

            return this.GetEntity(Entity, Command, FieldsToSkip);
        }

        /// <summary>
        /// Updates an entity object that has matching fields in the database for each
        /// public property. Kind of a poor man's quick entity update mechanism.
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Table"></param>
        /// <param name="KeyField"></param>
        /// <param name="FieldsToSkip"></param>
        /// <returns></returns>
        public bool UpdateEntity(object Entity, string Table, string KeyField, string FieldsToSkip)
        {
            if (FieldsToSkip == null)
                FieldsToSkip = "";
            else
                FieldsToSkip = "," + FieldsToSkip.ToLower() + ",";

            SqlCommand Command = this.CreateCommand("");

            Type ObjType = Entity.GetType();

            StringBuilder sb = new StringBuilder();
            sb.Append("update " + Table + " set ");

            PropertyInfo[] Properties = ObjType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo Property in Properties)
            {
                if (!Property.CanRead)
                    continue;

                string Name = Property.Name;

                if (FieldsToSkip.IndexOf("," + Name.ToLower() + ",") > -1)
                    continue;

                object Value = Property.GetValue(Entity, null);

                sb.Append(" [" + Name + "]=@" + Name + ",");

                Command.Parameters.Add(new SqlParameter("@" + Name, Value));
            }

            object PkValue = wwUtils.GetProperty(Entity, KeyField);

            String CommandText = sb.ToString().TrimEnd(',') + " where " + KeyField + "=@__PK";
            Command.Parameters.AddWithValue("@__PK", PkValue);
            Command.CommandText = CommandText;

            bool Result = this.ExecuteNonQuery(Command) > -1;
            this.CloseConnection(Command);

            return Result;
        }

        /// <summary>
        /// Inserts an object into the database based on its type information.
        /// The properties must match the database structure and you can skip
        /// over fields in the FieldsToSkip list.
        /// </summary>
        /// <param name="Entity"></param>
        /// <param name="Table"></param>
        /// <param name="KeyField"></param>
        /// <param name="FieldsToSkip"></param>
        /// <returns></returns>
        public bool InsertEntity(object Entity, string Table, string FieldsToSkip)
        {
            if (FieldsToSkip == null)
                FieldsToSkip = "";
            else
                FieldsToSkip = "," + FieldsToSkip.ToLower() + ",";

            SqlCommand Command = this.CreateCommand("");

            Type ObjType = Entity.GetType();

            StringBuilder FieldList = new StringBuilder();
            StringBuilder DataList = new StringBuilder();
            FieldList.Append("insert " + Table + " (");
            DataList.Append(" values (");

            PropertyInfo[] Properties = ObjType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
            foreach (PropertyInfo Property in Properties)
            {
                if (!Property.CanRead)
                    continue;

                string Name = Property.Name;

                if (FieldsToSkip.IndexOf("," + Name.ToLower() + ",") > -1)
                    continue;

                object Value = Property.GetValue(Entity, null);

                FieldList.Append("[" + Name + "],");
                DataList.Append("@" + Name + ",");

                Command.Parameters.Add(new SqlParameter("@" + Name, Value));
            }

            Command.CommandText = FieldList.ToString().TrimEnd(',') + ") " +
                                 DataList.ToString().TrimEnd(',') + ")";

            bool Result = this.ExecuteNonQuery(Command) > -1;

            this.CloseConnection();

            return Result;
        }


        /// <summary>
        /// Executes a long SQL script that contains batches (GO commands). This code
        /// breaks the script into individual commands and captures all execution errors.
        /// 
        /// If ContinueOnError is false, operations are run inside of a transaction and
        /// changes are rolled back. If true commands are accepted even if failures occur
        /// and are not rolled back.
        /// </summary>
        /// <param name="Script"></param>
        /// <param name="ScriptIsFile"></param>
        /// <returns></returns>
        public bool RunSqlScript(string Script, bool ContinueOnError, bool ScriptIsFile)
        {
            this.SetError();

            if (ScriptIsFile)
            {
                try
                {
                    Script = File.ReadAllText(Script);
                }
                catch(Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    return false;
                }
            }

            string[] ScriptBlocks = System.Text.RegularExpressions.Regex.Split(Script + "\r\n", "GO\r\n");
            string Errors = "";

            if (!ContinueOnError)
                this.BeginTransaction();

            foreach (string Block in ScriptBlocks)
            {
                if (string.IsNullOrEmpty(Block.TrimEnd()))
                    continue;

                if (this.ExecuteNonQuery(Block) == -1) 
                {
                    Errors = this.ErrorMessage + "\r\n";
                    if (!ContinueOnError)
                    {
                        this.RollbackTransaction();
                        return false;
                    }
                }
            }

            if (!ContinueOnError)
                this.CommitTransaction();

            if (string.IsNullOrEmpty(Errors) )
                return true;

            this.ErrorMessage = Errors;
            return false;
        }

        public bool BeginTransaction()
        {
            if (this._Connection == null)
            {
                this._Connection = new SqlConnection(this.ConnectionString);                
                this._Connection.Open();
            }

            this.Transaction = this._Connection.BeginTransaction();
            if (this.Transaction == null)
                return false;

            return true;
        }

        public bool CommitTransaction()
        {
            this.Transaction.Commit();
            this.Transaction = null;

            this.CloseConnection();

            return true;
        }

        public bool RollbackTransaction()
        {
            this.Transaction.Rollback();
            this.Transaction = null;

            this.CloseConnection();

            return true;
        }


        /// <summary>
        /// Sets the error message for the failure operations
        /// </summary>
        /// <param name="Message"></param>
        protected void SetError(string Message)
        {
            if (string.IsNullOrEmpty(Message))
            {
                this.ErrorMessage = "";
                return;
            }

            this.ErrorMessage = Message;
        }

        /// <summary>
        /// Sets the error message for failure operations.
        /// </summary>
        protected void SetError()
        {
            this.SetError(null);
        }


        #region IDisposable Members

        public void Dispose()
        {
            if (this._Connection != null)
                this.CloseConnection();
        }


        #endregion
    }
}

