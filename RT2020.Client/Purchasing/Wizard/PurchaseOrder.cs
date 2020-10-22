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
using System.Text.RegularExpressions;

namespace RT2020.Client.Purchasing.Wizard
{
    public partial class PurchaseOrder : Form
    {
        private List<Inventory.GoodsReceive.DetailData> _Result = new List<RT2020.Client.Inventory.GoodsReceive.DetailData>();

        /// <summary>
        /// The selected Index. 
        /// </summary>
        private int selectedIndex = 0;

        /// <summary>
        /// The obj header id.
        /// </summary>
        private Guid orderHeaderId = System.Guid.Empty;

        /// <summary>
        /// The order detail id.
        /// </summary>
        private Guid orderDetailId = System.Guid.Empty;

        /// <summary>
        /// The product id.
        /// </summary>
        private Guid productId = System.Guid.Empty;

        public PurchaseOrder()
        {
            InitializeComponent();

            this.txtPurchaseOrderNo.Enabled = false;
            this.txtOrderAmount.Enabled = false;
            this.txtTotalQty.Enabled = false;
            this.txtNetCost.Enabled = false;
            this.txtCoeffcient.Enabled = false;
            this.txtLastUpdate.Enabled = false;
            this.txtLastUser.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtStockCode.Enabled = false;
            this.txtAppendix1.Enabled = false;
            this.txtAppendix2.Enabled = false;
            this.txtAppendix3.Enabled = false;

            this.FillCboList();
            this.LoadLastName();
            this.LoadLastUpdate();
            this.txtPaymentTerm.Text = "0";
            this.cboStatus.SelectedIndex = 0;
            this.cboPartialShipment.SelectedIndex = 0;
            this.txtPurchaseOrderNo.Text = "Auto-Generated";
            this.InitCurrency(!DAL.Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));

            Cursor.Current = Cursors.Default;
        }

