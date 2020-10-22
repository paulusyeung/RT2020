﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Reflection;
using System.Text;
using Gizmox.WebGUI.Forms;
using System.Xml;

using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RT2020.DAL
{
    /// <summary>
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.ProductClass5.
    /// Date Created:   2020-08-09 02:14:14
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class ProductClass5
    {
        private Guid key = Guid.Empty;
        private Guid class5Id = Guid.Empty;
        private Guid parentClass = Guid.Empty;
        private string class5Code = String.Empty;
        private string class5Initial = String.Empty;
        private string class5Name = String.Empty;
        private string class5Name_Chs = String.Empty;
        private string class5Name_Cht = String.Empty;
        private Guid alternateClass = Guid.Empty;
        private DateTime createdOn = DateTime.Parse("1900-1-1");
        private Guid createdBy = Guid.Empty;
        private DateTime modifiedOn = DateTime.Parse("1900-1-1");
        private Guid modifiedBy = Guid.Empty;
        private bool retired;
        private DateTime retiredOn = DateTime.Parse("1900-1-1");
        private Guid retiredBy = Guid.Empty;

        /// <summary>
        /// Initialize an new empty ProductClass5 object.
        /// </summary>
        public ProductClass5()
        {
        }
		
        /// <summary>
        /// Initialize a new ProductClass5 object with the given parameters.
        /// </summary>
        public ProductClass5(Guid class5Id, Guid parentClass, string class5Code, string class5Initial, string class5Name, string class5Name_Chs, string class5Name_Cht, Guid alternateClass, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, bool retired, DateTime retiredOn, Guid retiredBy)
        {
                this.class5Id = class5Id;
                this.parentClass = parentClass;
                this.class5Code = class5Code;
                this.class5Initial = class5Initial;
                this.class5Name = class5Name;
                this.class5Name_Chs = class5Name_Chs;
                this.class5Name_Cht = class5Name_Cht;
                this.alternateClass = alternateClass;
                this.createdOn = createdOn;
                this.createdBy = createdBy;
                this.modifiedOn = modifiedOn;
                this.modifiedBy = modifiedBy;
                this.retired = retired;
                this.retiredOn = retiredOn;
                this.retiredBy = retiredBy;
        }	
		
        /// <summary>
        /// Loads a ProductClass5 object from the database using the given Class5Id
        /// </summary>
        /// <param name="class5Id">The primary key value</param>
        /// <returns>A ProductClass5 object</returns>
        public static ProductClass5 Load(Guid class5Id)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@Class5Id", class5Id) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spProductClass5_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    ProductClass5 result = new ProductClass5();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a ProductClass5 object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A ProductClass5 object</returns>
        public static ProductClass5 LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spProductClass5_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    ProductClass5 result = new ProductClass5();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of ProductClass5 objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the ProductClass5 objects in the database.</returns>
        public static ProductClass5Collection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spProductClass5_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of ProductClass5 objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the ProductClass5 objects in the database ordered by the columns specified.</returns>
        public static ProductClass5Collection LoadCollection(string[] orderByColumns, bool ascending)
        {
            StringBuilder orderClause = new StringBuilder();
            for (int i = 0; i < orderByColumns.Length; i++)
            {
                orderClause.Append(orderByColumns[i]);

                if (i != orderByColumns.Length-1)
                    orderClause.Append(", ");
            }

            if (ascending)
                orderClause.Append(" ASC");
            else
                orderClause.Append(" DESC");

            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@OrderBy", orderClause.ToString()) };
            return LoadCollection("spProductClass5_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of ProductClass5 objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the ProductClass5 objects in the database.</returns>
        public static ProductClass5Collection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spProductClass5_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of ProductClass5 objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the ProductClass5 objects in the database ordered by the columns specified.</returns>
        public static ProductClass5Collection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
        {
            StringBuilder orderClause = new StringBuilder();
            for (int i = 0; i < orderByColumns.Length; i++)
            {
                orderClause.Append(orderByColumns[i]);

                if (i != orderByColumns.Length-1)
                    orderClause.Append(", ");
            }

            if (ascending)
                orderClause.Append(" ASC");
            else
                orderClause.Append(" DESC");

            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause), new SqlParameter("@OrderBy", orderClause.ToString()) };
            return LoadCollection("spProductClass5_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of ProductClass5 objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the ProductClass5 objects in the database.</returns>
        public static ProductClass5Collection LoadCollection(string spName, SqlParameter[] parms)
        {
            ProductClass5Collection result = new ProductClass5Collection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    ProductClass5 tmp = new ProductClass5();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a ProductClass5 object from the database.
        /// </summary>
        /// <param name="class5Id">The primary key value</param>
        public static void Delete(Guid class5Id)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@Class5Id", class5Id) };
            SqlHelper.Default.ExecuteNonQuery("spProductClass5_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) class5Id = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) parentClass = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) class5Code = reader.GetString(2);
                if (!reader.IsDBNull(3)) class5Initial = reader.GetString(3);
                if (!reader.IsDBNull(4)) class5Name = reader.GetString(4);
                if (!reader.IsDBNull(5)) class5Name_Chs = reader.GetString(5);
                if (!reader.IsDBNull(6)) class5Name_Cht = reader.GetString(6);
                if (!reader.IsDBNull(7)) alternateClass = reader.GetGuid(7);
                if (!reader.IsDBNull(8)) createdOn = reader.GetDateTime(8);
                if (!reader.IsDBNull(9)) createdBy = reader.GetGuid(9);
                if (!reader.IsDBNull(10)) modifiedOn = reader.GetDateTime(10);
                if (!reader.IsDBNull(11)) modifiedBy = reader.GetGuid(11);
                if (!reader.IsDBNull(12)) retired = reader.GetBoolean(12);
                if (!reader.IsDBNull(13)) retiredOn = reader.GetDateTime(13);
                if (!reader.IsDBNull(14)) retiredBy = reader.GetGuid(14);
            }
        }
		
        public void Delete()
        {
            Delete(this.Class5Id);
        }

        public void Save()
        {
            //  We use the key field which will have its default value unless it is set by Load(). When we save we can know if
            //  we need to do an insert (key == null) an update (key == primaryKey) or a 
            //  delete+update (key != null && key != primaryKey)

            if (key == Guid.Empty)
                Insert();
            else
            {
                if (key != Class5Id)
                    this.Delete();
                Update();
            }
        }

        public Guid Class5Id
        {
            get { return class5Id; }
            set { class5Id = value; }
        }

        public Guid ParentClass
        {
            get { return parentClass; }
            set { parentClass = value; }
        }

        public string Class5Code
        {
            get { return class5Code; }
            set { class5Code = value; }
        }

        public string Class5Initial
        {
            get { return class5Initial; }
            set { class5Initial = value; }
        }

        public string Class5Name
        {
            get { return class5Name; }
            set { class5Name = value; }
        }

        public string Class5Name_Chs
        {
            get { return class5Name_Chs; }
            set { class5Name_Chs = value; }
        }

        public string Class5Name_Cht
        {
            get { return class5Name_Cht; }
            set { class5Name_Cht = value; }
        }

        public Guid AlternateClass
        {
            get { return alternateClass; }
            set { alternateClass = value; }
        }

        public DateTime CreatedOn
        {
            get { return createdOn; }
            set { createdOn = value; }
        }

        public Guid CreatedBy
        {
            get { return createdBy; }
            set { createdBy = value; }
        }

        public DateTime ModifiedOn
        {
            get { return modifiedOn; }
            set { modifiedOn = value; }
        }

        public Guid ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        public bool Retired
        {
            get { return retired; }
            set { retired = value; }
        }

        public DateTime RetiredOn
        {
            get { return retiredOn; }
            set { retiredOn = value; }
        }

        public Guid RetiredBy
        {
            get { return retiredBy; }
            set { retiredBy = value; }
        }


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spProductClass5_InsRec", "@Class5Id", out returnedValue, parameterValues);
            
            class5Id = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spProductClass5_UpdRec", parameterValues);
        }
        
        /// <summary>
        /// Gets the SQL parameter.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="direction">The direction.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="size">The size.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private SqlParameter GetSqlParameter(string name, ParameterDirection direction, SqlDbType dbType, int size, object value)
        {
            SqlParameter p = new SqlParameter(name, dbType, size);
            p.Value = value;
            p.Direction = direction;
            return p;
        }

        private SqlParameter[] GetInsertParameterValues()
        {
            SqlParameter[] prams = new SqlParameter[15];
            prams[0] = GetSqlParameter("@Class5Id", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.Class5Id);
            prams[1] = GetSqlParameter("@ParentClass", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ParentClass);
            prams[2] = GetSqlParameter("@Class5Code", ParameterDirection.Input, SqlDbType.VarChar, 6, this.Class5Code);
            prams[3] = GetSqlParameter("@Class5Initial", ParameterDirection.Input, SqlDbType.NVarChar, 10, this.Class5Initial);
            prams[4] = GetSqlParameter("@Class5Name", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.Class5Name);
            prams[5] = GetSqlParameter("@Class5Name_Chs", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.Class5Name_Chs);
            prams[6] = GetSqlParameter("@Class5Name_Cht", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.Class5Name_Cht);
            prams[7] = GetSqlParameter("@AlternateClass", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.AlternateClass);
            prams[8] = GetSqlParameter("@CreatedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.CreatedOn);
            prams[9] = GetSqlParameter("@CreatedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.CreatedBy);
            prams[10] = GetSqlParameter("@ModifiedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.ModifiedOn);
            prams[11] = GetSqlParameter("@ModifiedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ModifiedBy);
            prams[12] = GetSqlParameter("@Retired", ParameterDirection.Input, SqlDbType.Bit, 1, this.Retired);
            prams[13] = GetSqlParameter("@RetiredOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.RetiredOn);
            prams[14] = GetSqlParameter("@RetiredBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.RetiredBy);
            return prams;
        }
		
        /// <summary>
        /// Gets the SQL parameter without direction.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="dbType">Type of the db.</param>
        /// <param name="size">The size.</param>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        private SqlParameter GetSqlParameterWithoutDirection(string name, SqlDbType dbType, int size, object value)
        {
            SqlParameter p = new SqlParameter(name, dbType, size);
            p.Value = value;
            return p;
        }
        
        private SqlParameter[] GetUpdateParameterValues()
        {
            return new SqlParameter[] 
            {
                GetSqlParameterWithoutDirection("@Class5Id", SqlDbType.UniqueIdentifier, 16, this.Class5Id),
                GetSqlParameterWithoutDirection("@ParentClass", SqlDbType.UniqueIdentifier, 16, this.ParentClass),
                GetSqlParameterWithoutDirection("@Class5Code", SqlDbType.VarChar, 6, this.Class5Code),
                GetSqlParameterWithoutDirection("@Class5Initial", SqlDbType.NVarChar, 10, this.Class5Initial),
                GetSqlParameterWithoutDirection("@Class5Name", SqlDbType.NVarChar, 64, this.Class5Name),
                GetSqlParameterWithoutDirection("@Class5Name_Chs", SqlDbType.NVarChar, 64, this.Class5Name_Chs),
                GetSqlParameterWithoutDirection("@Class5Name_Cht", SqlDbType.NVarChar, 64, this.Class5Name_Cht),
                GetSqlParameterWithoutDirection("@AlternateClass", SqlDbType.UniqueIdentifier, 16, this.AlternateClass),
                GetSqlParameterWithoutDirection("@CreatedOn", SqlDbType.DateTime, 8, this.CreatedOn),
                GetSqlParameterWithoutDirection("@CreatedBy", SqlDbType.UniqueIdentifier, 16, this.CreatedBy),
                GetSqlParameterWithoutDirection("@ModifiedOn", SqlDbType.DateTime, 8, this.ModifiedOn),
                GetSqlParameterWithoutDirection("@ModifiedBy", SqlDbType.UniqueIdentifier, 16, this.ModifiedBy),
                GetSqlParameterWithoutDirection("@Retired", SqlDbType.Bit, 1, this.Retired),
                GetSqlParameterWithoutDirection("@RetiredOn", SqlDbType.DateTime, 8, this.RetiredOn),
                GetSqlParameterWithoutDirection("@RetiredBy", SqlDbType.UniqueIdentifier, 16, this.RetiredBy)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("class5Id: " + class5Id.ToString()).Append("\r\n");
            builder.Append("parentClass: " + parentClass.ToString()).Append("\r\n");
            builder.Append("class5Code: " + class5Code.ToString()).Append("\r\n");
            builder.Append("class5Initial: " + class5Initial.ToString()).Append("\r\n");
            builder.Append("class5Name: " + class5Name.ToString()).Append("\r\n");
            builder.Append("class5Name_Chs: " + class5Name_Chs.ToString()).Append("\r\n");
            builder.Append("class5Name_Cht: " + class5Name_Cht.ToString()).Append("\r\n");
            builder.Append("alternateClass: " + alternateClass.ToString()).Append("\r\n");
            builder.Append("createdOn: " + createdOn.ToString()).Append("\r\n");
            builder.Append("createdBy: " + createdBy.ToString()).Append("\r\n");
            builder.Append("modifiedOn: " + modifiedOn.ToString()).Append("\r\n");
            builder.Append("modifiedBy: " + modifiedBy.ToString()).Append("\r\n");
            builder.Append("retired: " + retired.ToString()).Append("\r\n");
            builder.Append("retiredOn: " + retiredOn.ToString()).Append("\r\n");
            builder.Append("retiredBy: " + retiredBy.ToString()).Append("\r\n");
            builder.Append("\r\n");
            return builder.ToString();
        }	
		
		#region Load ComboBox
        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale)
		{
			LoadCombo(ref ddList, TextField, SwitchLocale, false, string.Empty, string.Empty, new string[]{ TextField });
		}
		
        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, string[] OrderBy)
		{
			LoadCombo(ref ddList, TextField, SwitchLocale, false, string.Empty, string.Empty, OrderBy);
		}

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause)
		{
			LoadCombo(ref ddList, TextField, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, new String[] { TextField });
		}

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
		{
			LoadCombo(ref ddList, TextField, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
		}

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. "FieldName"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="ParentFilter">e.g. "ForeignFieldName = 'value'"</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string TextField, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
		{
			string [] textField = {TextField};
			LoadCombo(ref ddList, textField, "{0}", SwitchLocale, BlankLine, BlankLineText, ParentFilter, WhereClause, OrderBy);
		}

        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. new string[]{"FieldName1", "FieldName2", ...}</param>
        /// <param name="TextFormatString">e.g. "{0} - {1}"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string [] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string WhereClause, string[] OrderBy)
		{
			LoadCombo(ref ddList, TextField, TextFormatString, SwitchLocale, BlankLine, BlankLineText, string.Empty, WhereClause, OrderBy);
		}
		
        /// <summary>
        /// Only support the ComboBox control from WinForm/Visual WebGUI
        /// </summary>
        /// <param name="ddList">the ComboBox control from WinForm/Visual WebGUI</param>
        /// <param name="TextField">e.g. new string[]{"FieldName1", "FieldName2", ...}</param>
        /// <param name="TextFormatString">e.g. "{0} - {1}"</param>
        /// <param name="SwitchLocale">Can be localized, if the FieldName has locale suffix, e.g. '_chs'</param>
        /// <param name="BlankLine">add blank label text to ComboBox or not</param>
        /// <param name="BlankLineText">the blank label text</param>
        /// <param name="ParentFilter">e.g. "ForeignFieldName = 'value'"</param>
        /// <param name="WhereClause">Where Clause for SQL Statement. e.g. "FieldName = 'SomeCondition'"</param>
        /// <param name="OrderBy">Sorting order, string array, e.g. {"FieldName1", "FiledName2"}</param>
		public static void LoadCombo(ref ComboBox ddList, string [] TextField, string TextFormatString, bool SwitchLocale, bool BlankLine, string BlankLineText, string ParentFilter, string WhereClause, string[] OrderBy)
		{
			if (SwitchLocale)
			{
				TextField = GetSwitchLocale(TextField);
			}
			ddList.Items.Clear();						
			
			ProductClass5Collection source;
            
            if(OrderBy == null || OrderBy.Length == 0)
            {
			    OrderBy = TextField;
            }
			// Filter the retired records
			if (WhereClause.Length > 0)
			{
				WhereClause += " AND Retired = 0";
			}
			else
			{
				WhereClause = "Retired = 0";
			}
			
			if (WhereClause.Length > 0)
			{
				source = ProductClass5.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = ProductClass5.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (ProductClass5 item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.ParentClass != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.Class5Id));
				}
			}			

            ddList.DataSource = sourceList;
            ddList.DisplayMember = "Code";
            ddList.ValueMember = "Id";
			
			if (ddList.Items.Count > 0)
			{
			    ddList.SelectedIndex = 0;
            }
		}
		
		#endregion
		
		
		private static bool IgnorThis(ProductClass5 target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.ParentClass == Guid.Empty)
			{
				PropertyInfo pi = target.GetType().GetProperty(parsed[0]);
				string filterField = (string)pi.GetValue(target, null);
				if (filterField.ToLower() == parsed[1].ToLower())
				{
					result = false;
				}
			}
			else
			{
				ProductClass5 parentTemplate = ProductClass5.Load(target.ParentClass);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(ProductClass5 target, string [] textField, string textFormatString)
		{
			for (int i = 0; i < textField.Length; i++)
			{
				PropertyInfo pi = target.GetType().GetProperty(textField[i]);
				textFormatString = textFormatString.Replace("{" + i.ToString() +"}", pi != null ? pi.GetValue(target, null).ToString() : string.Empty);
			}
			return textFormatString;
		}
		
		private static string [] GetSwitchLocale(string [] source)
		{
			switch (Common.Config.CurrentLanguageId)
			{
				case 2:
					source[source.Length - 1] += "_Chs";
					break;
				case 3:
					source[source.Length - 1] += "_Cht";
					break;
			}
			return source;
		}
    }


    /// <summary>
    /// Represents a collection of <see cref="ProductClass5">ProductClass5</see> objects.
    /// </summary>
    public class ProductClass5Collection : BindingList< ProductClass5>
    {
	}
}
