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
using RT2020.Helper;

#endregion

namespace RT2020.Settings
{
    public partial class PaymentFactor : Form
    {
        public PaymentFactor(FactorType type)
        {
            InitializeComponent();

            this.PaymentFactorType = type;
        }

        private void PaymentFactor_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            ControlChanging();
            SetToolBar();
            FillComboList();
            BindPaymentFactorList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("country.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            //colCountryCode.Text = WestwindHelper.GetWord("country.code", "Model");
            //colCountryName.Text = WestwindHelper.GetWord("country.name", "Model");
            //colCountryNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            //colCountryNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            //lblCountryCode.Text = WestwindHelper.GetWordWithColon("country.code", "Model");
            //lblCountryName.Text = WestwindHelper.GetWordWithColon("country.name", "Model");
            //lblCountryNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            //lblCountryNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            //lnkAddProvince.Text = WestwindHelper.GetWord("province", "Model");
            //lnkAddCity.Text = WestwindHelper.GetWord("city", "Model");
        }

        private void SetAttributes()
        {
            lvPaymentFactor.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colCountryCode.TextAlign = HorizontalAlignment.Left;
            //colCountryCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            //colCountryName.TextAlign = HorizontalAlignment.Left;
            //colCountryName.ContentAlign = ExtendedHorizontalAlignment.Center;
            //colCountryNameAlt1.TextAlign = HorizontalAlignment.Left;
            //colCountryNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            //colCountryNameAlt2.TextAlign = HorizontalAlignment.Left;
            //colCountryNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;
        }

        #endregion

        public PaymentFactor(Guid paymentFactorId, FactorType type)
        {
            InitializeComponent();
            this.PaymentFactorId = paymentFactorId;
            this.PaymentFactorType = type;
            ControlChanging();
            SetToolBar();
            FillComboList();
            LoadPaymentFactor();
            BindPaymentFactorList();
        }

        #region Enums
        public enum FactorType
        {
            Currency,
            EventCode
        }
        #endregion

        #region Properties
        private Guid paymentFactorId = System.Guid.Empty;
        public Guid PaymentFactorId
        {
            get
            {
                return paymentFactorId;
            }
            set
            {
                paymentFactorId = value;
            }
        }

        private FactorType factorType = FactorType.Currency;
        public FactorType PaymentFactorType
        {
            get
            {
                return factorType;
            }
            set
            {
                factorType = value;
            }
        }
        #endregion

        #region Controls
        private void ControlChanging()
        {
            switch (this.PaymentFactorType)
            {
                case FactorType.Currency:
                    lblCurrency.Visible = true;
                    cboCurrency.Visible = true;

                    lblEventCode.Visible = false;
                    cboEventCode.Visible = false;

                    colCurrencyAndEventCode.Text = "Currency";
                    break;
                case FactorType.EventCode:
                    lblCurrency.Visible = false;
                    cboCurrency.Visible = false;

                    lblEventCode.Visible = true;
                    cboEventCode.Visible = true;
                    lblEventCode.Location = lblCurrency.Location;
                    cboEventCode.Location = cboCurrency.Location;

                    colCurrencyAndEventCode.Text = "Event Code";
                    break;
            }
        }
        #endregion

        #region ToolBar
        private void SetCtrlEditable()
        {
        }

