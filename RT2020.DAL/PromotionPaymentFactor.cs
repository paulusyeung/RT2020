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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.PromotionPaymentFactor.
    /// Date Created:   2020-08-09 02:14:15
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class PromotionPaymentFactor
    {
        private Guid key = Guid.Empty;
        private Guid paymentFactorId = Guid.Empty;
        private Guid workplaceId = Guid.Empty;
        private DateTime startOn = DateTime.Parse("1900-1-1");
        private DateTime endOn = DateTime.Parse("1900-1-1");
        private string currencyCode = String.Empty;
        private string eventCode = String.Empty;
        private decimal factorRate;
        private DateTime createdOn = DateTime.Parse("1900-1-1");
        private Guid createdBy = Guid.Empty;
        private DateTime modifiedOn = DateTime.Parse("1900-1-1");
        private Guid modifiedBy = Guid.Empty;
        private bool retired;
        private DateTime retiredOn = DateTime.Parse("1900-1-1");
        private Guid retiredBy = Guid.Empty;

        /// <summary>
        /// Initialize an new empty PromotionPaymentFactor object.
        /// </summary>
        public PromotionPaymentFactor()
        {
        }
		
        /// <summary>
        /// Initialize a new PromotionPaymentFactor object with the given parameters.
        /// </summary>
        public PromotionPaymentFactor(Guid paymentFactorId, Guid workplaceId, DateTime startOn, DateTime endOn, string currencyCode, string eventCode, decimal factorRate, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, bool retired, DateTime retiredOn, Guid retiredBy)
        {
                this.paymentFactorId = paymentFactorId;
                this.workplaceId = workplaceId;
                this.startOn = startOn;
                this.endOn = endOn;
                this.currencyCode = currencyCode;
                this.eventCode = eventCode;
                this.factorRate = factorRate;
                this.createdOn = createdOn;
                this.createdBy = createdBy;
                this.modifiedOn = modifiedOn;
                this.modifiedBy = modifiedBy;
                this.retired = retired;
                this.retiredOn = retiredOn;
                this.retiredBy = retiredBy;
        }	
		
        /// <summary>
        /// Loads a PromotionPaymentFactor object from the database using the given PaymentFactorId
        /// </summary>
        /// <param name="paymentFactorId">The primary key value</param>
        /// <returns>A PromotionPaymentFactor object</returns>
        public static PromotionPaymentFactor Load(Guid paymentFactorId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@PaymentFactorId", paymentFactorId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spPromotionPaymentFactor_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    PromotionPaymentFactor result = new PromotionPaymentFactor();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a PromotionPaymentFactor object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A PromotionPaymentFactor object</returns>
        public static PromotionPaymentFactor LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spPromotionPaymentFactor_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    PromotionPaymentFactor result = new PromotionPaymentFactor();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of PromotionPaymentFactor objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the PromotionPaymentFactor objects in the database.</returns>
        public static PromotionPaymentFactorCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spPromotionPaymentFactor_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PromotionPaymentFactor objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the PromotionPaymentFactor objects in the database ordered by the columns specified.</returns>
        public static PromotionPaymentFactorCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spPromotionPaymentFactor_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PromotionPaymentFactor objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the PromotionPaymentFactor objects in the database.</returns>
        public static PromotionPaymentFactorCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spPromotionPaymentFactor_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PromotionPaymentFactor objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the PromotionPaymentFactor objects in the database ordered by the columns specified.</returns>
        public static PromotionPaymentFactorCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spPromotionPaymentFactor_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PromotionPaymentFactor objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the PromotionPaymentFactor objects in the database.</returns>
        public static PromotionPaymentFactorCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            PromotionPaymentFactorCollection result = new PromotionPaymentFactorCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    PromotionPaymentFactor tmp = new PromotionPaymentFactor();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a PromotionPaymentFactor object from the database.
        /// </summary>
        /// <param name="paymentFactorId">The primary key value</param>
        public static void Delete(Guid paymentFactorId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@PaymentFactorId", paymentFactorId) };
            SqlHelper.Default.ExecuteNonQuery("spPromotionPaymentFactor_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) paymentFactorId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) workplaceId = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) startOn = reader.GetDateTime(2);
                if (!reader.IsDBNull(3)) endOn = reader.GetDateTime(3);
                if (!reader.IsDBNull(4)) currencyCode = reader.GetString(4);
                if (!reader.IsDBNull(5)) eventCode = reader.GetString(5);
                if (!reader.IsDBNull(6)) factorRate = reader.GetDecimal(6);
                if (!reader.IsDBNull(7)) createdOn = reader.GetDateTime(7);
                if (!reader.IsDBNull(8)) createdBy = reader.GetGuid(8);
                if (!reader.IsDBNull(9)) modifiedOn = reader.GetDateTime(9);
                if (!reader.IsDBNull(10)) modifiedBy = reader.GetGuid(10);
                if (!reader.IsDBNull(11)) retired = reader.GetBoolean(11);
                if (!reader.IsDBNull(12)) retiredOn = reader.GetDateTime(12);
                if (!reader.IsDBNull(13)) retiredBy = reader.GetGuid(13);
            }
        }
		
        public void Delete()
        {
            Delete(this.PaymentFactorId);
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
                if (key != PaymentFactorId)
                    this.Delete();
                Update();
            }
        }

        public Guid PaymentFactorId
        {
            get { return paymentFactorId; }
            set { paymentFactorId = value; }
        }

        public Guid WorkplaceId
        {
            get { return workplaceId; }
            set { workplaceId = value; }
        }

        public DateTime StartOn
        {
            get { return startOn; }
            set { startOn = value; }
        }

        public DateTime EndOn
        {
            get { return endOn; }
            set { endOn = value; }
        }

        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        public string EventCode
        {
            get { return eventCode; }
            set { eventCode = value; }
        }

        public decimal FactorRate
        {
            get { return factorRate; }
            set { factorRate = value; }
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
			
            SqlHelper.Default.ExecuteNonQuery("spPromotionPaymentFactor_InsRec", "@PaymentFactorId", out returnedValue, parameterValues);
            
            paymentFactorId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spPromotionPaymentFactor_UpdRec", parameterValues);
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
            prams[0] = GetSqlParameter("@PaymentFactorId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.PaymentFactorId);
            prams[1] = GetSqlParameter("@WorkplaceId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.WorkplaceId);
            prams[2] = GetSqlParameter("@StartOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.StartOn);
            prams[3] = GetSqlParameter("@EndOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.EndOn);
            prams[4] = GetSqlParameter("@CurrencyCode", ParameterDirection.Input, SqlDbType.VarChar, 3, this.CurrencyCode);
            prams[5] = GetSqlParameter("@EventCode", ParameterDirection.Input, SqlDbType.VarChar, 6, this.EventCode);
            prams[6] = GetSqlParameter("@FactorRate", ParameterDirection.Input, SqlDbType.Decimal, 5, this.FactorRate);
            prams[7] = GetSqlParameter("@CreatedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.CreatedOn);
            prams[8] = GetSqlParameter("@CreatedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.CreatedBy);
            prams[9] = GetSqlParameter("@ModifiedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.ModifiedOn);
            prams[10] = GetSqlParameter("@ModifiedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ModifiedBy);
            prams[11] = GetSqlParameter("@Retired", ParameterDirection.Input, SqlDbType.Bit, 1, this.Retired);
            prams[12] = GetSqlParameter("@RetiredOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.RetiredOn);
            prams[13] = GetSqlParameter("@RetiredBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.RetiredBy);
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
                GetSqlParameterWithoutDirection("@PaymentFactorId", SqlDbType.UniqueIdentifier, 16, this.PaymentFactorId),
                GetSqlParameterWithoutDirection("@WorkplaceId", SqlDbType.UniqueIdentifier, 16, this.WorkplaceId),
                GetSqlParameterWithoutDirection("@StartOn", SqlDbType.DateTime, 8, this.StartOn),
                GetSqlParameterWithoutDirection("@EndOn", SqlDbType.DateTime, 8, this.EndOn),
                GetSqlParameterWithoutDirection("@CurrencyCode", SqlDbType.VarChar, 3, this.CurrencyCode),
                GetSqlParameterWithoutDirection("@EventCode", SqlDbType.VarChar, 6, this.EventCode),
                GetSqlParameterWithoutDirection("@FactorRate", SqlDbType.Decimal, 5, this.FactorRate),
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
            builder.Append("paymentFactorId: " + paymentFactorId.ToString()).Append("\r\n");
            builder.Append("workplaceId: " + workplaceId.ToString()).Append("\r\n");
            builder.Append("startOn: " + startOn.ToString()).Append("\r\n");
            builder.Append("endOn: " + endOn.ToString()).Append("\r\n");
            builder.Append("currencyCode: " + currencyCode.ToString()).Append("\r\n");
            builder.Append("eventCode: " + eventCode.ToString()).Append("\r\n");
            builder.Append("factorRate: " + factorRate.ToString()).Append("\r\n");
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
			
			PromotionPaymentFactorCollection source;
            
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
				source = PromotionPaymentFactor.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = PromotionPaymentFactor.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (PromotionPaymentFactor item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.WorkplaceId != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.PaymentFactorId));
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
		
		
		private static bool IgnorThis(PromotionPaymentFactor target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.WorkplaceId == Guid.Empty)
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
				PromotionPaymentFactor parentTemplate = PromotionPaymentFactor.Load(target.WorkplaceId);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(PromotionPaymentFactor target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="PromotionPaymentFactor">PromotionPaymentFactor</see> objects.
    /// </summary>
    public class PromotionPaymentFactorCollection : BindingList< PromotionPaymentFactor>
    {
	}
}
