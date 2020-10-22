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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.InvtSubLedgerRPL_Header.
    /// Date Created:   2020-08-09 02:14:11
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class InvtSubLedgerRPL_Header
    {
        private Guid key = Guid.Empty;
        private Guid headerId = Guid.Empty;
        private string txNumber = String.Empty;
        private DateTime txDate = DateTime.Parse("1900-1-1");
        private Guid staffId = Guid.Empty;
        private string fromLocation = String.Empty;
        private string toLocation = String.Empty;
        private DateTime tXFOn = DateTime.Parse("1900-1-1");
        private string tXFNumber = String.Empty;
        private DateTime completedOn = DateTime.Parse("1900-1-1");
        private string remarks = String.Empty;
        private bool posted;
        private DateTime postedOn = DateTime.Parse("1900-1-1");
        private Guid postedBy = Guid.Empty;
        private bool confirmed;
        private DateTime confirmedOn = DateTime.Parse("1900-1-1");
        private Guid confirmedBy = Guid.Empty;
        private bool specialRequest;
        private int status = 0;
        private DateTime createdOn = DateTime.Parse("1900-1-1");
        private Guid createdBy = Guid.Empty;
        private DateTime modifiedOn = DateTime.Parse("1900-1-1");
        private Guid modifiedBy = Guid.Empty;
        private bool retired;
        private DateTime retiredOn = DateTime.Parse("1900-1-1");
        private Guid retiredBy = Guid.Empty;

        /// <summary>
        /// Initialize an new empty InvtSubLedgerRPL_Header object.
        /// </summary>
        public InvtSubLedgerRPL_Header()
        {
        }
		
        /// <summary>
        /// Initialize a new InvtSubLedgerRPL_Header object with the given parameters.
        /// </summary>
        public InvtSubLedgerRPL_Header(Guid headerId, string txNumber, DateTime txDate, Guid staffId, string fromLocation, string toLocation, DateTime tXFOn, string tXFNumber, DateTime completedOn, string remarks, bool posted, DateTime postedOn, Guid postedBy, bool confirmed, DateTime confirmedOn, Guid confirmedBy, bool specialRequest, int status, DateTime createdOn, Guid createdBy, DateTime modifiedOn, Guid modifiedBy, bool retired, DateTime retiredOn, Guid retiredBy)
        {
                this.headerId = headerId;
                this.txNumber = txNumber;
                this.txDate = txDate;
                this.staffId = staffId;
                this.fromLocation = fromLocation;
                this.toLocation = toLocation;
                this.tXFOn = tXFOn;
                this.tXFNumber = tXFNumber;
                this.completedOn = completedOn;
                this.remarks = remarks;
                this.posted = posted;
                this.postedOn = postedOn;
                this.postedBy = postedBy;
                this.confirmed = confirmed;
                this.confirmedOn = confirmedOn;
                this.confirmedBy = confirmedBy;
                this.specialRequest = specialRequest;
                this.status = status;
                this.createdOn = createdOn;
                this.createdBy = createdBy;
                this.modifiedOn = modifiedOn;
                this.modifiedBy = modifiedBy;
                this.retired = retired;
                this.retiredOn = retiredOn;
                this.retiredBy = retiredBy;
        }	
		
        /// <summary>
        /// Loads a InvtSubLedgerRPL_Header object from the database using the given HeaderId
        /// </summary>
        /// <param name="headerId">The primary key value</param>
        /// <returns>A InvtSubLedgerRPL_Header object</returns>
        public static InvtSubLedgerRPL_Header Load(Guid headerId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@HeaderId", headerId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spInvtSubLedgerRPL_Header_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    InvtSubLedgerRPL_Header result = new InvtSubLedgerRPL_Header();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a InvtSubLedgerRPL_Header object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A InvtSubLedgerRPL_Header object</returns>
        public static InvtSubLedgerRPL_Header LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spInvtSubLedgerRPL_Header_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    InvtSubLedgerRPL_Header result = new InvtSubLedgerRPL_Header();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of InvtSubLedgerRPL_Header objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the InvtSubLedgerRPL_Header objects in the database.</returns>
        public static InvtSubLedgerRPL_HeaderCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spInvtSubLedgerRPL_Header_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of InvtSubLedgerRPL_Header objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the InvtSubLedgerRPL_Header objects in the database ordered by the columns specified.</returns>
        public static InvtSubLedgerRPL_HeaderCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spInvtSubLedgerRPL_Header_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of InvtSubLedgerRPL_Header objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the InvtSubLedgerRPL_Header objects in the database.</returns>
        public static InvtSubLedgerRPL_HeaderCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spInvtSubLedgerRPL_Header_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of InvtSubLedgerRPL_Header objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the InvtSubLedgerRPL_Header objects in the database ordered by the columns specified.</returns>
        public static InvtSubLedgerRPL_HeaderCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spInvtSubLedgerRPL_Header_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of InvtSubLedgerRPL_Header objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the InvtSubLedgerRPL_Header objects in the database.</returns>
        public static InvtSubLedgerRPL_HeaderCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            InvtSubLedgerRPL_HeaderCollection result = new InvtSubLedgerRPL_HeaderCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    InvtSubLedgerRPL_Header tmp = new InvtSubLedgerRPL_Header();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a InvtSubLedgerRPL_Header object from the database.
        /// </summary>
        /// <param name="headerId">The primary key value</param>
        public static void Delete(Guid headerId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@HeaderId", headerId) };
            SqlHelper.Default.ExecuteNonQuery("spInvtSubLedgerRPL_Header_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) headerId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) txNumber = reader.GetString(1);
                if (!reader.IsDBNull(2)) txDate = reader.GetDateTime(2);
                if (!reader.IsDBNull(3)) staffId = reader.GetGuid(3);
                if (!reader.IsDBNull(4)) fromLocation = reader.GetString(4);
                if (!reader.IsDBNull(5)) toLocation = reader.GetString(5);
                if (!reader.IsDBNull(6)) tXFOn = reader.GetDateTime(6);
                if (!reader.IsDBNull(7)) tXFNumber = reader.GetString(7);
                if (!reader.IsDBNull(8)) completedOn = reader.GetDateTime(8);
                if (!reader.IsDBNull(9)) remarks = reader.GetString(9);
                if (!reader.IsDBNull(10)) posted = reader.GetBoolean(10);
                if (!reader.IsDBNull(11)) postedOn = reader.GetDateTime(11);
                if (!reader.IsDBNull(12)) postedBy = reader.GetGuid(12);
                if (!reader.IsDBNull(13)) confirmed = reader.GetBoolean(13);
                if (!reader.IsDBNull(14)) confirmedOn = reader.GetDateTime(14);
                if (!reader.IsDBNull(15)) confirmedBy = reader.GetGuid(15);
                if (!reader.IsDBNull(16)) specialRequest = reader.GetBoolean(16);
                if (!reader.IsDBNull(17)) status = reader.GetInt32(17);
                if (!reader.IsDBNull(18)) createdOn = reader.GetDateTime(18);
                if (!reader.IsDBNull(19)) createdBy = reader.GetGuid(19);
                if (!reader.IsDBNull(20)) modifiedOn = reader.GetDateTime(20);
                if (!reader.IsDBNull(21)) modifiedBy = reader.GetGuid(21);
                if (!reader.IsDBNull(22)) retired = reader.GetBoolean(22);
                if (!reader.IsDBNull(23)) retiredOn = reader.GetDateTime(23);
                if (!reader.IsDBNull(24)) retiredBy = reader.GetGuid(24);
            }
        }
		
        public void Delete()
        {
            Delete(this.HeaderId);
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
                if (key != HeaderId)
                    this.Delete();
                Update();
            }
        }

        public Guid HeaderId
        {
            get { return headerId; }
            set { headerId = value; }
        }

        public string TxNumber
        {
            get { return txNumber; }
            set { txNumber = value; }
        }

        public DateTime TxDate
        {
            get { return txDate; }
            set { txDate = value; }
        }

        public Guid StaffId
        {
            get { return staffId; }
            set { staffId = value; }
        }

        public string FromLocation
        {
            get { return fromLocation; }
            set { fromLocation = value; }
        }

        public string ToLocation
        {
            get { return toLocation; }
            set { toLocation = value; }
        }

        public DateTime TXFOn
        {
            get { return tXFOn; }
            set { tXFOn = value; }
        }

        public string TXFNumber
        {
            get { return tXFNumber; }
            set { tXFNumber = value; }
        }

        public DateTime CompletedOn
        {
            get { return completedOn; }
            set { completedOn = value; }
        }

        public string Remarks
        {
            get { return remarks; }
            set { remarks = value; }
        }

        public bool Posted
        {
            get { return posted; }
            set { posted = value; }
        }

        public DateTime PostedOn
        {
            get { return postedOn; }
            set { postedOn = value; }
        }

        public Guid PostedBy
        {
            get { return postedBy; }
            set { postedBy = value; }
        }

        public bool Confirmed
        {
            get { return confirmed; }
            set { confirmed = value; }
        }

        public DateTime ConfirmedOn
        {
            get { return confirmedOn; }
            set { confirmedOn = value; }
        }

        public Guid ConfirmedBy
        {
            get { return confirmedBy; }
            set { confirmedBy = value; }
        }

        public bool SpecialRequest
        {
            get { return specialRequest; }
            set { specialRequest = value; }
        }

        public int Status
        {
            get { return status; }
            set { status = value; }
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
			
            SqlHelper.Default.ExecuteNonQuery("spInvtSubLedgerRPL_Header_InsRec", "@HeaderId", out returnedValue, parameterValues);
            
            headerId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spInvtSubLedgerRPL_Header_UpdRec", parameterValues);
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
            SqlParameter[] prams = new SqlParameter[25];
            prams[0] = GetSqlParameter("@HeaderId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.HeaderId);
            prams[1] = GetSqlParameter("@TxNumber", ParameterDirection.Input, SqlDbType.VarChar, 12, this.TxNumber);
            prams[2] = GetSqlParameter("@TxDate", ParameterDirection.Input, SqlDbType.DateTime, 8, this.TxDate);
            prams[3] = GetSqlParameter("@StaffId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.StaffId);
            prams[4] = GetSqlParameter("@FromLocation", ParameterDirection.Input, SqlDbType.VarChar, 4, this.FromLocation);
            prams[5] = GetSqlParameter("@ToLocation", ParameterDirection.Input, SqlDbType.VarChar, 4, this.ToLocation);
            prams[6] = GetSqlParameter("@TXFOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.TXFOn);
            prams[7] = GetSqlParameter("@TXFNumber", ParameterDirection.Input, SqlDbType.VarChar, 12, this.TXFNumber);
            prams[8] = GetSqlParameter("@CompletedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.CompletedOn);
            prams[9] = GetSqlParameter("@Remarks", ParameterDirection.Input, SqlDbType.NVarChar, 512, this.Remarks);
            prams[10] = GetSqlParameter("@Posted", ParameterDirection.Input, SqlDbType.Bit, 1, this.Posted);
            prams[11] = GetSqlParameter("@PostedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.PostedOn);
            prams[12] = GetSqlParameter("@PostedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.PostedBy);
            prams[13] = GetSqlParameter("@Confirmed", ParameterDirection.Input, SqlDbType.Bit, 1, this.Confirmed);
            prams[14] = GetSqlParameter("@ConfirmedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.ConfirmedOn);
            prams[15] = GetSqlParameter("@ConfirmedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ConfirmedBy);
            prams[16] = GetSqlParameter("@SpecialRequest", ParameterDirection.Input, SqlDbType.Bit, 1, this.SpecialRequest);
            prams[17] = GetSqlParameter("@Status", ParameterDirection.Input, SqlDbType.Int, 4, this.Status);
            prams[18] = GetSqlParameter("@CreatedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.CreatedOn);
            prams[19] = GetSqlParameter("@CreatedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.CreatedBy);
            prams[20] = GetSqlParameter("@ModifiedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.ModifiedOn);
            prams[21] = GetSqlParameter("@ModifiedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ModifiedBy);
            prams[22] = GetSqlParameter("@Retired", ParameterDirection.Input, SqlDbType.Bit, 1, this.Retired);
            prams[23] = GetSqlParameter("@RetiredOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.RetiredOn);
            prams[24] = GetSqlParameter("@RetiredBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.RetiredBy);
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
                GetSqlParameterWithoutDirection("@HeaderId", SqlDbType.UniqueIdentifier, 16, this.HeaderId),
                GetSqlParameterWithoutDirection("@TxNumber", SqlDbType.VarChar, 12, this.TxNumber),
                GetSqlParameterWithoutDirection("@TxDate", SqlDbType.DateTime, 8, this.TxDate),
                GetSqlParameterWithoutDirection("@StaffId", SqlDbType.UniqueIdentifier, 16, this.StaffId),
                GetSqlParameterWithoutDirection("@FromLocation", SqlDbType.VarChar, 4, this.FromLocation),
                GetSqlParameterWithoutDirection("@ToLocation", SqlDbType.VarChar, 4, this.ToLocation),
                GetSqlParameterWithoutDirection("@TXFOn", SqlDbType.DateTime, 8, this.TXFOn),
                GetSqlParameterWithoutDirection("@TXFNumber", SqlDbType.VarChar, 12, this.TXFNumber),
                GetSqlParameterWithoutDirection("@CompletedOn", SqlDbType.DateTime, 8, this.CompletedOn),
                GetSqlParameterWithoutDirection("@Remarks", SqlDbType.NVarChar, 512, this.Remarks),
                GetSqlParameterWithoutDirection("@Posted", SqlDbType.Bit, 1, this.Posted),
                GetSqlParameterWithoutDirection("@PostedOn", SqlDbType.DateTime, 8, this.PostedOn),
                GetSqlParameterWithoutDirection("@PostedBy", SqlDbType.UniqueIdentifier, 16, this.PostedBy),
                GetSqlParameterWithoutDirection("@Confirmed", SqlDbType.Bit, 1, this.Confirmed),
                GetSqlParameterWithoutDirection("@ConfirmedOn", SqlDbType.DateTime, 8, this.ConfirmedOn),
                GetSqlParameterWithoutDirection("@ConfirmedBy", SqlDbType.UniqueIdentifier, 16, this.ConfirmedBy),
                GetSqlParameterWithoutDirection("@SpecialRequest", SqlDbType.Bit, 1, this.SpecialRequest),
                GetSqlParameterWithoutDirection("@Status", SqlDbType.Int, 4, this.Status),
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
            builder.Append("headerId: " + headerId.ToString()).Append("\r\n");
            builder.Append("txNumber: " + txNumber.ToString()).Append("\r\n");
            builder.Append("txDate: " + txDate.ToString()).Append("\r\n");
            builder.Append("staffId: " + staffId.ToString()).Append("\r\n");
            builder.Append("fromLocation: " + fromLocation.ToString()).Append("\r\n");
            builder.Append("toLocation: " + toLocation.ToString()).Append("\r\n");
            builder.Append("tXFOn: " + tXFOn.ToString()).Append("\r\n");
            builder.Append("tXFNumber: " + tXFNumber.ToString()).Append("\r\n");
            builder.Append("completedOn: " + completedOn.ToString()).Append("\r\n");
            builder.Append("remarks: " + remarks.ToString()).Append("\r\n");
            builder.Append("posted: " + posted.ToString()).Append("\r\n");
            builder.Append("postedOn: " + postedOn.ToString()).Append("\r\n");
            builder.Append("postedBy: " + postedBy.ToString()).Append("\r\n");
            builder.Append("confirmed: " + confirmed.ToString()).Append("\r\n");
            builder.Append("confirmedOn: " + confirmedOn.ToString()).Append("\r\n");
            builder.Append("confirmedBy: " + confirmedBy.ToString()).Append("\r\n");
            builder.Append("specialRequest: " + specialRequest.ToString()).Append("\r\n");
            builder.Append("status: " + status.ToString()).Append("\r\n");
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
			
			InvtSubLedgerRPL_HeaderCollection source;
            
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
				source = InvtSubLedgerRPL_Header.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = InvtSubLedgerRPL_Header.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (InvtSubLedgerRPL_Header item in source)
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
                    sourceList.Add(new Common.ComboItem(code, item.HeaderId));
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
		
		
		private static bool IgnorThis(InvtSubLedgerRPL_Header target, string parentFilter)
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
				InvtSubLedgerRPL_Header parentTemplate = InvtSubLedgerRPL_Header.Load(target.StaffId);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(InvtSubLedgerRPL_Header target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="InvtSubLedgerRPL_Header">InvtSubLedgerRPL_Header</see> objects.
    /// </summary>
    public class InvtSubLedgerRPL_HeaderCollection : BindingList< InvtSubLedgerRPL_Header>
    {
	}
}
