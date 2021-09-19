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


using RT2020.Controls;
using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

namespace RT2020.Inventory.Replenishment
{
    public partial class Wizard : Form, IGatewayComponent
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

        public Wizard(Guid rplId)
        {
            InitializeComponent();

            SetAttributes();
            SetSystemLabel();

            this.RplId = rplId;

            SetCtrlEditable();
            FillCboList();
            SetToolBar();
            LoadRplInfo();
        }

        #region Set System Label
        private void SetAttributes()
        {
            this.Text = Utility.Dictionary.GetWord("Replenishment") + " > " + Utility.Dictionary.GetWord("Wizard");

            lblTxNumber.Text = Utility.Dictionary.GetWordWithColon("TxNumber");
            lblTxConfirmed.Text = Utility.Dictionary.GetWordWithColon("Confirmed");

            tpGeneral.Text = Utility.Dictionary.GetWord("General");
            tpDetails.Text = Utility.Dictionary.GetWord("Details");

            lblFromLocation.Text = Utility.Dictionary.GetWordWithColon("from_location");
            lblToLocation.Text = Utility.Dictionary.GetWordWithColon("to_location");
            lblTxferDate.Text = Utility.Dictionary.GetWordWithColon("transfer_date");
            lblCompletionDate.Text = Utility.Dictionary.GetWordWithColon("completion_date");
            lblTransactionDate.Text = Utility.Dictionary.GetWordWithColon("txdate");
            lblOperatorCode.Text = Utility.Dictionary.GetWordWithColon("Staff");
            lblStatus.Text = Utility.Dictionary.GetWordWithColon("Status");
            lblRemarks.Text = Utility.Dictionary.GetWordWithColon("Remarks");
            lblLastUpdate.Text = Utility.Dictionary.GetWordWithColon("Last Update");
            lblSpecialRequest.Text = Utility.Dictionary.GetWordWithColon("special_request");

            lblStockCode.Text = Utility.Dictionary.GetWordWithColon("Product");
            lblDescription.Text = Utility.Dictionary.GetWordWithColon("Description");
            lblReplenishQty.Text = Utility.Dictionary.GetWordWithColon("Replenish Qty");
            lblActualQty.Text = Utility.Dictionary.GetWordWithColon("Actual Qty");
            label1.Text = Utility.Dictionary.GetWordWithColon("number_of_line");
            lblRemarks_Details.Text = Utility.Dictionary.GetWordWithColon("remarks");

            colLN.Text = Utility.Dictionary.GetWord("LN");
            colStatus.Text = Utility.Dictionary.GetWord("Status");
            colDescription.Text = Utility.Dictionary.GetWord("Description");
            colReplenishQty.Text = Utility.Dictionary.GetWord("replenish_qty");
            colActualQty.Text = Utility.Dictionary.GetWord("actual_qty");
            colRemarks.Text = Utility.Dictionary.GetWord("Remarks");

            btnAddItem.Text = Utility.Dictionary.GetWord("Add Item");
            btnEditItem.Text = Utility.Dictionary.GetWord("Edit Item");
            btnRemove.Text = Utility.Dictionary.GetWord("Remove Item");

            basicProduct.HasMatrix = false;
        }

