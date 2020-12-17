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
using RT2020.Helper;

namespace RT2020.Inventory.Adjustment
{
    public partial class Wizard : Form, IGatewayComponent, IWizard
    {
        private Guid _AdjId = System.Guid.Empty;
        private Guid _AdjDetailId = System.Guid.Empty;
        private Guid _ProductId = System.Guid.Empty;
        private int SelectedIndex = 0;
        private bool ValidSelection = false;
        private Guid _WorkplaceId = System.Guid.Empty;        //2013.12.23 paulus: Adjustment Header > Workplace

        #region Public Properties
        public Guid ADJId
        {
            get
            {
                return _AdjId;
            }
            set
            {
                _AdjId = value;
            }
        }

        public Guid ADJDetailId
        {
            get
            {
                return _AdjDetailId;
            }
            set
            {
                _AdjDetailId = value;
            }
        }

        public Guid ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }

        #endregion

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

        public Wizard(Guid adjId)
        {
            InitializeComponent();

            SetAttributes();
            SetSystemLabel();

            this.ADJId = adjId;

            FillCboList();
            SetToolBar();
            LoadADJInfo();
        }

        #region Set System Label
        private void SetAttributes()
        {
            this.Text = Utility.Dictionary.GetWord("Adjustment") + " > " + Utility.Dictionary.GetWord("Wizard");

            lblTxType.Text = Utility.Dictionary.GetWordWithColon("TxType");
            lblTxNumber.Text = Utility.Dictionary.GetWordWithColon("TxNumber");
            lblTxDate.Text = Utility.Dictionary.GetWordWithColon("Txdate");
            lblTotalAmount.Text = string.Format(Utility.Dictionary.GetWordWithColon("total_amount_with_currency"), "$");

            tpGeneral.Text = Utility.Dictionary.GetWord("General");
            tpDetails.Text = Utility.Dictionary.GetWord("Details");

            lblLocation.Text = Utility.Dictionary.GetWordWithColon("workplace");
            lblOperatorCode.Text = Utility.Dictionary.GetWordWithColon("Staff");
            lblRefNumber.Text = Utility.Dictionary.GetWordWithColon("Reference");
            lblStatus.Text = Utility.Dictionary.GetWordWithColon("Status");
            lblRemarks.Text = Utility.Dictionary.GetWordWithColon("Remarks");
            lblTotalQty.Text = Utility.Dictionary.GetWordWithColon("Total Qty");
            lblLastUpdate.Text = Utility.Dictionary.GetWordWithColon("Last Update");

            lblStockCode.Text = Utility.Dictionary.GetWordWithColon("Product");
            lblDescription.Text = Utility.Dictionary.GetWordWithColon("Description");
            lblQty.Text = Utility.Dictionary.GetWordWithColon("Qty");
            lblNumberOfLine.Text = Utility.Dictionary.GetWordWithColon("number_of_line");
            lblAvgCost.Text = Utility.Dictionary.GetWordWithColon("average_cost");
            lblOnHand.Text = Utility.Dictionary.GetWordWithColon("on-hand_quantity");
            lblRemarks_Details.Text = Utility.Dictionary.GetWordWithColon("remarks");

            colLN.Text = Utility.Dictionary.GetWord("LN");
            colStatus.Text = Utility.Dictionary.GetWord("Status");
            colDescription.Text = Utility.Dictionary.GetWord("Description");
            colQty.Text = Utility.Dictionary.GetWord("Qty");
            colOnHandQty.Text = Utility.Dictionary.GetWord("on-hand_quantity");
            colAvgCost.Text = Utility.Dictionary.GetWord("average_cost");
            colTotalAmount.Text = Utility.Dictionary.GetWord("total_amount");
            colRemarks.Text = Utility.Dictionary.GetWord("remarks");

            btnAddItem.Text = Utility.Dictionary.GetWord("Add Item");
            btnEditItem.Text = Utility.Dictionary.GetWord("Edit Item");
            btnRemove.Text = Utility.Dictionary.GetWord("Remove Item");

            basicFindProduct.TxType = Common.Enums.TxType.ADJ;
        }