        private void SetToolBar()
        {
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

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

            if (PaymentFactorId == System.Guid.Empty)
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
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveConfirmationHandler));
                        break;
                    case "refresh":
                        BindPaymentFactorList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }

        private void Clear()
        {
            this.Close();

            PaymentFactor wizPF = new PaymentFactor(this.PaymentFactorType);
            wizPF.ShowDialog();
        }
        #endregion

        #region Binding list
        private void BindPaymentFactorList()
        {
            int iCount = 1;
            string sql = @"
SELECT     PaymentFactorId, WorkplaceId, WorkplaceCode, CurrencyCode, EventCode, 
            StartOn, EndOn, FactorRate, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy
FROM        vwPaymentFactorList";

            if (this.PaymentFactorType == FactorType.Currency)
            {
                sql += " WHERE CurrencyCode IS NOT NULL AND CurrencyCode <> ''"; // Currency
            }
            else if (this.PaymentFactorType == FactorType.EventCode)
            {
                sql += " WHERE EventCode IS NOT NULL AND EventCode <> ''"; // Event Code
            }

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem listItem = lvPaymentFactor.Items.Add(reader.GetGuid(0).ToString());
                    listItem.SubItems.Add(reader.GetGuid(1).ToString());
                    listItem.SubItems.Add(iCount.ToString());
                    listItem.SubItems.Add(reader.GetString(2)); // Workplace

                    if (this.PaymentFactorType == FactorType.Currency)
                    {
                        listItem.SubItems.Add(reader.GetString(3)); // Currency
                    }
                    else if (this.PaymentFactorType == FactorType.EventCode)
                    {
                        listItem.SubItems.Add(reader.GetString(4)); // Event Code
                    }

                    listItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(5), false)); // Start date
                    listItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(6), false)); // End date
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n" + RT2020.SystemInfo.Settings.GetQtyDecimalPoint().ToString())); // Factor rate
                    listItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(8), true)); // Created On
                    listItem.SubItems.Add(RT2020.SystemInfo.Settings.DateTimeToString(reader.GetDateTime(10), true)); // Modified On

                    iCount++;
                }
            }
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillWorkplaceList();
            FillCurrencyList();
            FillEventCodeList();
        }

        private void FillWorkplaceList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboWorkplace, "WorkplaceCode", false);
        }

        private void FillCurrencyList()
        {
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false);
        }

        private void FillEventCodeList()
        {
            cboEventCode.DataSource = null;
            cboEventCode.Items.Clear();

            string sql = "SELECT DISTINCT EventCode FROM PromotionPaymentFactor ORDER BY EventCode";
            
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    cboEventCode.Items.Add(reader.GetString(0));
                }
            }
        }
        #endregion

        #region Save Methods
        private bool IsDuplicated()
        {
            string duplicatedMsg = Resources.Common.DuplicatedCode;

            string sql = "WorkplaceId = '" + cboWorkplace.SelectedValue.ToString() + "' AND {0} AND CONVERT(NVARCHAR(10), StartOn, 103) = '" + dtpStartDate.Value.ToString("dd/MM/yyyy") + "' AND CONVERT(NVARCHAR(10), EndOn, 103) = '" + dtpEndDate.Value.ToString("dd/MM/yyyy") + "'";

            if (this.PaymentFactorType == FactorType.Currency)
            {
                sql = string.Format(sql, "CurrencyCode = '" + cboCurrency.Text + "'");
                duplicatedMsg = string.Format(duplicatedMsg, "Workplace + Currency + Data Range");
            }

            if (this.PaymentFactorType == FactorType.EventCode)
            {
                sql = string.Format(sql, "EventCode = '" + cboEventCode.Text + "'");
                duplicatedMsg = string.Format(duplicatedMsg, "Workplace + Event Code + Data Range");
            }

            PromotionPaymentFactorCollection factorList = PromotionPaymentFactor.LoadCollection(sql);
            if (factorList.Count > 0)
            {
                errorProvider.SetError(cboWorkplace, duplicatedMsg);
                errorProvider.SetError(cboCurrency, duplicatedMsg);
                errorProvider.SetError(cboEventCode, duplicatedMsg);
                errorProvider.SetError(dtpStartDate, duplicatedMsg);
                errorProvider.SetError(dtpEndDate, duplicatedMsg);

                return true;
            }
            else
            {
                errorProvider.SetError(cboWorkplace, string.Empty);
                errorProvider.SetError(cboCurrency, string.Empty);
                errorProvider.SetError(cboEventCode, string.Empty);
                errorProvider.SetError(dtpStartDate, string.Empty);
                errorProvider.SetError(dtpEndDate, string.Empty);

                return false;
            }
        }

        private bool Verify()
        {
            if (cboWorkplace.SelectedValue == null)
            {
                errorProvider.SetError(cboWorkplace, "Can not null");
                return false;
            }
            else if (cboCurrency.SelectedValue == null && this.PaymentFactorType == FactorType.Currency)
            {
                errorProvider.SetError(cboCurrency, "Can not null");
                return false;
            }
            else if (cboEventCode.Text.Length == 0 && this.PaymentFactorType == FactorType.EventCode)
            {
                errorProvider.SetError(cboEventCode, "Can not null");
                return false;
            }
            else
            {
                errorProvider.SetError(cboEventCode, string.Empty);
                errorProvider.SetError(cboWorkplace, string.Empty);
                errorProvider.SetError(cboCurrency, string.Empty);
                return true;
            }
        }

        private bool Save()
        {
            if (Verify())
            {
                PromotionPaymentFactor oFactor = PromotionPaymentFactor.Load(this.PaymentFactorId);
                if (oFactor == null)
                {
                    oFactor = new PromotionPaymentFactor();
                    oFactor.CreatedBy = Common.Config.CurrentUserId;
                    oFactor.CreatedOn = DateTime.Now;

                    if (IsDuplicated())
                    {
                        return false;
                    }
                }
                oFactor.WorkplaceId = (cboWorkplace.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboWorkplace.SelectedValue.ToString());

                if (this.PaymentFactorType == FactorType.Currency)
                {
                    oFactor.CurrencyCode = cboCurrency.Text;
                }

                if (this.PaymentFactorType == FactorType.EventCode)
                {
                    oFactor.EventCode = cboEventCode.Text;
                }

                oFactor.FactorRate = (txtFactorRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtFactorRate.Text);
                oFactor.StartOn = dtpStartDate.Value;
                oFactor.EndOn = dtpEndDate.Value;

                oFactor.ModifiedBy = Common.Config.CurrentUserId;
                oFactor.ModifiedOn = DateTime.Now;
                oFactor.Retired = false;

                oFactor.Save();
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region Load Methods
        private void LoadPaymentFactor()
        {
            PromotionPaymentFactor oFactor = PromotionPaymentFactor.Load(this.PaymentFactorId);
            if (oFactor != null)
            {
                cboWorkplace.SelectedValue = oFactor.WorkplaceId;

                if (this.PaymentFactorType == FactorType.Currency)
                {
                    cboCurrency.Text = oFactor.CurrencyCode;
                }

                if (this.PaymentFactorType == FactorType.EventCode)
                {
                    cboEventCode.Text = oFactor.EventCode;
                }

                txtFactorRate.Text = oFactor.FactorRate.ToString("n2");
                dtpStartDate.Value = oFactor.StartOn;
                dtpEndDate.Value = oFactor.EndOn;

                txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oFactor.CreatedOn, false);
                txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(oFactor.ModifiedBy);
                txtLastUpdatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oFactor.ModifiedOn, false);
            }
        }

        #endregion

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            PromotionPaymentFactor factor = PromotionPaymentFactor.Load(this.PaymentFactorId);
            if (factor != null)
            {
                factor.Retired = true;
                factor.RetiredBy = Common.Config.CurrentUserId;
                factor.RetiredOn = DateTime.Now;

                factor.Save();

                MessageBox.Show("Delete Successfully!", "Delete Result");
                Clear();
            }
        }

        private void SaveConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    this.Clear();
                }
            }
        }

        private void lvPaymentFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPaymentFactor.SelectedItem != null)
            {
                ListViewItem listItem = lvPaymentFactor.SelectedItem;
                this.PaymentFactorId = Common.Utility.IsGUID(listItem.Text) ? new Guid(listItem.Text.Trim()) : System.Guid.Empty;
                LoadPaymentFactor();
                SetToolBar();
            }
        }
    }
}