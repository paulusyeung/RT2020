#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Common.Interfaces;

using RT2020.DAL;
using RT2020.Controls;
using System.Data.Entity;

#endregion

namespace RT2020.EmulatedPoS
{
    public partial class FastSalesWizard : Form
    {
        public RT2020.DAL.Common.Enums.TxType SalesType { get; set; }
        public DateTime FastTxDate { get; set; }
        public Guid FastWorkplaceId { get; set; }
        AnalysisCode oAnalysisCode;

        /// <summary>
        /// Initializes a new instance of the <see cref="FastSalesWizard"/> class.
        /// </summary>
        /// <param name="txDate">The tx date.</param>
        /// <param name="workplaceId">The workplace id.</param>
        /// <param name="salesType">Type of the sales.</param>
        public FastSalesWizard(DateTime txDate, Guid workplaceId, RT2020.DAL.Common.Enums.TxType salesType)
        {
            InitializeComponent();

            oAnalysisCode = new AnalysisCode();
            oAnalysisCode.Left = (panel4.Width - oAnalysisCode.Width) / 2;
            panel4.Controls.Add(oAnalysisCode);
            oAnalysisCode.BringToFront();
            oAnalysisCode.Visible = false;            

            this.FastWorkplaceId = workplaceId;
            this.FastTxDate = txDate;
            this.SalesType = salesType;

            InitHeaderInfo(this.FastTxDate, this.FastWorkplaceId);
            LoadPosBatchTenderInfo();
            SetToolBar();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="FastSalesWizard"/> class.
        /// </summary>
        /// <param name="headerId">The header id.</param>
        /// <param name="salesType">Type of the sales.</param>
        public FastSalesWizard(Guid headerId, RT2020.DAL.Common.Enums.TxType salesType)
        {
            InitializeComponent();

            oAnalysisCode = new AnalysisCode();
            oAnalysisCode.Left = (panel4.Width - oAnalysisCode.Width) / 2;
            panel4.Controls.Add(oAnalysisCode);
            oAnalysisCode.BringToFront();
            oAnalysisCode.Visible = false;

            this.HeaderId = headerId;
            this.SalesType = salesType;

            FillCboList();
            LoadPOSBatchInfo();
            LoadPosBatchTenderInfo();
            SetToolBar();
            InitCurrency(cboCurrencyCode.Text);

            cboCurrencyCode.Text = "HKD";
        }

        /// <summary>
        /// Handles the Load event of the FastSalesWizard control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void FastSalesWizard_Load(object sender, EventArgs e)
        {
            FormatDate();
        }

        #region Properties
        private Guid headerId = System.Guid.Empty;
        /// <summary>
        /// Gets or sets the POS id.
        /// </summary>
        /// <value>The POS id.</value>
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

        private Guid productId = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
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
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

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

            if (HeaderId == System.Guid.Empty)
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
        /// <summary>
        /// Binds the data.
        /// </summary>
        /// <returns></returns>
        private DataTable BindData()
        {
            string sql = @" SELECT TOP 100 PERCENT *
                            FROM vwRptEPOSWorksheet
                            WHERE	TxNumber BETWEEN '" + this.txtTxNumber.Text.Trim() + @"' AND '" + this.txtTxNumber.Text.Trim() + @"' 
                              AND CONVERT(VARCHAR(10), TxDate, 126) BETWEEN '" + txtDate.Tag.ToString() + @"' 
                                                                        AND '" + txtDate.Tag.ToString() + @"' 
                              AND TxType = '" + this.SalesType.ToString() + @"' 
                            ORDER BY TxNumber, TxDate
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

        /// <summary>
        /// CMDs the preview_ click.
        /// </summary>
        private void cmdPreview_Click()
        {
            string title = "";
            if (this.SalesType == Common.Enums.TxType.CAS)
            {
                title = "Sales Input Worksheet";
            }
            else
            {
                title = "Sales Return Worksheet";
            }
            string[,] param = { 
                                  {"CompanyName", RT2020.SystemInfo.CurrentInfo.Default.CompanyName},
                                  {"WorksheetTitle",title},
                                  {"PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                                  {"FromTRN",txtTxNumber.Text.Trim()},
                                  {"ToTRN",txtTxNumber.Text.Trim()},
                                  {"FromDate",txtDate.Text},
                                  {"ToDate",txtDate.Text},
                                  {"CLASS1",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1")},
                                  {"CLASS2",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS2")},
                                  {"CLASS3",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS3")},
                                  {"CLASS4",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS4")},
                                  {"CLASS5",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS5")},
                                  {"CLASS6",RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS6")},
                              };
            RT2020.Controls.Reporting.Viewer oViewer = new RT2020.Controls.Reporting.Viewer();

            oViewer.Datasource = BindData();
            oViewer.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptEPOSWorksheet";
            oViewer.ReportName = "RT2020.EmulatedPoS.Reports.WorksheetRdl.rdlc";
            oViewer.Parameters = param;

            oViewer.Show();
        }
        #endregion

        #region Fill Combo List
        /// <summary>
        /// Fills the cbo list.
        /// </summary>
        private void FillCboList()
        {
            FillLocationList();
            FillStaff1List();
            FillStaff2List();
            FillEventCodeList();
            FillCurrencyCodeList();
            FillPriceTypeList();
            FillVipList();
        }

        /// <summary>
        /// Fills the location list.
        /// </summary>
        private void FillLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboWorkplace, "WorkplaceCode", false);
        }

        /// <summary>
        /// Fills the staff1 list.
        /// </summary>
        private void FillStaff1List()
        {
            ModelEx.StaffEx.LoadCombo(ref cboStaff1,"StaffNumber", false);

            cboStaff1.SelectedValue = Common.Config.CurrentUserId;
        }

        /// <summary>
        /// Fills the staff2 list.
        /// </summary>
        private void FillStaff2List()
        {
            ModelEx.StaffEx.LoadCombo(ref cboStaff2, "StaffNumber", false);
        }

        /// <summary>
        /// Fills the event code list.
        /// </summary>
        private void FillEventCodeList()
        {
            ModelEx.PromotionPaymentFactorEx.LoadCombo(ref cboEvtCode, "EventCode", false);
        }

        /// <summary>
        /// Fills the currency code list.
        /// </summary>
        private void FillCurrencyCodeList()
        {
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrencyCode, "CurrencyCode", false);

            if (cboCurrencyCode.Items.Count > 0)
            {
                cboCurrencyCode.Text = SystemInfo.CurrentInfo.Default.SysInfo.BasicCurrency;

                InitCurrency(cboCurrencyCode.Text);
            }
        }

        /// <summary>
        /// Fills the price type list.
        /// </summary>
        private void FillPriceTypeList()
        {
            ModelEx.ProductPriceTypeEx.LoadCombo(ref cboPriceType, "PriceType", false);
        }

        /// <summary>
        /// Fills the vip list.
        /// </summary>
        private void FillVipList()
        {
            RT2020.DAL.Member.LoadCombo(ref cboMemberNumber, "MemberNumber", false);
        }
        #endregion

        #region Init Currency
        /// <summary>
        /// Inits the currency.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        private void InitCurrency(string currencyCode)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oCny = ctx.Currency.Where(x => x.CurrencyCode == currencyCode).FirstOrDefault();
                if (oCny != null)
                {
                    InitCurrency(oCny.CurrencyId);
                }
                else
                {
                    InitCurrency(Common.Utility.IsGUID(cboCurrencyCode.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(cboCurrencyCode.SelectedValue.ToString()));
                }
            }
        }

        /// <summary>
        /// Inits the currency.
        /// </summary>
        /// <param name="selectedCurrency">The selected currency.</param>
        private void InitCurrency(Guid selectedCurrency)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oCny = ctx.Currency.Find(selectedCurrency);
                if (oCny != null) txtExchangeRate.Text = oCny.ExchangeRate.Value.ToString("n4");
            }
        }
        #endregion

        #region Init Header Info
        /// <summary>
        /// Inits the header info.
        /// </summary>
        /// <param name="txDate">The tx date.</param>
        /// <param name="workplaceId">The workplace id.</param>
        private void InitHeaderInfo(DateTime txDate, Guid workplaceId)
        {
            FillCboList();

            txtDate.Text = txDate.ToString(RT2020.SystemInfo.Settings.GetDateFormat());
            cboWorkplace.SelectedValue = workplaceId;

            txtTxNumber.Text = "Auto-Generated";
            cboStatus.Text = "HOLD";
            cboCurrencyCode.Text = "HKD";
            InitCurrency(cboCurrencyCode.Text);
            cboPriceType.Text = "BASPRC";
            txtTxType.Text = this.SalesType.ToString();

            txtLastUpdateOn.Text = DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat());
            txtLastUpdateBy.Text =  ModelEx.StaffEx.GetStaffNumberById(Common.Config.CurrentUserId);
            txtCreateDate.Text = DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat());
        }

        /// <summary>
        /// Gets the total required qty.
        /// </summary>
        /// <returns></returns>
        private decimal GetTotalRequiredQty()
        {
            decimal totalQty = 0;

            string sql = "HeaderId = '" + this.HeaderId.ToString() + "'";
            EPOSBatchDetailsCollection oDetails = EPOSBatchDetails.LoadCollection(sql);
            foreach (EPOSBatchDetails oDetail in oDetails)
            {
                totalQty += oDetail.Qty;
            }

            return totalQty;
        }
        #endregion

        #region Save POS Batch Header Info
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            if (errorProvider.GetError(cboWorkplace).Length == 0 && errorProvider.GetError(cboStaff1).Length == 0 )
            {
                if (lvDetailsList.Items.Count > 0)
                {
                    EPOSBatchHeader oHeader = EPOSBatchHeader.Load(this.HeaderId);
                    if (oHeader == null)
                    {
                        oHeader = new EPOSBatchHeader();

                        txtTxNumber.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(this.SalesType);
                        oHeader.TxNumber = txtTxNumber.Text;
                        oHeader.TxType = this.SalesType.ToString();

                        oHeader.CreatedBy = Common.Config.CurrentUserId;
                        oHeader.CreatedOn = DateTime.Now;
                    }
                    oHeader.TxDate = Convert.ToDateTime(txtDate.Tag.ToString());
                    oHeader.Status = Convert.ToInt32(cboStatus.Text == "HOLD" ? Common.Enums.Status.Draft.ToString("d") : Common.Enums.Status.Active.ToString("d"));

                    //oHeader.DepositAmount = Convert.ToDecimal(txtDepositAmount.Text.Length == 0 ? "0" : txtDepositAmount.Text);
                    oHeader.Reference = txtDepositAmount.Text;

                    oHeader.PRICE_TYPE = cboPriceType.SelectedValue.ToString();
                    oHeader.WorkplaceId = new Guid(cboWorkplace.SelectedValue.ToString());
                    oHeader.StaffId = new Guid(cboStaff1.SelectedValue.ToString());
                    oHeader.Staff1 = oHeader.StaffId;
                    oHeader.Staff2 = new Guid(cboStaff2.SelectedValue.ToString());
                    oHeader.EVT_CODE = cboEvtCode.Text;
                    oHeader.CurrencyCode = cboCurrencyCode.Text;
                    oHeader.ExchangeRate = Convert.ToDecimal(txtExchangeRate.Text.Length == 0 ? "0" : txtExchangeRate.Text);

                    oHeader.MemberId = new Guid(cboMemberNumber.SelectedValue.ToString());

                    oHeader.ANALYSIS_CODE01 = oAnalysisCode.AnalysisCode01;
                    oHeader.ANALYSIS_CODE02 = oAnalysisCode.AnalysisCode02;
                    oHeader.ANALYSIS_CODE03 = oAnalysisCode.AnalysisCode03;
                    oHeader.ANALYSIS_CODE04 = oAnalysisCode.AnalysisCode04;
                    oHeader.ANALYSIS_CODE05 = oAnalysisCode.AnalysisCode05;
                    oHeader.ANALYSIS_CODE06 = oAnalysisCode.AnalysisCode06;
                    oHeader.ANALYSIS_CODE07 = oAnalysisCode.AnalysisCode07;
                    oHeader.ANALYSIS_CODE08 = oAnalysisCode.AnalysisCode08;
                    oHeader.ANALYSIS_CODE09 = oAnalysisCode.AnalysisCode09;
                    oHeader.ANALYSIS_CODE10 = oAnalysisCode.AnalysisCode10;

                    oHeader.ModifiedBy = Common.Config.CurrentUserId;
                    oHeader.ModifiedOn = DateTime.Now;

                    oHeader.Save();

                    this.HeaderId = oHeader.HeaderId;

                    SavePOSBatchDetail();
                    SavePosBatchTender();
                    UpdateHeaderInfo();
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

        /// <summary>
        /// Updates the header info.
        /// </summary>
        private void UpdateHeaderInfo()
        {
            EPOSBatchHeader oHeader = EPOSBatchHeader.Load(this.HeaderId);
            if (oHeader != null)
            {
                oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text.Trim() : "0");

                oHeader.Save();
            }
        }
        #endregion

        #region Load POS Batch Header Info
        /// <summary>
        /// Loads the POS batch info.
        /// </summary>
        private void LoadPOSBatchInfo()
        {
            EPOSBatchHeader oHeader = EPOSBatchHeader.Load(this.HeaderId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;
                txtTxType.Text = oHeader.TxType;

                cboWorkplace.SelectedValue = oHeader.WorkplaceId;
                cboStaff1.SelectedValue = oHeader.StaffId;
                cboStaff2.SelectedValue = oHeader.Staff2;
                cboStatus.Text = (oHeader.Status == 0) ? "HOLD" : "POST";
                cboMemberNumber.SelectedValue = oHeader.MemberId;

                txtDate.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.TxDate,false);

                txtDepositAmount.Text = oHeader.DepositAmount.ToString();
                cboEvtCode.Text = oHeader.EVT_CODE;
                cboCurrencyCode.Text = oHeader.CurrencyCode;
                txtExchangeRate.Text = oHeader.ExchangeRate.ToString();

                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE01, "01");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE02, "02");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE03, "03");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE04, "04");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE05, "05");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE06, "06");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE07, "07");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE08, "08");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE09, "09");
                oAnalysisCode.SetAnalysisCode(oHeader.ANALYSIS_CODE10, "10");
                
                txtLastUpdateOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.ModifiedOn, false);
                txtLastUpdateBy.Text = ModelEx.StaffEx.GetStaffNumberById(oHeader.ModifiedBy);
                txtCreateDate.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.CreatedOn, false);

                txtTotalQty.Text = GetTotalRequiredQty().ToString("n0");
                txtTotalAmount.Text = oHeader.TotalAmount.ToString("n2");
                txtTotalAmt.Text = oHeader.TotalAmount.ToString("n2");

                BindPOSBatchDetailsInfo();

            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        private void Delete()
        {
            EPOSBatchHeader oHeader = EPOSBatchHeader.Load(this.HeaderId);
            if (oHeader != null)
            {
                string sql = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                DeleteDetails(sql);
                DeleteTenders(sql);

                oHeader.Delete();
            }
        }

        /// <summary>
        /// Deletes the details.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        private void DeleteDetails(string sql)
        {
            EPOSBatchDetailsCollection oDetailList = EPOSBatchDetails.LoadCollection(sql);
            foreach (EPOSBatchDetails oDetail in oDetailList)
            {
                oDetail.Delete();
            }
        }

        /// <summary>
        /// Deletes the tenders.
        /// </summary>
        /// <param name="sql">The SQL.</param>
        private void DeleteTenders(string sql)
        {
            EPOSBatchTenderCollection oTenderList = EPOSBatchTender.LoadCollection(sql);
            foreach (EPOSBatchTender oTender in oTenderList)
            {
                oTender.Delete();
            }
        }
        #endregion

        #region Message Handler

        /// <summary>
        /// Checks the input info.
        /// </summary>
        /// <returns></returns>
        private bool CheckInputInfo()
        {
            if (lvDetailsList.Items.Count < 1)
            {
                MessageBox.Show("Detail Entry is not null", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (oAnalysisCode.AnalysisCode01 == "" || oAnalysisCode.AnalysisCode01 == string.Empty || oAnalysisCode.AnalysisCode01 == null)
            {
                MessageBox.Show("Bill must be checked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (Convert.ToDecimal(txtTotalChange.Text) < 0)
            {
                MessageBox.Show("Total Amount != Total Pay", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
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
                if (!CheckInputInfo())
                {
                    return;
                }
                if (!this.Text.Contains("ReadOnly"))
                {
                    Save();

                    if (this.HeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        RT2020.EmulatedPoS.FastSalesWizard wizard = new RT2020.EmulatedPoS.FastSalesWizard(this.HeaderId, this.SalesType);
                        wizard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (!CheckInputInfo())
                {
                    return;
                }
                if (!this.Text.Contains("ReadOnly"))
                {
                    Save();

                    if (this.HeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        this.Close();
                        RT2020.EmulatedPoS.FastModeLogin login = new RT2020.EmulatedPoS.FastModeLogin();
                        login.Closed += new EventHandler(login_Closed);
                        login.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        /// <summary>
        /// Handles the Closed event of the login control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void login_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                FastModeLogin fast = sender as FastModeLogin;

                FastSalesWizard wizFastSalesInput = new FastSalesWizard(fast.TxDate, fast.WorkplaceId, Common.Enums.TxType.CAS);
                wizFastSalesInput.ShowDialog();
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
                if (!CheckInputInfo())
                {
                    return;
                }
                if (!this.Text.Contains("ReadOnly"))
                {
                    Save();

                    if (this.HeaderId != System.Guid.Empty)
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

        /// <summary>
        /// Deletes the confirmation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                this.Close();
            }
        }

        /// <summary>
        /// Tabs the changed message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TabChangedMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (!CheckInputInfo())
                {
                    return;
                }
                Save();

                if (this.HeaderId != System.Guid.Empty)
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Adjustment.Wizard wizard = new RT2020.Inventory.Adjustment.Wizard(this.HeaderId);
                    wizard.ShowDialog();
                }
            }
        }
        #endregion

        #region POS Batch Detail

        #region Bind POS Batch Detail List
        /// <summary>
        /// Binds the POS batch details info.
        /// </summary>
        private void BindPOSBatchDetailsInfo()
        {
            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" UnitAmount, UAMT_FCURR, Qty, Discount, ProductId, COUPONNO, SERIALNO, VITEM, BARCODE ");
            sql.Append(" FROM vwEPosBatchDetailList ");
            sql.Append(" WHERE HeaderId = '").Append(this.HeaderId.ToString()).Append("'");
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
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n2")); // UnitAmount
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2")); // UAMT_FCURR
                    listItem.SubItems.Add(reader.GetDecimal(9).ToString("n0")); // Qty
                    listItem.SubItems.Add(reader.GetDecimal(10).ToString("n2")); // Disc

                    decimal totalAmt = reader.GetDecimal(7) * reader.GetDecimal(9) * (1 - reader.GetDecimal(10) / 100);
                    listItem.SubItems.Add(totalAmt.ToString("n2")); // Total
                    totalAmt = reader.GetDecimal(8) * reader.GetDecimal(9) * (1 - reader.GetDecimal(10) / 100);
                    listItem.SubItems.Add(totalAmt.ToString("n2")); // Total
                    listItem.SubItems.Add(string.IsNullOrEmpty(reader.GetString(15)) ? string.Empty : reader.GetString(15)); // Barcode
                    listItem.SubItems.Add(string.IsNullOrEmpty(reader.GetString(12)) ? string.Empty : reader.GetString(12)); // Coupon
                    listItem.SubItems.Add(string.IsNullOrEmpty(reader.GetString(13)) ? string.Empty : reader.GetString(13)); // Serial
                    listItem.SubItems.Add(string.IsNullOrEmpty(reader.GetString(14)) ? string.Empty : reader.GetString(14)); // VItem
                    listItem.SubItems.Add(reader.GetGuid(11).ToString()); // ProductId

                    iCount++;
                }
            }

            lblLineCount.Text = (iCount - 1).ToString();
        }
        #endregion

        #region Save POS Batch Detail Info
        /// <summary>
        /// Saves the POS batch detail.
        /// </summary>
        private void SavePOSBatchDetail()
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[18].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    EPOSBatchDetails oDetail = EPOSBatchDetails.Load(detailId);
                    if (oDetail == null)
                    {
                        oDetail = new EPOSBatchDetails();
                        oDetail.HeaderId = this.HeaderId;
                        oDetail.TxNumber = txtTxNumber.Text;
                        oDetail.TxType = txtTxType.Text;
                        oDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);
                    }
                    oDetail.SHOP = cboWorkplace.Text;
                    oDetail.TxDate = Convert.ToDateTime(txtDate.Tag.ToString());
                    oDetail.ProductId = new Guid(listItem.SubItems[18].Text.Trim());
                    oDetail.Qty = Convert.ToDecimal(listItem.SubItems[10].Text.Length == 0 ? "0" : listItem.SubItems[10].Text);
                    oDetail.Discount = Convert.ToDecimal(listItem.SubItems[11].Text.Length == 0 ? "0" : listItem.SubItems[11].Text);
                    oDetail.UnitAmount = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                    oDetail.UAMT_FCURR = oDetail.UnitAmount;
                    oDetail.Amount = (oDetail.Qty * oDetail.UnitAmount) * (100 - oDetail.Discount) * Convert.ToDecimal(0.01);
                    oDetail.AMOUNT_FCURR = oDetail.Amount;
                    oDetail.BARCODE = listItem.SubItems[14].Text;
                    oDetail.COUPONNO = listItem.SubItems[15].Text;
                    oDetail.SERIALNO = listItem.SubItems[16].Text;
                    oDetail.VITEM = listItem.SubItems[17].Text;
                    
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
        #endregion

        #region Load POS Batch Detail Info
        /// <summary>
        /// Loads the POS batch details info.
        /// </summary>
        /// <param name="detailId">The detail id.</param>
        private void LoadPOSBatchDetailsInfo(Guid detailId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" UnitAmount, UAMT_FCURR, Qty, Discount, ProductId, COUPONNO, SERIALNO, VITEM, BARCODE ");
            sql.Append(" FROM vwEPosBatchDetailList ");
            sql.Append(" WHERE DetailsId = '").Append(detailId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    SetStockCode(reader);

                    txtDescription.Text = reader.GetString(6);
                    txtUnitAmount.Text = reader.GetDecimal(7).ToString("n2");
                    txtQty.Text = reader.GetDecimal(9).ToString("n0");
                    txtDiscount.Text = reader.GetDecimal(10).ToString("n2");
                    txtBarcode.Text = reader.GetString(15);

                    basicFindProduct.SelectedItem = reader.GetGuid(11);
                    this.ProductId = reader.GetGuid(11);
                }
            }
        }
        /// <summary>
        /// Sets the stock code.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void SetStockCode(SqlDataReader reader)
        {
            basicFindProduct.SelectedText = reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5);
            basicFindProduct.SelectedItem = reader.GetGuid(11);
        }
        #endregion

        #endregion

        #region POS Batch Tender

        #region Load POS Batch Tender Info
        /// <summary>
        /// Loads the pos batch tender info.
        /// </summary>
        private void LoadPosBatchTenderInfo()
        {
            if (this.HeaderId == System.Guid.Empty)
            {
                for (int i = 0; i < 5; i++)
                {
                    lvPaymentItems.Items.Add("");
                }
            }
            else
            {
                int count = 0;

                using (var ctx = new EF6.RT2020Entities())
                {
                    string sqlWhere = "HeaderId='" + this.HeaderId + "'";
                    var posTenderCollection = ctx.EPOSBatchTender.Where(x => x.HeaderId == this.HeaderId).AsNoTracking().ToList();
                    foreach (var posTender in posTenderCollection)
                    {
                        string typeCode;
                        var posType = ctx.PosTenderType.Where(x => x.TypeId == posTender.TypeId).AsNoTracking().FirstOrDefault();
                        typeCode = posType.TypeCode;

                        ListViewItem item = new ListViewItem(posTender.TenderId.ToString());
                        item.SubItems.Add(posTender.TypeId.ToString());
                        item.SubItems.Add(typeCode);
                        item.SubItems.Add(posTender.TenderAmount.ToString());
                        item.SubItems.Add(posTender.CardNumber);
                        item.SubItems.Add(posTender.AuthorizationCode);
                        item.SubItems.Add(posTender.CurrencyCode);
                        item.SubItems.Add(posTender.ExchangeRate.ToString());
                        item.SubItems.Add(posTender.InLocalCurrency.ToString());

                        lvPaymentItems.Items.Add(item);
                        count++;
                    }
                    if (count < 5)
                    {
                        for (int i = 0; i < 5 - count; i++)
                        {
                            lvPaymentItems.Items.Add("");
                        }
                    }
                }

                CalculateTotalPay();
            }
        }
        #endregion

        #region Save POS Batch Tender Info
        /// <summary>
        /// Saves the pos batch tender.
        /// </summary>
        private void SavePosBatchTender()
        {
            foreach (ListViewItem listItem in lvPaymentItems.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text.Trim()))
                {
                    System.Guid tenderId = new Guid(listItem.Text.Trim());
                    EPOSBatchTender oTender = EPOSBatchTender.Load(tenderId);
                    if (oTender == null)
                    {
                        oTender = new EPOSBatchTender();
                        oTender.HeaderId = this.HeaderId;
                        oTender.TxNumber = txtTxNumber.Text;
                        oTender.TxType = txtTxType.Text;
                    }
                    oTender.TxDate = Convert.ToDateTime(txtDate.Tag.ToString());
                    oTender.TypeId = new Guid(listItem.SubItems[1].Text.Trim());
                    oTender.CurrencyCode = listItem.SubItems[6].Text.Trim();
                    oTender.CardNumber = listItem.SubItems[4].Text.Trim();
                    oTender.AuthorizationCode = listItem.SubItems[5].Text.Trim();
                    oTender.TenderAmount = Convert.ToDecimal(listItem.SubItems[3].Text.Length == 0 ? "0" : listItem.SubItems[3].Text);
                    oTender.ExchangeRate = Convert.ToDecimal(listItem.SubItems[7].Text.Length == 0 ? "0" : listItem.SubItems[7].Text);
                    oTender.InLocalCurrency = Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);

                    oTender.Save();
                }
            }
        }
        #endregion 

        #endregion

        /// <summary>
        /// Handles the SelectionChanged event of the basicFindProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs"/> instance containing the event data.</param>
        private void basicFindProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            txtDiscount.Text = e.Discount.ToString("n2");
            txtUnitAmount.Text = e.UnitPrice.ToString("n2");
            txtDescription.Text = e.Description;

            SearchProductBarcode(e.ProductId);
        }

        /// <summary>
        /// Searches the product barcode.
        /// </summary>
        /// <param name="productId">The product id.</param>
        private void SearchProductBarcode(Guid productId)
        {
            /**
            string sqlWhere = "ProductId = '" + productId.ToString() + "' AND PrimaryBarcode = 1";
            RT2020.DAL.ProductBarcode productBarcode = RT2020.DAL.ProductBarcode.LoadWhere(sqlWhere);
            if (productBarcode != null)
            {
                txtBarcode.Tag = productBarcode.Barcode;
            }
            */
            txtBarcode.Tag = ModelEx.ProductBarcodeEx.GetBarcodeByProductId(productId);
        }

        #region Add/Edit/Remove Item
        /// <summary>
        /// Determines whether the specified STK code is duplicated.
        /// </summary>
        /// <param name="stkCode">The STK code.</param>
        /// <param name="appendix1">The appendix1.</param>
        /// <param name="appendix2">The appendix2.</param>
        /// <param name="appendix3">The appendix3.</param>
        /// <returns>
        /// 	<c>true</c> if the specified STK code is duplicated; otherwise, <c>false</c>.
        /// </returns>
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

        /// <summary>
        /// Handles the Click event of the btnAddEditItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAddEditItem_Click(object sender, EventArgs e)
        {
            string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);
            if (lvDetailsList.SelectedItem != null)
            {
                ListViewItem listItem = lvDetailsList.SelectedItem;
                listItem.SubItems[2].Text = listItem.SubItems[2].Text != "NEW" ? "EDIT" : listItem.SubItems[2].Text; // Status
                listItem.SubItems[3].Text = stkCode; // Stock Code
                listItem.SubItems[4].Text = appendix1; // Appendix1
                listItem.SubItems[5].Text = appendix2; // Appendix2
                listItem.SubItems[6].Text = appendix3; // Appendix3
                listItem.SubItems[7].Text = txtDescription.Text; // Description
                listItem.SubItems[8].Text = txtUnitAmount.Text; // Amount
                listItem.SubItems[9].Text = txtUnitAmount.Text;// Amount_Fcurr
                listItem.SubItems[10].Text = txtQty.Text; // Qty
                listItem.SubItems[11].Text = txtDiscount.Text; // Average Cost

                decimal qty = Convert.ToDecimal(txtQty.Text.Length == 0 ? "0" : txtQty.Text);
                decimal price = Convert.ToDecimal(txtDiscount.Text.Length == 0 ? "0" : txtDiscount.Text);
                decimal amt = Convert.ToDecimal(txtUnitAmount.Text.Length == 0 ? "0" : txtUnitAmount.Text);
                decimal totalAmt = qty * amt * (1 - price / 100);
                listItem.SubItems[12].Text = totalAmt.ToString("n2"); // totalAmount
                listItem.SubItems[13].Text = totalAmt.ToString("n2"); // totalAmount
                listItem.SubItems[14].Text = txtBarcode.Tag.ToString(); // Barcode
                listItem.SubItems[15].Text = string.Empty;// Coupon
                listItem.SubItems[16].Text = string.Empty;// Serial
                listItem.SubItems[17].Text = string.Empty;   // Vendor Item
                listItem.SubItems[18].Text = this.ProductId.ToString(); // ProductId

                CalcTotal();
            }
            else
            {
                if (IsDuplicated(stkCode, appendix1, appendix2, appendix3))
                {
                    //this.Invoke(new EventHandler(btnEditItem_Click), new object[] { this, e });
                    MessageBox.Show(string.Format(Resources.Common.DuplicatedCode, "Stock Item"), string.Format(Resources.Common.DuplicatedCode, string.Empty));
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
                    listItem.SubItems.Add(txtDescription.Text); // Description
                    listItem.SubItems.Add(txtUnitAmount.Text.Length == 0 ? "0" : txtUnitAmount.Text); // UnitAmount
                    listItem.SubItems.Add(txtUnitAmount.Text.Length == 0 ? "0" : txtUnitAmount.Text); // UnitAmount_Fcurr
                    listItem.SubItems.Add(txtQty.Text.Length == 0 ? "0" : txtQty.Text); // Rej. Qty
                    listItem.SubItems.Add(txtDiscount.Text); // Average Cost

                    decimal qty = Convert.ToDecimal(txtQty.Text.Length == 0 ? "0" : txtQty.Text);
                    decimal amt = Convert.ToDecimal(txtUnitAmount.Text.Length == 0 ? "0" : txtUnitAmount.Text);
                    decimal disc = Convert.ToDecimal(txtDiscount.Text.Length == 0 ? "0" : txtDiscount.Text);
                    decimal totalAmt = qty * amt * (1 - disc / 100);
                    listItem.SubItems.Add(totalAmt.ToString("n2")); // Total
                    listItem.SubItems.Add(totalAmt.ToString("n2")); // Total(HKD)
                    listItem.SubItems.Add(txtBarcode.Tag.ToString()); // Barcode
                    listItem.SubItems.Add(string.Empty);// Coupon
                    listItem.SubItems.Add(string.Empty);// Serial
                    listItem.SubItems.Add(string.Empty);   // Vendor Item
                    listItem.SubItems.Add(this.ProductId.ToString()); // ProductId

                    CalcTotal();
                }
            }

            ClearDetailsInfo();
        }
        
        /// <summary>
        /// Items the info.
        /// </summary>
        /// <param name="stkCode">The STK code.</param>
        /// <param name="appendix1">The appendix1.</param>
        /// <param name="appendix2">The appendix2.</param>
        /// <param name="appendix3">The appendix3.</param>
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

                    //txtOnHand.Text = Utility.GetOnHandQtyByWorkplaceId(oProd.ProductId, "'" + cboWorkplace.SelectedValue.ToString() + "'").ToString("n0");

                    this.ProductId = oProd.ProductId;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
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

        /// <summary>
        /// Calcs the total.
        /// </summary>
        private void CalcTotal()
        {
            decimal ttlQty = 0, ttlAmount = 0;
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (listItem.SubItems[2].Text != "REMOVED")
                {
                    ttlQty += Convert.ToDecimal(listItem.SubItems[10].Text.Length > 0 ? listItem.SubItems[10].Text : "0");
                    ttlAmount += Convert.ToDecimal(listItem.SubItems[12].Text.Length > 0 ? listItem.SubItems[12].Text : "0");
                }
            }

            txtTotalQty.Text = ttlQty.ToString("n0");
            txtTotalAmount.Text = ttlAmount.ToString("n2");
            txtTotalAmt.Text = txtTotalAmount.Text;

            InitPaymentItems(ttlAmount);
        }

        /// <summary>
        /// Clears the details info.
        /// </summary>
        private void ClearDetailsInfo()
        {
            lvDetailsList.SelectedIndex = -1;

            basicFindProduct.SelectedText = "";
            txtDescription.Text = "";
            txtQty.Text = "1";
            txtUnitAmount.Text = "0";
            txtDiscount.Text = "0";

            txtBarcode.Text = "";
        }

        #endregion
        
        #region Add/Edit Payment Items
        /// <summary>
        /// Inits the payment items.
        /// </summary>
        /// <param name="amount">The amount.</param>
        private void InitPaymentItems(decimal amount)
        {
            //string sqlWhere = "TypeCode = 'CASH' AND CurrencyCode = 'HKD'";
            var posTenderType = ModelEx.PosTenderTypeEx.Get("CASH", "HKD");

            if (lvPaymentItems.Items[0].SubItems.Count <= 1)
            {
                lvPaymentItems.Items[0].Text = System.Guid.Empty.ToString();
                lvPaymentItems.Items[0].SubItems.Add(posTenderType.TypeId.ToString());
                lvPaymentItems.Items[0].SubItems.Add(posTenderType.TypeCode);
                lvPaymentItems.Items[0].SubItems.Add(amount.ToString());
                lvPaymentItems.Items[0].SubItems.Add("");
                lvPaymentItems.Items[0].SubItems.Add("");
                lvPaymentItems.Items[0].SubItems.Add(posTenderType.CurrencyCode);
                lvPaymentItems.Items[0].SubItems.Add(posTenderType.ExchangeRate.ToString());
                lvPaymentItems.Items[0].SubItems.Add(amount.ToString());
            }
            else
            {
                decimal ttlAmt = 0;
                int cnt = 0;
                int idx = 0;
                foreach (ListViewItem listItem in lvPaymentItems.Items)
                {
                    if (listItem.SubItems.Count > 1)
                    {
                        if (listItem.SubItems[2].Text != "CASH")
                        {
                            ttlAmt += Convert.ToDecimal(listItem.SubItems[3].Text.Length > 0 ? listItem.SubItems[3].Text : "0");
                        }
                        else
                        {
                            idx = cnt;
                        }
                        cnt ++;
                    }
                }
                lvPaymentItems.Items[idx].SubItems[1].Text = posTenderType.TypeId.ToString();
                lvPaymentItems.Items[idx].SubItems[2].Text = posTenderType.TypeCode;
                lvPaymentItems.Items[idx].SubItems[3].Text = (amount - ttlAmt).ToString();
                lvPaymentItems.Items[idx].SubItems[4].Text = "";
                lvPaymentItems.Items[idx].SubItems[5].Text = "";
                lvPaymentItems.Items[idx].SubItems[6].Text = posTenderType.CurrencyCode;
                lvPaymentItems.Items[idx].SubItems[7].Text = posTenderType.ExchangeRate.ToString();
                lvPaymentItems.Items[idx].SubItems[8].Text = (amount - ttlAmt).ToString();
            }

            CalculateTotalPay();
        }

        /// <summary>
        /// Handles the DoubleClick event of the lvPaymentItems control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvPaymentItems_DoubleClick(object sender, EventArgs e)
        {
            AddEditPaymentItems();
        }

        /// <summary>
        /// Adds or edit payment items.
        /// </summary>
        private void AddEditPaymentItems()
        {
            AmendPaymentItem apItem = new AmendPaymentItem();
            apItem.Closed += new EventHandler(apItem_Closed);
            string typeCode = "", currencyCode = "", amount = "", exchangeRate = "", amtHkd = "", card = "", authorize = "";
            if (lvPaymentItems.SelectedItem.Text != "")
            {
                typeCode = lvPaymentItems.SelectedItem.SubItems[2].Text;
                currencyCode = lvPaymentItems.SelectedItem.SubItems[6].Text;
                amount = lvPaymentItems.SelectedItem.SubItems[3].Text;
                exchangeRate = lvPaymentItems.SelectedItem.SubItems[7].Text;
                amtHkd = lvPaymentItems.SelectedItem.SubItems[8].Text;
                card = lvPaymentItems.SelectedItem.SubItems[4].Text;
                authorize = lvPaymentItems.SelectedItem.SubItems[5].Text;
                apItem.SetValues(typeCode, currencyCode, amount, exchangeRate, card, authorize);
            }
            else
            {
                decimal totalAmt = Convert.ToDecimal(txtTotalAmount.Text.Length > 0 ? txtTotalAmount.Text : "0");
                decimal totalPay = Convert.ToDecimal(txtTotalPay.Text.Length > 0 ? txtTotalPay.Text : "0");
                decimal totalChange = totalAmt - totalPay;

                amount = totalChange.ToString("n2");
                apItem.SetValues(typeCode, currencyCode, amount, card, authorize);
            }
            apItem.ShowDialog();
        }

        /// <summary>
        /// Handles the Closed event of the apItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void apItem_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                System.Guid typeId = new Guid();
                string typeCode = "", currencyCode = "", amount = "", exchangeRate = "", amtHkd = "", card = "", authorize = "";

                AmendPaymentItem apItem = sender as AmendPaymentItem;
                apItem.ReturnValues(ref typeId, ref typeCode, ref currencyCode, ref amount, ref exchangeRate, ref amtHkd, ref card, ref authorize);

                if (lvPaymentItems.SelectedItem.SubItems.Count <= 1)
                {
                    lvPaymentItems.SelectedItem.Text = System.Guid.Empty.ToString();
                    lvPaymentItems.SelectedItem.SubItems.Add(typeId.ToString());
                    lvPaymentItems.SelectedItem.SubItems.Add(typeCode);
                    lvPaymentItems.SelectedItem.SubItems.Add(amount);
                    lvPaymentItems.SelectedItem.SubItems.Add(card);
                    lvPaymentItems.SelectedItem.SubItems.Add(authorize);
                    lvPaymentItems.SelectedItem.SubItems.Add(currencyCode);
                    lvPaymentItems.SelectedItem.SubItems.Add(exchangeRate);
                    lvPaymentItems.SelectedItem.SubItems.Add(amtHkd);
                }
                else
                {
                    lvPaymentItems.SelectedItem.SubItems[1].Text = typeId.ToString();
                    lvPaymentItems.SelectedItem.SubItems[2].Text = typeCode;
                    lvPaymentItems.SelectedItem.SubItems[3].Text = amount;
                    lvPaymentItems.SelectedItem.SubItems[4].Text = card;
                    lvPaymentItems.SelectedItem.SubItems[5].Text = authorize;
                    lvPaymentItems.SelectedItem.SubItems[6].Text = currencyCode;
                    lvPaymentItems.SelectedItem.SubItems[7].Text = exchangeRate;
                    lvPaymentItems.SelectedItem.SubItems[8].Text = amtHkd;
                }
                
                CalculateTotalPay();
            }
        }

        /// <summary>
        /// Calculates the total pay.
        /// </summary>
        private void CalculateTotalPay()
        {
            decimal ttlAmount = 0;
            decimal totalAmt = Convert.ToDecimal(txtTotalAmount.Text);

            foreach (ListViewItem listItem in lvPaymentItems.Items)
            {
                if (listItem.SubItems.Count > 1)
                    ttlAmount += Convert.ToDecimal(listItem.SubItems[3].Text.Length > 0 ? listItem.SubItems[3].Text : "0");
            }

            txtTotalPay.Text = ttlAmount.ToString("n2");
            txtTotalChange.Text = (ttlAmount - totalAmt).ToString("n2");
        }
        #endregion

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvDetailsList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null && lvDetailsList.SelectedItem.SubItems[2].Text != "REMOVED")
            {
                if (Common.Utility.IsGUID(lvDetailsList.SelectedItem.Text))
                {
                    LoadPOSBatchDetailsInfo(new Guid(lvDetailsList.SelectedItem.Text));
                }
            }
        }

        #region Search Member
        /// <summary>
        /// Handles the Click event of the btnSearchMemNum control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSearchMemNum_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        /// <summary>
        /// Searches the member.
        /// </summary>
        private void SearchMember()
        {
            SearchMember frmSearch = new SearchMember();
            frmSearch.Closed += new EventHandler(frmSearch_Closed);
            frmSearch.ShowDialog();
        }

        /// <summary>
        /// Handles the Closed event of the frmSearch control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void frmSearch_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                SearchMember search = sender as SearchMember;
                cboMemberNumber.SelectedValue = search.MemberId;
            }
        }
        #endregion

        /// <summary>
        /// Handles the Click event of the btnAnalysisCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnAnalysisCode_Click(object sender, EventArgs e)
        {
            if (oAnalysisCode.Visible)
            {
                oAnalysisCode.Visible = false;
            }
            else
            {
                oAnalysisCode.Visible = true;
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoStockCode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void rdoStockCode_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoStockCode.Checked)
            {
                basicFindProduct.Focus();
                txtBarcode.Enabled = false;
            }
            else
            {
                txtBarcode.Enabled = true;
                txtBarcode.Focus();
            }
        }

        /// <summary>
        /// Formats the date.
        /// </summary>
        private void FormatDate()
        {
            string[] dateValue = txtDate.Text.Split('/');
            txtDate.Tag = dateValue[2] + "-" + dateValue[1] + "-" + dateValue[0];
        }

        /// <summary>
        /// Searches the product by barcode.
        /// </summary>
        /// <param name="barcode">The barcode.</param>
        private void SearchProductByBarcode(string barcode)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var productBarcode = ctx.ProductBarcode.Where(x => x.Barcode == barcode).FirstOrDefault();

                if (productBarcode != null)
                {
                    this.ProductId = productBarcode.ProductId;

                    var product = ctx.Product.Find(this.ProductId);
                    txtDiscount.Text = product.NormalDiscount.ToString("n2");
                    txtUnitAmount.Text = product.RetailPrice.Value.ToString("n2");
                    txtDescription.Text = product.ProductName;
                }
            }
        }

        /// <summary>
        /// Handles the CheckedChanged event of the rdoBarcode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void rdoBarcode_CheckedChanged(object sender, EventArgs e)
        {
            if (!rdoBarcode.Checked)
            {
                basicFindProduct.Focus();
                txtBarcode.Enabled = false;
            }
            else
            {
                txtBarcode.Enabled = true;
                txtBarcode.Focus();
            }
        }

        /// <summary>
        /// Handles the KeyUp event of the txtBarcode control.
        /// </summary>
        /// <param name="objSender">The source of the event.</param>
        /// <param name="objArgs">The <see cref="Gizmox.WebGUI.Forms.KeyEventArgs"/> instance containing the event data.</param>
        private void txtBarcode_KeyUp(object objSender, KeyEventArgs objArgs)
        {
            if (objArgs.KeyCode == Keys.Enter)
            {
                txtBarcode.Tag = txtBarcode.Text.Trim();

                SearchProductByBarcode(txtBarcode.Text.Trim());
            }
        }
    }
}