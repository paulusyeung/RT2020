#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

using RT2020.Controls;
using DevExpress.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using RT2020.Helper;
using System.Data.Entity;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Barcode : UserControl
    {
        #region Public Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _ProductId = Guid.Empty;
        public Guid ProductId
        {
            get { return _ProductId; }
            set { _ProductId = value; }
        }

        private Guid _BarcodeId = Guid.Empty;
        public Guid BarcodeId
        {
            get { return _BarcodeId; }
            set { _BarcodeId = value; }
        }
        #endregion

        public ProductWizard_Barcode()
        {
            InitializeComponent();
        }

        private void ProductWizard_Barcode_Load(object sender, EventArgs e)
        {

            SetCaptions();
            SetAttributes();
            SetToolBar();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadData();
                    break;
            }
        }

        #region SetCaptions, SetAttributes
        private void SetCaptions()
        {
            lblBarcode.Text = WestwindHelper.GetWordWithColon("barcode", "Product");
            lblBarcodeType.Text = WestwindHelper.GetWordWithColon("barcode.type", "Product");
            lblPrimaryBarcode.Text = WestwindHelper.GetWordWithColon("barcode.primary", "Product");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colBarcode.Text = WestwindHelper.GetWord("barcode", "Product");
            colBarcodeType.Text = WestwindHelper.GetWord("barcode.type", "Product");
            colPrimaryBarcode.Text = WestwindHelper.GetWord("barcode.primary", "Product");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colBarcode.TextAlign = HorizontalAlignment.Left;
            colBarcode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colBarcodeType.TextAlign = HorizontalAlignment.Left;
            colBarcodeType.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPrimaryBarcode.TextAlign = HorizontalAlignment.Center;
            colPrimaryBarcode.ContentAlign = ExtendedHorizontalAlignment.Center;
        }
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbBarcode.MenuHandle = false;
            this.tbBarcode.DragHandle = false;
            this.tbBarcode.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdRefresh
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "Refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbBarcode.Buttons.Add(cmdRefresh);

            // cmdGenerate
            ToolBarButton cmdGenerate = new ToolBarButton("Generate", WestwindHelper.GetWord("edit.generate", "General"));
            cmdGenerate.Tag = "Generate";
            cmdGenerate.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbBarcode.Buttons.Add(cmdGenerate);

            // cmdAdd
            ToolBarButton cmdAdd = new ToolBarButton("Add", WestwindHelper.GetWord("edit.new", "General"));
            cmdAdd.Tag = "Add";
            cmdAdd.Image = new IconResourceHandle("16x16.16_converttooppo.gif");

            this.tbBarcode.Buttons.Add(cmdAdd);
            this.tbBarcode.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            this.tbBarcode.Buttons.Add(cmdDelete);

            this.tbBarcode.ButtonClick += new ToolBarButtonClickEventHandler(tbBarcode_ButtonClick);
        }

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
                        _BarcodeId = Guid.Empty;
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
            this.lvBarcodeList.ListViewItemSorter = new ListViewItemSorter(this.lvBarcodeList);
            this.lvBarcodeList.Items.Clear();

            int iCount = 1;

            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProductBarcodeId, ProductId,  ROW_NUMBER() OVER (ORDER BY Barcode) AS rownum, ");
            sql.Append(" Barcode, BarcodeType, PrimaryBarcode ");
            sql.Append(" FROM ProductBarcode ");
            sql.Append(" WHERE ProductId = '").Append(_ProductId.ToString()).Append("'");

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvBarcodeList.Items.Add(reader.GetGuid(0).ToString()); // ProductBarcodeId
                    objItem.SubItems.Add(string.Empty); // Status
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(3)); // Barcode
                    objItem.SubItems.Add(reader.GetString(4)); // Barcode Type
                    objItem.SubItems.Add(reader.GetBoolean(5) ? "*" : ""); // Primary Barcode

                    iCount++;
                }
            }
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

        private void CheckBarcode()
        {
            int barcodeLen = 22;
            bool isValid = false;

            if (string.IsNullOrEmpty(txtBarcode.Text))
            {
                errorProvider.SetError(txtBarcode, "Can not be blank!");
            }
            else
            {
                if (txtBarcode.Text.Length > barcodeLen)
                {
                    errorProvider.SetError(txtBarcode, "Invalid Barcode Length!");
                }
                else if (cboBarcodeType.Text.Length == 0)
                {
                    errorProvider.SetError(cboBarcodeType, "Cannot be blank!");
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
                //ProductBarcode oBarcode = ProductBarcode.LoadWhere(sql);
                if (ModelEx.ProductBarcodeEx.IsBarcodeInUse(this.ProductId, txtBarcode.Text.Trim()))
                {
                    errorProvider.SetError(txtBarcode, "Barcode Already Exists");
                }
                else
                {
                    errorProvider.SetError(txtBarcode, string.Empty);
                }

                if (string.IsNullOrEmpty(errorProvider.GetError(txtBarcode)))
                {
                    //Verify type and check digit
                    switch (cboBarcodeType.SelectedItem.ToString())
                    {
                        case "INTERNAL (128B)": // INTERNAL (128B)
                            txtBarcode.Text = Utility.VerifyQuotes(txtBarcode.Text);
                            if (txtBarcode.Text.Length > 22)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(INTERNAL (128B)) must be <= 22!");
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                            }
                            break;
                        case "EAN8": // EAN8 (GTIN-8)
                            if (txtBarcode.Text.Length != 8)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(EAN8) must be 8!");
                            }
                            else if (!VerifyBarcodeNumber(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "Barcode(EAN8) must be Numeric Only!");
                            }
                            else if (!VerifyBarcodeCheckDigit(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "The Check Digit of Barcode(EAN8) is Not Valid!");
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                            }
                            break;
                        case "EAN13": // EAN13 (GTIN-13)
                            if (txtBarcode.Text.Length != 13)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(EAN13) must be 13!");
                            }
                            else if (!VerifyBarcodeNumber(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "Barcode(EAN13) must be Numeric Only!");
                            }
                            else if (!VerifyBarcodeCheckDigit(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "The Check Digit of Barcode(EAN13) is Not Valid!");
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                            }
                            break;
                        case "UPC12": // UPC12 (GTIN-12)
                            if (txtBarcode.Text.Length != 12)
                            {
                                errorProvider.SetError(txtBarcode, "The length of Barcode(UPC12) must be 12!");
                            }
                            else if (!VerifyBarcodeNumber(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "Barcode(UPC12) must be Numeric Only!");
                            }
                            else if (!VerifyBarcodeCheckDigit(txtBarcode.Text))
                            {
                                errorProvider.SetError(txtBarcode, "The Check Digit of Barcode(UPC12) is Not Valid!");
                            }
                            else
                            {
                                errorProvider.SetError(txtBarcode, string.Empty);
                            }
                            break;
                    }
                }
            }
        }
        #endregion

        #region Add Barcode Temporary
        private void AddTempBarcode()
        {
            // verify barcode
            CheckBarcode();

            if (string.IsNullOrEmpty(errorProvider.GetError(txtBarcode)) && string.IsNullOrEmpty(errorProvider.GetError(cboBarcodeType)))
            {
                if (lvBarcodeList.SelectedItem != null && lvBarcodeList.SelectedItem.Text == _BarcodeId.ToString())
                {
                    lvBarcodeList.SelectedItem.SubItems[1].Text = "E"; // Edited
                    lvBarcodeList.SelectedItem.SubItems[3].Text = txtBarcode.Text;
                    lvBarcodeList.SelectedItem.SubItems[4].Text = cboBarcodeType.Text;
                    lvBarcodeList.SelectedItem.SubItems[5].Text = chkPrimaryBarcode.Checked ? "*" : "";
                }
                else
                {
                    if (chkPrimaryBarcode.Checked)
                    {
                        foreach (ListViewItem item in lvBarcodeList.Items)
                        {
                            item.SubItems[4].Text = string.Empty;
                        }
                    }

                    int iCount = lvBarcodeList.Items.Count + 1;

                    ListViewItem objItem = this.lvBarcodeList.Items.Add(Guid.Empty.ToString()); // new barcode
                    objItem.SubItems.Add("N"); // Newly add
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(txtBarcode.Text); // Barcode
                    objItem.SubItems.Add(cboBarcodeType.Text); // Barcode Type
                    objItem.SubItems.Add(chkPrimaryBarcode.Checked ? "*" : ""); // Primary Barcode
                }

                // clear
                _BarcodeId = Guid.Empty;
                txtBarcode.Text = string.Empty;
                cboBarcodeType.Text = string.Empty;
                chkPrimaryBarcode.Checked = false;
            }
        }
        #endregion

        public void AddBarcode()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                for (int i = 0; i < lvBarcodeList.Items.Count; i++)
                {
                    Guid pbarcodeId = Guid.Empty;
                    ListViewItem item = lvBarcodeList.Items[i];
                    if (Guid.TryParse(item.Text, out _BarcodeId))
                    {
                        //string sql = "ProductId = '" + this.ProductId.ToString() + "' AND ProductBarcodeId = '" + item.Text + "'";
                        var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == this.ProductId && x.ProductBarcodeId == _BarcodeId).FirstOrDefault();
                        if (item.SubItems[1].Text == "D" && oBarcode != null)
                        {
                            ctx.ProductBarcode.Remove(oBarcode);
                        }
                        else
                        {
                            if (oBarcode == null)
                            {
                                oBarcode = new EF6.ProductBarcode();
                                oBarcode.ProductBarcodeId = Guid.NewGuid();
                                oBarcode.ProductId = this.ProductId;
                                ctx.ProductBarcode.Add(oBarcode);
                            }

                            // Save record
                            oBarcode.Barcode = item.SubItems[3].Text;
                            oBarcode.BarcodeType = item.SubItems[4].Text;
                            oBarcode.PrimaryBarcode = (item.SubItems[5].Text.Length > 0);
                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }

        private void GenBarcode()
        {
            StringBuilder barcode = new StringBuilder();
            var oItem = ModelEx.ProductEx.Get(this.ProductId);
            if (oItem != null)
            {
                barcode.Append(oItem.STKCODE);
                barcode.Append(oItem.APPENDIX1);
                barcode.Append(oItem.APPENDIX2);
                barcode.Append(oItem.APPENDIX3);
            }

            txtBarcode.Text = barcode.ToString();
            cboBarcodeType.SelectedIndex = 0;
            chkPrimaryBarcode.CheckState = Gizmox.WebGUI.Forms.CheckState.Checked;
        }

        private void DeleteBarcode()
        {
            if (lvBarcodeList.SelectedItem != null && lvBarcodeList.SelectedItem.Text == _BarcodeId.ToString())
            {
                lvBarcodeList.SelectedItem.SubItems[1].Text = "D"; // Removed
            }

            txtBarcode.Text = string.Empty;
            cboBarcodeType.Text = string.Empty;
            chkPrimaryBarcode.Checked = false;
        }
        #endregion

        #region Load Data
        public void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                int iCount = 1;
                var list = ctx.ProductBarcode.Where(x => x.ProductId == _ProductId).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvBarcodeList.Items.Add(item.ProductBarcodeId.ToString()); // ProductBarcodeId
                    objItem.SubItems.Add(string.Empty); // Status
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.Barcode); // Barcode
                    objItem.SubItems.Add(item.BarcodeType); // Barcode Type
                    objItem.SubItems.Add(item.PrimaryBarcode ? "*" : ""); // Primary Barcode

                    iCount++;
                }
            }
        }
        #endregion

        #region Save Data
        public bool SaveData()
        {
            var result = false;


            return result;
        }
        #endregion

        private void lvBarcodeList_Click(object sender, EventArgs e)
        {
            if (lvBarcodeList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvBarcodeList.SelectedItem.Text, out id))
                {
                    _BarcodeId = id;

                    txtBarcode.Text = lvBarcodeList.SelectedItem.SubItems[3].Text;
                    cboBarcodeType.Text = lvBarcodeList.SelectedItem.SubItems[4].Text.Contains("INTER") ? "INTERNAL (128B)" : lvBarcodeList.SelectedItem.SubItems[4].Text;
                    chkPrimaryBarcode.Checked = (lvBarcodeList.SelectedItem.SubItems[5].Text.Length > 0);
                }
            }
        }
    }
}