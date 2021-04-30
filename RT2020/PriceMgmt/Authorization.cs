#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using RT2020.Helper;

#endregion

namespace RT2020.PriceMgmt
{
    public partial class Authorization : Form
    {
        #region public Properties

        /// <summary>
        /// the type of the list.
        /// </summary>
        private EnumHelper.PriceMgmtPMType listType = EnumHelper.PriceMgmtPMType.Price;

        /// <summary>
        /// Gets or sets the type of the list.
        /// </summary>
        /// <value>The type of the list.</value>
        public EnumHelper.PriceMgmtPMType ListType
        {
            get
            {
                return listType;
            }
            set
            {
                listType = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="Authentication"/> class.
        /// </summary>
        public Authorization()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetAttributes();
            this.BindingAuthList();
        }

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {
            this.Text = this.ListType.ToString() + " Change Authorization";
            this.lblTxNumberToLookup.Text = string.Format(this.lblTxNumberToLookup.Text, this.ListType.ToString());

            this.txtTxNumberToLookup.Focus();

            this.txtPostedOn.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            this.txtCurrentSystemMonth.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            this.txtCurrentSystemYear.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;

            this.txtPostedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, true);
            this.txtCurrentSystemMonth.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemMonth;
            this.txtCurrentSystemYear.Text = RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemYear;

            this.cboSortAndFilterBy.SelectedIndex = 0;
            this.cboOperator.SelectedIndex = 0;
            this.cboOrdering.SelectedIndex = 0;
        }

        #region Bind auth list

