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
    using System.Text.RegularExpressions;
    using System.Web;

    using Gizmox.WebGUI.Common;
    using Gizmox.WebGUI.Common.Interfaces;
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Forms;

    using RT2020.DAL;
    using System.Linq;

    /// <summary>
    /// Documentation for the second part of PurchaseOrder.
    /// </summary>
    public partial class PurchaseOrder : Form, IGatewayComponent
    {
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

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrder"/> class.
        /// </summary>
        public PurchaseOrder()
        {
            this.InitializeComponent();
            this.FillCboList();
            this.SetToolBar();
            this.LoadLastName();
            this.LoadLastUpdate();
            this.txtPaymentTerm.Text = "0";
            this.cboStatus.SelectedIndex = 0;
            this.cboPartialShipment.SelectedIndex = 0;
            this.txtPurchaseOrderNo.Text = "Auto-Generated"; 
            this.InitCurrency(!Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrder"/> class.
        /// </summary>
        /// <param name="objHeaderId">The obj header id.</param>
        public PurchaseOrder(Guid objHeaderId)
        {
            this.InitializeComponent();

            this.orderHeaderId = objHeaderId;
            this.FillCboList();
            this.SetToolBar();
            this.LoadPurchaseOrderInfo();
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
                        orderType = Common.Enums.POType.FPO.ToString();
                        break;
                    case 1:
                        orderType = Common.Enums.POType.LPO.ToString();
                        break;
                    case 2:
                        orderType = Common.Enums.POType.OPO.ToString();
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
                this.txtLastUser.Text = ModelEx.StaffEx.GetStaffNumberById(objHeader.ModifiedBy);
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
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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

                    this.basicProduct.SelectedItem = reader.GetGuid(11);
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
            var objStaff = ModelEx.StaffEx.GetByStaffId(Common.Config.CurrentUserId);
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
            this.txtLastUpdate.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, false);
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
                    this.InitCurrency(oCny.CurrencyId);
                }
                else
                {
                    this.InitCurrency(Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
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
                if (oCny != null)
                {
                    this.txtXRate.Text = oCny.ExchangeRate.Value.ToString("n6");
                    this.txtCoeffcient.Text = oCny.ExchangeRate.Value.ToString("n6");
                }
            }
        }
        #endregion

        /// <summary>
        /// Handles the SelectedIndexChanged event of the lvDetailsList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(this.lvDetailsList.SelectedItem.Text))
                {
                    this.LoadPurchaseOrderDetailsInfo(new Guid(this.lvDetailsList.SelectedItem.Text));
                    this.orderDetailId = new Guid(this.lvDetailsList.SelectedItem.Text);
                    this.selectedIndex = this.lvDetailsList.SelectedIndex;
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
                    listItem.SubItems.Add(this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty
                    listItem.SubItems.Add(this.txtUnitCost.Text); //// Unit Cost
                    listItem.SubItems.Add(this.txtDisc.Text); //// DiscountPcn

                    decimal qty = PurchasingUtils.Convert.ToDecimal(this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text);
                    decimal unitCost = PurchasingUtils.Convert.ToDecimal(this.txtUnitCost.Text.Length == 0 ? "0" : this.txtUnitCost.Text);
                    decimal disc = PurchasingUtils.Convert.ToDecimal(this.txtDisc.Text);
                    disc = (100 - disc) / 100;
                    decimal amt = qty * unitCost * disc;
                    listItem.SubItems.Add(amt.ToString("n2")); //// Sub Total
                    listItem.SubItems.Add(this.txtRemarks.Text); //// Notes
                    listItem.SubItems.Add(this.productId.ToString()); //// ProductId

                    this.CalcTotal();
                }
            }
        }

        /// <summary>
        /// Calcs the total.
        /// </summary>
        private void CalcTotal()
        {
            decimal ttlQty = 0, ttlAmount = 0;
            foreach (ListViewItem listItem in this.lvDetailsList.Items)
            {
                if (listItem.SubItems[2].Text != "REMOVED")
                {
                    ttlQty += PurchasingUtils.Convert.ToDecimal(listItem.SubItems[8].Text.Length > 0 ? listItem.SubItems[8].Text : "0");
                    ttlAmount += PurchasingUtils.Convert.ToDecimal(listItem.SubItems[11].Text.Length > 0 ? listItem.SubItems[11].Text : "0");
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
                listItem.SubItems[8].Text = this.txtQty.Text; //// Qty
                listItem.SubItems[9].Text = this.txtUnitCost.Text; //// Unit Cost
                listItem.SubItems[10].Text = this.txtDisc.Text; //// DiscountPcn

                decimal qty = PurchasingUtils.Convert.ToDecimal(this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text);
                decimal unitPrice = PurchasingUtils.Convert.ToDecimal(this.txtUnitCost.Text.Length == 0 ? "0" : this.txtUnitCost.Text);
                decimal disc = PurchasingUtils.Convert.ToDecimal(this.txtDisc.Text);
                disc = (100 - disc) / 100;
                decimal amt = qty * unitPrice * disc;
                listItem.SubItems[11].Text = amt.ToString("n2"); //// Amount
                listItem.SubItems[12].Text = this.txtRemarks.Text; //// Remarks
                listItem.SubItems[13].Text = this.productId.ToString(); //// ProductId

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
        /// Handles the SelectionChanged event of the BasicProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs"/> instance containing the event data.</param>
        private void BasicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        {
            this.txtDescription.Text = e.Description;
            this.txtUnitCost.Text = e.UnitCost.ToString("n2");
        }

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

            this.lvDetailsList.ListViewItemSorter = new ListViewItemSorter(this.lvDetailsList);
        }

        /// <summary>
        /// Fills the supplier list.
        /// </summary>
        private void FillSupplierList()
        {
            ModelEx.SupplierEx.LoadCombo(ref this.cboSupplierCode, "SupplierCode", false);
        }

        /// <summary>
        /// Fills the operation list.
        /// </summary>
        private void FillOperationList()
        {
            ModelEx.StaffEx.LoadCombo(ref this.cboOperatorCode, "StaffNumber", false);
        }

        /// <summary>
        /// Fills the currency list.
        /// </summary>
        private void FillCurrencyList()
        {
            ModelEx.CurrencyEx.LoadCombo(ref this.cboCurrency, "CurrencyCode", false);
        }

        /// <summary>
        /// Fills the location list.
        /// </summary>
        private void FillLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref this.cboLocation, "WorkplaceCode", false);
        }

        /// <summary>
        /// Fills the shipment method list.
        /// </summary>
        private void FillShipmentMethodList()
        {
            RT2020.DAL.ShipmentMethod.LoadCombo(ref this.cboShipmentMethod, "MethodCode", false);
        }

        /// <summary>
        /// Fills the supplier terms list.
        /// </summary>
        private void FillSupplierTermsList()
        {
            ModelEx.SupplierTermsEx.LoadCombo(ref this.cboPaymentMethod, "TermsCode", false);
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

        #region Save Purchase Order Header Info
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            if (this.lvDetailsList.Items.Count <= 0)
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
                    this.txtPurchaseOrderNo.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.POType.FPO);
                    type = Convert.ToInt32(Common.Enums.POType.FPO);
                    break;
                case "LPO":
                    this.txtPurchaseOrderNo.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.POType.LPO);
                    type = Convert.ToInt32(Common.Enums.POType.LPO);
                    break;
                case "OPO":
                    this.txtPurchaseOrderNo.Text = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.POType.OPO);
                    type = Convert.ToInt32(Common.Enums.POType.OPO);
                    break;
            }

            if (objHeader == null)
            {
                objHeader = new PurchaseOrderHeader();

                objHeader.CreatedBy = Common.Config.CurrentUserId;
                objHeader.CreatedOn = DateTime.Now;

                objHeader.OrderNumber = this.txtPurchaseOrderNo.Text;
            }

            //// main
            objHeader.OrderType           = type;
            objHeader.SupplierId          = PurchasingUtils.Convert.ToGuid(this.cboSupplierCode.SelectedValue.ToString());
            objHeader.StaffId             = PurchasingUtils.Convert.ToGuid(this.cboOperatorCode.SelectedValue.ToString());
            objHeader.OrderOn             = this.dtpOrderDate.Value;
            objHeader.DeliverOn           = this.dtpDeliveryDate.Value;
            objHeader.CancellationOn      = this.dtpCancelDate.Value;
            objHeader.TermsId             = (this.cboPaymentMethod.SelectedIndex == -1) ? System.Guid.Empty : new Guid(this.cboPaymentMethod.SelectedValue.ToString());
            objHeader.CreditDays          = PurchasingUtils.Convert.ToInt32(this.txtPaymentTerm.Text);
            objHeader.DepositPercentage   = PurchasingUtils.Convert.ToDecimal(this.txtDeposit.Text);
            objHeader.PaymentRemarks      = this.txtPaymentRemark.Text;
            objHeader.WorkplaceId         = PurchasingUtils.Convert.ToGuid(this.cboLocation.SelectedValue.ToString());
            objHeader.CurrencyCode        = this.cboCurrency.Text;
            objHeader.GroupDiscount1      = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount1.Text);
            objHeader.GroupDiscount2      = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount2.Text);
            objHeader.GroupDiscount3      = PurchasingUtils.Convert.ToDecimal(this.txtGroupDiscount3.Text);
            objHeader.TYPEDTL             = this.txtTypeDetail.Text;
            objHeader.PartialShipment     = this.cboPartialShipment.SelectedItem.ToString().ToUpper() == "YES" ? true : false;
            objHeader.ShipmentMethod      = this.cboShipmentMethod.SelectedIndex == -1 ? String.Empty : this.cboShipmentMethod.Text;
            objHeader.ShipmentRemarks     = this.txtShipmentRemark.Text;
            objHeader.Status              = Convert.ToInt32(this.cboStatus.Text == "HOLD" ? Common.Enums.Status.Draft.ToString("d") : Common.Enums.Status.Active.ToString("d"));

            objHeader.ExchangeRate        = PurchasingUtils.Convert.ToDecimal(this.txtXRate.Text);
            objHeader.TotalCost           = PurchasingUtils.Convert.ToDecimal(this.txtOrderAmount.Text);
            objHeader.TotalQty            = PurchasingUtils.Convert.ToDecimal(this.txtTotalQty.Text);
            objHeader.FreightChargePcn    = PurchasingUtils.Convert.ToDecimal(this.txtFreightCharge.Text);
            objHeader.FreightChargeAmt    = objHeader.FreightChargePcn * objHeader.TotalCost;
            objHeader.HandlingChargePcn   = PurchasingUtils.Convert.ToDecimal(this.txtHandlingCharge.Text);
            objHeader.HandlingChargeAmt   = objHeader.HandlingChargePcn * objHeader.TotalCost;
            objHeader.InsuranceChargePcn  = PurchasingUtils.Convert.ToDecimal(this.txtInsuranceCharge.Text);
            objHeader.InsuranceChargeAmt  = objHeader.InsuranceChargePcn * objHeader.TotalCost;
            objHeader.OtherChargesPcn     = PurchasingUtils.Convert.ToDecimal(this.txtOtherCharge.Text);
            objHeader.OtherChargesAmt     = objHeader.OtherChargesPcn * objHeader.TotalCost;
            objHeader.ChargeCoefficient   = PurchasingUtils.Convert.ToDecimal(this.txtCoeffcient.Text);

            //// detail

            //// other
            objHeader.DeliveryAddress = this.txtDeliveryAddress.Text;
            objHeader.ContactPerson = this.txtContactPerson.Text;
            objHeader.ContactPhone = this.txtContactTel.Text;
            objHeader.Remarks1 = this.txtPoRemark1.Text;
            objHeader.Remarks2 = this.txtPoRemark2.Text;
            objHeader.Remarks3 = this.txtPoRemark3.Text;

            objHeader.ModifiedBy = Common.Config.CurrentUserId;
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
            foreach (ListViewItem listItem in this.lvDetailsList.Items)
            {
                //// 判断detailid 和 productid 是否为空，不为空才执行 保存/删除 操作
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[13].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    PurchaseOrderDetails objDetail = PurchaseOrderDetails.Load(detailId);
                    if (objDetail == null)
                    {
                        objDetail = new PurchaseOrderDetails();
                        objDetail.OrderHeaderId = this.orderHeaderId;
                        objDetail.LineNumber = PurchasingUtils.Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);
                    }

                    objDetail.ProductId = new Guid(listItem.SubItems[13].Text.Trim());
                    objDetail.OrderedQty = PurchasingUtils.Convert.ToDecimal(listItem.SubItems[8].Text.Length == 0 ? "0" : listItem.SubItems[8].Text);
                    objDetail.UnitCost = PurchasingUtils.Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);
                    objDetail.DiscountPcn = PurchasingUtils.Convert.ToDecimal(listItem.SubItems[10].Text.Length == 0 ? "0" : listItem.SubItems[10].Text);
                    objDetail.TotalQtyReceived = PurchasingUtils.Convert.ToDecimal(listItem.SubItems[11].Text.Length == 0 ? "0" : listItem.SubItems[11].Text);
                    objDetail.NetUnitCost = objDetail.UnitCost * ((100 - objDetail.DiscountPcn) / 100);
                    objDetail.NetUnitCostCoefficient = objDetail.NetUnitCost * PurchasingUtils.Convert.ToDecimal(this.txtCoeffcient.Text);
                    objDetail.Notes = listItem.SubItems[12].Text;

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
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultPOList>();
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
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultPOList>();
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
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultPOList>();
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
                    decimal qty = reader.GetDecimal(7);
                    decimal unitPrice = reader.GetDecimal(8);
                    decimal disc = (reader.GetDecimal(9) == 0) ? 1 : (reader.GetDecimal(9) / 100);
                    decimal amt = qty * unitPrice * disc;

                    ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                    listItem.SubItems.Add((iCount + 1).ToString());             //// LN
                    listItem.SubItems.Add(string.Empty);                        //// Status
                    listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                    listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                    listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                    listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                    listItem.SubItems.Add(reader.GetString(6));                 ////Description
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                    listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                    listItem.SubItems.Add(amt.ToString("n2"));                  //// Sub Total
                    listItem.SubItems.Add(reader.GetString(10));                //// Notes
                    listItem.SubItems.Add(reader.GetGuid(11).ToString());       //// ProductId

                    iCount++;
                }
            }

            this.lblLineCount.Text = iCount.ToString();
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
FROM vwRptPurchaseOrder
WHERE	OrderHeaderId = '" + this.OrderHeaderId.ToString() + "'";

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
            this.InitCurrency(!Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
        }
    }
}