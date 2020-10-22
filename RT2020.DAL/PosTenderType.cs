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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.PosTenderType.
    /// Date Created:   2020-08-09 02:14:13
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class PosTenderType
    {
        private Guid key = Guid.Empty;
        private Guid typeId = Guid.Empty;
        private string typeCode = String.Empty;
        private string typeName = String.Empty;
        private string typeName_Chs = String.Empty;
        private string typeName_Cht = String.Empty;
        private int priority = 0;
        private string currencyCode = String.Empty;
        private decimal exchangeRate;
        private string alternateCurrencyCode = String.Empty;
        private decimal bF_AMT;
        private decimal bF_XRATE;
        private bool downloadToPOS;
        private decimal chargeRate;
        private decimal chargeAmount;
        private decimal additionalMonthlyCharge;
        private decimal minimumMonthlyCharge;
        private DateTime createdOn = DateTime.Parse("1900-1-1");
        private Guid createdBy = Guid.Empty;
        private DateTime modifiedOn = DateTime.Parse("1900-1-1");
        private Guid modifiedBy = Guid.Empty;
        private bool retired;
        private Guid retiredBy = Guid.Empty;
        private DateTime retiredOn = DateTime.Parse("1900-1-1");

        /// <summary>
        /// Initialize an new empty PosTenderType object.
        /// </summary>
        public PosTenderType()
        {
        }
		
        /// <summary>
        /// Initialize a new PosTenderType object with the given parameters.
        /// </summary>
        public PosTenderType(Guid typeId, string typeCode, string typeName, string typeName_Chs, string typeName_Cht, int priority, string currencyCode, decimal exchangeRate, string alternateCurrencyCode, decimal bF_AMT, decimal bF_XRATE, bool downloadToPOS, decimal chargeRate, decimal chargeAmount, decimal additionalMonthlyCharge, decimal minimumMonthlyCharge, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, bool retired, Guid retiredBy, DateTime retiredOn)
        {
                this.typeId = typeId;
                this.typeCode = typeCode;
                this.typeName = typeName;
                this.typeName_Chs = typeName_Chs;
                this.typeName_Cht = typeName_Cht;
                this.priority = priority;
                this.currencyCode = currencyCode;
                this.exchangeRate = exchangeRate;
                this.alternateCurrencyCode = alternateCurrencyCode;
                this.bF_AMT = bF_AMT;
                this.bF_XRATE = bF_XRATE;
                this.downloadToPOS = downloadToPOS;
                this.chargeRate = chargeRate;
                this.chargeAmount = chargeAmount;
                this.additionalMonthlyCharge = additionalMonthlyCharge;
                this.minimumMonthlyCharge = minimumMonthlyCharge;
                this.createdOn = createdOn;
                this.createdBy = createdBy;
                this.modifiedOn = modifiedOn;
                this.modifiedBy = modifiedBy;
                this.retired = retired;
                this.retiredBy = retiredBy;
                this.retiredOn = retiredOn;
        }	
		
        /// <summary>
        /// Loads a PosTenderType object from the database using the given TypeId
        /// </summary>
        /// <param name="typeId">The primary key value</param>
        /// <returns>A PosTenderType object</returns>
        public static PosTenderType Load(Guid typeId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spPosTenderType_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    PosTenderType result = new PosTenderType();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a PosTenderType object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A PosTenderType object</returns>
        public static PosTenderType LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spPosTenderType_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    PosTenderType result = new PosTenderType();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of PosTenderType objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the PosTenderType objects in the database.</returns>
        public static PosTenderTypeCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spPosTenderType_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PosTenderType objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the PosTenderType objects in the database ordered by the columns specified.</returns>
        public static PosTenderTypeCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spPosTenderType_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PosTenderType objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the PosTenderType objects in the database.</returns>
        public static PosTenderTypeCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spPosTenderType_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PosTenderType objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the PosTenderType objects in the database ordered by the columns specified.</returns>
        public static PosTenderTypeCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spPosTenderType_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of PosTenderType objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the PosTenderType objects in the database.</returns>
        public static PosTenderTypeCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            PosTenderTypeCollection result = new PosTenderTypeCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    PosTenderType tmp = new PosTenderType();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a PosTenderType object from the database.
        /// </summary>
        /// <param name="typeId">The primary key value</param>
        public static void Delete(Guid typeId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@TypeId", typeId) };
            SqlHelper.Default.ExecuteNonQuery("spPosTenderType_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) typeId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) typeCode = reader.GetString(1);
                if (!reader.IsDBNull(2)) typeName = reader.GetString(2);
                if (!reader.IsDBNull(3)) typeName_Chs = reader.GetString(3);
                if (!reader.IsDBNull(4)) typeName_Cht = reader.GetString(4);
                if (!reader.IsDBNull(5)) priority = reader.GetInt32(5);
                if (!reader.IsDBNull(6)) currencyCode = reader.GetString(6);
                if (!reader.IsDBNull(7)) exchangeRate = reader.GetDecimal(7);
                if (!reader.IsDBNull(8)) alternateCurrencyCode = reader.GetString(8);
                if (!reader.IsDBNull(9)) bF_AMT = reader.GetDecimal(9);
                if (!reader.IsDBNull(10)) bF_XRATE = reader.GetDecimal(10);
                if (!reader.IsDBNull(11)) downloadToPOS = reader.GetBoolean(11);
                if (!reader.IsDBNull(12)) chargeRate = reader.GetDecimal(12);
                if (!reader.IsDBNull(13)) chargeAmount = reader.GetDecimal(13);
                if (!reader.IsDBNull(14)) additionalMonthlyCharge = reader.GetDecimal(14);
                if (!reader.IsDBNull(15)) minimumMonthlyCharge = reader.GetDecimal(15);
                if (!reader.IsDBNull(16)) createdOn = reader.GetDateTime(16);
                if (!reader.IsDBNull(17)) createdBy = reader.GetGuid(17);
                if (!reader.IsDBNull(18)) modifiedOn = reader.GetDateTime(18);
                if (!reader.IsDBNull(19)) modifiedBy = reader.GetGuid(19);
                if (!reader.IsDBNull(20)) retired = reader.GetBoolean(20);
                if (!reader.IsDBNull(21)) retiredBy = reader.GetGuid(21);
                if (!reader.IsDBNull(22)) retiredOn = reader.GetDateTime(22);
            }
        }
		
        public void Delete()
        {
            Delete(this.TypeId);
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
                if (key != TypeId)
                    this.Delete();
                Update();
            }
        }

        public Guid TypeId
        {
            get { return typeId; }
            set { typeId = value; }
        }

        public string TypeCode
        {
            get { return typeCode; }
            set { typeCode = value; }
        }

        public string TypeName
        {
            get { return typeName; }
            set { typeName = value; }
        }

        public string TypeName_Chs
        {
            get { return typeName_Chs; }
            set { typeName_Chs = value; }
        }

        public string TypeName_Cht
        {
            get { return typeName_Cht; }
            set { typeName_Cht = value; }
        }

        public int Priority
        {
            get { return priority; }
            set { priority = value; }
        }

        public string CurrencyCode
        {
            get { return currencyCode; }
            set { currencyCode = value; }
        }

        public decimal ExchangeRate
        {
            get { return exchangeRate; }
            set { exchangeRate = value; }
        }

        public string AlternateCurrencyCode
        {
            get { return alternateCurrencyCode; }
            set { alternateCurrencyCode = value; }
        }

        public decimal BF_AMT
        {
            get { return bF_AMT; }
            set { bF_AMT = value; }
        }

        public decimal BF_XRATE
        {
            get { return bF_XRATE; }
            set { bF_XRATE = value; }
        }

        public bool DownloadToPOS
        {
            get { return downloadToPOS; }
            set { downloadToPOS = value; }
        }

        public decimal ChargeRate
        {
            get { return chargeRate; }
            set { chargeRate = value; }
        }

        public decimal ChargeAmount
        {
            get { return chargeAmount; }
            set { chargeAmount = value; }
        }

        public decimal AdditionalMonthlyCharge
        {
            get { return additionalMonthlyCharge; }
            set { additionalMonthlyCharge = value; }
        }

        public decimal MinimumMonthlyCharge
        {
            get { return minimumMonthlyCharge; }
            set { minimumMonthlyCharge = value; }
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

        public Guid RetiredBy
        {
            get { return retiredBy; }
            set { retiredBy = value; }
        }

        public DateTime RetiredOn
        {
            get { return retiredOn; }
            set { retiredOn = value; }
        }


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spPosTenderType_InsRec", "@TypeId", out returnedValue, parameterValues);
            
            typeId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spPosTenderType_UpdRec", parameterValues);
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
            SqlParameter[] prams = new SqlParameter[23];
            prams[0] = GetSqlParameter("@TypeId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.TypeId);
            prams[1] = GetSqlParameter("@TypeCode", ParameterDirection.Input, SqlDbType.VarChar, 4, this.TypeCode);
            prams[2] = GetSqlParameter("@TypeName", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.TypeName);
            prams[3] = GetSqlParameter("@TypeName_Chs", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.TypeName_Chs);
            prams[4] = GetSqlParameter("@TypeName_Cht", ParameterDirection.Input, SqlDbType.NVarChar, 64, this.TypeName_Cht);
            prams[5] = GetSqlParameter("@Priority", ParameterDirection.Input, SqlDbType.Int, 4, this.Priority);
            prams[6] = GetSqlParameter("@CurrencyCode", ParameterDirection.Input, SqlDbType.VarChar, 3, this.CurrencyCode);
            prams[7] = GetSqlParameter("@ExchangeRate", ParameterDirection.Input, SqlDbType.Decimal, 5, this.ExchangeRate);
            prams[8] = GetSqlParameter("@AlternateCurrencyCode", ParameterDirection.Input, SqlDbType.NVarChar, 20, this.AlternateCurrencyCode);
            prams[9] = GetSqlParameter("@BF_AMT", ParameterDirection.Input, SqlDbType.Money, 8, this.BF_AMT);
            prams[10] = GetSqlParameter("@BF_XRATE", ParameterDirection.Input, SqlDbType.Decimal, 5, this.BF_XRATE);
            prams[11] = GetSqlParameter("@DownloadToPOS", ParameterDirection.Input, SqlDbType.Bit, 1, this.DownloadToPOS);
            prams[12] = GetSqlParameter("@ChargeRate", ParameterDirection.Input, SqlDbType.Decimal, 5, this.ChargeRate);
            prams[13] = GetSqlParameter("@ChargeAmount", ParameterDirection.Input, SqlDbType.Money, 8, this.ChargeAmount);
            prams[14] = GetSqlParameter("@AdditionalMonthlyCharge", ParameterDirection.Input, SqlDbType.Money, 8, this.AdditionalMonthlyCharge);
            prams[15] = GetSqlParameter("@MinimumMonthlyCharge", ParameterDirection.Input, SqlDbType.Money, 8, this.MinimumMonthlyCharge);
            prams[16] = GetSqlParameter("@CreatedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.CreatedOn);
            prams[17] = GetSqlParameter("@CreatedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.CreatedBy);
            prams[18] = GetSqlParameter("@ModifiedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.ModifiedOn);
            prams[19] = GetSqlParameter("@ModifiedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ModifiedBy);
            prams[20] = GetSqlParameter("@Retired", ParameterDirection.Input, SqlDbType.Bit, 1, this.Retired);
            prams[21] = GetSqlParameter("@RetiredBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.RetiredBy);
            prams[22] = GetSqlParameter("@RetiredOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.RetiredOn);
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
                GetSqlParameterWithoutDirection("@TypeId", SqlDbType.UniqueIdentifier, 16, this.TypeId),
                GetSqlParameterWithoutDirection("@TypeCode", SqlDbType.VarChar, 4, this.TypeCode),
                GetSqlParameterWithoutDirection("@TypeName", SqlDbType.NVarChar, 64, this.TypeName),
                GetSqlParameterWithoutDirection("@TypeName_Chs", SqlDbType.NVarChar, 64, this.TypeName_Chs),
                GetSqlParameterWithoutDirection("@TypeName_Cht", SqlDbType.NVarChar, 64, this.TypeName_Cht),
                GetSqlParameterWithoutDirection("@Priority", SqlDbType.Int, 4, this.Priority),
                GetSqlParameterWithoutDirection("@CurrencyCode", SqlDbType.VarChar, 3, this.CurrencyCode),
                GetSqlParameterWithoutDirection("@ExchangeRate", SqlDbType.Decimal, 5, this.ExchangeRate),
                GetSqlParameterWithoutDirection("@AlternateCurrencyCode", SqlDbType.NVarChar, 20, this.AlternateCurrencyCode),
                GetSqlParameterWithoutDirection("@BF_AMT", SqlDbType.Money, 8, this.BF_AMT),
                GetSqlParameterWithoutDirection("@BF_XRATE", SqlDbType.Decimal, 5, this.BF_XRATE),
                GetSqlParameterWithoutDirection("@DownloadToPOS", SqlDbType.Bit, 1, this.DownloadToPOS),
                GetSqlParameterWithoutDirection("@ChargeRate", SqlDbType.Decimal, 5, this.ChargeRate),
                GetSqlParameterWithoutDirection("@ChargeAmount", SqlDbType.Money, 8, this.ChargeAmount),
                GetSqlParameterWithoutDirection("@AdditionalMonthlyCharge", SqlDbType.Money, 8, this.AdditionalMonthlyCharge),
                GetSqlParameterWithoutDirection("@MinimumMonthlyCharge", SqlDbType.Money, 8, this.MinimumMonthlyCharge),
                GetSqlParameterWithoutDirection("@CreatedOn", SqlDbType.DateTime, 8, this.CreatedOn),
                GetSqlParameterWithoutDirection("@CreatedBy", SqlDbType.UniqueIdentifier, 16, this.CreatedBy),
                GetSqlParameterWithoutDirection("@ModifiedOn", SqlDbType.DateTime, 8, this.ModifiedOn),
                GetSqlParameterWithoutDirection("@ModifiedBy", SqlDbType.UniqueIdentifier, 16, this.ModifiedBy),
                GetSqlParameterWithoutDirection("@Retired", SqlDbType.Bit, 1, this.Retired),
                GetSqlParameterWithoutDirection("@RetiredBy", SqlDbType.UniqueIdentifier, 16, this.RetiredBy),
                GetSqlParameterWithoutDirection("@RetiredOn", SqlDbType.DateTime, 8, this.RetiredOn)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("typeId: " + typeId.ToString()).Append("\r\n");
            builder.Append("typeCode: " + typeCode.ToString()).Append("\r\n");
            builder.Append("typeName: " + typeName.ToString()).Append("\r\n");
            builder.Append("typeName_Chs: " + typeName_Chs.ToString()).Append("\r\n");
            builder.Append("typeName_Cht: " + typeName_Cht.ToString()).Append("\r\n");
            builder.Append("priority: " + priority.ToString()).Append("\r\n");
            builder.Append("currencyCode: " + currencyCode.ToString()).Append("\r\n");
            builder.Append("exchangeRate: " + exchangeRate.ToString()).Append("\r\n");
            builder.Append("alternateCurrencyCode: " + alternateCurrencyCode.ToString()).Append("\r\n");
            builder.Append("bF_AMT: " + bF_AMT.ToString()).Append("\r\n");
            builder.Append("bF_XRATE: " + bF_XRATE.ToString()).Append("\r\n");
            builder.Append("downloadToPOS: " + downloadToPOS.ToString()).Append("\r\n");
            builder.Append("chargeRate: " + chargeRate.ToString()).Append("\r\n");
            builder.Append("chargeAmount: " + chargeAmount.ToString()).Append("\r\n");
            builder.Append("additionalMonthlyCharge: " + additionalMonthlyCharge.ToString()).Append("\r\n");
            builder.Append("minimumMonthlyCharge: " + minimumMonthlyCharge.ToString()).Append("\r\n");
            builder.Append("createdOn: " + createdOn.ToString()).Append("\r\n");
            builder.Append("createdBy: " + createdBy.ToString()).Append("\r\n");
            builder.Append("modifiedOn: " + modifiedOn.ToString()).Append("\r\n");
            builder.Append("modifiedBy: " + modifiedBy.ToString()).Append("\r\n");
            builder.Append("retired: " + retired.ToString()).Append("\r\n");
            builder.Append("retiredBy: " + retiredBy.ToString()).Append("\r\n");
            builder.Append("retiredOn: " + retiredOn.ToString()).Append("\r\n");
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
			
			PosTenderTypeCollection source;
            
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
				source = PosTenderType.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = PosTenderType.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (PosTenderType item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = IgnorThis(item, ParentFilter);
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.TypeId));
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
		
		
		private static bool IgnorThis(PosTenderType target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			PropertyInfo pi = target.GetType().GetProperty(parsed[0]);
			string filterField = (string)pi.GetValue(target, null);
			if (filterField.ToLower() == parsed[1].ToLower())
			{
				result = false;
			}
			return result;
		}

		private static string GetFormatedText(PosTenderType target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="PosTenderType">PosTenderType</see> objects.
    /// </summary>
    public class PosTenderTypeCollection : BindingList< PosTenderType>
    {
	}
}
