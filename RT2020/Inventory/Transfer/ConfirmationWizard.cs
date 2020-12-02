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

namespace RT2020.Inventory.Transfer
{
    public partial class ConfirmationWizard : Form, IGatewayComponent
    {
        private Guid _TxferId = System.Guid.Empty;
        private Guid _TxferDetailId = System.Guid.Empty;
        private Guid _ProductId = System.Guid.Empty;
        private bool _IsCompleted = false;
        private int _SelectedIndex = 0;

        #region Public Properties
        private string IsConfirmedTransaction
        {
            get;
            set;
        }

        public Guid TxferId
        {
            get
            {
                return _TxferId;
            }
            set
            {
                _TxferId = value;
            }
        }

        public Guid TxferDetailId
        {
            get
            {
                return _TxferDetailId;
            }
            set
            {
                _TxferDetailId = value;
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

        public bool IsCompleted
        {
            get
            {
                return _IsCompleted;
            }
            set
            {
                _IsCompleted = value;
            }
        }
        #endregion

        public ConfirmationWizard(Guid txferId)
        {
            InitializeComponent();

            this.TxferId = txferId;
            this.IsConfirmedTransaction = "N";

            FillCboList();
            SetToolBar();
            LoadTxferInfo();
        }

        #region IGatewayComponent Members

        void IGatewayComponent.ProcessRequest(IContext objContext, string strAction)
        {
            DataTable dt = Reports.DataSource.Worksheet(this.txtTxNumber.Text, this.txtTxNumber.Text, this.dtpTxDate.Value, this.dtpTxDate.Value);

            string filename = txtTxNumber.Text.Trim() + ".pdf";

            RT2020.Inventory.Transfer.Reports.WorksheetRpt report = new RT2020.Inventory.Transfer.Reports.WorksheetRpt();
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
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = false;

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
            cmdDelete.Enabled = false;

            // cmdPrint
            ToolBarButton cmdPrint = new ToolBarButton("Print", "Print");
            cmdPrint.Tag = "Print";
            cmdPrint.Image = new IconResourceHandle("16x16.16_print.gif");
            cmdPrint.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

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
                        Link.Open(new Gizmox.WebGUI.Common.Gateways.GatewayReference(this, "open"));
                        break;
                }
            }
        }
        #endregion

        #region Fill Combo List
        private void FillCboList()
        {
            FillFromLocationList();
            FillToLocationList();
        }

