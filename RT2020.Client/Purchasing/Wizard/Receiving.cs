using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RT2020.DAL;

namespace RT2020.Client.Purchasing.Wizard
{
    public partial class Receiving : Form
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
            InitializeComponent();

            SetEnabled();

            this.FillLocationList();
            this.txtTRNo.Text = "Auto-Generated";
            this.txtType.Text = "REC";

            Cursor.Current = Cursors.Default;
        }

        public Receiving(Guid objId)
        {
            InitializeComponent();

            SetEnabled();

            this.FillLocationList();
            this.ReceivingHeaderId = objId;
            this.LoadReceivingHeaderInfo();

            Cursor.Current = Cursors.Default;
        }

        private void SetEnabled()
        {
            this.btnAddItem.Visible = false;

            this.txtType.Enabled = false;
            this.txtTRNo.Enabled = false;
            this.txtRecAmount.Enabled = false;
            this.txtTotalRetailM.Enabled = false;
            this.txtPoType.Enabled = false;
            this.txtPoNo.Enabled = false;
            this.txtSupplierCode.Enabled = false;
            this.txtOperatorCode.Enabled = false;
            this.txtCurrency.Enabled = false;
            this.txtOrderDate.Enabled = false;
            this.txtDeliveryDate.Enabled = false;
            this.txtCancellationDate.Enabled = false;
            this.txtPaymentMethod.Enabled = false;
            this.txtPaymentTerm.Enabled = false;
            this.txtPaymentRemark.Enabled = false;
            this.txtDeposit.Enabled = false;
            this.txtPartialShipment.Enabled = false;
            this.txtShipmentMethod.Enabled = false;
            this.txtShipmentRemark.Enabled = false;
            this.txtLastUser.Enabled = false;
            this.txtTotalQty.Enabled = false;
            this.txtNetCost.Enabled = false;
            this.txtCoeffcient.Enabled = false;
            this.txtLastUpdate.Enabled = false;

            this.txtStockCode.Enabled = false;
            this.txtAppendix1.Enabled = false;
            this.txtAppendix2.Enabled = false;
            this.txtAppendix3.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtOrderQty.Enabled = false;
            this.txtLastTotal.Enabled = false;
            this.txtRetailPrice.Enabled = false;
            this.txtTotalRetail.Enabled = false;
            this.txtBillTotal.Enabled = false;

            this.txtPoRemark1.Enabled = false;
            this.txtPoRemark2.Enabled = false;
            this.txtPoRemark3.Enabled = false;
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
            this.cboLocation.Items.Clear();

            RT2020.DAL.WorkplaceCollection workplaceList = DAL.Workplace.LoadCollection(new String[] { "WorkplaceCode" }, true);
            this.cboLocation.DataSource = workplaceList;
            this.cboLocation.DisplayMember = "WorkplaceCode";
            this.cboLocation.ValueMember = "WorkplaceId";

            this.cboLocation.SelectedIndex = 0;
        }
        #endregion

        #region Form Toolbar Events

        private void cmdSave_Click(object sender, EventArgs e)
        {
            //base.cmdSave_Click(sender, e);
            if (MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    this.Save();

                    if (this.OrderHeaderId != System.Guid.Empty)
                    {
                        //RT2020.SystemInfo.Settings.RefreshMainList<DefaultRECList>();
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

        private void cmdSaveNew_Click(object sender, EventArgs e)
        {
            //base.cmdSaveNew_Click(sender, e);
            if (MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    this.Save();

                    if (this.OrderHeaderId != System.Guid.Empty)
                    {
                        //RT2020.SystemInfo.Settings.RefreshMainList<DefaultRECList>();
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

        private void cmdSaveClose_Click(object sender, EventArgs e)
        {
            //base.cmdSaveClose_Click(sender, e);
            if (MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    this.Save();

                    if (this.OrderHeaderId != System.Guid.Empty)
                    {
                        //RT2020.SystemInfo.Settings.RefreshMainList<DefaultRECList>();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("This transaction is ReadOnly. The changes you've made cannot be saved!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            //base.cmdDelete_Click(sender, e);
            if (MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Delete();

                this.Close();
            }
        }

        private void cmdPrint_Click(object sender, EventArgs e)
        {

        }

        #endregion

        #region Message Handler
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

                objHeader.CreatedBy = DAL.Common.Config.CurrentUserId;
                objHeader.CreatedOn = DateTime.Now;

                this.txtTRNo.Text = Common.Utility.QueuingTxNumber(DAL.Common.Enums.TxType.REC);
                objHeader.TxNumber = this.txtTRNo.Text;
            }

            //// main
            objHeader.TxType = this.txtType.Text;
            objHeader.TxDate = this.dtpReceivingDate.Value;
            objHeader.OrderHeaderId = this.OrderHeaderId;
            objHeader.WorkplaceId = PurchasingUtils.Convert.ToGuid(this.cboLocation.SelectedValue.ToString());
            objHeader.StaffId = DAL.Common.Config.CurrentUserId;
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
            objHeader.Status = PurchasingUtils.Convert.ToInt32(this.cboStatus.Text == "HOLD" ? DAL.Common.Enums.Status.Draft.ToString("d") : DAL.Common.Enums.Status.Active.ToString("d"));

            //// detail

            //// other
            objHeader.SupplierInvoiceNumber = this.txtSupplierCode.Text;

            objHeader.ModifiedBy = DAL.Common.Config.CurrentUserId;
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
            foreach (DataGridViewRow row in this.dgvDetailsList.Rows)
            {
                //// 判断detailid 和 productid 是否为空，不为空才执行 保存/删除 操作
                if (DAL.Common.Utility.IsGUID(row.Cells[dgvDetailsList.Columns["colDetailsId"].Index].Value.ToString()) && DAL.Common.Utility.IsGUID(row.Cells[dgvDetailsList.Columns["colProductId"].Index].Value.ToString()))
                {
                    System.Guid detailId = new Guid(row.Cells[dgvDetailsList.Columns["colDetailsId"].Index].Value.ToString());
                    PurchaseOrderReceiveDetails objDetail = PurchaseOrderReceiveDetails.Load(detailId);
                    if (objDetail == null)
                    {
                        objDetail = new PurchaseOrderReceiveDetails();
                        objDetail.ReceiveHeaderId = this.ReceivingHeaderId;
                        objDetail.LineNumber = Convert.ToInt32(row.Cells[dgvDetailsList.Columns["colLN"].Index].Value.ToString().Length == 0 ? "1" : row.Cells[dgvDetailsList.Columns["colLN"].Index].Value.ToString());
                    }

                    objDetail.ProductId = new Guid(row.Cells[dgvDetailsList.Columns["colProductId"].Index].Value.ToString());
                    objDetail.ReceivedQty = Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value== null || row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString().Length == 0 ? "0" : row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString());
                    objDetail.UnitCost = Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colCost"].Index].Value == null || row.Cells[dgvDetailsList.Columns["colCost"].Index].Value.ToString().Length == 0 ? "0" : row.Cells[dgvDetailsList.Columns["colCost"].Index].Value.ToString());
                    objDetail.DiscountPcn = Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colDiscount"].Index].Value == null || row.Cells[dgvDetailsList.Columns["colDiscount"].Index].Value.ToString().Length == 0 ? "0" : row.Cells[dgvDetailsList.Columns["colDiscount"].Index].Value.ToString());
                    objDetail.NetUnitCost = objDetail.UnitCost * ((100 - objDetail.DiscountPcn) / 100);
                    objDetail.NetUnitCostCoefficient = objDetail.NetUnitCost * Convert.ToDecimal(this.txtCoeffcient.Text);
                    objDetail.BillQty = Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colBillQty"].Index].Value == null || row.Cells[dgvDetailsList.Columns["colBillQty"].Index].Value.ToString().Length == 0 ? "0" : row.Cells[dgvDetailsList.Columns["colBillQty"].Index].Value.ToString());
                    objDetail.BillUnitAmount = Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colBillCost"].Index].Value == null || row.Cells[dgvDetailsList.Columns["colBillCost"].Index].Value.ToString().Length == 0 ? "0" : row.Cells[dgvDetailsList.Columns["colBillCost"].Index].Value.ToString());
                    objDetail.Notes = row.Cells[dgvDetailsList.Columns["colRemark"].Index].Value.ToString();

                    if (row.Cells[dgvDetailsList.Columns["colStatus"].Index].Value != null && row.Cells[dgvDetailsList.Columns["colStatus"].Index].Value.ToString().Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
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
        //void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        //{
        //    switch (strAction)
        //    {
        //        case "rdlPDF":
        //            this.RdlToPdf();
        //            break;
        //    }
        //}

        /// <summary>
        /// RDLs to PDF.
        /// </summary>
        private void RdlToPdf()
        {
            //string[,] param = 
            //{
            //    { "PrintedOn", DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat()) },
            //    { "STKCODE", RT2020.SystemInfo.Settings.GetSystemLabelByKey("STKCODE") },
            //    { "Appendix1", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1") },
            //    { "Appendix2", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2") },
            //    { "Appendix3", RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3") },
            //    { "Company", RT2020.SystemInfo.Settings.GetSystemLabelByKey("Company") }, ////test
            //    { "DateFormat", RT2020.SystemInfo.Settings.GetDateFormat() }
            //};

            //RT2020.Controls.Reporting.RdlExport rdlExport = new RT2020.Controls.Reporting.RdlExport();

            //rdlExport.Datasource = this.BindData();
            //rdlExport.ReportName = "RT2020.Purchasing.Wizard.Reports.POWorksheetRdl.rdlc";
            //rdlExport.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwRptPurchaseOrder";
            //rdlExport.Parameters = param;

            //rdlExport.ToPdf();
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
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        #endregion

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
                this.txtSupplierCode.Text = objHeader.SupplierInvoiceNumber;

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
            DataGridViewRow row = this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex];

            this.txtDescription.Text = row.Cells[dgvDetailsList.Columns["colDescription"].Index].Value.ToString();
            this.txtRecQty.Text = row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString();
            this.txtUnitCost.Text = row.Cells[dgvDetailsList.Columns["colCost"].Index].Value.ToString();
            this.txtDisc.Text = row.Cells[dgvDetailsList.Columns["colDiscount"].Index].Value.ToString();
            this.txtRemarks.Text = row.Cells[dgvDetailsList.Columns["colRemark"].Index].Value.ToString();

            this.txtOrderQty.Text = row.Cells[dgvDetailsList.Columns["colOrderedQty"].Index].Value.ToString();
            this.txtLastTotal.Text = (PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colOrderedQty"].Index].Value.ToString()) - PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString())).ToString("n2");
            this.txtRetailPrice.Text = row.Cells[dgvDetailsList.Columns["colRetailPrice"].Index].Value.ToString();
            this.txtTotalRetail.Text = (PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString()) * PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRetailPrice"].Index].Value.ToString())).ToString("n2");

            this.txtBillQty.Text = row.Cells[dgvDetailsList.Columns["colBillQty"].Index].Value.ToString();
            this.txtBillUnitCost.Text = row.Cells[dgvDetailsList.Columns["colBillCost"].Index].Value.ToString();
            this.txtBillTotal.Text = (PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colBillQty"].Index].Value.ToString()) * PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colBillCost"].Index].Value.ToString())).ToString("n2");

            //this.basicProduct.SelectedItem = PurchasingUtils.Convert.ToGuid(objItem.SubItems[20].Text);
            this.ProductId = PurchasingUtils.Convert.ToGuid(row.Cells[dgvDetailsList.Columns["colProductId"].Index].Value.ToString());
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
                    strPoType = DAL.Common.Enums.POType.LPO.ToString();
                    break;
                case 2:
                    strPoType = DAL.Common.Enums.POType.OPO.ToString();
                    break;
                case 0:
                default:
                    strPoType = DAL.Common.Enums.POType.FPO.ToString();
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
                sql.Append("SELECT  ReceiveDetailsId AS DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
                sql.Append(" OrderedQty, OrderedQty-ReceivedQty AS LastQty , ReceivedQty, UnitCost, DiscountPcn, NetUnitCost, RetailPrice, ReceivedQty*RetailPrice AS TotalRetail, BillQty, BillUnitAmount, Notes, ProductId ");
                sql.Append(" FROM vwPurchaseOrderReceiveDetailsList ");
                sql.Append(" WHERE ReceiveHeaderId = '").Append(this.ReceivingHeaderId.ToString()).Append("'");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql.ToString();
                cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
                {
                    this.dgvDetailsList.DataSource = ds.Tables[0];

                    #region 2013.08.18 paulus: 我估計 david 改用 data binding 所以取消了以下的 code
                    //while (reader.Read())
                    //{
                    //    ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                    //    listItem.SubItems.Add((iCount + 1).ToString());             //// LN
                    //    listItem.SubItems.Add(string.Empty);                        //// Status
                    //    listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                    //    listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                    //    listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                    //    listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                    //    listItem.SubItems.Add(reader.GetString(6));                 ////Description
                    //    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                    //    listItem.SubItems.Add((reader.GetDecimal(7) - reader.GetDecimal(11)).ToString("n0"));     //// Last Rec Qty = Order Qty - Rec Qty
                    //    listItem.SubItems.Add(reader.GetDecimal(11).ToString("n0"));     //// Rec Qty
                    //    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                    //    listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                    //    listItem.SubItems.Add(reader.GetDecimal(10).ToString("n2"));     //// Net Cost
                    //    listItem.SubItems.Add(reader.GetDecimal(12).ToString("n2"));     //// Retail Price
                    //    listItem.SubItems.Add((reader.GetDecimal(11) * reader.GetDecimal(12)).ToString("n2"));     //// Total Retail = Rec Qty × Retail Price
                    //    listItem.SubItems.Add(reader.GetDecimal(13).ToString("n0"));     //// Bill Qty
                    //    listItem.SubItems.Add(reader.GetDecimal(14).ToString("n2"));     //// Bill Cost = BillUnitAmount / BillQty
                    //    listItem.SubItems.Add(reader.GetDecimal(14).ToString("n2"));     //// Bill Total = Bill Qty × Bill Unit Cost
                    //    listItem.SubItems.Add(reader.GetString(15));                //// Notes
                    //    listItem.SubItems.Add(reader.GetGuid(16).ToString());       //// ProductId

                    //    iCount++;
                    //}
                    #endregion
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
                cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
                {
                    ds.Tables[0].Columns.Add("RetailPrice");
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["RetailPrice"] = this.GetStockCode(new Guid(ds.Tables[0].Rows[i]["ProductId"].ToString()), 0, "RETAILPRICE").ToString("n0");
                    }

                    this.dgvDetailsList.DataSource = ds.Tables[0];

                    #region 2013.08.18 paulus: 我估計 david 改用 data binding 所以取消了以下的 code
                    //while (reader.Read())
                    //{
                    //    ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                    //    listItem.SubItems.Add((iCount + 1).ToString());             //// LN
                    //    listItem.SubItems.Add(string.Empty);                        //// Status
                    //    listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                    //    listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                    //    listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                    //    listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                    //    listItem.SubItems.Add(reader.GetString(6));                 ////Description
                    //    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                    //    listItem.SubItems.Add("0");     //// Last Rec Qty
                    //    listItem.SubItems.Add("0");     //// Rec Qty
                    //    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                    //    listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                    //    listItem.SubItems.Add("0.00");     //// Net Cost
                    //    listItem.SubItems.Add(this.GetStockCode(reader.GetGuid(11), 0, "RETAILPRICE").ToString("n0"));     //// Retail Price
                    //    listItem.SubItems.Add("0.00");     //// Total Retail
                    //    listItem.SubItems.Add("0");     //// Bill Qty
                    //    listItem.SubItems.Add("0.00");     //// Bill Cost
                    //    listItem.SubItems.Add("0.00");     //// Bill Total
                    //    listItem.SubItems.Add(reader.GetString(10));                //// Notes
                    //    listItem.SubItems.Add(reader.GetGuid(11).ToString());       //// ProductId

                    //    iCount++;
                    //}
                    #endregion
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

        #region 2013.08.18 paulus: 我估計 david 取消以下的 code 但係又冇刪除
        /// <summary>
        /// Handles the SelectionChanged event of the BasicProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs"/> instance containing the event data.</param>
        //private void BasicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        //{
        //    this.txtDescription.Text = e.Description;
        //    this.txtUnitCost.Text = e.UnitCost.ToString("n2");
        //    this.txtRetailPrice.Text = e.UnitPrice.ToString("n2");
        //}
        #endregion

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
            if (this.dgvDetailsList.Rows != null)
            {
                if (this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[dgvDetailsList.Columns["colDetailsId"].Index].Value.ToString() != System.Guid.Empty.ToString())
                {
                    this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[dgvDetailsList.Columns["colStatus"].Index].Value = "REMOVED"; //// Status
                }
                else
                {
                    this.dgvDetailsList.Rows.Remove(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex]);
                    this.dgvDetailsList.Update();
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
            //string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
            //this.ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

            //if (this.IsDuplicated(stkCode, appendix1, appendix2, appendix3))
            //{
            //    ////this.Invoke(new EventHandler(btnEditItem_Click), new object[] { this, e });
            //    //MessageBox.Show(string.Format(Resources.Common.DuplicatedCode, "Stock Item"), string.Format(Resources.Common.DuplicatedCode, string.Empty));
            //}
            //else
            //{
            //    if (this.ProductId != System.Guid.Empty)
            //    {
            //        DataGridViewRow row = new DataGridViewRow();
            //        row.Cells[0].Value = System.Guid.Empty.ToString();
            //        row.Cells[1].Value = this.dgvDetailsList.Rows.Count.ToString();
            //        row.Cells[2].Value = "NEW"; //// Status
            //        row.Cells[3].Value = stkCode; //// Stock Code
            //        row.Cells[4].Value = appendix1; //// Appendix1
            //        row.Cells[5].Value = appendix2; //// Appendix2
            //        row.Cells[6].Value = appendix3; //// Appendix3
            //        row.Cells[7].Value = this.txtDescription.Text; //// Description
            //        row.Cells[8].Value = this.txtOrderQty.Text;     //// OrderedQty
            //        row.Cells[9].Value = (PurchasingUtils.Convert.ToDecimal(this.txtOrderQty.Text) - PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text)).ToString();     //// Last Rec Qty = Order Qty - Rec Qty
            //        row.Cells[10].Value = this.txtRecQty.Text;     //// Rec Qty
            //        row.Cells[11].Value = this.txtUnitCost.Text;     //// UnitCost
            //        row.Cells[12].Value = this.txtDisc.Text;     //// DiscountPcn
            //        row.Cells[13].Value = this.txtNetCost.Text;     //// Net Cost
            //        row.Cells[14].Value = this.txtRetailPrice.Text;     //// Retail Price
            //        row.Cells[15].Value = (PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtRetailPrice.Text)).ToString();     //// Total Retail = Rec Qty × Retail Price
            //        row.Cells[16].Value = this.txtBillQty.Text;     //// Bill Qty
            //        row.Cells[17].Value = this.txtBillUnitCost.Text;     //// Bill Cost 
            //        row.Cells[18].Value = (PurchasingUtils.Convert.ToDecimal(this.txtBillQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtBillUnitCost.Text)).ToString();     //// Bill Total = Bill Qty × Bill Unit Cost
            //        row.Cells[19].Value = this.txtRemarks.Text;                //// Notes
            //        row.Cells[20].Value = this.ProductId.ToString();       //// ProductId

            //        this.dgvDetailsList.Rows.Add(row);

            //        this.CalcTotal();
            //    }
            //}
        }

        /// <summary>
        /// Handles the Click event of the BtnEditItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetailsList.SelectedRows != null)
            {
                string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
                this.ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

                DataGridViewRow row = this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex];

                row.Cells[dgvDetailsList.Columns["colStatus"].Index].Value = row.Cells[2].Value == null ? "EDIT" : row.Cells[2].Value.ToString(); //// Status
                row.Cells[dgvDetailsList.Columns["colStockCode"].Index].Value = stkCode; //// Stock Code
                row.Cells[dgvDetailsList.Columns["colAppendix1"].Index].Value = appendix1; //// Appendix1
                row.Cells[dgvDetailsList.Columns["colAppendix2"].Index].Value = appendix2; //// Appendix2
                row.Cells[dgvDetailsList.Columns["colAppendix3"].Index].Value = appendix3; //// Appendix3
                row.Cells[dgvDetailsList.Columns["colDescription"].Index].Value = this.txtDescription.Text; //// Description
                row.Cells[dgvDetailsList.Columns["colOrderedQty"].Index].Value = this.txtOrderQty.Text; //// OrderedQty
                row.Cells[dgvDetailsList.Columns["colLastQty"].Index].Value = (PurchasingUtils.Convert.ToDecimal(this.txtOrderQty.Text) - PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text)).ToString("n0"); //// Last Rec Qty
                row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value = this.txtRecQty.Text; //// Rec Qty
                row.Cells[dgvDetailsList.Columns["colCost"].Index].Value = this.txtUnitCost.Text.Replace(",", ""); //// UnitCost
                row.Cells[dgvDetailsList.Columns["colDiscount"].Index].Value = PurchasingUtils.Convert.ToDecimal(this.txtDisc.Text); //// DiscountPcn
                row.Cells[dgvDetailsList.Columns["colNetCost"].Index].Value = this.txtNetCost.Text.Replace(",", ""); //// Net Cost
                row.Cells[dgvDetailsList.Columns["colRetailPrice"].Index].Value = PurchasingUtils.Convert.ToDecimal(this.txtRetailPrice.Text); //// Retail Price
                row.Cells[dgvDetailsList.Columns["colTotalRetail"].Index].Value = PurchasingUtils.Convert.ToDecimal((PurchasingUtils.Convert.ToDecimal(this.txtRecQty.Text) * PurchasingUtils.Convert.ToDecimal(this.txtRetailPrice.Text.Replace(",", ""))).ToString("n2")); //// Total Retail
                row.Cells[dgvDetailsList.Columns["colBillQty"].Index].Value = this.txtBillQty.Text; //// Bill Qty
                row.Cells[dgvDetailsList.Columns["colBillCost"].Index].Value = this.txtBillUnitCost.Text.Replace(",", ""); //// Bill Cost 
                row.Cells[dgvDetailsList.Columns["colBillTotal"].Index].Value = (PurchasingUtils.Convert.ToDecimal(this.txtBillQty.Text.Replace(",", "")) * PurchasingUtils.Convert.ToDecimal(this.txtBillUnitCost.Text.Replace(",", ""))).ToString("n2"); //// Bill Total
                row.Cells[dgvDetailsList.Columns["colRemark"].Index].Value = this.txtRemarks.Text; //// Notes
                row.Cells[dgvDetailsList.Columns["colProductId"].Index].Value = this.ProductId.ToString(); //// ProductId


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
            RT2020.DAL.Product objProd = RT2020.DAL.Product.Load(new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[dgvDetailsList.Columns["colProductId"].Index].Value.ToString()));
            if (objProd != null)
            {
                stkCode = objProd.STKCODE;
                appendix1 = objProd.APPENDIX1;
                appendix2 = objProd.APPENDIX2;
                appendix3 = objProd.APPENDIX3;

                this.ProductId = objProd.ProductId;
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

            foreach (DataGridViewRow row in this.dgvDetailsList.Rows)
            {
                if (stkCode.Length > 0)
                {
                    isDuplicated = (row.Cells[3].Value.ToString() == stkCode);
                    isDuplicated = isDuplicated & (row.Cells[dgvDetailsList.Columns["colAppendix1"].Index].Value.ToString() == appendix1);
                    isDuplicated = isDuplicated & (row.Cells[dgvDetailsList.Columns["colAppendix2"].Index].Value.ToString() == appendix2);
                    isDuplicated = isDuplicated & (row.Cells[dgvDetailsList.Columns["colAppendix3"].Index].Value.ToString() == appendix3);
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
            foreach (DataGridViewRow row in this.dgvDetailsList.Rows)
            {
                if (row.Cells[2].Value != null && row.Cells[2].Value.ToString() != "REMOVED")
                {
                    decimal totalRetail = PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString()) * PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRetailPrice"].Index].Value.ToString());
                    decimal recAmount = PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString()) * PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colCost"].Index].Value.ToString());
                    this.totalQty += PurchasingUtils.Convert.ToDecimal(row.Cells[dgvDetailsList.Columns["colRecQty"].Index].Value.ToString());
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
            if (this.dgvDetailsList.SelectedRows != null)
            {
                if (DAL.Common.Utility.IsGUID(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[dgvDetailsList.Columns["colDetailsId"].Index].Value.ToString()))
                {
                    this.LoadReceivingDetailInfo(new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[dgvDetailsList.Columns["colDetailsId"].Index].Value.ToString()));
                    this.ReceivingDetailId = new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[dgvDetailsList.Columns["colDetailsId"].Index].Value.ToString());
                    //this.selectedIndex = this.dgvDetailsList.CurrentCell.RowIndex;
                }
            }
        }



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

        private void dgvDetailsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = this.dgvDetailsList.CurrentCell.RowIndex;

            this.txtStockCode.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colStockCode"].Index].Value != null ? dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colStockCode"].Index].Value.ToString() : "";
            this.txtAppendix1.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colAppendix1"].Index].Value != null ? dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colAppendix1"].Index].Value.ToString() : "";
            this.txtAppendix2.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colAppendix2"].Index].Value != null ? dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colAppendix2"].Index].Value.ToString() : "";
            this.txtAppendix3.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colAppendix3"].Index].Value != null ? dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colAppendix3"].Index].Value.ToString() : "";
            this.txtDescription.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colDescription"].Index].Value != null ? dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colDescription"].Index].Value.ToString() : "";
            this.txtOrderQty.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colOrderedQty"].Index].Value != null ? Convert.ToInt32(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colOrderedQty"].Index].Value).ToString("n0") : "0";
            this.txtLastTotal.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colLastQty"].Index].Value != null ? Convert.ToInt32(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colLastQty"].Index].Value).ToString("n0") : "0";
            this.txtRetailPrice.Text = Convert.ToDecimal(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colRetailPrice"].Index].Value).ToString("n2");
            this.txtTotalRetail.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colTotalRetail"].Index].Value != null ? Convert.ToDecimal(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colTotalRetail"].Index].Value).ToString("n2") : "0.00";
            this.txtBillQty.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colBillQty"].Index].Value != null ? Convert.ToInt32(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colBillQty"].Index].Value).ToString("n0") : "0";
            this.txtBillUnitCost.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colBillCost"].Index].Value != null ? Convert.ToDecimal(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colBillCost"].Index].Value).ToString("n2") : "0.00";
            this.txtBillTotal.Text = dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colBillTotal"].Index].Value != null ? Convert.ToDecimal(dgvDetailsList.Rows[index].Cells[dgvDetailsList.Columns["colBillTotal"].Index].Value).ToString("n2") : "0.00";
        }



    }
}
