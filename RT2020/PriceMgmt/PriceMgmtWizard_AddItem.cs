#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.PriceMgmt
{
    public partial class PriceMgmtWizard_AddItem : Form
    {
        private PriceMgmtWizard_Details _PriceDetails = null;
        private bool _TabAppendixClicked = false;
        private bool _TabClassClicked = false;

        #region Public Properyties

        private EnumHelper.PriceMgmtPMType _PMType = EnumHelper.PriceMgmtPMType.Price;
        public EnumHelper.PriceMgmtPMType PMType
        {
            get { return _PMType; }
            set { _PMType = value; }
        }

        public PriceMgmtWizard_Details PriceDetails
        {
            get { return _PriceDetails; }
            set { _PriceDetails = value; }
        }

        private EnumHelper.PriceMgmtTxType _TxType = EnumHelper.PriceMgmtTxType.None;
        public EnumHelper.PriceMgmtTxType TxType
        {
            get { return _TxType; }
            set { _TxType = value; }
        }
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PriceMgmtWizard_AddItem"/> class.
        /// </summary>
        public PriceMgmtWizard_AddItem()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetAttributes();
        }

        #region Set Attributes

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {
            this.Text = this.PMType.ToString() + " - " + this.Text;

            gbMarkUpPrice.Enabled = (_PMType == EnumHelper.PriceMgmtPMType.Price);
            gbMarkUpAndDown.Enabled = (_PMType == EnumHelper.PriceMgmtPMType.Price);
            gbUsingValues.Enabled = (_PMType == EnumHelper.PriceMgmtPMType.Price);

            lblValue.Text = (_PMType == EnumHelper.PriceMgmtPMType.Price) ? "Value : " : "Disc. % : ";

            chkA1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            chkA2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            chkA3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");

            chkC1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1");
            chkC2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS2");
            chkC3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS3");
            chkC4.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS4");
            chkC5.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS5");
            chkC6.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS6");
        }

        #endregion

        private void InitTabAppendix()
        {
            chkA1.Checked = true;
            chkA2.Checked = true;
            chkA3.Checked = true;
            FillAppendixList(chkA1.Name.ToLower());
            FillAppendixList(chkA2.Name.ToLower());
            FillAppendixList(chkA3.Name.ToLower());
        }

        private void InitTabClass()
        {
            chkC1.Checked = true;
            chkC2.Checked = true;
            chkC3.Checked = true;
            chkC4.Checked = true;
            chkC5.Checked = true;
            chkC6.Checked = true;
            FillClassList(chkC1.Name.ToLower());
            FillClassList(chkC2.Name.ToLower());
            FillClassList(chkC3.Name.ToLower());
            FillClassList(chkC4.Name.ToLower());
            FillClassList(chkC5.Name.ToLower());
            FillClassList(chkC6.Name.ToLower());
        }

        #region Binding List

        #region Appendix

        /// <summary>
        /// Fills the appendix list.
        /// </summary>
        private void FillAppendixList(string appendix)
        {
            switch (appendix.ToLower().Trim())
            {
                case "chka1":
                    if (chkA1.Checked)
                    {
                        #region 填上 Appendix1 combobox 和 listview 的資料
                        gbAppendix1.Enabled = true;
                        rbtnByA1Range.Checked = true;
                        cboFromA1.DataSource = null;
                        ModelEx.ProductAppendix1Ex.LoadCombo(ref cboFromA1, "Appendix1Code", false, true, String.Empty, String.Empty);
                        cboFromA1.SelectedIndex = 0;
                        cboToA1.DataSource = null;
                        ModelEx.ProductAppendix1Ex.LoadCombo(ref cboToA1, "Appendix1Code", false, true, String.Empty, String.Empty);
                        cboToA1.SelectedIndex = cboToA1.Items.Count - 1;

                        this.FillAppendix1ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 Appendix1 combobox 和 listview 的資料
                        gbAppendix1.Enabled = false;
                        rbtnByA1Range.Checked = true;
                        cboFromA1.DataSource = null;
                        cboToA1.DataSource = null;
                        lvA1List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chka2":
                    if (chkA2.Checked)
                    {
                        #region 填上 Appendix2 combobox 和 listview 的資料
                        gbAppendix2.Enabled = true;
                        rbtnByA2Range.Checked = true;

                        ModelEx.ProductAppendix2Ex.LoadCombo(ref cboFromA2, "Appendix2Code", false, true, String.Empty, String.Empty);
                        cboFromA2.SelectedIndex = 0;

                        ModelEx.ProductAppendix2Ex.LoadCombo(ref cboToA2, "Appendix2Code", false, true, String.Empty, String.Empty);
                        cboToA2.SelectedIndex = cboToA2.Items.Count - 1;

                        this.FillAppendix2ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 Appendix2 combobox 和 listview 的資料
                        gbAppendix2.Enabled = false;
                        rbtnByA2Range.Checked = true;
                        cboFromA2.DataSource = null;
                        cboToA2.DataSource = null;
                        lvA2List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chka3":
                    if (chkA3.Checked)
                    {
                        #region 填上 Appendix3 combobox 和 listview 的資料
                        gbAppendix3.Enabled = true;
                        rbtnByA3Range.Checked = true;

                        ModelEx.ProductAppendix3Ex.LoadCombo(ref cboFromA3, "Appendix3Code", false, true, String.Empty, String.Empty);
                        cboFromA3.SelectedIndex = 0;

                        ModelEx.ProductAppendix3Ex.LoadCombo(ref cboToA3, "Appendix3Code", false, true, String.Empty, String.Empty);
                        cboToA3.SelectedIndex = cboToA3.Items.Count - 1;

                        this.FillAppendix3ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 Appendix3 combobox 和 listview 的資料
                        gbAppendix3.Enabled = false;
                        rbtnByA3Range.Checked = true;
                        cboFromA3.DataSource = null;
                        cboToA3.DataSource = null;
                        lvA3List.Items.Clear();
                        #endregion
                    }
                    break;

            }
        }

        /// <summary>
        /// Fills the appendix1 list view.
        /// </summary>
        private void FillAppendix1ListView()
        {
            String[] orderby = { "Appendix1Code" };
            lvA1List.Items.Clear();

            //2014.01.10 paulus: 加個 blank item
            ListViewItem oBlankItem = lvA1List.Items.Add(String.Empty);
            oBlankItem.SubItems.Add(String.Empty);

            using (var ctx = new EF6.RT2020Entities())
            {
                var a1List = ctx.ProductAppendix1.OrderBy(x => x.Appendix1Code);
                foreach (var a1 in a1List)
                {
                    ListViewItem objItem = lvA1List.Items.Add(a1.Appendix1Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the appendix2 list view.
        /// </summary>
        private void FillAppendix2ListView()
        {
            String[] orderby = { "Appendix2Code" };
            lvA2List.Items.Clear();

            //2014.01.10 paulus: 加個 blank item
            ListViewItem oBlankItem = lvA2List.Items.Add(String.Empty);
            oBlankItem.SubItems.Add(String.Empty);

            using (var ctx = new EF6.RT2020Entities())
            {
                var a2List = ctx.ProductAppendix2.OrderBy(x => x.Appendix2Code);
                foreach (var a2 in a2List)
                {
                    ListViewItem objItem = lvA2List.Items.Add(a2.Appendix2Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the appendix3 list view.
        /// </summary>
        private void FillAppendix3ListView()
        {
            
            String[] orderby = { "Appendix3Code" };
            lvA3List.Items.Clear();

            //2014.01.10 paulus: 加個 blank item
            ListViewItem oBlankItem = lvA3List.Items.Add(String.Empty);
            oBlankItem.SubItems.Add(String.Empty);

            using (var ctx = new EF6.RT2020Entities())
            {
                var a3List = ctx.ProductAppendix3.OrderBy(x => x.Appendix3Code);
                foreach (var a3 in a3List)
                {
                    ListViewItem objItem = lvA3List.Items.Add(a3.Appendix3Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        #endregion

        #region Class

        /// <summary>
        /// Fills the class list.
        /// </summary>
        private void FillClassList(string className)
        {
            switch (className)
            {
                case "chkc1":
                    if (chkC1.Checked)
                    {
                        #region 填上 class1 comboBox 和 listView 資料
                        gbClass1.Enabled = true;
                        rbtnByC1Range.Checked = true;

                        cboFromC1.DataSource = null;
                        ModelEx.ProductClass1Ex.LoadCombo(ref cboFromC1, "Class1Code", false, true, String.Empty, String.Empty);
                        cboFromC1.SelectedIndex = 0;

                        cboToC1.DataSource = null;
                        ModelEx.ProductClass1Ex.LoadCombo(ref cboToC1, "Class1Code", false, true, String.Empty, String.Empty);
                        cboToC1.SelectedIndex = cboToC1.Items.Count - 1;

                        FillClass1ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 class1 comboBox 和 listView 資料
                        gbClass1.Enabled = false;
                        rbtnByC1Range.Checked = true;
                        cboFromC1.DataSource = null;
                        cboToC1.DataSource = null;
                        lvC1List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chkc2":
                    if (chkC2.Checked)
                    {
                        #region 填上 class2 comboBox 和 listView 資料
                        gbClass2.Enabled = true;
                        rbtnByC2Range.Checked = true;

                        ModelEx.ProductClass2Ex.LoadCombo(ref cboFromC2, "Class2Code", false, true, String.Empty, String.Empty);
                        cboFromC2.SelectedIndex = 0;

                        ModelEx.ProductClass2Ex.LoadCombo(ref cboToC2, "Class2Code", false, true, String.Empty, String.Empty);
                        cboToC2.SelectedIndex = cboToC2.Items.Count - 1;

                        FillClass2ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 class2 comboBox 和 listView 資料
                        gbClass2.Enabled = false;
                        rbtnByC2Range.Checked = true;
                        cboFromC2.DataSource = null;
                        cboToC2.DataSource = null;
                        lvC2List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chkc3":
                    if (chkC3.Checked)
                    {
                        #region 填上 class3 comboBox 和 listView 資料
                        gbClass3.Enabled = true;
                        rbtnByC3Range.Checked = true;

                        ModelEx.ProductClass3Ex.LoadCombo(ref cboFromC3, "Class3Code", false, true, String.Empty, String.Empty);
                        cboFromC3.SelectedIndex = 0;

                        ModelEx.ProductClass3Ex.LoadCombo(ref cboToC3, "Class3Code", false, true, String.Empty, String.Empty);
                        cboToC3.SelectedIndex = cboToC3.Items.Count - 1;

                        FillClass3ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 class3 comboBox 和 listView 資料
                        gbClass3.Enabled = false;
                        rbtnByC3Range.Checked = true;
                        cboFromC3.DataSource = null;
                        cboToC3.DataSource = null;
                        lvC3List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chkc4":
                    if (chkC4.Checked)
                    {
                        #region 填上 class4 comboBox 和 listView 資料
                        gbClass4.Enabled = true;
                        rbtnByC4Range.Checked = true;

                        ModelEx.ProductClass4Ex.LoadCombo(ref cboFromC4, "Class4Code", false, true, String.Empty, String.Empty);
                        cboFromC4.SelectedIndex = 0;

                        ModelEx.ProductClass4Ex.LoadCombo(ref cboToC4, "Class4Code", false, true, String.Empty, String.Empty);
                        cboToC4.SelectedIndex = cboToC4.Items.Count - 1;

                        FillClass4ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 class4 comboBox 和 listView 資料
                        gbClass4.Enabled = false;
                        rbtnByC4Range.Checked = true;
                        cboFromC4.DataSource = null;
                        cboToC4.DataSource = null;
                        lvC4List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chkc5":
                    if (chkC5.Checked)
                    {
                        #region 填上 class5 comboBox 和 listView 資料
                        gbClass5.Enabled = true;
                        rbtnByC5Range.Checked = true;

                        ModelEx.ProductClass5Ex.LoadCombo(ref cboFromC5, "Class5Code", false, true, String.Empty, String.Empty);
                        cboFromC5.SelectedIndex = 0;

                        ModelEx.ProductClass5Ex.LoadCombo(ref cboToC5, "Class5Code", false, true, String.Empty, String.Empty);
                        cboToC5.SelectedIndex = cboToC5.Items.Count - 1;

                        FillClass5ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 class5 comboBox 和 listView 資料
                        gbClass5.Enabled = false;
                        rbtnByC5Range.Checked = true;
                        cboFromC5.DataSource = null;
                        cboToC5.DataSource = null;
                        lvC5List.Items.Clear();
                        #endregion
                    }
                    break;
                case "chkc6":
                    if (chkC6.Checked)
                    {
                        #region 填上 class6 comboBox 和 listView 資料
                        gbClass6.Enabled = true;
                        rbtnByC6Range.Checked = true;

                        ModelEx.ProductClass6Ex.LoadCombo(ref cboFromC6, "Class6Code", false, true, String.Empty, String.Empty);
                        cboFromC6.SelectedIndex = 0;

                        ModelEx.ProductClass6Ex.LoadCombo(ref cboToC6, "Class6Code", false, true, String.Empty, String.Empty);
                        cboToC6.SelectedIndex = cboToC6.Items.Count - 1;

                        FillClass6ListView();
                        #endregion
                    }
                    else
                    {
                        #region 清除 class6 comboBox 和 listView 資料
                        gbClass6.Enabled = false;
                        rbtnByC6Range.Checked = true;
                        cboFromC6.DataSource = null;
                        cboToC6.DataSource = null;
                        lvC6List.Items.Clear();
                        #endregion
                    }
                    break;
            }
        }

        /// <summary>
        /// Fills the class1 list view.
        /// </summary>
        private void FillClass1ListView()
        {
            String[] orderby = { "Class1Code" };
            lvC1List.Items.Clear();
            using (var ctx = new EF6.RT2020Entities())
            {
                var c1List = ctx.ProductClass1.OrderBy(x => x.Class1Code).AsNoTracking();
                //2014.01.23 paulus: Opera 要求加行吉嘅
                ListViewItem oBlankItem = lvC1List.Items.Add(String.Empty);
                oBlankItem.SubItems.Add(String.Empty);
                foreach (var c1 in c1List)
                {
                    ListViewItem objItem = lvC1List.Items.Add(c1.Class1Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the class2 list view.
        /// </summary>
        private void FillClass2ListView()
        {
            String[] orderby = { "Class2Code" };
            lvC2List.Items.Clear();
            using (var ctx = new EF6.RT2020Entities())
            {
                var c2List = ctx.ProductClass2.OrderBy(x => x.Class2Code).AsNoTracking();
                //2014.01.23 paulus: Opera 要求加行吉嘅
                ListViewItem oBlankItem = lvC2List.Items.Add(String.Empty);
                oBlankItem.SubItems.Add(String.Empty);
                foreach (var c2 in c2List)
                {
                    ListViewItem objItem = lvC2List.Items.Add(c2.Class2Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the class3 list view.
        /// </summary>
        private void FillClass3ListView()
        {
            String[] orderby = { "Class3Code" };
            lvC3List.Items.Clear();
            using (var ctx = new EF6.RT2020Entities())
            {
                var c3List = ctx.ProductClass3.OrderBy(x => x.Class3Code).AsNoTracking();
                //2014.01.23 paulus: Opera 要求加行吉嘅
                ListViewItem oBlankItem = lvC3List.Items.Add(String.Empty);
                oBlankItem.SubItems.Add(String.Empty);
                foreach (var c3 in c3List)
                {
                    ListViewItem objItem = lvC3List.Items.Add(c3.Class3Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the class4 list view.
        /// </summary>
        private void FillClass4ListView()
        {
            String[] orderby = { "Class4Code" };
            lvC4List.Items.Clear();
            using (var ctx = new EF6.RT2020Entities())
            {
                var c4List = ctx.ProductClass4.OrderBy(x => x.Class4Code).AsNoTracking();
                //2014.01.23 paulus: Opera 要求加行吉嘅
                ListViewItem oBlankItem = lvC4List.Items.Add(String.Empty);
                oBlankItem.SubItems.Add(String.Empty);
                foreach (var c4 in c4List)
                {
                    ListViewItem objItem = lvC4List.Items.Add(c4.Class4Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the class5 list view.
        /// </summary>
        private void FillClass5ListView()
        {
            String[] orderby = { "Class5Code" };
            lvC5List.Items.Clear();
            using (var ctx = new EF6.RT2020Entities())
            {
                var c5List = ctx.ProductClass5.OrderBy(x => x.Class5Code).AsNoTracking();
                //2014.01.23 paulus: Opera 要求加行吉嘅
                ListViewItem oBlankItem = lvC5List.Items.Add(String.Empty);
                oBlankItem.SubItems.Add(String.Empty);
                foreach (var c5 in c5List)
                {
                    ListViewItem objItem = lvC5List.Items.Add(c5.Class5Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        /// <summary>
        /// Fills the class6 list view.
        /// </summary>
        private void FillClass6ListView()
        {
            String[] orderby = { "Class6Code" };
            lvC6List.Items.Clear();
            using (var ctx = new EF6.RT2020Entities())
            {
                var c6List = ctx.ProductClass6.OrderBy(x => x.Class6Code).AsNoTracking();
                //2014.01.23 paulus: Opera 要求加行吉嘅
                ListViewItem oBlankItem = lvC6List.Items.Add(String.Empty);
                oBlankItem.SubItems.Add(String.Empty);
                foreach (var c6 in c6List)
                {
                    ListViewItem objItem = lvC6List.Items.Add(c6.Class6Code);
                    objItem.SubItems.Add(string.Empty);
                }
            }
        }

        #endregion

        private void CheckRadButton_lvw(String lvwName)
        {
            if (lvwName == lvA1List.Name)
            {
                rbtnByA1Selection.Checked = true;
            }
            else
                if (lvwName == lvA2List.Name)
                {
                    rbtnByA2Selection.Checked = true;
                }
                else
                    if (lvwName == lvA3List.Name)
                    {
                        rbtnByA3Selection.Checked = true;
                    }
                    else
                        if (lvwName == lvC1List.Name)
                        {
                            rbtnByC1Selection.Checked = true;
                        }
                        else
                            if (lvwName == lvC2List.Name)
                            {
                                rbtnByC2Selection.Checked = true;
                            }
                            else
                                if (lvwName == lvC3List.Name)
                                {
                                    rbtnByC3Selection.Checked = true;
                                }
                                else
                                    if (lvwName == lvC4List.Name)
                                    {
                                        rbtnByC4Selection.Checked = true;
                                    }
                                    else
                                        if (lvwName == lvC5List.Name)
                                        {
                                            rbtnByC5Selection.Checked = true;
                                        }
                                        else
                                            if (lvwName == lvC6List.Name)
                                            {
                                                rbtnByC6Selection.Checked = true;
                                            }
        }

        #endregion

        #region Events

        /// <summary>
        /// Sets the update discount info.
        /// </summary>
        private void SetUpdateDiscountInfo()
        {
            chkFixedPriceItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblDiscountForDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;
            txtDiscountForDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblDiscForFixedPriceItem.Enabled = chkUpdateDiscountInfo.Checked;
            txtDiscountForFixedPriceItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblDiscountForNoDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;
            txtDiscountForNoDiscountItem.Enabled = chkUpdateDiscountInfo.Checked;

            lblStaffDiscount.Enabled = chkUpdateDiscountInfo.Checked;
            txtStaffDiscount.Enabled = chkUpdateDiscountInfo.Checked;
        }

        /// <summary>
        /// Handles the Click event of the CheckBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckBox_Click(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox chkCtrl = sender as CheckBox;
                if (chkCtrl != null)
                {
                    switch (chkCtrl.Name.ToLower())
                    {
                        case "chkupdatediscountinfo":
                            SetUpdateDiscountInfo();
                            break;
                        case "chknormaldiscount":
                            txtFromNormalDiscount.Enabled = chkNormalDiscount.Checked;
                            txtToNormalDiscount.Enabled = chkNormalDiscount.Checked;
                            break;
                        case "chka1":
                        case "chka2":
                        case "chka3":
                            FillAppendixList(chkCtrl.Name.ToLower());
                            break;
                        case "chkc1":
                        case "chkc2":
                        case "chkc3":
                        case "chkc4":
                        case "chkc5":
                        case "chkc6":
                            FillClassList(chkCtrl.Name.ToLower());
                            break;
                    }

                    //this.FillAppendixList(chkCtrl.Name.ToLower());
                    //this.FillClassList(chkCtrl.Name.ToLower());
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnlookupfromstockcode":
                            Product.FindProduct wizFindFrom = new RT2020.Product.FindProduct();
                            wizFindFrom.Closed += new EventHandler(wizFindFrom_Closed);
                            wizFindFrom.ShowDialog();
                            break;
                        case "btnlookuptostockcode":
                            Product.FindProduct wizFindTo = new RT2020.Product.FindProduct();
                            wizFindTo.Closed += new EventHandler(wizFindTo_Closed);
                            wizFindTo.ShowDialog();
                            break;
                        case "btnok":
                            this.AddItems(false, false);
                            break;
                        case "btnappendixok":
                            if (CheckRadioButtons(tpAppendix, "A", 3))
                            {
                                this.AddItems(true, false);
                            }
                            else
                            {
                                MessageBox.Show("Must have at least one radio button checked! (Range or Selection ?)", "Attetion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        case "btnclassok":
                            if (CheckRadioButtons(tpClass, "C", 6))
                            {
                                this.AddItems(false, true);
                            }
                            else
                            {
                                MessageBox.Show("Must have at least one radio button checked! (Range or Selection ?)", "Attetion", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            break;
                        case "btnexit":
                        case "btnexitfromappendix":
                        case "btnexitfromclass":
                            MessageBox.Show("Confirm Exit?", "Confirmation", MessageBoxButtons.YesNo, new EventHandler(ConfirmExitEventHandler));
                            break;
                    }
                }
            }
        }

        #region Checking selections

        /// <summary>
        /// Checks the radio buttons.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <param name="keyCount">The key count.</param>
        /// <returns></returns>
        private bool CheckRadioButtons(TabPage container, string key, int keyCount)
        {
            bool result = false;

            for (int i = 1; i <= keyCount; i++)
            {
                string keyCode = key + i.ToString();                                            //第一步，找出 CheckBox
                Control[] ctrls = container.Controls.Find("chk" + keyCode, true);
                if (ctrls.Length > 0)
                {
                    if (ctrls[0] is CheckBox)
                    {
                        CheckBox chkCtrl = ctrls[0] as CheckBox;
                        if (chkCtrl != null)
                        {
                            if (chkCtrl.Checked)                                                //如果有打勾（選了）
                            {
                                result = true;
                                result = result & CheckRanges(container, keyCode);              //先查 By Range

                                if (!result)                                                    //如果不是 By Range，再查 By Selection
                                {
                                    result = true;
                                    result = result & CheckSelections(container, keyCode);
                                }
                            }
                        }
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the ranges.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private bool CheckRanges(TabPage container, string key)
        {
            bool result = false;

            Control[] ctrls = container.Controls.Find("rbtnBy" + key + "Range", true);
            if (ctrls.Length > 0)
            {
                if (ctrls[0] is RadioButton)
                {
                    RadioButton rbtnCtrl = ctrls[0] as RadioButton;
                    if (rbtnCtrl != null)
                    {
                        result = rbtnCtrl.Checked;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Checks the selections.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private bool CheckSelections(TabPage container, string key)
        {
            bool result = false;

            Control[] ctrls = container.Controls.Find("rbtnBy" + key + "Selection", true);
            if (ctrls.Length > 0)
            {
                if (ctrls[0] is RadioButton)
                {
                    RadioButton rbtnCtrl = ctrls[0] as RadioButton;
                    if (rbtnCtrl != null)
                    {
                        result = rbtnCtrl.Checked;
                    }
                }
            }

            return result;
        }

        #endregion

        /// <summary>
        /// Handles the Click event of the AppendixButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AppendixButton_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnselectalla1":
                            SelectListViewItems(ref lvA1List, true);
                            break;
                        case "btnselectalla2":
                            SelectListViewItems(ref lvA2List, true);
                            break;
                        case "btnselectalla3":
                            SelectListViewItems(ref lvA3List, true);
                            break;
                        case "btnselectnonea1":
                            SelectListViewItems(ref lvA1List, false);
                            break;
                        case "btnselectnonea2":
                            SelectListViewItems(ref lvA2List, false);
                            break;
                        case "btnselectnonea3":
                            SelectListViewItems(ref lvA3List, false);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ClassButton control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ClassButton_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnselectallc1":
                            SelectListViewItems(ref lvC1List, true);
                            break;
                        case "btnselectallc2":
                            SelectListViewItems(ref lvC2List, true);
                            break;
                        case "btnselectallc3":
                            SelectListViewItems(ref lvC3List, true);
                            break;
                        case "btnselectallc4":
                            SelectListViewItems(ref lvC4List, true);
                            break;
                        case "btnselectallc5":
                            SelectListViewItems(ref lvC5List, true);
                            break;
                        case "btnselectallc6":
                            SelectListViewItems(ref lvC6List, true);
                            break;
                        case "btnselectnonec1":
                            SelectListViewItems(ref lvC1List, false);
                            break;
                        case "btnselectnonec2":
                            SelectListViewItems(ref lvC2List, false);
                            break;
                        case "btnselectnonec3":
                            SelectListViewItems(ref lvC3List, false);
                            break;
                        case "btnselectnonec4":
                            SelectListViewItems(ref lvC4List, false);
                            break;
                        case "btnselectnonec5":
                            SelectListViewItems(ref lvC5List, false);
                            break;
                        case "btnselectnonec6":
                            SelectListViewItems(ref lvC6List, false);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Selects the list view items.
        /// </summary>
        /// <param name="lvCtrl">The listview control.</param>
        private void SelectListViewItems(ref ListView lvCtrl, bool selectAll)
        {
            foreach (ListViewItem lvItem in lvCtrl.Items)
            {
                if (selectAll)
                {
                    lvItem.SubItems[1].Text = lvItem.SubItems[1].Text != "*" ? "*" : lvItem.SubItems[1].Text;
                }
                else
                {
                    lvItem.SubItems[1].Text = lvItem.SubItems[1].Text != "" ? "" : lvItem.SubItems[1].Text;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the ListView control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ListView_Click(object sender, EventArgs e)
        {
            if (sender is ListView)
            {
                ListView lvCtrl = sender as ListView;
                if (lvCtrl != null)
                {
                    //2014.01.10 paulus: 改為 toggle
                    //lvCtrl.SelectedItem.SubItems[1].Text = lvCtrl.SelectedItem.SubItems[1].Text != "*" ? "*" : lvCtrl.SelectedItem.SubItems[1].Text;
                    lvCtrl.SelectedItem.SubItems[1].Text = lvCtrl.SelectedItem.SubItems[1].Text != "*" ? "*" : String.Empty;
                    CheckRadButton_lvw(lvCtrl.Name);
                }
            }
        }

        /// <summary>
        /// Handles the Closed event of the wizFindFrom control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void wizFindFrom_Closed(object sender, EventArgs e)
        {
            if (sender is Product.FindProduct)
            {
                Product.FindProduct wizFindFrom = sender as Product.FindProduct;
                if (wizFindFrom != null)
                {
                    txtFromStockCode.Text = ModelEx.ProductEx.GetSTKCODE(wizFindFrom.ProductId);
                }
            }
        }

        /// <summary>
        /// Handles the Closed event of the wizFindTo control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void wizFindTo_Closed(object sender, EventArgs e)
        {
            if (sender is Product.FindProduct)
            {
                Product.FindProduct wizFindTo = sender as Product.FindProduct;
                if (wizFindTo != null)
                {
                    txtToStockCode.Text = ModelEx.ProductEx.GetSTKCODE(wizFindTo.ProductId);
                }
            }
        }

        /// <summary>
        /// Handles the GotFocus event of the TextBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void TextBox_GotFocus(object sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox txtCtrl = sender as TextBox;
                if (txtCtrl != null)
                {
                    txtCtrl.SelectAll();
                }
            }
        }

        /// <summary>
        /// Confirms the exit event handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        void ConfirmExitEventHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        #endregion

        #region Add items

        /// <summary>
        /// Adds the items.
        /// </summary>
        /// <param name="includeAppendix">if set to <c>true</c> [include appendix].</param>
        /// <param name="includeClass">if set to <c>true</c> [include class].</param>
        private void AddItems(bool includeAppendix, bool includeClass)
        {
            if (PriceDetails != null)
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    string query = BuildQuery(includeAppendix, includeClass);

                    var objProductList = ctx.Product
                        .SqlQuery(string.Format("Select * from Product Where {0} Order By (1)", query, "STKCODE, APPENDIX1, APPENDIX2, APPENDIX3"))
                        .ToList();
                    foreach (var objProduct in objProductList)
                    {
                        decimal avgCost = ModelEx.ProductCurrentSummaryEx.GetAverageCode(objProduct.ProductId);
                        decimal oldMu = 0, newMu = 0, diff = 0;
                        decimal newPrice = 0, newDiscount = 0;

                        if (_PMType == EnumHelper.PriceMgmtPMType.Price)
                        {
                            newPrice = CalcNewPrice(objProduct.RetailPrice.Value, avgCost);

                            if (avgCost > 0)
                            {
                                oldMu = ((objProduct.RetailPrice.Value / avgCost) - 1) * 100;
                                newMu = ((newPrice / avgCost) - 1) * 100;
                            }
                        }
                        else
                        {
                            decimal.TryParse(txtValue.Text, out newDiscount);
                        }

                        ListViewItem lvItem = PriceDetails.lvItemList.Items.Add(System.Guid.Empty.ToString());
                        lvItem.SubItems.Add("N"); // N = New
                        lvItem.SubItems.Add(objProduct.STKCODE);
                        lvItem.SubItems.Add(objProduct.APPENDIX1);
                        lvItem.SubItems.Add(objProduct.APPENDIX2);
                        lvItem.SubItems.Add(objProduct.APPENDIX3);
                        lvItem.SubItems.Add(avgCost.ToString()); // Average Cost
                        lvItem.SubItems.Add(objProduct.RetailPrice.Value.ToString("n2")); // Old Price
                        lvItem.SubItems.Add(oldMu.ToString("n2")); // Old MarkUp
                        lvItem.SubItems.Add(newPrice.ToString("n2")); // New Price
                        lvItem.SubItems.Add(newMu.ToString("n2")); // New MarkUp
                        lvItem.SubItems.Add(diff.ToString("n2")); // Difference
                        lvItem.SubItems.Add(objProduct.NormalDiscount.ToString("n2")); // Old Discount
                        lvItem.SubItems.Add(newDiscount.ToString("n2")); // new Discount
                        lvItem.SubItems.Add(objProduct.ProductName); // Descritpion
                        lvItem.SubItems.Add(objProduct.CLASS1); // Class1
                        lvItem.SubItems.Add(objProduct.CLASS2); // Class2
                        lvItem.SubItems.Add(objProduct.CLASS3); // Class3
                        lvItem.SubItems.Add(objProduct.CLASS4); // Class4
                        lvItem.SubItems.Add(objProduct.CLASS5); // Class5
                        lvItem.SubItems.Add(objProduct.CLASS6); // Class6
                        lvItem.SubItems.Add(chkUpdateDiscountInfo.Checked ? "Y" : "N"); // Update VIP Discount
                        lvItem.SubItems.Add(chkUpdateDiscountInfo.Checked ? (chkFixedPriceItem.Checked ? "Y" : "N") : (objProduct.FixedPriceItem ? "Y" : "N")); // Fixed price item
                        lvItem.SubItems.Add(chkUpdateDiscountInfo.Checked ? txtDiscountForFixedPriceItem.Text : ProductHelper.GetVipDiscount(objProduct.ProductId, "FixedItem").ToString("n2")); // Discount For Fixed price Item
                        lvItem.SubItems.Add(chkUpdateDiscountInfo.Checked ? txtDiscountForDiscountItem.Text : ProductHelper.GetVipDiscount(objProduct.ProductId, "DiscItem").ToString("n2")); // Discount for Discount Item
                        lvItem.SubItems.Add(chkUpdateDiscountInfo.Checked ? txtDiscountForNoDiscountItem.Text : ProductHelper.GetVipDiscount(objProduct.ProductId, "NoDiscItem").ToString("n2")); // Disocunt for No Discount Item
                        lvItem.SubItems.Add(chkUpdateDiscountInfo.Checked ? txtStaffDiscount.Text : ProductHelper.GetVipDiscount(objProduct.ProductId, "StaffDisc").ToString("n2")); // Staff Discount
                        lvItem.SubItems.Add(objProduct.ProductId.ToString());
                    }
                }
            }

            MessageBox.Show("Confirm Exit?", "Confirmation", MessageBoxButtons.YesNo, new EventHandler(ConfirmExitEventHandler));
        }

        #region Build Query String

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery(bool includeAppendix, bool includeClass)
        {
            StringBuilder query = new StringBuilder();
            query.Append("STKCODE >= '");
            query.Append(txtFromStockCode.Text.Trim());
            query.Append("' AND STKCODE <= '");
            query.Append(txtToStockCode.Text.Trim()).Append("'");

            if (includeAppendix)
            {
                query.Append(BuildSubquery(tpAppendix, "A", 3));
            }

            if (includeClass)
            {
                query.Append(BuildSubquery(tpClass, "C", 6));
            }

            if (chkNormalDiscount.Checked)
            {
                query.Append(" AND NormalDiscount >= ");
                query.Append(txtFromNormalDiscount.Text.Trim());
                query.Append(" AND NormalDiscount <= ");
                query.Append(txtToNormalDiscount.Text.Trim());
            }

            return query.ToString();
        }

        /// <summary>
        /// Builds the subquery.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="key">The key.</param>
        /// <param name="keyCount">The key count.</param>
        /// <returns></returns>
        private string BuildSubquery(TabPage container, string key, int keyCount)
        {
            StringBuilder query = new StringBuilder();

            for (int i = 1; i <= keyCount; i++)
            {
                string keyCode = key + i.ToString();
                Control[] ctrls = container.Controls.Find("chk" + keyCode, true);
                if (ctrls.Length > 0)
                {
                    if (ctrls[0] is CheckBox)
                    {
                        CheckBox chkCtrl = ctrls[0] as CheckBox;
                        if (chkCtrl != null)
                        {
                            if (chkCtrl.Checked)
                            {
                                query.Append(BuildSubqueryFromRange(container, keyCode));
                                query.Append(BuildSubqueryFromSelection(container, keyCode));
                            }
                        }
                    }
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// Builds the subquery from range.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string BuildSubqueryFromRange(TabPage container, string key)
        {
            StringBuilder query = new StringBuilder();

            Control[] ctrls = container.Controls.Find("rbtnBy" + key + "Range", true);
            if (ctrls.Length > 0)
            {
                if (ctrls[0] is RadioButton)
                {
                    RadioButton rbtnCtrl = ctrls[0] as RadioButton;
                    if (rbtnCtrl != null)
                    {
                        if (rbtnCtrl.Checked)
                        {
                            ctrls = container.Controls.Find("cboFrom" + key, true);
                            if (ctrls.Length > 0)
                            {
                                if (ctrls[0] is ComboBox)
                                {
                                    ComboBox cboFromCtrl = ctrls[0] as ComboBox;
                                    if (cboFromCtrl != null)
                                    {
                                        query.Append(" AND ").Append(GetFieldName(key)).Append(" >= '");
                                        query.Append(cboFromCtrl.Text);
                                        query.Append("'");
                                    }
                                    else
                                    {
                                        query.Append(" AND ").Append(GetFieldName(key)).Append(" >= ''");
                                    }
                                }
                            }

                            ctrls = container.Controls.Find("cboTo" + key, true);
                            if (ctrls.Length > 0)
                            {
                                if (ctrls[0] is ComboBox)
                                {
                                    ComboBox cboToCtrl = ctrls[0] as ComboBox;
                                    if (cboToCtrl != null)
                                    {
                                        query.Append(" AND ").Append(GetFieldName(key)).Append(" <= '");
                                        query.Append(cboToCtrl.Text);
                                        query.Append("'");
                                    }
                                    else
                                    {
                                        query.Append(" AND ").Append(GetFieldName(key)).Append(" <= ''");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// Builds the subquery from selection.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string BuildSubqueryFromSelection(TabPage container, string key)
        {
            StringBuilder query = new StringBuilder();

            Control[] radBySelection = container.Controls.Find("rbtnBy" + key + "Selection", true);
            if (radBySelection.Length > 0)
            {
                if (radBySelection[0] is RadioButton)
                {
                    RadioButton rbtnCtrl = radBySelection[0] as RadioButton;
                    if (rbtnCtrl != null)
                    {
                        Control[] lvwBySelection = container.Controls.Find("lv" + key + "List", true);
                        if (lvwBySelection.Length > 0)
                        {
                            if (lvwBySelection[0] is ListView)
                            {
                                ListView lvCtrl = lvwBySelection[0] as ListView;
                                if (lvCtrl != null)
                                {
                                    if (rbtnCtrl.Checked && lvCtrl.Items.Count > 0)
                                    {
                                        query.Append(" AND ").Append(GetFieldName(key)).Append(" IN (");

                                        int i = 0;
                                        foreach (ListViewItem row in lvCtrl.Items)                  //loop 整個 ListView
                                        {
                                            if (row.SubItems[1].Text == "*")                        // 把有打 * 的都加進 query
                                            {
                                                if (i > 0)
                                                {
                                                    query.Append(", ");
                                                }

                                                query.Append("'");
                                                query.Append(row.SubItems[0].Text);
                                                query.Append("'");

                                                i++;
                                            }
                                        }

                                        query.Append(")");
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return query.ToString();
        }

        /// <summary>
        /// Gets the name of the field.
        /// </summary>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        private string GetFieldName(string key)
        {
            string fieldName = "APPENDIX1";

            switch (key.ToLower().Trim())
            {
                case "a1":
                    fieldName = "APPENDIX1";
                    break;
                case "a2":
                    fieldName = "APPENDIX2";
                    break;
                case "a3":
                    fieldName = "APPENDIX3";
                    break;
                case "c1":
                    fieldName = "CLASS1";
                    break;
                case "c2":
                    fieldName = "CLASS2";
                    break;
                case "c3":
                    fieldName = "CLASS3";
                    break;
                case "c4":
                    fieldName = "CLASS4";
                    break;
                case "c5":
                    fieldName = "CLASS5";
                    break;
                case "c6":
                    fieldName = "CLASS6";
                    break;
            }

            return fieldName;
        }

        #endregion

        /// <summary>
        /// Calcs the new price.
        /// </summary>
        /// <param name="rtlPrice">The retail price to be changed.</param>
        /// <param name="avgCost">The average cost to be changed.</param>
        /// <returns></returns>
        private decimal CalcNewPrice(decimal rtlPrice, decimal avgCost)
        {
            decimal newPrice = 0;
            decimal valueToChange = 0;

            decimal.TryParse(txtValue.Text.Trim(), out valueToChange);

            // Mark by retail price / average cost
            if (rbtnMarkByPrice.Checked)
            {
                newPrice = rtlPrice;
            }
            else
            {
                newPrice = avgCost;
            }

            // use value as percentage
            if (rbtnUsePercentageValue.Checked)
            {
                valueToChange = valueToChange / 100;

                // Mark down / up
                if (rbtnMarkDown.Checked)
                {
                    newPrice = newPrice * (1 - valueToChange);
                }
                else
                {
                    newPrice = newPrice * (1 + valueToChange);
                }
            }
            else // use value as amount
            {
                // Mark down / up
                if (rbtnMarkDown.Checked)
                {
                    newPrice = newPrice - valueToChange;
                }
                else
                {
                    newPrice = newPrice + valueToChange;
                }
            }

            return newPrice;
        }

        #endregion

        private void tbAddItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (((TabControl)sender).SelectedIndex)
            {
                case 1:
                    if (!(_TabAppendixClicked))
                    {
                        InitTabAppendix();
                        _TabAppendixClicked = true;
                    }
                    break;
                case 2:
                    if (!(_TabClassClicked))
                    {
                        //2014.01.23 paulus: 又話唔使 pre-load
                        //InitTabClass();
                        _TabClassClicked = true;
                    }
                    break;
                case 0:
                default:
                    break;
            }
        }
    }
}