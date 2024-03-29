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

namespace RT2020.Supplier
{
    public partial class SupplierWizard : Form
    {
        #region Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _SupplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get { return _SupplierId; }
            set { _SupplierId = value; }
        }

        private string _SupplierCode = string.Empty;
        public string SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        #endregion

        #region declare index tab pages
        bool tabGeneralLoaded = false, tabAddressLoaded = false, tabContactLoaded = false, tabFinancialLoaded = false;

        SupplierWizard_General general = null;
        SupplierWizard_Address address = null;
        SupplierWizard_Contact contact = null;
        SupplierWizard_Finance finance = null;
        #endregion

        public SupplierWizard()
        {
            InitializeComponent();
        }

        private void SupplierWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetToolBar();
            LoadTabPage();

            SetCtrlEditable();

            //tabContact.Visible = false;

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadSupplierInfo();
                    break;
            }
        }

        #region SetCaptions, SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("supplier.setup", "Model");
            lblSupplierNumber.Text = WestwindHelper.GetWordWithColon("supplier.number", "Model");

            tabGeneral.Text = WestwindHelper.GetWord("supplier.general", "Model");
            tabAddress.Text = WestwindHelper.GetWord("supplier.address", "Model");
            tabContact.Text = WestwindHelper.GetWord("supplier.contact", "Model");
            tabFinance.Text = WestwindHelper.GetWord("supplier.finance", "Model");
        }

        private void SetAttributes()
        {
        }
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", WestwindHelper.GetWord("edit.save.new", "General"));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", WestwindHelper.GetWord("edit.save.close", "General"));
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_SupplierId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
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
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        break;
                    case "save & new":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Supplier Code
        private void SetCtrlEditable()
        {
            txtSupplierCode.BackColor = (_SupplierId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtSupplierCode.ReadOnly = (_SupplierId != Guid.Empty);
        }
        #endregion

        #region Save Methods

        private bool Verify()
        {
            var result = true;
            errorProvider.SetError(txtSupplierCode, string.Empty);

            decimal numeric = 0;
            if (txtSupplierCode.Text == string.Empty)
            {
                errorProvider.SetError(txtSupplierCode, "Can not be blank!");
                tabGeneral.Select();
                return false;
            }
            if (tabFinancialLoaded)
            {
                #region verify tabFinance
                errorProvider.SetError(finance.txtCreditLimit, string.Empty);
                errorProvider.SetError(finance.txtNormalDiscount, string.Empty);
                errorProvider.SetError(finance.txtWholesalesDiscount, string.Empty);
                errorProvider.SetError(finance.txtQuotaDiscount, string.Empty);
                errorProvider.SetError(finance.txtYearEndBonus, string.Empty);
                errorProvider.SetError(finance.txtCashDiscount, string.Empty);
                errorProvider.SetError(finance.txtOthersDiscount, string.Empty);

                if (!decimal.TryParse(finance.txtCreditLimit.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtCreditLimit, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                if (!decimal.TryParse(finance.txtNormalDiscount.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtNormalDiscount, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                if (!decimal.TryParse(finance.txtWholesalesDiscount.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtWholesalesDiscount, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                if (!decimal.TryParse(finance.txtQuotaDiscount.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtQuotaDiscount, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                if (!decimal.TryParse(finance.txtYearEndBonus.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtYearEndBonus, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                if (!decimal.TryParse(finance.txtCashDiscount.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtCashDiscount, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                if (!decimal.TryParse(finance.txtOthersDiscount.Text.Replace(",", ""), out numeric))
                {
                    errorProvider.SetError(finance.txtOthersDiscount, Resources.Common.DigitalNeeded);
                    tabFinance.Select();
                    return false;
                }
                #endregion
            }
            return result;
        }

        private bool IsValid()
        {
            bool result = true;

            #region Supplier Code 唔可以吉
            errorProvider.SetError(txtSupplierCode, string.Empty);
            if (txtSupplierCode.Text.Length == 0)
            {
                errorProvider.SetError(txtSupplierCode, "Cannot be blank!");
                errorProvider.SetIconAlignment(txtSupplierCode, ErrorIconAlignment.TopLeft);
                return false;
            }
            #endregion

            #region 新增，要 check Supplier Code 係咪 in use
            errorProvider.SetError(txtSupplierCode, string.Empty);
            if (_SupplierId == Guid.Empty)
            {
                if (SupplierEx.IsSupplierCodeInUse(txtSupplierCode.Text.Trim()))
                {
                    errorProvider.SetError(txtSupplierCode, "Supplier Code in use");
                    errorProvider.SetIconAlignment(txtSupplierCode, ErrorIconAlignment.TopLeft);
                    return false;
                }
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            var result = false;

            if (Verify() && IsValid())
            {
                bool canSave = false, isNew = false;

                using (var ctx = new EF6.RT2020Entities())
                {
                    var item = ctx.Supplier.Find(_SupplierId);
                    if (item == null)
                    {
                        item = new EF6.Supplier();
                        item.SupplierId = Guid.NewGuid();
                        item.SupplierCode = txtSupplierCode.Text.Trim();

                        item.Status = (int)EnumHelper.Status.Active;         //2014.01.04 paulus: 一開始就係 Active
                        item.CreatedBy = ConfigHelper.CurrentUserId;
                        item.CreatedOn = DateTime.Now;

                        ctx.Supplier.Add(item);
                        _SupplierId = item.SupplierId;
                        _SupplierCode = item.SupplierCode;
                    }
                    //item.SupplierInitial = general.txtInitial.Text;
                    //item.SupplierName = general.txtName.Text;
                    //item.SupplierName_Chs = general.txtNameChs.Text;
                    //item.SupplierName_Cht = general.txtNameCht.Text;
                    //item.AlternateSupplier = general.txtSmartTag1.Text;
                    //item.MarketSectorId = new Guid(general.cboMarketSector.SelectedValue.ToString());
                    //item.Remarks = general.txtRemarks.Text;

                    item.Status = ctx.Entry(item).State == EntityState.Added ?
                         (int)EnumHelper.Status.Active : (int)EnumHelper.Status.Modified;

                    item.ModifiedBy = ConfigHelper.CurrentUserId;
                    item.ModifiedOn = DateTime.Now;

                    ctx.SaveChanges();

                    //SaveSmartTagValue(_SupplierId);

                    result = true;
                }

                #region general.SaveGeneralData
                if (tabGeneralLoaded)
                {
                    if (_EditMode == EnumHelper.EditMode.Add)
                    {
                        general.SupplierId = _SupplierId;
                        general.SupplierCode = _SupplierCode;
                    }
//                    result = general.SaveGeneralData();
                }
                #endregion
                #region address.SaveAddressData
                if (tabAddressLoaded && result)
                {
                    if (_EditMode == EnumHelper.EditMode.Add) address.SupplierId = _SupplierId;
                        result = address.SaveAddressData();
                }
                #endregion
                #region contact.SaveContctData
                if (tabContactLoaded && result)
                {
                    if (_EditMode == EnumHelper.EditMode.Add) contact.SupplierId = _SupplierId;
                    result = contact.SaveContctData();
                }
                #endregion
                #region finance.SaveFinanceData
                if (tabFinancialLoaded && result)
                {
                    if (_EditMode == EnumHelper.EditMode.Add) finance.SupplierId = _SupplierId;
                    result = finance.SaveFinanceData();
                }
                #endregion

                return result;
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Load Tab Pages
        private void LoadTabPage(int idx = 0)
        {
            switch (idx)
            {
                case 0:
                    #region Tab Page: General
                    if (!tabGeneralLoaded)
                    {
                        general = new SupplierWizard_General();
                        general.Dock = DockStyle.Fill;
                        general.EditMode = _EditMode;
                        general.SupplierId = _SupplierId;
                        tabGeneral.Controls.Add(general);

                        general.LoadGeneralData();
                        tabGeneralLoaded = true;
                    }
                    break;
                    #endregion
                case 1:
                    #region Tab Page: Personal
                    if (!tabAddressLoaded)
                    {
                        address = new SupplierWizard_Address();
                        address.Dock = DockStyle.Fill;
                        address.EditMode = _EditMode;
                        address.SupplierId = _SupplierId;
                        tabAddress.Controls.Add(address);

                        address.LoadAddressData();
                        tabAddressLoaded = true;
                    }
                    break;
                    #endregion
                case 2:
                    #region Tab Page: Contact
                    if (!tabContactLoaded)
                    {
                        contact = new SupplierWizard_Contact();
                        contact.Dock = DockStyle.Fill;
                        contact.EditMode = _EditMode;
                        contact.SupplierId = _SupplierId;
                        tabContact.Controls.Add(contact);

                        contact.LoadContactData();
                        tabContactLoaded = true;
                    }
                    break;
                    #endregion
                case 3:
                    #region Tab Page: Financial
                    if (!tabFinancialLoaded)
                    {
                        finance = new SupplierWizard_Finance();
                        finance.Dock = DockStyle.Fill;
                        finance.EditMode = _EditMode;
                        finance.SupplierId = _SupplierId;
                        tabFinance.Controls.Add(finance);

                        finance.LoadFinanceData();
                        tabFinancialLoaded = true;
                    }
                    break;
                    #endregion
            }
        }

        private void LoadSupplierInfo()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oSupplier = ctx.Supplier.Find(_SupplierId);
                if (oSupplier != null)
                {
                    txtSupplierCode.Text = oSupplier.SupplierCode;
                }
            }
        }

        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oSupplier = ctx.Supplier.Find(_SupplierId);
                if (oSupplier == null)
                {
                    switch ((int)oSupplier.Status)
                    {
                        case (int)EnumHelper.Status.Active:       //2014.01.04 paulus: 如果 Supplier.Status = Active 設為 Deleted + Retired
                            oSupplier.Status = Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d"));
                            oSupplier.Retired = true;
                            oSupplier.RetiredOn = DateTime.Now;
                            oSupplier.RetiredBy = ConfigHelper.CurrentUserId;
                            break;
                        case (int)EnumHelper.Status.Draft:        //2014.01.04 paulus: 如果 Supplier.Status = Draft 可以直接刪除
                            string sql = "SupplierId = '" + oSupplier.SupplierId.ToString() + "'";

                            SupplierSmartTagEx.Delete(oSupplier.SupplierId);
                            SupplierContactEx.Delete(oSupplier.SupplierId);
                            SupplierAddressEx.Delete(oSupplier.SupplierId);

                            ctx.Supplier.Remove(oSupplier);
                            break;
                    }
                    ctx.SaveChanges();
                }
            }
        }
        #endregion

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    if (_SupplierId != Guid.Empty)
                    {
                        Helper.DesktopHelper.RefreshMainList<SupplierList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        SupplierWizard wizard = new SupplierWizard();
                        wizard.EditMode = EnumHelper.EditMode.Edit;
                        wizard.SupplierId = _SupplierId;
                        wizard.ShowDialog();
                    }
                }
            }
        }

        private void tabSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tabSupplier.SelectedTab.Name;
            LoadTabPage(tabSupplier.SelectedIndex);
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    if (this.SupplierId != Guid.Empty)
                    {
                        Helper.DesktopHelper.RefreshMainList<SupplierList>();
                        this.Close();

                        SupplierWizard wizard = new SupplierWizard();
                        wizard.EditMode = EnumHelper.EditMode.Add;
                        wizard.ShowDialog();
                    }
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    if (this.SupplierId != Guid.Empty)
                    {
                        Helper.DesktopHelper.RefreshMainList<SupplierList>();
                        this.Close();
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                this.Close();
            }
        }
    }
}