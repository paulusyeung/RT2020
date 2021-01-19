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

#endregion

namespace RT2020.Settings
{
    public partial class PosTenderTypeWizard : Form
    {
        #region Properties
        private Guid _TenderTypeId = System.Guid.Empty;
        public Guid PosTenderTypeId
        {
            get { return _TenderTypeId; }
            set { _TenderTypeId = value; }
        }
        #endregion

        public PosTenderTypeWizard()
        {
            InitializeComponent();
        }

        private void PosTenderTypeWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillCurrencyList();
            BindPosTenderTypeList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("posTenderType.setup", "Model");

            lblTypeCode.Text = WestwindHelper.GetWordWithColon("posTenderType.code", "Model");
            lblTypeName.Text = WestwindHelper.GetWordWithColon("posTenderType.name", "Model");
            lblTypeNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblTypeNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblPriority.Text = WestwindHelper.GetWordWithColon("posTenderType.priority", "Model");
            lblCurrency.Text = WestwindHelper.GetWordWithColon("currency", "Model");
            lblExchangeRate.Text = WestwindHelper.GetWordWithColon("posTenderType.exchangeRate", "Model");
            lblDownloadToPoS.Text = WestwindHelper.GetWordWithColon("posTenderType.downloadToPos", "Model");
            lblChargeRate.Text = WestwindHelper.GetWordWithColon("posTenderType.chargeRate", "Model");
            lblChargeAmount.Text = WestwindHelper.GetWordWithColon("posTenderType.chargeAmount", "Model");
            lblMonthly.Text = WestwindHelper.GetWordWithColon("posTenderType.monthly", "Model");
            lblAdditionalMonthlyCharge.Text = WestwindHelper.GetWordWithColon("posTenderType.additionalCharge", "Model");
            lblMinimumMonthlyCharge.Text = WestwindHelper.GetWordWithColon("posTenderType.minimumCharge", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colTypeCode.Text = WestwindHelper.GetWord("posTenderType.code", "Model");
            colTypeName.Text = WestwindHelper.GetWord("posTenderType.name", "Model");
            colTypeNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colTypeNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
        }

        private void SetAttributes()
        {
            #region ListView Column Style
            lvPosTenderTypeList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colParentDept.TextAlign = HorizontalAlignment.Left;
            //colParentDept.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTypeCode.TextAlign = HorizontalAlignment.Left;
            colTypeCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTypeName.TextAlign = HorizontalAlignment.Left;
            colTypeName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTypeNameAlt1.TextAlign = HorizontalAlignment.Left;
            colTypeNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTypeNameAlt2.TextAlign = HorizontalAlignment.Left;
            colTypeNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;
            #endregion

            #region show/ hide alt1 alt2
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblTypeNameAlt2.Visible = txtTypeNameAlt2.Visible = false;
                    colTypeNameAlt2.Visible = false;
                    // push parent dept. up
                    //lblProvince.Location = new Point(lblProvince.Location.X, lblCityNameAlt1.Location.Y);
                    //cboProvince.Location = new Point(cboProvince.Location.X, txtCityNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblTypeNameAlt1.Visible = lblTypeNameAlt2.Visible = txtTypeNameAlt1.Visible = txtTypeNameAlt2.Visible = false;
                    colTypeNameAlt1.Visible = colTypeNameAlt2.Visible = false;
                    // push parent dept up
                    //lblProvince.Location = new Point(lblProvince.Location.X, lblCityNameAlt1.Location.Y);
                    //cboProvince.Location = new Point(cboProvince.Location.X, txtCityNameAlt1.Location.Y);
                    break;
            }
            #endregion

