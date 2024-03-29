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
using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_General : UserControl
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
        #endregion

        public ProductWizard_General()
        {
            InitializeComponent();
        }

        private void ProductWizard_General_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetSystemLabels();
            FillList();
            SetEditable();

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

        #region SetCaptions, SetAttributes & SetPhoneTag
        private void SetCaptions()
        {
            lblProductName.Text = WestwindHelper.GetWordWithColon("general.name", "Product");
            lblProductNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblProductNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblMemo.Text = WestwindHelper.GetWordWithColon("general.memo", "Product");
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

            gbxPrice.Text = WestwindHelper.GetWordWithColon("price", "Product");
            lblVendorPrice.Text = WestwindHelper.GetWordWithColon("price.vendor", "Product");
            lblWholeSalesPrice.Text = WestwindHelper.GetWordWithColon("price.wholesale", "Product");
            lblOriginalPrice.Text = WestwindHelper.GetWordWithColon("price.originalRetail", "Product");
            lblCurrentPrice.Text = WestwindHelper.GetWordWithColon("price.currentRetail", "Product");
            lblRetailDiscount.Text = WestwindHelper.GetWordWithColon("price.retailDiscount", "Product");
            lblUnit.Text = WestwindHelper.GetWordWithColon("price.unit", "Product");

            gbxBin.Text = WestwindHelper.GetWord("general.bin", "Product");

            gbxStatus.Text = WestwindHelper.GetWord("glossary.status", "General");
            lblCreatedOn.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblModifiedBy.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblStatus.Text = WestwindHelper.GetWordWithColon("glossary.sync", "General");
        }

        private void SetAttributes()
        {
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

            /**
            #region 設定 clickable Smart Tag 2 label
            //lblSmartTag2.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag2.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag2.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Smart Tag 3 label
            lblSmartTag3.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag3.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag3.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Smart Tag 4 label
            lblSmartTag4.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag4.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag4.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 1 label
            lblPhoneTag1.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag1.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag1.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 2 label
            //lblPhoneTag2.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag2.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag2.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 3 label
            lblPhoneTag3.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag3.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag3.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 4 label
            //lblPhoneTag4.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag4.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag4.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable country label
            //lblCountry.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblCountry.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblCountry.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.CountryWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCountry();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable province label
            //lblDistrict.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblDistrict.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblDistrict.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.ProvinceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillProvinceList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable city label
            //lblCity.AutoSize = true;                            // 減少 whitespace，有字嘅位置先可以 click
            lblCity.Cursor = Cursors.Hand;                      // cursor over 顯示 hand cursor
            lblCity.Click += (s, e) =>                          // 彈出 wizard
            {
                var dialog = new Settings.CityWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillCityList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable LOO label
            //lblLOO.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblLOO.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblLOO.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.LineOfOperationWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillLineOfOperation();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Nature label
            //lblNature.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblNature.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblNature.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new WorkplaceNatureWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillNature();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Zone label
            //lblZone.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblZone.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblZone.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.ZoneWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillZone();
                };
                dialog.ShowDialog();
            };
            #endregion
            */
        }

        private void SetSmartTags()
        {
            var smartTagList = SmartTag4WorkplaceEx.GetListOrderBy(new string[] { "Priority" });

            SmartTagHelper oTag = new SmartTagHelper(this);
            oTag.WorkplaceSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }

        private void SetPhoneTags()
        {
            var oTag = new PhoneTagHelper(this, "SKU");
            oTag.SetPhoneTag();
        }
        #endregion

        #region Set System label
        private void SetSystemLabels()
        {
            //lblClass1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1");
            //lblClass2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2");
            //lblClass3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3");
            //lblClass4.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4");
            //lblClass5.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5");
            //lblClass6.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6");

            //lblRemarks1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK1");
            //lblRemarks2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK2");
            //lblRemarks3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK3");
            //lblRemarks4.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK4");
            //lblRemarks5.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK5");
            //lblRemarks6.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("REMARK6");
        }
        #endregion

        #region Set Editable
        private void SetEditable()
        {
            chkRetailItem.Checked = true;
            this.chkCounterItem.LostFocus += new EventHandler(chkCounterItem_LostFocus);

            if (_ProductId == System.Guid.Empty)
            {
                txtModifiedOn.Enabled = false;
                txtModifiedBy.Enabled = false;
                txtCreatedOn.Enabled = false;
                txtStatus_Office.Enabled = false;
                txtStatus_Counter.Enabled = false;
            }
        }

        void chkCounterItem_LostFocus(object sender, EventArgs e)
        {
            this.cboVendorCurrency.Focus();
        }
        #endregion

        #region Binding List
        private void FillList()
        {
            FillClasses();
            FillNatureList();
            FillCurrencyList();
        }

        #region Class
        private void FillClasses()
        {
            /**
            FillClass1();
            FillClass2();
            FillClass3();
            FillClass4();
            FillClass5();
            FillClass6();
            */
            ProductClass1Ex.LoadCombo(ref cboClass1, "Class1Code", false, true, "", "");
            ProductClass2Ex.LoadCombo(ref cboClass2, "Class2Code", false, true, "", "");
            ProductClass3Ex.LoadCombo(ref cboClass3, "Class3Code", false, true, "", "");
            ProductClass4Ex.LoadCombo(ref cboClass4, "Class4Code", false, true, "", "");
            ProductClass5Ex.LoadCombo(ref cboClass5, "Class5Code", false, true, "", "");
            ProductClass6Ex.LoadCombo(ref cboClass6, "Class6Code", false, true, "", "");
        }

        private void FillClass1()
        {
            ProductClass1Ex.LoadCombo(ref cboClass1, "Class1Code", false, true, "", "Retired <> 1");
            /**
            cboClass1.Items.Clear();

            string[] orderBy = new string[] { "Class1Code" };
            ProductClass1Collection oC1List = ProductClass1.LoadCollection(orderBy, true);
            oC1List.Add(new ProductClass1());
            cboClass1.DataSource = oC1List;
            cboClass1.DisplayMember = "Class1Code";
            cboClass1.ValueMember = "Class1Id";
            */
        }

        private void FillClass2()
        {
            ProductClass2Ex.LoadCombo(ref cboClass2, "Class2Code", false, true, "", "");
            /**
            cboClass2.Items.Clear();

            string[] orderBy = new string[] { "Class2Code" };
            ProductClass2Collection oC2List = ProductClass2.LoadCollection(orderBy, true);
            oC2List.Add(new ProductClass2());
            cboClass2.DataSource = oC2List;
            cboClass2.DisplayMember = "Class2Code";
            cboClass2.ValueMember = "Class2Id";
            */
        }

        private void FillClass3()
        {
            ProductClass3Ex.LoadCombo(ref cboClass3, "Class3Code", false, true, "", "");
            /**
            cboClass3.Items.Clear();

            string[] orderBy = new string[] { "Class3Code" };
            ProductClass3Collection oC3List = ProductClass3.LoadCollection(orderBy, true);
            oC3List.Add(new ProductClass3());
            cboClass3.DataSource = oC3List;
            cboClass3.DisplayMember = "Class3Code";
            cboClass3.ValueMember = "Class3Id";
            */
        }

        private void FillClass4()
        {
            ProductClass4Ex.LoadCombo(ref cboClass4, "Class4Code", false, true, "", "");
            /**
            cboClass4.Items.Clear();

            string[] orderBy = new string[] { "Class4Code" };
            ProductClass4Collection oC4List = ProductClass4.LoadCollection(orderBy, true);
            oC4List.Add(new ProductClass4());
            cboClass4.DataSource = oC4List;
            cboClass4.DisplayMember = "Class4Code";
            cboClass4.ValueMember = "Class4Id";
            */
        }
            
        private void FillClass5()
        {
            ProductClass5Ex.LoadCombo(ref cboClass5, "Class5Code", false, true, "", "");
            /**
            cboClass5.Items.Clear();

            string[] orderBy = new string[] { "Class5Code" };
            ProductClass5Collection oC5List = ProductClass5.LoadCollection(orderBy, true);
            oC5List.Add(new ProductClass5());
            cboClass5.DataSource = oC5List;
            cboClass5.DisplayMember = "Class5Code";
            cboClass5.ValueMember = "Class5Id";
            */
        }
        
        private void FillClass6()
        {
            ProductClass6Ex.LoadCombo(ref cboClass6, "Class6Code", false, true, "", "");
            /**
            cboClass6.Items.Clear();

            string[] orderBy = new string[] { "Class6Code" };
            ProductClass6Collection oC6List = ProductClass6.LoadCollection(orderBy, true);
            oC6List.Add(new ProductClass6());
            cboClass6.DataSource = oC6List;
            cboClass6.DisplayMember = "Class6Code";
            cboClass6.ValueMember = "Class6Id";
            */
        }
        #endregion

        private void FillNatureList()
        {
            var textFields = new string[] { "NatureCode", "NatureName" };
            var pattern = "{0} - {1}";
            var orderBy = new string[] { "NatureCode" };
            ProductNatureEx.LoadCombo(ref cboNature, textFields, pattern, true, true, "", "", orderBy);
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
            CurrencyEx.LoadCombo(ref cboVendorCurrency, "CurrencyCode", false, true, String.Empty, String.Empty);
        }

        #endregion

        #region Load Data
        public void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oItem = ctx.Product.Where(x => x.ProductId == this.ProductId).AsNoTracking().FirstOrDefault();
                if (oItem != null)
                {
                    cboClass1.Text = oItem.CLASS1;
                    cboClass2.Text = oItem.CLASS2;
                    cboClass3.Text = oItem.CLASS3;
                    cboClass4.Text = oItem.CLASS4;
                    cboClass5.Text = oItem.CLASS5;
                    cboClass6.Text = oItem.CLASS6;

                    txtProductName.Text = oItem.ProductName;
                    txtProductNameChs.Text = oItem.ProductName_Chs;
                    txtProductNameCht.Text = oItem.ProductName_Cht;
                    txtRemarks.Text = oItem.Remarks;

                    txtWholesalesPrice.Text = oItem.WholesalePrice.Value.ToString("n2");
                    txtOriginalRetailPrice.Text = oItem.OriginalRetailPrice.Value.ToString("n2");
                    txtCurrentRetailPrice.Text = oItem.RetailPrice.Value.ToString("n2");
                    txtRetailDiscount.Text = oItem.NormalDiscount.ToString("n2");
                    txtUnit.Text = oItem.UOM;
                    cboNature.SelectedValue = oItem.NatureId.HasValue ? oItem.NatureId : Guid.Empty;

                    txtStatus_Counter.Text = "";
                    txtStatus_Office.Text = "";
                    txtCreatedOn.Text = DateTimeHelper.DateTimeToString(oItem.CreatedOn, false);
                    txtModifiedOn.Text = DateTimeHelper.DateTimeToString(oItem.ModifiedOn, false);
                    txtModifiedBy.Text = StaffEx.GetStaffNumberById(oItem.ModifiedBy);

                    #region LoadProductBasicPrice();
                    var priceTypeId = ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.BASPRC.ToString());
                    var oBPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oBPrice != null)
                    {
                        txtCurrentRetailCurrency.Text = oBPrice.CurrencyCode;
                        txtCurrentRetailPrice.Text = oBPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    #region LoadProductOriginalPrice();
                    priceTypeId = ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.ORIPRC.ToString());
                    var oOPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oOPrice != null)
                    {
                        txtOriginalRetailCurrency.Text = oOPrice.CurrencyCode;
                        txtOriginalRetailPrice.Text = oOPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    #region LoadProductVendorPrice();
                    priceTypeId = ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.VPRC.ToString());
                    var oVPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oVPrice != null)
                    {
                        cboVendorCurrency.Text = oVPrice.CurrencyCode;
                        txtVendorPrice.Text = oVPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    #region LoadProductWholesalesPrice();
                    priceTypeId = ProductPriceTypeEx.GetIdByPriceType(ProductHelper.Prices.WHLPRC.ToString());
                    var oWPrice = ctx.ProductPrice.Where(x => x.ProductId == this.ProductId && x.PriceTypeId == priceTypeId).AsNoTracking().FirstOrDefault();
                    if (oWPrice != null)
                    {
                        txtWholesalesCurrency.Text = oWPrice.CurrencyCode;
                        txtWholesalesPrice.Text = oWPrice.Price.Value.ToString("n2");
                    }
                    #endregion

                    txtCurrentRetailPrice.Text = oItem.RetailPrice.Value.ToString("n2");

                    #region LoadProductSupplement
                    var oProdSupp = ctx.ProductSupplement.Where(x => x.ProductId == this._ProductId).AsNoTracking().FirstOrDefault();
                    if (oProdSupp != null)
                    {
                        cboVendorCurrency.Text = oProdSupp.VendorCurrencyCode;
                        txtVendorPrice.Text = oProdSupp.VendorPrice.Value.ToString("n2");
                        txtMemo.Text = oProdSupp.ProductName_Memo;
                        txtPole.Text = oProdSupp.ProductName_Pole;
                    }
                    #endregion

                    #region LoadProductRemarks
                    var oRemarks = ctx.ProductRemarks.Where(x => x.ProductId == _ProductId).AsNoTracking().FirstOrDefault();
                    if (oRemarks != null)
                    {
                        txtBin_X.Text = oRemarks.BinX;
                        txtBin_Y.Text = oRemarks.BinY;
                        txtBin_Z.Text = oRemarks.BinZ;

                        chkRetailItem.Checked = oRemarks.DownloadToShop;
                        chkOffDisplayItem.Checked = oRemarks.OffDisplayItem;
                        chkCounterItem.Checked = oRemarks.DownloadToCounter;

                        txtRemarks1.Text = oRemarks.REMARK1;
                        txtRemarks2.Text = oRemarks.REMARK2;
                        txtRemarks3.Text = oRemarks.REMARK3;
                        txtRemarks4.Text = oRemarks.REMARK4;
                        txtRemarks5.Text = oRemarks.REMARK5;
                        txtRemarks6.Text = oRemarks.REMARK6;
                    }
                    #endregion
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

        private void txtBin_Z_LostFocus(object sender, EventArgs e)
        {
            txtProductName.Focus();
        }

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