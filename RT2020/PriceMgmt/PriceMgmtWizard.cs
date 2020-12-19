#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

using System.Linq;
using RT2020.Helper;

#endregion

namespace RT2020.PriceMgmt
{
    public partial class PriceMgmtWizard : Form
    {
        PriceMgmtWizard_Details details;

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceMgmtWizard"/> class.
        /// </summary>
        public PriceMgmtWizard()
        {
            InitializeComponent();

            SetToolBar();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceMgmtWizard"/> class.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        public PriceMgmtWizard(Guid headerId)
        {
            InitializeComponent();

            this.headerId = headerId;

            SetToolBar();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            ModelEx.PriceManagementReasonEx.LoadCombo(ref cboReasonCode, "ReasonCode", false, true, string.Empty, string.Empty);

            this.SetAttributes();

            this.LoadHeader();

            this.Text = this.ListType.ToString() + " Change Wizard";
        }

        #region Properties

        /// <summary>
        /// the type of the list.
        /// </summary>
        private PriceUtility.PriceMgmtType listType = PriceUtility.PriceMgmtType.Price;

        /// <summary>
        /// Gets or sets the type of the list.
        /// </summary>
        /// <value>The type of the list.</value>
        public PriceUtility.PriceMgmtType ListType
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

        /// <summary>
        /// the header id.
        /// </summary>
        private Guid headerId = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the header id.
        /// </summary>
        /// <value>The header id.</value>
        public Guid HeaderId
        {
            get
            {
                return headerId;
            }
            set
            {
                headerId = value;
            }
        }

        #endregion

        #region Set attributes

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {
            this.dtpEffectiveDate.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;

            this.txtTxType.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            this.txtCreatedOn.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            this.txtModifiedBy.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            this.txtModifiedOn.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            this.txtTxNumber.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;

            // Loading Details Page
            details = new PriceMgmtWizard_Details();
            details.HeaderId = this.HeaderId;
            details.ListType = this.ListType;
            tpDetails.Controls.Add(details);
        }

        #endregion

        #region ToolBar

        /// <summary>
        /// Sets the tool bar.
        /// </summary>
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            // cmdPrint
            ToolBarButton cmdPrint = new ToolBarButton("Print", "Print");
            cmdPrint.Tag = "Print";
            cmdPrint.Image = new IconResourceHandle("16x16.16_print.gif");

            if (this.HeaderId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
                cmdPrint.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
                cmdPrint.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);
            this.tbWizardAction.Buttons.Add(sep);
            this.tbWizardAction.Buttons.Add(cmdPrint);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        /// <summary>
        /// Handles the ButtonClick event of the tbWizardAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        break;
                    case "save & new":
                        MessageBox.Show("Save Record And Add New?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                    case "print":
                        ClickPrint();
                        break;
                }
            }
        }
        private DataTable BindDataToReport()
        {
            string sql = @"
SELECT TOP 100 PERCENT * 
FROM vwRptBatchPriceMgmt
WHERE TxNumber BETWEEN '" + this.txtTxNumber.Text.Trim() + "' AND '" + this.txtTxNumber.Text.Trim() + @"'
AND CONVERT(NVARCHAR(10),EffectDate,126) BETWEEN '" + this.dtpEffectiveDate.Value.ToString("yyyy-MM-dd") + @"'
                                             AND '" + this.dtpEffectiveDate.Value.ToString("yyyy-MM-dd") + @"'
";
            if (this.ListType.ToString().Substring(0, 1) == "P")
            {
                sql += " AND PM_TYPE = 'P'";
            }
            else if (this.ListType.ToString().Substring(0, 1) == "D")
            {
                sql += " AND PM_TYPE = 'D'";
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        /// <summary>
        /// print every ListItem
        /// </summary>
        private void ClickPrint()
        {
            string[,] param = { 
                {"FromTxNumber",this.txtTxNumber.Text.Trim()},
                {"ToTxNumber",this.txtTxNumber.Text.Trim()},
                {"FromTxDate", this.dtpEffectiveDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"ToTxDate", this.dtpEffectiveDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                {"DateFormat", RT2020.SystemInfo.Settings.GetDateFormat()},
                {"STKCODE",RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE")},
                {"APPENDIX1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1")},
                {"APPENDIX2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2")},
                {"APPENDIX3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3")},
                {"CLASS1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1")},
                {"CLASS2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2")},
                {"CLASS3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3")},
                {"CLASS4",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4")},
                {"CLASS5",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5")},
                {"CLASS6",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6")},
                {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

            RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

            view.Datasource = BindDataToReport();
            view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource4PriceMgmt_vwRptBatchPriceMgmt";

            if (this.ListType.ToString().Substring(0, 1) == "P")
            {
                view.ReportName = "RT2020.PriceMgmt.Reports.PriceWorksheetRdl.rdlc";
            }
            else if (this.ListType.ToString().Substring(0, 1) == "D")
            {
                view.ReportName = "RT2020.PriceMgmt.Reports.DiscountWorksheetRdl.rdlc";
            }

            view.Parameters = param;

            view.Show();    
        }

        #endregion

        #region Load

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void LoadHeader()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oHeader = ctx.PriceManagementBatchHeader.Find(this.HeaderId);
                if (oHeader != null)
                {
                    txtTxNumber.Text = oHeader.TxNumber;

                    dtpEffectiveDate.Value = oHeader.EffectDate.Value;
                    cboReasonCode.SelectedValue = oHeader.ReasonId;
                    txtRemarks.Text = oHeader.Remarks;

                    txtModifiedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.ModifiedOn.Value, true);
                    txtModifiedBy.Text = ModelEx.StaffEx.GetStaffNumberById(oHeader.ModifiedBy);
                    txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.CreatedOn.Value, true);

                }
            }
        }

        #endregion

        #region Save

        /// <summary>
        /// Verifies this instance.
        /// </summary>
        /// <returns></returns>
        private bool Verify()
        {
            bool isValid = false;

            if (details != null)
            {
                if (details.lvItemList.Items.Count <= 0)
                {
                    MessageBox.Show("The detail list cannot be empty. Try to add some!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning, new EventHandler(CheckValidationHandler));
                }
                else
                {
                    isValid = true;
                }
            }

            return isValid;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            if (Verify())
            {
                UpdateHeader();

                return this.HeaderId != System.Guid.Empty;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Updates the header.
        /// </summary>
        private void UpdateHeader()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oHeader = ctx.PriceManagementBatchHeader.Find(this.HeaderId);
                        if (oHeader == null)
                        {
                            #region add new PriceManagementBatchHeader
                            oHeader = new EF6.PriceManagementBatchHeader();
                            oHeader.HeaderId = Guid.NewGuid();
                            txtTxNumber.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(EnumHelper.TxType.PMS);
                            oHeader.TxNumber = txtTxNumber.Text;
                            oHeader.TxType = EnumHelper.TxType.PMC.ToString();
                            oHeader.PM_TYPE = this.ListType.ToString().Substring(0, 1);

                            oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                            oHeader.CreatedOn = DateTime.Now;

                            ctx.PriceManagementBatchHeader.Add(oHeader);
                            #endregion
                        }

                        oHeader.EffectDate = dtpEffectiveDate.Value;
                        oHeader.ReasonId = (Guid)cboReasonCode.SelectedValue;
                        oHeader.Remarks = txtRemarks.Text;

                        oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                        oHeader.ModifiedOn = DateTime.Now;

                        ctx.SaveChanges();

                        this.HeaderId = oHeader.HeaderId;

                        #region UpdateDetails();
                        for (int i = 0; i < details.lvItemList.Items.Count; i++)
                        {
                            ListViewItem lvItem = details.lvItemList.Items[i];
                            int lineNumber = i + 1;

                            Guid productId = Guid.Empty, detailId = Guid.Empty;
                            if (Guid.TryParse(lvItem.SubItems[27].Text, out productId) && Guid.TryParse(lvItem.Text, out detailId))
                            {
                                var oDetail = ctx.PriceManagementBatchDetails.Find(detailId);
                                if (oDetail == null)
                                {
                                    #region new PriceManagementBatchDetails
                                    oDetail = new EF6.PriceManagementBatchDetails();
                                    oDetail.DetailId = Guid.NewGuid();
                                    oDetail.HeaderId = this.HeaderId;
                                    oDetail.LineNumber = lineNumber;
                                    oDetail.ProductId = productId;
                                    oDetail.TxNumber = txtTxNumber.Text;
                                    oDetail.TxType = txtTxType.Text;

                                    ctx.PriceManagementBatchDetails.Add(oDetail);
                                    #endregion
                                }

                                if (lvItem.SubItems[1].Text != "D")
                                {
                                    decimal oldValue = 0, newValue = 0;

                                    if (this.ListType == PriceUtility.PriceMgmtType.Price)
                                    {
                                        decimal.TryParse(lvItem.SubItems[7].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[9].Text, out newValue);
                                    }
                                    else
                                    {
                                        decimal.TryParse(lvItem.SubItems[12].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[13].Text, out newValue);
                                    }

                                    oDetail.OLD_FIGURE = oldValue;
                                    oDetail.NEW_FIGURE = newValue;

                                    #region Update Vip Discount
                                    if (lvItem.SubItems[21].Text == "Y") // Update Vip Discount
                                    {
                                        var objProduct = ctx.Product.Find(productId);
                                        if (objProduct != null)
                                        {
                                            objProduct.FixedPriceItem = (lvItem.SubItems[22].Text == "Y"); // Fixed price item

                                            string query = "ProductId = '" + objProduct.ProductId.ToString() + "'";
                                            var oSupplement = ctx.ProductSupplement.Where(x => x.ProductId == objProduct.ProductId).FirstOrDefault();
                                            if (oSupplement != null)
                                            {
                                                decimal vipDicount_FixedItem = 0, vipDiscount_DiscountItem = 0, vipDiscount_NoDiscountItem = 0, staffDiscount = 0;
                                                decimal.TryParse(lvItem.SubItems[23].Text, out vipDicount_FixedItem);
                                                decimal.TryParse(lvItem.SubItems[24].Text, out vipDiscount_DiscountItem);
                                                decimal.TryParse(lvItem.SubItems[25].Text, out vipDiscount_NoDiscountItem);
                                                decimal.TryParse(lvItem.SubItems[26].Text, out staffDiscount);
                                                //oSupplement.VipDiscount_FixedItem = Common.Utility.IsNumeric(lvItem.SubItems[23].Text) ? Convert.ToDecimal(lvItem.SubItems[23].Text.Trim()) : oSupplement.VipDiscount_FixedItem; // Discount For Fixed price Item
                                                //oSupplement.VipDiscount_DiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[24].Text) ? Convert.ToDecimal(lvItem.SubItems[24].Text.Trim()) : oSupplement.VipDiscount_DiscountItem; // Discount for Discount Item
                                                //oSupplement.VipDiscount_NoDiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[25].Text) ? Convert.ToDecimal(lvItem.SubItems[25].Text.Trim()) : oSupplement.VipDiscount_NoDiscountItem; // Disocunt for No Discount Item
                                                //oSupplement.StaffDiscount = Common.Utility.IsNumeric(lvItem.SubItems[26].Text) ? Convert.ToDecimal(lvItem.SubItems[26].Text.Trim()) : oSupplement.StaffDiscount; // Staff Discount
                                                oSupplement.VipDiscount_FixedItem = vipDicount_FixedItem;
                                                oSupplement.VipDiscount_DiscountItem = vipDiscount_DiscountItem;
                                                oSupplement.VipDiscount_NoDiscountItem = vipDiscount_NoDiscountItem;
                                                oSupplement.StaffDiscount = staffDiscount;
                                            }

                                            objProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                            objProduct.ModifiedOn = DateTime.Now;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    ctx.PriceManagementBatchDetails.Remove(oDetail);
                                }
                                ctx.SaveChanges();
                            }
                        }
                        #endregion

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }
        }
        /**
        /// <summary>
        /// Updates the details.
        /// </summary>
        private void UpdateDetails()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        for (int i = 0; i < details.lvItemList.Items.Count; i++)
                        {
                            ListViewItem lvItem = details.lvItemList.Items[i];
                            int lineNumber = i + 1;

                            Guid productId = Guid.Empty, detailId = Guid.Empty;
                            if (Guid.TryParse(lvItem.SubItems[27].Text, out productId) && Guid.TryParse(lvItem.Text, out detailId))
                            {
                                var oDetail = ctx.PriceManagementBatchDetails.Find(detailId);
                                if (oDetail == null)
                                {
                                    #region new PriceManagementBatchDetails
                                    oDetail = new EF6.PriceManagementBatchDetails();
                                    oDetail.DetailId = Guid.NewGuid();
                                    oDetail.HeaderId = this.HeaderId;
                                    oDetail.LineNumber = lineNumber;
                                    oDetail.ProductId = productId;
                                    oDetail.TxNumber = txtTxNumber.Text;
                                    oDetail.TxType = txtTxType.Text;

                                    ctx.PriceManagementBatchDetails.Add(oDetail);
                                    #endregion
                                }

                                if (lvItem.SubItems[1].Text != "D")
                                {
                                    decimal oldValue = 0, newValue = 0;

                                    if (this.ListType == PriceUtility.PriceMgmtType.Price)
                                    {
                                        decimal.TryParse(lvItem.SubItems[7].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[9].Text, out newValue);
                                    }
                                    else
                                    {
                                        decimal.TryParse(lvItem.SubItems[12].Text, out oldValue);
                                        decimal.TryParse(lvItem.SubItems[13].Text, out newValue);
                                    }

                                    oDetail.OLD_FIGURE = oldValue;
                                    oDetail.NEW_FIGURE = newValue;

                                    #region Update Vip Discount
                                    if (lvItem.SubItems[21].Text == "Y") // Update Vip Discount
                                    {
                                        var objProduct = ctx.Product.Find(productId);
                                        if (objProduct != null)
                                        {
                                            objProduct.FixedPriceItem = (lvItem.SubItems[22].Text == "Y"); // Fixed price item

                                            string query = "ProductId = '" + objProduct.ProductId.ToString() + "'";
                                            var oSupplement = ctx.ProductSupplement.Where(x => x.ProductId == objProduct.ProductId).FirstOrDefault();
                                            if (oSupplement != null)
                                            {
                                                oSupplement.VipDiscount_FixedItem = Common.Utility.IsNumeric(lvItem.SubItems[23].Text) ? Convert.ToDecimal(lvItem.SubItems[23].Text.Trim()) : oSupplement.VipDiscount_FixedItem; // Discount For Fixed price Item
                                                oSupplement.VipDiscount_DiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[24].Text) ? Convert.ToDecimal(lvItem.SubItems[24].Text.Trim()) : oSupplement.VipDiscount_DiscountItem; // Discount for Discount Item
                                                oSupplement.VipDiscount_NoDiscountItem = Common.Utility.IsNumeric(lvItem.SubItems[25].Text) ? Convert.ToDecimal(lvItem.SubItems[25].Text.Trim()) : oSupplement.VipDiscount_NoDiscountItem; // Disocunt for No Discount Item
                                                oSupplement.StaffDiscount = Common.Utility.IsNumeric(lvItem.SubItems[26].Text) ? Convert.ToDecimal(lvItem.SubItems[26].Text.Trim()) : oSupplement.StaffDiscount; // Staff Discount
                                            }

                                            objProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                            objProduct.ModifiedOn = DateTime.Now;
                                        }
                                    }
                                    #endregion
                                }
                                else
                                {
                                    ctx.PriceManagementBatchDetails.Remove(oDetail);
                                }
                                ctx.SaveChanges();
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
        }
        */
        #endregion

        /// <summary>
        /// the Validation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckValidationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
            }
        }

        /// <summary>
        /// Saves the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultReasonList>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    PriceMgmtWizard wizard = new PriceMgmtWizard(this.HeaderId);
                    wizard.ListType = this.ListType;
                    wizard.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Saves the new message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultReasonList>();
                    this.Close();
                    PriceMgmtWizard wizard = new PriceMgmtWizard();
                    wizard.ListType = this.ListType;
                    wizard.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Saves the close message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultReasonList>();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Deletes the confirmation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var objPriceMgmtBatchHeader = ctx.PriceManagementBatchHeader.Find(this.HeaderId);
                if (objPriceMgmtBatchHeader != null)
                {
                    try
                    {
                        //string query = "HeaderId = '" + objPriceMgmtBatchHeader.HeaderId.ToString() + "'";
                        var objDetailList = ctx.PriceManagementBatchDetails
                            .Where(x => x.HeaderId == objPriceMgmtBatchHeader.HeaderId)
                            .ToList();
                        foreach (var objDetail in objDetailList)
                        {
                            ctx.PriceManagementBatchDetails.Remove(objDetail);
                        }

                        ctx.PriceManagementBatchHeader.Remove(objPriceMgmtBatchHeader);

                        ctx.SaveChanges();

                        MessageBox.Show("Record deleted!", "Delete Successful!");

                        this.Close();
                    }
                    catch (Exception exc)
                    {
                        MessageBox.Show(exc.Message, "Failed to delete!");
                    }
                }
            }
        }
    }
}