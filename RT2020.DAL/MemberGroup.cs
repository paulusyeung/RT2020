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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.MemberGroup.
    /// Date Created:   2020-08-09 02:14:12
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class MemberGroup
    {
        private Guid key = Guid.Empty;
        private Guid groupId = Guid.Empty;
        private Guid parentGroup = Guid.Empty;
        private string groupCode = String.Empty;
        private string groupName = String.Empty;
        private string groupName_Chs = String.Empty;
        private string groupName_Cht = String.Empty;

        /// <summary>
        /// Initialize an new empty MemberGroup object.
        /// </summary>
        public MemberGroup()
        {
        }
		
        /// <summary>
        /// Initialize a new MemberGroup object with the given parameters.
        /// </summary>
        public MemberGroup(Guid groupId, Guid parentGroup, string groupCode, string groupName, string groupName_Chs, string groupName_Cht)
        {
                this.groupId = groupId;
                this.parentGroup = parentGroup;
                this.groupCode = groupCode;
                this.groupName = groupName;
                this.groupName_Chs = groupName_Chs;
                this.groupName_Cht = groupName_Cht;
        }	
		
        /// <summary>
        /// Loads a MemberGroup object from the database using the given GroupId
        /// </summary>
        /// <param name="groupId">The primary key value</param>
        /// <returns>A MemberGroup object</returns>
        public static MemberGroup Load(Guid groupId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@GroupId", groupId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spMemberGroup_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    MemberGroup result = new MemberGroup();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a MemberGroup object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A MemberGroup object</returns>
        public static MemberGroup LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spMemberGroup_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    MemberGroup result = new MemberGroup();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of MemberGroup objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the MemberGroup objects in the database.</returns>
        public static MemberGroupCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spMemberGroup_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of MemberGroup objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the MemberGroup objects in the database ordered by the columns specified.</returns>
        public static MemberGroupCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spMemberGroup_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of MemberGroup objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the MemberGroup objects in the database.</returns>
        public static MemberGroupCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spMemberGroup_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of MemberGroup objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the MemberGroup objects in the database ordered by the columns specified.</returns>
        public static MemberGroupCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spMemberGroup_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of MemberGroup objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the MemberGroup objects in the database.</returns>
        public static MemberGroupCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            MemberGroupCollection result = new MemberGroupCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    MemberGroup tmp = new MemberGroup();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a MemberGroup object from the database.
        /// </summary>
        /// <param name="groupId">The primary key value</param>
        public static void Delete(Guid groupId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@GroupId", groupId) };
            SqlHelper.Default.ExecuteNonQuery("spMemberGroup_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) groupId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) parentGroup = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) groupCode = reader.GetString(2);
                if (!reader.IsDBNull(3)) groupName = reader.GetString(3);
                if (!reader.IsDBNull(4)) groupName_Chs = reader.GetString(4);
                if (!reader.IsDBNull(5)) groupName_Cht = reader.GetString(5);
            }
        }
		
        public void Delete()
        {
            Delete(this.GroupId);
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
                if (key != GroupId)
                    this.Delete();
                Update();
            }
        }

        public Guid GroupId
        {
            get { return groupId; }
            set { groupId = value; }
        }

        public Guid ParentGroup
        {
            get { return parentGroup; }
            set { parentGroup = value; }
        }

        public string GroupCode
        {
            get { return groupCode; }
            set { groupCode = value; }
        }

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        public string GroupName_Chs
        {
            get { return groupName_Chs; }
            set { groupName_Chs = value; }
        }

        public string GroupName_Cht
        {
            get { return groupName_Cht; }
            set { groupName_Cht = value; }
        }


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spMemberGroup_InsRec", "@GroupId", out returnedValue, parameterValues);
            
            groupId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spMemberGroup_UpdRec", parameterValues);
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
            prams[0] = GetSqlParameter("@GroupId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.GroupId);
            prams[1] = GetSqlParameter("@ParentGroup", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ParentGroup);
            prams[2] = GetSqlParameter("@GroupCode", ParameterDirection.Input, SqlDbType.NVarChar, 10, this.GroupCode);
            prams[3] = GetSqlParameter("@GroupName", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.GroupName);
            prams[4] = GetSqlParameter("@GroupName_Chs", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.GroupName_Chs);
            prams[5] = GetSqlParameter("@GroupName_Cht", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.GroupName_Cht);
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
                GetSqlParameterWithoutDirection("@GroupId", SqlDbType.UniqueIdentifier, 16, this.GroupId),
                GetSqlParameterWithoutDirection("@ParentGroup", SqlDbType.UniqueIdentifier, 16, this.ParentGroup),
                GetSqlParameterWithoutDirection("@GroupCode", SqlDbType.NVarChar, 10, this.GroupCode),
                GetSqlParameterWithoutDirection("@GroupName", SqlDbType.NVarChar, 64, this.GroupName),
                GetSqlParameterWithoutDirection("@GroupName_Chs", SqlDbType.NVarChar, 64, this.GroupName_Chs),
                GetSqlParameterWithoutDirection("@GroupName_Cht", SqlDbType.NVarChar, 64, this.GroupName_Cht)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("groupId: " + groupId.ToString()).Append("\r\n");
            builder.Append("parentGroup: " + parentGroup.ToString()).Append("\r\n");
            builder.Append("groupCode: " + groupCode.ToString()).Append("\r\n");
            builder.Append("groupName: " + groupName.ToString()).Append("\r\n");
            builder.Append("groupName_Chs: " + groupName_Chs.ToString()).Append("\r\n");
            builder.Append("groupName_Cht: " + groupName_Cht.ToString()).Append("\r\n");
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
			
			MemberGroupCollection source;
            
            if(OrderBy == null || OrderBy.Length == 0)
            {
			    OrderBy = TextField;
            }
			
			if (WhereClause.Length > 0)
			{
				source = MemberGroup.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = MemberGroup.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (MemberGroup item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.ParentGroup != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.GroupId));
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
		
		
		private static bool IgnorThis(MemberGroup target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.ParentGroup == Guid.Empty)
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
				MemberGroup parentTemplate = MemberGroup.Load(target.ParentGroup);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(MemberGroup target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="MemberGroup">MemberGroup</see> objects.
    /// </summary>
    public class MemberGroupCollection : BindingList< MemberGroup>
    {
	}
}