        public PurchaseOrder(Guid objHeaderId)
        {
            InitializeComponent();

            this.txtPurchaseOrderNo.Enabled = false;
            this.txtOrderAmount.Enabled = false;
            this.txtTotalQty.Enabled = false;
            this.txtNetCost.Enabled = false;
            this.txtCoeffcient.Enabled = false;
            this.txtLastUpdate.Enabled = false;
            this.txtLastUser.Enabled = false;
            this.txtDescription.Enabled = false;
            this.txtStockCode.Enabled = false;
            this.txtAppendix1.Enabled = false;
            this.txtAppendix2.Enabled = false;
            this.txtAppendix3.Enabled = false;

            this.orderHeaderId = objHeaderId;
            this.FillCboList();
            this.LoadPurchaseOrderInfo();

            Cursor.Current = Cursors.Default;
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
        public Guid OrderDetailId
        {
            get { return this.orderDetailId; }
            set { this.orderDetailId = value; }
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
                        //RT2020.SystemInfo.Settings.RefreshMainList<DefaultPOList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        PurchaseOrder purchaseOrder = new PurchaseOrder(this.OrderHeaderId);
                        purchaseOrder.ShowDialog();
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
                        //RT2020.SystemInfo.Settings.RefreshMainList<DefaultPOList>();
                        this.Close();
                        PurchaseOrder purchaseOrder = new PurchaseOrder();
                        purchaseOrder.ShowDialog();
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
                        //RT2020.SystemInfo.Settings.RefreshMainList<DefaultPOList>();
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

        #region Load Purchase Order Header Info
        /// <summary>
        /// Loads the purchase order info.
        /// </summary>
        private void LoadPurchaseOrderInfo()
        {
            PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(this.orderHeaderId);
            if (objHeader != null)
            {
                this.txtPurchaseOrderNo.Text = objHeader.OrderNumber;
                string orderType = string.Empty;
                switch (objHeader.OrderType)
                {
                    case 0:
                        orderType = DAL.Common.Enums.POType.FPO.ToString();
                        break;
                    case 1:
                        orderType = DAL.Common.Enums.POType.LPO.ToString();
                        break;
                    case 2:
                        orderType = DAL.Common.Enums.POType.OPO.ToString();
                        break;
                }

                this.cboType.Text = orderType;

                this.txtOrderAmount.Text = this.GetTotalAmount().ToString("n2");

                this.cboSupplierCode.SelectedValue = objHeader.SupplierId;
                this.cboOperatorCode.SelectedValue = objHeader.StaffId;
                this.dtpOrderDate.Value = objHeader.OrderOn;
                this.dtpCancelDate.Value = objHeader.CancellationOn;
                this.dtpDeliveryDate.Value = objHeader.DeliverOn;
                this.cboLocation.SelectedValue = objHeader.WorkplaceId;
                this.cboCurrency.Text = objHeader.CurrencyCode;
                this.cboStatus.SelectedItem = (objHeader.Status == 0) ? "HOLD" : "POST";
                this.txtXRate.Text = objHeader.ExchangeRate.ToString("n6");

                this.cboPaymentMethod.SelectedValue = objHeader.TermsId;
                this.txtPaymentTerm.Text = objHeader.CreditDays.ToString();
                this.txtDeposit.Text = objHeader.DepositPercentage.ToString("n2");
                this.txtPaymentRemark.Text = objHeader.PaymentRemarks;
                this.txtGroupDiscount1.Text = objHeader.GroupDiscount1.ToString("n2");
                this.txtGroupDiscount2.Text = objHeader.GroupDiscount2.ToString("n2");
                this.txtGroupDiscount3.Text = objHeader.GroupDiscount3.ToString("n2");
                this.txtTypeDetail.Text = objHeader.TYPEDTL;
                this.cboPartialShipment.SelectedIndex = objHeader.PartialShipment ? 0 : 1;
                this.cboShipmentMethod.Text = objHeader.ShipmentMethod;
                this.txtShipmentRemark.Text = objHeader.ShipmentRemarks;
                this.txtLastUser.Text = this.GetStaffName(objHeader.ModifiedBy);
                this.txtFreightCharge.Text = objHeader.FreightChargePcn.ToString("n2");
                this.txtHandlingCharge.Text = objHeader.HandlingChargePcn.ToString("n2");
                this.txtInsuranceCharge.Text = objHeader.InsuranceChargePcn.ToString("n2");
                this.txtOtherCharge.Text = objHeader.OtherChargesPcn.ToString("n2");

                this.txtTotalQty.Text = this.GetTotalQty().ToString("n0");

                this.GetNetCost(objHeader.TotalCost, objHeader.GroupDiscount1, objHeader.GroupDiscount2, objHeader.GroupDiscount3, objHeader.FreightChargeAmt, objHeader.HandlingChargeAmt, objHeader.InsuranceChargeAmt, objHeader.OtherChargesAmt, objHeader.ChargeCoefficient);

                this.txtCoeffcient.Text = objHeader.ChargeCoefficient.ToString("n6");
                this.txtLastUpdate.Text = objHeader.ModifiedOn.ToShortDateString();

                this.txtDeliveryAddress.Text = objHeader.DeliveryAddress;
                this.txtContactPerson.Text = objHeader.ContactPerson;
                this.txtContactTel.Text = objHeader.ContactPhone;
                this.txtPoRemark1.Text = objHeader.Remarks1;
                this.txtPoRemark2.Text = objHeader.Remarks2;
                this.txtPoRemark3.Text = objHeader.Remarks3;

                this.BindPurchaseOrderDetailsInfo();
            }
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
        private void GetNetCost(decimal totalCost, decimal groupDiscount1, decimal groupDiscount2, decimal groupDiscount3, decimal freightChargeAmt, decimal handlingChargeAmt, decimal insuranceChargeAmt, decimal otherChargesAmt, decimal chargeCoefficient)
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
        /// Gets the total qty.
        /// </summary>
        /// <returns>The total qty</returns>
        private decimal GetTotalQty()
        {
            decimal result = 0;

            string sql = "OrderHeaderId = '" + this.OrderHeaderId.ToString() + "'";
            PurchaseOrderDetailsCollection objDetails = PurchaseOrderDetails.LoadCollection(sql);
            foreach (PurchaseOrderDetails objDetail in objDetails)
            {
                result += objDetail.OrderedQty;
            }

            return result;
        }

        /// <summary>
        /// Gets the total amount.
        /// </summary>
        /// <returns>The total amount.</returns>
        private decimal GetTotalAmount()
        {
            decimal result = 0;

            string sql = "OrderHeaderId = '" + this.OrderHeaderId.ToString() + "'";
            PurchaseOrderDetailsCollection objDetails = PurchaseOrderDetails.LoadCollection(sql);
            foreach (PurchaseOrderDetails objDetail in objDetails)
            {
                decimal disc = (100 - objDetail.DiscountPcn) / 100;
                result += objDetail.OrderedQty * objDetail.UnitCost * disc;
            }

            return result;
        }

        #endregion

        #region Load PurchaseOrder Detail Info
        /// <summary>
        /// Loads the purchase order details info.
        /// </summary>
        /// <param name="detailId">The detail id.</param>
        private void LoadPurchaseOrderDetailsInfo(Guid detailId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" OrderedQty, UnitCost, DiscountPcn, Notes, ProductId ");
            sql.Append(" FROM vwPurchaseOrderDetailsList ");
            sql.Append(" WHERE DetailsId = '").Append(detailId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    this.txtDescription.Text = reader.GetString(6);
                    this.txtQty.Text = reader.GetDecimal(7).ToString("n0");
                    this.txtUnitCost.Text = reader.GetDecimal(8).ToString("n2");
                    this.txtDisc.Text = reader.GetDecimal(9).ToString("n2");
                    this.txtRemarks.Text = reader.GetString(10);

                    //this.basicProduct.SelectedItem = reader.GetGuid(11);
                    this.ProductId = reader.GetGuid(11);
                }
            }
        }
        #endregion

        #region Load Last Name & Last Update
        /// <summary>
        /// Loads the name of the staff fuff.
        /// </summary>
        private void LoadLastName()
        {
            Staff objStaff = Staff.Load(DAL.Common.Config.CurrentUserId);
            if (objStaff != null)
            {
                this.txtLastUser.Text = objStaff.StaffNumber;
            }
        }

        /// <summary>
        /// Loads the last update.
        /// </summary>
        private void LoadLastUpdate()
        {
            this.txtLastUpdate.Text = Common.DateTimeHelper.DateTimeToString(DateTime.Now, false);
        }
        #endregion

        #region Init Currency
        /// <summary>
        /// Inits the currency.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        private void InitCurrency(string currencyCode)
        {
            string sql = "CurrencyCode = '" + currencyCode + "'";
            Currency objCny = Currency.LoadWhere(sql);
            if (objCny != null)
            {
                this.InitCurrency(objCny.CurrencyId);
            }
            else
            {
                this.InitCurrency(DAL.Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
            }
        }

        /// <summary>
        /// Inits the currency.
        /// </summary>
        /// <param name="selectedCurrency">The selected currency.</param>
        private void InitCurrency(Guid selectedCurrency)
        {
            Currency objCurrency = Currency.Load(selectedCurrency);
            if (objCurrency != null)
            {
                this.txtXRate.Text = objCurrency.ExchangeRate.ToString("n6");
                this.txtCoeffcient.Text = objCurrency.ExchangeRate.ToString("n6");
            }
        }
        #endregion

        #region Fill Combo List
        /// <summary>
        /// Fills the cbo list.
        /// </summary>
        private void FillCboList()
        {
            this.FillPoType();
            this.FillSupplierList();
            this.FillOperationList();
            this.FillCurrencyList();
            this.FillLocationList();
            this.FillShipmentMethodList();
            this.FillSupplierTermsList();
        }

        /// <summary>
        /// Fills the type of the po.
        /// </summary>
        private void FillPoType()
        {
            this.cboType.Items.Add("FPO");
            this.cboType.Items.Add("LPO");
            this.cboType.Items.Add("OPO");
            this.cboType.SelectedIndex = 0;

        }

        /// <summary>
        /// Fills the supplier list.
        /// </summary>
        private void FillSupplierList()
        {
            cboSupplierCode.Items.Clear();

            RT2020.DAL.SupplierCollection supplierList = RT2020.DAL.Supplier.LoadCollection(new String[] { "SupplierCode" }, true);
            cboSupplierCode.DataSource = supplierList;
            cboSupplierCode.DisplayMember = "SupplierCode";
            cboSupplierCode.ValueMember = "SupplierId";

            cboSupplierCode.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the operation list.
        /// </summary>
        private void FillOperationList()
        {
            cboOperatorCode.Items.Clear();

            RT2020.DAL.StaffCollection staffList = RT2020.DAL.Staff.LoadCollection(new String[] { "StaffNumber" }, true);
            cboOperatorCode.DataSource = staffList;
            cboOperatorCode.DisplayMember = "StaffNumber";
            cboOperatorCode.ValueMember = "StaffId";

            cboOperatorCode.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the currency list.
        /// </summary>
        private void FillCurrencyList()
        {
            cboCurrency.Items.Clear();

            RT2020.DAL.CurrencyCollection currencyList = Currency.LoadCollection();
            cboCurrency.DataSource = currencyList;
            cboCurrency.DisplayMember = "CurrencyCode";
            cboCurrency.ValueMember = "CurrencyId";

            cboCurrency.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the location list.
        /// </summary>
        private void FillLocationList()
        {
            this.cboLocation.Items.Clear();

            DAL.WorkplaceCollection workplaceList = DAL.Workplace.LoadCollection(new String[] { "WorkplaceCode" }, true);
            this.cboLocation.DataSource = workplaceList;
            this.cboLocation.DisplayMember = "WorkplaceCode";
            this.cboLocation.ValueMember = "WorkplaceId";

            this.cboLocation.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the shipment method list.
        /// </summary>
        private void FillShipmentMethodList()
        {
            this.cboShipmentMethod.Items.Clear();

            RT2020.DAL.ShipmentMethodCollection shipmentMethodList = RT2020.DAL.ShipmentMethod.LoadCollection(new String[] { "MethodCode" }, true);
            this.cboShipmentMethod.DataSource = shipmentMethodList;
            this.cboShipmentMethod.DisplayMember = "MethodCode";
            this.cboShipmentMethod.ValueMember = "MethodId";

            this.cboShipmentMethod.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the supplier terms list.
        /// </summary>
        private void FillSupplierTermsList()
        {
            this.cboPaymentMethod.Items.Clear();

            RT2020.DAL.SupplierTermsCollection supplierTermsList = DAL.SupplierTerms.LoadCollection(new String[] { "TermsCode" }, true);
            this.cboPaymentMethod.DataSource = supplierTermsList;
            this.cboPaymentMethod.DisplayMember = "TermsCode";
            this.cboPaymentMethod.ValueMember = "TermsId";

            this.cboPaymentMethod.SelectedIndex = 0;
        }
        #endregion

        #region Save Purchase Order Header Info
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            if (this.dgvDetailsList.Rows.Count <= 0)
            {
                MessageBox.Show("Does not allow saving record without details", "Save Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabGoodsREJ.SelectedIndex = 1;
                return;
            }

            PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(this.OrderHeaderId);
            int type = 0;
            switch (this.cboType.SelectedItem.ToString().ToUpper())
            {
                case "FPO":
                default:
                    this.txtPurchaseOrderNo.Text = Common.Utility.QueuingTxNumber(DAL.Common.Enums.POType.FPO);
                    type = Convert.ToInt32(DAL.Common.Enums.POType.FPO);
                    break;
                case "LPO":
                    this.txtPurchaseOrderNo.Text = Common.Utility.QueuingTxNumber(DAL.Common.Enums.POType.LPO);
                    type = Convert.ToInt32(DAL.Common.Enums.POType.LPO);
                    break;
                case "OPO":
                    this.txtPurchaseOrderNo.Text = Common.Utility.QueuingTxNumber(DAL.Common.Enums.POType.OPO);
                    type = Convert.ToInt32(DAL.Common.Enums.POType.OPO);
                    break;
            }

            if (objHeader == null)
            {
                objHeader = new PurchaseOrderHeader();

                objHeader.CreatedBy = DAL.Common.Config.CurrentUserId;
                objHeader.CreatedOn = DateTime.Now;

                objHeader.OrderNumber = this.txtPurchaseOrderNo.Text;
            }

            //// main
            objHeader.OrderType = type;
            objHeader.SupplierId = PurchasingUtils.Convert.ToGuid(this.cboSupplierCode.SelectedValue.ToString());
            objHeader.StaffId = PurchasingUtils.Convert.ToGuid(this.cboOperatorCode.SelectedValue.ToString());
            objHeader.OrderOn = this.dtpOrderDate.Value;
            objHeader.DeliverOn = this.dtpDeliveryDate.Value;
            objHeader.CancellationOn = this.dtpCancelDate.Value;
            objHeader.TermsId = (this.cboPaymentMethod.SelectedIndex == -1) ? System.Guid.Empty : new Guid(this.cboPaymentMethod.SelectedValue.ToString());
            objHeader.CreditDays = PurchasingUtils.Convert.ToInt32(this.txtPaymentTerm.Text);
            objHeader.DepositPercentage = PurchasingUtils.Convert.ToDecimal(this.txtDeposit.Text);
            objHeader.PaymentRemarks = this.txtPaymentRemark.Text;
            objHeader.WorkplaceId = PurchasingUtils.Convert.ToGuid(this.cboLocation.SelectedValue.ToString());
            objHeader.CurrencyCode = this.cboCurrency.Text;
            objHeader.GroupDiscount1 = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount1.Text);
            objHeader.GroupDiscount2 = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount2.Text);
            objHeader.GroupDiscount3 = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount3.Text);
            objHeader.TYPEDTL = this.txtTypeDetail.Text;
            objHeader.PartialShipment = this.cboPartialShipment.SelectedItem.ToString().ToUpper() == "YES" ? true : false;
            objHeader.ShipmentMethod = this.cboShipmentMethod.SelectedIndex == -1 ? String.Empty : this.cboShipmentMethod.Text;
            objHeader.ShipmentRemarks = this.txtShipmentRemark.Text;
            objHeader.Status = Convert.ToInt32(this.cboStatus.Text == "HOLD" ? DAL.Common.Enums.Status.Draft.ToString("d") : DAL.Common.Enums.Status.Active.ToString("d"));

            objHeader.ExchangeRate = PurchasingUtils.Convert.ToDecimal(this.txtXRate.Text);
            objHeader.TotalCost = PurchasingUtils.Convert.ToDecimal(this.txtOrderAmount.Text);
            objHeader.TotalQty = PurchasingUtils.Convert.ToDecimal(this.txtTotalQty.Text);
            objHeader.FreightChargePcn = PurchasingUtils.Convert.ToDecimal(this.txtFreightCharge.Text);
            objHeader.FreightChargeAmt = objHeader.FreightChargePcn * objHeader.TotalCost;
            objHeader.HandlingChargePcn = PurchasingUtils.Convert.ToDecimal(this.txtHandlingCharge.Text);
            objHeader.HandlingChargeAmt = objHeader.HandlingChargePcn * objHeader.TotalCost;
            objHeader.InsuranceChargePcn = PurchasingUtils.Convert.ToDecimal(this.txtInsuranceCharge.Text);
            objHeader.InsuranceChargeAmt = objHeader.InsuranceChargePcn * objHeader.TotalCost;
            objHeader.OtherChargesPcn = PurchasingUtils.Convert.ToDecimal(this.txtOtherCharge.Text);
            objHeader.OtherChargesAmt = objHeader.OtherChargesPcn * objHeader.TotalCost;
            objHeader.ChargeCoefficient = PurchasingUtils.Convert.ToDecimal(this.txtCoeffcient.Text);

            //// detail

            //// other
            objHeader.DeliveryAddress = this.txtDeliveryAddress.Text;
            objHeader.ContactPerson = this.txtContactPerson.Text;
            objHeader.ContactPhone = this.txtContactTel.Text;
            objHeader.Remarks1 = this.txtPoRemark1.Text;
            objHeader.Remarks2 = this.txtPoRemark2.Text;
            objHeader.Remarks3 = this.txtPoRemark3.Text;

            objHeader.ModifiedBy = DAL.Common.Config.CurrentUserId;
            objHeader.ModifiedOn = DateTime.Now;

            objHeader.Save();

            this.OrderHeaderId = objHeader.OrderHeaderId;

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
                if (DAL.Common.Utility.IsGUID(row.Cells[0].Value.ToString().Trim()) && DAL.Common.Utility.IsGUID(row.Cells[13].Value.ToString().Trim()))
                {
                    System.Guid detailId = new Guid(row.Cells[0].Value.ToString());
                    PurchaseOrderDetails objDetail = PurchaseOrderDetails.Load(detailId);
                    if (objDetail == null)
                    {
                        objDetail = new PurchaseOrderDetails();
                        objDetail.OrderHeaderId = this.orderHeaderId;
                        objDetail.LineNumber = PurchasingUtils.Convert.ToInt32(row.Cells[1].Value.ToString().Length == 0 ? "1" : row.Cells[1].Value.ToString());
                    }

                    objDetail.ProductId = new Guid(row.Cells[13].Value.ToString().Trim());
                    objDetail.OrderedQty = PurchasingUtils.Convert.ToDecimal(row.Cells[8].Value.ToString().Length == 0 ? "0" : row.Cells[8].Value.ToString());
                    objDetail.UnitCost = PurchasingUtils.Convert.ToDecimal(row.Cells[9].Value.ToString().Length == 0 ? "0" : row.Cells[9].Value.ToString());
                    objDetail.DiscountPcn = PurchasingUtils.Convert.ToDecimal(row.Cells[10].Value.ToString().Length == 0 ? "0" : row.Cells[10].Value.ToString());
                    objDetail.TotalQtyReceived = PurchasingUtils.Convert.ToDecimal(row.Cells[11].Value.ToString().Length == 0 ? "0" : row.Cells[11].Value.ToString());
                    objDetail.NetUnitCost = objDetail.UnitCost * ((100 - objDetail.DiscountPcn) / 100);
                    objDetail.NetUnitCostCoefficient = objDetail.NetUnitCost * PurchasingUtils.Convert.ToDecimal(this.txtCoeffcient.Text);
                    objDetail.Notes = row.Cells[12].Value.ToString();

                    if (row.Cells[2].Value.ToString().Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
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
            PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(this.OrderHeaderId);
            if (objHeader != null)
            {
                ////oHeader.TotalAmount = PurchasingUtils.Convert.ToDecimal(Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text.Trim() : "0");

                objHeader.Save();
            }
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
                    PurchaseOrder purchaseOrder = new PurchaseOrder();
                    purchaseOrder.ShowDialog();
                }
            }
            else
            {
                ////tabGoodsADJ.SelectedIndex = 0;
            }
        }
        #endregion

        #region Bind PurchaseOrder Detail List
        /// <summary>
        /// Binds the purchase order details info.
        /// </summary>
        private void BindPurchaseOrderDetailsInfo()
        {
            int iCount = 0;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber,'' AS Status, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" OrderedQty, UnitCost, DiscountPcn,OrderedQty*UnitCost*(DiscountPcn/100) AS SubTotal, Notes, ProductId  ");
            sql.Append(" FROM vwPurchaseOrderDetailsList ");
            sql.Append(" WHERE HeaderId = '").Append(this.OrderHeaderId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                dgvDetailsList.DataSource = ds.Tables[0];

                //while (reader.Read())
                //{
                //    decimal qty = reader.GetDecimal(7);
                //    decimal unitPrice = reader.GetDecimal(8);
                //    decimal disc = (reader.GetDecimal(9) == 0) ? 1 : (reader.GetDecimal(9) / 100);
                //    decimal amt = qty * unitPrice * disc;

                //    ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                //    listItem.SubItems.Add((iCount + 1).ToString());             //// LN
                //    listItem.SubItems.Add(string.Empty);                        //// Status
                //    listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                //    listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                //    listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                //    listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                //    listItem.SubItems.Add(reader.GetString(6));                 ////Description
                //    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                //    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                //    listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                //    listItem.SubItems.Add(amt.ToString("n2"));                  //// Sub Total
                //    listItem.SubItems.Add(reader.GetString(10));                //// Notes
                //    listItem.SubItems.Add(reader.GetGuid(11).ToString());       //// ProductId

                //    iCount++;
                //}
            }

            this.lblLineCount.Text = this.dgvDetailsList.Rows.Count.ToString();
        }

        private void BindCAPDetailsInfo(DataTable datasource)
        {
            this.dgvDetailsList.AutoGenerateColumns = false;

            this.dgvDetailsList.DataSource = datasource;
        }

        private DataTable GetData()
        {
            DataTable table = new DataTable();

            if (this.dgvDetailsList.DataSource == null)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
                sql.Append(" OrderedQty, UnitCost, DiscountPcn, Notes, ProductId, '' AS Status, OrderedQty*UnitCost*(DiscountPcn/100) AS SubTotal ");
                sql.Append(" FROM vwPurchaseOrderDetailsList ");
                sql.Append(" WHERE HeaderId = '").Append(this.OrderHeaderId.ToString()).Append("'");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql.ToString();
                cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

                table = ds.Tables[0];
                if (table.Rows.Count == 0)
                {
                    GetDataFromList(ref table);
                }
            }
            else
            {
                table = (DataTable)this.dgvDetailsList.DataSource;
                GetDataFromList(ref table);
            }

            return table;
        }

        private void GetDataFromList(ref DataTable table)
        {

            foreach (Inventory.GoodsReceive.DetailData detailData in _Result)
            {
                Product product = Product.Load(detailData.ProductId);
                if (product != null)
                {
                    DataRow[] rows = table.Select(string.Format("ProductId = '{0}'", product.ProductId));
                    if (rows.Length > 0)
                    {
                        for (int i = 0; i < rows.Length; i++)
                        {
                            DataRow row = rows[i];
                            if (!row["OrderedQty"].Equals(detailData.Qty))
                            {
                                row.BeginEdit();
                                row["Status"] = "EDIT";
                                row["OrderedQty"] = detailData.Qty;
                                row["UnitCost"] = detailData.UnitAmount;
                                row.EndEdit();
                            }
                        }
                    }
                    else
                    {
                        decimal disc = 0;
                        decimal disc2 = 0;
                        string sql = string.Format("ProductId = '{0}'", product.ProductId);
                        PurchaseOrderDetails orderDetail = PurchaseOrderDetails.LoadWhere(sql);
                        if (orderDetail != null)
                        {
                            disc = (orderDetail.DiscountPcn == 0) ? 1 : (orderDetail.DiscountPcn / 100);
                            disc2 = orderDetail.DiscountPcn;
                        }

                        decimal unitPrice = detailData.UnitAmount > 0 ? detailData.UnitAmount : Convert.ToDecimal(product.RetailPrice.ToString("n2"));

                        DataRow row = table.NewRow();
                        row["DetailsId"] = Guid.Empty;
                        row["LineNumber"] = table.Rows.Count + 1;
                        row["Status"] = "NEW";
                        row["STKCODE"] = product.STKCODE;
                        row["APPENDIX1"] = product.APPENDIX1;
                        row["APPENDIX2"] = product.APPENDIX2;
                        row["APPENDIX3"] = product.APPENDIX3;
                        row["ProductName"] = product.ProductName;
                        row["OrderedQty"] = detailData.Qty;
                        row["UnitCost"] = unitPrice;
                        row["DiscountPcn"] = disc2;
                        row["ProductId"] = product.ProductId;
                        row["SubTotal"] = detailData.Qty * unitPrice * disc;
                        table.Rows.Add(row);
                    }
                }
            }
        }

        #endregion

        #region Delete
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        private void Delete()
        {
            PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(this.OrderHeaderId);
            if (objHeader != null)
            {
                string sql = "OrderHeaderId = '" + objHeader.OrderHeaderId.ToString() + "'";

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
            PurchaseOrderDetailsCollection objDetailList = PurchaseOrderDetails.LoadCollection(objSql);
            foreach (PurchaseOrderDetails objDetail in objDetailList)
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
            //    { "PrintedOn", DateTime.Now.ToString(Common.DateTimeHelper.GetDateTimeFormat()) },
            //    { "STKCODE", Common.Utility.GetSystemLabelByKey("STKCODE") },
            //    { "Appendix1", Common.Utility.GetSystemLabelByKey("APPENDIX1") },
            //    { "Appendix2", Common.Utility.GetSystemLabelByKey("APPENDIX2") },
            //    { "Appendix3", Common.Utility.GetSystemLabelByKey("APPENDIX3") },
            //    { "Company", Common.Utility.GetSystemLabelByKey("Company") }, ////test
            //    { "DateFormat", Common.DateTimeHelper.GetDateFormat() }
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
FROM vwRptPurchaseOrder
WHERE	OrderHeaderId = '" + this.OrderHeaderId.ToString() + "'";

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


        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvDetailsList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dgvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dgvDetailsList.SelectedRows != null)
            {
                if (DAL.Common.Utility.IsGUID(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                {
                    this.LoadPurchaseOrderDetailsInfo(new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                    this.orderDetailId = new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    this.selectedIndex = this.dgvDetailsList.CurrentCell.RowIndex;
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

            foreach (DataGridViewRow row in this.dgvDetailsList.Rows)
            {
                if (stkCode.Length > 0)
                {
                    isDuplicated = (row.Cells[3].Value == stkCode);
                    isDuplicated = isDuplicated & (row.Cells[4].Value == appendix1);
                    isDuplicated = isDuplicated & (row.Cells[5].Value == appendix2);
                    isDuplicated = isDuplicated & (row.Cells[6].Value == appendix3);
                }
            }

            return isDuplicated;
        }

        /// <summary>
        /// Handles the Click event of the BtnAddItem control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnAddItem_Click(object sender, EventArgs e)
        {
            Inventory.GoodsReceive.Detail detail = new RT2020.Client.Inventory.GoodsReceive.Detail();
            detail.Closed += new EventHandler(detailData_Closed);
            detail.ShowDialog();

            this.CalcTotal();
        }

        /// <summary>
        /// Calcs the total.
        /// </summary>
        private void CalcTotal()
        {
            decimal ttlQty = 0, ttlAmount = 0;
            foreach (DataGridViewRow row in this.dgvDetailsList.Rows)
            {
                if (row.Cells[2].Value.ToString() != "REMOVED")
                {
                    ttlQty += PurchasingUtils.Convert.ToDecimal(row.Cells[8].Value.ToString().Length > 0 ? row.Cells[8].Value.ToString() : "0");
                    ttlAmount += PurchasingUtils.Convert.ToDecimal(row.Cells[11].Value.ToString().Length > 0 ? row.Cells[11].Value.ToString() : "0");
                }
            }

            decimal coefficient = PurchasingUtils.Convert.ToDecimal(this.txtCoeffcient.Text);

            this.txtTotalQty.Text = ttlQty.ToString("n0");
            this.txtOrderAmount.Text = (ttlAmount * coefficient).ToString("n2");
        }

        /// <summary>
        /// Handles the Click event of the BtnRemove control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (this.dgvDetailsList.SelectedRows != null)
            {
                if (this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString() != System.Guid.Empty.ToString())
                {
                    this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[2].Value = "REMOVED"; //// Status
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
                row.Cells[2].Value = row.Cells[2].Value.ToString() != "NEW" ? "EDIT" : row.Cells[2].Value.ToString(); //// Status
                row.Cells[3].Value = stkCode; //// Stock Code
                row.Cells[4].Value = appendix1; //// Appendix1
                row.Cells[5].Value = appendix2; //// Appendix2
                row.Cells[6].Value = appendix3; //// Appendix3
                row.Cells[7].Value = this.txtDescription.Text; //// Description
                row.Cells[8].Value = this.txtQty.Text; //// Qty
                row.Cells[9].Value = Convert.ToDecimal(this.txtUnitCost.Text); //// Unit Cost
                row.Cells[10].Value = this.txtDisc.Text; //// DiscountPcn

                decimal qty = PurchasingUtils.Convert.ToDecimal(this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text);
                decimal unitPrice = PurchasingUtils.Convert.ToDecimal(this.txtUnitCost.Text.Length == 0 ? "0" : this.txtUnitCost.Text);
                decimal disc = PurchasingUtils.Convert.ToDecimal(this.txtDisc.Text);
                disc = (100 - disc) / 100;
                decimal amt = qty * unitPrice * disc;
                row.Cells[11].Value = amt; //// Amount
                row.Cells[12].Value = this.txtRemarks.Text; //// Remarks
                row.Cells[13].Value = this.productId.ToString(); //// ProductId

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
            RT2020.DAL.Product objProd = RT2020.DAL.Product.Load(new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[13].Value.ToString()));
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
        /// Handles the Leave event of the TxtXRate control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtXRate_Leave(object sender, EventArgs e)
        {
            this.txtCoeffcient.Text = this.txtXRate.Text;
        }

        /// <summary>
        /// Determines whether the specified expression is number.
        /// </summary>
        /// <param name="expression">The expression.</param>
        private void IsNumber(string expression)
        {
            Regex rex = new Regex(@"^[0-9]*$");
            Match match = rex.Match(expression);
            if (match.Success)
            {
                MessageBox.Show("Incorrect Number Format! (Number Format:123.12)");
            }
        }

        /// <summary>
        /// Handles the VisibleChanged event of the TxtFreightCharge control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TxtFreightCharge_VisibleChanged(object sender, EventArgs e)
        {
            this.IsNumber(this.txtFreightCharge.Text);
        }

        /// <summary>
        /// Handles the SelectedIndexChanged event of the CboCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.InitCurrency(!DAL.Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inventory.GoodsReceive.Detail detail = new RT2020.Client.Inventory.GoodsReceive.Detail();
            detail.Closed += new EventHandler(detailData_Closed);
            detail.ShowDialog();
        }

        void detailData_Closed(object sender, EventArgs e)
        {
            if (sender is Inventory.GoodsReceive.Detail)
            {
                Inventory.GoodsReceive.Detail detail = sender as Inventory.GoodsReceive.Detail;
                if (detail != null)
                {
                    _Result = detail.ResultList;
                    BindCAPDetailsInfo(GetData());
                }
            }
        }

        private void dgvDetailsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Inventory.GoodsReceive.Detail detail = new RT2020.Client.Inventory.GoodsReceive.Detail();
                detail.StockCode = this.dgvDetailsList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                detail.ResultList = SetDetailData(this.dgvDetailsList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                detail.Closed += new EventHandler(detailData_Closed);
                detail.ShowDialog();
            }
        }

        private List<Inventory.GoodsReceive.DetailData> SetDetailData(string STKCODE)
        {
            List<Inventory.GoodsReceive.DetailData> resultList = new List<RT2020.Client.Inventory.GoodsReceive.DetailData>();

            foreach (DataGridViewRow row in dgvDetailsList.Rows)
            {
                if (row.Cells[3].Value.ToString().Trim() == STKCODE)
                {
                    decimal qty = Convert.ToDecimal(row.Cells[8].Value.ToString());
                    decimal uamt = Convert.ToDecimal(row.Cells[9].Value.ToString());

                    if (DAL.Common.Utility.IsGUID(row.Cells[13].Value.ToString()))
                    {
                        Guid productId = new Guid(row.Cells[13].Value.ToString());

                        Inventory.GoodsReceive.DetailData detailDate = resultList.Find(d => d.ProductId == productId);
                        if (detailDate == null)
                        {
                            detailDate = new RT2020.Client.Inventory.GoodsReceive.DetailData();
                            detailDate.ProductId = productId;
                            detailDate.Qty = qty;
                            detailDate.UnitAmount = uamt;
                        }
                        else
                        {
                            resultList.Remove(detailDate);

                            detailDate.Qty = qty;
                            detailDate.UnitAmount = uamt;
                        }

                        resultList.Add(detailDate);
                    }
                }
            }

            return resultList;
        }

        private void dgvDetailsList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;

            if (index != -1)    // 2013.0809 paulus: ignor header
            {
                this.txtStockCode.Text = this.dgvDetailsList.Rows[index].Cells[3].Value.ToString();
                this.txtAppendix1.Text = this.dgvDetailsList.Rows[index].Cells[4].Value.ToString();
                this.txtAppendix2.Text = this.dgvDetailsList.Rows[index].Cells[5].Value.ToString();
                this.txtAppendix3.Text = this.dgvDetailsList.Rows[index].Cells[6].Value.ToString();
                this.txtDescription.Text = this.dgvDetailsList.Rows[index].Cells[7].Value.ToString();
                this.txtQty.Text = Convert.ToInt32(this.dgvDetailsList.Rows[index].Cells[8].Value).ToString();
                this.txtUnitCost.Text = Convert.ToDecimal(this.dgvDetailsList.Rows[index].Cells[9].Value).ToString("n2");
                this.txtDisc.Text = Convert.ToDecimal(this.dgvDetailsList.Rows[index].Cells[10].Value).ToString("n2");
                this.txtRemarks.Text = this.dgvDetailsList.Rows[index].Cells[12].Value.ToString();
            }
        }

    }
}
