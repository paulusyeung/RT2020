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
    public partial class ByMultipleLocation : Form
    {
        private List<Inventory.GoodsReceive.DetailData> _Result = new List<RT2020.Client.Inventory.GoodsReceive.DetailData>();

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

        public ByMultipleLocation()
        {
            InitializeComponent();
            this.FillCboList();
            this.btnMarkAll.Visible = true;
            this.btnOK.Visible = true;
            this.cboStatus.SelectedIndex = 0;
            this.txtExchangeRete.Text = this.InitCurrency(!DAL.Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString())).ToString("n6");

            this.txtTotalQty.Enabled = false;
            this.txtTotalAmount.Enabled = false;

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
            this.cboStatus.Enabled = false;

            this.txtStockCode.Enabled = false;
            this.txtAppendix1.Enabled = false;
            this.txtAppendix2.Enabled = false;
            this.txtAppendix3.Enabled = false;

            this.BindingList(RT2020.DAL.Common.Enums.Status.Draft); //// Holding
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


        /// <summary>
        /// Handles the Click event of the LvPostTxList control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void dgvPostTxList_Click(object sender, EventArgs e)
        {
            if (this.dgvLocationsList.Rows != null && this.dgvLocationsList.CurrentCell.RowIndex >= 0)
            {
                //int index = this.lvLocationsList.SelectedIndex;
                //int iCount = 0;
                //this.lvLocationsList.Items[index].SubItems[1].Text = (this.lvLocationsList.Items[index].SubItems[1].Text.Length == 0) ? "*" : string.Empty;

                int index = this.dgvLocationsList.CurrentCell.RowIndex;
                int iCount = 0;

                this.dgvLocationsList.Rows[index].Cells[0].Value = (this.dgvLocationsList.Rows[index].Cells[0].Value == null) ? "*" : null;
                
                foreach (DataGridViewRow rows in this.dgvLocationsList.Rows)
                {
                    if (rows.Cells[0].Value != null && rows.Cells[0].Value.ToString() == "*")
                    {
                        this.btnMarkAll.Text = "Unmark All";
                        iCount++;

                        if (iCount > 10)
                        {
                            this.dgvLocationsList.Rows[index].Cells[0].Value = (this.dgvLocationsList.Rows[index].Cells[0].Value.ToString() == "*") ? null : this.dgvLocationsList.Rows[index].Cells[0].Value;
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
            foreach (DataGridViewRow rows in dgvLocationsList.Rows)
            {
                if (this.btnMarkAll.Text.Contains("Mark") && rows.Cells[0].Value == null)
                {
                    if (iCount >= 10)
                    {
                        break;
                    }
                    rows.Cells[0].Value = "*";
                    iCount++;

                }
                else if (this.btnMarkAll.Text.Contains("Unmark"))
                {
                    rows.Cells[0].Value = null;
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
            
            this.Update();
        }

        #region Init Detail
        /// <summary>
        /// Inits the detail finding selection.
        /// </summary>
        private void InitDetailFindingSelection()
        {
            //this.txtBarcode.ReadOnly = !this.rbtnBarcode.Checked;
            //this.txtBarcode.Focus();
            //this.txtBarcode.BackColor = !this.rbtnBarcode.Checked ? Color.LightYellow : Color.White;
            //this.txtBarcode.TabStop = this.rbtnBarcode.Checked;

            //this.txtStockCode.ReadOnly = !this.rbtnStockCode_1.Checked;
            //this.txtStockCode.Focus();
            //this.txtStockCode.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            //this.txtStockCode.TabStop = this.rbtnStockCode_1.Checked;
            //this.txtStockCode.TabIndex = 0;

            //this.txtAppendix1.ReadOnly = !this.rbtnStockCode_1.Checked;
            //this.txtAppendix1.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            //this.txtAppendix1.TabStop = this.rbtnStockCode_1.Checked;
            //this.txtAppendix1.TabIndex = 1;

            //this.txtAppendix2.ReadOnly = !this.rbtnStockCode_1.Checked;
            //this.txtAppendix2.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            //this.txtAppendix2.TabStop = this.rbtnStockCode_1.Checked;
            //this.txtAppendix2.TabIndex = 2;

            //this.txtAppendix3.ReadOnly = !this.rbtnStockCode_1.Checked;
            //this.txtAppendix3.BackColor = !this.rbtnStockCode_1.Checked ? Color.LightYellow : Color.White;
            //this.txtAppendix3.TabStop = this.rbtnStockCode_1.Checked;
            //this.txtAppendix3.TabIndex = 3;

            //this.basicProduct.Enabled = this.rbtnStockCode_2.Checked;
            //this.basicProduct.BackColor = !this.rbtnStockCode_2.Checked ? Color.LightYellow : Color.White;
            //this.basicProduct.TabStop = this.rbtnStockCode_2.Checked;
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
            cmd.CommandTimeout = RT2020.DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    this.SetStockCode(reader);

                    //this.txtDescription.Text = reader.GetString(6);
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
            //if (this.rbtnBarcode.Checked)
            //{
            //    this.txtBarcode.Text = reader.GetString(2) + reader.GetString(3) + reader.GetString(4) + reader.GetString(5);

            //    //this.basicProduct.SelectedItem = System.Guid.Empty;
            //}

            //if (this.rbtnStockCode_1.Checked)
            //{
            //    this.txtStockCode.Text = reader.GetString(2);
            //    this.txtAppendix1.Text = reader.GetString(3);
            //    this.txtAppendix2.Text = reader.GetString(4);
            //    this.txtAppendix3.Text = reader.GetString(5);

            //    //this.basicProduct.SelectedItem = System.Guid.Empty;
            //}

            //if (this.rbtnStockCode_2.Checked)
            //{
            //    //this.basicProduct.SelectedText = reader.GetString(2) + " " + reader.GetString(3) + " " + reader.GetString(4) + " " + reader.GetString(5);
            //    //this.basicProduct.SelectedItem = reader.GetGuid(11);
            //}
        }
        #endregion

        #region Bind Methods
        /// <summary>
        /// Datas the source.
        /// </summary>
        /// <param name="status">The status.</param>
        /// <param name="conditions">if set to <c>true</c> [conditions].</param>
        /// <returns>The source</returns>
        private DataTable DataSource(string status, bool conditions)
        {
            string sql = this.BuildSqlQueryString(status, conditions);

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = RT2020.DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);
            return ds.Tables[0];
        }

        /// <summary>
        /// Bindings the list.
        /// </summary>
        /// <param name="status">The status.</param>
        private void BindingList(DAL.Common.Enums.Status status)
        {
            DataTable table;
            table = this.DataSource(RT2020.DAL.Common.Enums.Status.Draft.ToString("d"), false);
            this.BindingHoldingList(table);
        }

        /// <summary>
        /// Bindings the holding list.
        /// </summary>
        /// <param name="reader">The reader.</param>
        private void BindingHoldingList(DataTable table)
        {
            this.dgvLocationsList.Rows.Clear();

           
            if (table != null)
            {
                table.Columns.Add("LineNumber");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    table.Rows[i]["LineNumber"] = Convert.ToString(i +1);
                }
            }


            this.dgvLocationsList.DataSource = table;
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
            if (this.dgvDetailsList.Rows.Count <= 0)
            {
                MessageBox.Show("Does not allow saving record without details", "Save Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.tabADJAuthorization.SelectedIndex = 1;
                return;
            }

            foreach (DataGridViewRow rows in dgvLocationsList.Rows)
            {
                if (rows.Cells[0].Value != null && rows.Cells[0].Value.ToString() == "*")
                {
                    PurchaseOrderHeader objHeader = new PurchaseOrderHeader();

                    objHeader.CreatedBy = RT2020.DAL.Common.Config.CurrentUserId;
                    objHeader.CreatedOn = DateTime.Now;

                    int type = 0;
                    string orderNumber = string.Empty;
                    switch (this.cboType.SelectedItem.ToString().ToUpper())
                    {
                        case "FPO":
                            orderNumber = Common.Utility.QueuingTxNumber(RT2020.DAL.Common.Enums.POType.FPO);
                            type = Convert.ToInt32(RT2020.DAL.Common.Enums.POType.FPO);
                            break;
                        case "LPO":
                            orderNumber = Common.Utility.QueuingTxNumber(RT2020.DAL.Common.Enums.POType.LPO);
                            type = Convert.ToInt32(RT2020.DAL.Common.Enums.POType.LPO);
                            break;
                        case "OPO":
                            orderNumber = Common.Utility.QueuingTxNumber(RT2020.DAL.Common.Enums.POType.OPO);
                            type = Convert.ToInt32(RT2020.DAL.Common.Enums.POType.OPO);
                            break;
                    }

                    objHeader.OrderNumber = orderNumber;
                    objHeader.OrderType = type;
                    objHeader.SupplierId = this.cboSupplierCode.SelectedIndex == -1 ? System.Guid.Empty : Purchasing.PurchasingUtils.Convert.ToGuid(this.cboSupplierCode.SelectedValue.ToString());
                    objHeader.StaffId = Purchasing.PurchasingUtils.Convert.ToGuid(this.cboOperatorCode.SelectedValue.ToString());
                    objHeader.OrderOn = this.dtpOrderDate.Value;
                    objHeader.DeliverOn = this.dtpDeliveryDate.Value;
                    objHeader.CancellationOn = this.dtpCancelDate.Value;
                    objHeader.WorkplaceId = Purchasing.PurchasingUtils.Convert.ToGuid(rows.Cells[dgvLocationsList.Columns["colTxId"].Index].Value);
                    objHeader.CurrencyCode = this.cboCurrency.Text;
                    objHeader.Status = Purchasing.PurchasingUtils.Convert.ToInt32(this.cboStatus.Text == "HOLD" ? RT2020.DAL.Common.Enums.Status.Draft.ToString("d") : RT2020.DAL.Common.Enums.Status.Active.ToString("d"));

                    objHeader.ExchangeRate = this.InitCurrency(objHeader.CurrencyCode);
                    objHeader.ChargeCoefficient = this.InitCurrency(objHeader.CurrencyCode);
                    //objHeader.TotalCost = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(this.txtTotalAmount.Text);
                    //objHeader.TotalQty = RT2020.Purchasing.PurchasingUtils.Convert.ToDecimal(this.txtTotalQty.Text);

                    objHeader.ModifiedBy = RT2020.DAL.Common.Config.CurrentUserId;
                    objHeader.ModifiedOn = DateTime.Now;

                    objHeader.Save();

                    this.SaveOrderDetail(objHeader);
                }
            }
        }

        /// <summary>
        /// Saves the order detail.
        /// </summary>
        /// <param name="header">The header.</param>
        private void SaveOrderDetail(PurchaseOrderHeader header)
        {
            foreach (DataGridViewRow rows in this.dgvDetailsList.Rows)
            {
                bool result = true;

                //// 判断detailid 和 productid 是否为空，不为空才执行 保存/删除 操作
                if (DAL.Common.Utility.IsGUID(rows.Cells[0].Value.ToString()) && DAL.Common.Utility.IsGUID(rows.Cells[8].Value.ToString()))
                {
                    System.Guid detailId = Purchasing.PurchasingUtils.Convert.ToGuid(rows.Cells[0].Value.ToString());
                    PurchaseOrderDetails objDetail = PurchaseOrderDetails.Load(detailId);
                    DAL.Workplace workplace = DAL.Workplace.Load(header.WorkplaceId);
                    if (objDetail == null)
                    {
                        objDetail = new PurchaseOrderDetails();
                        objDetail.OrderHeaderId = header.OrderHeaderId;
                        this.orderHeaderId = header.OrderHeaderId;
                        objDetail.LineNumber = Purchasing.PurchasingUtils.Convert.ToInt32(rows.Cells[1].Value.ToString().Length == 0 ? "1" : rows.Cells[1].Value.ToString());
                    }

                    objDetail.ProductId = Purchasing.PurchasingUtils.Convert.ToGuid(rows.Cells[8].Value.ToString().Trim());
                    for (int i = 9; i <= 18; i++)
                    {
                        if (workplace.WorkplaceCode == this.dgvDetailsList.Columns[i].HeaderText && rows.Cells[i].Value.ToString() != "0")
                        {
                            objDetail.OrderedQty = Purchasing.PurchasingUtils.Convert.ToDecimal(rows.Cells[i].Value.ToString().Length == 0 ? "0" : rows.Cells[i].Value.ToString());
                            result = true;
                            break;
                        }
                        else
                        {
                            result = false;
                        }
                    }

                    objDetail.UnitCost = Purchasing.PurchasingUtils.Convert.ToDecimal(rows.Cells[7].Value.ToString().Length == 0 ? "0" : rows.Cells[7].Value.ToString());
                    objDetail.TotalQtyReceived = objDetail.OrderedQty * objDetail.UnitCost;

                    if (result)
                    {
                        if (rows.Cells[2].Value != null && rows.Cells[2].Value.ToString().Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
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
            string sql = "CurrencyCode = '" + currencyCode + "'";
            Currency objCny = Currency.LoadWhere(sql);
            if (objCny != null)
            {
                value = this.InitCurrency(objCny.CurrencyId);
            }
            else
            {
                value = this.InitCurrency(RT2020.DAL.Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString()));
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
            Currency objCny = Currency.Load(selectedCurrency);
            if (objCny != null)
            {
                value = objCny.ExchangeRate;
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

            foreach (DataGridViewRow rows in this.dgvDetailsList.Rows)
            {
                if (stkCode.Length > 0)
                {
                    isDuplicated = (rows.Cells[3].Value.ToString() == stkCode);
                    isDuplicated = isDuplicated & (rows.Cells[4].Value.ToString() == appendix1);
                    isDuplicated = isDuplicated & (rows.Cells[5].Value.ToString() == appendix2);
                    isDuplicated = isDuplicated & (rows.Cells[6].Value.ToString() == appendix3);
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
            
                RT2020.DAL.Product objProd = RT2020.DAL.Product.Load(new Guid(dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[8].Value.ToString()));
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
        /// Handles the SelectedIndexChanged event of the CboCurrency control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtExchangeRete.Text = this.InitCurrency(!DAL.Common.Utility.IsGUID(this.cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(this.cboCurrency.SelectedValue.ToString())).ToString("n6");
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

            foreach (DataGridViewRow rows in this.dgvLocationsList.Rows)
            {
                if (rows.Cells[0].Value != null)
                {
                    this.cboLocation.Items.Add(rows.Cells[dgvLocationsList.Columns["colWorkplaceCode"].Index].Value.ToString());
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
            foreach (DataGridViewRow rows in this.dgvLocationsList.Rows)
            {
                if (colName.ToUpper() == objItemValue)
                {
                    if (rows.Cells[0].Value != null && rows.Cells[0].Value.ToString() == "*")
                    {

                        this.dgvDetailsList.Columns[index].HeaderText = rows.Cells[dgvLocationsList.Columns["colWorkplaceCode"].Index].Value.ToString();
                        this.dgvDetailsList.Columns[index].Visible = true;
                        index++;
                    }
                }
                else if (rows.Cells[dgvLocationsList.Columns["colWorkplaceCode"].Index].Value.ToString() == this.cboLocation.SelectedItem.ToString())
                {
                    if (this.dgvDetailsList.Columns[index].HeaderText == rows.Cells[dgvLocationsList.Columns["colWorkplaceCode"].Index].Value.ToString())
                    {
                        this.dgvDetailsList.Columns[index].HeaderText = rows.Cells[dgvLocationsList.Columns["colWorkplaceCode"].Index].Value.ToString();
                        this.dgvDetailsList.Columns[index].Visible = true;
                    }
                }
            }
        }

        /// <summary>
        /// Calcs the total.
        /// </summary>
        private void CalcTotal()
        {
            decimal ttlQty = 0, ttlAmount = 0;
            foreach (DataGridViewRow rows in this.dgvDetailsList.Rows)
            {
                if (rows.Cells[2].Value.ToString() != "REMOVED")
                {
                    ttlQty += Convert.ToDecimal(rows.Cells[19].Value.ToString().Length > 0 ? rows.Cells[19].Value.ToString() : "0");
                    ttlAmount += Convert.ToDecimal(rows.Cells[20].Value.ToString().Length > 0 ? rows.Cells[20].Value.ToString() : "0");
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
        private void dgvDetailsList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.dgvDetailsList.SelectedRows != null)
            {
                if (RT2020.DAL.Common.Utility.IsGUID(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString()))
                {
                    this.LoadPurchaseOrderDetailsInfo(new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString()));
                    this.orderDetailId = new Guid(this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].Cells[0].Value.ToString());
                    //this.selectedIndex = this.lvDetailsList.SelectedIndex;
                }
            }
        }

        private void BindCAPDetailsInfo(DataTable datasource)
        {
            this.dgvDetailsList.AutoGenerateColumns = false;

            this.dgvDetailsList.DataSource = datasource;

            int iCount = 0;

            foreach (DataGridViewRow row in dgvDetailsList.Rows)
            {
                for (int i = 9; i <= 18; i++)
                {
                    row.Cells[i].Value = row.Cells[21].Value;
                    if (row.Cells[i].Visible)
                    {
                        iCount += Convert.ToInt32(row.Cells[i].Value);
                    }
                }
                row.Cells[19].Value = iCount;
                row.Cells[20].Value = iCount*Convert.ToDecimal(row.Cells[7].Value);
                iCount = 0;
            }

            this.CalcTotal();

            this.lblLineCount.Text = dgvDetailsList.Rows.Count.ToString();
        }

        #region Load PurchaseOrder Detail Info
        /// <summary>
        /// Loads the purchase order details info.
        /// </summary>
        /// <param name="detailId">The detail id.</param>
        private DataTable LoadPurchaseOrderDetailsInfo(Guid detailId)
        {
            DataTable table = new DataTable();

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" OrderedQty, UnitCost, DiscountPcn, Notes, ProductId,'' AS Status ");
            sql.Append(" FROM vwPurchaseOrderDetailsList ");
            sql.Append(" WHERE DetailsId = '").Append(detailId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = RT2020.DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    //this.txtDescription.Text = reader.GetString(6);
                    this.txtCost.Text = reader.GetDecimal(7).ToString("n2");
                    this.txtQty.Text = reader.GetDecimal(9).ToString("n0");

                    //this.basicProduct.SelectedItem = reader.GetGuid(9);
                    this.ProductId = reader.GetGuid(9);
                }
            }

            if (this.dgvDetailsList.DataSource == null)
            {
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
        #endregion

        private void GetDataFromList(ref DataTable table)
        {
            foreach (Inventory.GoodsReceive.DetailData detailData in _Result)
            {
                DAL.Product product = DAL.Product.Load(detailData.ProductId);
                if (product != null)
                {
                    DataRow[] rows = table.Select(string.Format("ProductId = '{0}'", product.ProductId.ToString()));
                    if (rows.Length > 0)
                    {
                        for (int i = 0; i < rows.Length; i++)
                        {
                            DataRow row = rows[i];
                            row["OrderedQty"] = detailData.Qty;
                            row["UnitCost"] = detailData.UnitAmount > 0 ? detailData.UnitAmount : Convert.ToDecimal(product.RetailPrice.ToString("n2"));
                            row["Status"] = "EDIT";
                            row.EndEdit();
                            row.AcceptChanges();
                        }
                    }
                    else 
                    {
                        DataRow row = table.NewRow();
                        row["DetailsId"] = Guid.Empty;
                        row["LineNumber"] = table.Rows.Count + 1;
                        row["STKCODE"] = product.STKCODE;
                        row["APPENDIX1"] = product.APPENDIX1;
                        row["APPENDIX2"] = product.APPENDIX2;
                        row["APPENDIX3"] = product.APPENDIX3;
                        row["ProductName"] = product.ProductName;
                        row["OrderedQty"] = detailData.Qty;
                        row["UnitCost"] = detailData.UnitAmount > 0 ? detailData.UnitAmount : Convert.ToDecimal(product.RetailPrice.ToString("n2"));
                        row["ProductId"] = product.ProductId;
                        row["Status"] = "NEW";
                        table.Rows.Add(row);
                    }
                }
            }
        }

        /// <summary>
        /// Handles the SelectionChanged event of the BasicProduct control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs"/> instance containing the event data.</param>
        //private void BasicProduct_SelectionChanged(object sender, RT2020.Controls.ProductSearcher.Basic.ProductSelectionEventArgs e)
        //{
        //    this.txtDescription.Text = e.Description;
        //    this.txtCost.Text = e.UnitPrice.ToString("n2");
        //}

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Inventory.GoodsReceive.Detail detail = new RT2020.Client.Inventory.GoodsReceive.Detail();
            detail.Closed += new EventHandler(detail_Closed);
            detail.ShowDialog();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (this.dgvDetailsList.SelectedRows != null)
            {
                string stkCode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
                this.ItemInfo(ref stkCode, ref appendix1, ref appendix2, ref appendix3);

                DataGridViewRow rows = dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex];

                rows.Cells[2].Value = rows.Cells[2].Value.ToString() != "NEW" ? "EDIT" : rows.Cells[2].Value; //// Status
                rows.Cells[3].Value = stkCode; //// Stock Code
                rows.Cells[4].Value = appendix1; //// Appendix1
                rows.Cells[5].Value = appendix2; //// Appendix2
                rows.Cells[6].Value = appendix3; //// Appendix3
                rows.Cells[7].Value = this.txtCost.Text; //// Unit Cost
                rows.Cells[8].Value = this.productId.ToString(); //// ProductId

                for (int i = 9; i <= 18; i++)
                {
                    if (this.dgvDetailsList.Columns[i].Visible)
                    {
                        if (this.cboLocation.SelectedItem.ToString() == this.dgvDetailsList.Columns[i].HeaderText)
                        {
                            rows.Cells[i].Value = (this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty1
                        }
                        else if (this.cboLocation.SelectedItem.ToString() == "All")
                        {
                            rows.Cells[i].Value = (this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text); //// Qty1
                        }
                        else
                        {
                            rows.Cells[i].Value = "0"; //// Qty1
                        }
                    }
                    else
                    {
                        rows.Cells[i].Value = "0"; //// Qty1
                    }
                }

                int totalQty = 0;
                for (int i = 9; i <= 18; i++)
                {
                    if (this.dgvDetailsList.Columns[i].Visible)
                    {
                        if (this.cboLocation.SelectedItem.ToString() == this.dgvDetailsList.Columns[i].HeaderText)
                        {
                            totalQty += Convert.ToInt32(rows.Cells[i].Value.ToString());
                        }
                        else if (this.cboLocation.SelectedItem.ToString() == "All")
                        {
                            totalQty += Convert.ToInt32(rows.Cells[i].Value.ToString());
                        }
                    }
                }

                rows.Cells[19].Value = totalQty.ToString("n0"); //// Total Qty
                //string totalCost = (totalQty * Convert.ToDecimal(this.txtCost.Text)).ToString();
                rows.Cells[20].Value = totalQty * Convert.ToDecimal(this.txtCost.Text); //// Total Cost
                rows.Cells[21].Value = (this.txtQty.Text.Length == 0 ? "0" : this.txtQty.Text);

                //this.dgvDetailsList.Rows[dgvDetailsList.CurrentCell.RowIndex].SetValues(rows);

                this.CalcTotal();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
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

            this.lblLineCount.Text = this.dgvDetailsList.Rows.Count.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Inventory.GoodsReceive.Detail detail = new RT2020.Client.Inventory.GoodsReceive.Detail();
            detail.Closed += new EventHandler(detail_Closed);
            detail.ShowDialog();
        }

        void detail_Closed(object sender, EventArgs e)
        {
            if(sender is Inventory.GoodsReceive.Detail)
            {
                Inventory.GoodsReceive.Detail detail = sender as Inventory.GoodsReceive.Detail;
                if (detail != null)
                {
                    _Result = detail.ResultList;

                    BindCAPDetailsInfo(LoadPurchaseOrderDetailsInfo(OrderDetailId));
                }
            }
        }

        private void dgvDetailsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Inventory.GoodsReceive.Detail detail = new RT2020.Client.Inventory.GoodsReceive.Detail();
            detail.StockCode = this.dgvDetailsList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
            detail.ResultList = SetDetailData(this.dgvDetailsList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
            detail.Closed += new EventHandler(detail_Closed);
            detail.ShowDialog();
        }

        private List<Inventory.GoodsReceive.DetailData> SetDetailData(string STKCODE)
        {
            List<Inventory.GoodsReceive.DetailData> resultList = new List<RT2020.Client.Inventory.GoodsReceive.DetailData>();

            foreach(DataGridViewRow rows in dgvDetailsList.Rows)
            {
                if (rows.Cells[3].Value.ToString().Trim() == STKCODE)
                {
                    decimal qty = Convert.ToDecimal(rows.Cells[21].Value.ToString());
                    decimal uamt = Convert.ToDecimal(rows.Cells[7].Value.ToString());

                    if (DAL.Common.Utility.IsGUID(rows.Cells[8].Value.ToString()))
                    {
                        Guid productId = new Guid(rows.Cells[8].Value.ToString());

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
            int index = dgvDetailsList.CurrentCell.RowIndex;

            this.txtStockCode.Text = dgvDetailsList.Rows[index].Cells[3].Value.ToString();
            this.txtAppendix1.Text = dgvDetailsList.Rows[index].Cells[4].Value.ToString();
            this.txtAppendix2.Text = dgvDetailsList.Rows[index].Cells[5].Value.ToString();
            this.txtAppendix3.Text = dgvDetailsList.Rows[index].Cells[6].Value.ToString();
            this.txtQty.Text = dgvDetailsList.Rows[index].Cells[21].Value.ToString();
            this.txtCost.Text = dgvDetailsList.Rows[index].Cells[7].Value.ToString();
            //this.cboLocation.SelectedText = dgvDetailsList.Rows[index].Cells[].Value.ToString();
        }

    }
}
