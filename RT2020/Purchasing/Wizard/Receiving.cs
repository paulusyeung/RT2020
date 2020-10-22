////RT2020.Purchasing.Wizard
namespace RT2020.Purchasing.Wizard
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Text;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Forms;

    using RT2020.DAL;

    /// <summary>
    /// Documentation for the second part of Receiving.
    /// </summary>
    public partial class Receiving : Form, IGatewayComponent
    {
        /// <summary>
        /// The selected Index. 
        /// </summary>
        private int selectedIndex = 0;

        /// <summary>
        /// The Total Qty
        /// </summary>
        private decimal totalQty = 0;

        /// <summary>
        /// The order header id.
        /// </summary>
        private Guid orderHeaderId = System.Guid.Empty;

        /// <summary>
        /// The order detail id.
        /// </summary>
        private Guid receivingDetailId = System.Guid.Empty;

        /// <summary>
        /// The receiving id.
        /// </summary>
        private Guid receivingHeaderId = System.Guid.Empty;

        /// <summary>
        /// The product id
        /// </summary>
        private Guid productId = System.Guid.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="Receiving"/> class.
        /// </summary>
        public Receiving()
        {
            this.InitializeComponent();

            this.FillLocationList();
            this.SetToolBar();
            this.txtTRNo.Text = "Auto-Generated";
            this.txtType.Text = "REC";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Receiving"/> class.
        /// </summary>
        /// <param name="objId">The obj id.</param>
        public Receiving(Guid objId)
        {
            this.InitializeComponent();
            this.FillLocationList();
            this.SetToolBar();
            this.ReceivingHeaderId = objId;
            this.LoadReceivingHeaderInfo();
        }

        #region Properties
        /// <summary>
        /// Gets or sets the order header id.
        /// </summary>
        /// <value>The order header id.</value>
        public Guid OrderHeaderId
        {
            get { return this.orderHeaderId; }
            set { this.orderHeaderId = value; }
        }

        /// <summary>
        /// Gets or sets the order detail id.
        /// </summary>
        /// <value>The order detail id.</value>
        public Guid ReceivingDetailId
        {
            get { return this.receivingDetailId; }
            set { this.receivingDetailId = value; }
        }

        /// <summary>
        /// Gets or sets the receiving id.
        /// </summary>
        /// <value>The receiving id.</value>
        public Guid ReceivingHeaderId
        {
            get { return this.receivingHeaderId; }
            set { this.receivingHeaderId = value; }
        }

        /// <summary>
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
        public Guid ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }

        #endregion

        #region Fill List
        /// <summary>
        /// Fills the location list.
        /// </summary>
        private void FillLocationList()
        {
            RT2020.DAL.Workplace.LoadCombo(ref this.cboLocation, new string[] { "WorkplaceCode", "WorkplaceInitial" }, "{0} - {1}", false, false, string.Empty, string.Empty, null);
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

            //// cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            //// cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            //// cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            //// cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            //// cmdPrint
            ToolBarButton cmdPrint = new ToolBarButton("Print", "Print");
            cmdPrint.Tag = "Print";
            cmdPrint.Image = new IconResourceHandle("16x16.16_print.gif");

            if (this.OrderHeaderId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
                cmdPrint.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
                cmdPrint.Enabled = true;
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);
            this.tbWizardAction.Buttons.Add(sep);
            this.tbWizardAction.Buttons.Add(cmdPrint);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(this.TbWizardAction_ButtonClick);
        }

        /// <summary>
        /// Handles the ButtonClick event of the TbWizardAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        private void TbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(this.SaveMessageHandler));
                        break;
                    case "save & new":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(this.SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(this.SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(this.DeleteConfirmationHandler));
                        break;
                    case "print":
                        Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "rdlPDF"));
                        break;
                }
            }
        }
        #endregion

        #region Message Handler
        /// <summary>
        /// Saves the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    this.Save();

                    if (this.OrderHeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultRECList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        Receiving receiving = new Receiving(this.ReceivingHeaderId);
                        receiving.ShowDialog();
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
                if (!this.Text.Contains("ReadOnly"))
                {
                    this.Save();

                    if (this.OrderHeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultRECList>();
                        this.Close();
                        Receiving receiving = new Receiving();
                        receiving.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                if (!this.Text.Contains("ReadOnly"))
                {
                    this.Save();

                    if (this.OrderHeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultRECList>();
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
                this.Delete();

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
                this.Save();

                if (this.OrderHeaderId != System.Guid.Empty)
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    Receiving receiving = new Receiving();
                    receiving.ShowDialog();
                }
            }
            else
            {
                ////tabGoodsADJ.SelectedIndex = 0;
            }
        }
        #endregion

        #region Save Purchase Order Header Info
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            PurchaseOrderReceiveHeader objHeader = PurchaseOrderReceiveHeader.Load(this.ReceivingHeaderId);

            if (objHeader == null)
            {
                objHeader = new PurchaseOrderReceiveHeader();

                objHeader.CreatedBy = Common.Config.CurrentUserId;
                objHeader.CreatedOn = DateTime.Now;

                this.txtTRNo.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.REC);
                objHeader.TxNumber = this.txtTRNo.Text;
            }

            //// main
            objHeader.TxType = this.txtType.Text;
            objHeader.TxDate = this.dtpReceivingDate.Value;
            objHeader.OrderHeaderId = this.OrderHeaderId;
            objHeader.WorkplaceId = PurchasingUtils.Convert.ToGuid(this.cboLocation.SelectedValue.ToString());
            objHeader.StaffId = Common.Config.CurrentUserId;
            objHeader.ExchangeRate = PurchasingUtils.Convert.ToDecimal(this.txtXRate.Text);
            objHeader.TotalCost = PurchasingUtils.Convert.ToDecimal(this.txtRecAmount.Text);
            ////objHeader.TotalQty = PurchasingUtils.Convert.ToDecimal(this.txtTotalQty.Text);
            objHeader.TotalQty = this.totalQty;
            objHeader.FreightChargePcn = PurchasingUtils.Convert.ToDecimal(this.txtFreightCharge.Text);
            objHeader.FreightChargeAmt = objHeader.FreightChargePcn * objHeader.TotalCost;
            objHeader.HandlingChargePcn = PurchasingUtils.Convert.ToDecimal(this.txtHandlingCharge.Text);
            objHeader.HandlingChargeAmt = objHeader.HandlingChargePcn * objHeader.TotalCost;
            objHeader.InsuranceChargePcn = PurchasingUtils.Convert.ToDecimal(this.txtInsuranceCharge.Text);
            objHeader.InsuranceChargeAmt = objHeader.InsuranceChargePcn * objHeader.TotalCost;
            objHeader.OtherChargesPcn = PurchasingUtils.Convert.ToDecimal(this.txtOtherCharge.Text);
            objHeader.OtherChargesAmt = objHeader.OtherChargesPcn * objHeader.TotalCost;
            objHeader.GroupDiscount1 = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount1.Text);
            objHeader.GroupDiscount2 = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount2.Text);
            objHeader.GroupDiscount3 = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount3.Text);
            objHeader.Status = PurchasingUtils.Convert.ToInt32(this.cboStatus.Text == "HOLD" ? Common.Enums.Status.Draft.ToString("d") : Common.Enums.Status.Active.ToString("d"));
            
            //// detail

            //// other
            objHeader.SupplierInvoiceNumber = this.txtSuppINV.Text;
            
            objHeader.ModifiedBy = Common.Config.CurrentUserId;
            objHeader.ModifiedOn = DateTime.Now;

            objHeader.Save();

            this.receivingHeaderId = objHeader.ReceiveHeaderId;

            this.SaveOrderDetail();
            this.UpdateHeaderInfo();
        }

        /// <summary>
        /// Saves the order detail.
        /// </summary>
        private void SaveOrderDetail()
        {
            foreach (ListViewItem listItem in this.lvDetailsList.Items)
            {
                //// 判断detailid 和 productid 是否为空，不为空才执行 保存/删除 操作
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[20].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    PurchaseOrderReceiveDetails objDetail = PurchaseOrderReceiveDetails.Load(detailId);
                    if (objDetail == null)
                    {
                        objDetail = new PurchaseOrderReceiveDetails();
                        objDetail.ReceiveHeaderId = this.ReceivingHeaderId;
                        objDetail.LineNumber = Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);
                    }

                    objDetail.ProductId = new Guid(listItem.SubItems[20].Text.Trim());
                    objDetail.ReceivedQty = Convert.ToDecimal(listItem.SubItems[10].Text.Length == 0 ? "0" : listItem.SubItems[10].Text);
                    objDetail.UnitCost = Convert.ToDecimal(listItem.SubItems[11].Text.Length == 0 ? "0" : listItem.SubItems[11].Text);
                    objDetail.DiscountPcn = Convert.ToDecimal(listItem.SubItems[12].Text.Length == 0 ? "0" : listItem.SubItems[12].Text);
                    objDetail.NetUnitCost = objDetail.UnitCost * ((100 - objDetail.DiscountPcn) / 100);
                    objDetail.NetUnitCostCoefficient = objDetail.NetUnitCost * Convert.ToDecimal(this.txtCoeffcient.Text);
                    objDetail.BillQty = Convert.ToDecimal(listItem.SubItems[16].Text.Length == 0 ? "0" : listItem.SubItems[16].Text);
                    objDetail.BillUnitAmount = Convert.ToDecimal(listItem.SubItems[17].Text.Length == 0 ? "0" : listItem.SubItems[17].Text);
                    objDetail.Notes = listItem.SubItems[19].Text;

                    if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
                    {
                        objDetail.Delete();
                    }
                    else
                    {
                        objDetail.Save();
                    }
                }
            }
        }

        /// <summary>
        /// Updates the header info.
        /// </summary>
        private void UpdateHeaderInfo()
        {
            PurchaseOrderReceiveHeader objHeader = PurchaseOrderReceiveHeader.Load(this.ReceivingHeaderId);
            if (objHeader != null)
            {
                ////oHeader.TotalAmount = Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text.Trim() : "0");

                objHeader.Save();
            }
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        private void Delete()
        {
            PurchaseOrderReceiveHeader objHeader = PurchaseOrderReceiveHeader.Load(this.ReceivingHeaderId);
            if (objHeader != null)
            {
                string sql = "ReceiveHeaderId = '" + objHeader.ReceiveHeaderId.ToString() + "'";

                this.DelDetails(sql);

                objHeader.Delete();
            }
        }

        /// <summary>
        /// Dels the details.
        /// </summary>
        /// <param name="objSql">The obj SQL.</param>
        private void DelDetails(string objSql)
        {
            PurchaseOrderReceiveDetailsCollection objDetailList = PurchaseOrderReceiveDetails.LoadCollection(objSql);
            foreach (PurchaseOrderReceiveDetails objDetail in objDetailList)
            {
                objDetail.Delete();
            }
        }
        #endregion

        #region IGatewayComponent Members

        /// <summary>
        /// Provides a way to custom handle requests.
        /// </summary>
        /// <param name="objContext">The request context.</param>
        /// <param name="strAction">The request action.</param>
        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            switch (strAction)
            {
                case "rdlPDF":
                    this.RdlToPdf();
                    break;
            }
        }

        /// <summary>
        /// RDLs to PDF.
        /// </summary>
        private void RdlToPdf()
        {
            string[,] param = 
            {
                { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
                { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
                { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
                { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
                { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
                { "Company", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test
                { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            };

            RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            rdlExport.Datasource = this.BindData();
            rdlExport.ReportName = "RT2020.Purchasing.Wizard.Reports.POWorksheetRdl.rdlc";
            rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
            rdlExport.Parameters = param;

            rdlExport.ToPdf();
        }

        #endregion

        #region Bind data to report
        /// <summary>
        /// Binds the data.
        /// </summary>
        /// <returns>A DataTable object</returns>
        private DataTable BindData()
        {
            string sql = @"
SELECT TOP 100 PERCENT *
FROM vwRptPurchaseOrderReceive
WHERE ReceiveHeaderId = '" + this.ReceivingHeaderId.ToString() + "'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        #endregion

        /// <summary>
        /// Handles the SelectionChanged event of the BasicProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs"/> instance containing the event data.</param>
        private void BasicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            this.txtDescription.Text = e.Description;
            this.txtUnitCost.Text = e.UnitCost.ToString("n2");
            this.txtRetailPrice.Text = e.UnitPrice.ToString("n2");
        }

        /// <summary>
        /// Handles the Leave event of the TxtXRate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtXRate_Leave(object sender, EventArgs e)
        {
            this.txtCoeffcient.Text = this.txtXRate.Text;
        }

        /// <summary>
        /// Handles the Click event of the BtnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (this.lvDetailsList.SelectedItem != null)
            {
                if (this.lvDetailsList.SelectedItem.Text != System.Guid.Empty.ToString())
                {
                    ListViewItem listItem = this.lvDetailsList.SelectedItem;
                    listItem.SubItems[2].Text = "REMOVED"; //// Status
                }
                else
                {
                    this.lvDetailsList.Items.Remove(this.lvDetailsList.SelectedItem);
                    this.lvDetailsList.Update();
                }

                this.CalcTotal();
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnAddItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            this.ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

            if (this.IsDuplicated(stkCode, appendix1, appendix2, appendix3))
            {
                ////this.Invoke(new EventHandler(btnEditItem_Click), new object[] { this, e });
                MessageBox.Show(string.Format(Resources.Common.DuplicatedCode, "Stock Item"), string.Format(Resources.Common.DuplicatedCode, string.Empty));
            }
            else
            {
                if (this.ProductId != System.Guid.Empty)
                {
                    ListViewItem listItem = this.lvDetailsList.Items.Add(System.Guid.Empty.ToString());
                    listItem.SubItems.Add(this.lvDetailsList.Items.Count.ToString());
                    listItem.SubItems.Add("NEW"); //// Status
                    listItem.SubItems.Add(stkCode); //// Stock Code
                    listItem.SubItems.Add(appendix1); //// Appendix1
                    listItem.SubItems.Add(appendix2); //// Appendix2
                    listItem.SubItems.Add(appendix3); //// Appendix3
                    listItem.SubItems.Add(this.txtDescription.Text); //// Description
                    listItem.SubItems.Add(this.txtOrderQty.Text);     //// OrderedQty
                    listItem.SubItems.Add((PurchasingUtils.Convert.ToDecimal(this.txtOrderQty.Text) - PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text)).ToString());     //// Last Rec Qty = Order Qty - Rec Qty
                    listItem.SubItems.Add(this.txtRecQty.Text);     //// Rec Qty
                    listItem.SubItems.Add(this.txtUnitCost.Text);     //// UnitCost
                    listItem.SubItems.Add(this.txtDisc.Text);     //// DiscountPcn
                    listItem.SubItems.Add(this.txtNetCost.Text);     //// Net Cost
                    listItem.SubItems.Add(this.txtRetailPrice.Text);     //// Retail Price
                    listItem.SubItems.Add((PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtRetailPrice.Text)).ToString());     //// Total Retail = Rec Qty × Retail Price
                    listItem.SubItems.Add(this.txtBillQty.Text);     //// Bill Qty
                    listItem.SubItems.Add(this.txtBillUnitCost.Text);     //// Bill Cost 
                    listItem.SubItems.Add((PurchasingUtils.Convert.ToDecimal(this.txtBillQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtBillUnitCost.Text)).ToString());     //// Bill Total = Bill Qty × Bill Unit Cost
                    listItem.SubItems.Add(this.txtRemarks.Text);                //// Notes
                    listItem.SubItems.Add(this.ProductId.ToString());       //// ProductId

                    this.CalcTotal();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnEditItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            if (this.lvDetailsList.SelectedItem != null)
            {
                string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
                this.ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);
               
                ListViewItem listItem = this.lvDetailsList.SelectedItem;
                listItem.SubItems[2].Text = listItem.SubItems[2].Text != "NEW" ? "EDIT" : listItem.SubItems[2].Text; //// Status
                listItem.SubItems[3].Text = stkCode; //// Stock Code
                listItem.SubItems[4].Text = appendix1; //// Appendix1
                listItem.SubItems[5].Text = appendix2; //// Appendix2
                listItem.SubItems[6].Text = appendix3; //// Appendix3
                listItem.SubItems[7].Text = this.txtDescription.Text; //// Description
                listItem.SubItems[8].Text = this.txtOrderQty.Text; //// OrderedQty
                listItem.SubItems[9].Text = (PurchasingUtils.Convert.ToDecimal(this.txtOrderQty.Text) - PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text)).ToString("n0"); //// Last Rec Qty
                listItem.SubItems[10].Text = this.txtRecQty.Text; //// Rec Qty
                listItem.SubItems[11].Text = this.txtUnitCost.Text; //// UnitCost
                listItem.SubItems[12].Text = this.txtDisc.Text; //// DiscountPcn
                listItem.SubItems[13].Text = this.txtNetCost.Text; //// Net Cost
                listItem.SubItems[14].Text = this.txtRetailPrice.Text; //// Retail Price
                listItem.SubItems[15].Text = (PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtRetailPrice.Text)).ToString("n2"); //// Total Retail
                listItem.SubItems[16].Text = this.txtBillQty.Text; //// Bill Qty
                listItem.SubItems[17].Text = this.txtBillUnitCost.Text; //// Bill Cost 
                listItem.SubItems[18].Text = (PurchasingUtils.Convert.ToDecimal(this.txtBillQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtBillUnitCost.Text)).ToString("n2"); //// Bill Total
                listItem.SubItems[19].Text = this.txtRemarks.Text; //// Notes
                listItem.SubItems[20].Text = this.ProductId.ToString(); //// ProductId

                this.CalcTotal();
            }
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
            if (this.basicProduct.SelectedItem != null)
            {
                RT2020.DAL.Product objProd = RT2020.DAL.Product.Load(new Guid(this.basicProduct.SelectedItem.ToString()));
                if (objProd != null)
                {
                    stkCode = objProd.STKCODE;
                    appendix1 = objProd.APPENDIX1;
                    appendix2 = objProd.APPENDIX2;
                    appendix3 = objProd.APPENDIX3;

                    this.ProductId = objProd.ProductId;
                }
            }
        }

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

            foreach (ListViewItem objItem in this.lvDetailsList.Items)
            {
                if (stkCode.Length > 0)
                {
                    isDuplicated = (objItem.SubItems[3].Text == stkCode);
                    isDuplicated = isDuplicated & (objItem.SubItems[4].Text == appendix1);
                    isDuplicated = isDuplicated & (objItem.SubItems[5].Text == appendix2);
                    isDuplicated = isDuplicated & (objItem.SubItems[6].Text == appendix3);
                }
            }

            return isDuplicated;
        }

        /// <summary>
        /// Calcs the total.
        /// </summary>
        private void CalcTotal()
        {
            decimal ttlRecAmount = 0, ttlRetail = 0;
            this.totalQty = 0;
            foreach (ListViewItem listItem in this.lvDetailsList.Items)
            {
                if (listItem.SubItems[2].Text != "REMOVED")
                {
                    decimal totalRetail = PurchasingUtils.Convert.ToDecimal(listItem.SubItems[10].Text) * PurchasingUtils.Convert.ToDecimal(listItem.SubItems[14].Text);
                    decimal recAmount = PurchasingUtils.Convert.ToDecimal(listItem.SubItems[10].Text) * PurchasingUtils.Convert.ToDecimal(listItem.SubItems[11].Text);
                    this.totalQty += PurchasingUtils.Convert.ToDecimal(listItem.SubItems[10].Text);
                    ttlRecAmount += recAmount;
                    ttlRetail += totalRetail;
                }
            }

            decimal coefficient = PurchasingUtils.Convert.ToDecimal(this.txtCoeffcient.Text);

            this.txtRecAmount.Text = (ttlRecAmount * coefficient).ToString("n2");
            this.txtTotalRetailM.Text = ttlRetail.ToString("n2");
        }

        /// <summary>
        /// Calcs the retail.
        /// </summary>
        private void CalcRetail()
        {
            decimal retail = PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtRetailPrice.Text);

            this.txtTotalRetail.Text = retail.ToString("n2");
        }

        /// <summary>
        /// Calcs the bill total.
        /// </summary>
        private void CalcBillTotal()
        {
            decimal billTotal = PurchasingUtils.Convert.ToDecimal(this.txtBillQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtBillUnitCost.Text);

            this.txtBillTotal.Text = billTotal.ToString("n2");
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the LvDetailsList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(this.lvDetailsList.SelectedItem.Text))
                {
                    this.LoadReceivingDetailInfo(new Guid(this.lvDetailsList.SelectedItem.Text));
                    this.ReceivingDetailId = new Guid(this.lvDetailsList.SelectedItem.Text);
                    this.selectedIndex = this.lvDetailsList.SelectedIndex;
                }
            }
        }

        #region Load Purchase Order Header And Details
        /// <summary>
        /// Loads the receiving header info.
        /// </summary>
        private void LoadReceivingHeaderInfo()
        {
            PurchaseOrderReceiveHeader objHeader = PurchaseOrderReceiveHeader.Load(this.ReceivingHeaderId);
            if (objHeader != null)
            {
                this.OrderHeaderId = objHeader.OrderHeaderId;
                PurchaseOrderHeader pohHeader = PurchaseOrderHeader.Load(this.OrderHeaderId);

                this.txtTRNo.Text = objHeader.TxNumber;

                string strPoType = string.Empty;
                switch (pohHeader.OrderType)
                {
                    case 0:
                        strPoType = "FPO";
                        break;
                    case 1:
                        strPoType = "LPO";
                        break;
                    case 2:
                        strPoType = "OPO";
                        break;
                }

                this.txtType.Text = objHeader.TxType;

                this.txtPoType.Text = strPoType;
                this.txtSupplierCode.Text = this.GetSupplierCode(pohHeader.SupplierId);
                this.txtOperatorCode.Text = this.GetOperatorCode(objHeader.StaffId);
                this.txtOrderDate.Text = pohHeader.OrderOn.ToShortDateString();
                this.txtDeliveryDate.Text = pohHeader.DeliverOn.ToShortDateString();
                this.txtCancellationDate.Text = pohHeader.CancellationOn.ToShortDateString();
                this.txtPaymentMethod.Text = this.GetTermsCode(pohHeader.TermsId);
                this.txtPaymentTerm.Text = pohHeader.CreditDays.ToString();
                this.txtDeposit.Text = pohHeader.DepositPercentage.ToString("n2");
                this.txtPaymentRemark.Text = pohHeader.PaymentRemarks;

                this.txtPoNo.Text = pohHeader.OrderNumber;
                this.cboLocation.SelectedValue = objHeader.WorkplaceId;
                this.txtCurrency.Text = pohHeader.CurrencyCode;
                this.txtXRate.Text = objHeader.ExchangeRate.ToString("n6");
                this.txtGroupDiscount1.Text = objHeader.GroupDiscount1.ToString("n2");
                this.txtGroupDiscount2.Text = objHeader.GroupDiscount2.ToString("n2");
                this.txtGroupDiscount3.Text = objHeader.GroupDiscount3.ToString("n2");
                this.txtPartialShipment.Text = pohHeader.PartialShipment ? "YES" : "NO";
                this.txtShipmentMethod.Text = pohHeader.ShipmentMethod;
                this.txtShipmentRemark.Text = pohHeader.ShipmentRemarks;
                this.txtLastUser.Text = this.GetStaffName(objHeader.ModifiedBy);

                string statusName = string.Empty;
                switch (objHeader.Status)
                {
                    case 1:
                        statusName = "POST";
                        break;
                    case 0:
                    default:
                        statusName = "HOLD";
                        break;
                }

                this.cboStatus.SelectedItem = statusName;
                this.txtFreightCharge.Text = objHeader.FreightChargePcn.ToString("n2");
                this.txtHandlingCharge.Text = objHeader.HandlingChargePcn.ToString("n2");
                this.txtInsuranceCharge.Text = objHeader.InsuranceChargePcn.ToString("n2");
                this.txtOtherCharge.Text = objHeader.OtherChargesPcn.ToString("n2");
                this.txtTotalQty.Text = objHeader.TotalQty.ToString("n0");
                
                this.ShowNetCost(objHeader.TotalCost, objHeader.GroupDiscount1, objHeader.GroupDiscount2, objHeader.GroupDiscount3, objHeader.FreightChargeAmt, objHeader.HandlingChargeAmt, objHeader.InsuranceChargeAmt, objHeader.OtherChargesAmt, objHeader.ExchangeRate);
                
                this.txtCoeffcient.Text = objHeader.ExchangeRate.ToString("n6");
                this.txtLastUpdate.Text = objHeader.ModifiedOn.ToShortDateString();

                this.txtPoRemark1.Text = pohHeader.Remarks1;
                this.txtPoRemark2.Text = pohHeader.Remarks2;
                this.txtPoRemark3.Text = pohHeader.Remarks3;
                this.txtSuppINV.Text = objHeader.SupplierInvoiceNumber;

                this.BindPODetailsInfo();
                this.CalcTotal();
            }
        }

        /// <summary>
        /// Loads the PO detail info.
        /// </summary>
        /// <param name="detailId">The detail id.</param>
        private void LoadReceivingDetailInfo(Guid detailId)
        {
            ListViewItem objItem = this.lvDetailsList.SelectedItem;

            this.txtDescription.Text = objItem.SubItems[7].Text;
            this.txtRecQty.Text = objItem.SubItems[10].Text;
            this.txtUnitCost.Text = objItem.SubItems[11].Text;
            this.txtDisc.Text = objItem.SubItems[12].Text;
            this.txtRemarks.Text = objItem.SubItems[19].Text;

            this.txtOrderQty.Text = objItem.SubItems[8].Text;
            this.txtLastTotal.Text = (PurchasingUtils.Convert.ToDecimal(objItem.SubItems[8].Text) - PurchasingUtils.Convert.ToDecimal(objItem.SubItems[10].Text)).ToString("n2");
            this.txtRetailPrice.Text = objItem.SubItems[14].Text;
            this.txtTotalRetail.Text = (PurchasingUtils.Convert.ToDecimal(objItem.SubItems[10].Text) * PurchasingUtils.Convert.ToDecimal(objItem.SubItems[14].Text)).ToString("n2");

            this.txtBillQty.Text = objItem.SubItems[16].Text;
            this.txtBillUnitCost.Text = objItem.SubItems[17].Text;
            this.txtBillTotal.Text = (PurchasingUtils.Convert.ToDecimal(objItem.SubItems[16].Text) * PurchasingUtils.Convert.ToDecimal(objItem.SubItems[17].Text)).ToString("n2");

            this.basicProduct.SelectedItem = PurchasingUtils.Convert.ToGuid(objItem.SubItems[20].Text);
            this.ProductId = PurchasingUtils.Convert.ToGuid(objItem.SubItems[20].Text);
        }

        #endregion

        #region Bind Receiving Detail List
        /// <summary>
        /// Loads the PO header info.
        /// </summary>
        /// <param name="objHeader">The obj header.</param>
        public void BindPOHeaderInfo(PurchaseOrderHeader objHeader)
        {
            this.OrderHeaderId = objHeader.OrderHeaderId;

            string strPoType = string.Empty;
            switch (objHeader.OrderType)
            {
                case 1:
                    strPoType = Common.Enums.POType.LPO.ToString();
                    break;
                case 2:
                    strPoType = Common.Enums.POType.OPO.ToString();
                    break;
                case 0:
                default:
                    strPoType = Common.Enums.POType.FPO.ToString();
                    break;
            }

            this.txtPoType.Text = strPoType;
            this.txtSupplierCode.Text = this.GetSupplierCode(objHeader.SupplierId);
            this.txtOperatorCode.Text = this.GetOperatorCode(objHeader.StaffId);
            this.txtOrderDate.Text = objHeader.OrderOn.ToShortDateString();
            this.txtDeliveryDate.Text = objHeader.DeliverOn.ToShortDateString();
            this.txtCancellationDate.Text = objHeader.CancellationOn.ToShortDateString();
            this.txtPaymentMethod.Text = this.GetTermsCode(objHeader.TermsId);
            this.txtPaymentTerm.Text = objHeader.CreditDays.ToString();
            this.txtDeposit.Text = objHeader.DepositPercentage.ToString("n2");
            this.txtPaymentRemark.Text = objHeader.PaymentRemarks;

            this.txtPoNo.Text = objHeader.OrderNumber;
            this.cboLocation.SelectedValue = objHeader.WorkplaceId;
            this.txtCurrency.Text = objHeader.CurrencyCode;
            this.txtXRate.Text = objHeader.ExchangeRate.ToString("n6");
            this.txtGroupDiscount1.Text = objHeader.GroupDiscount1.ToString("n2");
            this.txtGroupDiscount2.Text = objHeader.GroupDiscount2.ToString("n2");
            this.txtGroupDiscount3.Text = objHeader.GroupDiscount3.ToString("n2");
            this.txtPartialShipment.Text = objHeader.PartialShipment ? "YES" : "NO";
            this.txtShipmentMethod.Text = objHeader.ShipmentMethod;
            this.txtShipmentRemark.Text = objHeader.ShipmentRemarks;
            this.txtLastUser.Text = this.GetStaffName(objHeader.ModifiedBy);
            
            this.cboStatus.SelectedIndex = objHeader.Status;
            this.txtFreightCharge.Text = objHeader.FreightChargePcn.ToString("n2");
            this.txtHandlingCharge.Text = objHeader.HandlingChargePcn.ToString("n2");
            this.txtInsuranceCharge.Text = objHeader.InsuranceChargePcn.ToString("n2");
            this.txtOtherCharge.Text = objHeader.OtherChargesPcn.ToString("n2");
            this.txtTotalQty.Text = objHeader.TotalQty.ToString("n0");

            this.ShowNetCost(objHeader.TotalCost, objHeader.GroupDiscount1, objHeader.GroupDiscount2, objHeader.GroupDiscount3, objHeader.FreightChargeAmt, objHeader.HandlingChargeAmt, objHeader.InsuranceChargeAmt, objHeader.OtherChargesAmt, objHeader.ChargeCoefficient);

            this.txtCoeffcient.Text = objHeader.ExchangeRate.ToString("n6");
            this.txtLastUpdate.Text = objHeader.ModifiedOn.ToShortDateString();

            this.txtPoRemark1.Text = objHeader.Remarks1;
            this.txtPoRemark2.Text = objHeader.Remarks2;
            this.txtPoRemark3.Text = objHeader.Remarks3;

            this.BindPODetailsInfo();
        }

        /// <summary>
        /// Binds the purchase order details info.
        /// </summary>
        private void BindPODetailsInfo()
        {
            int iCount = 0;

            StringBuilder sql = new StringBuilder();
            if (this.ReceivingHeaderId != System.Guid.Empty)
            {
                sql.Append("SELECT  ReceiveDetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
                sql.Append(" OrderedQty, UnitCost, DiscountPcn, NetUnitCost,ReceivedQty, RetailPrice, BillQty, BillUnitAmount, Notes, ProductId ");
                sql.Append(" FROM vwPurchaseOrderReceiveDetailsList ");
                sql.Append(" WHERE ReceiveHeaderId = '").Append(this.ReceivingHeaderId.ToString()).Append("'");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql.ToString();
                cmd.CommandTimeout = Common.Config.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                        listItem.SubItems.Add((iCount + 1).ToString());             //// LN
                        listItem.SubItems.Add(string.Empty);                        //// Status
                        listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                        listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                        listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                        listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                        listItem.SubItems.Add(reader.GetString(6));                 ////Description
                        listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                        listItem.SubItems.Add((reader.GetDecimal(7) - reader.GetDecimal(11)).ToString("n0"));     //// Last Rec Qty = Order Qty - Rec Qty
                        listItem.SubItems.Add(reader.GetDecimal(11).ToString("n0"));     //// Rec Qty
                        listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                        listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                        listItem.SubItems.Add(reader.GetDecimal(10).ToString("n2"));     //// Net Cost
                        listItem.SubItems.Add(reader.GetDecimal(12).ToString("n2"));     //// Retail Price
                        listItem.SubItems.Add((reader.GetDecimal(11) * reader.GetDecimal(12)).ToString("n2"));     //// Total Retail = Rec Qty × Retail Price
                        listItem.SubItems.Add(reader.GetDecimal(13).ToString("n0"));     //// Bill Qty
                        listItem.SubItems.Add(reader.GetDecimal(14).ToString("n2"));     //// Bill Cost = BillUnitAmount / BillQty
                        listItem.SubItems.Add(reader.GetDecimal(14).ToString("n2"));     //// Bill Total = Bill Qty × Bill Unit Cost
                        listItem.SubItems.Add(reader.GetString(15));                //// Notes
                        listItem.SubItems.Add(reader.GetGuid(16).ToString());       //// ProductId

                        iCount++;
                    }
                }
            }
            else
            {
                sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
                sql.Append(" OrderedQty, UnitCost, DiscountPcn, Notes, ProductId ");
                sql.Append(" FROM vwPurchaseOrderDetailsList ");
                sql.Append(" WHERE HeaderId = '").Append(this.OrderHeaderId.ToString()).Append("'");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql.ToString();
                cmd.CommandTimeout = Common.Config.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                        listItem.SubItems.Add((iCount + 1).ToString());             //// LN
                        listItem.SubItems.Add(string.Empty);                        //// Status
                        listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                        listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                        listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                        listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                        listItem.SubItems.Add(reader.GetString(6));                 ////Description
                        listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                        listItem.SubItems.Add("0");     //// Last Rec Qty
                        listItem.SubItems.Add("0");     //// Rec Qty
                        listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                        listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                        listItem.SubItems.Add("0.00");     //// Net Cost
                        listItem.SubItems.Add(this.GetStockCode(reader.GetGuid(11), 0, "RETAILPRICE").ToString("n0"));     //// Retail Price
                        listItem.SubItems.Add("0.00");     //// Total Retail
                        listItem.SubItems.Add("0");     //// Bill Qty
                        listItem.SubItems.Add("0.00");     //// Bill Cost
                        listItem.SubItems.Add("0.00");     //// Bill Total
                        listItem.SubItems.Add(reader.GetString(10));                //// Notes
                        listItem.SubItems.Add(reader.GetGuid(11).ToString());       //// ProductId

                        iCount++;
                    }
                }
            }

            this.lblLineCount.Text = iCount.ToString();
        }
        #endregion

        #region Get Codes
        /// <summary>
        /// Gets the stock code.
        /// </summary>
        /// <param name="productId">The product id.</param>
        /// <param name="recQty">The rec qty.</param>
        /// <param name="stockName">Name of the stock.</param>
        /// <returns>the stock code</returns>
        private decimal GetStockCode(Guid productId, decimal recQty, string stockName)
        {
            decimal result = 0;

            Product objProduct = Product.Load(productId);
            if (objProduct != null)
            {
                switch (stockName.ToUpper())
                {
                    case "RETAILPRICE":     ////Retail Price
                    default:
                        result = objProduct.RetailPrice;  
                        break;
                    case "TOTALRETAIL":     ////Total Retail($)
                        result = objProduct.RetailPrice * recQty;
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the net cost.
        /// </summary>
        /// <param name="totalCost">The total cost.</param>
        /// <param name="groupDiscount1">The group discount1.</param>
        /// <param name="groupDiscount2">The group discount2.</param>
        /// <param name="groupDiscount3">The group discount3.</param>
        /// <param name="freightChargeAmt">The freight charge amt.</param>
        /// <param name="handlingChargeAmt">The handling charge amt.</param>
        /// <param name="insuranceChargeAmt">The insurance charge amt.</param>
        /// <param name="otherChargesAmt">The other charges amt.</param>
        /// <param name="chargeCoefficient">The charge coefficient.</param>
        private void ShowNetCost(decimal totalCost, decimal groupDiscount1, decimal groupDiscount2, decimal groupDiscount3, decimal freightChargeAmt, decimal handlingChargeAmt, decimal insuranceChargeAmt, decimal otherChargesAmt, decimal chargeCoefficient)
        {
            decimal result = 0;

            decimal disc1 = (100 - groupDiscount1) / 100;
            decimal disc2 = (100 - groupDiscount2) / 100;
            decimal disc3 = (100 - groupDiscount3) / 100;
            decimal freightAmt = (100 - freightChargeAmt) / 100;
            decimal handAmt = (100 - handlingChargeAmt) / 100;
            decimal insuranceAmt = (100 - insuranceChargeAmt) / 100;
            decimal otherAmt = (100 - otherChargesAmt) / 100;
            
            result = ((totalCost * disc1 * disc2 * disc3) - freightAmt - handAmt - insuranceAmt - otherAmt) * chargeCoefficient;

            this.txtNetCost.Text = result.ToString("n2");
        }

        /// <summary>
        /// Gets the name of the staff.
        /// </summary>
        /// <param name="staffId">The staff id.</param>
        /// <returns>The staff Name.</returns>
        private string GetStaffName(Guid staffId)
        {
            string result = string.Empty;

            RT2020.DAL.Staff objStaff = RT2020.DAL.Staff.Load(staffId);
            if (objStaff != null)
            {
                result = objStaff.StaffNumber;
            }

            return result;
        }

        /// <summary>
        /// Gets the supplier code.
        /// </summary>
        /// <param name="supplierId">The supplier id.</param>
        /// <returns>the supplier code.</returns>
        private string GetSupplierCode(Guid supplierId)
        {
            string result = string.Empty;

            Supplier objSupplier = Supplier.Load(supplierId);
            if (objSupplier != null)
            {
                result = objSupplier.SupplierCode;
            }

            return result;
        }

        /// <summary>
        /// Gets the operator code.
        /// </summary>
        /// <param name="operatorId">The operator id.</param>
        /// <returns>the operator code.</returns>
        private string GetOperatorCode(Guid operatorId)
        {
            string result = string.Empty;

            Staff objStaff = Staff.Load(operatorId);
            if (objStaff != null)
            {
                result = objStaff.StaffNumber;
            }

            return result;
        }

        /// <summary>
        /// Gets the terms code.
        /// </summary>
        /// <param name="termsId">The terms id.</param>
        /// <returns>the terms code.</returns>
        private string GetTermsCode(Guid termsId)
        {
            string result = string.Empty;

            SupplierTerms objTerms = SupplierTerms.Load(termsId);
            if (objTerms != null)
            {
                result = objTerms.TermsCode;
            }

            return result;
        }

        #endregion

        /// <summary>
        /// Handles the TextChanged event of the txtRecQty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtRecQty_TextChanged(object sender, EventArgs e)
        {
            if (this.txtRecQty.Text.Length > 0 && this.txtRetailPrice.Text.Length > 0)
            {
                this.CalcRetail();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtBillQty control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtBillQty_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBillQty.Text.Length > 0 && this.txtBillUnitCost.Text.Length > 0)
            {
                this.CalcBillTotal();
            }
        }

        /// <summary>
        /// Handles the TextChanged event of the txtBillUnitCost control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtBillUnitCost_TextChanged(object sender, EventArgs e)
        {
            if (this.txtBillQty.Text.Length > 0 && this.txtBillUnitCost.Text.Length > 0)
            {
                this.CalcBillTotal();
            }
        }
    }
}