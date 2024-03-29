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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.Province.
    /// Date Created:   2020-08-09 02:14:15
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class Province
    {
        private Guid key = Guid.Empty;
        private Guid provinceId = Guid.Empty;
        private Guid countryId = Guid.Empty;
        private string provinceCode = String.Empty;
        private string provinceName = String.Empty;
        private string provinceName_Chs = String.Empty;
        private string provinceName_Cht = String.Empty;

        /// <summary>
        /// Initialize an new empty Province object.
        /// </summary>
        public Province()
        {
        }
		
        /// <summary>
        /// Initialize a new Province object with the given parameters.
        /// </summary>
        public Province(Guid provinceId, Guid countryId, string provinceCode, string provinceName, string provinceName_Chs, string provinceName_Cht)
        {
                this.provinceId = provinceId;
                this.countryId = countryId;
                this.provinceCode = provinceCode;
                this.provinceName = provinceName;
                this.provinceName_Chs = provinceName_Chs;
                this.provinceName_Cht = provinceName_Cht;
        }	
		
        /// <summary>
        /// Loads a Province object from the database using the given ProvinceId
        /// </summary>
        /// <param name="provinceId">The primary key value</param>
        /// <returns>A Province object</returns>
        public static Province Load(Guid provinceId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@ProvinceId", provinceId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spProvince_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    Province result = new Province();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a Province object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A Province object</returns>
        public static Province LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spProvince_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    Province result = new Province();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of Province objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the Province objects in the database.</returns>
        public static ProvinceCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spProvince_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Province objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the Province objects in the database ordered by the columns specified.</returns>
        public static ProvinceCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spProvince_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Province objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the Province objects in the database.</returns>
        public static ProvinceCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spProvince_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Province objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the Province objects in the database ordered by the columns specified.</returns>
        public static ProvinceCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spProvince_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of Province objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the Province objects in the database.</returns>
        public static ProvinceCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            ProvinceCollection result = new ProvinceCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    Province tmp = new Province();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a Province object from the database.
        /// </summary>
        /// <param name="provinceId">The primary key value</param>
        public static void Delete(Guid provinceId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@ProvinceId", provinceId) };
            SqlHelper.Default.ExecuteNonQuery("spProvince_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) provinceId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) countryId = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) provinceCode = reader.GetString(2);
                if (!reader.IsDBNull(3)) provinceName = reader.GetString(3);
                if (!reader.IsDBNull(4)) provinceName_Chs = reader.GetString(4);
                if (!reader.IsDBNull(5)) provinceName_Cht = reader.GetString(5);
            }
        }
		
        public void Delete()
        {
            Delete(this.ProvinceId);
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
                if (key != ProvinceId)
                    this.Delete();
                Update();
            }
        }

        public Guid ProvinceId
        {
            get { return provinceId; }
            set { provinceId = value; }
        }

        public Guid CountryId
        {
            get { return countryId; }
            set { countryId = value; }
        }

        public string ProvinceCode
        {
            get { return provinceCode; }
            set { provinceCode = value; }
        }

        public string ProvinceName
        {
            get { return provinceName; }
            set { provinceName = value; }
        }

        public string ProvinceName_Chs
        {
            get { return provinceName_Chs; }
            set { provinceName_Chs = value; }
        }

        public string ProvinceName_Cht
        {
            get { return provinceName_Cht; }
            set { provinceName_Cht = value; }
        }


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spProvince_InsRec", "@ProvinceId", out returnedValue, parameterValues);
            
            provinceId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spProvince_UpdRec", parameterValues);
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
            prams[0] = GetSqlParameter("@ProvinceId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.ProvinceId);
            prams[1] = GetSqlParameter("@CountryId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.CountryId);
            prams[2] = GetSqlParameter("@ProvinceCode", ParameterDirection.Input, SqlDbType.NVarChar, 10, this.ProvinceCode);
            prams[3] = GetSqlParameter("@ProvinceName", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.ProvinceName);
            prams[4] = GetSqlParameter("@ProvinceName_Chs", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.ProvinceName_Chs);
            prams[5] = GetSqlParameter("@ProvinceName_Cht", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.ProvinceName_Cht);
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
                GetSqlParameterWithoutDirection("@ProvinceId", SqlDbType.UniqueIdentifier, 16, this.ProvinceId),
                GetSqlParameterWithoutDirection("@CountryId", SqlDbType.UniqueIdentifier, 16, this.CountryId),
                GetSqlParameterWithoutDirection("@ProvinceCode", SqlDbType.NVarChar, 10, this.ProvinceCode),
                GetSqlParameterWithoutDirection("@ProvinceName", SqlDbType.NVarChar, 64, this.ProvinceName),
                GetSqlParameterWithoutDirection("@ProvinceName_Chs", SqlDbType.NVarChar, 64, this.ProvinceName_Chs),
                GetSqlParameterWithoutDirection("@ProvinceName_Cht", SqlDbType.NVarChar, 64, this.ProvinceName_Cht)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("provinceId: " + provinceId.ToString()).Append("\r\n");
            builder.Append("countryId: " + countryId.ToString()).Append("\r\n");
            builder.Append("provinceCode: " + provinceCode.ToString()).Append("\r\n");
            builder.Append("provinceName: " + provinceName.ToString()).Append("\r\n");
            builder.Append("provinceName_Chs: " + provinceName_Chs.ToString()).Append("\r\n");
            builder.Append("provinceName_Cht: " + provinceName_Cht.ToString()).Append("\r\n");
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
			
			ProvinceCollection source;
            
            if(OrderBy == null || OrderBy.Length == 0)
            {
			    OrderBy = TextField;
            }
			
			if (WhereClause.Length > 0)
			{
				source = Province.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = Province.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (Province item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.CountryId != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.ProvinceId));
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
		
		
		private static bool IgnorThis(Province target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.CountryId == Guid.Empty)
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
				Province parentTemplate = Province.Load(target.CountryId);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(Province target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="Province">Province</see> objects.
    /// </summary>
    public class ProvinceCollection : BindingList< Province>
    {
	}
}
