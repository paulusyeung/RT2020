using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RT2020.DAL;
using System.Data.SqlClient;

namespace RT2020.Client.Inventory.GoodsReceive
{
    public partial class Wizard : WizardBase
    {
        private List<DetailData> _ResultList = new List<DetailData>();

        public Guid CAPHeaderId { get; set; }

        public Wizard()
        {
            InitializeComponent();

            FormChanged = Modified.Clean;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetCaptions();
            SetCombos();
            SetAttributes();
            SetAnsToolbar();

            if (this.EditMode == Mode.Edit)
            {
                ShowItem();

                cmdDelete.Enabled = true;
            }

            Cursor.Current = Cursors.Default;
        }

        #region Utility

        private void SetCaptions()
        {
            colSTKCODE.HeaderText = Common.Utility.GetSystemLabelByKey("STKCODE");
            colAppendix1.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.HeaderText = Common.Utility.GetSystemLabelByKey("APPENDIX3");
        }

        private void SetAttributes()
        {
            this.txtTxType.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtTxNumber.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtTotalAmount.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtTotalQty.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtAmendmentRestrict.BackColor = Common.Theme.ControlBackColor.DisabledBox;

            this.txtModifiedBy.BackColor = Common.Theme.ControlBackColor.DisabledBox;
            this.txtModifiedOn.BackColor = Common.Theme.ControlBackColor.DisabledBox;

            this.cboWorkplace.BackColor = Common.Theme.ControlBackColor.RequiredBox;
            this.cboStaff.BackColor = Common.Theme.ControlBackColor.RequiredBox;
            this.cboCurrency.BackColor = Common.Theme.ControlBackColor.RequiredBox;
            this.cboStatus.BackColor = Common.Theme.ControlBackColor.RequiredBox;

            if (this.EditMode == Mode.New)
            {
                this.cboCurrency.Text = "HKD";
                this.txtTxType.Text = DAL.Common.Enums.TxType.CAP.ToString();
                this.txtTxNumber.Text = "Auto-Generated";
                this.txtTotalAmount.Text = "0.00";
                this.txtTotalQty.Text = "0";

                this.txtModifiedBy.Text = string.Empty;
                this.txtModifiedOn.Text = string.Empty;

                InitCurrency(cboCurrency.Text);
            }
        }

        private void SetAnsToolbar()
        {
            ToolStripButton ansDelete = new ToolStripButton();
            ansDelete.Name = "ansDelete";
            ansDelete.Text = "Delete";
            ansDelete.Image = cmdDelete.Image;
            ansDelete.Enabled = (this.EditMode == Mode.Edit);
            ansDelete.Click += new EventHandler(ansDelete_Click);
            ansDetails.Items.Add(ansDelete);
        }

        #region ComboBox

        private void SetCombos()
        {
            Common.ComboBox.FillStatus(ref cboStatus);

            FillWorkplaceList();
            FillStaffList();
            FillSupplierList();
            FillCurrencyList();
        }

        private void FillWorkplaceList()
        {
            cboWorkplace.Items.Clear();

            RT2020.DAL.WorkplaceCollection wpList = RT2020.DAL.Workplace.LoadCollection(new String[] { "WorkplaceCode" }, true);
            cboWorkplace.DataSource = wpList;
            cboWorkplace.DisplayMember = "WorkplaceCode";
            cboWorkplace.ValueMember = "WorkplaceId";

            cboWorkplace.SelectedIndex = 0;
        }

        private void FillStaffList()
        {
            cboStaff.Items.Clear();

            RT2020.DAL.StaffCollection staffList = RT2020.DAL.Staff.LoadCollection(new String[] { "StaffNumber" }, true);
            cboStaff.DataSource = staffList;
            cboStaff.DisplayMember = "StaffNumber";
            cboStaff.ValueMember = "StaffId";

            cboStaff.SelectedIndex = 0;
        }

        private void FillSupplierList()
        {
            cboSupplier.Items.Clear();

            RT2020.DAL.SupplierCollection SupplierList = RT2020.DAL.Supplier.LoadCollection(new String[] { "SupplierCode" }, true);
            cboSupplier.DataSource = SupplierList;
            cboSupplier.DisplayMember = "SupplierCode";
            cboSupplier.ValueMember = "SupplierId";

            cboSupplier.SelectedIndex = 0;
        }