        private void SetSystemLabel()
        {
            colStockCode.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

        #region IGatewayComponent Members

        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            DataTable dt = Reports.DataSource.Worksheet(this.txtTxNumber.Text, this.txtTxNumber.Text, this.dtpTxDate.Value, this.dtpTxDate.Value);

            string filename = txtTxNumber.Text.Trim() + ".pdf";

            RT2020.Inventory.Adjustment.Reports.WorksheetRpt report = new RT2020.Inventory.Adjustment.Reports.WorksheetRpt();
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
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", HttpUtility.UrlDecode(Utility.Dictionary.GetWord("Save_New")));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", HttpUtility.UrlDecode(Utility.Dictionary.GetWord("Save_Close")));
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

            if (ADJId == System.Guid.Empty)
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
            string sql = @" SELECT TOP 100 PERCENT *
                            FROM vwRptBatchADJ
                            WHERE	TxNumber BETWEEN '" + this.txtTxNumber.Text.Trim() + @"' AND '" + this.txtTxNumber.Text.Trim() + @"' 
                              AND CONVERT(VARCHAR(10), TxDate, 126) BETWEEN '" + this.dtpTxDate.Value.ToString("yyyy-MM-dd") + @"' 
                                                                        AND '" + this.dtpTxDate.Value.ToString("yyyy-MM-dd") + @"' 
                              AND TxType = '" + Common.Enums.TxType.ADJ.ToString() + @"' 
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
                { "FromTxDate", this.dtpTxDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "ToTxDate", this.dtpTxDate.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat()) },
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "PrintedBy", ModelEx.StaffEx.GetStaffNameById(Common.Config.CurrentUserId) },
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() },
                { "CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName},
                { "StockCode", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") }
                };

            RT2020.Controls.Reporting.Viewer oViewer = new RT2020.Controls.Reporting.Viewer();

            oViewer.Datasource = BindData();
            oViewer.ReportName = "RT2020.Inventory.Adjustment.Reports.WorksheetRdl.rdlc";
            oViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptBatchADJ";
            oViewer.Parameters = param;

            oViewer.Show();
        }
        #endregion

        #region Fill Combo List
        private void FillCboList()
        {
            FillLocationList();
            FillStaffList();
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
        #endregion

        #region Save ADJ Header Info
        private void Save()
        {
            if (errorProvider.GetError(cboWorkplace).Length == 0 && errorProvider.GetError(cboOperatorCode).Length == 0)
            {
                if (lvDetailsList.Items.Count > 0)
                {
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        using (var scope = ctx.Database.BeginTransaction())
                        {
                            try
                            {
                                var oHeader = ctx.InvtBatchADJ_Header.Find(this.ADJId);
                                if (oHeader == null)
                                {
                                    #region add new InvtBatchADJ_Header
                                    oHeader = new EF6.InvtBatchADJ_Header();

                                    txtTxNumber.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.ADJ);
                                    oHeader.HeaderId = Guid.NewGuid();
                                    oHeader.TxNumber = txtTxNumber.Text;
                                    oHeader.TxType = Common.Enums.TxType.ADJ.ToString();

                                    oHeader.CreatedBy = Common.Config.CurrentUserId;
                                    oHeader.CreatedOn = DateTime.Now;

                                    ctx.InvtBatchADJ_Header.Add(oHeader);
                                    #endregion
                                }
                                #region InvtBatchADJ_Header core data
                                oHeader.TxDate = dtpTxDate.Value;
                                oHeader.Status = Convert.ToInt32(cboStatus.Text == "HOLD" ? Common.Enums.Status.Draft.ToString("d") : Common.Enums.Status.Active.ToString("d"));

                                oHeader.WorkplaceId = new Guid(cboWorkplace.SelectedValue.ToString());
                                oHeader.StaffId = new Guid(cboOperatorCode.SelectedValue.ToString());
                                oHeader.Remarks = txtRemarks.Text;
                                oHeader.Reference = txtRefNumber.Text;

                                oHeader.ModifiedBy = Common.Config.CurrentUserId;
                                oHeader.ModifiedOn = DateTime.Now;
                                #endregion

                                oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text.Trim() : "0");

                                ctx.SaveChanges();

                                this.ADJId = oHeader.HeaderId;

                                #region log activity (New Record)
                                RT2020.Controls.Log4net.LogInfo(ctx.Entry(oHeader).State == System.Data.Entity.EntityState.Added ?
                                    RT2020.Controls.Log4net.LogAction.Create : RT2020.Controls.Log4net.LogAction.Update, oHeader.ToString());
                                #endregion

                                #region SaveADJDetail();
                                foreach (ListViewItem listItem in lvDetailsList.Items)
                                {
                                    Guid detailId = Guid.Empty, productId = Guid.Empty;
                                    if (Guid.TryParse(listItem.Text.Trim(), out detailId) && Guid.TryParse(listItem.SubItems[13].Text.Trim(), out productId))
                                    {
                                        //System.Guid detailId = new Guid(listItem.Text.Trim());
                                        var oDetail = ctx.InvtBatchADJ_Details.Find(detailId);
                                        if (oDetail == null)
                                        {
                                            oDetail = new EF6.InvtBatchADJ_Details();
                                            oDetail.DetailsId = Guid.NewGuid();
                                            oDetail.HeaderId = this.ADJId;
                                            oDetail.TxNumber = txtTxNumber.Text;
                                            oDetail.TxType = txtTxType.Text;
                                            oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);

                                            ctx.InvtBatchADJ_Details.Add(oDetail);
                                        }
                                        oDetail.ProductId = productId;  // new Guid(listItem.SubItems[13].Text.Trim());
                                        oDetail.Qty = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                                        oDetail.AverageCost = Convert.ToDecimal(listItem.SubItems[10].Text.Length == 0 ? "0" : listItem.SubItems[10].Text);
                                        oDetail.Remarks = listItem.SubItems[12].Text;

                                        if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != Guid.Empty)
                                        {
                                            ctx.InvtBatchADJ_Details.Remove(oDetail);
                                        }
                                        ctx.SaveChanges();
                                    }
                                }
                                #endregion

                                //UpdateHeaderInfo();

                                scope.Commit();
                            }
                            catch (Exception ex)
                            {
                                scope.Rollback();
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Cannot save the record without details!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Cannot save until the errors are fixed!", "Warning!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /**
        private void UpdateHeaderInfo()
        {
            InvtBatchADJ_Header oHeader = InvtBatchADJ_Header.Load(this.ADJId);
            if (oHeader != null)
            {
                oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text.Trim() : "0");

                oHeader.Save();

                // log activity (Update)
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oHeader.ToString());
            }
        }
        */
        #endregion

        #region Load ADJ Header Info
        private void LoadADJInfo()
        {
            var oHeader = ModelEx.InvtBatchADJ_HeaderEx.Get(this.ADJId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;
                txtTxType.Text = oHeader.TxType;

                cboWorkplace.SelectedValue = oHeader.WorkplaceId;
                cboOperatorCode.SelectedValue = oHeader.StaffId;
                cboStatus.Text = (oHeader.Status == 0) ? "HOLD" : "POST";

                dtpTxDate.Value = oHeader.TxDate.Value;

                txtRemarks.Text = oHeader.Remarks;
                txtRefNumber.Text = oHeader.Reference;

                txtLastUpdateOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.ModifiedOn, false);
                txtLastUpdateBy.Text = ModelEx.StaffEx.GetStaffNumberById(oHeader.ModifiedBy);

                txtTotalQty.Text = ModelEx.InvtBatchADJ_DetailsEx.GetTotalQty(this.ADJId).ToString("n0");
                txtTotalAmount.Text = ModelEx.InvtBatchADJ_DetailsEx.GetTotalAmount(this.ADJId).ToString("n2");

                _WorkplaceId = oHeader.WorkplaceId;

                BindADJDetailsInfo();
            }
        }
        /**
        private decimal GetTotalRequiredQty()
        {
            decimal totalQty = 0;

            string sql = "HeaderId = '" + this.ADJId.ToString() + "'";
            InvtBatchADJ_DetailsCollection oDetails = InvtBatchADJ_Details.LoadCollection(sql);
            foreach (InvtBatchADJ_Details oDetail in oDetails)
            {
                totalQty += oDetail.Qty;
            }

            return totalQty;
        }

        private decimal GetTotalAmount()
        {
            decimal totalAmt = 0;

            string sql = "HeaderId = '" + this.ADJId.ToString() + "'";
            InvtBatchADJ_DetailsCollection oDetails = InvtBatchADJ_Details.LoadCollection(sql);
            foreach (InvtBatchADJ_Details oDetail in oDetails)
            {
                totalAmt += oDetail.Qty * ModelEx.ProductEx.GetRetailPrice(oDetail.ProductId);
            }

            return totalAmt;
        }
        */
        #endregion

        #region Delete
            /**
        private void Delete()
        {
            InvtBatchADJ_Header oHeader = InvtBatchADJ_Header.Load(this.ADJId);
            if (oHeader != null)
            {
                string sql = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                DeleteDetails(sql);

                oHeader.Delete();
                // log activity
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, oHeader.ToString());

            }
        }

        private void DeleteDetails(string sql)
        {
            InvtBatchADJ_DetailsCollection oDetailList = InvtBatchADJ_Details.LoadCollection(sql);
            foreach (InvtBatchADJ_Details oDetail in oDetailList)
            {
                oDetail.Delete();
                // log activity
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
                    Save();

                    if (this.ADJId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        RT2020.Inventory.Adjustment.Wizard wizard = new RT2020.Inventory.Adjustment.Wizard(this.ADJId);
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
                    Save();

                    if (this.ADJId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        this.Close();
                        RT2020.Inventory.Adjustment.Wizard wizard = new RT2020.Inventory.Adjustment.Wizard();
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
                    Save();

                    if (this.ADJId != System.Guid.Empty)
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
                ModelEx.InvtBatchADJ_HeaderEx.DeleteChildToo(this.ADJId);   // Delete();

                this.Close();
            }
        }

        private void TabChangedMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.ADJId != System.Guid.Empty)
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Adjustment.Wizard wizard = new RT2020.Inventory.Adjustment.Wizard(this.ADJId);
                    wizard.ShowDialog();
                }
            }
            else
            {
                tabGoodsADJ.SelectedIndex = 0;
            }
        }
        #endregion

        #region ADJ Detail

        #region Bind ADJ Detail List
        private void BindADJDetailsInfo()
        {
            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" Qty, AverageCost, ISNULL(Remarks, '') AS Remarks, ReasonCode, ProductId ");
            sql.Append(" FROM vwADJDetailsList ");
            sql.Append(" WHERE HeaderId = '").Append(this.ADJId.ToString()).Append("'");
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
                    listItem.SubItems.Add(iCount.ToString()); // LineNumber
                    listItem.SubItems.Add(string.Empty); // Status
                    listItem.SubItems.Add(reader.GetString(2)); // STKCode
                    listItem.SubItems.Add(reader.GetString(3)); // Appendix1
                    listItem.SubItems.Add(reader.GetString(4)); // Appendix2
                    listItem.SubItems.Add(reader.GetString(5)); // Appendix3
                    listItem.SubItems.Add(reader.GetString(6)); // ProductName
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // Qty
                    listItem.SubItems.Add(GetOnHandQty((reader.GetGuid(11))).ToString("n0")); // On-Hand
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2")); // UnitPrice

                    decimal amt = reader.GetDecimal(7) * reader.GetDecimal(8);
                    listItem.SubItems.Add(amt.ToString("n2")); // Amount
                    listItem.SubItems.Add(string.IsNullOrEmpty(reader.GetString(9)) ? string.Empty : reader.GetString(9)); // Remarks
                    listItem.SubItems.Add(reader.GetGuid(11).ToString()); // ProductId

                    iCount++;
                }
            }

            lblLineCount.Text = (iCount - 1).ToString();
        }
        #endregion

        #region Save ADJ Detail Info
        /**
        private void SaveADJDetail()
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[13].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    InvtBatchADJ_Details oDetail = InvtBatchADJ_Details.Load(detailId);
                    if (oDetail == null)
                    {
                        oDetail = new InvtBatchADJ_Details();
                        oDetail.HeaderId = this.ADJId;
                        oDetail.TxNumber = txtTxNumber.Text;
                        oDetail.TxType = txtTxType.Text;
                        oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);
                    }
                    oDetail.ProductId = new Guid(listItem.SubItems[13].Text.Trim());
                    oDetail.Qty = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                    oDetail.AverageCost = Convert.ToDecimal(listItem.SubItems[10].Text.Length == 0 ? "0" : listItem.SubItems[10].Text);
                    oDetail.Remarks = listItem.SubItems[12].Text;

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

        #region Load ADJ Detail Info
        private void LoadADJDetailsInfo()
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvDetailsList.SelectedItem.Text))
                {
                    this.ValidSelection = true;

                    this.ADJDetailId = new Guid(lvDetailsList.SelectedItem.Text);
                    this.ProductId = new Guid(lvDetailsList.SelectedItem.SubItems[13].Text);

                    txtDescription.Text = lvDetailsList.SelectedItem.SubItems[7].Text;
                    txtQty.Text = lvDetailsList.SelectedItem.SubItems[8].Text;
                    txtAvgCost.Text = lvDetailsList.SelectedItem.SubItems[10].Text;
                    txtOnHand.Text = GetOnHandQty(this.ProductId).ToString("n0");
                    txtRemarks_Details.Text = lvDetailsList.SelectedItem.SubItems[12].Text;

                    basicFindProduct.SelectedItem = this.ProductId;
                    basicFindProduct.ResultList = SetDetailData(lvDetailsList.SelectedItem.SubItems[3].Text);
              
                    this.SelectedIndex = lvDetailsList.SelectedIndex;

                    this.ValidSelection = false;
                }
            }
        }
        #endregion

        private decimal GetOnHandQty(Guid productId)
        {
            /**
            decimal result = 0;

            String sql = String.Format("ProductId = '{0}' AND WorkplaceId = '{1}'", productId.ToString(), _WorkplaceId.ToString());
            DAL.ProductWorkplace oItem = DAL.ProductWorkplace.LoadWhere(sql);
            if (oItem != null)
            {
                result = oItem.CDQTY;
            }

            return result;
            */

            return ProductHelper.GetOnHandQtyByWorkplaceId(productId, _WorkplaceId);
        }

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

                if (isDuplicated)
                    break;
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
                    listItem.SubItems.Add(txtQty.Text.Length == 0 ? "0" : txtQty.Text); // Rej. Qty
                    listItem.SubItems.Add(txtOnHand.Text); // On-Hand
                    listItem.SubItems.Add(txtAvgCost.Text); // Average Cost

                    decimal qty = Convert.ToDecimal(txtQty.Text.Length == 0 ? "0" : txtQty.Text);
                    decimal unitPrice = Convert.ToDecimal(txtAvgCost.Text.Length == 0 ? "0" : txtAvgCost.Text);
                    decimal amt = qty * unitPrice;
                    listItem.SubItems.Add(amt.ToString("n2")); // Amount
                    listItem.SubItems.Add(txtRemarks_Details.Text); // Remarks
                    listItem.SubItems.Add(this.ProductId.ToString()); // ProductId

                    CalcTotal();
                }
            }
        }

        private void ItemInfo(ref string stkCode, ref string appendix1, ref string appendix2, ref string appendix3)
        {
            if (basicFindProduct.SelectedItem != null)
            {
                System.Guid prodId = Common.Utility.IsGUID(basicFindProduct.SelectedItem.ToString()) ? new System.Guid(basicFindProduct.SelectedItem.ToString()) : System.Guid.Empty;
                var oProd = ModelEx.ProductEx.Get(prodId);
                if (oProd != null)
                {
                    stkCode = oProd.STKCODE;
                    appendix1 = oProd.APPENDIX1;
                    appendix2 = oProd.APPENDIX2;
                    appendix3 = oProd.APPENDIX3;

                    txtOnHand.Text = ProductHelper.GetOnHandQtyByWorkplaceId(oProd.ProductId, (Guid)cboWorkplace.SelectedValue).ToString("n0");

                    this.ProductId = oProd.ProductId;
                }
            }
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
                ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

                ListViewItem listItem = lvDetailsList.SelectedItem;
                listItem.SubItems[2].Text = listItem.SubItems[2].Text != "NEW" ? "EDIT" : listItem.SubItems[2].Text; // Status
                listItem.SubItems[3].Text = stkCode; // Stock Code
                listItem.SubItems[4].Text = appendix1; // Appendix1
                listItem.SubItems[5].Text = appendix2; // Appendix2
                listItem.SubItems[6].Text = appendix3; // Appendix3
                listItem.SubItems[7].Text = txtDescription.Text; // Description
                listItem.SubItems[8].Text = txtQty.Text; // Qty
                listItem.SubItems[9].Text = txtOnHand.Text; // On-Hand
                listItem.SubItems[10].Text = txtAvgCost.Text; // Average Cost

                decimal qty = Convert.ToDecimal(txtQty.Text.Length == 0 ? "0" : txtQty.Text);
                decimal price = Convert.ToDecimal(txtAvgCost.Text.Length == 0 ? "0" : txtAvgCost.Text);
                decimal amt = qty * price;
                listItem.SubItems[11].Text = amt.ToString("n2"); // Amount
                listItem.SubItems[12].Text = txtRemarks_Details.Text; // Remarks
                listItem.SubItems[13].Text = this.ProductId.ToString(); // ProductId

                CalcTotal();
                basicFindProduct.ResultList = SetDetailData(stkCode);
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
                    ttlAmount += Convert.ToDecimal(listItem.SubItems[11].Text.Length > 0 ? listItem.SubItems[11].Text : "0");
                }
            }

            txtTotalQty.Text = ttlQty.ToString("n0");
            txtTotalAmount.Text = ttlAmount.ToString("n2");
        }
        #endregion

        private void lvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadADJDetailsInfo();
        }

        private void basicFindProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            if (!this.ValidSelection)
            {
                int iCount = 0;

                txtAvgCost.Text = e.AverageCost.ToString("n2");
                txtDescription.Text = e.Description;
                txtOnHand.Text = ProductHelper.GetOnHandQtyByWorkplaceId(e.ProductId, (Guid)cboWorkplace.SelectedValue).ToString("n0");

                foreach (ListViewItem lvItem in lvDetailsList.Items)
                {
                    lvItem.Selected = false;

                    if (lvItem.SubItems[13].Text == e.ProductId.ToString())
                    {
                        if (lvItem.Text != System.Guid.Empty.ToString() && Common.Utility.IsGUID(lvItem.Text))
                        {
                            if (iCount == 0)
                            {
                                txtQty.Text = lvItem.SubItems[8].Text;
                                txtRemarks_Details.Text = lvItem.SubItems[12].Text;

                                this.ProductId = e.ProductId;
                                this.ADJDetailId = new Guid(lvItem.Text);
                                this.SelectedIndex = lvItem.Index;

                                lvItem.Selected = true;
                            }

                            iCount++;
                        }
                    }
                }
            }
        }

        private void cboWorkplace_TextChanged(object sender, EventArgs e)
        {
            if (cboWorkplace.Text.Trim().Length > 0)
            {
                string wpCode = cboWorkplace.Text.Trim();
                if (wpCode.Length >= 4)
                {
                    if (!ModelEx.WorkplaceEx.IsWorkplaceCodeInUse(wpCode.Substring(0, 4)))
                    {
                        errorProvider.SetError(cboWorkplace, "Location code does exist!");
                    }
                    else
                    {
                        errorProvider.SetError(cboWorkplace, string.Empty);
                    }
                }
                else
                {
                    errorProvider.SetError(cboWorkplace, "Location code should be 4 digits!");
                }
            }
        }

        private void cboOperatorCode_TextChanged(object sender, EventArgs e)
        {
            if (cboOperatorCode.Text.Trim().Length > 0)
            {
                string staffNumber = cboOperatorCode.Text.Trim();
                if (staffNumber.Length >= 4)
                {
                    if (!ModelEx.StaffEx.IsStaffNumberInUse(staffNumber.Substring(0, 4)))
                    {
                        errorProvider.SetError(cboOperatorCode, "Operator code does exist!");
                    }
                    else
                    {
                        errorProvider.SetError(cboOperatorCode, string.Empty);
                    }
                }
                else
                {
                    errorProvider.SetError(cboOperatorCode, "Operator code should be 4 digits!");
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
                            if (lvItem.SubItems[13].Text == oProduct.ProductId.ToString() && lvItem.SubItems[2].Text != "REMOVED")
                            {
                                if (lvItem.SubItems[8].Text != detail.Qty.ToString("n0") || lvItem.SubItems[10].Text != detail.UnitAmount.ToString("n2"))
                                {
                                    lvItem.SubItems[2].Text = lvItem.SubItems[2].Text != "NEW" ? "EDIT" : lvItem.SubItems[2].Text; // Status
                                    lvItem.SubItems[8].Text = detail.Qty.ToString("n0"); // QTY
                                    lvItem.SubItems[10].Text = detail.UnitAmount.ToString("n2"); // Unit Amount
                                    lvItem.SubItems[11].Text = amt.ToString("n2"); // Amount
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
                        listItem.SubItems.Add(GetOnHandQty(detail.ProductId).ToString("n0")); // On-hand Qty
                        listItem.SubItems.Add(detail.UnitAmount.ToString("n2")); // Unit Amount
                        listItem.SubItems.Add(amt.ToString("n2")); // Amount
                        listItem.SubItems.Add(string.Empty); // remarks
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
                    Guid prodId = new Guid(lvItem.SubItems[13].Text);
                    decimal unitPrice = Convert.ToDecimal(Common.Utility.IsNumeric(lvItem.SubItems[10].Text.Trim()) ? lvItem.SubItems[10].Text.Trim() : "0"); 
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