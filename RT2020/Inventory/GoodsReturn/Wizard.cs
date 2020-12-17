using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;

using RT2020.DAL;
using RT2020.Controls;

namespace RT2020.Inventory.GoodsReturn
{
    public partial class Wizard : Form, IGatewayComponent, IWizard
    {
        public Wizard()
        {
            InitializeComponent();

            SetAttributes();
            SetSystemLabel();

            FillCboList();
            SetToolBar();
            txtTxNumber.Text = "Auto-Generated";
            cboStatus.Text = "HOLD";
        }

        public Wizard(Guid capId)
        {
            InitializeComponent();

            SetAttributes();
            SetSystemLabel();

            this.REJId = capId;

            SetSystemLabel();
            FillCboList();
            SetToolBar();
            LoadREJInfo();
        }

        #region Set System Label
        private void SetAttributes()
        {
            this.Text = Utility.Dictionary.GetWord("Goods Return") + " > " + Utility.Dictionary.GetWord("Wizard");

            lblTxType.Text = Utility.Dictionary.GetWordWithColon("TxType");
            lblTxNumber.Text = Utility.Dictionary.GetWordWithColon("TxNumber");
            lblTotalAmount.Text = string.Format(Utility.Dictionary.GetWordWithColon("total_amount_with_currency"), "$");

            tpGeneral.Text = Utility.Dictionary.GetWord("General");
            tpDetails.Text = Utility.Dictionary.GetWord("Details");

            lblLocation.Text = Utility.Dictionary.GetWordWithColon("workplace");
            lblRecvDate.Text = Utility.Dictionary.GetWordWithColon("Receive Date");
            lblOperatorCode.Text = Utility.Dictionary.GetWordWithColon("Staff");
            lblSupplier.Text = Utility.Dictionary.GetWordWithColon("Supplier");
            lblSupplierInvoice.Text = Utility.Dictionary.GetWord("Supplier") + " " + Utility.Dictionary.GetWordWithColon("Invoice Number");
            lblRefNumber.Text = Utility.Dictionary.GetWordWithColon("Reference");
            lblStatus.Text = Utility.Dictionary.GetWordWithColon("Status");
            lblRemarks.Text = Utility.Dictionary.GetWordWithColon("Remarks");
            lblTotalQty.Text = Utility.Dictionary.GetWordWithColon("Total Qty");
            lblLastUpdate.Text = Utility.Dictionary.GetWordWithColon("Last Update");
            lblAmendmentRetrict.Text = Utility.Dictionary.GetWordWithColon("Amendment Restrict");
            lblAPLink.Text = Utility.Dictionary.GetWordWithColon("AP Link");

            lblStockCode.Text = Utility.Dictionary.GetWordWithColon("Product");
            lblDescription.Text = Utility.Dictionary.GetWordWithColon("Description");
            lblQty.Text = Utility.Dictionary.GetWordWithColon("Qty");
            lblUnitAmount.Text = string.Format(Utility.Dictionary.GetWord("unit_amount_with_currency"), "$");
            lblNumberOfLine.Text = Utility.Dictionary.GetWordWithColon("number_of_line");

            colLN.Text = Utility.Dictionary.GetWord("LN");
            colStatus.Text = Utility.Dictionary.GetWord("Status");
            colDescription.Text = Utility.Dictionary.GetWord("Description");
            colQty.Text = Utility.Dictionary.GetWord("Qty");
            colUnitAmount.Text = string.Format(Utility.Dictionary.GetWord("unit_amount_with_currency"), "$");
            colAmount.Text = string.Format(Utility.Dictionary.GetWord("amount_with_currency"), "$");

            btnAddItem.Text = Utility.Dictionary.GetWord("Add Item");
            btnEditItem.Text = Utility.Dictionary.GetWord("Edit Item");
            btnRemove.Text = Utility.Dictionary.GetWord("Remove Item");
        }

