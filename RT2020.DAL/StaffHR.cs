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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.StaffHR.
    /// Date Created:   2020-08-09 02:14:16
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class StaffHR
    {
        private Guid key = Guid.Empty;
        private Guid hRId = Guid.Empty;
        private Guid staffId = Guid.Empty;
        private string employmentNumber = String.Empty;
        private DateTime hiredOn = DateTime.Parse("1900-1-1");
        private decimal salary;
        private string medicalNumber = String.Empty;
        private string bankAccountNumber = String.Empty;
        private bool tC_AdminEnable;
        private bool tC_PunchEnable;
        private bool tC_PunchEnable_InOut;
        private bool tC_PunchEnable_DayView;
        private decimal paidAnnualLeave;
        private decimal paidSickLeave;
        private decimal paidSickLeaveWithoutCert;

        /// <summary>
        /// Initialize an new empty StaffHR object.
        /// </summary>
        public StaffHR()
        {
        }
		
        /// <summary>
        /// Initialize a new StaffHR object with the given parameters.
        /// </summary>
        public StaffHR(Guid hRId, Guid staffId, string employmentNumber, DateTime hiredOn, decimal salary, string medicalNumber, string bankAccountNumber, bool tC_AdminEnable, bool tC_PunchEnable, bool tC_PunchEnable_InOut, bool tC_PunchEnable_DayView, decimal paidAnnualLeave, decimal paidSickLeave, decimal paidSickLeaveWithoutCert)
        {
                this.hRId = hRId;
                this.staffId = staffId;
                this.employmentNumber = employmentNumber;
                this.hiredOn = hiredOn;
                this.salary = salary;
                this.medicalNumber = medicalNumber;
                this.bankAccountNumber = bankAccountNumber;
                this.tC_AdminEnable = tC_AdminEnable;
                this.tC_PunchEnable = tC_PunchEnable;
                this.tC_PunchEnable_InOut = tC_PunchEnable_InOut;
                this.tC_PunchEnable_DayView = tC_PunchEnable_DayView;
                this.paidAnnualLeave = paidAnnualLeave;
                this.paidSickLeave = paidSickLeave;
                this.paidSickLeaveWithoutCert = paidSickLeaveWithoutCert;
        }	
		
        /// <summary>
        /// Loads a StaffHR object from the database using the given HRId
        /// </summary>
        /// <param name="hRId">The primary key value</param>
        /// <returns>A StaffHR object</returns>
        public static StaffHR Load(Guid hRId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@HRId", hRId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spStaffHR_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    StaffHR result = new StaffHR();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a StaffHR object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A StaffHR object</returns>
        public static StaffHR LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spStaffHR_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    StaffHR result = new StaffHR();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of StaffHR objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the StaffHR objects in the database.</returns>
        public static StaffHRCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spStaffHR_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StaffHR objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the StaffHR objects in the database ordered by the columns specified.</returns>
        public static StaffHRCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spStaffHR_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StaffHR objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the StaffHR objects in the database.</returns>
        public static StaffHRCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spStaffHR_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StaffHR objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the StaffHR objects in the database ordered by the columns specified.</returns>
        public static StaffHRCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spStaffHR_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StaffHR objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the StaffHR objects in the database.</returns>
        public static StaffHRCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            StaffHRCollection result = new StaffHRCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    StaffHR tmp = new StaffHR();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a StaffHR object from the database.
        /// </summary>
        /// <param name="hRId">The primary key value</param>
        public static void Delete(Guid hRId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@HRId", hRId) };
            SqlHelper.Default.ExecuteNonQuery("spStaffHR_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) hRId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) staffId = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) employmentNumber = reader.GetString(2);
                if (!reader.IsDBNull(3)) hiredOn = reader.GetDateTime(3);
                if (!reader.IsDBNull(4)) salary = reader.GetDecimal(4);
                if (!reader.IsDBNull(5)) medicalNumber = reader.GetString(5);
                if (!reader.IsDBNull(6)) bankAccountNumber = reader.GetString(6);
                if (!reader.IsDBNull(7)) tC_AdminEnable = reader.GetBoolean(7);
                if (!reader.IsDBNull(8)) tC_PunchEnable = reader.GetBoolean(8);
                if (!reader.IsDBNull(9)) tC_PunchEnable_InOut = reader.GetBoolean(9);
                if (!reader.IsDBNull(10)) tC_PunchEnable_DayView = reader.GetBoolean(10);
                if (!reader.IsDBNull(11)) paidAnnualLeave = reader.GetDecimal(11);
                if (!reader.IsDBNull(12)) paidSickLeave = reader.GetDecimal(12);
                if (!reader.IsDBNull(13)) paidSickLeaveWithoutCert = reader.GetDecimal(13);
            }
        }
		
        public void Delete()
        {
            Delete(this.HRId);
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
                if (key != HRId)
                    this.Delete();
                Update();
            }
        }

        public Guid HRId
        {
            get { return hRId; }
            set { hRId = value; }
        }

        public Guid StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        public string EmploymentNumber
        {
            get { return employmentNumber; }
            set { employmentNumber = value; }
        }

        public DateTime HiredOn
        {
            get { return hiredOn; }
            set { hiredOn = value; }
        }

        public decimal Salary
        {
            get { return salary; }
            set { salary = value; }
        }

        public string MedicalNumber
        {
            get { return medicalNumber; }
            set { medicalNumber = value; }
        }

        public string BankAccountNumber
        {
            get { return bankAccountNumber; }
            set { bankAccountNumber = value; }
        }

        public bool TC_AdminEnable
        {
            get { return tC_AdminEnable; }
            set { tC_AdminEnable = value; }
        }

        public bool TC_PunchEnable
        {
            get { return tC_PunchEnable; }
            set { tC_PunchEnable = value; }
        }

        public bool TC_PunchEnable_InOut
        {
            get { return tC_PunchEnable_InOut; }
            set { tC_PunchEnable_InOut = value; }
        }

        public bool TC_PunchEnable_DayView
        {
            get { return tC_PunchEnable_DayView; }
            set { tC_PunchEnable_DayView = value; }
        }

        public decimal PaidAnnualLeave
        {
            get { return paidAnnualLeave; }
            set { paidAnnualLeave = value; }
        }

        public decimal PaidSickLeave
        {
            get { return paidSickLeave; }
            set { paidSickLeave = value; }
        }

        public decimal PaidSickLeaveWithoutCert
        {
            get { return paidSickLeaveWithoutCert; }
            set { paidSickLeaveWithoutCert = value; }
        }


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spStaffHR_InsRec", "@HRId", out returnedValue, parameterValues);
            
            hRId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spStaffHR_UpdRec", parameterValues);
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
            SqlParameter[] prams = new SqlParameter[14];
            prams[0] = GetSqlParameter("@HRId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.HRId);
            prams[1] = GetSqlParameter("@StaffId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.StaffId);
            prams[2] = GetSqlParameter("@EmploymentNumber", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.EmploymentNumber);
            prams[3] = GetSqlParameter("@HiredOn", ParameterDirection.Input, SqlDbType.SmallDateTime, 4, this.HiredOn);
            prams[4] = GetSqlParameter("@Salary", ParameterDirection.Input, SqlDbType.Money, 8, this.Salary);
            prams[5] = GetSqlParameter("@MedicalNumber", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.MedicalNumber);
            prams[6] = GetSqlParameter("@BankAccountNumber", ParameterDirection.Input, SqlDbType.NVarChar, 14, this.BankAccountNumber);
            prams[7] = GetSqlParameter("@TC_AdminEnable", ParameterDirection.Input, SqlDbType.Bit, 1, this.TC_AdminEnable);
            prams[8] = GetSqlParameter("@TC_PunchEnable", ParameterDirection.Input, SqlDbType.Bit, 1, this.TC_PunchEnable);
            prams[9] = GetSqlParameter("@TC_PunchEnable_InOut", ParameterDirection.Input, SqlDbType.Bit, 1, this.TC_PunchEnable_InOut);
            prams[10] = GetSqlParameter("@TC_PunchEnable_DayView", ParameterDirection.Input, SqlDbType.Bit, 1, this.TC_PunchEnable_DayView);
            prams[11] = GetSqlParameter("@PaidAnnualLeave", ParameterDirection.Input, SqlDbType.Decimal, 5, this.PaidAnnualLeave);
            prams[12] = GetSqlParameter("@PaidSickLeave", ParameterDirection.Input, SqlDbType.Decimal, 5, this.PaidSickLeave);
            prams[13] = GetSqlParameter("@PaidSickLeaveWithoutCert", ParameterDirection.Input, SqlDbType.Decimal, 5, this.PaidSickLeaveWithoutCert);
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
                GetSqlParameterWithoutDirection("@HRId", SqlDbType.UniqueIdentifier, 16, this.HRId),
                GetSqlParameterWithoutDirection("@StaffId", SqlDbType.UniqueIdentifier, 16, this.StaffId),
                GetSqlParameterWithoutDirection("@EmploymentNumber", SqlDbType.NVarChar, 64, this.EmploymentNumber),
                GetSqlParameterWithoutDirection("@HiredOn", SqlDbType.SmallDateTime, 4, this.HiredOn),
                GetSqlParameterWithoutDirection("@Salary", SqlDbType.Money, 8, this.Salary),
                GetSqlParameterWithoutDirection("@MedicalNumber", SqlDbType.NVarChar, 64, this.MedicalNumber),
                GetSqlParameterWithoutDirection("@BankAccountNumber", SqlDbType.NVarChar, 14, this.BankAccountNumber),
                GetSqlParameterWithoutDirection("@TC_AdminEnable", SqlDbType.Bit, 1, this.TC_AdminEnable),
                GetSqlParameterWithoutDirection("@TC_PunchEnable", SqlDbType.Bit, 1, this.TC_PunchEnable),
                GetSqlParameterWithoutDirection("@TC_PunchEnable_InOut", SqlDbType.Bit, 1, this.TC_PunchEnable_InOut),
                GetSqlParameterWithoutDirection("@TC_PunchEnable_DayView", SqlDbType.Bit, 1, this.TC_PunchEnable_DayView),
                GetSqlParameterWithoutDirection("@PaidAnnualLeave", SqlDbType.Decimal, 5, this.PaidAnnualLeave),
                GetSqlParameterWithoutDirection("@PaidSickLeave", SqlDbType.Decimal, 5, this.PaidSickLeave),
                GetSqlParameterWithoutDirection("@PaidSickLeaveWithoutCert", SqlDbType.Decimal, 5, this.PaidSickLeaveWithoutCert)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("hRId: " + hRId.ToString()).Append("\r\n");
            builder.Append("staffId: " + staffId.ToString()).Append("\r\n");
            builder.Append("employmentNumber: " + employmentNumber.ToString()).Append("\r\n");
            builder.Append("hiredOn: " + hiredOn.ToString()).Append("\r\n");
            builder.Append("salary: " + salary.ToString()).Append("\r\n");
            builder.Append("medicalNumber: " + medicalNumber.ToString()).Append("\r\n");
            builder.Append("bankAccountNumber: " + bankAccountNumber.ToString()).Append("\r\n");
            builder.Append("tC_AdminEnable: " + tC_AdminEnable.ToString()).Append("\r\n");
            builder.Append("tC_PunchEnable: " + tC_PunchEnable.ToString()).Append("\r\n");
            builder.Append("tC_PunchEnable_InOut: " + tC_PunchEnable_InOut.ToString()).Append("\r\n");
            builder.Append("tC_PunchEnable_DayView: " + tC_PunchEnable_DayView.ToString()).Append("\r\n");
            builder.Append("paidAnnualLeave: " + paidAnnualLeave.ToString()).Append("\r\n");
            builder.Append("paidSickLeave: " + paidSickLeave.ToString()).Append("\r\n");
            builder.Append("paidSickLeaveWithoutCert: " + paidSickLeaveWithoutCert.ToString()).Append("\r\n");
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
			
			StaffHRCollection source;
            
            if(OrderBy == null || OrderBy.Length == 0)
            {
			    OrderBy = TextField;
            }
			
			if (WhereClause.Length > 0)
			{
				source = StaffHR.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = StaffHR.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (StaffHR item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.StaffId != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.HRId));
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
		
		
		private static bool IgnorThis(StaffHR target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.StaffId == Guid.Empty)
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
				StaffHR parentTemplate = StaffHR.Load(target.StaffId);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(StaffHR target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="StaffHR">StaffHR</see> objects.
    /// </summary>
    public class StaffHRCollection : BindingList< StaffHR>
    {
	}
}