            #region 設定 clickable Currency label
            lblCurrency.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblCurrency.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblCurrency.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.CurrencyWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCurrencyList();
                };
                dialog.ShowDialog();
            };
            #endregion
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

            if (_TenderTypeId == Guid.Empty)
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
                        if (Save())
                        {
                            ClearForm();
                            BindPosTenderTypeList();
                        }
                        break;
                    case "refresh":
                        ClearForm();
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
            txtTypeCode.BackColor = (_TenderTypeId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtTypeCode.ReadOnly = (_TenderTypeId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtTypeCode, string.Empty);
            errorProvider.SetError(txtExchangeRate, string.Empty);
            errorProvider.SetError(txtChargeRate, string.Empty);
            errorProvider.SetError(txtChargeAmount, string.Empty);
            errorProvider.SetError(txtAdditionalMonthlyCharge, string.Empty);
            errorProvider.SetError(txtMinimumMonthlyCharge, string.Empty);
        }

        private void ClearForm()
        {
            txtTypeCode.Text = txtTypeName.Text = txtTypeNameAlt1.Text = txtTypeNameAlt2.Text = txtPriority.Text = string.Empty;
            txtExchangeRate.Text = txtChargeRate.Text = txtChargeAmount.Text = txtAdditionalMonthlyCharge.Text = txtMinimumMonthlyCharge.Text = string.Empty;
            chkDownloadToPoS.Checked = false;

            _TenderTypeId = Guid.Empty;

            FillCurrencyList();
            SetCtrlEditable();
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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false, true, "", "");
        }
        #endregion

        #region Save
        
        private bool Save()
        {
            decimal numeric = 0;
            if (txtTypeCode.Text.Length == 0)
            {
                errorProvider.SetError(txtTypeCode, "Cannot be blank!");
                return false;
            }
            else if (!decimal.TryParse(txtExchangeRate.Text, out numeric))
            {
                errorProvider.SetError(txtExchangeRate, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!decimal.TryParse(txtChargeRate.Text, out numeric))
            {
                errorProvider.SetError(txtChargeRate, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!decimal.TryParse(txtChargeAmount.Text, out numeric))
            {
                errorProvider.SetError(txtChargeAmount, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!decimal.TryParse(txtAdditionalMonthlyCharge.Text, out numeric))
            {
                errorProvider.SetError(txtAdditionalMonthlyCharge, Resources.Common.DigitalNeeded);
                return false;
            }
            else if (!decimal.TryParse(txtMinimumMonthlyCharge.Text, out numeric))
            {
                errorProvider.SetError(txtMinimumMonthlyCharge, Resources.Common.DigitalNeeded);
                return false;
            }
            else
            {
                errorProvider.SetError(txtTypeCode, string.Empty);
                errorProvider.SetError(txtExchangeRate, string.Empty);
                errorProvider.SetError(txtChargeRate, string.Empty);
                errorProvider.SetError(txtChargeAmount, string.Empty);
                errorProvider.SetError(txtAdditionalMonthlyCharge, string.Empty);
                errorProvider.SetError(txtMinimumMonthlyCharge, string.Empty);

                using (var ctx = new EF6.RT2020Entities())
                {
                    var oPosTenderType = ctx.PosTenderType.Find(_TenderTypeId);
                    if (oPosTenderType == null)
                    {
                        oPosTenderType = new EF6.PosTenderType();
                        oPosTenderType.TypeId = Guid.NewGuid();
                        if (ModelEx.PosTenderTypeEx.IsTypeCodeInUse(txtTypeCode.Text.Trim()))
                        {
                            errorProvider.SetError(txtTypeCode, string.Format(Resources.Common.DuplicatedCode, "PoS Tender Type Code"));
                            return false;
                        }
                        else
                        {
                            oPosTenderType.TypeCode = txtTypeCode.Text;
                            oPosTenderType.CreatedBy = ConfigHelper.CurrentUserId;
                            oPosTenderType.CreatedOn = DateTime.Now;
                            errorProvider.SetError(txtTypeCode, string.Empty);
                        }
                        ctx.PosTenderType.Add(oPosTenderType);
                    }
                    oPosTenderType.TypeName = txtTypeName.Text;
                    oPosTenderType.TypeName_Chs = txtTypeNameAlt1.Text;
                    oPosTenderType.TypeName_Cht = txtTypeNameAlt2.Text;

                    oPosTenderType.CurrencyCode = cboCurrency.Text;
                    oPosTenderType.ExchangeRate = (txtExchangeRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtExchangeRate.Text);
                    oPosTenderType.DownloadToPOS = chkDownloadToPoS.Checked;
                    oPosTenderType.ChargeRate = (txtChargeRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtChargeRate.Text);
                    oPosTenderType.ChargeAmount = (txtChargeAmount.Text.Length == 0) ? 0 : Convert.ToDecimal(txtChargeAmount.Text);
                    oPosTenderType.AdditionalMonthlyCharge = (txtAdditionalMonthlyCharge.Text.Length == 0) ? 0 : Convert.ToDecimal(txtAdditionalMonthlyCharge.Text);
                    oPosTenderType.MinimumMonthlyCharge = (txtMinimumMonthlyCharge.Text.Length == 0) ? 0 : Convert.ToDecimal(txtMinimumMonthlyCharge.Text);

                    oPosTenderType.ModifiedBy = ConfigHelper.CurrentUserId;
                    oPosTenderType.ModifiedOn = DateTime.Now;

                    ctx.SaveChanges();
                }
                return true;
            }
        }
        #endregion

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oPosTenderType = ctx.PosTenderType.Find(_TenderTypeId);
                if (oPosTenderType != null)
                {
                    try
                    {
                        ctx.PosTenderType.Remove(oPosTenderType);
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                    }
                }
            }
        }

        private void lvPosTenderTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPosTenderTypeList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvPosTenderTypeList.SelectedItem.Text, out id))
                {
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var oPosTenderType = ctx.PosTenderType.Find(id);
                        if (oPosTenderType != null)
                        {
                            txtTypeCode.Text = oPosTenderType.TypeCode;
                            txtTypeName.Text = oPosTenderType.TypeName;
                            txtTypeNameAlt1.Text = oPosTenderType.TypeName_Chs;
                            txtTypeNameAlt2.Text = oPosTenderType.TypeName_Cht;
                            cboCurrency.SelectedValue = ModelEx.CurrencyEx.GetCurrencyIdByCode(oPosTenderType.CurrencyCode);
                            txtExchangeRate.Text = oPosTenderType.ExchangeRate.Value.ToString("n4");
                            chkDownloadToPoS.Checked = true;
                            txtChargeRate.Text = oPosTenderType.ChargeRate.ToString("n2");
                            txtChargeAmount.Text = oPosTenderType.ChargeAmount.ToString("n2");
                            txtAdditionalMonthlyCharge.Text = oPosTenderType.AdditionalMonthlyCharge.ToString("n2");
                            txtMinimumMonthlyCharge.Text = oPosTenderType.MinimumMonthlyCharge.ToString("n2");

                            _TenderTypeId = oPosTenderType.TypeId;

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

                BindPosTenderTypeList();
                ClearForm();
                SetCtrlEditable();
            }
        }

        private void cboCurrency_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = Guid.Empty;
            if (cboCurrency.SelectedValue != null)
            {
                if (Guid.TryParse(cboCurrency.SelectedValue.ToString(), out id))
                {
                    if (id != Guid.Empty)
                    {
                        txtExchangeRate.Text = ModelEx.CurrencyEx.GetExchangeRateById(id).ToString("n4");
                    }
                }
            }
        }
    }
}