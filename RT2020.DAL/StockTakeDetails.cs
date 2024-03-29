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
    /// This Data Access Layer Component (DALC) provides access to the data contained in the data table dbo.StockTakeDetails.
    /// Date Created:   2020-08-09 02:14:16
    /// Created By:     Generated by CodeSmith version 7.0.0.15123
    /// Template:       BusinessObjects_v5.0.cst
    /// </summary>
    public class StockTakeDetails
    {
        private Guid key = Guid.Empty;
        private Guid detailsId = Guid.Empty;
        private Guid headerId = Guid.Empty;
        private string txNumber = String.Empty;
        private Guid productId = Guid.Empty;
        private Guid workplaceId = Guid.Empty;
        private decimal capturedQty;
        private decimal hHTQty;
        private decimal book1Qty;
        private decimal book2Qty;
        private decimal book3Qty;
        private decimal book4Qty;
        private decimal book5Qty;
        private decimal averageCost;
        private DateTime modifiedOn = DateTime.Parse("1900-1-1");
        private Guid modifiedBy = Guid.Empty;

        /// <summary>
        /// Initialize an new empty StockTakeDetails object.
        /// </summary>
        public StockTakeDetails()
        {
        }
		
        /// <summary>
        /// Initialize a new StockTakeDetails object with the given parameters.
        /// </summary>
        public StockTakeDetails(Guid detailsId, Guid headerId, string txNumber, Guid productId, Guid workplaceId, decimal capturedQty, decimal hHTQty, decimal book1Qty, decimal book2Qty, decimal book3Qty, decimal book4Qty, decimal book5Qty, decimal averageCost, DateTime modifiedOn, Guid modifiedBy)
        {
                this.detailsId = detailsId;
                this.headerId = headerId;
                this.txNumber = txNumber;
                this.productId = productId;
                this.workplaceId = workplaceId;
                this.capturedQty = capturedQty;
                this.hHTQty = hHTQty;
                this.book1Qty = book1Qty;
                this.book2Qty = book2Qty;
                this.book3Qty = book3Qty;
                this.book4Qty = book4Qty;
                this.book5Qty = book5Qty;
                this.averageCost = averageCost;
                this.modifiedOn = modifiedOn;
                this.modifiedBy = modifiedBy;
        }	
		
        /// <summary>
        /// Loads a StockTakeDetails object from the database using the given DetailsId
        /// </summary>
        /// <param name="detailsId">The primary key value</param>
        /// <returns>A StockTakeDetails object</returns>
        public static StockTakeDetails Load(Guid detailsId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@DetailsId", detailsId) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spStockTakeDetails_SelRec", parameterValues))
            {
                if (reader.Read())
                {
                    StockTakeDetails result = new StockTakeDetails();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// Loads a StockTakeDetails object from the database using the given where clause
        /// </summary>
        /// <param name="whereClause">The filter expression for the query</param>
        /// <returns>A StockTakeDetails object</returns>
        public static StockTakeDetails LoadWhere(string whereClause)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader("spStockTakeDetails_SelAll", parameterValues))
            {
                if (reader.Read())
                {
                    StockTakeDetails result = new StockTakeDetails();
                    result.LoadFromReader(reader);
                    return result;
                }
                else
                    return null;
            }
        }
		
        /// <summary>
        /// Loads a collection of StockTakeDetails objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the StockTakeDetails objects in the database.</returns>
        public static StockTakeDetailsCollection LoadCollection()
        {
            SqlParameter[] parms = new SqlParameter[] {};
            return LoadCollection("spStockTakeDetails_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StockTakeDetails objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the StockTakeDetails objects in the database ordered by the columns specified.</returns>
        public static StockTakeDetailsCollection LoadCollection(string[] orderByColumns, bool ascending)
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
            return LoadCollection("spStockTakeDetails_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StockTakeDetails objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the StockTakeDetails objects in the database.</returns>
        public static StockTakeDetailsCollection LoadCollection(string whereClause)
        {
            SqlParameter[] parms = new SqlParameter[] { new SqlParameter("@WhereClause", whereClause) };
            return LoadCollection("spStockTakeDetails_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StockTakeDetails objects from the database ordered by the columns specified.
        /// </summary>
        /// <returns>A collection containing all of the StockTakeDetails objects in the database ordered by the columns specified.</returns>
        public static StockTakeDetailsCollection LoadCollection(string whereClause, string[] orderByColumns, bool ascending)
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
            return LoadCollection("spStockTakeDetails_SelAll", parms);
        }

        /// <summary>
        /// Loads a collection of StockTakeDetails objects from the database.
        /// </summary>
        /// <returns>A collection containing all of the StockTakeDetails objects in the database.</returns>
        public static StockTakeDetailsCollection LoadCollection(string spName, SqlParameter[] parms)
        {
            StockTakeDetailsCollection result = new StockTakeDetailsCollection();
            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(spName, parms))
            {
                while (reader.Read())
                {
                    StockTakeDetails tmp = new StockTakeDetails();
                    tmp.LoadFromReader(reader);
                    result.Add(tmp);
                }
            }
            return result;
        }

        /// <summary>
        /// Deletes a StockTakeDetails object from the database.
        /// </summary>
        /// <param name="detailsId">The primary key value</param>
        public static void Delete(Guid detailsId)
        {
            SqlParameter[] parameterValues = new SqlParameter[] { new SqlParameter("@DetailsId", detailsId) };
            SqlHelper.Default.ExecuteNonQuery("spStockTakeDetails_DelRec", parameterValues);
        }

		
        public void LoadFromReader(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                key = reader.GetGuid(0);
                if (!reader.IsDBNull(0)) detailsId = reader.GetGuid(0);
                if (!reader.IsDBNull(1)) headerId = reader.GetGuid(1);
                if (!reader.IsDBNull(2)) txNumber = reader.GetString(2);
                if (!reader.IsDBNull(3)) productId = reader.GetGuid(3);
                if (!reader.IsDBNull(4)) workplaceId = reader.GetGuid(4);
                if (!reader.IsDBNull(5)) capturedQty = reader.GetDecimal(5);
                if (!reader.IsDBNull(6)) hHTQty = reader.GetDecimal(6);
                if (!reader.IsDBNull(7)) book1Qty = reader.GetDecimal(7);
                if (!reader.IsDBNull(8)) book2Qty = reader.GetDecimal(8);
                if (!reader.IsDBNull(9)) book3Qty = reader.GetDecimal(9);
                if (!reader.IsDBNull(10)) book4Qty = reader.GetDecimal(10);
                if (!reader.IsDBNull(11)) book5Qty = reader.GetDecimal(11);
                if (!reader.IsDBNull(12)) averageCost = reader.GetDecimal(12);
                if (!reader.IsDBNull(13)) modifiedOn = reader.GetDateTime(13);
                if (!reader.IsDBNull(14)) modifiedBy = reader.GetGuid(14);
            }
        }
		
        public void Delete()
        {
            Delete(this.DetailsId);
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
                if (key != DetailsId)
                    this.Delete();
                Update();
            }
        }

        public Guid DetailsId
        {
            get { return detailsId; }
            set { detailsId = value; }
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

        public Guid ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public Guid WorkplaceId
        {
            get { return workplaceId; }
            set { workplaceId = value; }
        }

        public decimal CapturedQty
        {
            get { return capturedQty; }
            set { capturedQty = value; }
        }

        public decimal HHTQty
        {
            get { return hHTQty; }
            set { hHTQty = value; }
        }

        public decimal Book1Qty
        {
            get { return book1Qty; }
            set { book1Qty = value; }
        }

        public decimal Book2Qty
        {
            get { return book2Qty; }
            set { book2Qty = value; }
        }

        public decimal Book3Qty
        {
            get { return book3Qty; }
            set { book3Qty = value; }
        }

        public decimal Book4Qty
        {
            get { return book4Qty; }
            set { book4Qty = value; }
        }

        public decimal Book5Qty
        {
            get { return book5Qty; }
            set { book5Qty = value; }
        }

        public decimal AverageCost
        {
            get { return averageCost; }
            set { averageCost = value; }
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


        private void Insert()
        {
            SqlParameter[] parameterValues = GetInsertParameterValues();
            object returnedValue = null;
			
            SqlHelper.Default.ExecuteNonQuery("spStockTakeDetails_InsRec", "@DetailsId", out returnedValue, parameterValues);
            
            detailsId = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
            key = returnedValue != null ? (Guid)returnedValue : Guid.Empty;
        }

        private void Update()
        {
            SqlParameter[] parameterValues = GetUpdateParameterValues();
            
			SqlHelper.Default.ExecuteNonQuery("spStockTakeDetails_UpdRec", parameterValues);
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
            prams[0] = GetSqlParameter("@DetailsId", ParameterDirection.Output, SqlDbType.UniqueIdentifier, 16, this.DetailsId);
            prams[1] = GetSqlParameter("@HeaderId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.HeaderId);
            prams[2] = GetSqlParameter("@TxNumber", ParameterDirection.Input, SqlDbType.VarChar, 12, this.TxNumber);
            prams[3] = GetSqlParameter("@ProductId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ProductId);
            prams[4] = GetSqlParameter("@WorkplaceId", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.WorkplaceId);
            prams[5] = GetSqlParameter("@CapturedQty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.CapturedQty);
            prams[6] = GetSqlParameter("@HHTQty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.HHTQty);
            prams[7] = GetSqlParameter("@Book1Qty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.Book1Qty);
            prams[8] = GetSqlParameter("@Book2Qty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.Book2Qty);
            prams[9] = GetSqlParameter("@Book3Qty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.Book3Qty);
            prams[10] = GetSqlParameter("@Book4Qty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.Book4Qty);
            prams[11] = GetSqlParameter("@Book5Qty", ParameterDirection.Input, SqlDbType.Decimal, 9, this.Book5Qty);
            prams[12] = GetSqlParameter("@AverageCost", ParameterDirection.Input, SqlDbType.Money, 8, this.AverageCost);
            prams[13] = GetSqlParameter("@ModifiedOn", ParameterDirection.Input, SqlDbType.DateTime, 8, this.ModifiedOn);
            prams[14] = GetSqlParameter("@ModifiedBy", ParameterDirection.Input, SqlDbType.UniqueIdentifier, 16, this.ModifiedBy);
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
                GetSqlParameterWithoutDirection("@DetailsId", SqlDbType.UniqueIdentifier, 16, this.DetailsId),
                GetSqlParameterWithoutDirection("@HeaderId", SqlDbType.UniqueIdentifier, 16, this.HeaderId),
                GetSqlParameterWithoutDirection("@TxNumber", SqlDbType.VarChar, 12, this.TxNumber),
                GetSqlParameterWithoutDirection("@ProductId", SqlDbType.UniqueIdentifier, 16, this.ProductId),
                GetSqlParameterWithoutDirection("@WorkplaceId", SqlDbType.UniqueIdentifier, 16, this.WorkplaceId),
                GetSqlParameterWithoutDirection("@CapturedQty", SqlDbType.Decimal, 9, this.CapturedQty),
                GetSqlParameterWithoutDirection("@HHTQty", SqlDbType.Decimal, 9, this.HHTQty),
                GetSqlParameterWithoutDirection("@Book1Qty", SqlDbType.Decimal, 9, this.Book1Qty),
                GetSqlParameterWithoutDirection("@Book2Qty", SqlDbType.Decimal, 9, this.Book2Qty),
                GetSqlParameterWithoutDirection("@Book3Qty", SqlDbType.Decimal, 9, this.Book3Qty),
                GetSqlParameterWithoutDirection("@Book4Qty", SqlDbType.Decimal, 9, this.Book4Qty),
                GetSqlParameterWithoutDirection("@Book5Qty", SqlDbType.Decimal, 9, this.Book5Qty),
                GetSqlParameterWithoutDirection("@AverageCost", SqlDbType.Money, 8, this.AverageCost),
                GetSqlParameterWithoutDirection("@ModifiedOn", SqlDbType.DateTime, 8, this.ModifiedOn),
                GetSqlParameterWithoutDirection("@ModifiedBy", SqlDbType.UniqueIdentifier, 16, this.ModifiedBy)
            };
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("detailsId: " + detailsId.ToString()).Append("\r\n");
            builder.Append("headerId: " + headerId.ToString()).Append("\r\n");
            builder.Append("txNumber: " + txNumber.ToString()).Append("\r\n");
            builder.Append("productId: " + productId.ToString()).Append("\r\n");
            builder.Append("workplaceId: " + workplaceId.ToString()).Append("\r\n");
            builder.Append("capturedQty: " + capturedQty.ToString()).Append("\r\n");
            builder.Append("hHTQty: " + hHTQty.ToString()).Append("\r\n");
            builder.Append("book1Qty: " + book1Qty.ToString()).Append("\r\n");
            builder.Append("book2Qty: " + book2Qty.ToString()).Append("\r\n");
            builder.Append("book3Qty: " + book3Qty.ToString()).Append("\r\n");
            builder.Append("book4Qty: " + book4Qty.ToString()).Append("\r\n");
            builder.Append("book5Qty: " + book5Qty.ToString()).Append("\r\n");
            builder.Append("averageCost: " + averageCost.ToString()).Append("\r\n");
            builder.Append("modifiedOn: " + modifiedOn.ToString()).Append("\r\n");
            builder.Append("modifiedBy: " + modifiedBy.ToString()).Append("\r\n");
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
			
			StockTakeDetailsCollection source;
            
            if(OrderBy == null || OrderBy.Length == 0)
            {
			    OrderBy = TextField;
            }
			
			if (WhereClause.Length > 0)
			{
				source = StockTakeDetails.LoadCollection(WhereClause, OrderBy, true);
			}
			else
			{
				source = StockTakeDetails.LoadCollection(OrderBy, true);
			}
			
            Common.ComboList sourceList = new Common.ComboList();

			if (BlankLine)
			{
                sourceList.Add(new Common.ComboItem(BlankLineText, Guid.Empty));
			}
			
			foreach (StockTakeDetails item in source)
			{
				bool filter = false;
				if (ParentFilter.Trim() != String.Empty)
				{
					filter = true;
					if (item.HeaderId != Guid.Empty)
					{
						filter = IgnorThis(item, ParentFilter);
					}
				}
				if (!(filter))
				{
                    string code = GetFormatedText(item, TextField, TextFormatString);
                    sourceList.Add(new Common.ComboItem(code, item.DetailsId));
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
		
		
		private static bool IgnorThis(StockTakeDetails target, string parentFilter)
		{
			bool result = true;
			parentFilter = parentFilter.Replace(" ", "");		// remove spaces
			parentFilter = parentFilter.Replace("'", "");		// remove '
			string [] parsed = parentFilter.Split('=');			// parse

			if (target.HeaderId == Guid.Empty)
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
				StockTakeDetails parentTemplate = StockTakeDetails.Load(target.HeaderId);
				result = IgnorThis(parentTemplate, parentFilter);
			}
			return result;
		}

		private static string GetFormatedText(StockTakeDetails target, string [] textField, string textFormatString)
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
    /// Represents a collection of <see cref="StockTakeDetails">StockTakeDetails</see> objects.
    /// </summary>
    public class StockTakeDetailsCollection : BindingList< StockTakeDetails>
    {
	}
}