        private void SetSystemLabel()
        {
            colStockCode.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

        #region Properties
        private Guid capId = System.Guid.Empty;
        public Guid REJId
        {
            get
            {
                return capId;
            }
            set
            {
                capId = value;
            }
        }

        private Guid capDetailId = System.Guid.Empty;
        public Guid REJDetailId
        {
            get
            {
                return capDetailId;
            }
            set
            {
                capDetailId = value;
            }
        }

        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        private int SelectedIndex = 0;
        private bool ValidSelection = false;

        #endregion

        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            DataTable dt = Reports.DataSource.Worksheet(this.txtTxNumber.Text, this.txtTxNumber.Text, this.dtpRecvDate.Value, this.dtpRecvDate.Value);

            string filename = txtTxNumber.Text.Trim() + ".pdf";

            RT2020.Inventory.GoodsReturn.Reports.WorksheetRpt report = new RT2020.Inventory.GoodsReturn.Reports.WorksheetRpt();
            report.DataSource = dt;
            report.TxNumberFrom = this.txtTxNumber.Text.Trim();
            report.TxNumberTo = this.txtTxNumber.Text.Trim();
            report.TxDateFrom = this.dtpRecvDate.Value;
            report.TxDateTo = this.dtpRecvDate.Value;
            HttpResponse objResponse = this.Context.HttpContext.Response;

            System.IO.MemoryStream memStream = new System.IO.MemoryStream();

            objResponse.Clear();
            objResponse.ClearHeaders();

            report.ExportToPdf(memStream);
            objResponse.ContentType = "application/pdf";
            objResponse.AddHeader("content-disposition", "attachment; filename=" + filename);
            objResponse.BinaryWrite(memStream.ToArray());
            objResponse.Flush();
            objResponse.End();
        }
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", Utility.Dictionary.GetWord("Save"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", HttpUtility.UrlDecode(Utility.Dictionary.GetWord("Save_New")));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", HttpUtility.UrlDecode(Utility.Dictionary.GetWord("Save_close")));
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", Utility.Dictionary.GetWord("Delete"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            // cmdPrint
            ToolBarButton cmdPrint = new ToolBarButton("Print", Utility.Dictionary.GetWord("Print"));
            cmdPrint.Tag = "Print";
            cmdPrint.Image = new IconResourceHandle("16x16.16_print.gif");

            if (REJId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
                cmdPrint.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Delete);
                cmdPrint.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);
            this.tbWizardAction.Buttons.Add(sep);
            this.tbWizardAction.Buttons.Add(cmdPrint);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

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
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                    case "print":
                        //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
                        cmdPreview_Click();
                        break;
                }
            }
        }
        #endregion

        #region Bind Data to Report(ClickPrint)
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwRptBatchCAP
WHERE	TxNumber BETWEEN '" + this.txtTxNumber.Text.Trim() + @"' AND '" + this.txtTxNumber.Text.Trim() + @"' AND
        CONVERT(VARCHAR(10), TxDate, 126) BETWEEN '" + this.dtpRecvDate.Value.ToString("yyyy-MM-dd") + @"' AND '" + this.dtpRecvDate.Value.ToString("yyyy/MM/dd") + @"' AND
        TxType = '" + Common.Enums.TxType.REJ.ToString() + @"' 