        private void FillFromLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboFromLocation, "WorkplaceCode", false);
        }

        private void FillToLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboToLocation, "WorkplaceCode", false);
            cboToLocation.SelectedIndex = cboToLocation.Items.Count - 1;
        }
        #endregion

        #region Save Txfer Header Info
        private bool Save()
        {
            bool isSave = false;

            if (lvDetailsList.Items.Count > 0)
            {
                if (!cboFromLocation.SelectedValue.Equals(cboToLocation.SelectedValue))
                {
                    Confirmation();
                    isSave = true;
                }
                else
                {
                    MessageBox.Show("Cannot transfer to a same location!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Does not allow saving record without details", "Save Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tabGoodsTxfer.SelectedIndex = 1;
            }

            return isSave;
        }

        private void Confirmation()
        {
            InvtBatchTXF_Header oHeader = InvtBatchTXF_Header.Load(this.TxferId);
            if (oHeader != null)
            {
                SaveTxferDetail();

                // Update TXF SubLedger
                UpdateTXFSubLedger(oHeader.TxNumber);

                // Update Ledger
                UpdateLedger(oHeader.TxNumber);

                // Update Product Info
                UpdateProduct(oHeader);

                oHeader.CONFIRM_TRF = this.IsConfirmedTransaction;
                oHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                oHeader.CONFIRM_TRF_LASTUSER = Common.Config.CurrentUserId;
                oHeader.ModifiedBy = Common.Config.CurrentUserId;
                oHeader.ModifiedOn = DateTime.Now;

                oHeader.Save();

                this.TxferId = oHeader.HeaderId;
            }
        }

        #region SubLedger
        private void UpdateTXFSubLedger(string txnumber_Batch)
        {
            InvtSubLedgerTXF_Header oSubTXF = InvtSubLedgerTXF_Header.Load(this.TxferId);
            if (oSubTXF != null)
            {
                UpdateTXFSubLedgerDetail(oSubTXF.HeaderId);

                oSubTXF.CONFIRM_TRF = this.IsConfirmedTransaction;
                oSubTXF.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                oSubTXF.CONFIRM_TRF_LASTUSER = Common.Config.CurrentUserId;

                oSubTXF.ModifiedBy = Common.Config.CurrentUserId;
                oSubTXF.ModifiedOn = DateTime.Now;

                oSubTXF.Save();
            }
        }

        private void UpdateTXFSubLedgerDetail(Guid subledgerHeaderId)
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.SubItems[10].Text))
                {
                    string sql = "HeaderId = '" + subledgerHeaderId.ToString() + "' AND ProductId = '" + listItem.SubItems[10].Text + "'";
                    InvtSubLedgerTXF_Details oSubLedgerDetail = InvtSubLedgerTXF_Details.LoadWhere(sql);
                    if (oSubLedgerDetail != null)
                    {
                        if (Common.Utility.IsNumeric(listItem.SubItems[9].Text))
                        {
                            oSubLedgerDetail.QtyConfirmed = Convert.ToDecimal(listItem.SubItems[9].Text);

                            oSubLedgerDetail.Save();
                        }
                    }
                }
            }
        }
        #endregion

        #region Ledger
        private void UpdateLedger(string txnumber_Batch)
        {
            InvtLedgerHeader oLedgerHeader = InvtLedgerHeader.Load(this.TxferId);
            if (oLedgerHeader != null)
            {
                UpdateLedgerDetails(oLedgerHeader.HeaderId);

                oLedgerHeader.CONFIRM_TRF = this.IsConfirmedTransaction;
                oLedgerHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                oLedgerHeader.CONFIRM_TRF_LASTUSER = ModelEx.StaffEx.GetStaffNumberById(Common.Config.CurrentUserId);

                oLedgerHeader.ModifiedBy = Common.Config.CurrentUserId;
                oLedgerHeader.ModifiedOn = DateTime.Now;
                oLedgerHeader.Save();
            }
        }

        private void UpdateLedgerDetails(Guid ledgerHeaderId)
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.SubItems[10].Text))
                {
                    string sql = "HeaderId = '" + ledgerHeaderId.ToString() + "' AND ProductId = '" + listItem.SubItems[10].Text + "'";
                    InvtLedgerDetails oLedgerDetail = InvtLedgerDetails.LoadWhere(sql);
                    if (oLedgerDetail != null)
                    {
                        if (Common.Utility.IsNumeric(listItem.SubItems[9].Text))
                        {
                            oLedgerDetail.Qty = Convert.ToDecimal(listItem.SubItems[9].Text);

                            oLedgerDetail.Save();
                        }
                    }
                }
            }
        }
        #endregion

        #region FEP
        private void UpdateFEP()
        {
            FepBatchHeader oFepHeader = FepBatchHeader.Load(this.TxferId);
            if (oFepHeader != null)
            {
                UpdateLedgerDetails(oFepHeader.HeaderId);

                oFepHeader.CONFIRM_TRF = this.IsConfirmedTransaction;
                oFepHeader.CONFIRM_TRF_LASTUPDATE = DateTime.Now;
                oFepHeader.CONFIRM_TRF_LASTUSER = ModelEx.StaffEx.GetStaffNumberById(Common.Config.CurrentUserId);

                oFepHeader.ModifiedBy = Common.Config.CurrentUserId;
                oFepHeader.ModifiedOn = DateTime.Now;
                oFepHeader.Save();
            }
        }

        private void UpdateFepDetails(Guid fepHeaderId)
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.SubItems[10].Text))
                {
                    string sql = "HeaderId = '" + fepHeaderId.ToString() + "' AND ProductId = '" + listItem.SubItems[10].Text + "'";
                    FepBatchDetail oFepDetail = FepBatchDetail.LoadWhere(sql);
                    if (oFepDetail != null)
                    {
                        if (Common.Utility.IsNumeric(listItem.SubItems[9].Text))
                        {
                            oFepDetail.CONFIRM_TRF_QTY = Convert.ToDecimal(listItem.SubItems[9].Text);

                            oFepDetail.Save();
                        }
                    }
                }
            }
        }
        #endregion

        #region Product
        private void UpdateProduct(InvtBatchTXF_Header oBatchHeader)
        {
            string sql = "HeaderId = '" + oBatchHeader.HeaderId.ToString() + "'";
            InvtBatchTXF_DetailsCollection detailsList = InvtBatchTXF_Details.LoadCollection(sql);
            for (int i = 0; i < detailsList.Count; i++)
            {
                InvtBatchTXF_Details detail = detailsList[i];
                //Out
                UpdateProductQty(detail.ProductId, oBatchHeader.FromLocation, detail.QtyConfirmed * (-1));
                //In
                UpdateProductQty(detail.ProductId, oBatchHeader.ToLocation, detail.QtyConfirmed);
            }
        }

        private void UpdateProductQty(Guid productId, Guid workplaceId, decimal qty)
        {
            string sql = "ProductId = '" + productId.ToString() + "' AND WorkplaceId = '" + workplaceId.ToString() + "'";
            ProductWorkplace wpProd = ProductWorkplace.LoadWhere(sql);
            if (wpProd == null)
            {
                wpProd = new ProductWorkplace();
                wpProd.ProductId = productId;
                wpProd.WorkplaceId = workplaceId;
            }
            wpProd.CDQTY += qty;
            if (qty > 0)
            {
                wpProd.RECQTY += qty;
            }
            wpProd.Save();
        }
        #endregion

        #endregion

        #region Load Txfer Header Info
        private void LoadTxferInfo()
        {
            InvtBatchTXF_Header oHeader = InvtBatchTXF_Header.Load(this.TxferId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;
                txtTxType.Text = oHeader.TxType;

                cboFromLocation.SelectedValue = oHeader.FromLocation;
                cboToLocation.SelectedValue = oHeader.ToLocation;
                dtpTxDate.Value = oHeader.TxDate;

                txtLatestConfirmedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.CONFIRM_TRF_LASTUPDATE, false);
                txtLatestConfirmedBy.Text = ModelEx.StaffEx.GetStaffNumberById(oHeader.CONFIRM_TRF_LASTUSER);

                txtRecordStatus.Text = string.Format(txtRecordStatus.Text, oHeader.TxType);

                txtConfirmationStatus.Text = oHeader.CONFIRM_TRF == "Y" ? "Completed" : (oHeader.CONFIRM_TRF.Trim() == "" ? "Unprocessed" : "Incompleted");
            }
            else
            {
                LoadTxferLedgerInfo();
                LoadTxferFepInfo();
            }

            BindTxferDetailsInfo();
            CalcTotal();
        }

        private void LoadTxferLedgerInfo()
        {
            InvtLedgerHeader oHeader = InvtLedgerHeader.Load(this.TxferId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;
                txtTxType.Text = oHeader.TxType;

                cboFromLocation.SelectedValue = oHeader.WorkplaceId;
                cboToLocation.SelectedValue = oHeader.VsLocationId;
                dtpTxDate.Value = oHeader.TxDate;

                txtLatestConfirmedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.CONFIRM_TRF_LASTUPDATE, false);
                txtLatestConfirmedBy.Text = oHeader.CONFIRM_TRF_LASTUSER;

                txtRecordStatus.Text = string.Format(txtRecordStatus.Text, oHeader.TxType);
            }
        }

        private void LoadTxferFepInfo()
        {
            FepBatchHeader oHeader = FepBatchHeader.Load(this.TxferId);
            if (oHeader != null)
            {
                txtTxNumber.Text = oHeader.TxNumber;
                txtTxType.Text = oHeader.TxType;

                cboFromLocation.SelectedValue = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(oHeader.SHOP);
                cboToLocation.SelectedValue = ModelEx.WorkplaceEx.GetWorkplaceIdByCode(oHeader.FTSHOP);
                dtpTxDate.Value = oHeader.TxDate;

                txtLatestConfirmedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oHeader.CONFIRM_TRF_LASTUPDATE, false);
                txtLatestConfirmedBy.Text = oHeader.CONFIRM_TRF_LASTUSER;

                txtRecordStatus.Text = string.Format(txtRecordStatus.Text, oHeader.TxType);
            }
        }

        private decimal GetRetailPrice(Guid productId)
        {
            decimal rtPrice = 1;

            RT2020.DAL.Product oProd = RT2020.DAL.Product.Load(productId);
            if (oProd != null)
            {
                rtPrice = oProd.RetailPrice;
            }

            return rtPrice;
        }
        #endregion

        #region Delete
        private void Delete()
        {
            InvtBatchTXF_Header oHeader = InvtBatchTXF_Header.Load(this.TxferId);
            if (oHeader != null)
            {
                string sql = "HeaderId = '" + oHeader.HeaderId.ToString() + "'";

                DeleteDetails(sql);

                oHeader.Delete();
            }
        }

        private void DeleteDetails(string sql)
        {
            InvtBatchTXF_DetailsCollection oDetailList = InvtBatchTXF_Details.LoadCollection(sql);
            foreach (InvtBatchTXF_Details oDetail in oDetailList)
            {
                oDetail.Delete();
            }
        }
        #endregion

        #region Message Handler
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Transfer.ConfirmationWizard wizard = new RT2020.Inventory.Transfer.ConfirmationWizard(this.TxferId);
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    MessageBox.Show("Success!", "Save Result");
                    this.IsCompleted = true;

                    this.Close();
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                this.Close();
            }
        }

        private void TabChangedMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Transfer.ConfirmationWizard wizard = new RT2020.Inventory.Transfer.ConfirmationWizard(this.TxferId);
                    wizard.ShowDialog();
                }
            }
            else
            {
                tabGoodsTxfer.SelectedIndex = 0;
            }
        }
        #endregion

        #region Txfer Detail

        #region Bind Txfer Detail List
        private void BindTxferDetailsInfo()
        {
            lvDetailsList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" QtyRequested, QtyConfirmed, ProductId ");
            sql.Append(" FROM vwTxferDetailsList ");
            sql.Append(" WHERE HeaderId = '").Append(this.TxferId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem listItem = lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); // DetailsId
                    listItem.SubItems.Add(reader.GetInt32(1).ToString()); // LineNumber
                    listItem.SubItems.Add(string.Empty);
                    listItem.SubItems.Add(reader.GetString(2)); // STKCode
                    listItem.SubItems.Add(reader.GetString(3)); // Appendix1
                    listItem.SubItems.Add(reader.GetString(4)); // Appendix2
                    listItem.SubItems.Add(reader.GetString(5)); // Appendix3
                    listItem.SubItems.Add(reader.GetString(6)); // ProductName
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // QtyRequested
                    listItem.SubItems.Add(reader.GetDecimal(8).ToString("n0")); // QtyConfirmed
                    listItem.SubItems.Add(reader.GetGuid(9).ToString()); // ProductId

                    iCount++;
                }
            }

            lblLineCount.Text = (iCount - 1).ToString();
        }
        #endregion

        #region Save Txfer Detail Info
        private void SaveTxferDetail()
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text.Trim()) && Common.Utility.IsGUID(listItem.SubItems[10].Text.Trim()))
                {
                    System.Guid detailId = new Guid(listItem.Text.Trim());
                    InvtBatchTXF_Details oDetail = InvtBatchTXF_Details.Load(detailId);
                    if (oDetail != null)
                    {
                        oDetail.QtyConfirmed = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);

                        oDetail.Save();
                    }

                    InvtLedgerDetails oLedgerDetail = InvtLedgerDetails.Load(detailId);
                    if (oLedgerDetail != null)
                    {
                        oLedgerDetail.CONFIRM_TRF_QTY = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);

                        oLedgerDetail.Save();

                        InvtSubLedgerTXF_Details oSubLedgerDetail = InvtSubLedgerTXF_Details.Load(oLedgerDetail.SubLedgerDetailsId);
                        if (oSubLedgerDetail != null)
                        {
                            oSubLedgerDetail.QtyConfirmed = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);

                            oSubLedgerDetail.Save();
                        }
                    }

                    FepBatchDetail oFepDetail = FepBatchDetail.Load(detailId);
                    if (oFepDetail != null)
                    {
                        oFepDetail.CONFIRM_TRF_QTY = Convert.ToDecimal(listItem.SubItems[9].Text.Length == 0 ? "0" : listItem.SubItems[9].Text);

                        oFepDetail.Save();
                    }

                    if (listItem.SubItems[9].Text.Trim().CompareTo(listItem.SubItems[8].Text.Trim()) == 0)
                    {
                        this.IsConfirmedTransaction = "Y";
                    }
                    else
                    {
                        this.IsConfirmedTransaction = "N";
                    }
                }
            }
        }
        #endregion

        #region Load Txfer Detail Info
        private void LoadTxferDetailsInfo(int row)
        {
            ListViewItem curRow = lvDetailsList.Items[row];

                    //ListViewItem listItem = lvDetailsList.Items.Add(reader.GetGuid(0).ToString()); // DetailsId
                    //listItem.SubItems.Add(reader.GetInt32(1).ToString()); // LineNumber
                    //listItem.SubItems.Add(string.Empty);
                    //listItem.SubItems.Add(reader.GetString(2)); // STKCode
                    //listItem.SubItems.Add(reader.GetString(3)); // Appendix1
                    //listItem.SubItems.Add(reader.GetString(4)); // Appendix2
                    //listItem.SubItems.Add(reader.GetString(5)); // Appendix3
                    //listItem.SubItems.Add(reader.GetString(6)); // ProductName
                    //listItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // QtyRequested
                    //listItem.SubItems.Add(reader.GetDecimal(8).ToString("n0")); // QtyConfirmed
                    //listItem.SubItems.Add(reader.GetGuid(9).ToString()); // ProductId
            String stkcode = curRow.SubItems[3].Text;
            String appendix1 = curRow.SubItems[4].Text;
            String appendix2 = curRow.SubItems[5].Text;
            String appendix3 = curRow.SubItems[6].Text;
            //basicProduct.SelectedItem = _ProductId;
            basicProduct.SelectedText = stkcode + " " + appendix1 + " " + appendix2 + " " + appendix3;
            txtDescription.Text = curRow.SubItems[7].Text;
            txtRequiredQty.Text = curRow.SubItems[8].Text;
            txtConfirmedQty.Text = curRow.SubItems[9].Text;
        }

        private void LoadTxferDetailsInfo(Guid detailId)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT  DetailsId, LineNumber, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ");
            sql.Append(" QtyRequested, QtyConfirmed, ProductId ");
            sql.Append(" FROM vwTxferDetailsList ");
            sql.Append(" WHERE DetailsId = '").Append(detailId.ToString()).Append("'");

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    basicProduct.SelectedItem = reader.GetGuid(9);

                    txtDescription.Text = reader.GetString(6);
                    txtRequiredQty.Text = reader.GetDecimal(7).ToString("n0");
                    txtConfirmedQty.Text = reader.GetDecimal(8).ToString("n0");

                    _ProductId = reader.GetGuid(9);
                    _TxferDetailId = reader.GetGuid(0);

                    string stkcode = string.Empty, appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;
                    ItemInfo(ref stkcode, ref appendix1, ref appendix2, ref appendix3);
                    basicProduct.SelectedText = stkcode + " " + appendix1 + " " + appendix2 + " " + appendix3;
                }
            }
        }
        #endregion

        #endregion

        #region Confirm Item

        private void ItemInfo(ref string stkCode, ref string appendix1, ref string appendix2, ref string appendix3)
        {
            if (basicProduct.SelectedItem != null)
            {
                RT2020.DAL.Product oProd = RT2020.DAL.Product.Load(new Guid(basicProduct.SelectedItem.ToString()));
                if (oProd != null)
                {
                    stkCode = oProd.STKCODE;
                    appendix1 = oProd.APPENDIX1;
                    appendix2 = oProd.APPENDIX2;
                    appendix3 = oProd.APPENDIX3;

                    _ProductId = oProd.ProductId;
                }
            }
        }

        private void ConfirmItem(ListViewItem sourceItem, bool isAllConfirmed)
        {
            ListViewItem listItem = sourceItem;
            listItem.SubItems[2].Text = "EDIT"; // Status

            if (isAllConfirmed)
            {
                listItem.SubItems[9].Text = listItem.SubItems[8].Text; // Confirmed Qty
            }
            else
            {
                listItem.SubItems[9].Text = txtConfirmedQty.Text; // Confirmed Qty
            }

            CalcTotal();
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsNumeric(txtConfirmedQty.Text.Trim()))
                {
                    ConfirmItem(lvDetailsList.SelectedItem, false);
                }
                else
                {
                    MessageBox.Show("Please input a valid number into box 'ConfirmedQty'", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnResetAllItems_Click(object sender, EventArgs e)
        {
            BindTxferDetailsInfo();
        }

        private void btnConfirmAllItems_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                ConfirmItem(listItem, true);
            }
        }

        private void CalcTotal()
        {
            decimal ttlRequiredQty = 0, ttlConfirmedQty = 0;
            foreach (ListViewItem listItem in lvDetailsList.Items)
            {
                ttlRequiredQty += Convert.ToDecimal(listItem.SubItems[8].Text.Length > 0 ? listItem.SubItems[8].Text : "0");
                ttlConfirmedQty += Convert.ToDecimal(listItem.SubItems[9].Text.Length > 0 ? listItem.SubItems[9].Text : "0");
            }

            txtTotalRequiredQty.Text = ttlRequiredQty.ToString("n0");
            txtTotalConfirmedQty.Text = ttlConfirmedQty.ToString("n0");
        }
        #endregion

        private void lvDetailsList_Click(object sender, EventArgs e)
        {
            if (lvDetailsList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvDetailsList.SelectedItem.Text))
                {
                    _TxferDetailId = new Guid(lvDetailsList.SelectedItem.Text);
                    _SelectedIndex = lvDetailsList.SelectedIndex;

                    //LoadTxferDetailsInfo(_TxferDetailId);
                    LoadTxferDetailsInfo(lvDetailsList.SelectedIndex);
                }
            }
        }
    }
}