        private void SetSystemLabel()
        {
            colStockCode.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

        #region Ctrl Editable
        private void SetCtrlEditable()
        {
            cboFromLocation.Enabled = false;
            cboFromLocation.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            cboToLocation.Enabled = false;
            cboToLocation.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            cboOperatorCode.Enabled = false;
            cboOperatorCode.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            txtTxNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtTxConfirmed.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtConfirmedOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtConfirmedBy.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtSpecialRequest.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastUpdateBy.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtLastUpdateOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            txtDescription.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtReplenishQty.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
        }
        #endregion

        #region Properties
        private Guid rplId = System.Guid.Empty;
        public Guid RplId
        {
            get
            {
                return rplId;
            }
            set
            {
                rplId = value;
            }
        }

        private Guid rplDetailId = System.Guid.Empty;
        public Guid RplDetailId
        {
            get
            {
                return rplDetailId;
            }
            set
            {
                rplDetailId = value;
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

        private int SelectedIndex = -1;
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
            DataTable dt = Reports.DataSource.Worksheet(this.txtTxNumber.Text, this.txtTxNumber.Text, this.dtpTxDate.Value, this.dtpTxDate.Value);

            string filename = txtTxNumber.Text.Trim() + ".pdf";

            RT2020.Inventory.Replenishment.Reports.WorksheetRpt report = new RT2020.Inventory.Replenishment.Reports.WorksheetRpt();
            report.DataSource = dt;
            report.TxNumberFrom = this.txtTxNumber.Text.Trim();
            report.TxNumberTo = this.txtTxNumber.Text.Trim();
            report.TxDateFrom = this.dtpTxDate.Value;
            report.TxDateTo = this.dtpTxDate.Value;
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
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", HttpUtility.UrlDecode(Utility.Dictionary.GetWord("Save_New")));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = false;

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", HttpUtility.UrlDecode(Utility.Dictionary.GetWord("Save_Close")));
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

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

            if (RplId == System.Guid.Empty)
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

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        if (IsValid())
                        {
                            MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        }
                        break;
                    case "save & new":
                        if (IsValid())
                        {
                            MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        }
                        break;
                    case "save & close":
                        if (IsValid())
                        {
                            MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        }
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                    case "print":
                        //Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
                        btnPreview_Click();
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
                          FROM vwRptBatchRPL
                          WHERE	TxNumber BETWEEN '" + this.txtTxNumber.Text.Trim() + @"' AND '" + this.txtTxNumber.Text.Trim() + @"' 
                          AND CONVERT(VARCHAR(10), TxDate, 126) BETWEEN '" + this.dtpTxDate.Value.ToString("yyyy-MM-dd") + @"' 
                                                                        AND '" + this.dtpTxDate.Value.ToString("yyyy-MM-dd") + @"'
                          ORDER BY TxNumber, TxDate, LineNumber
                          ";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private void btnPreview_Click()
        {
            string[,] param = {
                { "FromTxNumber", this.txtTxNumber.Text.Trim() },
                { "ToTxNumber", this.txtTxNumber.Text.Trim() },
                { "FromTxDate", this.dtpTxDate.Value.ToString(DateTimeHelper.GetDateFormat()) },
                { "ToTxDate", this.dtpTxDate.Value.ToString(DateTimeHelper.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(DateTimeHelper.GetDateTimeFormat()) },
                { "PrintedBy", StaffEx.GetStaffNameById(ConfigHelper.CurrentUserId) },
                { "DateFormat", DateTimeHelper.GetDateFormat() },
                { "CompanyName", SystemInfoEx.CurrentInfo.Default.CompanyName},
                { "StockCode", SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3") }
                };

            RT2020.Controls.Reporting.Viewer oViewer = new RT2020.Controls.Reporting.Viewer();

            oViewer.Datasource = BindData();
            oViewer.ReportName = "RT2020.Inventory.Replenishment.Reports.WorksheetRdl.rdlc";
            oViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptBatchRPL";
            oViewer.Parameters = param;

            oViewer.Show();
        }
        #endregion

        #region Fill Combo List
        private void FillCboList()
        {
            FillFromLocationList();
            FillToLocationList();
            FillStaffList();
        }

        private void FillFromLocationList()
        {
            WorkplaceEx.LoadCombo(ref cboFromLocation, "WorkplaceCode", false);
        }

        private void FillToLocationList()
        {
            WorkplaceEx.LoadCombo(ref cboToLocation, "WorkplaceCode", false);
            cboToLocation.SelectedIndex = cboToLocation.Items.Count - 1;
        }

        private void FillStaffList()
        {
            StaffEx.LoadCombo(ref cboOperatorCode, "StaffNumber", false);
        }
        #endregion

        #region Save Rpl Header Info
        private bool IsValid()
        {
            if (dtpTxferDate.Value.ToString("yyyy-MM-dd").CompareTo(DateTime.Now.ToString("yyyy-MM-dd")) < 0)
            {
                errorProvider.SetError(dtpTxferDate, "Transfer date cannot be earlier than today!");
            }
            else
            {
                errorProvider.SetError(dtpTxferDate, string.Empty);
            }

            if (dtpCompDate.Value.ToString("yyyy-MM-dd").CompareTo(dtpTxferDate.Value.ToString("yyyy-MM-dd")) < 0)
            {
                errorProvider.SetError(dtpCompDate, "Completion date cannot be earlier than transfer date!");
            }
            else
            {
                errorProvider.SetError(dtpCompDate, string.Empty);
            }

            return (errorProvider.GetError(dtpTxDate).Length == 0 && errorProvider.GetError(dtpTxferDate).Length == 0 && errorProvider.GetError(dtpCompDate).Length == 0);
        }

        private void Save()
        {
            if (IsValid())
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    using (var scope = ctx.Database.BeginTransaction())
                    {
                        try
                        {
                            #region save InvtBatchRPL_Header
                            var oHeader = ctx.InvtBatchRPL_Header.Find(this.RplId);
                            if (oHeader != null)
                            {
                                oHeader.Status = cboStatus.Text == "HOLD" ? (int)EnumHelper.Status.Draft : (int)EnumHelper.Status.Active;

                                oHeader.TxDate = dtpTxDate.Value;
                                oHeader.TXFOn = dtpTxferDate.Value;
                                oHeader.CompletedOn = dtpCompDate.Value;

                                oHeader.FromLocation = cboFromLocation.Text;
                                oHeader.ToLocation = cboToLocation.Text;
                                oHeader.StaffId = new Guid(cboOperatorCode.SelectedValue.ToString());
                                oHeader.Remarks = txtRemarks.Text;

                                oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                oHeader.ModifiedOn = DateTime.Now;

                                ctx.SaveChanges();

                                this.RplId = oHeader.HeaderId;
                            }
                            #endregion

                            #region SaveRplDetail();
                            foreach (ListViewItem listItem in lvDetailsList.Items)
                            {
                                Guid detailId = Guid.Empty, productId = Guid.Empty;

                                if (Guid.TryParse(listItem.Text.Trim(), out detailId) && Guid.TryParse(listItem.SubItems[11].Text.Trim(), out productId))
                                {
                                    //System.Guid detailId = new Guid(listItem.Text.Trim());
                                    var oDetail = ctx.InvtBatchRPL_Details.Find(detailId);
                                    if (oDetail == null)
                                    {
                                        oDetail = new EF6.InvtBatchRPL_Details();
                                        oDetail.DetailsId = Guid.NewGuid();
                                        oDetail.HeaderId = this.RplId;
                                        oDetail.TxNumber = txtTxNumber.Text;
                                        oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);

                                        ctx.InvtBatchRPL_Details.Add(oDetail);
                                    }
                                    oDetail.ProductId = productId;  // new Guid(listItem.SubItems[11].Text.Trim());
                                    oDetail.QtyRequested = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                                    oDetail.QtyIssued = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);
                                    oDetail.Remarks = listItem.SubItems[10].Text;

                                    if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != Guid.Empty)
                                    {
                                        ctx.InvtBatchRPL_Details.Remove(oDetail);
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
        }
        #endregion

        #region Load Rpl Header Info
        private void LoadRplInfo()
        {
            var oHeader = InvtBatchRPL_HeaderEx.Get(this.RplId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;

                cboFromLocation.Text = oHeader.FromLocation;
                cboToLocation.Text = oHeader.ToLocation;
                cboOperatorCode.SelectedValue = oHeader.StaffId;
                cboStatus.Text = (oHeader.Status == 0) ? "HOLD" : "POST";

                dtpTxDate.Value = oHeader.TxDate.Value;
                dtpTxferDate.Value = oHeader.TXFOn.Value;
                dtpCompDate.Value = oHeader.CompletedOn.Value;

                txtRemarks.Text = oHeader.Remarks;

                txtLastUpdateOn.Text = DateTimeHelper.DateTimeToString(oHeader.ModifiedOn, false);
                txtLastUpdateBy.Text = StaffEx.GetStaffNumberById(oHeader.ModifiedBy);

                txtTxConfirmed.Text = oHeader.Confirmed ? "Y" : "N";
                txtConfirmedBy.Text = StaffEx.GetStaffNumberById(oHeader.ConfirmedBy.Value);
                txtConfirmedOn.Text = DateTimeHelper.DateTimeToString(oHeader.ConfirmedOn.Value, false);
                txtSpecialRequest.Text = oHeader.SpecialRequest ? "Y" : "N";

                this.tbWizardAction.Buttons[0].Enabled = !oHeader.Confirmed;
                this.tbWizardAction.Buttons[2].Enabled = !oHeader.Confirmed;
                this.tbWizardAction.Buttons[4].Enabled = !oHeader.Confirmed;

                BindRplDetailsInfo();
            }
        }
        #endregion

        #region Delete
        /**
        private void Delete()
        {
            InvtBatchRPL_Header oHeader = InvtBatchRPL_Header.Load(this.RplId);
            if (oHeader != null)
            {
                string sql = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                DeleteDetails(sql);

                oHeader.Delete();
            }
        }

        private void DeleteDetails(string sql)
        {
            InvtBatchRPL_DetailsCollection oDetailList = InvtBatchRPL_Details.LoadCollection(sql);
            foreach (InvtBatchRPL_Details oDetail in oDetailList)
            {
                oDetail.Delete();
            }
        }
        */
        #endregion

        #region Message Handler
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    Helper.DesktopHelper.RefreshMainList<Default>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Replenishment.Wizard wizard = new RT2020.Inventory.Replenishment.Wizard(this.RplId);
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    Helper.DesktopHelper.RefreshMainList<Default>();
                    this.Close();
                    RT2020.Inventory.Replenishment.Wizard wizard = new RT2020.Inventory.Replenishment.Wizard();
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    Helper.DesktopHelper.RefreshMainList<Default>();
                    this.Close();
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                InvtBatchRPL_HeaderEx.DeleteChildToo(this.RplId); // Delete();

                this.Close();
            }
        }

        private void TabChangedMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Replenishment.Wizard wizard = new RT2020.Inventory.Replenishment.Wizard(this.RplId);
                    wizard.ShowDialog();
                }
            }
            else
            {
                tabGoodsRpl.SelectedIndex = 0;
            }
        }
        #endregion

        #region Rpl Detail

        #region Bind Rpl Detail List
        private void BindRplDetailsInfo()
        {
            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" QtyRequested, QtyIssued, Remarks, ProductId ");
            sql.Append(" FROM vwRPLDetailsList ");
            sql.Append(" WHERE HeaderId = '").Append(this.RplId.ToString()).Append("'");
            sql.Append(" ORDER BY LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 ");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem listItem = lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); // DetailsId
                    listItem.SubItems.Add(iCount.ToString()); // LineNumber
                    listItem.SubItems.Add(string.Empty);
                    listItem.SubItems.Add(reader.GetString(2)); // STKCode
                    listItem.SubItems.Add(reader.GetString(3)); // Appendix1
                    listItem.SubItems.Add(reader.GetString(4)); // Appendix2
                    listItem.SubItems.Add(reader.GetString(5)); // Appendix3
                    listItem.SubItems.Add(reader.GetString(6)); // ProductName
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // QtyRequested
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n0")); // QtyIssued
                    listItem.SubItems.Add(reader.GetString(9)); // Remarks
                    listItem.SubItems.Add(reader.GetGuid(10).ToString()); // ProductId

                    iCount++;
                }
            }

            lblLineCount.Text = (iCount - 1).ToString();
        }
        #endregion

        #region Save Rpl Detail Info
        /**
        private void SaveRplDetail()
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[11].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    InvtBatchRPL_Details oDetail = InvtBatchRPL_Details.Load(detailId);
                    if (oDetail == null)
                    {
                        oDetail = new InvtBatchRPL_Details();
                        oDetail.HeaderId = this.RplId;
                        oDetail.TxNumber = txtTxNumber.Text;
                        oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);
                    }
                    oDetail.ProductId = new Guid(listItem.SubItems[11].Text.Trim());
                    oDetail.QtyRequested = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                    oDetail.QtyIssued = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);
                    oDetail.Remarks = listItem.SubItems[10].Text;

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

        #region Load Rpl Detail Info
        private void LoadRplDetailsInfo(Guid detailId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" QtyRequested, QtyIssued, Remarks, ProductId ");
            sql.Append(" FROM vwRPLDetailsList ");
            sql.Append(" WHERE DetailsId = '").Append(detailId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    txtDescription.Text = reader.GetString(6);
                    txtReplenishQty.Text = reader.GetDecimal(7).ToString("n0");
                    txtActualQty.Text = reader.GetDecimal(8).ToString("n0");
                    txtRemarks_Detail.Text = reader.GetString(9);

                    basicProduct.SelectedItem = reader.GetGuid(10);

                    this.ProductId = reader.GetGuid(10);
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
                }
            }

            return isDuplicated;
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

            if (IsDuplicated(stkCode, appendix1, appendix2, appendix3))
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
                    listItem.SubItems.Add(stkCode); // Stock Code
                    listItem.SubItems.Add(appendix1); // Appendix1
                    listItem.SubItems.Add(appendix2); // Appendix2
                    listItem.SubItems.Add(appendix3); // Appendix3
                    listItem.SubItems.Add(txtDescription.Text); // Description
                    listItem.SubItems.Add(txtReplenishQty.Text.Length == 0 ? "0" : txtReplenishQty.Text); // Retail Price
                    listItem.SubItems.Add(txtActualQty.Text.Length == 0 ? "0" : txtActualQty.Text); // Required Qty
                    listItem.SubItems.Add(txtRemarks_Detail.Text); // Remarks
                    listItem.SubItems.Add(this.ProductId.ToString()); // ProductId
                }
            }
        }

        private void ItemInfo(ref string stkCode, ref string appendix1, ref string appendix2, ref string appendix3)
        {
            if (basicProduct.SelectedItem != null)
            {
                var oProd = ProductEx.Get((Guid)basicProduct.SelectedItem);
                if (oProd != null)
                {
                    stkCode = oProd.STKCODE;
                    appendix1 = oProd.APPENDIX1;
                    appendix2 = oProd.APPENDIX2;
                    appendix3 = oProd.APPENDIX3;

                    this.ProductId = oProd.ProductId;
                }
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

            ListViewItem listItem = lvDetailsList.SelectedItem;
            listItem.SubItems[2].Text = "EDIT"; // Status
            listItem.SubItems[3].Text = stkCode; // Stock Code
            listItem.SubItems[4].Text = appendix1; // Appendix1
            listItem.SubItems[5].Text = appendix2; // Appendix2
            listItem.SubItems[6].Text = appendix3; // Appendix3
            listItem.SubItems[7].Text = txtDescription.Text; // Description
            listItem.SubItems[8].Text = txtReplenishQty.Text; // Replenish Qty
            listItem.SubItems[9].Text = txtActualQty.Text; // Actual Qty
            listItem.SubItems[10].Text = txtRemarks_Detail.Text; // Remarks
            listItem.SubItems[11].Text = this.ProductId.ToString(); // ProductId
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            ListViewItem listItem = lvDetailsList.SelectedItem;
            listItem.SubItems[2].Text = "REMOVED"; // Status
        }
        #endregion

        private void lvDetailsList_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null && lvDetailsList.SelectedItem.SubItems[2].Text != "REMOVED")
            {
                Guid detailId = Guid.Empty;
                if (Guid.TryParse(lvDetailsList.SelectedItem.Text, out detailId))
                {
                    if (lvDetailsList.SelectedItem.Text != System.Guid.Empty.ToString())
                    {
                        this.ValidSelection = true;

                        this.SelectedIndex = lvDetailsList.SelectedIndex;

                        this.RplDetailId = detailId;
                        LoadRplDetailsInfo(detailId);

                        this.ValidSelection = false;
                    }
                }
            }
        }

        private void basicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            if (!this.ValidSelection)
            {
                int iCount = 0;

                txtDescription.Text = e.Description;
                txtReplenishQty.Text = "0";
                txtActualQty.Text = "0";

                foreach (ListViewItem lvItem in lvDetailsList.Items)
                {
                    lvItem.Selected = false;

                    if (lvItem.SubItems[11].Text.Trim() == e.ProductId.ToString())
                    {
                        Guid detailId = Guid.Empty;
                        if (Guid.TryParse(lvItem.Text, out detailId))
                        {
                            if (detailId != Guid.Empty)
                            {
                                if (iCount == 0)
                                {
                                    txtReplenishQty.Text = lvItem.SubItems[8].Text;
                                    txtActualQty.Text = lvItem.SubItems[9].Text;
                                    txtRemarks_Detail.Text = lvItem.SubItems[10].Text;

                                    this.ProductId = e.ProductId;
                                    this.RplDetailId = detailId;    // new Guid(lvItem.Text);
                                    this.SelectedIndex = lvItem.Index;

                                    lvItem.Selected = true;

                                    iCount++;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void dtpDate_ValueChanged(object sender, EventArgs e)
        {
            IsValid();
        }
    }
}