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

using System.Data.SqlClient;
using System.Configuration;
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Settings
{
    public partial class CurrencyWizard : Form
    {
        #region Properties
        private Guid _CurrencyId = System.Guid.Empty;
        public Guid CurrencyId
        {
            get { return _CurrencyId; }
            set { _CurrencyId = value; }
        }
        #endregion

        public CurrencyWizard()
        {
            InitializeComponent();
        }

        private void CurrencyWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            SetCtrlEditable();
            FillCountryName();
            BindCurrencyList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("currency.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colCurrencyCode.Text = WestwindHelper.GetWord("currency.code", "Model");
            colCountryName.Text = WestwindHelper.GetWord("country.name", "Model");
            colCurrencyName.Text = WestwindHelper.GetWord("currency.name", "Model");
            colExchangeRate.Text = WestwindHelper.GetWord("currency.exchangeRate", "Model");
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");

            lblCurrencyCode.Text = WestwindHelper.GetWordWithColon("currency.code", "Model");
            lblCurrencyName.Text = WestwindHelper.GetWordWithColon("currency.name", "Model");
            lblCountryName.Text = WestwindHelper.GetWord("country.name", "Model");
            lblExchangeRate.Text = WestwindHelper.GetWordWithColon("currency.exchangeRate", "Model");
            lblUnicodeDecimal.Text = WestwindHelper.GetWordWithColon("currency.symbol", "Model");
        }

        private void SetAttributes()
        {
            lvCurrencyList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colCurrencyCode.TextAlign = HorizontalAlignment.Center;
            colCurrencyCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCountryName.TextAlign = HorizontalAlignment.Left;
            colCountryName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCurrencyName.TextAlign = HorizontalAlignment.Left;
            colCurrencyName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colExchangeRate.TextAlign = HorizontalAlignment.Right;
            colExchangeRate.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCreatedOn.TextAlign = HorizontalAlignment.Right;
            colCreatedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colModifiedOn.TextAlign = HorizontalAlignment.Right;
            colModifiedOn.ContentAlign = ExtendedHorizontalAlignment.Center;

            #region 設定 clickable Class 1 label
            lblCountryName.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblCountryName.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblCountryName.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new CountryWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCountryName();
                };
                dialog.ShowDialog();
            };
            #endregion

            // 2021.01.20 paulus: 唔啱用，Euro 唔係國家
            lblCountryName.Visible = cboCountryName.Visible = colCountryName.Visible = false;
        }

        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_CurrencyId == Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "new":
                        ClearForm();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            ClearForm();
                            BindCurrencyList();
                        }
                        break;
                    case "refresh":
                        LoadData();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Currency Code
        private void SetCtrlEditable()
        {
            txtCurrencyCode.BackColor = (_CurrencyId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCurrencyCode.ReadOnly = (_CurrencyId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCurrencyCode, string.Empty);
            errorProvider.SetError(txtUnicodeDecimal, string.Empty);
            errorProvider.SetError(txtExchangeRate, string.Empty);
        }

        private void ClearForm()
        {
            txtCurrencyCode.Text = txtCurrencyName.Text = txtExchangeRate.Text = txtUnicodeDecimal.Text = string.Empty;

            _CurrencyId = Guid.Empty;
            SetCtrlEditable();
            FillCountryName();
        }
        #endregion

        #region Fill Country Name
        private void FillCountryName()
        {

            //ModelEx.CountryEx.LoadCombo(ref cboCountryName, "CountryName", true);
            var fields = new string[] { "CountryCode", "CountryName" };
            var pattern = "{0} - {1}";
            var orderby = new string[] { "CountryCode" };
            ModelEx.CountryEx.LoadCombo(ref cboCountryName, fields, pattern, true, true, "", "", orderby);
        }
        #endregion

        #region Bind Currency List

        private void BindCurrencyList()
        {
            this.lvCurrencyList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Currency.OrderBy(x => x.CurrencyCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var oItem = this.lvCurrencyList.Items.Add(item.CurrencyCode);
                    oItem.SubItems.Add(iCount.ToString()); // Line Number
                    oItem.SubItems.Add(item.CurrencyId.ToString());
                    oItem.SubItems.Add(item.CountryName);
                    oItem.SubItems.Add(item.CurrencyName);
                    oItem.SubItems.Add(item.ExchangeRate.HasValue ? item.ExchangeRate.Value.ToString("n4") : "");
                    oItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true));
                    oItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true));

                    iCount++;
                }
            }
        }

        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true; decimal numeric = 0;
            errorProvider.SetError(txtCurrencyCode, string.Empty);
            errorProvider.SetError(txtUnicodeDecimal, string.Empty);
            errorProvider.SetError(txtExchangeRate, string.Empty);

            #region CountryCode 唔可以吉
            if (txtCurrencyCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCurrencyCode, "Cannot be blank!");
                errorProvider.SetIconAlignment(txtCurrencyCode, ErrorIconAlignment.TopLeft);
                result = false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            if (_CurrencyId == Guid.Empty)
            {
                if (ModelEx.CurrencyEx.IsCurrencyCodeInUse(txtCurrencyCode.Text.Trim()))
                {
                    errorProvider.SetError(txtCurrencyCode, "Currency Code in use");
                    errorProvider.SetIconAlignment(txtCurrencyCode, ErrorIconAlignment.TopLeft);
                    result = false;
                }
            }
            #endregion

            if (!decimal.TryParse(txtUnicodeDecimal.Text, out numeric))
            {
                errorProvider.SetError(txtUnicodeDecimal, Resources.Common.DigitalNeeded);
                errorProvider.SetIconAlignment(txtUnicodeDecimal, ErrorIconAlignment.TopLeft);
                result = false;
            }
            if (!decimal.TryParse(txtExchangeRate.Text, out numeric))
            {
                errorProvider.SetError(txtExchangeRate, Resources.Common.DigitalNeeded);
                errorProvider.SetIconAlignment(txtExchangeRate, ErrorIconAlignment.TopLeft);
                result = false;
            }

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var currency = ctx.Currency.Find(_CurrencyId);

                if (currency == null)
                {
                    currency = new EF6.Currency();

                    currency.CurrencyId = Guid.NewGuid();
                    currency.CurrencyCode = txtCurrencyCode.Text;
                    currency.CreatedBy = ConfigHelper.CurrentUserId;
                    currency.CreatedOn = DateTime.Now;

                    ctx.Currency.Add(currency);
                }
                currency.CountryName = (Guid)cboCountryName.SelectedValue != Guid.Empty ? ModelEx.CountryEx.GetCountryCode((Guid)cboCountryName.SelectedValue) : "";
                currency.CurrencyName = txtCurrencyName.Text;
                currency.UnicodeDecimal = Convert.ToInt32((txtUnicodeDecimal.Text == string.Empty) ? "0" : txtUnicodeDecimal.Text);
                currency.ExchangeRate = Convert.ToDecimal((txtExchangeRate.Text == string.Empty) ? "0" : txtExchangeRate.Text);
                currency.ModifiedBy = ConfigHelper.CurrentUserId;
                currency.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        private void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var currency = ctx.Currency.Find(_CurrencyId);
                if (currency != null)
                {
                    var countryId = ModelEx.CountryEx.GetCountryIdByCode(currency.CountryName);

                    txtCurrencyCode.Text = currency.CurrencyCode;
                    txtCurrencyName.Text = currency.CurrencyName;
                    cboCountryName.SelectedValue = countryId != Guid.Empty ? countryId : Guid.Empty;
                    txtUnicodeDecimal.Text = currency.UnicodeDecimal.ToString();
                    txtExchangeRate.Text = currency.ExchangeRate == null ? "" : currency.ExchangeRate?.ToString("n4");
                    ShowSymbol();
                    SetCtrlEditable();
                    SetToolBar();
                }
            }
        }

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var currency = ctx.Currency.Find(_CurrencyId);
                    if (currency != null)
                    {
                        ctx.Currency.Remove(currency);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        /// <summary>
        /// refer: https://www.xe.com/symbols.php
        /// dbo.Currency.UnicodeDecimal 設計錯誤，應該係 int delimited array 先啱
        /// </summary>
        private void ShowSymbol()
        {
            int[] list = { 350, 290, 10 };

            Encoding encoding = Encoding.Unicode;

            var result = list.Select(i => encoding.GetString(BitConverter.GetBytes(i))).ToList();

            int source = 0;
            if (int.TryParse(txtUnicodeDecimal.Text.Trim(), out source))
            {
                lblSymbol.Text = encoding.GetString(BitConverter.GetBytes(source));
            }
        }

        private void lnkCountryName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CountryWizard countryWizard = new CountryWizard();
            countryWizard.ShowDialog();
            FillCountryName();
            this.Update();
        }

        private void lvCurrencyList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCurrencyList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvCurrencyList.SelectedItem.SubItems[2].Text, out id))
                {
                    _CurrencyId = id;
                    LoadData();
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindCurrencyList();
                ClearForm();
                SetCtrlEditable();
            }
        }

        private void txtUnicodeDecimal_Leave(object sender, EventArgs e)
        {
            ShowSymbol();
        }

        private void txtUnicodeDecimal_EnterKeyDown(object objSender, KeyEventArgs objArgs)
        {
            ShowSymbol();
        }
    }
}