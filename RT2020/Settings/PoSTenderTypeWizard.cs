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
    public partial class PosTenderTypeWizard : Form
    {
        public PosTenderTypeWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillCurrencyList();
            BindPosTenderTypeList();
            SetCtrlEditable();
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

            if (PosTenderTypeId == System.Guid.Empty)
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
                            BindPosTenderTypeList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindPosTenderTypeList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region PosTenderType Code
        private void SetCtrlEditable()
        {
            txtPosTenderTypeCode.BackColor = (this.PosTenderTypeId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtPosTenderTypeCode.ReadOnly = (this.PosTenderTypeId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtPosTenderTypeCode, string.Empty);
            errorProvider.SetError(txtExchangeRate, string.Empty);
            errorProvider.SetError(txtChargeRate, string.Empty);
            errorProvider.SetError(txtChargeAmount, string.Empty);
            errorProvider.SetError(txtAdditionalMonthlyCharge, string.Empty);
            errorProvider.SetError(txtMinimumMonthlyCharge, string.Empty);
        }
        #endregion

        #region Binding
        private void BindPosTenderTypeList()
        {
            this.lvPosTenderTypeList.ListViewItemSorter = new ListViewItemSorter(lvPosTenderTypeList);
            this.lvPosTenderTypeList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT TypeId,  ROW_NUMBER() OVER (ORDER BY TypeCode) AS rownum, ");
            sql.Append(" TypeCode, TypeName, TypeName_Chs, TypeName_Cht ");
            sql.Append(" FROM PosTenderType ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvPosTenderTypeList.Items.Add(reader.GetGuid(0).ToString()); // PosTenderTypeId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // PosTenderTypeCode
                    objItem.SubItems.Add(reader.GetString(3)); // PosTenderType Name
                    objItem.SubItems.Add(reader.GetString(4)); // PosTenderType Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // PosTenderType Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Fill Currency List
        private void FillCurrencyList()
        {
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false);
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "TypeCode = '" + txtPosTenderTypeCode.Text.Trim() + "'";
            PosTenderTypeCollection typeList = PosTenderType.LoadCollection(sql);
            if (typeList.Count > 0)
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
            if (txtPosTenderTypeCode.Text.Length == 0)
            {
                errorProvider.SetError(txtPosTenderTypeCode, "Cannot be blank!");
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtExchangeRate.Text))
            {
                errorProvider.SetError(txtExchangeRate, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtChargeRate.Text))
            {
                errorProvider.SetError(txtChargeRate, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtChargeAmount.Text))
            {
                errorProvider.SetError(txtChargeAmount, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtAdditionalMonthlyCharge.Text))
            {
                errorProvider.SetError(txtAdditionalMonthlyCharge, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtMinimumMonthlyCharge.Text))
            {
                errorProvider.SetError(txtMinimumMonthlyCharge, Resources.Common.DigitalNeeded);
                return false;
            }
            else
            {
                errorProvider.SetError(txtPosTenderTypeCode, string.Empty);
                errorProvider.SetError(txtExchangeRate, string.Empty);
                errorProvider.SetError(txtChargeRate, string.Empty);
                errorProvider.SetError(txtChargeAmount, string.Empty);
                errorProvider.SetError(txtAdditionalMonthlyCharge, string.Empty);
                errorProvider.SetError(txtMinimumMonthlyCharge, string.Empty);

                PosTenderType oPosTenderType = PosTenderType.Load(this.PosTenderTypeId);
                if (oPosTenderType == null)
                {
                    oPosTenderType = new PosTenderType();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtPosTenderTypeCode, string.Format(Resources.Common.DuplicatedCode, "PoS Tender Type Code"));
                        return false;
                    }
                    else
                    {
                        oPosTenderType.TypeCode = txtPosTenderTypeCode.Text;
                        oPosTenderType.CreatedBy = Common.Config.CurrentUserId;
                        oPosTenderType.CreatedOn = DateTime.Now;
                        errorProvider.SetError(txtPosTenderTypeCode, string.Empty);
                    }
                }
                oPosTenderType.TypeName = txtPosTenderTypeName.Text;
                oPosTenderType.TypeName_Chs = txtPosTenderTypeNameChs.Text;
                oPosTenderType.TypeName_Cht = txtPosTenderTypeNameCht.Text;

                oPosTenderType.CurrencyCode = cboCurrency.Text;
                oPosTenderType.ExchangeRate = (txtExchangeRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtExchangeRate.Text);
                oPosTenderType.DownloadToPOS = chkDownloadToPoS.Checked;
                oPosTenderType.ChargeRate = (txtChargeRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtChargeRate.Text);
                oPosTenderType.ChargeAmount = (txtChargeAmount.Text.Length == 0) ? 0 : Convert.ToDecimal(txtChargeAmount.Text);
                oPosTenderType.AdditionalMonthlyCharge = (txtAdditionalMonthlyCharge.Text.Length == 0) ? 0 : Convert.ToDecimal(txtAdditionalMonthlyCharge.Text);
                oPosTenderType.MinimumMonthlyCharge = (txtMinimumMonthlyCharge.Text.Length == 0) ? 0 : Convert.ToDecimal(txtMinimumMonthlyCharge.Text);

                oPosTenderType.ModifiedBy = Common.Config.CurrentUserId;
                oPosTenderType.ModifiedOn = DateTime.Now;

                oPosTenderType.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            PosTenderTypeWizard wizType = new PosTenderTypeWizard();
            wizType.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid PosTenderTypeId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
            }
        }
        #endregion

        private void Delete()
        {
            PosTenderType oPosTenderType = PosTenderType.Load(this.PosTenderTypeId);
            if (oPosTenderType != null)
            {
                try
                {
                    oPosTenderType.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvPosTenderTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPosTenderTypeList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvPosTenderTypeList.SelectedItem.Text))
                {
                    PosTenderType oPosTenderType = PosTenderType.Load(new System.Guid(lvPosTenderTypeList.SelectedItem.Text));
                    if (oPosTenderType != null)
                    {
                        txtPosTenderTypeCode.Text = oPosTenderType.TypeCode;
                        txtPosTenderTypeName.Text = oPosTenderType.TypeName;
                        txtPosTenderTypeNameChs.Text = oPosTenderType.TypeName_Chs;
                        txtPosTenderTypeNameCht.Text = oPosTenderType.TypeName_Cht;
                        cboCurrency.Text = oPosTenderType.CurrencyCode;
                        txtExchangeRate.Text = oPosTenderType.ExchangeRate.ToString("n4");
                        chkDownloadToPoS.Checked = true;
                        txtChargeRate.Text = oPosTenderType.ChargeRate.ToString("n2");
                        txtChargeAmount.Text = oPosTenderType.ChargeAmount.ToString("n2");
                        txtAdditionalMonthlyCharge.Text = oPosTenderType.AdditionalMonthlyCharge.ToString("n2");
                        txtMinimumMonthlyCharge.Text = oPosTenderType.MinimumMonthlyCharge.ToString("n2");

                        this.PosTenderTypeId = oPosTenderType.TypeId;

                        SetCtrlEditable();
                        SetToolBar();
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindPosTenderTypeList();
                Clear();
                SetCtrlEditable();
            }
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Guid.Empty;
            if (Guid.TryParse(cboCurrency.SelectedValue.ToString(), out id))
            {
                txtExchangeRate.Text = ModelEx.CurrencyEx.GetExchangeRateById(id).ToString("n4");
            }
        }
    }
}