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
using RT2020.DAL;
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
            colCountryName.Text = WestwindHelper.GetWord("currency.name", "Model");

            lblCurrencyCode.Text = WestwindHelper.GetWordWithColon("currency.code", "Model");
            lblCurrencyName.Text = WestwindHelper.GetWordWithColon("currency.name", "Model");

            lnkCountryName.Text = WestwindHelper.GetWord("country.name", "Model");

            lblExchangeRate.Text = WestwindHelper.GetWordWithColon("currency.exchageRate", "Model");
            lblUnicodeDecimal.Text = WestwindHelper.GetWordWithColon("currency.symbol", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colCurrencyCode.TextAlign = HorizontalAlignment.Left;
            colCurrencyCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCountryName.TextAlign = HorizontalAlignment.Left;
            colCountryName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCurrencyName.TextAlign = HorizontalAlignment.Left;
            colCurrencyName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colExchangeRate.TextAlign = HorizontalAlignment.Left;
            colExchangeRate.ContentAlign = ExtendedHorizontalAlignment.Center;
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

            if (CurrencyId == System.Guid.Empty)
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
                        Clear();
                        SetCtrlEditable();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindCurrencyList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindCurrencyList();
                        FillCountryName();
                        this.Update();
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
            txtCurrencyCode.BackColor = (this.CurrencyId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCurrencyCode.ReadOnly = (this.CurrencyId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtCurrencyCode, string.Empty);
            errorProvider.SetError(txtUnicodeDecimal, string.Empty);
            errorProvider.SetError(txtExchangeRate, string.Empty);
        }
        #endregion

        #region Country Name
        private void FillCountryName()
        {
            ModelEx.CountryEx.LoadCombo(ref cboCountryName, "CountryName", true);
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
                    var oItem = this.lvCurrencyList.Items.Add(item.CurrencyId.ToString());
                    oItem.SubItems.Add(iCount.ToString()); // Line Number
                    oItem.SubItems.Add(item.CountryName);
                    oItem.SubItems.Add(item.CurrencyCode);
                    oItem.SubItems.Add(item.CurrencyName);
                    oItem.SubItems.Add(item.ExchangeRate.Value.ToString("n4"));
                    oItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(item.CreatedOn, true));
                    oItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(item.ModifiedOn, true));

                    iCount++;
                }
            }
        }

        #endregion

        #region Properties
        private Guid currencyId = System.Guid.Empty;
        public Guid CurrencyId
        {
            get
            {
                return currencyId;
            }
            set
            {
                currencyId = value;
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region CountryCode 唔可以吉
            errorProvider.SetError(txtCurrencyCode, string.Empty);
            if (txtCurrencyCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCurrencyCode, "Cannot be blank!");
                result = false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            errorProvider.SetError(txtCurrencyCode, string.Empty);
            if (this.CurrencyId == System.Guid.Empty && ModelEx.CurrencyEx.IsCurrencyCodeInUse(txtCurrencyCode.Text.Trim()))
            {
                errorProvider.SetError(txtCurrencyCode, "Currency Code in use");
                result = false;
            }
            #endregion

            if (!Common.Utility.IsNumeric(txtUnicodeDecimal.Text))
            {
                errorProvider.SetError(txtUnicodeDecimal, Resources.Common.DigitalNeeded);
                result = false;
            }
            else if (!Common.Utility.IsNumeric(txtExchangeRate.Text))
            {
                errorProvider.SetError(txtExchangeRate, Resources.Common.DigitalNeeded);
                result = false;
            }

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var currency = ctx.Currency.Find(this.CurrencyId);

                if (currency == null)
                {
                    currency = new EF6.Currency();
                    currency.CurrencyId = new Guid();
                    currency.CreatedBy = Common.Config.CurrentUserId;
                    currency.CreatedOn = DateTime.Now;

                    ctx.Currency.Add(currency);
                    currency.CurrencyCode = txtCurrencyCode.Text;
                }
                currency.CountryName = txtCurrencyName.Text;
                currency.UnicodeDecimal = Convert.ToInt32((txtUnicodeDecimal.Text == string.Empty) ? "0" : txtUnicodeDecimal.Text);
                currency.ExchangeRate = Convert.ToDecimal((txtExchangeRate.Text == string.Empty) ? "0" : txtExchangeRate.Text);
                currency.ModifiedBy = Common.Config.CurrentUserId;
                currency.ModifiedOn = DateTime.Now;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            CurrencyWizard wizCurrency = new CurrencyWizard();
            wizCurrency.ShowDialog();
        }
        #endregion

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var currency = ctx.Currency.Find(this.CurrencyId);
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
                if (Guid.TryParse(lvCurrencyList.SelectedItem.Text, out id))
                {
                    this.CurrencyId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var currency = ctx.Currency.Find(this.CurrencyId);
                        if (currency != null)
                        {
                            txtCurrencyCode.Text = currency.CurrencyCode;
                            txtCurrencyName.Text = currency.CurrencyName;
                            cboCountryName.Text = currency.CountryName;
                            txtUnicodeDecimal.Text = currency.UnicodeDecimal.ToString();
                            txtExchangeRate.Text = currency.ExchangeRate == null ? "" : currency.ExchangeRate?.ToString("n4");

                            SetCtrlEditable();
                            SetToolBar();
                        }
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindCurrencyList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}