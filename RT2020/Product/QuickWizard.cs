#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.Controls;
using System.IO;
using System.Linq;
using RT2020.Helper;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace RT2020.Product
{
    public partial class QuickWizard : Form
    {
        string mstrDirectory = string.Empty;

        public QuickWizard()
        {
            InitializeComponent();
        }

        private void QuickWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            FillComboList();
            mstrDirectory = Path.Combine(Context.Config.GetDirectory("RTImages"), "Product");
            SetLayout();
        }

        #region SetCaptions, SetAttributes, SetLayout
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("product.product.quick", "Menu");

            colRow.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colAppendix1.Text = WestwindHelper.GetWord("appendix.appendix1", "Product");
            colAppendix2.Text = WestwindHelper.GetWord("appendix.appendix2", "Product");
            colAppendix3.Text = WestwindHelper.GetWord("appendix.appendix3", "Product");

            lblAppendix1.Text = WestwindHelper.GetWordWithColon("appendix.appendix1", "Product");
            lblAppendix2.Text = WestwindHelper.GetWordWithColon("appendix.appendix2", "Product");
            lblAppendix3.Text = WestwindHelper.GetWordWithColon("appendix.appendix3", "Product");
            btnAdd.Text = WestwindHelper.GetWord("edit.new", "General");
            btnDelete.Text = WestwindHelper.GetWord("edit.delete", "General");
            lblRowNum.Text = WestwindHelper.GetWordWithColon("listview.line", "Tools");

            gbxCombination.Text = WestwindHelper.GetWord("combination", "Product");
            lblCombinNumber.Text = WestwindHelper.GetWordWithColon("combination.number", "Product");
            lblFileName.Text = WestwindHelper.GetWordWithColon("misc.pictureFile", "Product");
            btnExit.Text = WestwindHelper.GetWord("glossary.cancel", "General");
            btnCreate.Text = WestwindHelper.GetWord("glossary.process", "General");
            btnClearAll.Text = WestwindHelper.GetWord("glossary.clearAll", "General");

            gbxPrice.Text = WestwindHelper.GetWord("price", "Product");
            lblVendorPrice.Text = WestwindHelper.GetWordWithColon("price.vendor", "Product");
            lblWholeSalesPrice.Text = WestwindHelper.GetWordWithColon("price.wholesale", "Product");
            lblOriginalPrice.Text = WestwindHelper.GetWordWithColon("price.originalRetail", "Product");
            lblCurrentPrice.Text = WestwindHelper.GetWordWithColon("price.currentRetail", "Product");
            lblRetailDiscount.Text = WestwindHelper.GetWordWithColon("price.retailDiscount", "Product");
            lblUnit.Text = WestwindHelper.GetWordWithColon("price.unit", "Product");

            gbxBin.Text = WestwindHelper.GetWord("general.bin", "Product");

            gbxDiscount.Text = WestwindHelper.GetWord("discount.discounts", "Product");
            lblFixedPrice.Text = WestwindHelper.GetWordWithColon("discount.fixedPrice", "Product");
            lblFixPriceItem.Text = WestwindHelper.GetWordWithColon("discount.fixedPriceItem", "Product");
            lblDiscountItem.Text = WestwindHelper.GetWordWithColon("discount.discountItem", "Product");
            lblNoDiscountItem.Text = WestwindHelper.GetWordWithColon("discount.noDiscountItem", "Product");
            lblStaffDiscount.Text = WestwindHelper.GetWordWithColon("staff", "Model");

            lblStkCode.Text = WestwindHelper.GetWordWithColon("general.STKCODE", "Product");
            lblProductName.Text = WestwindHelper.GetWordWithColon("general.name", "Product");
            lblProductNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblProductNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblMemoProductName.Text = WestwindHelper.GetWordWithColon("general.memo", "Product");
            lblPole.Text = WestwindHelper.GetWordWithColon("general.pole", "Product");
            lblRemarks.Text = WestwindHelper.GetWordWithColon("general.remarks", "Product");

            toolTip1.SetToolTip(cmdMemo, WestwindHelper.GetWord("general.sameAsProductName", "Product"));
            toolTip1.SetToolTip(cmdPole, WestwindHelper.GetWord("general.sameAsProductName", "Product"));
            toolTip1.SetToolTip(cmdRemarks, WestwindHelper.GetWord("general.sameAsProductName", "Product"));

            lblClass1.Text = WestwindHelper.GetWordWithColon("class.class1", "Product");
            lblClass2.Text = WestwindHelper.GetWordWithColon("class.class2", "Product");
            lblClass3.Text = WestwindHelper.GetWordWithColon("class.class3", "Product");
            lblClass4.Text = WestwindHelper.GetWordWithColon("class.class4", "Product");
            lblClass5.Text = WestwindHelper.GetWordWithColon("class.class5", "Product");
            lblClass6.Text = WestwindHelper.GetWordWithColon("class.class6", "Product");

            lblRemarks1.Text = WestwindHelper.GetWordWithColon("remarks.remarks1", "Product");
            lblRemarks2.Text = WestwindHelper.GetWordWithColon("remarks.remarks2", "Product");
            lblRemarks3.Text = WestwindHelper.GetWordWithColon("remarks.remarks3", "Product");
            lblRemarks4.Text = WestwindHelper.GetWordWithColon("remarks.remarks4", "Product");
            lblRemarks5.Text = WestwindHelper.GetWordWithColon("remarks.remarks5", "Product");
            lblRemarks6.Text = WestwindHelper.GetWordWithColon("remarks.remarks6", "Product");

            chkOffDisplayItem.Text = WestwindHelper.GetWordWithColon("general.offDisplayItem", "Product");
            chkRetailItem.Text = WestwindHelper.GetWordWithColon("general.retailItem", "Product");
            chkCounterItem.Text = WestwindHelper.GetWordWithColon("general.counterItem", "Product");

            lblNature.Text = WestwindHelper.GetWordWithColon("nature", "Product");

        }

        private void SetAttributes()
        {
            this.KeyFilter = KeyFilter.Alt;
            this.KeyPress += new KeyPressEventHandler(Alt_KeyPress);

            this.txtStkCode.Focus();

            #region 2013.12.17 paulus: TabStop = false 有時唔 work，係 WebGUI 嘅問題，據說 v6.4 才 fixed，我哋用 6.3.17，唯有用手動，叫佢改 focus
            this.txtCurrentRetailCurrency.Enabled = false;
            this.txtOriginalRetailCurrency.Enabled = false;
            this.txtWholesalesCurrency.Enabled = false;

            this.cboVendorCurrency.LostFocus += new EventHandler(cboVendorCurrency_LostFocus);
            this.txtCurrentRetailPrice.LostFocus += new EventHandler(txtCurrentRetailPrice_LostFocus);
            this.txtRetailDiscount.LostFocus += new EventHandler(txtRetailDiscount_LostFocus);
            #endregion

            chkRetailItem.Checked = true;

            // dbo.ProductRemarks.REMARK1, 2, 3, 4, 5, 6 NVARCHAR(10)
            txtRemarks1.MaxLength = txtRemarks2.MaxLength = txtRemarks3.MaxLength = txtRemarks4.MaxLength = txtRemarks5.MaxLength = txtRemarks6.MaxLength = 10;
            txtPole.MaxLength = 20;     // dbo.ProductSupplement.ProductName_Pole   NVARCHAR(20)
            txtMemo.MaxLength = 30;     // dbo.ProductSupplement.ProductName_Memo   NVARCHAR(30)

            #region copy Product Name buttons
            cmdMemo.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("16.mdi-content-duplicate.png"));
            cmdMemo.FlatAppearance.BorderColor = Color.Red;
            cmdMemo.FlatStyle = FlatStyle.Flat;

            cmdPole.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("16.mdi-content-duplicate.png"));
            cmdPole.FlatAppearance.BorderColor = Color.Red;
            cmdPole.FlatStyle = FlatStyle.Flat;

            cmdRemarks.Image = new IconResourceHandle(ThemeHelper.GetIconThemed("16.mdi-content-duplicate.png"));
            cmdRemarks.FlatAppearance.BorderColor = Color.Red;
            cmdRemarks.FlatStyle = FlatStyle.Flat;
            #endregion

            #region listview columns
            colRow.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colRow.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendix1.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendix1.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendix2.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendix2.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            colAppendix3.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            colAppendix3.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Left;
            #endregion

            #region show/hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblProductNameAlt2.Visible = txtProductNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblProductNameAlt1.Visible = lblProductNameAlt2.Visible = txtProductNameAlt1.Visible = txtProductNameAlt2.Visible = false;
                    break;
            }
            #endregion

            #region 設定 clickable Nature label
            //lblNature.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblNature.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblNature.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductNatureWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillNatureList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Combination Number label
            lblCombinNumber.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblCombinNumber.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblCombinNumber.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new CombinationWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCombinList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Class 1 label
            //lblClass1.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblClass1.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblClass1.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductClassWizardAio();
                dialog.ProductClassType = ProductHelper.Classes.Class1;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillClass1();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Class 2 label
            //lblClass2.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblClass2.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblClass2.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductClassWizardAio();
                dialog.ProductClassType = ProductHelper.Classes.Class2;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillClass2();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Class 3 label
            //lblClass3.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblClass3.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblClass3.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductClassWizardAio();
                dialog.ProductClassType = ProductHelper.Classes.Class3;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillClass3();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Class 4 label
            //lblClass4.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblClass4.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblClass4.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductClassWizardAio();
                dialog.ProductClassType = ProductHelper.Classes.Class4;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillClass4();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Class 5 label
            //lblClass5.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblClass5.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblClass5.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductClassWizardAio();
                dialog.ProductClassType = ProductHelper.Classes.Class5;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillClass5();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Class 6 label
            //lblClass6.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblClass6.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblClass6.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new ProductClassWizardAio();
                dialog.ProductClassType = ProductHelper.Classes.Class6;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillClass6();
                };
                dialog.ShowDialog();
            };
            #endregion

        }

        #region 2013.07.05 paulus: Keyboard shortcuts
        #region 2013.12.17 paulus: TabStop = false 有時唔 work，係 WebGUI 嘅問題，唯有用手動，叫佢改 focus
        void txtRetailDiscount_LostFocus(object sender, EventArgs e)
        {
            this.txtUnit.Focus();
        }

        void txtCurrentRetailPrice_LostFocus(object sender, EventArgs e)
        {
            this.txtRetailDiscount.Focus();
        }

        void cboVendorCurrency_LostFocus(object sender, EventArgs e)
        {
            this.txtVendorPrice.Focus();
        }
        #endregion

        void Alt_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case 'C':
                    DoCreateProduct();
                    break;
                case 'E':
                    DoExitWizard();
                    break;
            }
        }
        #endregion

        private void SetLayout()
        {
            txtStkCode.BackColor = Color.LightSkyBlue;
        }
        #endregion

        #region Properties
        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillAppendixes();
            FillClasses();
            FillNatureList();
            FillCurrencyList();
            FillCombinList();
        }

        #region Appendix
        private void FillAppendixes()
        {
            FillAppendixe1();
            FillAppendixe2();
            FillAppendixe3();
        }

        private void FillAppendixe1()
        {
            cboAppendix1.BindData();
        }

        private void FillAppendixe2()
        {
            cboAppendix2.BindData();
        }

        private void FillAppendixe3()
        {
            cboAppendix3.BindData();
        }
        #endregion

        #region Class
        private void FillClasses()
        {
            FillClass1();
            FillClass2();
            FillClass3();
            FillClass4();
            FillClass5();
            FillClass6();
        }

        private void FillClass1()
        {
            ModelEx.ProductClass1Ex.LoadCombo(ref cboClass1, "Class1Code", false, true, "", "");
            /**
            cboClass1.Items.Clear();

            string[] orderBy = new string[] { "Class1Code" };
            ProductClass1Collection oC1List = ProductClass1.LoadCollection(orderBy, true);
            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Inset New EMPTY record to the top (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            oC1List.Insert (0, new ProductClass1());

            cboClass1.DataSource = oC1List;
            cboClass1.DisplayMember = "Class1Code";
            cboClass1.ValueMember = "Class1Id";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Locate to 1st record (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            cboClass1.SelectedIndex = 0;
            */
        }

        private void FillClass2()
        {
            ModelEx.ProductClass2Ex.LoadCombo(ref cboClass2, "Class2Code", false, true, "", "");
            /**
            cboClass2.Items.Clear();

            string[] orderBy = new string[] { "Class2Code" };
            ProductClass2Collection oC2List = ProductClass2.LoadCollection(orderBy, true);
            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Inset New EMPTY record to the top (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            oC2List.Insert (0, new ProductClass2());

            cboClass2.DataSource = oC2List;
            cboClass2.DisplayMember = "Class2Code";
            cboClass2.ValueMember = "Class2Id";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Locate to 1st record (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            cboClass2.SelectedIndex = 0;
            */
        }

        private void FillClass3()
        {
            ModelEx.ProductClass3Ex.LoadCombo(ref cboClass3, "Class3Code", false, true, "", "");
            /**
            cboClass3.Items.Clear();

            string[] orderBy = new string[] { "Class3Code" };
            ProductClass3Collection oC3List = ProductClass3.LoadCollection(orderBy, true);
            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Inset New EMPTY record to the top (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            oC3List.Insert (0, new ProductClass3());

            cboClass3.DataSource = oC3List;
            cboClass3.DisplayMember = "Class3Code";
            cboClass3.ValueMember = "Class3Id";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Locate to 1st record (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            cboClass3.SelectedIndex = 0;
            */
        }

        private void FillClass4()
        {
            ModelEx.ProductClass4Ex.LoadCombo(ref cboClass4, "Class4Code", false, true, "", "");
            /**
            cboClass4.Items.Clear();

            string[] orderBy = new string[] { "Class4Code" };
            ProductClass4Collection oC4List = ProductClass4.LoadCollection(orderBy, true);
            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Inset New EMPTY record to the top (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            oC4List.Insert (0, new ProductClass4());

            cboClass4.DataSource = oC4List;
            cboClass4.DisplayMember = "Class4Code";
            cboClass4.ValueMember = "Class4Id";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Locate to 1st record (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            cboClass4.SelectedIndex = 0;
            */
        }

        private void FillClass5()
        {
            ModelEx.ProductClass5Ex.LoadCombo(ref cboClass5, "Class5Code", false, true, "", "");
            /**
            cboClass5.Items.Clear();

            string[] orderBy = new string[] { "Class5Code" };
            ProductClass5Collection oC5List = ProductClass5.LoadCollection(orderBy, true);
            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Inset New EMPTY record to the top (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            oC5List.Insert (0, new ProductClass5());

            cboClass5.DataSource = oC5List;
            cboClass5.DisplayMember = "Class5Code";
            cboClass5.ValueMember = "Class5Id";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Locate to 1st record (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            cboClass5.SelectedIndex = 0;
            */
        }

        private void FillClass6()
        {
            ModelEx.ProductClass6Ex.LoadCombo(ref cboClass6, "Class6Code", false, true, "", "");
            /**
            cboClass6.Items.Clear();

            string[] orderBy = new string[] { "Class6Code" };
            var oC6List = ProductClass6.LoadCollection(orderBy, true);
            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Inset New EMPTY record to the top (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            oC6List.Insert (0, new ProductClass6());

            cboClass6.DataSource = oC6List;
            cboClass6.DisplayMember = "Class6Code";
            cboClass6.ValueMember = "Class6Id";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Locate to 1st record (Consisitent to Combin#)
            // ----------------------------------------------------------------------------------------------------
            cboClass6.SelectedIndex = 0;
            */
        }
        #endregion

        private void FillNatureList()
        {
            ModelEx.ProductNatureEx.LoadCombo(ref cboNature, "NatureCode", false);
        }

        #region ComboBox Binding Class
        public class ProductNatureRec
        {
            Guid prodNatureId = System.Guid.Empty;
            string natureCode = string.Empty;

            public ProductNatureRec(Guid pNId, string sCode)
            {
                prodNatureId = pNId;
                natureCode = sCode;
            }

            public Guid ProductNatureId
            {
                get { return prodNatureId; }
                set { prodNatureId = value; }
            }

            public string ProductNatureCode
            {
                get { return natureCode; }
                set { natureCode = value; }
            }
        }

        public class ProductNatureList : BindingList<ProductNatureRec>
        {
        }
        #endregion

        private void FillCurrencyList()
        {
            cboVendorCurrency.Items.Clear();

            //2013.07.05 paulus: ID# 566.1，有機會咩都唔選，所以改為 list 內有 String.Empty 
            //string[] orderBy = new string[] { "CurrencyCode" };
            //CurrencyCollection oCnyList = Currency.LoadCollection(orderBy, true);
            //cboVendorCurrency.DataSource = oCnyList;
            //cboVendorCurrency.DisplayMember = "CurrencyCode";
            //cboVendorCurrency.ValueMember = "CurrencyId";

            ModelEx.CurrencyEx.LoadCombo(ref cboVendorCurrency, "CurrencyCode", false, true, String.Empty, String.Empty);
        }

        private void FillCombinList()
        {
            ModelEx.ProductDimEx.LoadCombo(ref cboCombinationNum, "DimCode", false, true, "", "");
            /**
            cboCombinationNum.Items.Clear();

            string[] orderBy = new string[] { "DimCode" };
            ProductDimCollection oDimList = ProductDim.LoadCollection(orderBy, true);

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : Bug #337
            // Avoid loading incorrect Combination List for EMPTY Combin#, it changes to insert EMPTY record at the top of list.
            // ----------------------------------------------------------------------------------------------------
            // Inset New EMPTY record 
            oDimList.Insert(0, new ProductDim());

            cboCombinationNum.DataSource = oDimList;
            cboCombinationNum.DisplayMember = "DimCode";
            cboCombinationNum.ValueMember = "DimensionId";

            // ----------------------------------------------------------------------------------------------------
            // 2008-05-29 Carrie : EMPTY record has been inserted into the top so that the default "SelectedIndex" set to be 0.
            // ----------------------------------------------------------------------------------------------------
            cboCombinationNum.SelectedIndex = 0;            
            */
        }

        #endregion

        #region Combine Appendix List
        private bool VerifyAppendixList()
        {
            bool beVerified = false;
            foreach (ListViewItem objItem in lvAppendixList.Items)
            {
                bool verifyA1 = (objItem.SubItems[1].Text == cboAppendix1.Text);
                bool verifyA2 = (objItem.SubItems[2].Text == cboAppendix2.Text);
                bool verifyA3 = (objItem.SubItems[3].Text == cboAppendix3.Text);

                beVerified = verifyA1 && verifyA2 && verifyA3;
                if (beVerified) break;
            }
            return beVerified;
        }

        private void UpdateAppendixList(Gizmox.WebGUI.Forms.ListView.ListViewItemCollection itemList)
        {
            for (int i = 0; i < itemList.Count; i++)
            {
                itemList[i].SubItems[0].Text = (i + 1).ToString();
            }
        }
        #endregion

        #region Create Products
        private bool Verify()
        {
            bool isVerified = false;

            if (lvAppendixList.Items.Count == 0)
            {
                MessageBox.Show("You should add one appendix at least or select one combination number!");
            }
            else if (txtStkCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStkCode, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(txtStkCode, string.Empty);
                isVerified = true;
            }

            return isVerified;
        }

        private int CreateProducts()
        {
            int iCount = 0;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        foreach (ListViewItem oItem in lvAppendixList.Items)
                        {
                            #region CreateProducts(oItem);

                            #region prepare local variables
                            string a1 = oItem.SubItems[1].Text;
                            string a2 = oItem.SubItems[2].Text;
                            string a3 = oItem.SubItems[3].Text;

                            Guid a1Id = Guid.Empty, a2Id = Guid.Empty, a3Id = Guid.Empty;
                            a1Id = (Guid.TryParse(oItem.SubItems[4].Text, out a1Id)) ? a1Id : Guid.Empty;
                            a2Id = (Guid.TryParse(oItem.SubItems[5].Text, out a2Id)) ? a2Id : Guid.Empty;
                            a3Id = (Guid.TryParse(oItem.SubItems[6].Text, out a3Id)) ? a3Id : Guid.Empty;
                            string stkcode = txtStkCode.Text.Trim();
                            string prodCode = stkcode + a1 + a2 + a3;
                            #endregion

                            var oProduct = ctx.Product.Where(x => x.STKCODE == stkcode && x.APPENDIX1 == a1 && x.APPENDIX2 == a2 && x.APPENDIX3 == a3).FirstOrDefault();
                            if (oProduct == null)
                            {
                                #region product core data
                                oProduct = new EF6.Product();
                                oProduct.ProductId = Guid.NewGuid();
                                oProduct.STKCODE = txtStkCode.Text;
                                oProduct.APPENDIX1 = a1;
                                oProduct.APPENDIX2 = a2;
                                oProduct.APPENDIX3 = a3;

                                oProduct.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                                oProduct.CLASS1 = cboClass1.Text;
                                oProduct.CLASS2 = cboClass2.Text;
                                oProduct.CLASS3 = cboClass3.Text;
                                oProduct.CLASS4 = cboClass4.Text;
                                oProduct.CLASS5 = cboClass5.Text;
                                oProduct.CLASS6 = cboClass6.Text;

                                oProduct.ProductName = txtProductName.Text;
                                oProduct.ProductName_Chs = txtProductNameAlt1.Text;
                                oProduct.ProductName_Cht = txtProductNameAlt2.Text;
                                oProduct.Remarks = txtRemarks.Text;

                                oProduct.NormalDiscount = Convert.ToDecimal((txtRetailDiscount.Text == string.Empty) ? "0" : txtRetailDiscount.Text);
                                oProduct.UOM = txtUnit.Text;
                                oProduct.NatureId = new Guid(cboNature.SelectedValue.ToString());

                                oProduct.FixedPriceItem = chkFixedPrice.Checked;
                                #endregion

                                #region Price
                                oProduct.RetailPrice = Convert.ToDecimal((txtCurrentRetailPrice.Text == string.Empty) ? "0" : txtCurrentRetailPrice.Text);
                                oProduct.WholesalePrice = Convert.ToDecimal((txtWholesalesPrice.Text == string.Empty) ? "0" : txtWholesalesPrice.Text);
                                oProduct.OriginalRetailPrice = Convert.ToDecimal((txtOriginalRetailPrice.Text == string.Empty) ? "0" : txtOriginalRetailPrice.Text);
                                //oItem.Markup = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                                #endregion

                                #region Download Packets
                                oProduct.DownloadToPOS = chkRetailItem.Checked;
                                oProduct.DownloadToCounter = chkCounterItem.Checked;
                                #endregion

                                oProduct.CreatedBy = ConfigHelper.CurrentUserId;
                                oProduct.CreatedOn = DateTime.Now;
                                oProduct.ModifiedBy = ConfigHelper.CurrentUserId;
                                oProduct.ModifiedOn = DateTime.Now;

                                ctx.Product.Add(oProduct);

                                var productId = oProduct.ProductId;
                                this.ProductId = oProduct.ProductId;

                                #region SaveProductBarcode(oProduct.ProductId, prodCode);
                                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == productId && x.Barcode == prodCode).FirstOrDefault();
                                if (oBarcode == null)
                                {
                                    oBarcode = new EF6.ProductBarcode();
                                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                                    oBarcode.ProductId = productId;
                                    oBarcode.Barcode = prodCode;
                                    oBarcode.BarcodeType = "INTER";
                                    oBarcode.PrimaryBarcode = true;
                                    oBarcode.DownloadToPOS = chkRetailItem.Checked;
                                    oBarcode.DownloadToCounter = chkCounterItem.Checked;

                                    ctx.ProductBarcode.Add(oBarcode);
                                    ctx.SaveChanges();
                                }
                                #endregion

                                #region Appendix / Class
                                System.Guid c1Id = (cboClass1.SelectedValue != null) ? new Guid(cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
                                System.Guid c2Id = (cboClass2.SelectedValue != null) ? new Guid(cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
                                System.Guid c3Id = (cboClass3.SelectedValue != null) ? new Guid(cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
                                System.Guid c4Id = (cboClass4.SelectedValue != null) ? new Guid(cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
                                System.Guid c5Id = (cboClass5.SelectedValue != null) ? new Guid(cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
                                System.Guid c6Id = (cboClass6.SelectedValue != null) ? new Guid(cboClass6.SelectedValue.ToString()) : System.Guid.Empty;
                                //SaveProductCode(oProduct.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);
                                var oCode = ctx.ProductCode.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oCode == null)
                                {
                                    oCode = new EF6.ProductCode();
                                    oCode.CodeId = Guid.NewGuid();
                                    oCode.ProductId = productId;

                                    //2013.07.05 paulus: 有可能是吉的（冇選 Appendix）
                                    if (a1Id != Guid.Empty) oCode.Appendix1Id = a1Id;
                                    if (a2Id != Guid.Empty) oCode.Appendix2Id = a2Id;
                                    if (a3Id != Guid.Empty) oCode.Appendix3Id = a3Id;

                                    ctx.ProductCode.Add(oCode);
                                }
                                oCode.Class1Id = c1Id;
                                oCode.Class2Id = c2Id;
                                oCode.Class3Id = c3Id;
                                oCode.Class4Id = c4Id;
                                oCode.Class5Id = c5Id;
                                oCode.Class6Id = c6Id;

                                ctx.SaveChanges();
                                #endregion

                                // Product Price
                                #region SaveProductSupplement(oProduct.ProductId);
                                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oProdSupp == null)
                                {
                                    oProdSupp = new EF6.ProductSupplement();
                                    oProdSupp.SupplementId = Guid.NewGuid();
                                    oProdSupp.ProductId = productId;

                                    ctx.ProductSupplement.Add(oProdSupp);
                                }
                                oProdSupp.VendorCurrencyCode = cboVendorCurrency.Text;
                                oProdSupp.VendorPrice = Convert.ToDecimal((txtVendorPrice.Text == string.Empty) ? "0" : txtVendorPrice.Text);
                                oProdSupp.ProductName_Memo = txtMemo.Text;
                                oProdSupp.ProductName_Pole = txtPole.Text;

                                oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : txtDiscount1_FixPriceItem.Text);
                                oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : txtDiscount2_DiscountItem.Text);
                                oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : txtDiscount3_NoDiscountItem.Text);
                                oProdSupp.StaffDiscount = Convert.ToDecimal((txtStaffDiscount.Text == string.Empty) ? "0" : txtStaffDiscount.Text);

                                ctx.SaveChanges();
                                #endregion

                                //SaveProductPrice(oProduct.ProductId);
                                var currencyCode = txtCurrentRetailCurrency.Text;
                                var price = txtCurrentRetailPrice.Text;
                                #region SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), txtCurrentRetailCurrency.Text, txtCurrentRetailPrice.Text);
                                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.BASPRC.ToString());
                                var oBPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oBPrice == null)
                                {
                                    oBPrice = new EF6.ProductPrice();
                                    oBPrice.ProductPriceId = Guid.NewGuid();
                                    oBPrice.ProductId = productId;
                                    ctx.ProductPrice.Add(oBPrice);
                                }
                                oBPrice.PriceTypeId = priceTypeId;
                                oBPrice.CurrencyCode = currencyCode;
                                oBPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);

                                ctx.SaveChanges();
                                #endregion
                                //
                                #region SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), txtOriginalRetailCurrency.Text, txtOriginalRetailPrice.Text);
                                priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.ORIPRC.ToString());
                                var oOPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oOPrice == null)
                                {
                                    oOPrice = new EF6.ProductPrice();
                                    oOPrice.ProductPriceId = Guid.NewGuid();
                                    oOPrice.ProductId = productId;
                                    ctx.ProductPrice.Add(oOPrice);
                                }
                                oOPrice.PriceTypeId = priceTypeId;
                                oOPrice.CurrencyCode = currencyCode;
                                oOPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);

                                ctx.SaveChanges();
                                #endregion
                                //
                                #region SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), cboVendorCurrency.Text, txtVendorPrice.Text);
                                priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.VPRC.ToString());
                                var oVPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oVPrice == null)
                                {
                                    oVPrice = new EF6.ProductPrice();
                                    oVPrice.ProductPriceId = Guid.NewGuid();
                                    oVPrice.ProductId = productId;
                                    ctx.ProductPrice.Add(oVPrice);
                                }
                                oVPrice.PriceTypeId = priceTypeId;
                                oVPrice.CurrencyCode = currencyCode;
                                oVPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);

                                ctx.SaveChanges();
                                #endregion
                                //
                                #region SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), txtWholesalesCurrency.Text, txtWholesalesPrice.Text);
                                priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.WHLPRC.ToString());
                                var oWPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                                if (oWPrice == null)
                                {
                                    oWPrice = new EF6.ProductPrice();
                                    oWPrice.ProductPriceId = Guid.NewGuid();
                                    oWPrice.ProductId = productId;
                                    ctx.ProductPrice.Add(oWPrice);
                                }
                                oWPrice.PriceTypeId = priceTypeId;
                                oWPrice.CurrencyCode = currencyCode;
                                oWPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);

                                ctx.SaveChanges();
                                #endregion

                                // Remarks
                                #region SaveProductRemarks(oProduct.ProductId);
                                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oRemarks == null)
                                {
                                    oRemarks = new EF6.ProductRemarks();
                                    oRemarks.ProductRemarksId = Guid.NewGuid();
                                    oRemarks.ProductId = productId;

                                    ctx.ProductRemarks.Add(oRemarks);
                                }
                                oRemarks.BinX = txtBin_X.Text;
                                oRemarks.BinY = txtBin_Y.Text;
                                oRemarks.BinZ = txtBin_Z.Text;

                                oRemarks.DownloadToShop = chkRetailItem.Checked;
                                oRemarks.OffDisplayItem = chkOffDisplayItem.Checked;
                                oRemarks.DownloadToCounter = chkCounterItem.Checked;

                                oRemarks.REMARK1 = txtRemarks1.Text;
                                oRemarks.REMARK2 = txtRemarks2.Text;
                                oRemarks.REMARK3 = txtRemarks3.Text;
                                oRemarks.REMARK4 = txtRemarks4.Text;
                                oRemarks.REMARK5 = txtRemarks5.Text;
                                oRemarks.REMARK6 = txtRemarks6.Text;

                                //oRemarks.Notes = txtNotes.Text;

                                oRemarks.Photo = txtPicFileName.Text;

                                ctx.SaveChanges();
                                #endregion

                                #region SaveCurrentSummary(oProduct.ProductId);
                                var oCurrSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                                if (oCurrSummary == null)
                                {
                                    oCurrSummary = new EF6.ProductCurrentSummary();
                                    oCurrSummary.CurrentSummaryId = Guid.NewGuid();
                                    oCurrSummary.ProductId = productId;
                                    oCurrSummary.CDQTY = 0;
                                    oCurrSummary.LastPurchasedOn = new DateTime(1900, 1, 1);
                                    oCurrSummary.LastSoldOn = new DateTime(1900, 1, 1);

                                    ctx.ProductCurrentSummary.Add(oCurrSummary);
                                    ctx.SaveChanges();
                                }
                                #endregion
                            }

                            #endregion

                            ctx.SaveChanges();
                            iCount++;
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            return iCount;
        }

        /** 改咗，依家冇用
        private void CreateProducts(ListViewItem listItem)
        {
            string a1 = listItem.SubItems[1].Text;
            string a2 = listItem.SubItems[2].Text;
            string a3 = listItem.SubItems[3].Text;

            Guid a1Id = Guid.Empty, a2Id = Guid.Empty, a3Id = Guid.Empty;
            a1Id = (Guid.TryParse(listItem.SubItems[4].Text, out a1Id)) ? a1Id : Guid.Empty;
            a2Id = (Guid.TryParse(listItem.SubItems[5].Text, out a2Id)) ? a2Id : Guid.Empty;
            a3Id = (Guid.TryParse(listItem.SubItems[6].Text, out a3Id)) ? a3Id : Guid.Empty;

            string prodCode = txtStkCode.Text.Trim() + a1 + a2 + a3;
            if (prodCode.Length <= 22)
            {
                StringBuilder sql = new StringBuilder();
                sql.Append(" STKCODE = '").Append(txtStkCode.Text.Trim()).Append("' ");
                sql.Append(" AND APPENDIX1 = '").Append(a1.Trim()).Append("' ");
                sql.Append(" AND APPENDIX2 = '").Append(a2.Trim()).Append("' ");
                sql.Append(" AND APPENDIX3 = '").Append(a3.Trim()).Append("' ");

                RT2020.DAL.Product oItem = RT2020.DAL.Product.LoadWhere(sql.ToString());
                if (oItem == null)
                {
                    #region product core data
                    oItem = new RT2020.DAL.Product();

                    oItem.STKCODE = txtStkCode.Text;
                    oItem.APPENDIX1 = a1;
                    oItem.APPENDIX2 = a2;
                    oItem.APPENDIX3 = a3;

                    oItem.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                    oItem.CLASS1 = cboClass1.Text;
                    oItem.CLASS2 = cboClass2.Text;
                    oItem.CLASS3 = cboClass3.Text;
                    oItem.CLASS4 = cboClass4.Text;
                    oItem.CLASS5 = cboClass5.Text;
                    oItem.CLASS6 = cboClass6.Text;

                    oItem.ProductName = txtProductName.Text;
                    oItem.ProductName_Chs = txtProductNameChs.Text;
                    oItem.ProductName_Cht = txtProductNameCht.Text;
                    oItem.Remarks = txtRemarks.Text;

                    oItem.NormalDiscount = Convert.ToDecimal((txtRetailDiscount.Text == string.Empty) ? "0" : txtRetailDiscount.Text);
                    oItem.UOM = txtUnit.Text;
                    oItem.NatureId = new Guid(cboNature.SelectedValue.ToString());

                    oItem.FixedPriceItem = chkFixedPrice.Checked;
                    #endregion

                    #region Price
                    oItem.RetailPrice = Convert.ToDecimal((txtCurrentRetailPrice.Text == string.Empty) ? "0" : txtCurrentRetailPrice.Text);
                    oItem.WholesalePrice = Convert.ToDecimal((txtWholesalesPrice.Text == string.Empty) ? "0" : txtWholesalesPrice.Text);
                    oItem.OriginalRetailPrice = Convert.ToDecimal((txtOriginalRetailPrice.Text == string.Empty) ? "0" : txtOriginalRetailPrice.Text);
                    //oItem.Markup = Convert.ToDecimal((general.txtVendorPrice.Text == string.Empty) ? "0" : general.txtVendorPrice.Text);
                    #endregion

                    #region Download Packets
                    oItem.DownloadToPOS = chkRetailItem.Checked;
                    oItem.DownloadToCounter = chkCounterItem.Checked;
                    #endregion

                    oItem.CreatedBy = ConfigHelper.CurrentUserId;
                    oItem.CreatedOn = DateTime.Now;
                    oItem.ModifiedBy = ConfigHelper.CurrentUserId;
                    oItem.ModifiedOn = DateTime.Now;

                    oItem.Save();

                    this.ProductId = oItem.ProductId;

                    SaveProductBarcode(oItem.ProductId, prodCode);

                    #region Appendix / Class
                    System.Guid c1Id = (cboClass1.SelectedValue != null) ? new Guid(cboClass1.SelectedValue.ToString()) : System.Guid.Empty;
                    System.Guid c2Id = (cboClass2.SelectedValue != null) ? new Guid(cboClass2.SelectedValue.ToString()) : System.Guid.Empty;
                    System.Guid c3Id = (cboClass3.SelectedValue != null) ? new Guid(cboClass3.SelectedValue.ToString()) : System.Guid.Empty;
                    System.Guid c4Id = (cboClass4.SelectedValue != null) ? new Guid(cboClass4.SelectedValue.ToString()) : System.Guid.Empty;
                    System.Guid c5Id = (cboClass5.SelectedValue != null) ? new Guid(cboClass5.SelectedValue.ToString()) : System.Guid.Empty;
                    System.Guid c6Id = (cboClass6.SelectedValue != null) ? new Guid(cboClass6.SelectedValue.ToString()) : System.Guid.Empty;
                    SaveProductCode(oItem.ProductId, a1Id, a2Id, a3Id, c1Id, c2Id, c3Id, c4Id, c5Id, c6Id);
                    #endregion

                    // Product Price
                    SaveProductSupplement(oItem.ProductId);
                    SaveProductPrice(oItem.ProductId);

                    // Remarks
                    SaveProductRemarks(oItem.ProductId);

                    SaveCurrentSummary(oItem.ProductId);
                }
            }
        }
        
        private void SaveCurrentSummary(Guid productId)
        {
            string where = "ProductId = '" + productId.ToString() + "'";

            using (var ctx = new EF6.RT2020Entities())
            {
                var oCurrSummary = ctx.ProductCurrentSummary.Where(x => x.ProductId == productId).FirstOrDefault();
                //DAL.ProductCurrentSummary oCurrSummary = DAL.ProductCurrentSummary.LoadWhere(where);
                if (oCurrSummary == null)
                {
                    oCurrSummary = new EF6.ProductCurrentSummary();
                    oCurrSummary.CurrentSummaryId = Guid.NewGuid();
                    oCurrSummary.ProductId = productId;
                    oCurrSummary.CDQTY = 0;
                    oCurrSummary.LastPurchasedOn = new DateTime(1900, 1, 1);
                    oCurrSummary.LastSoldOn = new DateTime(1900, 1, 1);

                    ctx.ProductCurrentSummary.Add(oCurrSummary);
                    ctx.SaveChanges();
                }
            }
        }
        
        private void SaveProductBarcode(Guid productid, string barcode)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productid.ToString() + "' AND Barcode = '" + barcode + "'";
                var oBarcode = ctx.ProductBarcode.Where(x => x.ProductId == productid && x.Barcode == barcode).FirstOrDefault();
                if (oBarcode == null)
                {
                    oBarcode = new EF6.ProductBarcode();
                    oBarcode.ProductBarcodeId = Guid.NewGuid();
                    oBarcode.ProductId = productid;
                    oBarcode.Barcode = barcode;
                    oBarcode.BarcodeType = "INTER";
                    oBarcode.PrimaryBarcode = true;
                    oBarcode.DownloadToPOS = chkRetailItem.Checked;
                    oBarcode.DownloadToCounter = chkCounterItem.Checked;

                    ctx.ProductBarcode.Add(oBarcode);
                    ctx.SaveChanges();
                }
            }
        }
        
        private void SaveProductCode(Guid productId, Guid a1Id, Guid a2Id, Guid a3Id, Guid c1Id, Guid c2Id, Guid c3Id, Guid c4Id, Guid c5Id, Guid c6Id)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productId.ToString() + "'";
                var oCode = ctx.ProductCode.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oCode == null)
                {
                    oCode = new EF6.ProductCode();
                    oCode.CodeId = Guid.NewGuid();
                    oCode.ProductId = productId;

                    //2013.07.05 paulus: 有可能是吉的（冇選 Appendix）
                    if (a1Id != System.Guid.Empty) oCode.Appendix1Id = a1Id;
                    if (a2Id != System.Guid.Empty) oCode.Appendix2Id = a2Id;
                    if (a3Id != System.Guid.Empty) oCode.Appendix3Id = a3Id;

                    ctx.ProductCode.Add(oCode);
                }
                oCode.Class1Id = c1Id;
                oCode.Class2Id = c2Id;
                oCode.Class3Id = c3Id;
                oCode.Class4Id = c4Id;
                oCode.Class5Id = c5Id;
                oCode.Class6Id = c6Id;

                ctx.SaveChanges();
            }
        }
        
        private void SaveProductSupplement(Guid productId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "ProductId = '" + productId.ToString() + "'";
                var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oProdSupp == null)
                {
                    oProdSupp = new EF6.ProductSupplement();
                    oProdSupp.SupplementId = Guid.NewGuid();
                    oProdSupp.ProductId = productId;

                    ctx.ProductSupplement.Add(oProdSupp);
                }
                oProdSupp.VendorCurrencyCode = cboVendorCurrency.Text;
                oProdSupp.VendorPrice = Convert.ToDecimal((txtVendorPrice.Text == string.Empty) ? "0" : txtVendorPrice.Text);
                oProdSupp.ProductName_Memo = txtMemo.Text;
                oProdSupp.ProductName_Pole = txtPole.Text;

                oProdSupp.VipDiscount_FixedItem = Convert.ToDecimal((txtDiscount1_FixPriceItem.Text == string.Empty) ? "0" : txtDiscount1_FixPriceItem.Text);
                oProdSupp.VipDiscount_DiscountItem = Convert.ToDecimal((txtDiscount2_DiscountItem.Text == string.Empty) ? "0" : txtDiscount2_DiscountItem.Text);
                oProdSupp.VipDiscount_NoDiscountItem = Convert.ToDecimal((txtDiscount3_NoDiscountItem.Text == string.Empty) ? "0" : txtDiscount3_NoDiscountItem.Text);
                oProdSupp.StaffDiscount = Convert.ToDecimal((txtStaffDiscount.Text == string.Empty) ? "0" : txtStaffDiscount.Text);

                ctx.SaveChanges();
            }
        }
        
        private void SaveProductPrice(Guid productId)
        {
            SaveProductPrice(productId, ProductHelper.Prices.BASPRC.ToString(), txtCurrentRetailCurrency.Text, txtCurrentRetailPrice.Text);
            SaveProductPrice(productId, ProductHelper.Prices.ORIPRC.ToString(), txtOriginalRetailCurrency.Text, txtOriginalRetailPrice.Text);
            SaveProductPrice(productId, ProductHelper.Prices.VPRC.ToString(), cboVendorCurrency.Text, txtVendorPrice.Text);
            SaveProductPrice(productId, ProductHelper.Prices.WHLPRC.ToString(), txtWholesalesCurrency.Text, txtWholesalesPrice.Text);
        }

        private void SaveProductPrice(Guid productId, string priceType, string currencyCode, string price)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var priceTypeId = ModelEx.ProductPriceTypeEx.GetIdByPriceType(priceType);
                //string sql = "ProductId = '" + productId.ToString() + "' AND PriceTypeId = '" + GetPriceType(priceType).ToString() + "'";
                var oPrice = ctx.ProductPrice.Where(x => x.ProductId == productId && x.PriceTypeId == priceTypeId).FirstOrDefault();
                if (oPrice == null)
                {
                    oPrice = new EF6.ProductPrice();
                    oPrice.ProductPriceId = Guid.NewGuid();
                    oPrice.ProductId = productId;
                    ctx.ProductPrice.Add(oPrice);
                }
                oPrice.PriceTypeId = priceTypeId;
                oPrice.CurrencyCode = currencyCode;
                oPrice.Price = Convert.ToDecimal((price == string.Empty) ? "0" : price);

                ctx.SaveChanges();
            }
        }
        
        private void SaveProductRemarks(Guid productId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string sql = "ProductId = '" + productId.ToString() + "'";
                var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == productId).FirstOrDefault();
                if (oRemarks == null)
                {
                    oRemarks = new EF6.ProductRemarks();
                    oRemarks.ProductRemarksId = Guid.NewGuid();
                    oRemarks.ProductId = productId;

                    ctx.ProductRemarks.Add(oRemarks);
                }
                oRemarks.BinX = txtBin_X.Text;
                oRemarks.BinY = txtBin_Y.Text;
                oRemarks.BinZ = txtBin_Z.Text;

                oRemarks.DownloadToShop = chkRetailItem.Checked;
                oRemarks.OffDisplayItem = chkOffDisplayItem.Checked;
                oRemarks.DownloadToCounter = chkCounterItem.Checked;

                oRemarks.REMARK1 = txtRemarks1.Text;
                oRemarks.REMARK2 = txtRemarks2.Text;
                oRemarks.REMARK3 = txtRemarks3.Text;
                oRemarks.REMARK4 = txtRemarks4.Text;
                oRemarks.REMARK5 = txtRemarks5.Text;
                oRemarks.REMARK6 = txtRemarks6.Text;

                oRemarks.Notes = txtNotes.Text;

                oRemarks.Photo = txtPicFileName.Text;

                ctx.SaveChanges();
            }
        } 
        */
        #endregion

        private void DoCreateProduct()
        {
            if (Verify())
            {
                int result = CreateProducts();

                if (this.ProductId != System.Guid.Empty)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<ProductList>();
                    MessageBox.Show(result.ToString() + " Succeed!", "Create Result", MessageBoxButtons.OK, new EventHandler(SaveMessageHandler));
                }
            }
        }

        private void DoExitWizard()
        {
            this.Close();
        }

        #region Events

        #region Main Button Events
        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.Close();
            QuickWizard wizFast = new QuickWizard();
            wizFast.ShowDialog();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DoCreateProduct();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DoExitWizard();
        }

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        #endregion

        #region Picture / Combination Events
        private void btnFindPic_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Product Picture Upload Wizard";
            openFileDialog.MaxFileSize = 10240;
            openFileDialog.ShowDialog();
        }

        private void openFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            OpenFileDialog objFileDialog = sender as OpenFileDialog;
            txtPicFileName.Text = Utility.UploadFile(openFileDialog, mstrDirectory);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        { 
            //2013.07.05 paulus: 有機會咩 Appendix 都唔選
            //if (cboAppendix1.SelectedValue.ToString() != System.Guid.Empty.ToString() || cboAppendix2.SelectedValue.ToString() != System.Guid.Empty.ToString() || cboAppendix3.SelectedValue.ToString() != System.Guid.Empty.ToString())
            //{
                // 2008-05-29 Carrie : Check whether the CODE of A1-3 is in the list (Except EMPTY record) 
                bool bPASS = true;
                string sMSG = string.Empty;                
                if (cboAppendix1.Text.Length != 0 && 
                    (cboAppendix1.SelectedValue.ToString() == System.Guid.Empty.ToString() ||
                     ModelEx.ProductAppendix1Ex.GetIdByCode(cboAppendix1.Text).ToString() != cboAppendix1.SelectedValue.ToString()))
                {
                    sMSG = sMSG + ((sMSG.Length != 0)? ", ": string.Empty) + lblAppendix1.Text;
                    bPASS = false;
                }
                if (cboAppendix2.Text.Length != 0 &&
                    (cboAppendix2.SelectedValue.ToString() == System.Guid.Empty.ToString() ||
                     ModelEx.ProductAppendix2Ex.GetIdByCode(cboAppendix2.Text).ToString() != cboAppendix2.SelectedValue.ToString()))
                {
                    sMSG = sMSG + ((sMSG.Length != 0) ? ", " : string.Empty) + lblAppendix2.Text;
                    bPASS = false;
                }
                if (cboAppendix3.Text.Length != 0 &&
                    (cboAppendix3.SelectedValue.ToString() == System.Guid.Empty.ToString() ||
                     ModelEx.ProductAppendix3Ex.GetIdByCode(cboAppendix3.Text).ToString() != cboAppendix3.SelectedValue.ToString()))
                    {
                    sMSG = sMSG + ((sMSG.Length != 0) ? ", " : string.Empty) + lblAppendix3.Text;
                    bPASS = false;
                }
                if (!bPASS)
                {
                    MessageBox.Show("Invalid Appendix Code (" + sMSG + ")", this.Text);
                }                
                else 
                {
                    if (!VerifyAppendixList())
                    {
                        ListViewItem objItem = lvAppendixList.Items.Add((lvAppendixList.Items.Count + 1).ToString());
                        objItem.SubItems.Add(cboAppendix1.Text);
                        objItem.SubItems.Add(cboAppendix2.Text);
                        objItem.SubItems.Add(cboAppendix3.Text);
                        objItem.SubItems.Add((cboAppendix1.Text == String.Empty)? System.Guid.Empty.ToString() : cboAppendix1.SelectedValue.ToString());
                        objItem.SubItems.Add((cboAppendix2.Text == String.Empty)? System.Guid.Empty.ToString() : cboAppendix2.SelectedValue.ToString());
                        objItem.SubItems.Add((cboAppendix3.Text == String.Empty)? System.Guid.Empty.ToString() : cboAppendix3.SelectedValue.ToString());
                    }
                    else
                    {
                        MessageBox.Show("The combination exists", this.Text);                    
                    }
                }
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtRowNum.Text.Length == 0)
            {
                errorProvider.SetError(txtRowNum, "Please select a row to delete or try to input a valid row number.");
            }
            else
            {
                errorProvider.SetError(txtRowNum, "");

                int rowNumber = 0;
                if (int.TryParse(txtRowNum.Text, out rowNumber))
                {
                    if (rowNumber <= lvAppendixList.Items.Count)
                    {
                        lvAppendixList.Items.RemoveAt(rowNumber - 1);

                        UpdateAppendixList(lvAppendixList.Items);

                        this.Update();
                    }
                }
            }
        }
        #endregion

        private void lvAppendixList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAppendixList.SelectedItem != null)
            {
                txtRowNum.Text = lvAppendixList.SelectedItem.Text;
            }
        }

        private void cboCombinationNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvAppendixList.Items.Clear();

            Guid id = Guid.Empty;
            if (Guid.TryParse(cboCombinationNum.SelectedValue.ToString(), out id))
            {
                var detailList = ModelEx.ProductDim_DetailsEx.GetListByDimensionId(id);
                foreach (var detail in detailList)
                {
                    ListViewItem objItem = lvAppendixList.Items.Add((lvAppendixList.Items.Count + 1).ToString());
                    objItem.SubItems.Add(detail.APPENDIX1);
                    objItem.SubItems.Add(detail.APPENDIX2);
                    objItem.SubItems.Add(detail.APPENDIX3);
                    objItem.SubItems.Add(ModelEx.ProductAppendix1Ex.GetIdByCode(detail.APPENDIX1).ToString());
                    objItem.SubItems.Add(ModelEx.ProductAppendix2Ex.GetIdByCode(detail.APPENDIX2).ToString());
                    objItem.SubItems.Add(ModelEx.ProductAppendix3Ex.GetIdByCode(detail.APPENDIX3).ToString());
                }
            }
        }

        #endregion

        private void cmdMemo_Click(object sender, EventArgs e)
        {
            txtMemo.Text = txtProductName.Text;
        }

        private void cmdPole_Click(object sender, EventArgs e)
        {
            txtPole.Text = txtProductName.Text;
        }

        private void cmdRemarks_Click(object sender, EventArgs e)
        {
            txtRemarks.Text = txtProductName.Text;
        }
    }
}