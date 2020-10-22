#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;

using RT2020.DAL;

using System.Data.SqlClient;
using System.Configuration;
using RT2020.Client.Common;

#endregion

namespace RT2020.Client.Products.Wizard
{
    public partial class ProductWizard_Barcode : UserControl
    {
        private Guid _ProductId = System.Guid.Empty;

        #region Public Properties
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

        private Guid barcodeId = System.Guid.Empty;
        public Guid BarcodeId
        {
            get
            {
                return barcodeId;
            }
            set
            {
                barcodeId = value;
            }
        }
        #endregion

        public ProductWizard_Barcode(Guid productId)
        {
            InitializeComponent();

            if (productId != System.Guid.Empty)
            {
                this.ProductId = productId;

                BindingBarcodeList();
            }
        }

        #region ToolBar
        void tbBarcode_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "refresh":
                        txtBarcode.Text = string.Empty;
                        cboBarcodeType.Text = string.Empty;
                        chkPrimaryBarcode.Checked = false;
                        this.BarcodeId = System.Guid.Empty;
                        this.Update();
                        break;
                    case "generate":
                        GenBarcode();
                        break;
                    case "add":
                        AddTempBarcode();
                        break;
                    case "delete":
                        DeleteBarcode();
                        break;
                }
            }
        }
        #endregion

        #region Binding Barcode List

        private void BindingBarcodeList()
        {
            this.dgBarcodeList.AutoGenerateColumns = false;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProductBarcodeId, ProductId, '' AS Status, ROW_NUMBER() OVER (ORDER BY Barcode) AS rownum, ");
            sql.Append(" Barcode, BarcodeType, PrimaryBarcode ");
            sql.Append(" FROM ProductBarcode ");
            sql.Append(" WHERE ProductId = '").Append(this.ProductId.ToString()).Append("'");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

            this.dgBarcodeList.DataSource = ds.Tables[0];

            this.dgBarcodeList.ClearSelection();
        }
        #endregion

        #region Action Methods

        #region Verify Barcode
        private bool VerifyBarcodeNumber(string barcode)
        {
            bool isValidate = true;

            for (int i = 0; i < barcode.Length; i++)
            {
                if (!char.IsNumber(barcode[i]))
                {
                    isValidate = false;
                }
            }

            return isValidate;
        }

        private bool VerifyBarcodeCheckDigit(string barcode)
        {
            bool isValidate = true;
            string checkDigit = BarcodeUtility.GetCheckCode(barcode.Remove(barcode.Length - 1));
            if (checkDigit != barcode[barcode.Length - 1].ToString())
            {
                isValidate = false;
            }
            return isValidate;
        }

        private bool IsBarcodeValid()
        {
            int barcodeLen = 22;
            bool isValid = false;

            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                errorProvider.SetError(txtBarcode, "Can not be blank!");
                isValid = false;
            }
            else
            {
                if (txtBarcode.Text.Length > barcodeLen)
                {
                    errorProvider.SetError(txtBarcode, "Invalid Barcode Length!");
                    isValid = false;
                }
                else if (cboBarcodeType.Text.Length == 0)
                {
                    errorProvider.SetError(cboBarcodeType, "Cannot be blank!");
                    isValid = false;
                }
                else
                {
                    errorProvider.SetError(txtBarcode, string.Empty);
                    errorProvider.SetError(cboBarcodeType, string.Empty);
                    isValid = true;
                }
            }

            if (isValid)
            {
                string sql = "ProductId = '" + this.ProductId.ToString() + "' AND Barcode = '" + txtBarcode.Text.Trim() + "'";
                ProductBarcode oBarcode = ProductBarcode.LoadWhere(sql);
                if (oBarcode != null)
                {
                    errorProvider.SetError(txtBarcode, "Barcode Already Exists");
                    isValid = false;
                }
                else
                {
                    errorProvider.SetError(txtBarcode, string.Empty);
                    isValid = true;
                }

                if (isValid)
                {
                    //Verify type and check digit
                    switch (cboBarcodeType.SelectedItem.ToString())
                    {
                        case "INTERNAL (128B)": // INTERNAL (128B)
                            txtBarcode.Text = Utility.VerifyQuotes(txtBarcode.Text);
                            if (txtBarcode.Text.Length > 22)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(INTERNAL (128B)) must be <= 22!");
                                isValid = false;
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                                isValid = true;
                            }
                            break;
                        case "EAN8": // EAN8 (GTIN-8)
                            if (txtBarcode.Text.Length != 8)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(EAN8) must be 8!");
                                isValid = false;
                            }
                            else if (!VerifyBarcodeNumber(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "Barcode(EAN8) must be Numeric Only!");
                                isValid = false;
                            }
                            else if (!VerifyBarcodeCheckDigit(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "The Check Digit of Barcode(EAN8) is Not Valid!");
                                isValid = false;
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                                isValid = true;
                            }
                            break;
                        case "EAN13": // EAN13 (GTIN-13)
                            if (txtBarcode.Text.Length != 13)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(EAN13) must be 13!");
                                isValid = false;
                            }
                            else if (!VerifyBarcodeNumber(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "Barcode(EAN13) must be Numeric Only!");
                                isValid = false;
                            }
                            else if (!VerifyBarcodeCheckDigit(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "The Check Digit of Barcode(EAN13) is Not Valid!");
                                isValid = false;
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                                isValid = true;
                            }
                            break;
                        case "UPC12": // UPC12 (GTIN-12)
                            if (txtBarcode.Text.Length != 12)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(UPC12) must be 12!");
                                isValid = false;
                            }
                            else if (!VerifyBarcodeNumber(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "Barcode(UPC12) must be Numeric Only!");
                                isValid = false;
                            }
                            else if (!VerifyBarcodeCheckDigit(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "The Check Digit of Barcode(UPC12) is Not Valid!");
                                isValid = false;
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                                isValid = true;
                            }
                            break;
                    }
                }
            }

            return isValid;
        }
        #endregion

        #region Add Barcode Temporary
        private void AddTempBarcode()
        {
            // verify barcode
            if (IsBarcodeValid())
            {
                if (chkPrimaryBarcode.Checked)
                {
                    foreach (DataGridViewRow item in dgBarcodeList.Rows)
                    {
                        item.Cells["colPrimaryBarcode"].Value = "False";
                    }
                }

                if (dgBarcodeList.SelectedRows.Count > 0 && this.BarcodeId != Guid.Empty)
                {
                    if (dgBarcodeList.SelectedRows[0] != null && dgBarcodeList.SelectedRows[0].Cells["colProductBarcodeId"].Value.Equals(this.BarcodeId))
                    {
                        dgBarcodeList.SelectedRows[0].Cells["colStatus"].Value = "E"; // Edited
                        dgBarcodeList.SelectedRows[0].Cells["colBarcode"].Value = txtBarcode.Text;
                        dgBarcodeList.SelectedRows[0].Cells["colBarcodeType"].Value = cboBarcodeType.Text;
                        dgBarcodeList.SelectedRows[0].Cells["colPrimaryBarcode"].Value = chkPrimaryBarcode.Checked;
                    }
                }
                else
                {
                    int iCount = dgBarcodeList.Rows.Count + 1;

                    DataTable dt = this.dgBarcodeList.DataSource as DataTable;

                    DataRow newRow = dt.NewRow();
                    newRow["ProductBarcodeId"] = System.Guid.Empty; // new barcode
                    newRow["ProductId"] = this.ProductId; // new barcode
                    newRow["Status"] = ("A"); // Newly add
                    newRow["rownum"] = iCount; // Line Number
                    newRow["Barcode"] = txtBarcode.Text; // Barcode
                    newRow["BarcodeType"] = cboBarcodeType.Text; // Barcode Type
                    newRow["PrimaryBarcode"] = chkPrimaryBarcode.Checked; // Primary Barcode

                    dt.Rows.Add(newRow);

                    this.dgBarcodeList.DataSource = null;
                    this.dgBarcodeList.DataSource = dt;
                }

                // clear
                this.BarcodeId = System.Guid.Empty;
                txtBarcode.Text = string.Empty;
                cboBarcodeType.Text = string.Empty;
                chkPrimaryBarcode.Checked = false;
            }
        }
        #endregion

        public void AddBarcode()
        {
            for (int i = 0; i < dgBarcodeList.Rows.Count; i++)
            {
                DataGridViewRow item = dgBarcodeList.Rows[i];
                if (DAL.Common.Utility.IsGUID(item.Cells["colProductBarcodeId"].Value.ToString()))
                {
                    string sql = "ProductId = '" + this.ProductId.ToString() + "' AND ProductBarcodeId = '" + item.Cells["colProductBarcodeId"].Value.ToString() + "'";
                    ProductBarcode oBarcode = ProductBarcode.LoadWhere(sql);
                    if (item.Cells["colStatus"].Value.ToString() == "D" && oBarcode != null)
                    {
                        oBarcode.Delete();
                    }
                    else
                    {
                        if (oBarcode == null)
                        {
                            oBarcode = new ProductBarcode();
                            oBarcode.ProductId = this.ProductId;
                        }

                        // Save record
                        oBarcode.Barcode = item.Cells["colBarcode"].Value.ToString();
                        oBarcode.BarcodeType = item.Cells["colBarcodeType"].Value.ToString();
                        oBarcode.PrimaryBarcode = Convert.ToBoolean(item.Cells["colPrimaryBarcode"].Value.ToString());
                        oBarcode.Save();

                        item.Cells["colStatus"].Value = string.Empty;
                    }
                }
            }
        }

        private void GenBarcode()
        {
            StringBuilder barcode = new StringBuilder();
            RT2020.DAL.Product oItem = RT2020.DAL.Product.Load(this.ProductId);
            if (oItem != null)
            {
                barcode.Append(oItem.STKCODE);
                barcode.Append(oItem.APPENDIX1);
                barcode.Append(oItem.APPENDIX2);
                barcode.Append(oItem.APPENDIX3);
            }

            txtBarcode.Text = barcode.ToString();
            cboBarcodeType.SelectedIndex = 0;
            chkPrimaryBarcode.CheckState = CheckState.Checked;
        }

        private void DeleteBarcode()
        {
            if (dgBarcodeList.SelectedRows.Count > 0 && this.BarcodeId != Guid.Empty)
            {
                dgBarcodeList.SelectedRows[0].Cells["colStatus"].Value = "D"; // Removed
            }

            txtBarcode.Text = string.Empty;
            cboBarcodeType.Text = string.Empty;
            chkPrimaryBarcode.Checked = false;
        }
        #endregion

        private void dgBarcodeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                this.BarcodeId = new System.Guid(dgBarcodeList.Rows[e.RowIndex].Cells["colProductBarcodeId"].Value.ToString());

                txtBarcode.Text = dgBarcodeList.Rows[e.RowIndex].Cells["colBarcode"].Value.ToString();

                string barcodeType = dgBarcodeList.Rows[e.RowIndex].Cells["colBarcodeType"].Value.ToString();
                cboBarcodeType.Text = barcodeType.Contains("INTER") ? "INTERNAL (128B)" : barcodeType;
                chkPrimaryBarcode.Checked = Convert.ToBoolean(dgBarcodeList.Rows[e.RowIndex].Cells["colPrimaryBarcode"].Value.ToString());
            }
        }
    }
}