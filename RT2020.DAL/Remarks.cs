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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.Remarks.
    /// Date Created:   2020-08-09 02:14:15
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class Remarks
    {
        private Guid key = Guid.Empty;
        private Guid remarkId = Guid.Empty;
        private Guid parentRemark = Guid.Empty;
        private string remarkCode = String.Empty;
        private string remarks1 = String.Empty;
        private string remarks2 = String.Empty;
        private string remarks3 = String.Empty;

        /// <summary>
        /// Initialize an new empty Remarks object.
        /// </summary>
        public Remarks()
        {
        }
		
        /// <summary>
        /// Initialize a new Remarks object with the given parameters.
        /// </summary>
        public Remarks(Guid remarkId, Guid parentRemark, string remarkCode, string remarks1, string remarks2, string remarks3)
        {
                this.remarkId = remarkId;
                this.parentRemark = parentRemark;
                this.remarkCode = remarkCode;
                this.remarks1 = remarks1;
                this.remarks2 = remarks2;
                this.remarks3 = remarks3;
        }	
		
        /// <summary>
        /// Loads a Remarks object from the database using the given RemarkId
        /// </summary>
        /// <param name="remarkId">The primary key value</param>
        /// <returns>A Remarks object</returns>
        public static Remarks Load(Guid remarkId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@RemarkId", remarkId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spRemarks_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    Remarks result = new Remarks();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a Remarks object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A Remarks object</returns>
        public static Remarks LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spRemarks_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    Remarks result = new Remarks();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of Remarks objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the Remarks objects in the database.</returns>
        public static RemarksCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spRemarks_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Remarks objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the Remarks objects in the database ordered by the columns specified.</returns>
        public static RemarksCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spRemarks_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Remarks objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the Remarks objects in the database.</returns>
        public static RemarksCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spRemarks_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Remarks objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the Remarks objects in the database ordered by the columns specified.</returns>
        public static RemarksCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spRemarks_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Remarks objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the Remarks objects in the database.</returns>
        public static RemarksCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            RemarksCollection result = new RemarksCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    Remarks tmp = new Remarks();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a Remarks object from the database.
        /// </summary>
        /// <param name="remarkId">The primary key value</param>
        public static void Delete(Guid remarkId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@RemarkId", remarkId) };
            SqlHelper.Default.ExecuteNonQuery("spRemarks_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) remarkId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) parentRemark = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) remarkCode = reader.GetString(2);
                if (!reader.IsDBNull(3)) remarks1 = reader.GetString(3);
                if (!reader.IsDBNull(4)) remarks2 = reader.GetString(4);
                if (!reader.IsDBNull(5)) remarks3 = reader.GetString(5);
            }
        }
		
        public void Delete()
        {
            Delete(this.RemarkId);
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
                if (key != RemarkId)
                    this.Delete();
                Update();
            }
        }

        public Guid RemarkId
        {
            get { return remarkId; }
            set { remarkId = value; }
        }

        public Guid ParentRemark
        {
            get { return parentRemark; }
            set { parentRemark = value; }
        }

        public string RemarkCode
        {
            get { return remarkCode; }
            set { remarkCode = value; }
        }

        public string Remarks1
        {
            get { return remarks1; }
            set { remarks1 = value; }
        }

        public string Remarks2
        {
            get { return remarks2; }
            set { remarks2 = value; }
        }

        public string Remarks3
        {
            get { return remarks3; }
            set { remarks3 = value; }
        }


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spRemarks_InsRec", "@RemarkId", out returnedValue, parameterValues);
            
            remarkId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spRemarks_UpdRec", parameterValues);
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
            SqlParameter[] prams = new SqlParameter[6];
            prams[0] = GetSqlParameter("@RemarkId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.RemarkId);
            prams[1] = GetSqlParameter("@ParentRemark", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ParentRemark);
            prams[2] = GetSqlParameter("@RemarkCode", ParameterDirection.Input, SqlDbType.NVarChar, 10, this.RemarkCode);
            prams[3] = GetSqlParameter("@Remarks1", ParameterDirection.Input, SqlDbType.NVarChar, 20, this.Remarks1);
            prams[4] = GetSqlParameter("@Remarks2", ParameterDirection.Input, SqlDbType.NVarChar, 20, this.Remarks2);
            prams[5] = GetSqlParameter("@Remarks3", ParameterDirection.Input, SqlDbType.NText, 16, this.Remarks3);
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
                GetSqlParameterWithoutDirection("@RemarkId", SqlDbType.UniqueIdentifier, 16, this.RemarkId),
                GetSqlParameterWithoutDirection("@ParentRemark", SqlDbType.UniqueIdentifier, 16, this.ParentRemark),
                GetSqlParameterWithoutDirection("@RemarkCode", SqlDbType.NVarChar, 10, this.RemarkCode),
                GetSqlParameterWithoutDirection("@Remarks1", SqlDbType.NVarChar, 20, this.Remarks1),
                GetSqlParameterWithoutDirection("@Remarks2", SqlDbType.NVarChar, 20, this.Remarks2),
                GetSqlParameterWithoutDirection("@Remarks3", SqlDbType.NText, 16, this.Remarks3)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("remarkId: " + remarkId.ToString()).Append("\r\n");
            builder.Append("parentRemark: " + parentRemark.ToString()).Append("\r\n");
            builder.Append("remarkCode: " + remarkCode.ToString()).Append("\r\n");
            builder.Append("remarks1: " + remarks1.ToString()).Append("\r\n");
            builder.Append("remarks2: " + remarks2.ToString()).Append("\r\n");
            builder.Append("remarks3: " + remarks3.ToString()).Append("\r\n");
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
			
			RemarksCollection source;
            
            if(OrderBy == null || OrderBy.Length == 0)
            {
			    OrderBy = TextField;
            }
			
			if (WhereClause.Length > 0)
			{
				source = Remarks.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = Remarks.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (Remarks item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.ParentRemark != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.RemarkId));
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
		
		
		private static bool IgnorThis(Remarks target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.ParentRemark == Guid.Empty)
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
				Remarks parentTemplate = Remarks.Load(target.ParentRemark);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(Remarks target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="Remarks">Remarks</see> objects.
    /// </summary>
    public class RemarksCollection : BindingList< Remarks>
    {
	}
}
