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
    using System.Linq;

    /// <summary>
    /// Documentation for the second part of ByMultipleLocation.
    /// </summary>
    public partial class ByMultipleLocation : Form
    {
        /// <summary>
        /// The order header id.
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
        ///  The order selectedIndex.
        /// </summary>
        private int selectedIndex = 0;

        /// <summary>
        /// Initializes a new instance of the <see cref="ByMultipleLocation"/> class.
        /// </summary>
        public ByMultipleLocation()
        {
            this.InitializeComponent();
            this.SetToolBar();
            this.FillCboList();
            this.btnMarkAll.Visible = true;
            this.btnOK.Visible = true;
            this.cboStatus.SelectedIndex = 0;
            this.txtExchangeRete.Text = this.InitCurrency(!Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString())).ToString("n6");

            this.cboLocation.Text = "All";
            this.cboType.Enabled = false;
            this.cboSupplierCode.Enabled = false;
            this.cboOperatorCode.Enabled = false;
            this.dtpCancelDate.Enabled = false;
            this.dtpDeliveryDate.Enabled = false;
            this.dtpOrderDate.Enabled = false;
            this.cboCurrency.Enabled = false;
            this.txtExchangeRete.Enabled = false;
            this.tabADJAuthorization.TabPages[1].Enabled = false;

            this.BindingList(Common.Enums.Status.Draft); //// Holding
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

        /// <summary>
        /// Handles the Load event of the ByMultipleLocation control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ByMultipleLocation_Load(object sender, EventArgs e)
        {
            return;
        }

        /// <summary>
        /// Handles the CheckedChanged event of the ChkSortAndFilter control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChkSortAndFilter_CheckedChanged(object sender, EventArgs e)
        {
            return;
        }

        /// <summary>
        /// Handles the Click event of the LvPostTxList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void LvPostTxList_Click(object sender, EventArgs e)
        {
            if (this.lvLocationsList.Items != null && this.lvLocationsList.SelectedIndex >= 0)
            {
                int index = this.lvLocationsList.SelectedIndex;
                int iCount = 0;

                this.lvLocationsList.Items[index].SubItems[1].Text = (this.lvLocationsList.Items[index].SubItems[1].Text.Length == 0) ? "*" : string.Empty;
                
                foreach (ListViewItem objItem in this.lvLocationsList.Items)
                {
                    if (objItem.SubItems[1].Text.Contains("*"))
                    {
                        this.btnMarkAll.Text = "Unmark All";
                        iCount++;
                        if (iCount >= 10)
                        {
                            return;
                        }
                    }
                }

                if (iCount == 0)
                {
                    this.btnMarkAll.Text = "Mark All";
                }

                this.Update();
            }
        }

        /// <summary>
        /// Handles the Click event of the BtnMarkAll control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnMarkAll_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            foreach (ListViewItem objItem in this.lvLocationsList.Items)
            {
                if (this.btnMarkAll.Text.Contains("Mark") && !objItem.SubItems[1].Text.Contains("*"))
                {
                    objItem.SubItems[1].Text = "*";
                    iCount++;
                    if (iCount >= 10)
                    {
                        break;
                    }
                }
                else if (this.btnMarkAll.Text.Contains("Unmark"))
                {
                    objItem.SubItems[1].Text = string.Empty;
                }
            }

            this.Update();

            this.btnMarkAll.Text = (this.btnMarkAll.Text == "Mark All") ? "Unmark All" : "Mark All"; 
        }

        /// <summary>
        /// Handles the CheckedChanged event of the RbtnBarcode control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void RbtnBarcode_CheckedChanged(object sender, EventArgs e)
        {
            this.InitDetailFindingSelection();
            this.LoadCAPDetailsInfo(this.OrderDetailId);
            this.ResetTabOrder();
            this.Update();
        }

        #region Init Detail
        /// <summary>
        /// Inits the detail finding selection.
        /// </summary>
        private void InitDetailFindingSelection()
        {
            this.txtBarcode.ReadOnly = !this.rbtnBarcode.Checked;
            this.txtBarcode.Focus();
            this.txtBarcode.BackColor = !this.rbtnBarcode.Checked ? Color.LightYellow : Color.White;
            this.txtBarcode.TabStop = this.rbtnBarcode.Checked;

            this.txtStockCode.ReadOnly = !this.rbtnStockCode_1.Checked;
            this.txtStockCode.Focus();
            this.txtStockCode.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            this.txtStockCode.TabStop = this.rbtnStockCode_1.Checked;
            this.txtStockCode.TabIndex = 0;

            this.txtAppendix1.ReadOnly = !this.rbtnStockCode_1.Checked;
            this.txtAppendix1.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            this.txtAppendix1.TabStop = this.rbtnStockCode_1.Checked;
            this.txtAppendix1.TabIndex = 1;

            this.txtAppendix2.ReadOnly = !this.rbtnStockCode_1.Checked;
            this.txtAppendix2.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            this.txtAppendix2.TabStop = this.rbtnStockCode_1.Checked;
            this.txtAppendix2.TabIndex = 2;

            this.txtAppendix3.ReadOnly = !this.rbtnStockCode_1.Checked;
            this.txtAppendix3.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            this.txtAppendix3.TabStop = this.rbtnStockCode_1.Checked;
            this.txtAppendix3.TabIndex = 3;

            this.basicProduct.Enabled = this.rbtnStockCode_2.Checked;
            this.basicProduct.BackColor = !this.rbtnStockCode_2.Checked ? Color.LightYellow : Color.White;
            this.basicProduct.TabStop = this.rbtnStockCode_2.Checked;
        }

        /// <summary>
        /// Resets the tab order.
        /// </summary>
        private void ResetTabOrder()
        {
            this.ResetTabOrder(this.rbtnBarcode.Checked, this.rbtnStockCode_1.Checked, this.rbtnStockCode_2.Checked);
        }

        /// <summary>
        /// Resets the tab order.
        /// </summary>
        /// <param name="isBChecked">if set to <c>true</c> [is B checked].</param>
        /// <param name="isS1Checked">if set to <c>true</c> [is s1 checked].</param>
        /// <param name="isS2Checked">if set to <c>true</c> [is s2 checked].</param>
        private void ResetTabOrder(bool isBChecked, bool isS1Checked, bool isS2Checked)
        {
            this.basicProduct.TabStop = isS2Checked;
            this.txtBarcode.TabStop = isBChecked;

            this.txtStockCode.TabStop = isS1Checked;
            this.txtAppendix1.TabStop = isS1Checked;
            this.txtAppendix2.TabStop = isS1Checked;
            this.txtAppendix3.TabStop = isS1Checked;
        }
        #endregion
        
        #region Load CAP Detail Info
        /// <summary>
        /// Loads the CAP details info.
        /// </summary>
        /// <param name="detailId">The detail id.</param>
        private void LoadCAPDetailsInfo(Guid detailId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" OrderedQty, UnitCost, DiscountPcn, ProductId ");
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
                    this.SetStockCode(reader);

                    this.txtDescription.Text = reader.GetString(6);
                    this.txtQty.Text = reader.GetDecimal(7).ToString("n0");
                    this.txtCost.Text = reader.GetDecimal(10).ToString("n2");

                    this.ProductId = reader.GetGuid(10);
                    this.OrderDetailId = reader.GetGuid(0);
                }
            }
        }

        /// <summary>
        /// Sets the stock code.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void SetStockCode(SqlDataReader reader)
        {
            if (this.rbtnBarcode.Checked)
            {
                this.txtBarcode.Text = reader.GetString(2) + reader.GetString(3) + reader.GetString(4) + reader.GetString(5);

                this.basicProduct.SelectedItem = System.Guid.Empty;
            }

            if (this.rbtnStockCode_1.Checked)
            {
                this.txtStockCode.Text = reader.GetString(2);
                this.txtAppendix1.Text = reader.GetString(3);
                this.txtAppendix2.Text = reader.GetString(4);
                this.txtAppendix3.Text = reader.GetString(5);

                this.basicProduct.SelectedItem = System.Guid.Empty;
            }

            if (this.rbtnStockCode_2.Checked)
            {
                this.basicProduct.SelectedText = reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5);
                this.basicProduct.SelectedItem = reader.GetGuid(11);
            }
        }
        #endregion

        #region Bind Methods
        /// <summary>
        /// Datas the source.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="conditions">if set to <c>true</c> [conditions].</param>
        /// <returns>The source</returns>
        private SqlDataReader DataSource(string status, bool conditions)
        {
            string sql = this.BuildSqlQueryString(status, conditions);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd);
            return reader;
        }

        /// <summary>
        /// Bindings the list.
        /// </summary>
        /// <param name="status">The status.</param>
        private void BindingList(Common.Enums.Status status)
        {
            SqlDataReader reader;
            reader = this.DataSource(Common.Enums.Status.Draft.ToString("d"), false);
            this.BindingHoldingList(reader);
        }

        /// <summary>
        /// Bindings the holding list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingHoldingList(SqlDataReader reader)
        {
            this.lvLocationsList.Items.Clear();

            int iCount = 0;

            while (reader.Read())
            {
                ListViewItem objItem = this.lvLocationsList.Items.Add(reader.GetGuid(0).ToString()); // WorkplaceId
                objItem.SubItems.Add(string.Empty);
                objItem.SubItems.Add((iCount + 1).ToString()); //// Line Number
                objItem.SubItems.Add(reader.GetString(1)); //// WorkplaceCode
                objItem.SubItems.Add(reader.GetString(2)); //// WorkplaceInitial

                iCount++;
            }

            if (!reader.IsClosed)
            {
                reader.Close();
            }
        }

        /// <summary>
        /// Builds the SQL query string.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="withConditions">if set to <c>true</c> [with conditions].</param>
        /// <returns>the SQL query string.</returns>
        private string BuildSqlQueryString(string status, bool withConditions)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT WorkplaceId, WorkplaceCode, WorkplaceInitial ");
            sql.Append(" FROM vwWorkplaceList ");
            ////sql.Append(" WHERE STATUS = ").Append(status);
            sql.Append(" ORDER BY WorkplaceCode");

            return sql.ToString();
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
                        Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
                        break;
                    default:
                        break;
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
            this.FillPoType();
            this.FillSupplierList();
            this.FillOperationList();
            this.FillCurrencyList();
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
                        ByMultipleLocation objLocation = new ByMultipleLocation();
                        objLocation.ShowDialog();
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
                        ByMultipleLocation objLocation = new ByMultipleLocation();
                        objLocation.ShowDialog();
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
                this.tabADJAuthorization.SelectedIndex = 0;
            }
        }
        #endregion

        #region Save Purchase Order Header Info
        /// <summary>
        /// Saves this instance.
        /// </summary>
        private void Save()
        {
            //// 判断detail列表不为空才可以保存
            if (this.lvDetailsList.Items.Count <= 0)
            {
                MessageBox.Show("Does not allow saving record without details", "Save Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabADJAuthorization.SelectedIndex = 1;
                return;
            }

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ListViewItem objItem in this.lvLocationsList.Items)
                        {
                            if (objItem.SubItems[1].Text.Contains("*"))
                            {
                                var objHeader = new EF6.PurchaseOrderHeader();

                                objHeader.OrderHeaderId = Guid.NewGuid();
                                objHeader.CreatedBy = Common.Config.CurrentUserId;
                                objHeader.CreatedOn = DateTime.Now;

                                #region type
                                int type = 0;
                                string orderNumber = string.Empty;
                                switch (this.cboType.SelectedItem.ToString().ToUpper())
                                {
                                    case "FPO":
                                        orderNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.POType.FPO);
                                        type = Convert.ToInt32(Common.Enums.POType.FPO);
                                        break;
                                    case "LPO":
                                        orderNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.POType.LPO);
                                        type = Convert.ToInt32(Common.Enums.POType.LPO);
                                        break;
                                    case "OPO":
                                        orderNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.POType.OPO);
                                        type = Convert.ToInt32(Common.Enums.POType.OPO);
                                        break;
                                }
                                #endregion

                                objHeader.OrderNumber = orderNumber;
                                objHeader.OrderType = type;
                                objHeader.SupplierId = this.cboSupplierCode.SelectedIndex == -1 ? System.Guid.Empty : RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(this.cboSupplierCode.SelectedValue.ToString());
                                objHeader.StaffId = RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(this.cboOperatorCode.SelectedValue.ToString());
                                objHeader.OrderOn = this.dtpOrderDate.Value;
                                objHeader.DeliverOn = this.dtpDeliveryDate.Value;
                                objHeader.CancellationOn = this.dtpCancelDate.Value;
                                objHeader.WorkplaceId = RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(objItem.SubItems[0].Text);
                                objHeader.CurrencyCode = this.cboCurrency.Text;
                                objHeader.Status = RT2020.Purchasing.PurchasingUtils.Convert.ToInt32(this.cboStatus.Text == "HOLD" ? Common.Enums.Status.Draft.ToString("d") : Common.Enums.Status.Active.ToString("d"));

                                objHeader.ExchangeRate = this.InitCurrency(objHeader.CurrencyCode);
                                objHeader.ChargeCoefficient = this.InitCurrency(objHeader.CurrencyCode);
                                ////objHeader.TotalCost = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(this.txtTotalAmount.Text);
                                ////objHeader.TotalQty = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(this.txtTotalQty.Text);

                                objHeader.ModifiedBy = Common.Config.CurrentUserId;
                                objHeader.ModifiedOn = DateTime.Now;

                                ctx.PurchaseOrderHeader.Add(objHeader);
                                ctx.SaveChanges();

                                #region original: this.SaveOrderDetail(objHeader);
                                foreach (ListViewItem listItem in this.lvDetailsList.Items)
                                {
                                    bool result = true;
                                    Guid detailId = Guid.Empty, productId = Guid.Empty;

                                    if (Guid.TryParse(listItem.Text.Trim(), out detailId) && Guid.TryParse(listItem.SubItems[8].Text.Trim(), out productId))
                                    {
                                        //System.Guid detailId = RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(listItem.Text.Trim());
                                        var objDetail = ctx.PurchaseOrderDetails.Find(detailId);
                                        var wpCode = ModelEx.WorkplaceEx.GetWorkplaceCodeById(objHeader.WorkplaceId.Value);
                                        if (objDetail == null)
                                        {
                                            objDetail = new EF6.PurchaseOrderDetails();

                                            objDetail.OrderDetailsId = Guid.NewGuid();
                                            objDetail.OrderHeaderId = objHeader.OrderHeaderId;
                                            this.orderHeaderId = objHeader.OrderHeaderId;
                                            objDetail.LineNumber = RT2020.Purchasing.PurchasingUtils.Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);

                                            ctx.PurchaseOrderDetails.Add(objDetail);
                                        }

                                        objDetail.ProductId = RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(listItem.SubItems[8].Text.Trim());
                                        for (int i = 9; i <= 18; i++)
                                        {
                                            if (wpCode == this.lvDetailsList.Columns[i].Text && listItem.SubItems[i].Text != "0")
                                            {
                                                objDetail.OrderedQty = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(listItem.SubItems[i].Text.Length == 0 ? "0" : listItem.SubItems[i].Text);
                                                result = true;
                                                break;
                                            }
                                            else
                                            {
                                                result = false;
                                            }
                                        }

                                        objDetail.UnitCost = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(listItem.SubItems[7].Text.Length == 0 ? "0" : listItem.SubItems[7].Text);
                                        objDetail.TotalQtyReceived = objDetail.OrderedQty * objDetail.UnitCost;

                                        if (result)
                                        {
                                            if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
                                            {
                                                ctx.PurchaseOrderDetails.Remove(objDetail);
                                            }
                                        }
                                        ctx.SaveChanges();
                                    }
                                }
                                #endregion
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

        /// <summary>
        /// Saves the order detail.
        /// </summary>
        /// <param name="header">The header.</param>
        private void SaveOrderDetail(EF6.PurchaseOrderHeader header)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ListViewItem listItem in this.lvDetailsList.Items)
                        {
                            bool result = true;

                            Guid detailId = Guid.Empty, productId = Guid.Empty;
                            if (Guid.TryParse(listItem.Text.Trim(), out detailId) && Guid.TryParse(listItem.SubItems[8].Text.Trim(), out productId))
                            {
                                //System.Guid detailId = RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(listItem.Text.Trim());
                                var objDetail = ctx.PurchaseOrderDetails.Find(detailId);
                                var wpCode = ModelEx.WorkplaceEx.GetWorkplaceCodeById(header.WorkplaceId.Value);
                                if (objDetail == null)
                                {
                                    objDetail = new EF6.PurchaseOrderDetails();
                                    objDetail.OrderDetailsId = Guid.NewGuid();
                                    objDetail.OrderHeaderId = header.OrderHeaderId;
                                    this.orderHeaderId = header.OrderHeaderId;
                                    objDetail.LineNumber = RT2020.Purchasing.PurchasingUtils.Convert.ToInt32(listItem.SubItems[1].Text.Length == 0 ? "1" : listItem.SubItems[1].Text);

                                    ctx.PurchaseOrderDetails.Add(objDetail);
                                }

                                //objDetail.ProductId = RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(listItem.SubItems[8].Text.Trim());
                                objDetail.ProductId = productId;
                                for (int i = 9; i <= 18; i++)
                                {
                                    if (wpCode == this.lvDetailsList.Columns[i].Text && listItem.SubItems[i].Text != "0")
                                    {
                                        objDetail.OrderedQty = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(listItem.SubItems[i].Text.Length == 0 ? "0" : listItem.SubItems[i].Text);
                                        result = true;
                                        break;
                                    }
                                    else
                                    {
                                        result = false;
                                    }
                                }

                                objDetail.UnitCost = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(listItem.SubItems[7].Text.Length == 0 ? "0" : listItem.SubItems[7].Text);
                                objDetail.TotalQtyReceived = objDetail.OrderedQty * objDetail.UnitCost;

                                if (result)
                                {
                                    if (listItem.SubItems[2].Text.Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
                                    {
                                        ctx.PurchaseOrderDetails.Remove(objDetail);
                                    }
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

        #endregion
        
        #region Init Currency
        /// <summary>
        /// Inits the currency.
        /// </summary>
        /// <param name="currencyCode">The currency code.</param>
        /// <returns>The Init Currency.</returns>
        private decimal InitCurrency(string currencyCode)
        {
            decimal value = 0;
            using (var ctx = new EF6.RT2020Entities())
            {
                var cny = ctx.Currency.Where(x => x.CurrencyCode == currencyCode).FirstOrDefault();
                if (cny != null)
                {
                    value = this.InitCurrency(cny.CurrencyId);
                }
                else
                {
                    value = this.InitCurrency(Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
                }
            }
            return value;
        }

        /// <summary>
        /// Inits the currency.
        /// </summary>
        /// <param name="selectedCurrency">The selected currency.</param>
        /// <returns>The Init Currency.</returns>
        private decimal InitCurrency(Guid selectedCurrency)
        {
            decimal value = 0;
            using (var ctx = new EF6.RT2020Entities())
            {
                var cny = ctx.Currency.Find(selectedCurrency);
                if (cny != null) value = cny.ExchangeRate.Value;
            }

            return value;
        }
        #endregion

        #region Delete
        /// <summary>
        /// Deletes this instance.
        /// </summary>
        private void Delete()
        {
            return;
        }
        #endregion

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
                    this.SetLvDetailsListColumns(this.cboLocation.SelectedItem.ToString());

                    ListViewItem listItem = this.lvDetailsList.Items.Add(System.Guid.Empty.ToString());
                    listItem.SubItems.Add(this.lvDetailsList.Items.Count.ToString());
                    listItem.SubItems.Add("NEW"); //// Status
                    listItem.SubItems.Add(stkCode); //// Stock Code
                    listItem.SubItems.Add(appendix1); //// Appendix1
                    listItem.SubItems.Add(appendix2); //// Appendix2
                    listItem.SubItems.Add(appendix3); //// Appendix3
                    listItem.SubItems.Add(this.txtCost.Text); //// Unit Cost
                    listItem.SubItems.Add(this.ProductId.ToString()); //// ProductId

                    string selectedValue = "ALL";
                    for (int i = 9; i <= 18; i++)
                    {
                        if (this.lvDetailsList.Columns[i].Visible)
                        {
                            if (this.cboLocation.SelectedItem.ToString() == this.lvDetailsList.Columns[i].Text)
                            {
                                listItem.SubItems.Add(this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty1
                            }
                            else if (this.cboLocation.SelectedItem.ToString().ToUpper() == selectedValue)
                            {
                                listItem.SubItems.Add(this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty1
                            }
                            else
                            {
                                listItem.SubItems.Add("0"); //// Qty1
                            }
                        }
                        else
                        {
                            listItem.SubItems.Add("0"); //// Qty1
                        }
                    }

                    int totalQty = 0;
                    for (int i = 9; i <= 18; i++)
                    {
                        if (this.lvDetailsList.Columns[i].Visible)
                        {
                            if (this.cboLocation.SelectedItem.ToString() == this.lvDetailsList.Columns[i].Text)
                            {
                                totalQty += PurchasingUtils.Convert.ToInt32(listItem.SubItems[i].Text);
                            }
                            else if (this.cboLocation.SelectedItem.ToString().ToUpper() == selectedValue)
                            {
                                totalQty += PurchasingUtils.Convert.ToInt32(listItem.SubItems[i].Text);
                            }
                        }
                    }

                    listItem.SubItems.Add(totalQty.ToString()); //// Total Qty
                    listItem.SubItems.Add((totalQty * PurchasingUtils.Convert.ToDecimal(this.txtCost.Text)).ToString()); //// Total Cost

                    this.CalcTotal();
                }
            }

            this.lblLineCount.Text = this.lvDetailsList.Items.Count.ToString();
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
                RT2020.DAL.Product objProd = RT2020.DAL.Product.Load(RT2020.Purchasing.PurchasingUtils.Convert.ToGuid(this.basicProduct.SelectedItem.ToString()));
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
        /// Handles the SelectedIndexChanged event of the CboCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtExchangeRete.Text = this.InitCurrency(!Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString())).ToString("n6");
        }

        /// <summary>
        /// Handles the Click event of the btnOK control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.btnMarkAll.Visible = false;
            this.btnOK.Visible = false;

            this.cboType.Enabled = true;
            this.cboSupplierCode.Enabled = true;
            this.cboOperatorCode.Enabled = true;
            this.dtpCancelDate.Enabled = true;
            this.dtpDeliveryDate.Enabled = true;
            this.dtpOrderDate.Enabled = true;
            this.cboCurrency.Enabled = true;
            this.txtExchangeRete.Enabled = true;
            this.tabADJAuthorization.TabPages[1].Enabled = true;

            this.LoadLocation();
            this.SetLvDetailsListColumns(this.cboLocation.SelectedItem.ToString());
        }

        /// <summary>
        /// Loads the location.
        /// </summary>
        private void LoadLocation()
        {
            this.cboLocation.Items.Clear();
            this.cboLocation.Items.Add("All");

            foreach (ListViewItem objItem in this.lvLocationsList.Items)
            {
                if (objItem.SubItems[1].Text.Contains("*"))
                {
                    this.cboLocation.Items.Add(objItem.SubItems[3].Text);
                }
            }

            this.cboLocation.SelectedIndex = 0;            
        }

        /// <summary>
        /// Sets the lv details list columns.
        /// </summary>
        /// <param name="colName">Name of the col.</param>
        private void SetLvDetailsListColumns(string colName)
        {
            int index = 9;
            string objItemValue = "ALL";
            foreach (ListViewItem objItem in this.lvLocationsList.Items)
            {
                if (colName.ToUpper() == objItemValue)
                {
                    if (objItem.SubItems[1].Text.Contains("*"))
                    {
                        this.lvDetailsList.Columns[index].Text = objItem.SubItems[3].Text;
                        this.lvDetailsList.Columns[index].Visible = true;
                        index++;
                    }
                }
                else if (objItem.SubItems[3].Text == this.cboLocation.SelectedItem.ToString())
                {
                    if (this.lvDetailsList.Columns[index].Text == objItem.SubItems[3].Text)
                    {
                        this.lvDetailsList.Columns[index].Text = objItem.SubItems[3].Text;
                        this.lvDetailsList.Columns[index].Visible = true;
                    }
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
                listItem.SubItems[7].Text = this.txtCost.Text; //// Unit Cost
                listItem.SubItems[8].Text = this.productId.ToString(); //// ProductId

                for (int i = 9; i <= 18; i++)
                {
                    if (this.lvDetailsList.Columns[i].Visible)
                    {
                        if (this.cboLocation.SelectedItem.ToString() == this.lvDetailsList.Columns[i].Text)
                        {
                            listItem.SubItems[i].Text = (this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty1
                        }
                        else if (this.cboLocation.SelectedItem.ToString() == "All")
                        {
                            listItem.SubItems[i].Text = (this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty1
                        }
                        else
                        {
                            listItem.SubItems[i].Text = "0"; //// Qty1
                        }
                    }
                    else
                    {
                        listItem.SubItems[i].Text = "0"; //// Qty1
                    }
                }

                int totalQty = 0;
                for (int i = 9; i <= 18; i++)
                {
                    if (this.lvDetailsList.Columns[i].Visible)
                    {
                        if (this.cboLocation.SelectedItem.ToString() == this.lvDetailsList.Columns[i].Text)
                        {
                            totalQty += Convert.ToInt32(listItem.SubItems[i].Text);
                        }
                        else if (this.cboLocation.SelectedItem.ToString() == "All")
                        {
                            totalQty += Convert.ToInt32(listItem.SubItems[i].Text);
                        }
                    }
                }

                listItem.SubItems[19].Text = totalQty.ToString("n0"); //// Total Qty
                listItem.SubItems[20].Text = (totalQty * Convert.ToDecimal(this.txtCost.Text)).ToString("n2"); //// Total Cost

                this.CalcTotal();
            }
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

            this.lblLineCount.Text = this.lvDetailsList.Items.Count.ToString();
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
                    ttlQty += Convert.ToDecimal(listItem.SubItems[19].Text.Length > 0 ? listItem.SubItems[19].Text : "0");
                    ttlAmount += Convert.ToDecimal(listItem.SubItems[20].Text.Length > 0 ? listItem.SubItems[20].Text : "0");
                }
            }

            this.txtTotalQty.Text = ttlQty.ToString("n0");
            this.txtTotalAmount.Text = ttlAmount.ToString("n2");
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
                    this.LoadPurchaseOrderDetailsInfo(new Guid(this.lvDetailsList.SelectedItem.Text));
                    this.orderDetailId = new Guid(this.lvDetailsList.SelectedItem.Text);
                    this.selectedIndex = this.lvDetailsList.SelectedIndex;
                }
            }
        }

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
                    this.txtCost.Text = reader.GetDecimal(7).ToString("n2");
                    this.txtQty.Text = reader.GetDecimal(9).ToString("n0");

                    this.basicProduct.SelectedItem = reader.GetGuid(9);
                    this.ProductId = reader.GetGuid(9);
                }
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
            this.txtCost.Text = e.UnitPrice.ToString("n2");
        }
    }
}