ORDER BY TxNumber, TxDate, LineNumber
";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private void cmdPreview_Click()
        {
            string[,] param = {
                { "FromTxNumber", this.txtTxNumber.Text.Trim() },
                { "ToTxNumber", this.txtTxNumber.Text.Trim() },
                { "FromTxDate", this.dtpRecvDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToTxDate", this.dtpRecvDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "PrintedBy", ModelEx.StaffEx.GetStaffNameById(Common.Config.CurrentUserId) },
                { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() },
                { "CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

            RT2020.Controls.Reporting.Viewer oViewer = new RT2020.Controls.Reporting.Viewer();

            oViewer.Datasource = BindData();
            oViewer.ReportName = "RT2020.Inventory.GoodsReturn.Reports.WorksheetRdl.rdlc";
            oViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptBatchCAP";
            oViewer.Parameters = param;

            oViewer.Show();
        }
        #endregion

        #region Fill Combo List
        private void FillCboList()
        {
            FillLocationList();
            FillStaffList();
            FillSupplierList();
        }

        private void FillLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboWorkplace, "WorkplaceCode", false);
        }

        private void FillStaffList()
        {
            ModelEx.StaffEx.LoadCombo(ref cboOperatorCode, "StaffNumber", false);

            cboOperatorCode.SelectedValue = Common.Config.CurrentUserId;
        }

        private void FillSupplierList()
        {
            ModelEx.SupplierEx.LoadCombo(ref cboSupplierList, "SupplierCode", false);
        }
        #endregion

        #region Save REJ Header Info
        private bool Save()
        {
            bool isSave = false;
            if (lvDetailsList.Items.Count > 0)
            {
                SaveREJ();
                return true;
            }
            else
            {
                MessageBox.Show("Does not allow saving record without details", "Save Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabGoodsREJ.SelectedIndex = 1;
            }
            return isSave;
        }

        private void SaveREJ()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oHeader = ctx.InvtBatchCAP_Header.Find(this.REJId);
                        if (oHeader == null)
                        {
                            #region add new InvtBatchCAP_Header
                            oHeader = new EF6.InvtBatchCAP_Header();
                            oHeader.HeaderId = Guid.NewGuid();
                            txtTxNumber.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.REJ);
                            oHeader.TxNumber = txtTxNumber.Text;
                            oHeader.TxType = Common.Enums.TxType.REJ.ToString();

                            oHeader.CreatedBy = Common.Config.CurrentUserId;
                            oHeader.CreatedOn = DateTime.Now;

                            ctx.InvtBatchCAP_Header.Add(oHeader);
                            #endregion
                        }
                        #region InvtBatchCAP_Header core data
                        oHeader.TxDate = dtpRecvDate.Value;
                        oHeader.Status = Convert.ToInt32(cboStatus.Text == "HOLD" ? Common.Enums.Status.Draft.ToString("d") : Common.Enums.Status.Active.ToString("d"));

                        oHeader.WorkplaceId = new Guid(cboWorkplace.SelectedValue.ToString());
                        oHeader.StaffId = new Guid(cboOperatorCode.SelectedValue.ToString());
                        oHeader.SupplierId = new Guid(cboSupplierList.SelectedValue.ToString());
                        oHeader.SupplierRefernce = txtSupplierInvoice.Text;
                        oHeader.Remarks = txtRemarks.Text;
                        oHeader.Reference = txtRefNumber.Text;
                        oHeader.LinkToAP = chkAPLink.Checked;

                        oHeader.ModifiedBy = Common.Config.CurrentUserId;
                        oHeader.ModifiedOn = DateTime.Now;
                        #endregion

                        oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text : "0");

                        ctx.SaveChanges();

                        #region log activity
                        RT2020.Controls.Log4net.LogInfo(
                            ctx.Entry(oHeader).State == System.Data.Entity.EntityState.Added ?
                            RT2020.Controls.Log4net.LogAction.Create :
                            RT2020.Controls.Log4net.LogAction.Update, oHeader.ToString());
                        #endregion

                        this.REJId = oHeader.HeaderId;

                        #region SaveREJDetail();
                        foreach (ListViewItem listItem in lvDetailsList.Items)
                        {
                            Guid detailId = Guid.Empty, productId = Guid.Empty;

                            if (Guid.TryParse(listItem.Text.Trim(), out detailId) && Guid.TryParse(listItem.SubItems[11].Text.Trim(), out productId))
                            {
                                //System.Guid detailId = new Guid(listItem.Text.Trim());
                                var oDetail = ctx.InvtBatchCAP_Details.Find(detailId);
                                if (oDetail == null)
                                {
                                    oDetail = new EF6.InvtBatchCAP_Details();
                                    oDetail.DetailsId = Guid.NewGuid();
                                    oDetail.HeaderId = this.REJId;
                                    oDetail.TxNumber = txtTxNumber.Text;
                                    oDetail.TxType = txtTxType.Text;
                                    oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);

                                    ctx.InvtBatchCAP_Details.Add(oDetail);
                                }
                                oDetail.ProductId = productId;  // new Guid(listItem.SubItems[11].Text.Trim());
                                oDetail.Qty = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                                oDetail.UnitAmount = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);
                                oDetail.UnitAmountInForeignCurrency = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);

                                if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
                                {
                                    ctx.InvtBatchCAP_Details.Remove(oDetail);
                                }
                                ctx.SaveChanges();
                            }
                        }
                        #endregion

                        #region UpdateHeaderInfo(); HACK: 點解喺呢度先 update Total Amount? 我將佢搬咗上去
                        //oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text : "0");
                        //ctx.SaveChanges();

                        // log activity (Update)
                        //RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oHeader.ToString());
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
        private void UpdateHeaderInfo()
        {
            InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.Load(this.REJId);
            if (oHeader != null)
            {
                oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text : "0");
                oHeader.Save();

                // log activity (Update)
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oHeader.ToString());
            }
        }
        */
        #endregion

        #region Load REJ Header Info
        private void LoadREJInfo()
        {
            var oHeader = ModelEx.InvtBatchCAP_HeaderEx.Get(this.REJId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;
                txtTxType.Text = oHeader.TxType;

                cboWorkplace.SelectedValue = oHeader.WorkplaceId;
                cboOperatorCode.SelectedValue = oHeader.StaffId;
                cboStatus.Text = (oHeader.Status == 0) ? "HOLD" : "POST";

                dtpRecvDate.Value = oHeader.TxDate.Value;

                cboSupplierList.SelectedValue = oHeader.SupplierId;
                txtSupplierInvoice.Text = oHeader.SupplierRefernce;
                txtRemarks.Text = oHeader.Remarks;
                txtRefNumber.Text = oHeader.Reference;

                txtLastUpdateOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.ModifiedOn, false);
                txtLastUpdateBy.Text = ModelEx.StaffEx.GetStaffNumberById(oHeader.ModifiedBy);

                txtAmendmentRetrict.Text = oHeader.ReadOnly ? "Y" : "N";
                chkAPLink.Checked = oHeader.LinkToAP;

                txtTotalQty.Text = ModelEx.InvtBatchCAP_DetailsEx.GetTotalQty(this.REJId).ToString("n0");
                txtTotalAmount.Text = ModelEx.InvtBatchCAP_DetailsEx.GetTotalAmount(this.REJId).ToString("n2");

                this.Text += oHeader.ReadOnly ? " (ReadOnly)" : "";

                BindREJDetailsInfo();
            }
        }
        #endregion

        #region Delete
        /**
        private void Delete()
        {
            InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.Load(this.REJId);
            if (oHeader != null)
            {
                string sql = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                DeleteDetails(sql);

                oHeader.Delete();

                // log activity (Delete)
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, oHeader.ToString());
            }
        }

        private void DeleteDetails(string sql)
        {
            InvtBatchCAP_DetailsCollection oDetailList = InvtBatchCAP_Details.LoadCollection(sql);
            foreach (InvtBatchCAP_Details oDetail in oDetailList)
            {
                oDetail.Delete();
                // log activity (Delete)
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, oDetail.ToString());
            }
        }
        */
        #endregion

        #region Message Handler
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (Save())
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        RT2020.Inventory.GoodsReturn.Wizard wizard = new RT2020.Inventory.GoodsReturn.Wizard(this.REJId);
                        wizard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (Save())
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        this.Close();
                        RT2020.Inventory.GoodsReturn.Wizard wizard = new RT2020.Inventory.GoodsReturn.Wizard();
                        wizard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (Save())
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                ModelEx.InvtBatchCAP_HeaderEx.DeleteChildToo(this.REJId);   //Delete();

                this.Close();
            }
        }

        private void TabChangedMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.GoodsReturn.Wizard wizard = new RT2020.Inventory.GoodsReturn.Wizard(this.REJId);
                    wizard.ShowDialog();
                }
            }
            else
            {
                tabGoodsREJ.SelectedIndex = 0;
            }
        }
        #endregion

        #region REJ Detail

        #region Bind REJ Detail List
        private void BindREJDetailsInfo()
        {
            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" Qty, UnitAmount, ProductId ");
            sql.Append(" FROM vwCAPDetailsList ");
            sql.Append(" WHERE HeaderId = '").Append(this.REJId.ToString()).Append("'");
            sql.Append(" ORDER BY LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem listItem = lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); // DetailsId
                    listItem.SubItems.Add((iCount).ToString()); // LineNumber
                    listItem.SubItems.Add(string.Empty);
                    listItem.SubItems.Add(reader.GetString(2)); // STKCode
                    listItem.SubItems.Add(reader.GetString(3)); // Appendix1
                    listItem.SubItems.Add(reader.GetString(4)); // Appendix2
                    listItem.SubItems.Add(reader.GetString(5)); // Appendix3
                    listItem.SubItems.Add(reader.GetString(6)); // ProductName
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // Qty
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2")); // UnitPrice

                    decimal amt = reader.GetDecimal(7) * reader.GetDecimal(8);
                    listItem.SubItems.Add(amt.ToString("n2")); // Amount
                    listItem.SubItems.Add(reader.GetGuid(9).ToString()); // ProductId

                    iCount++;
                }
            }

            lblLineCount.Text = (iCount - 1).ToString();
        }
        #endregion

        #region Save REJ Detail Info
        /**
        private void SaveREJDetail()
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[11].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    InvtBatchCAP_Details oDetail = InvtBatchCAP_Details.Load(detailId);
                    if (oDetail == null)
                    {
                        oDetail = new InvtBatchCAP_Details();
                        oDetail.HeaderId = this.REJId;
                        oDetail.TxNumber = txtTxNumber.Text;
                        oDetail.TxType = txtTxType.Text;
                        oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);
                    }
                    oDetail.ProductId = new Guid(listItem.SubItems[11].Text.Trim());
                    oDetail.Qty = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                    oDetail.UnitAmount = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);
                    oDetail.UnitAmountInForeignCurrency = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);

                    if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
                    {
                        oDetail.Delete();
                    }
                    else
                    {
                        oDetail.Save();
                    }
                }
            }
        }
        */
        #endregion

        #region Load REJ Detail Info
        private void LoadREJDetailsInfo(ListViewItem lvItem)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvItem.Text))
                {
                    this.ValidSelection = true;

                    this.REJDetailId = new Guid(lvItem.Text);
                    this.SelectedIndex = lvDetailsList.SelectedIndex;

                    txtDescription.Text = lvItem.SubItems[7].Text;
                    txtQty.Text = lvItem.SubItems[8].Text;
                    txtUnitPrice.Text = lvItem.SubItems[9].Text;
                    txtUnitAmount.Text = lvItem.SubItems[9].Text;

                    basicProduct.SelectedItem = new Guid(lvItem.SubItems[11].Text);
                    basicProduct.ResultList = SetDetailData(lvItem.SubItems[3].Text);
                    this.ProductId = new Guid(lvItem.SubItems[11].Text);

                    this.ValidSelection = false;
                }
            }
        }
        #endregion

        #endregion

        #region Add/Edit/Remove Item
        private bool IsDuplicated(string stkCode, string appendix1, string appendix2, string appendix3)
        {
            bool isDuplicated = false;

            foreach (ListViewItem oItem in lvDetailsList.Items)
            {
                if (stkCode.Length > 0)
                {
                    isDuplicated = (oItem.SubItems[3].Text == stkCode);
                    isDuplicated = isDuplicated & (oItem.SubItems[4].Text == appendix1);
                    isDuplicated = isDuplicated & (oItem.SubItems[5].Text == appendix2);
                    isDuplicated = isDuplicated & (oItem.SubItems[6].Text == appendix3);

                    if (isDuplicated)
                        break;
                }
            }

            return isDuplicated;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            if (basicProduct.SelectedItem != null)
            {
                var oProd = ModelEx.ProductEx.Get((Guid)basicProduct.SelectedItem);
                if (oProd != null)
                {
                    if (IsDuplicated(oProd.STKCODE, oProd.APPENDIX1, oProd.APPENDIX2, oProd.APPENDIX3))
                    {
                        //this.Invoke(new EventHandler(btnEditItem_Click), new object[] { this, e });
                        MessageBox.Show(string.Format(Resources.Common.DuplicatedCode, "Stock Item"), string.Format(Resources.Common.DuplicatedCode, string.Empty));
                    }
                    else
                    {
                        if (this.ProductId != System.Guid.Empty)
                        {
                            ListViewItem listItem = lvDetailsList.Items.Add(System.Guid.Empty.ToString());
                            listItem.SubItems.Add(lvDetailsList.Items.Count.ToString());
                            listItem.SubItems.Add("NEW"); // Status
                            listItem.SubItems.Add(oProd.STKCODE); // Stock Code
                            listItem.SubItems.Add(oProd.APPENDIX1); // Appendix1
                            listItem.SubItems.Add(oProd.APPENDIX2); // Appendix2
                            listItem.SubItems.Add(oProd.APPENDIX3); // Appendix3
                            listItem.SubItems.Add(txtDescription.Text); // Description
                            listItem.SubItems.Add(txtQty.Text.Length == 0 ? "0" : txtQty.Text); // Rej. Qty
                            listItem.SubItems.Add(txtUnitAmount.Text); // Unit Amount

                            decimal qty = Convert.ToDecimal(txtQty.Text.Length == 0 ? "0" : txtQty.Text);
                            decimal unitPrice = Convert.ToDecimal(txtUnitAmount.Text.Length == 0 ? "0" : txtUnitAmount.Text);
                            decimal amt = qty * unitPrice;
                            listItem.SubItems.Add(amt.ToString("n2")); // Amount
                            listItem.SubItems.Add(this.ProductId.ToString()); // ProductId

                            CalcTotal();
                        }
                    }
                }
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (basicProduct.SelectedItem != null)
                {
                    var oProd = ModelEx.ProductEx.Get(this.ProductId);
                    if (oProd != null)
                    {
                        ListViewItem listItem = lvDetailsList.SelectedItem;
                        listItem.SubItems[2].Text = listItem.SubItems[2].Text != "NEW" ? "EDIT" : listItem.SubItems[2].Text; // Status
                        listItem.SubItems[3].Text = oProd.STKCODE; // Stock Code
                        listItem.SubItems[4].Text = oProd.APPENDIX1; // Appendix1
                        listItem.SubItems[5].Text = oProd.APPENDIX2; // Appendix2
                        listItem.SubItems[6].Text = oProd.APPENDIX3; // Appendix3
                        listItem.SubItems[7].Text = txtDescription.Text; // Description
                        listItem.SubItems[8].Text = txtQty.Text; // Qty
                        listItem.SubItems[9].Text = txtUnitAmount.Text; // Unit Amount

                        decimal qty = Convert.ToDecimal(txtQty.Text.Length == 0 ? "0" : txtQty.Text);
                        decimal price = Convert.ToDecimal(txtUnitAmount.Text.Length == 0 ? "0" : txtUnitAmount.Text);
                        decimal amt = qty * price;
                        listItem.SubItems[10].Text = amt.ToString("n2"); // Amount
                        listItem.SubItems[11].Text = this.ProductId.ToString(); // ProductId

                        CalcTotal();

                        basicProduct.ResultList = SetDetailData(oProd.STKCODE);
                    }
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (lvDetailsList.SelectedItem.Text != System.Guid.Empty.ToString())
                {
                    ListViewItem listItem = lvDetailsList.SelectedItem;
                    listItem.SubItems[2].Text = "REMOVED"; // Status
                }
                else
                {
                    lvDetailsList.Items.Remove(lvDetailsList.SelectedItem);
                    lvDetailsList.Update();
                }

                CalcTotal();
            }
        }

        private void CalcTotal()
        {
            decimal ttlQty = 0, ttlAmount = 0;
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (listItem.SubItems[2].Text != "REMOVED")
                {
                    ttlQty += Convert.ToDecimal(listItem.SubItems[8].Text.Length > 0 ? listItem.SubItems[8].Text : "0");
                    ttlAmount += Convert.ToDecimal(listItem.SubItems[10].Text.Length > 0 ? listItem.SubItems[10].Text : "0");
                }
            }

            txtTotalQty.Text = ttlQty.ToString("n0");
            txtTotalAmount.Text = ttlAmount.ToString("n2");
        }
        #endregion

        private void lvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadREJDetailsInfo(lvDetailsList.SelectedItem);
        }

        private void basicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            if (!this.ValidSelection)
            {
                int iCount = 0;
                txtDescription.Text = e.Description;
                txtUnitPrice.Text = e.UnitPrice.ToString("n2");
                txtUnitAmount.Text = e.UnitPrice.ToString("n2");

                foreach (ListViewItem lvItem in lvDetailsList.Items)
                {
                    lvItem.Selected = false;

                    if (lvItem.SubItems[11].Text == e.ProductId.ToString())
                    {
                        if (lvItem.Text != System.Guid.Empty.ToString() && Common.Utility.IsGUID(lvItem.Text))
                        {
                            if (iCount == 0)
                            {
                                txtQty.Text = lvItem.SubItems[8].Text;

                                this.ProductId = e.ProductId;
                                this.REJDetailId = new Guid(lvItem.Text);
                                this.SelectedIndex = lvItem.Index;
                                lvItem.Selected = true;
                            }

                            iCount++;
                        }
                    }
                }
            }
        }

        #region IWizard Members

        public void AddItemByList(List<RT2020.Controls.ProductSearcher.DetailData> resultList)
        {
            foreach (RT2020.Controls.ProductSearcher.DetailData detail in resultList)
            {
                var oProduct = ModelEx.ProductEx.Get(detail.ProductId);
                if (oProduct != null)
                {
                    string stkCode = oProduct.STKCODE;
                    string appendix1 = oProduct.APPENDIX1;
                    string appendix2 = oProduct.APPENDIX2;
                    string appendix3 = oProduct.APPENDIX3;

                    decimal amt = detail.Qty * detail.UnitAmount;

                    if (IsDuplicated(stkCode, appendix1, appendix2, appendix3))
                    {
                        foreach (ListViewItem lvItem in lvDetailsList.Items)
                        {
                            if (lvItem.SubItems[11].Text == oProduct.ProductId.ToString() && lvItem.SubItems[2].Text != "REMOVED")
                            {
                                if (lvItem.SubItems[8].Text != detail.Qty.ToString("n0") || lvItem.SubItems[9].Text != detail.UnitAmount.ToString("n2"))
                                {
                                    lvItem.SubItems[2].Text = lvItem.SubItems[2].Text != "NEW" ? "EDIT" : lvItem.SubItems[2].Text; // Status
                                    lvItem.SubItems[8].Text = detail.Qty.ToString("n0"); // QTY
                                    lvItem.SubItems[9].Text = detail.UnitAmount.ToString("n2"); // Unit Amount
                                    lvItem.SubItems[10].Text = amt.ToString("n2"); // Amount
                                }
                            }
                        }
                    }
                    else
                    {
                        ListViewItem listItem = lvDetailsList.Items.Add(System.Guid.Empty.ToString());
                        listItem.SubItems.Add(lvDetailsList.Items.Count.ToString());
                        listItem.SubItems.Add("NEW"); // Status
                        listItem.SubItems.Add(stkCode); // Stock Code
                        listItem.SubItems.Add(appendix1); // Appendix1
                        listItem.SubItems.Add(appendix2); // Appendix2
                        listItem.SubItems.Add(appendix3); // Appendix3
                        listItem.SubItems.Add(oProduct.ProductName); // Description
                        listItem.SubItems.Add(detail.Qty.ToString("n0")); // Qty
                        listItem.SubItems.Add(detail.UnitAmount.ToString("n2")); // Unit Amount
                        listItem.SubItems.Add(amt.ToString("n2")); // Amount
                        listItem.SubItems.Add(oProduct.ProductId.ToString()); // ProductId
                    }
                }
            }

            CalcTotal();
        }

        public List<RT2020.Controls.ProductSearcher.DetailData> SetDetailData(string STKCODE)
        {
            List<RT2020.Controls.ProductSearcher.DetailData> ResultList = new List<RT2020.Controls.ProductSearcher.DetailData>();

            foreach (ListViewItem lvItem in lvDetailsList.Items)
            {
                if (lvItem.SubItems[3].Text.Trim() == STKCODE)
                {
                    Guid prodId = new Guid(lvItem.SubItems[11].Text);
                    decimal unitPrice = Convert.ToDecimal(Common.Utility.IsNumeric(lvItem.SubItems[9].Text.Trim()) ? lvItem.SubItems[9].Text.Trim() : "0"); // UnitAmountInForeignCurrency
                    decimal qty = Convert.ToDecimal(Common.Utility.IsNumeric(lvItem.SubItems[8].Text.Trim()) ? lvItem.SubItems[8].Text.Trim() : "0");

                    RT2020.Controls.ProductSearcher.DetailData detail = ResultList.Find(d => d.ProductId == prodId);

                    if (detail == null)
                    {
                        detail = new RT2020.Controls.ProductSearcher.DetailData();
                        detail.ProductId = prodId;
                        detail.Qty = qty;
                        detail.UnitAmount = unitPrice;
                    }
                    else
                    {
                        ResultList.Remove(detail);

                        detail.Qty = qty;
                        detail.UnitAmount = unitPrice;
                    }

                    ResultList.Add(detail);
                }
            }

            return ResultList;
        }

        #endregion
    }
}