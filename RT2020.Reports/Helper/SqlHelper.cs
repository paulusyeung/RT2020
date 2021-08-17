﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RT2020.Reports.Helper
{
    class SqlHelper
    {
        //Database db = DatabaseFactory.CreateDatabase();
        Database db = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="SqlHelper"/> class.
        /// </summary>
        public SqlHelper()
        {
            DatabaseProviderFactory factory = new DatabaseProviderFactory();
            db = factory.CreateDefault();
        }

        /// <summary>
        /// Gets the default Sql Helper.
        /// </summary>
        /// <value>The default Sql Helper.</value>
        public static SqlHelper Default
        {
            get
            {
                return new SqlHelper();
            }
        }

        #region Execute DataReader
        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(DbCommand dbCommand)
        {
            return DirectCast(db.ExecuteReader(dbCommand));
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(CommandType commandType, string commandText)
        {
            return DirectCast(db.ExecuteReader(commandType, commandText));
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(DbCommand dbCommand, DbTransaction dbTransaction)
        {
            return DirectCast(db.ExecuteReader(dbCommand, dbTransaction));
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            return DirectCast(db.ExecuteReader(sqlCommand));
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(DbTransaction dbTransaction, CommandType commandType, string commandText)
        {
            return DirectCast(db.ExecuteReader(dbTransaction, commandType, commandText));
        }

        /// <summary>
        /// Executes the reader.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(DbTransaction dbTransaction, string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            return DirectCast(db.ExecuteReader(sqlCommand, dbTransaction));
        }


        private SqlDataReader DirectCast(IDataReader reader)
        {
            //2016.06.21 paulus: can't use direct cast like these
            //SqlDataReader sqlReader = (SqlDataReader)reader;;
            //
            //ExecuteReader in EntLib wraps IDataReader into RefCountingDataReader,
            //  RefCountingDataReader has InnerReader property that can cast to SqlDataReader.
            SqlDataReader sqlReader;
            RefCountingDataReader innerReader = (RefCountingDataReader)reader;
            sqlReader = (SqlDataReader)innerReader.InnerReader;

            return sqlReader;
        }
        #endregion

        #region Execute DataSet
        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand dbCommand)
        {
            return db.ExecuteDataSet(dbCommand);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(CommandType commandType, string commandText)
        {
            return db.ExecuteDataSet(commandType, commandText);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbCommand dbCommand, DbTransaction dbTransaction)
        {
            return db.ExecuteDataSet(dbCommand, dbTransaction);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            return db.ExecuteDataSet(sqlCommand);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbTransaction dbTransaction, CommandType commandType, string commandText)
        {
            return db.ExecuteDataSet(dbTransaction, commandType, commandText);
        }

        /// <summary>
        /// Executes the data set.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(DbTransaction dbTransaction, string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            return db.ExecuteDataSet(sqlCommand, dbTransaction);
        }
        #endregion

        #region Execute NonQuery
        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        public void ExecuteNonQuery(DbCommand dbCommand)
        {
            db.ExecuteNonQuery(dbCommand);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        public void ExecuteNonQuery(CommandType commandType, string commandText)
        {
            db.ExecuteNonQuery(commandType, commandText);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="dbTransaction">The db transaction.</param>
        public void ExecuteNonQuery(DbCommand dbCommand, DbTransaction dbTransaction)
        {
            db.ExecuteNonQuery(dbCommand, dbTransaction);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public void ExecuteNonQuery(string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            db.ExecuteNonQuery(sqlCommand);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="keyToReturn">The key to return.</param>
        /// <param name="returnedKeyValue">The returned key value.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public void ExecuteNonQuery(string storedProcedureName, string keyToReturn, out object returnedKeyValue, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            db.ExecuteNonQuery(sqlCommand);
            returnedKeyValue = db.GetParameterValue(sqlCommand, keyToReturn);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        public void ExecuteNonQuery(DbTransaction dbTransaction, CommandType commandType, string commandText)
        {
            db.ExecuteNonQuery(dbTransaction, commandType, commandText);
        }

        /// <summary>
        /// Executes the non query.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        public void ExecuteNonQuery(DbTransaction dbTransaction, string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            db.ExecuteNonQuery(sqlCommand, dbTransaction);
        }
        #endregion

        #region Execute Scalar
        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand dbCommand)
        {
            return db.ExecuteScalar(dbCommand);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public object ExecuteScalar(CommandType commandType, string commandText)
        {
            return db.ExecuteScalar(commandType, commandText);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <returns></returns>
        public object ExecuteScalar(DbCommand dbCommand, DbTransaction dbTransaction)
        {
            return db.ExecuteScalar(dbCommand, dbTransaction);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public object ExecuteScalar(string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            return db.ExecuteScalar(sqlCommand);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="commandType">Type of the command.</param>
        /// <param name="commandText">The command text.</param>
        /// <returns></returns>
        public object ExecuteScalar(DbTransaction dbTransaction, CommandType commandType, string commandText)
        {
            return db.ExecuteScalar(dbTransaction, commandType, commandText);
        }

        /// <summary>
        /// Executes the scalar.
        /// </summary>
        /// <param name="dbTransaction">The db transaction.</param>
        /// <param name="storedProcedureName">Name of the stored procedure.</param>
        /// <param name="parameterValues">The parameter values.</param>
        /// <returns></returns>
        public object ExecuteScalar(DbTransaction dbTransaction, string storedProcedureName, params object[] parameterValues)
        {
            DbCommand sqlCommand = db.GetStoredProcCommand(storedProcedureName);
            FillDbCommandWithParameter(ref db, ref sqlCommand, parameterValues);

            return db.ExecuteScalar(sqlCommand, dbTransaction);
        }
        #endregion

        /// <summary>
        /// Fills the db command with parameter.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <param name="dbCommand">The db command.</param>
        /// <param name="parameterValues">The parameter values.</param>
        private void FillDbCommandWithParameter(ref Database db, ref DbCommand dbCommand, object[] parameterValues)
        {
            foreach (SqlParameter sParam in parameterValues)
            {
                if (sParam.Direction == ParameterDirection.Output)
                {
                    db.AddOutParameter(dbCommand, sParam.ParameterName, sParam.DbType, sParam.Size);
                }
                else
                {
                    db.AddInParameter(dbCommand, sParam.ParameterName, sParam.DbType, sParam.Value);
                }
            }

            dbCommand.CommandTimeout = 6000;
        }
    }
}
