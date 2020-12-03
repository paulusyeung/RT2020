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
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard : Form
    {
        SupplierWizard_General general = null;
        SupplierWizard_Personal personal = null;
        SupplierWizard_Contact contact = null;
        SupplierWizard_Financial financial = null;

        public SupplierWizard()
        {
            InitializeComponent();
            SetToolBar();
            TabCtrl();
            SetCtrlEditable();

            tabContact.Visible = false;
        }

        public SupplierWizard(System.Guid supplierId)
        {
            InitializeComponent();
            this.SupplierId = supplierId;
            SetToolBar();
            TabCtrl();
            SetCtrlEditable();
            LoadSupplierInfo();

            tabContact.Visible = false;
        }

        #region Properties
        private Guid supplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                supplierId = value;
            }
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
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (SupplierId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Delete);
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

        #region Controls

        #region Supplier Code
        private void SetCtrlEditable()
        {
            txtSupplierCode.BackColor = (this.SupplierId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtSupplierCode.ReadOnly = (this.SupplierId != System.Guid.Empty);
        }
        #endregion

        #region Tab
        private void TabCtrl()
        {
            // General
            general = new SupplierWizard_General();
            general.Dock = DockStyle.Fill;
            general.SupplierId = this.SupplierId;
            tabGeneral.Controls.Add(general);

            // Personal
            personal = new SupplierWizard_Personal();
            personal.Dock = DockStyle.Fill;
            personal.SupplierId = this.SupplierId;
            tabPersonal.Controls.Add(personal);

            // Contact
            //contact = new SupplierWizard_Contact();
            //contact.Dock = DockStyle.Fill;
            //contact.SupplierId = this.SupplierId;
            //tabContact.Controls.Add(contact);

            // Financial
            financial = new SupplierWizard_Financial();
            financial.Dock = DockStyle.Fill;
            financial.SupplierId = this.SupplierId;
            tabFinancial.Controls.Add(financial);
        }
        #endregion

        #endregion

        #region Save Methods

        private bool Verify()
        {
            if (txtSupplierCode.Text == string.Empty)
            {
                errorProvider.SetError(txtSupplierCode, "Can not be blank!");
                tabGeneral.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtCreditLimit.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtCreditLimit, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtNormalDiscount.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtNormalDiscount, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtWholesalesDiscount.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtWholesalesDiscount, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtQuotaDiscount.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtQuotaDiscount, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtYearEndBonus.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtYearEndBonus, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtCashDiscount.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtCashDiscount, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else if (!Common.Utility.IsNumeric(financial.txtOthersDiscount.Text.Replace(",", "")))
            {
                errorProvider.SetError(financial.txtOthersDiscount, Resources.Common.DigitalNeeded);
                tabFinancial.Select();
                return false;
            }
            else
            {
                errorProvider.SetError(txtSupplierCode, string.Empty);
                errorProvider.SetError(financial.txtCreditLimit, string.Empty);
                errorProvider.SetError(financial.txtNormalDiscount, string.Empty);
                errorProvider.SetError(financial.txtWholesalesDiscount, string.Empty);
                errorProvider.SetError(financial.txtQuotaDiscount, string.Empty);
                errorProvider.SetError(financial.txtYearEndBonus, string.Empty);
                errorProvider.SetError(financial.txtCashDiscount, string.Empty);
                errorProvider.SetError(financial.txtOthersDiscount, string.Empty);
                return true;
            }
        }

        private bool IsValid()
        {
            bool result = true;

            #region Supplier Code 唔可以吉
            errorProvider.SetError(txtSupplierCode, string.Empty);
            if (txtSupplierCode.Text.Length == 0)
            {
                errorProvider.SetError(txtSupplierCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Supplier Code 係咪 in use
            errorProvider.SetError(txtSupplierCode, string.Empty);
            if (ModelEx.SupplierEx.IsSupplierCodeInUse(txtSupplierCode.Text.Trim()))
            {
                errorProvider.SetError(txtSupplierCode, "Supplier Code in use");
                return false;
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            if (Verify() && IsValid())
            {
                bool canSave = false, isNew = false;

                using (var ctx = new EF6.RT2020Entities())
                {
                    var oSupplier = ctx.Supplier.Find(this.SupplierId);
                    if (oSupplier == null)
                    {
                        oSupplier = new EF6.Supplier();
                        oSupplier.SupplierId = Guid.NewGuid();
                        oSupplier.SupplierCode = txtSupplierCode.Text;

                        oSupplier.Status = (int)Common.Enums.Status.Active;         //2014.01.04 paulus: 一開始就係 Active
                        oSupplier.CreatedBy = Common.Config.CurrentUserId;
                        oSupplier.CreatedOn = DateTime.Now;

                        ctx.Supplier.Add(oSupplier);
                        isNew = true;
                    }
                    oSupplier.SupplierInitial = general.txtInitial.Text;
                    oSupplier.SupplierName = general.txtName.Text;
                    oSupplier.SupplierName_Chs = general.txtNameChs.Text;
                    oSupplier.SupplierName_Cht = general.txtNameCht.Text;
                    oSupplier.AlternateSupplier = general.txtAltSupplierNum.Text;
                    oSupplier.MarketSectorId = new Guid(general.cboMarketSector.SelectedValue.ToString());
                    oSupplier.TermsId = new Guid(financial.cboTerms.SelectedValue.ToString());
                    oSupplier.CreditAmount = Convert.ToDecimal((financial.txtCreditLimit.Text.Length == 0) ? "0" : financial.txtCreditLimit.Text);
                    oSupplier.Remarks = general.txtRemarks.Text;
                    oSupplier.NormalDiscount = Convert.ToDecimal((financial.txtNormalDiscount.Text.Length == 0) ? "0" : financial.txtNormalDiscount.Text);
                    oSupplier.WholesaleDiscount = Convert.ToDecimal((financial.txtWholesalesDiscount.Text.Length == 0) ? "0" : financial.txtWholesalesDiscount.Text);
                    oSupplier.QuotaDiscount = Convert.ToDecimal((financial.txtQuotaDiscount.Text.Length == 0) ? "0" : financial.txtQuotaDiscount.Text);
                    oSupplier.YearEndDiscount = Convert.ToDecimal((financial.txtYearEndBonus.Text.Length == 0) ? "0" : financial.txtYearEndBonus.Text);
                    oSupplier.CashDiscount = Convert.ToDecimal((financial.txtCashDiscount.Text.Length == 0) ? "0" : financial.txtCashDiscount.Text);
                    oSupplier.OtherDiscount = Convert.ToDecimal((financial.txtOthersDiscount.Text.Length == 0) ? "0" : financial.txtOthersDiscount.Text);
                    oSupplier.CurrencyCode = financial.cboCurrency.Text;

                    if (!isNew) oSupplier.Status = Convert.ToInt32(Common.Enums.Status.Modified.ToString("d"));

                    oSupplier.ModifiedBy = Common.Config.CurrentUserId;
                    oSupplier.ModifiedOn = DateTime.Now;

                    ctx.SaveChanges();
                    this.SupplierId = oSupplier.SupplierId;

                    SaveAddress(oSupplier.SupplierId);
                    SaveSmartTagValue(oSupplier.SupplierId);

                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private void SaveAddress(Guid supplierId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var typeId = (Guid)personal.cboAddressType.SelectedValue;
                var item = ctx.SupplierAddress.Where(x => x.SupplierId == this.SupplierId && x.AddressTypeId == typeId).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.SupplierAddress();
                    item.AddressId = Guid.NewGuid();
                    item.SupplierId = supplierId;
                    item.AddressTypeId = (Guid)personal.cboAddressType.SelectedValue;

                    ctx.SupplierAddress.Add(item);
                }
                item.Address = personal.txtAddress.Text;
                item.PostalCode = personal.txtPostalCode.Text;
                if ((Guid)personal.cboCountry.SelectedValue != Guid.Empty) item.CountryId = (Guid)personal.cboCountry.SelectedValue;
                if ((Guid)personal.cboProvince.SelectedValue != Guid.Empty) item.ProvinceId = (Guid)personal.cboProvince.SelectedValue;
                if ((Guid)personal.cboCity.SelectedValue != Guid.Empty) item.CityId = (Guid)personal.cboCity.SelectedValue;

                ctx.SaveChanges();
            }
        }

        private void SaveSmartTagValue(Guid supplierId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "SupplierId = '{0}'  AND TagId = '{1}'";

                #region Smart Tag 1
                var oTag1 = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == (Guid)general.txtSmartTag1.Tag).FirstOrDefault();
                if (oTag1 == null)
                {
                    oTag1 = new EF6.SupplierSmartTag();
                    oTag1.SmartTagId = Guid.NewGuid();
                    oTag1.SupplierId = supplierId;
                    oTag1.TagId = (general.txtSmartTag1.Tag == null) ? Guid.Empty : (Guid)general.txtSmartTag1.Tag;

                    ctx.SupplierSmartTag.Add(oTag1);
                }
                oTag1.SmartTagValue = general.txtSmartTag1.Text;
                #endregion

                #region Smart Tag 2
                var oTag2 = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == (Guid)general.txtSmartTag2.Tag).FirstOrDefault();
                if (oTag2 == null)
                {
                    oTag2 = new EF6.SupplierSmartTag();
                    oTag2.SmartTagId = Guid.NewGuid();
                    oTag2.SupplierId = supplierId;
                    oTag2.TagId = (general.txtSmartTag2.Tag == null) ? Guid.Empty : (Guid)general.txtSmartTag2.Tag;

                    ctx.SupplierSmartTag.Add(oTag2);
                }
                oTag2.SmartTagValue = general.txtSmartTag2.Text;
                #endregion

                #region Smart Tag 3
                var oTag3 = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == (Guid)general.txtSmartTag3.Tag).FirstOrDefault();
                if (oTag3 == null)
                {
                    oTag3 = new EF6.SupplierSmartTag();
                    oTag3.SmartTagId = Guid.NewGuid();
                    oTag3.SupplierId = supplierId;
                    oTag3.TagId = (general.txtSmartTag3.Tag == null) ? Guid.Empty : (Guid)general.txtSmartTag3.Tag;

                    ctx.SupplierSmartTag.Add(oTag3);
                }
                oTag3.SmartTagValue = general.txtSmartTag3.Text;
                #endregion

                #region Smart Tag 4
                var oTag4 = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == (Guid)general.txtSmartTag4.Tag).FirstOrDefault();
                if (oTag4 == null)
                {
                    oTag4 = new EF6.SupplierSmartTag();
                    oTag4.SmartTagId = Guid.NewGuid();
                    oTag4.SupplierId = supplierId;
                    oTag4.TagId = (general.txtSmartTag4.Tag == null) ? Guid.Empty : (Guid)general.txtSmartTag4.Tag;

                    ctx.SupplierSmartTag.Add(oTag4);
                }
                oTag4.SmartTagValue = general.txtSmartTag4.Text;
                #endregion

                #region Smart Tag 5
                var oTag5 = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == (Guid)personal.txtSmartTag5.Tag).FirstOrDefault();
                if (oTag5 == null)
                {
                    oTag5 = new EF6.SupplierSmartTag();
                    oTag5.SmartTagId = Guid.NewGuid();
                    oTag5.SupplierId = supplierId;
                    oTag5.TagId = (personal.txtSmartTag5.Tag == null) ? Guid.Empty : (Guid)personal.txtSmartTag5.Tag;

                    ctx.SupplierSmartTag.Add(oTag5);
                }
                oTag5.SmartTagValue = personal.txtSmartTag5.Text;
                #endregion

                #region Smart Tag 6
                var oTag6 = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == (Guid)personal.txtSmartTag6.Tag).FirstOrDefault();
                if (oTag6 == null)
                {
                    oTag6 = new EF6.SupplierSmartTag();
                    oTag5.SmartTagId = Guid.NewGuid();
                    oTag6.SupplierId = supplierId;
                    oTag5.TagId = (personal.txtSmartTag6.Tag == null) ? Guid.Empty : (Guid)personal.txtSmartTag6.Tag;

                    ctx.SupplierSmartTag.Add(oTag6);
                }
                oTag6.SmartTagValue = personal.txtSmartTag6.Text;
                #endregion

                ctx.SaveChanges();
            }
        }
        #endregion

        #region Load Methods
        private void LoadSupplierInfo()
        {
            LoadInfo();
        }

        private void LoadInfo()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oSupplier = ctx.Supplier.Find(this.SupplierId);
                if (oSupplier == null)
                {
                    txtSupplierCode.Text = oSupplier.SupplierCode;
                    general.txtInitial.Text = oSupplier.SupplierInitial;
                    general.txtName.Text = oSupplier.SupplierName;
                    general.txtNameChs.Text = oSupplier.SupplierName_Chs;
                    general.txtNameCht.Text = oSupplier.SupplierName_Cht;
                    general.txtAltSupplierNum.Text = oSupplier.AlternateSupplier;
                    general.cboMarketSector.SelectedValue = oSupplier.MarketSectorId;
                    financial.cboTerms.SelectedValue = oSupplier.TermsId;
                    financial.txtCreditLimit.Text = oSupplier.CreditAmount.ToString("n2");
                    general.txtRemarks.Text = oSupplier.Remarks;
                    financial.txtNormalDiscount.Text = oSupplier.NormalDiscount.ToString("n2");
                    financial.txtWholesalesDiscount.Text = oSupplier.WholesaleDiscount.ToString("n2");
                    financial.txtQuotaDiscount.Text = oSupplier.QuotaDiscount.ToString("n2");
                    financial.txtYearEndBonus.Text = oSupplier.YearEndDiscount.ToString("n2");
                    financial.txtCashDiscount.Text = oSupplier.CashDiscount.ToString("n2");
                    financial.txtOthersDiscount.Text = oSupplier.OtherDiscount.ToString("n2");
                    financial.cboCurrency.Text = oSupplier.CurrencyCode;
                    financial.txtBFAmount.Text = oSupplier.BFBAL.ToString("n2");
                    financial.txtCDAmount.Text = oSupplier.CDBAL.ToString("n2");
                    financial.txtLastPurchasedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oSupplier.DateLastPurchase.Value, false);
                    financial.txtLastPaidOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oSupplier.DateLastPay.Value, false);
                    financial.txtLastReturnedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oSupplier.DateLastReturn.Value, false);

                    general.txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(oSupplier.ModifiedBy);
                    general.txtLastUpdatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oSupplier.ModifiedOn, false);
                    general.txtCreatedon.Text = RT2020.SystemInfo.Settings.DateTimeToString(oSupplier.CreatedOn, false);

                    LoadAddress();
                    LoadSmartTag();
                }
            }
        }

        private void LoadAddress()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierAddress.Where(x => x.SupplierId == this.SupplierId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    personal.cboAddressType.SelectedValue = item.AddressTypeId;
                    personal.txtAddress.Text = item.Address;
                    personal.txtPostalCode.Text = item.PostalCode;
                    personal.cboCountry.SelectedValue = item.CountryId;
                    personal.cboProvince.SelectedValue = item.ProvinceId;
                    personal.cboCity.SelectedValue = item.CityId;
                }
            }
        }

        private void LoadSmartTag()
        {
            var oTag1 = ModelEx.SupplierSmartTagEx.Get(this.SupplierId, (Guid)general.txtSmartTag1.Tag);
            if (oTag1 != null)
            {
                general.txtSmartTag1.Text = oTag1.SmartTagValue;
            }

            var oTag2 = ModelEx.SupplierSmartTagEx.Get(this.SupplierId, (Guid)general.txtSmartTag2.Tag);
            if (oTag2 != null)
            {
                general.txtSmartTag2.Text = oTag2.SmartTagValue;
            }

            var oTag3 = ModelEx.SupplierSmartTagEx.Get(this.SupplierId, (Guid)general.txtSmartTag3.Tag);
            if (oTag3 != null)
            {
                general.txtSmartTag3.Text = oTag3.SmartTagValue;
            }

            var oTag4 = ModelEx.SupplierSmartTagEx.Get(this.SupplierId, (Guid)general.txtSmartTag4.Tag);
            if (oTag4 != null)
            {
                general.txtSmartTag4.Text = oTag4.SmartTagValue;
            }

            var oTag5 = ModelEx.SupplierSmartTagEx.Get(this.SupplierId, (Guid)personal.txtSmartTag5.Tag);
            if (oTag5 != null)
            {
                personal.txtSmartTag5.Text = oTag5.SmartTagValue;
            }

            var oTag6 = ModelEx.SupplierSmartTagEx.Get(this.SupplierId, (Guid)personal.txtSmartTag6.Tag);
            if (oTag6 != null)
            {
                personal.txtSmartTag6.Text = oTag6.SmartTagValue;
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oSupplier = ctx.Supplier.Find(this.SupplierId);
                if (oSupplier == null)
                {
                    switch ((int)oSupplier.Status)
                    {
                        case (int)Common.Enums.Status.Active:       //2014.01.04 paulus: 如果 Supplier.Status = Active 設為 Deleted + Retired
                            oSupplier.Status = Convert.ToInt32(Common.Enums.Status.Deleted.ToString("d"));
                            oSupplier.Retired = true;
                            oSupplier.RetiredOn = DateTime.Now;
                            oSupplier.RetiredBy = Common.Config.CurrentUserId;
                            break;
                        case (int)Common.Enums.Status.Draft:        //2014.01.04 paulus: 如果 Supplier.Status = Draft 可以直接刪除
                            string sql = "SupplierId = '" + oSupplier.SupplierId.ToString() + "'";

                            ModelEx.SupplierSmartTagEx.Delete(oSupplier.SupplierId);
                            ModelEx.SupplierContactEx.Delete(oSupplier.SupplierId);
                            ModelEx.SupplierAddressEx.Delete(oSupplier.SupplierId);

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
                    if (this.SupplierId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        SupplierWizard wizard = new SupplierWizard(this.SupplierId);
                        wizard.ShowDialog();
                    }
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    if (this.SupplierId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                        this.Close();
                        SupplierWizard wizard = new SupplierWizard();
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
                    if (this.SupplierId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
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