        private void FillCurrencyList()
        {
            cboCurrency.Items.Clear();

            RT2020.DAL.CurrencyCollection CurrencyList = RT2020.DAL.Currency.LoadCollection(new String[] { "CurrencyCode" }, true);
            cboCurrency.DataSource = CurrencyList;
            cboCurrency.DisplayMember = "CurrencyCode";
            cboCurrency.ValueMember = "CurrencyId";

            cboCurrency.SelectedIndex = 0;
        }

        #endregion
        
        private void FormatCellStyle()
        {
            foreach (DataGridViewRow row in dgvDetailList.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.ColumnIndex == 8) // Qty
                    {
                        if (Convert.ToDecimal(cell.Value.ToString()) > 0)
                        {
                            cell.Style.Font = new Font(dgvDetailList.DefaultCellStyle.Font, FontStyle.Bold);
                        }

                        cell.ReadOnly = false;
                    }
                    else
                    {
                        cell.ReadOnly = true;
                    }

                    if (cell.ReadOnly)
                    {
                        cell.Style.BackColor = Common.Theme.ControlBackColor.DisabledBox;
                    }
                }
            }
        }

        #endregion

        #region Show Item

        private void ShowItem()
        {
            InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.Load(this.CAPHeaderId);
            if (oHeader != null)
            {
                this.txtTxNumber.Text = oHeader.TxNumber;
                this.txtTxType.Text = oHeader.TxType;
                this.dtpTxDate.Value = oHeader.TxDate;

                this.cboCurrency.Text = oHeader.CurrencyCode;
                this.txtExchgRate.Text = oHeader.ExchangeRate.ToString("n4");
                this.cboWorkplace.SelectedValue = oHeader.WorkplaceId;
                this.cboStaff.SelectedValue = oHeader.StaffId;

                this.cboStatus.Text = (oHeader.Status == 0) ? "HOLD" : "POST";

                this.cboSupplier.SelectedValue = oHeader.SupplierId;
                this.txtSupplierInvoice.Text = oHeader.SupplierRefernce;
                this.txtRemarks.Text = oHeader.Remarks;
                this.txtReference.Text = oHeader.Reference;

                InitCurrency(oHeader.CurrencyCode);

                this.txtModifiedOn.Text = oHeader.ModifiedOn.ToString("dd/MM/yyyy");
                this.txtModifiedBy.Text = GetStaffName(oHeader.ModifiedBy);

                this.txtAmendmentRestrict.Text = oHeader.ReadOnly ? "Y" : "N";
                this.chkApLink.Checked = oHeader.LinkToAP;

                this.txtTotalQty.Text = GetTotalRequiredQty().ToString("n0");
                this.txtTotalAmount.Text = GetTotalAmount().ToString("n2");

                BindCAPDetailsInfo(GetData());
            }
        }

        private string GetStaffName(Guid staffId)
        {
            RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.Load(staffId);
            if (oStaff != null)
            {
                return oStaff.StaffNumber;
            }
            else
            {
                return string.Empty;
            }
        }

        private decimal GetTotalRequiredQty()
        {
            decimal totalQty = 0;

            string sql = "HeaderId = '" + this.CAPHeaderId.ToString() + "'";
            InvtBatchCAP_DetailsCollection oDetails = InvtBatchCAP_Details.LoadCollection(sql);
            foreach (InvtBatchCAP_Details oDetail in oDetails)
            {
                totalQty += oDetail.Qty;
            }

            return totalQty;
        }

        private decimal GetTotalAmount()
        {
            decimal totalAmt = 0;

            string sql = "HeaderId = '" + this.CAPHeaderId.ToString() + "'";
            InvtBatchCAP_DetailsCollection oDetails = InvtBatchCAP_Details.LoadCollection(sql);
            foreach (InvtBatchCAP_Details oDetail in oDetails)
            {
                decimal xchgRate = Convert.ToDecimal(DAL.Common.Utility.IsNumeric(txtExchgRate.Text) ? txtExchgRate.Text.Trim() : "1");
                totalAmt += oDetail.UnitAmount * oDetail.Qty;
            }

            return totalAmt;
        }

        private void InitCurrency(string currencyCode)
        {
            string sql = "CurrencyCode = '" + currencyCode + "'";
            Currency oCny = Currency.LoadWhere(sql);
            if (oCny != null)
            {
                InitCurrency(oCny.CurrencyId);
            }
            else
            {
                InitCurrency(DAL.Common.Utility.IsGUID(cboCurrency.SelectedValue.ToString()) ? System.Guid.Empty : new System.Guid(cboCurrency.SelectedValue.ToString()));
            }
        }

        private void InitCurrency(Guid selectedCurrency)
        {
            Currency oCny = Currency.Load(selectedCurrency);
            if (oCny != null)
            {
                this.lblTotalAmount.Text = string.Format("Total Amount ({0}):", oCny.CurrencyCode);
                this.txtTotalAmount.Text = DAL.Common.Utility.IsNumeric(txtTotalAmount.Text.Trim()) ? (Convert.ToDecimal(txtTotalAmount.Text) * oCny.ExchangeRate).ToString("n2") : "0.00";

                colUnitAmountInForeignCurrency.HeaderText = string.Format("Unit Amount ({0})", oCny.CurrencyCode);

                txtExchgRate.Text = oCny.ExchangeRate.ToString("n4");

                ResetCAPDetails(oCny.ExchangeRate);
            }
        }

        private void ResetCAPDetails(decimal xchgRate)
        {
            foreach (DataGridViewRow item in dgvDetailList.Rows)
            {
                decimal qty = Convert.ToDecimal(item.Cells[8].Value.ToString().Length == 0 ? "0" : item.Cells[8].Value.ToString());
                decimal uamtF = Convert.ToDecimal(item.Cells[9].Value.ToString().Length == 0 ? "0" : item.Cells[9].Value.ToString());
                item.Cells[2].Value = item.Cells[2].Value.ToString().Trim().Length == 0 ? "EDIT" : item.Cells[2].Value;
                item.Cells[10].Value = (uamtF * xchgRate);
                item.Cells[11].Value = (uamtF * xchgRate * qty);
            }
        }

        private void BindCAPDetailsInfo(DataTable datasource)
        {
            dgvDetailList.AutoGenerateColumns = false;

            dgvDetailList.DataSource = datasource;

            FormatCellStyle();
        }

        private DataTable GetData()
        {
            DataTable oTable = new DataTable();

            if (dgvDetailList.DataSource == null)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
                sql.Append(" Qty, UnitAmountInForeignCurrency, UnitAmount, ProductId, UnitAmount * Qty AS Amount, '' AS Status ");
                sql.Append(" FROM vwCAPDetailsList ");
                sql.Append(" WHERE HeaderId = '").Append(this.CAPHeaderId.ToString()).Append("'");
                sql.Append(" ORDER BY LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 ");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandText = sql.ToString();
                cmd.CommandTimeout = Convert.ToInt32(System.Configuration.ConfigurationManager.AppSettings["CommandTimeoutValue"]);
                cmd.CommandType = CommandType.Text;

                DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

                oTable = ds.Tables[0];

                if (oTable.Rows.Count == 0)
                {
                     GetDataFromList(ref oTable);
                }
            }
            else
            {
                oTable = (DataTable)dgvDetailList.DataSource;
                GetDataFromList(ref oTable);
            }

            return oTable;
        }

        private void GetDataFromList(ref DataTable oTable)
        {
            foreach (DetailData detailData in _ResultList)
            {
                Product oProduct = Product.Load(detailData.ProductId);
                if (oProduct != null)
                {
                    DataRow[] rows = oTable.Select(string.Format("ProductId = '{0}'", oProduct.ProductId.ToString()));
                    if (rows.Length > 0)
                    {
                        for (int i = 0; i < rows.Length; i++)
                        {
                            DataRow row = rows[i];
                            if (!row["Qty"].Equals(detailData.Qty))
                            {
                                row.BeginEdit();
                                row["Qty"] = detailData.Qty;
                                row["Status"] = "EDIT";
                                row.EndEdit();
                                row.AcceptChanges();
                            }

                            if (!row["UnitAmountInForeignCurrency"].Equals(detailData.UnitAmount))
                            {
                                row.BeginEdit();
                                row["UnitAmountInForeignCurrency"] = detailData.UnitAmount;
                                row["Status"] = "EDIT";
                                row.EndEdit();
                                row.AcceptChanges();
                            }
                        }
                    }
                    else
                    {
                        DataRow row = oTable.NewRow();
                        row["DetailsId"] = Guid.Empty;
                        row["LineNumber"] = oTable.Rows.Count + 1;
                        row["STKCODE"] = oProduct.STKCODE;
                        row["APPENDIX1"] = oProduct.APPENDIX1;
                        row["APPENDIX2"] = oProduct.APPENDIX2;
                        row["APPENDIX3"] = oProduct.APPENDIX3;
                        row["ProductName"] = oProduct.ProductName;
                        row["Qty"] = detailData.Qty;
                        row["UnitAmountInForeignCurrency"] = detailData.UnitAmount;
                        row["UnitAmount"] = detailData.UnitAmount * Convert.ToDecimal(txtExchgRate.Text.Trim());
                        row["ProductId"] = oProduct.ProductId;
                        row["Amount"] = detailData.UnitAmount * Convert.ToDecimal(txtExchgRate.Text.Trim()) * detailData.Qty;
                        row["Status"] = "NEW";
                        oTable.Rows.Add(row);
                    }
                }
            }
        }

        #endregion

        #region Save Item
        private bool SaveItem()
        {
            bool isSave = false;

            if (dgvDetailList.Rows.Count > 0)
            {
                SaveCAP();
                isSave = true;
            }
            else
            {
                MessageBox.Show("Error found: Cannot be saved without any detail info.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            return isSave;
        }

        private void SaveCAP()
        {
            InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.Load(this.CAPHeaderId);
            if (oHeader == null)
            {
                oHeader = new InvtBatchCAP_Header();

                txtTxNumber.Text = Common.Utility.QueuingTxNumber(DAL.Common.Enums.TxType.CAP);
                oHeader.TxNumber = txtTxNumber.Text;
                oHeader.TxType = DAL.Common.Enums.TxType.CAP.ToString();

                oHeader.CreatedBy = DAL.Common.Config.CurrentUserId;
                oHeader.CreatedOn = DateTime.Now;
            }

            oHeader.TxDate = dtpTxDate.Value;
            oHeader.Status = Convert.ToInt32(cboStatus.Text == "HOLD" ? DAL.Common.Enums.Status.Draft.ToString("d") : DAL.Common.Enums.Status.Active.ToString("d"));

            oHeader.WorkplaceId = new Guid(cboWorkplace.SelectedValue.ToString());
            oHeader.StaffId = new Guid(cboStaff.SelectedValue.ToString());
            oHeader.SupplierId = new Guid(cboSupplier.SelectedValue.ToString());
            oHeader.SupplierRefernce = txtSupplierInvoice.Text;
            oHeader.Remarks = txtRemarks.Text;
            oHeader.Reference = txtReference.Text;
            oHeader.CurrencyCode = cboCurrency.Text;
            oHeader.ExchangeRate = Convert.ToDecimal(txtExchgRate.Text.Length == 0 ? "1" : txtExchgRate.Text);
            oHeader.LinkToAP = chkApLink.Checked;

            oHeader.ModifiedBy = DAL.Common.Config.CurrentUserId;
            oHeader.ModifiedOn = DateTime.Now;

            oHeader.Save();

            this.CAPHeaderId = oHeader.HeaderId;

            SaveCAPDetail();
            UpdateHeaderInfo();
        }

        private void SaveCAPDetail()
        {
            foreach (DataGridViewRow listItem in dgvDetailList.Rows)
            {
                if (DAL.Common.Utility.IsGUID(listItem.Cells[0].Value.ToString().Trim()) && DAL.Common.Utility.IsGUID(listItem.Cells[12].Value.ToString().Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Cells[0].Value.ToString().Trim());
                    InvtBatchCAP_Details oDetail = InvtBatchCAP_Details.Load(detailId);
                    if (oDetail == null)
                    {
                        oDetail = new InvtBatchCAP_Details();
                        oDetail.HeaderId = this.CAPHeaderId;
                        oDetail.TxNumber = txtTxNumber.Text;
                        oDetail.TxType = txtTxType.Text;
                        oDetail.LineNumber = Convert.ToInt32(listItem.Cells[1].Value.ToString().Length == 0 ? "1" : listItem.Cells[1].Value.ToString());
                    }
                    oDetail.ProductId = new Guid(listItem.Cells[12].Value.ToString().Trim());
                    oDetail.Qty = Convert.ToDecimal(listItem.Cells[8].Value.ToString().Length == 0 ? "0" : listItem.Cells[8].Value.ToString());
                    oDetail.UnitAmount = Convert.ToDecimal(listItem.Cells[10].Value.ToString().Length == 0 ? "0" : listItem.Cells[10].Value.ToString());
                    oDetail.UnitAmountInForeignCurrency = Convert.ToDecimal(listItem.Cells[9].Value.ToString().Length == 0 ? "0" : listItem.Cells[9].Value.ToString());

                    if (listItem.Cells[2].Value.ToString().Trim().ToUpper() == "REMOVED" && detailId != System.Guid.Empty)
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

        private void UpdateHeaderInfo()
        {
            InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.Load(this.CAPHeaderId);
            if (oHeader != null)
            {
                oHeader.TotalAmount = Convert.ToDecimal(DAL.Common.Utility.IsNumeric(txtTotalAmount.Text) ? txtTotalAmount.Text : "0");
                oHeader.Save();
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            InvtBatchCAP_Header oHeader = InvtBatchCAP_Header.Load(this.CAPHeaderId);
            if (oHeader != null)
            {
                string sql = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                DeleteDetails(sql);

                oHeader.Delete();
            }
        }

        private void DeleteDetails(string sql)
        {
            InvtBatchCAP_DetailsCollection oDetailList = InvtBatchCAP_Details.LoadCollection(sql);
            foreach (InvtBatchCAP_Details oDetail in oDetailList)
            {
                oDetail.Delete();
            }
        }
        #endregion

        #region Detail Toolbar Events

        protected override void ansAddNew_Click(object sender, EventArgs e)
        {
            //base.ansAddNew_Click(sender, e);
            Detail detail = new Detail();
            //detail.StockCode = dgvDetailList.SelectedRows[0].Cells[3].Value.ToString().Trim(); // Stock Code
            detail.Closed += new EventHandler(detail_Closed);
            detail.ShowDialog(this);
        }

        void detail_Closed(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            if (sender is Detail)
            {
                Detail detail = sender as Detail;
                if (detail != null)
                {
                    _ResultList = detail.ResultList;

                    BindCAPDetailsInfo(GetData());

                    if (dgvDetailList.Rows.Count > 0)
                    {
                        this.ansDetails.Items.Find("ansDelete", true)[0].Enabled = true;
                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        protected override void ansRefresh_Click(object sender, EventArgs e)
        {
            //base.ansRefresh_Click(sender, e);
            BindCAPDetailsInfo(GetData());
        }

        void ansDelete_Click(object sender, EventArgs e)
        {
            if (this.EditMode == Mode.New)
            {
                if (dgvDetailList.SelectedCells.Count > 0)
                {
                    this.dgvDetailList.Rows.RemoveAt(dgvDetailList.CurrentCell.RowIndex);
                    if (dgvDetailList.Rows.Count <= 0)
                    {
                        this.ansDetails.Items.Find("ansDelete", true)[0].Enabled = false;
                    }
                }
            }
            else
            {
                DataGridViewSelectedCellCollection itemList = dgvDetailList.SelectedCells;
                foreach (DataGridViewCell item in itemList)
                {
                    DataGridViewRow row = dgvDetailList.Rows[item.RowIndex];
                    if (DAL.Common.Utility.IsNumeric(row.Cells[8].Value.ToString()))
                    {
                        row.Cells[2].Value = row.Cells[2].Value.ToString().Trim().Length == 0 ? "REMOVED" : row.Cells[2].Value;
                    }
                }
            }
        }

        #endregion

        #region Form Toolbar Events

        protected override void cmdDelete_Click(object sender, EventArgs e)
        {
            //base.cmdDelete_Click(sender, e);
            if (MessageBox.Show("Delete Record ?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Delete();

                FormChanged = Modified.Clean;

                this.Close();
            }
        }

        protected override void cmdSave_Click(object sender, EventArgs e)
        {
            //base.cmdSave_Click(sender, e);
            if (MessageBox.Show("Save Record ?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (SaveItem())
                    {
                        FormChanged = Modified.Clean;

                        MessageBox.Show("Successfully Save", "Result");

                        this.Close();
                        Inventory.GoodsReceive.Wizard wizard = new Inventory.GoodsReceive.Wizard();
                        wizard.CAPHeaderId = this.CAPHeaderId;
                        wizard.EditMode = Mode.Edit;
                        wizard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Readonly transaction cannot be modified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected override void cmdSaveClose_Click(object sender, EventArgs e)
        {
            //base.cmdSaveClose_Click(sender, e);
            if (MessageBox.Show("Save Record, then close the wizard?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (SaveItem())
                    {
                        FormChanged = Modified.Clean;

                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Readonly transaction cannot be modified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        protected override void cmdSaveNew_Click(object sender, EventArgs e)
        {
            //base.cmdSaveNew_Click(sender, e);
            if (MessageBox.Show("Save Record, then open a new wizard?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (!this.Text.Contains("ReadOnly"))
                {
                    if (SaveItem())
                    {
                        FormChanged = Modified.Clean;

                        this.Close();
                        Inventory.GoodsReceive.Wizard wizard = new Inventory.GoodsReceive.Wizard();
                        wizard.CAPHeaderId = Guid.Empty;
                        wizard.EditMode = Mode.New;
                        wizard.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Readonly transaction cannot be modified!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DAL.Common.Utility.IsGUID(cboCurrency.SelectedValue.ToString()))
            {
                InitCurrency(new Guid(cboCurrency.SelectedValue.ToString()));

                FormChanged = Modified.Dirty;
            }
        }

        private void dgvDetailList_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow item = dgvDetailList.Rows[e.RowIndex];
            if (DAL.Common.Utility.IsNumeric(item.Cells[8].Value.ToString()))
            {
                item.Cells[2].Value = item.Cells[2].Value.ToString().Trim().Length == 0 ? "EDIT" : item.Cells[2].Value;

                decimal qty = Convert.ToDecimal(item.Cells[8].Value.ToString());
                decimal unitAmount = Convert.ToDecimal(DAL.Common.Utility.IsNumeric(item.Cells[10].Value.ToString()) ? item.Cells[10].Value.ToString() : "0");

                item.Cells[11].Value = qty * unitAmount;

                txtTotalAmount.Text = GetTotalAmount().ToString("n2");
            }
        }

        private void dgvDetailList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                Cursor.Current = Cursors.WaitCursor;

                Detail detail = new Detail();
                detail.StockCode = dgvDetailList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim(); // Stock Code
                detail.ResultList = SetDetailData(dgvDetailList.Rows[e.RowIndex].Cells[3].Value.ToString().Trim());
                detail.Closed += new EventHandler(detail_Closed);
                detail.ShowDialog(this);
            }
        }

        public List<DetailData> SetDetailData(string STKCODE)
        {
            List<DetailData> resultList = new List<DetailData>();

            foreach (DataGridViewRow row in dgvDetailList.Rows)
            {
                if (row.Cells[3].Value.ToString().Trim() == STKCODE)
                {
                    decimal qty = Convert.ToDecimal(row.Cells[8].Value.ToString()); // Qty
                    decimal uamt = Convert.ToDecimal(row.Cells[9].Value.ToString()); // Unit Amount

                    if (DAL.Common.Utility.IsGUID(row.Cells[12].Value.ToString()))
                    {
                        Guid productId = new Guid(row.Cells[12].Value.ToString());

                        DetailData detail = resultList.Find(d => d.ProductId == productId);

                        if (detail == null)
                        {
                            detail = new DetailData();
                            detail.ProductId = productId;
                            detail.Qty = qty;
                            detail.UnitAmount = uamt;
                        }
                        else
                        {
                            resultList.Remove(detail);

                            detail.Qty = qty;
                            detail.UnitAmount = uamt;
                        }

                        resultList.Add(detail);
                    }
                }
            }

            return resultList;
        }
    }
}
