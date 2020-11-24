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

#endregion

namespace RT2020.Settings
{
    public partial class CurrencyWizard : Form
    {
        public CurrencyWizard()
        {
            InitializeComponent();
            SetToolBar();
            SetCtrlEditable();
            FillCountryName();
            BindCurrencyList();
        }

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
            ToolBarButton cmdNew = new ToolBarButton("New", "New");
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", "Refresh");
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
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
                        if (Save())
                        {
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
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT CurrencyId,  ROW_NUMBER() OVER (ORDER BY CurrencyCode) AS rownum, ");
            sql.Append(" CurrencyCode, CurrencyName, CountryName, ExchangeRate,");
            sql.Append(" CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM Currency ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvCurrencyList.Items.Add(reader.GetGuid(0).ToString()); // CurrencyId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(4)); // Country Name
                    objItem.SubItems.Add(reader.GetString(2)); // CurrencyCode
                    objItem.SubItems.Add(reader.GetString(3)); // Currency Name
                    objItem.SubItems.Add(reader.GetDecimal(5).ToString("n4")); // Exchange Rate
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(6), true)); // CreatedOn
                    objItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(7), true)); // ModifiedOn

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
        private bool CodeExists()
        {
            string sql = "CurrencyCode = '" + txtCurrencyCode.Text.Trim() + "'";
            CurrencyCollection cnyList = Currency.LoadCollection(sql);
            if (cnyList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Save()
        {
            if (txtCurrencyCode.Text.Length == 0)
            {
                errorProvider.SetError(txtCurrencyCode, "Currency Code cannot be blank!");
                return false;
            }
            if (!Common.Utility.IsNumeric(txtUnicodeDecimal.Text))
            {
                errorProvider.SetError(txtUnicodeDecimal, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtExchangeRate.Text))
            {
                errorProvider.SetError(txtExchangeRate, Resources.Common.DigitalNeeded);
                return false;
            }
            else
            {
                errorProvider.SetError(txtCurrencyCode, string.Empty);
                errorProvider.SetError(txtUnicodeDecimal, string.Empty);
                errorProvider.SetError(txtExchangeRate, string.Empty);

                Currency oCny = Currency.Load(this.CurrencyId);
                if (oCny == null)
                {
                    oCny = new Currency();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtCurrencyCode, string.Format(Resources.Common.DuplicatedCode, "Currency Code"));
                        return false;
                    }
                    else
                    {
                        errorProvider.SetError(txtCurrencyCode, string.Empty);

                        oCny.CurrencyCode = txtCurrencyCode.Text;
                        oCny.CreatedBy = Common.Config.CurrentUserId;
                        oCny.CreatedOn = DateTime.Now;
                    }
                }
                oCny.CountryName = cboCountryName.Text;
                oCny.CurrencyName = txtCurrencyName.Text;
                oCny.UnicodeDecimal = Convert.ToInt32((txtUnicodeDecimal.Text == string.Empty) ? "0" : txtUnicodeDecimal.Text);
                oCny.ExchangeRate = Convert.ToDecimal((txtExchangeRate.Text == string.Empty) ? "0" : txtExchangeRate.Text);
                oCny.ModifiedBy = Common.Config.CurrentUserId;
                oCny.ModifiedOn = DateTime.Now;

                oCny.Save();

                this.CurrencyId = oCny.CurrencyId;
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            CurrencyWizard wizCurrency = new CurrencyWizard();
            wizCurrency.ShowDialog();
        }
        #endregion

        #region Load
        private void LoadCurrencyInfo()
        {
            Currency oCny = Currency.Load(this.CurrencyId);
            if (oCny != null)
            {
                txtCurrencyCode.Text = oCny.CurrencyCode;
                txtCurrencyName.Text = oCny.CurrencyName;
                cboCountryName.Text = oCny.CountryName;
                txtUnicodeDecimal.Text = oCny.UnicodeDecimal.ToString();
                txtExchangeRate.Text = oCny.ExchangeRate.ToString("n4");
            }
        }
        #endregion

        private void Delete()
        {
            Currency oCurrency = Currency.Load(this.CurrencyId);
            if (oCurrency != null)
            {
                try
                {
                    oCurrency.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
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
                if (Common.Utility.IsGUID(lvCurrencyList.SelectedItem.Text))
                {
                    this.CurrencyId = new Guid(lvCurrencyList.SelectedItem.Text);
                    LoadCurrencyInfo();
                    SetCtrlEditable();
                    SetToolBar();
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