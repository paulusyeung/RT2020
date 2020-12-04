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
    using Gizmox.WebGUI.Common.Resources;
    using Gizmox.WebGUI.Forms;

    using RT2020.DAL;
    using System.Linq;

    /// <summary>
    ///  Documentation for the second part of SettleOrder.
    /// </summary>
    public partial class SettleOrder : Form
    {
        /// <summary>
        /// The obj header id.
        /// </summary>
        private Guid orderHeaderId = System.Guid.Empty;

        /// <summary>
        /// The product id.
        /// </summary>
        private Guid productId = System.Guid.Empty;

        /// <summary>
        /// The receiving Header Id
        /// </summary>
        private Guid receivingHeaderId = System.Guid.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="SettleOrder"/> class.
        /// </summary>
        public SettleOrder()
        {
            this.InitializeComponent();

            this.FillCboList();
            this.SetToolBar();
            this.LoadLastName();
            this.LoadLastUpdate();
            this.cboSettled.Text = "YES";
            this.txtPaymentTerm.Text = "0";
            this.cboStatus.SelectedIndex = 0;
            this.cboPartialShipment.SelectedIndex = 0;
            this.txtPurchaseOrderNo.Text = "Auto-Generated";
            this.InitCurrency(!Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SettleOrder"/> class.
        /// </summary>
        /// <param name="receivingHeaderId">The receiving header id.</param>
        public SettleOrder(Guid receivingHeaderId)
        {
            this.InitializeComponent();

            this.ReceivingHeaderId = receivingHeaderId;
            this.LoadOrderHeaderId();
            this.FillCboList();
            this.SetToolBar();

            this.LoadPOHeaderInfo();
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
        /// Gets or sets the product id.
        /// </summary>
        /// <value>The product id.</value>
        public Guid ProductId
        {
            get { return this.productId; }
            set { this.productId = value; }
        }

        /// <summary>
        /// Gets or sets the receiving header id.
        /// </summary>
        /// <value>The receiving header id.</value>
        public Guid ReceivingHeaderId
        {
            get { return this.receivingHeaderId; }
            set { this.receivingHeaderId = value; }
        }
        #endregion

        #region Load Last Name & Last Update
        /// <summary>
        /// Loads the name of the staff fuff.
        /// </summary>
        private void LoadLastName()
        {
            this.txtLastUser.Text = ModelEx.StaffEx.GetStaffNumberById(Common.Config.CurrentUserId);
        }

        /// <summary>
        /// Loads the last update.
        /// </summary>
        private void LoadLastUpdate()
        {
            this.txtLastUpdate.Text = RT2020.SystemInfo.Settings.DateTimeToString(DateTime.Now, false);
        }

        /// <summary>
        /// Loads the order header id.
        /// </summary>
        private void LoadOrderHeaderId()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var objReceiveHeader = ctx.PurchaseOrderReceiveHeader.Find(this.ReceivingHeaderId);
                if (objReceiveHeader != null)
                {
                    this.OrderHeaderId = objReceiveHeader.OrderHeaderId.Value;
                }
            }
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

        #region Fill Combo List
        /// <summary>
        /// Fills the cbo list.
        /// </summary>
        private void FillCboList()
        {
            this.FillSupplierList();
            this.FillOperationList();
            this.FillCurrencyList();
            this.FillLocationList();
            this.FillShipmentMethodList();
            this.FillSupplierTermsList();
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
            ModelEx.ShipmentMethodEx.LoadCombo(ref this.cboShipmentMethod, "MethodCode", false);
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

            if (this.ReceivingHeaderId == System.Guid.Empty)
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
                        Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
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

                    if (this.ReceivingHeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultOSTList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        SettleOrder settleOrder = new SettleOrder(this.ReceivingHeaderId);
                        settleOrder.ShowDialog();
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

                    if (this.ReceivingHeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultOSTList>();
                        this.Close();
                        SettleOrder settleOrder = new SettleOrder();
                        settleOrder.ShowDialog();
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

                    if (this.ReceivingHeaderId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultOSTList>();
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

                if (this.ReceivingHeaderId != System.Guid.Empty)
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    SettleOrder settleOrder = new SettleOrder();
                    settleOrder.ShowDialog();
                }
            }
            else
            {
                ////tabGoodsADJ.SelectedIndex = 0;
            }
        }
        #endregion

        #region 保存 & 删除
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            // David [2008-10-27] : It should use the OrderHeaderId, but not ReceivingHeaderId.
            PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(this.OrderHeaderId);

            // David [2008-10-27] : It should check whether the objHeader is null or not.
            if (objHeader != null)
            {
                objHeader.Settled = this.cboSettled.SelectedItem.ToString() == "YES" ? true : false;
                objHeader.SettledOn = DateTime.Now;

                objHeader.ModifiedBy = Common.Config.CurrentUserId;
                objHeader.ModifiedOn = DateTime.Now;

                objHeader.Save();
            }
        }
        #endregion

        #region Load Purchase Order Info
        /// <summary>
        /// Loads the PO header info.
        /// </summary>
        private void LoadPOHeaderInfo()
        {
            PurchaseOrderHeader objHeader = PurchaseOrderHeader.Load(this.OrderHeaderId);
            
            if (objHeader != null)
            {
                string strType = string.Empty;
                switch (objHeader.OrderType)
                {
                    case 1:
                        strType = Common.Enums.POType.LPO.ToString();
                        break;
                    case 2:
                        strType = Common.Enums.POType.OPO.ToString();
                        break;
                    case 0:
                    default:
                        strType = Common.Enums.POType.FPO.ToString();
                        break;
                }

                this.txtType.Text = strType;
                this.txtPurchaseOrderNo.Text = objHeader.OrderNumber;
                this.txtPOOrderedQty.Text = objHeader.TotalQty.ToString("n0");
                this.txtOrderAmount.Text = objHeader.TotalCost.ToString("n2");
                this.cboSupplierCode.SelectedValue = objHeader.SupplierId;
                this.cboOperatorCode.SelectedValue = objHeader.StaffId;
                this.dtpOrderDate.Value = objHeader.OrderOn;
                this.dtpDeliveryDate.Value = objHeader.DeliverOn;
                this.dtpCancelDate.Value = objHeader.CancellationOn;
                this.cboPaymentMethod.SelectedValue = objHeader.TermsId;
                this.txtPaymentTerm.Text = objHeader.CreditDays.ToString("n0");
                this.txtDeposit.Text = objHeader.DepositPercentage.ToString("n2");
                this.txtPaymentRemark.Text = objHeader.PaymentRemarks;

                this.cboLocation.SelectedValue = objHeader.WorkplaceId;
                this.cboCurrency.Text = objHeader.CurrencyCode;
                this.txtGroupDiscount1.Text = objHeader.GroupDiscount1.ToString("n2");
                this.txtGroupDiscount2.Text = objHeader.GroupDiscount2.ToString("n2");
                this.txtGroupDiscount3.Text = objHeader.GroupDiscount3.ToString("n2");
                this.txtTypeDetail.Text = objHeader.TYPEDTL;
                this.cboPartialShipment.SelectedItem = objHeader.PartialShipment ? "YES" : "NO";
                this.cboShipmentMethod.Text = objHeader.ShipmentMethod;
                this.txtShipmentRemark.Text = objHeader.ShipmentRemarks;
                this.txtLastUser.Text = ModelEx.StaffEx.GetStaffNumberById(objHeader.ModifiedBy);

                this.cboStatus.SelectedItem = (objHeader.Status == 0) ? "HOLD" : "POST";
                this.txtXRate.Text = objHeader.ExchangeRate.ToString("n6");
                this.txtFreightCharge.Text = objHeader.FreightChargePcn.ToString("n2");
                this.txtHandlingCharge.Text = objHeader.HandlingChargePcn.ToString("n2");
                this.txtInsuranceCharge.Text = objHeader.InsuranceChargePcn.ToString("n2");
                this.txtOtherCharge.Text = objHeader.OtherChargesPcn.ToString("n2");
                this.txtTotalQty.Text = objHeader.TotalQty.ToString("n0");
                this.txtNetCost.Text = (objHeader.TotalCost - objHeader.GroupDiscount1 - objHeader.GroupDiscount2 - objHeader.GroupDiscount3 - objHeader.FreightChargeAmt - objHeader.HandlingChargeAmt - objHeader.InsuranceChargeAmt - objHeader.OtherChargesAmt).ToString("n2");
                this.txtCoeffcient.Text = objHeader.ChargeCoefficient.ToString("n6");
                this.txtLastUpdate.Text = objHeader.ModifiedOn.ToShortDateString();

                this.txtDeliveryAddress.Text = objHeader.DeliveryAddress;
                this.txtContactPerson.Text = objHeader.ContactPerson;
                this.txtContactTel.Text = objHeader.ContactPhone;
                this.txtPoRemark1.Text = objHeader.Remarks1;
                this.txtPoRemark2.Text = objHeader.Remarks2;
                this.txtPoRemark3.Text = objHeader.Remarks3;

                this.LoadPODetailInfo();
                this.CalReceivingQty();
            }
        }

        /// <summary>
        /// Loads the PO detail info.
        /// </summary>
        private void LoadPODetailInfo()
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
                    ListViewItem listItem = this.lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); //// DetailsId
                    listItem.SubItems.Add((iCount + 1).ToString());                   //// LN
                    listItem.SubItems.Add(string.Empty);                        //// Status
                    listItem.SubItems.Add(reader.GetString(2));                 //// PLU
                    listItem.SubItems.Add(reader.GetString(3));                 ////SERSON
                    listItem.SubItems.Add(reader.GetString(4));                 ////COLOR
                    listItem.SubItems.Add(reader.GetString(5));                 ////SIZE
                    listItem.SubItems.Add(reader.GetString(6));                 ////Description
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0"));     //// OrderedQty
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n2"));     //// UnitCost
                    listItem.SubItems.Add(reader.GetDecimal(9).ToString("n2"));     //// DiscountPcn
                    listItem.SubItems.Add((reader.GetDecimal(7) * reader.GetDecimal(8)).ToString("n2")); //// Sub Total
                    listItem.SubItems.Add(reader.GetString(10));                //// Notes
                    listItem.SubItems.Add(reader.GetGuid(11).ToString());       //// ProductId

                    iCount++;
                }
            }

            this.lblLineCount.Text = iCount.ToString();
        }

        /// <summary>
        /// Cals the receiving qty.
        /// </summary>
        private void CalReceivingQty()
        {
            decimal totalReceivingQty = 0;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  ReceiveDetailsId, ReceivedQty ");
            sql.Append(" FROM PurchaseOrderReceiveDetails a,PurchaseOrderReceiveHeader b ");
            sql.Append(" WHERE a.ReceiveHeaderId = b.ReceiveHeaderId and OrderHeaderId = '").Append(this.OrderHeaderId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    totalReceivingQty += reader.GetDecimal(1);
                }
            }

            this.txtPOReceivingQty.Text = totalReceivingQty.ToString("n0");
        }
        #endregion
    }
}