        /// <summary>
        /// Bindings the auth list.
        /// </summary>
        private void BindingAuthList()
        {
            lvAuthList.Items.Clear();

            int iCount = 1;
            string sql = BuildSqlQueryString();
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvAuthList.Items.Add(reader.GetGuid(0).ToString()); // HeaderId
                    objItem.SubItems.Add(string.Empty); // Mark
                    objItem.SubItems.Add(reader.GetString(1)); // TxNumber
                    objItem.SubItems.Add(reader.GetString(2)); // TxType
                    objItem.SubItems.Add(reader.GetString(5)); // Reason
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(3), false)); // Effective Date
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(8), false)); // Modified On

                    iCount++;
                }
            }
        }

        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <returns></returns>
        private string BuildSqlQueryString()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@" SELECT HeaderId, TxNumber, TxType, EffectDate, PM_TYPE, 
                (CASE WHEN PriceManagementBatchHeader.ReasonId IS NOT NULL THEN (SELECT ReasonCode FROM PriceManagementReason WHERE ReasonId = PriceManagementBatchHeader.ReasonId)
                ELSE '' END) AS ReasonCode, Remarks, ");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM PriceManagementBatchHeader ");
            sql.Append(" WHERE Posted = 0  AND PM_TYPE = '").Append(this.ListType.ToString().Substring(0, 1)).Append("'");

            if (chkEnableSortAndFilter.Checked)
            {
                if (cboSortAndFilterBy.Text.Length > 0 && cboOperator.Text != "None")
                {
                    sql.Append(" AND ");
                    sql.Append(GetColumnName()).Append(" ");

                    if (cboSortAndFilterBy.Text.Contains("Date"))
                    {
                        sql.Append("BETWEEN '");
                        sql.Append(txtSearchData.Tag.ToString()).Append(" 00:00:00'");
                        sql.Append(" AND '");
                        sql.Append(txtSearchData.Tag.ToString()).Append(" 23:59:59'");
                    }
                    else
                    {
                        sql.Append((cboOperator.Text == "=") ? "= '" : "LIKE '%");
                        sql.Append(txtSearchData.Text).Append((cboOperator.Text == "=") ? "'" : "%'");
                    }
                }

                sql.Append(" ORDER BY ");
                sql.Append(GetColumnName());
                sql.Append((cboOrdering.Text == "Ascending") ? " ASC" : " DESC");
            }
            else
            {
                if (txtTxNumberToLookup.Text.Trim().Length > 0)
                {
                    sql.Append(" AND TxNumber = '").Append(txtTxNumberToLookup.Text.Trim()).Append("'");
                }
            }

            return sql.ToString();
        }

        /// <summary>
        /// Gets the name of the column.
        /// </summary>
        /// <returns></returns>
        private string GetColumnName()
        {
            string colName = string.Empty;
            switch (cboSortAndFilterBy.Text)
            {
                case "Type":
                    colName = "TxType";
                    break;
                case "Reason":
                    colName = "ReasonCode";
                    break;
                case "Effective Date (dd/MM/yyyy)":
                    colName = "TxDate";
                    break;
                case "Last Update (dd/MM/yyyy)":
                    colName = "ModifiedOn";
                    break;
                default:
                case "TRN#":
                    colName = "TxNumber";
                    break;
            }
            return colName;
        }

        /// <summary>
        /// Verifies the date.
        /// </summary>
        /// <returns></returns>
        private bool VerifyDate()
        {
            bool isVerified = true;
            if (cboSortAndFilterBy.Text.Contains("Date"))
            {
                string pattern = @"^\d{1,2}\/\d{1,2}\/\d{4}$";
                Regex rex = new Regex(pattern);
                Match match = rex.Match(txtSearchData.Text);
                if (!match.Success)
                {
                    errorProvider.SetError(lblSearchData, "Incorrect Date Format! (Date Format:dd/MM/yyyy)");
                    isVerified = false;
                }
                else
                {
                    errorProvider.SetError(lblSearchData, string.Empty);
                    FormatDate();
                }
            }
            return isVerified;
        }

        /// <summary>
        /// Formats the date.
        /// </summary>
        private void FormatDate()
        {
            string[] dateValue = txtSearchData.Text.Split('/');
            txtSearchData.Tag = dateValue[2] + "-" + dateValue[1] + "-" + dateValue[0];
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the chkEnableSortAndFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkEnableSortAndFilter_Click(object sender, EventArgs e)
        {
            cboSortAndFilterBy.Enabled = chkEnableSortAndFilter.Checked;
            cboOrdering.Enabled = chkEnableSortAndFilter.Checked;
            cboOperator.Enabled = chkEnableSortAndFilter.Checked;
            txtSearchData.Enabled = chkEnableSortAndFilter.Checked;
            btnReload.Enabled = chkEnableSortAndFilter.Checked;
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnreload":
                            if (VerifyDate())
                            {
                                BindingAuthList();
                            }
                            break;
                        case "btnmarkitems":
                            this.MarkItems();
                            break;
                        case "btnpost":
                            MessageBox.Show("Confirm proceed?", "Attention", MessageBoxButtons.YesNo, new EventHandler(ConfirmProceedHandler));
                            break;
                        case "btnexit":
                            this.Close();
                            break;
                    }
                }
            }
        }

        #region Posting

        /// <summary>
        /// Confirms the proceed handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ConfirmProceedHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (CountSelectedColumns() > 0)
                {
                    int result = CreateActiveRecords();
                    if (result > 0)
                    {
                        MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK, new EventHandler(PostingMessageHandler));
                    }
                    else
                    {
                        MessageBox.Show(result.ToString() + " succeed!", "Posting result", MessageBoxButtons.OK, MessageBoxIcon.Warning, new EventHandler(PostingMessageHandler));
                    }
                }
                else
                {
                    MessageBox.Show("No Record Selected!", "Attention");
                }
            }
        }

        /// <summary>
        /// Postings the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void PostingMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                BindingAuthList();
            }
        }

        /// <summary>
        /// Counts the selected columns.
        /// </summary>
        /// <returns></returns>
        private int CountSelectedColumns()
        {
            int iCount = 0;

            foreach (ListViewItem objItem in this.lvAuthList.Items)
            {
                if (objItem.SubItems[1].Text == "*")
                {
                    iCount++;
                }
            }

            return iCount;
        }

        /// <summary>
        /// Creates the active records.
        /// </summary>
        /// <returns></returns>
        private int CreateActiveRecords()
        {
            int iCount = 0;
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ListViewItem oItem in lvAuthList.Items)
                        {
                            if (oItem.SubItems[1].Text == "*")
                            {
                                Guid headerId = Guid.Empty;
                                if (Guid.TryParse(oItem.Text, out headerId))
                                {
                                    Guid destHeaderId = Guid.Empty;

                                    #region Guid destHeaderId = CreateActiveHeader(headerId);
                                    var srcHeader = ctx.PriceManagementBatchHeader.Find(headerId);
                                    if (srcHeader != null)
                                    {
                                        // Add new active header
                                        var destHeader = new EF6.PriceManagementActiveHeader();
                                        destHeader.HeaderId = System.Guid.NewGuid();
                                        destHeader.TxNumber = srcHeader.TxNumber;
                                        destHeader.TxType = srcHeader.TxType;
                                        destHeader.EffectDate = srcHeader.EffectDate;
                                        destHeader.PM_TYPE = srcHeader.PM_TYPE;
                                        destHeader.ReasonId = srcHeader.ReasonId;
                                        destHeader.StartOn = srcHeader.StartOn;
                                        destHeader.EndOn = srcHeader.EndOn;
                                        destHeader.Remarks = srcHeader.Remarks;
                                        destHeader.SEGMENT_LOCATION = srcHeader.SEGMENT_LOCATION;
                                        destHeader.Posted = true;
                                        destHeader.PostedBy = ConfigHelper.CurrentUserId;
                                        destHeader.PostedOn = DateTime.Now;
                                        destHeader.CreatedOn = srcHeader.CreatedOn;
                                        destHeader.CreatedBy = srcHeader.CreatedBy;
                                        destHeader.ModifiedBy = srcHeader.ModifiedBy;
                                        destHeader.ModifiedOn = srcHeader.ModifiedOn;
                                        ctx.PriceManagementActiveHeader.Add(destHeader);

                                        destHeaderId = destHeader.HeaderId;

                                        // Update the posted detail (batch)
                                        srcHeader.Posted = true;
                                        srcHeader.PostedBy = ConfigHelper.CurrentUserId;
                                        srcHeader.PostedOn = DateTime.Now;
                                        srcHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                        srcHeader.ModifiedOn = DateTime.Now;

                                        ctx.SaveChanges();
                                    }
                                    #endregion

                                    if (destHeaderId != Guid.Empty)
                                    {
                                        #region this.CreateActiveDetails(destHeaderId, headerId);
                                        //string query = "HeaderId = '" + srcHeaderId.ToString() + "'";
                                        var srcDetailList = ctx.PriceManagementBatchDetails
                                            .Where(x => x.HeaderId == headerId)
                                            .OrderBy(x => x.LineNumber); 
                                        foreach (var srcDetail in srcDetailList)
                                        {
                                            //PriceManagementBatchDetails srcDetail = srcDetailList[i];

                                            var destDetail = new EF6.PriceManagementActiveDetails();
                                            destDetail.DetailId = Guid.NewGuid();
                                            destDetail.HeaderId = destHeaderId;
                                            destDetail.LineNumber = srcDetail.LineNumber;
                                            destDetail.TxNumber = srcDetail.TxNumber;
                                            destDetail.TxType = srcDetail.TxType;
                                            destDetail.ProductId = srcDetail.ProductId;
                                            destDetail.OLD_FIGURE = srcDetail.OLD_FIGURE;
                                            destDetail.NEW_FIGURE = srcDetail.NEW_FIGURE;

                                            ctx.PriceManagementActiveDetails.Add(destDetail);

                                            // Updates the product info.
                                            #region this.UpdateProductInfo(srcDetail.ProductId, srcDetail.NEW_FIGURE.Value);
                                            var updatedValue = srcDetail.NEW_FIGURE.Value;
                                            var oProduct = ctx.Product.Find(srcDetail.ProductId);
                                            if (oProduct != null)
                                            {
                                                if (this.ListType == EnumHelper.PriceMgmtPMType.Price)
                                                {
                                                    oProduct.RetailPrice = updatedValue;
                                                }
                                                else if (this.ListType == EnumHelper.PriceMgmtPMType.Discount)
                                                {
                                                    oProduct.NormalDiscount = updatedValue;
                                                }

                                                oProduct.DownloadToPOS = true;
                                                oProduct.Status = (int)EnumHelper.Status.Modified;
                                                oProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                                oProduct.ModifiedOn = DateTime.Now;

                                                ctx.SaveChanges();
                                            }
                                            #endregion
                                        }
                                        #endregion

                                        iCount++;
                                    }

                                    #region RemovePostedBatchInfo(headerId);
                                    var objHeader = ctx.PriceManagementBatchHeader.Find(headerId);
                                    if (objHeader != null)
                                    {
                                        //string query = "HeaderId = '" + headerId.ToString() + "'";
                                        var srcDetailList = ctx.PriceManagementBatchDetails
                                            .Where(x => x.HeaderId == headerId)
                                            .OrderBy(x => x.LineNumber);
                                        foreach (var srcDetail in srcDetailList)
                                        {
                                            ctx.PriceManagementBatchDetails.Remove(srcDetail);
                                        }

                                        ctx.PriceManagementBatchHeader.Remove(objHeader);
                                    }
                                    ctx.SaveChanges();
                                    #endregion
                                }
                            }
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }

            }
            return iCount;
        }
        /**
        /// <summary>
        /// Creates the active header.
        /// </summary>
        /// <param name="oItem">The source header id.</param>
        private Guid CreateActiveHeader(Guid srcHeaderId)
        {
            System.Guid headerId = System.Guid.Empty;
            PriceManagementBatchHeader srcHeader = PriceManagementBatchHeader.Load(srcHeaderId);
            if (srcHeader != null)
            {
                // Add new active header
                PriceManagementActiveHeader destHeader = new PriceManagementActiveHeader();
                destHeader.HeaderId = System.Guid.NewGuid();
                destHeader.TxNumber = srcHeader.TxNumber;
                destHeader.TxType = srcHeader.TxType;
                destHeader.EffectDate = srcHeader.EffectDate;
                destHeader.PM_TYPE = srcHeader.PM_TYPE;
                destHeader.ReasonId = srcHeader.ReasonId;
                destHeader.StartOn = srcHeader.StartOn;
                destHeader.EndOn = srcHeader.EndOn;
                destHeader.Remarks = srcHeader.Remarks;
                destHeader.SEGMENT_LOCATION = srcHeader.SEGMENT_LOCATION;
                destHeader.Posted = true;
                destHeader.PostedBy = ConfigHelper.CurrentUserId;
                destHeader.PostedOn = DateTime.Now;
                destHeader.CreatedOn = srcHeader.CreatedOn;
                destHeader.CreatedBy = srcHeader.CreatedBy;
                destHeader.ModifiedBy = srcHeader.ModifiedBy;
                destHeader.ModifiedOn = srcHeader.ModifiedOn;
                destHeader.Save();

                headerId = destHeader.HeaderId;

                // Update the posted detail (batch)
                srcHeader.Posted = true;
                srcHeader.PostedBy = ConfigHelper.CurrentUserId;
                srcHeader.PostedOn = DateTime.Now;
                srcHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                srcHeader.ModifiedOn = DateTime.Now;
                srcHeader.Save();
            }

            return headerId;
        }

        /// <summary>
        /// Creates the active details.
        /// </summary>
        /// <param name="destHeaderId">The destination header id.</param>
        /// <param name="srcHeaderId">The source header id.</param>
        private void CreateActiveDetails(Guid destHeaderId, Guid srcHeaderId)
        {
            if (destHeaderId != System.Guid.Empty)
            {
                string query = "HeaderId = '" + srcHeaderId.ToString() + "'";
                PriceManagementBatchDetailsCollection srcDetailList = PriceManagementBatchDetails.LoadCollection(query, new string[] { "LineNumber" }, true);
                for (int i = 0; i < srcDetailList.Count; i++)
                {
                    PriceManagementBatchDetails srcDetail = srcDetailList[i];

                    PriceManagementActiveDetails destDetail = new PriceManagementActiveDetails();
                    destDetail.DetailId = System.Guid.NewGuid();
                    destDetail.HeaderId = destHeaderId;
                    destDetail.LineNumber = srcDetail.LineNumber;
                    destDetail.TxNumber = srcDetail.TxNumber;
                    destDetail.TxType = srcDetail.TxType;
                    destDetail.ProductId = srcDetail.ProductId;
                    destDetail.OLD_FIGURE = srcDetail.OLD_FIGURE;
                    destDetail.NEW_FIGURE = srcDetail.NEW_FIGURE;

                    destDetail.Save();

                    // Updates the product info.
                    this.UpdateProductInfo(srcDetail.ProductId, srcDetail.NEW_FIGURE);
                }
            }
        }

        /// <summary>
        /// Removes the posted batch info.
        /// </summary>
        private void RemovePostedBatchInfo(Guid headerId)
        {
            PriceManagementBatchHeader objHeader = PriceManagementBatchHeader.Load(headerId);
            if (objHeader != null)
            {
                string query = "HeaderId = '" + headerId.ToString() + "'";
                PriceManagementBatchDetailsCollection srcDetailList = PriceManagementBatchDetails.LoadCollection(query, new string[] { "LineNumber" }, true);
                for (int i = 0; i < srcDetailList.Count; i++)
                {
                    srcDetailList[i].Delete();
                }

                objHeader.Delete();
            }
        }

        /// <summary>
        /// Updates the product info.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <param name="updatedValue">The updated value.</param>
        private void UpdateProductInfo(Guid productId, decimal updatedValue)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oProduct = ctx.Product.Find(productId);
                if (oProduct != null)
                {
                    if (this.ListType == PriceUtility.PriceMgmtType.Price)
                    {
                        oProduct.RetailPrice = updatedValue;
                    }
                    else if (this.ListType == PriceUtility.PriceMgmtType.Discount)
                    {
                        oProduct.NormalDiscount = updatedValue;
                    }

                    oProduct.DownloadToPOS = true;
                    oProduct.Status = (int)EnumHelper.Status.Modified;
                    oProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                    oProduct.ModifiedOn = DateTime.Now;

                    ctx.SaveChanges();
                }
            }
        }
        */
        #endregion

        /// <summary>
        /// Marks the items.
        /// </summary>
        private void MarkItems()
        {
            foreach (ListViewItem objItem in this.lvAuthList.Items)
            {
                if (btnMarkItems.Text.Contains("Mark") && !objItem.SubItems[1].Text.Contains("*"))
                {
                    objItem.SubItems[1].Text = "*";
                }
                else if (btnMarkItems.Text.Contains("Unmark"))
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }
            this.Update();

            btnMarkItems.Text = (btnMarkItems.Text == "Mark All") ? "Unmark All" : "Mark All";
        }

        /// <summary>
        /// Handles the Click event of the lvAuthList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvAuthList_Click(object sender, EventArgs e)
        {
            if (lvAuthList.SelectedItem != null)
            {
                this.lvAuthList.SelectedItem.SubItems[1].Text = (this.lvAuthList.SelectedItem.SubItems[1].Text.Length == 0) ? "*" : string.Empty;
                this.Update();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtTxNumberToLookup control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtTxNumberToLookup_TextChanged(object sender, EventArgs e)
        {
            this.BindingAuthList();
        }
    }
}