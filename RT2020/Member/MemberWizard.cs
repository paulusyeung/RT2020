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
using System.IO;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard : Form
    {
        Boolean _EveryMemberIsVip = true;           //RT2000 default = false; Opera default = true;
        Boolean _Use13DigitsVipNumber = false;      //Works if and only if _EveryMemberIsVip = true

        MemberWizard_MainInfo main = null;
        MemberWizard_CardInfo card = null;
        MemberWizard_AddressInfo address = null;
        MemberWizard_OthersInfo others = null;
        MemberWizard_MiscInfo misc = null;
        MemberWizard_MarketingInfo marketing = null;

        public MemberWizard()
        {
            InitializeComponent();
            FillLineOfOperationList();
            SetToolBar();
            TabCtrl();
            SetCtrlEditable();
            SetDefaults();
        }

        public MemberWizard(Guid memberId)
        {
            InitializeComponent();
            this.MemberId = memberId;
            FillLineOfOperationList();
            SetToolBar();
            TabCtrl();
            SetCtrlEditable();
            LoadMemberInfo();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_EveryMemberIsVip)
            {
                chkVIP.Checked = true;
                chkVIP.Visible = false;

                this.VipNumber = RT2020.Controls.Member.GetNextVipNumber(_Use13DigitsVipNumber);
            }
            this.CheckVipInfo();
            txtMemberNumber.Focus();
        }

        private void CheckVipInfo()
        {
            tpCardInfo.Visible = chkVIP.Checked;
            tpOthersInfo.Visible = chkVIP.Checked;
            tpMiscInfo.Visible = chkVIP.Checked;
            tpMarketingInfo.Visible = chkVIP.Checked;

            if (!chkVIP.Checked)
            {
                tpMainInfo.Select();
                tabMember.SelectedIndex = 0;
                tabMember.Update();
            }
        }

        #region Properties
        private Guid memberId = System.Guid.Empty;
        public Guid MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
            }
        }

        private string vipNumber = string.Empty;
        public string VipNumber
        {
            get
            {
                return vipNumber;
            }
            set
            {
                vipNumber = value;
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

            if (MemberId == System.Guid.Empty)
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

        #region Fill Combo List
        private void FillLineOfOperationList()
        {
            cboLineOfOperation.Items.Clear();

            ModelEx.LineOfOperationEx.LoadCombo(ref cboLineOfOperation, "LineOfOperationName", false);
            cboLineOfOperation.SelectedIndex = 0;
        }
        #endregion

        #region Controls

        #region Member Code
        private void SetCtrlEditable()
        {
            txtMemberNumber.BackColor = (this.MemberId == System.Guid.Empty) ? RT2020.SystemInfo.ControlBackColor.RequiredBox : RT2020.SystemInfo.ControlBackColor.DisabledBox;
            txtMemberNumber.ReadOnly = (this.MemberId != System.Guid.Empty);

            cboLineOfOperation.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;
        }
        #endregion

        #region Tab
        private void TabCtrl()
        {
            // Main Info
            main = new MemberWizard_MainInfo();
            main.Dock = DockStyle.Fill;
            main.MemberId = this.MemberId;
            tpMainInfo.Controls.Add(main);

            // Address Info
            address = new MemberWizard_AddressInfo();
            address.Dock = DockStyle.Fill;
            address.MemberId = this.MemberId;
            tpAddressInfo.Controls.Add(address);

            // Card Info
            card = new MemberWizard_CardInfo();
            card.Dock = DockStyle.Fill;
            card.MemberId = this.MemberId;
            tpCardInfo.Controls.Add(card);

            // Others Info
            others = new MemberWizard_OthersInfo();
            others.Dock = DockStyle.Fill;
            others.MemberId = this.MemberId;
            tpOthersInfo.Controls.Add(others);

            // Misc Info
            misc = new MemberWizard_MiscInfo();
            misc.Dock = DockStyle.Fill;
            misc.MemberId = this.MemberId;
            tpMiscInfo.Controls.Add(misc);

            // Marketing Info
            marketing = new MemberWizard_MarketingInfo();
            marketing.Dock = DockStyle.Fill;
            marketing.MemberId = this.MemberId;
            tpMarketingInfo.Controls.Add(marketing);
        }
        #endregion

        #endregion

        #region Save Methods

        private bool Verify()
        {
            bool result = true;

            if (txtMemberNumber.Text == string.Empty)
            {
                errorProvider.SetError(txtMemberNumber, "Can not be blank!");
                result = false;
            }
            else if (txtMemberNumber.Text.Length > 13)
            {
                errorProvider.SetError(txtMemberNumber, "The length of [Member#] should be Less than or equal to 13!");
                result = false;
            }
            else
            {
                errorProvider.SetError(txtMemberNumber, string.Empty);

                if (this.MemberId == System.Guid.Empty)
                {
                    string sql = "MemberNumber = '" + txtMemberNumber.Text + "'";
                    RT2020.DAL.Member oMember = RT2020.DAL.Member.LoadWhere(sql);
                    if (oMember != null && this.MemberId == System.Guid.Empty)
                    {
                        errorProvider.SetError(txtMemberNumber, "Member Number exists!");
                        result = false;
                    }
                    else
                    {
                        errorProvider.SetError(txtMemberNumber, string.Empty);
                    }
                }
            }

            if (cboLineOfOperation.Text.Length == 0)
            {
                //errorProvider.SetError(cboLineOfOperation, "Can not be blank!");
                //result = false;
            }
            else
            {
                errorProvider.SetError(cboLineOfOperation, string.Empty);
            }

            return result;
        }

        private bool VerifyNumbers()
        {
            bool result = true;

            if (!Common.Utility.IsNumeric(others.txtCreditLimit.Text))
            {
                errorProvider.SetError(others.txtCreditLimit, Resources.Common.DigitalNeeded);
                result = false;
            }
            else if (!Common.Utility.IsNumeric(others.txtNormalItemDiscount.Text))
            {
                errorProvider.SetError(others.txtNormalItemDiscount, Resources.Common.DigitalNeeded);
                result = false;
            }
            else if (!Common.Utility.IsNumeric(others.txtPaymentDiscount.Text))
            {
                errorProvider.SetError(others.txtPaymentDiscount, Resources.Common.DigitalNeeded);
                result = false;
            }
            else if (!Common.Utility.IsNumeric(others.txtPromotionItemDiscount.Text))
            {
                errorProvider.SetError(others.txtPromotionItemDiscount, Resources.Common.DigitalNeeded);
                result = false;
            }
            else if (!Common.Utility.IsNumeric(others.txtStaffQuota.Text))
            {
                errorProvider.SetError(others.txtStaffQuota, Resources.Common.DigitalNeeded);
                result = false;
            }
            else
            {
                errorProvider.SetError(others.txtCreditLimit, string.Empty);
                errorProvider.SetError(others.txtNormalItemDiscount, string.Empty);
                errorProvider.SetError(others.txtPaymentDiscount, string.Empty);
                errorProvider.SetError(others.txtPromotionItemDiscount, string.Empty);
                errorProvider.SetError(others.txtStaffQuota, string.Empty);
            }

            if (!result)
            {
                tabMember.SelectedIndex = 3;
            }

            return result;
        }

        private bool Save()
        {
            if (Verify() && VerifyNumbers())
            {
                bool isNew = false;

                RT2020.DAL.Member oMember = RT2020.DAL.Member.Load(this.MemberId);
                if (oMember == null)
                {
                    oMember = new RT2020.DAL.Member();

                    oMember.MemberNumber = txtMemberNumber.Text;
                    oMember.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));
                    isNew = true;

                    oMember.CreatedBy = Common.Config.CurrentUserId;
                    oMember.CreatedOn = DateTime.Now;
                }

                oMember.WorkplaceId = (main.cboWorkplace.SelectedValue == null) ? System.Guid.Empty : new System.Guid(main.cboWorkplace.SelectedValue.ToString());
                oMember.ClassId = (main.cboPhoneBook.SelectedValue == null) ? System.Guid.Empty : new System.Guid(main.cboPhoneBook.SelectedValue.ToString());
                oMember.GroupId = (main.cboGroup.SelectedValue == null) ? System.Guid.Empty : new System.Guid(main.cboGroup.SelectedValue.ToString());
                oMember.MemberInitial = main.txtNickName.Text;
                oMember.SalutationId = (main.cboSalutation.SelectedValue == null) ? System.Guid.Empty : new System.Guid(main.cboSalutation.SelectedValue.ToString());
                oMember.FirstName = main.txtFirstName.Text;
                oMember.LastName = main.txtLastName.Text;
                oMember.FullName = main.txtLastName.Text + "," + main.txtFirstName.Text;
                oMember.FullName_Chs = main.txtChineseName.Text;
                oMember.FullName_Cht = main.txtChineseName.Text;
                oMember.JobTitleId = (main.cboJobTitle.SelectedValue == null) ? System.Guid.Empty : new System.Guid(main.cboJobTitle.SelectedValue.ToString());
                oMember.AssignedTo = System.Guid.Empty;
                oMember.Remarks = main.txtRemarks.Text;
                oMember.NormalDiscount = (others.txtNormalItemDiscount.Text.Length == 0) ? 0 : Convert.ToDecimal(others.txtNormalItemDiscount.Text);
                oMember.DownloadToPOS = true;

                if (!isNew)
                {
                    oMember.Status = Convert.ToInt32(Common.Enums.Status.Modified.ToString("d"));
                }

                oMember.ModifiedBy = Common.Config.CurrentUserId;
                oMember.ModifiedOn = DateTime.Now;
                oMember.Save();

                this.MemberId = oMember.MemberId;

                SaveSmartTag(oMember.MemberId);
                SaveAddress(oMember.MemberId);

                if (chkVIP.Checked && this.VipNumber.Trim().Length > 0)
                {
                    SaveVipData(oMember.MemberId);
                }

                if (isNew)
                {// log activity (New Record)
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Create, oMember.ToString());
                }
                else
                { // log activity (Update)
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oMember.ToString());
                }     

                return true;
            }
            else
            {
                return false;
            }
        }

        private void SaveSmartTag(Guid memberId)
        {
            string sql = "MemberId = '" + memberId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";

            for (int i = 0; i < main.Controls.Count; i++)
            {
                string tagId = String.Empty;
                string value = String.Empty;
                Control Ctrl = main.Controls[i];

                if (Ctrl != null && Ctrl.Name.Contains(key))
                {
                    if (Ctrl.GetType().Equals(typeof(TextBox)))
                    {
                        TextBox txtTag = Ctrl as TextBox;
                        tagId = txtTag.Tag.ToString();
                        value = txtTag.Text;
                    }

                    if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                    {
                        MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                        tagId = txtTag.Tag.ToString();
                        value = txtTag.Text;
                    }

                    if (Ctrl.GetType().Equals(typeof(ComboBox)))
                    {
                        ComboBox cboTag = Ctrl as ComboBox;
                        tagId = cboTag.Tag.ToString();
                        value = cboTag.Text;
                    }

                    if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                    {
                        DateTimePicker dtpTag = Ctrl as DateTimePicker;
                        tagId = dtpTag.Tag.ToString();
                        //2014.01.08 paulus: 可以唔輸入 birthday，先決 ShowCheckBox，再睇吓有冇 Checked
                        if (dtpTag.ShowCheckBox)
                        {
                            value = (dtpTag.Checked) ? dtpTag.Value.ToString("yyyy-MM-dd") : String.Empty;
                        }
                        else
                        {
                            value = dtpTag.Value.ToString("yyyy-MM-dd");
                        }
                    }

                    Guid smartTagId = Guid.Empty;
                    if (Guid.TryParse(tagId, out smartTagId))
                    {
                        using (var ctx = new EF6.RT2020Entities())
                        {
                            var oTag = ctx.MemberSmartTag
                                .Where(x => x.MemberId == memberId && x.TagId == smartTagId)
                                .FirstOrDefault();
                            if (oTag == null)
                            {
                                oTag = new EF6.MemberSmartTag();
                                oTag.SmartTagId = Guid.NewGuid();
                                oTag.MemberId = memberId;
                                oTag.TagId = new Guid(tagId);

                                ctx.MemberSmartTag.Add(oTag);
                            }
                            oTag.SmartTagValue = value;
                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }

        private void SaveAddress(Guid memberId)
        {
            string sql = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + address.cboAddressType.SelectedValue.ToString() + "'";
            MemberAddress oAddress = MemberAddress.LoadWhere(sql);
            if (oAddress == null)
            {
                oAddress = new MemberAddress();
                oAddress.MemberId = memberId;
                oAddress.AddressTypeId = new Guid(address.cboAddressType.SelectedValue.ToString());
            }
            oAddress.Address = address.txtAddress.Text;
            oAddress.PostalCode = address.txtPostalCode.Text;
            oAddress.CountryId = new Guid(address.cboCountry.SelectedValue.ToString());
            oAddress.ProvinceId = new Guid(address.cboProvince.SelectedValue.ToString());
            oAddress.CityId = new Guid(address.cboCity.SelectedValue.ToString());
            oAddress.District = address.txtDistrict.Text;
            oAddress.Mailing = true;
            oAddress.PhoneTag1 = (address.txtPhoneTag1.Tag == null) ? System.Guid.Empty : new System.Guid(address.txtPhoneTag1.Tag.ToString());
            oAddress.PhoneTag1Value = address.txtPhoneTag1.Text;
            oAddress.PhoneTag2 = (address.txtPhoneTag2.Tag == null) ? System.Guid.Empty : new System.Guid(address.txtPhoneTag2.Tag.ToString());
            oAddress.PhoneTag2Value = address.txtPhoneTag2.Text;
            oAddress.PhoneTag3 = (address.txtPhoneTag3.Tag == null) ? System.Guid.Empty : new System.Guid(address.txtPhoneTag3.Tag.ToString());
            oAddress.PhoneTag3Value = address.txtPhoneTag3.Text;
            oAddress.PhoneTag4 = (address.txtPhoneTag4.Tag == null) ? System.Guid.Empty : new System.Guid(address.txtPhoneTag4.Tag.ToString());
            oAddress.PhoneTag4Value = address.txtPhoneTag4.Text;
            oAddress.PhoneTag5 = (address.txtPhoneTag5.Tag == null) ? System.Guid.Empty : new System.Guid(address.txtPhoneTag5.Tag.ToString());
            oAddress.PhoneTag5Value = address.txtPhoneTag5.Text;

            oAddress.Save();
        }

        private void SaveVipData(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "MemberId = '" + memberId.ToString() + "'";
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).FirstOrDefault();
                if (oVip == null)
                {
                    oVip = new EF6.MemberVipData();
                    oVip.MemberVipId = Guid.NewGuid();
                    oVip.MemberVipId = System.Guid.NewGuid();
                    oVip.MemberId = memberId;
                    oVip.VipNumber = this.VipNumber;

                    ctx.MemberVipData.Add(oVip);
                }
                oVip.FORMER_PPNO = card.txtFormerPPNumber.Text;
                oVip.CARD_ACTIVE = card.chkCardActived.Checked;
                oVip.CARD_RECEIVE = card.chkCardReceived.Checked;
                oVip.CARD_NAME = card.txtCardName.Text;
                oVip.CARD_EXPIRE = card.dtpCardExpiredOn.Value;
                oVip.CARD_ISSUE = card.dtpIssuedOn.Value;

                oVip.CommencementDate = card.dtpCommencementDate.Value;
                oVip.MigrationDate = card.dtpMigrationDate.Value;

                decimal credit = 0;
                if (Decimal.TryParse(others.txtCreditLimit.Text.Trim(), out credit))
                {
                    oVip.CreditLimit = credit;
                }

                decimal terms = 0;
                if (Decimal.TryParse(others.txtCreditTerms.Text.Trim(), out terms))
                {
                    oVip.CreditTerms = terms;
                }

                decimal paydisc = 0;
                if (Decimal.TryParse(others.txtPaymentDiscount.Text.Trim(), out paydisc))
                {
                    oVip.PaymentDiscount = paydisc;
                }

                decimal staffQuota = 0;
                if (Decimal.TryParse(others.txtStaffQuota.Text.Trim(), out staffQuota))
                {
                    oVip.StaffQuota = staffQuota;
                }

                oVip.AddOnDiscount = others.chkAddOnDiscount.Checked;

                ctx.SaveChanges();

                var vipId = oVip.MemberVipId;
                #region this.SaveVipLineOfOperation(vipId);
                string query = "MemberVipId = '" + vipId.ToString() + "'";
                var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == vipId).FirstOrDefault();
                if (oVipLoo == null)
                {
                    oVipLoo = new EF6.MemberVipLineOfOperation();
                    oVipLoo.MemberVipId = vipId;
                    oVipLoo.VipLooId = Guid.NewGuid();

                    ctx.MemberVipLineOfOperation.Add(oVipLoo);
                }

                oVipLoo.LineOfOperationId = new Guid(cboLineOfOperation.SelectedValue.ToString());
                oVipLoo.NormalDiscount = (others.txtNormalItemDiscount.Text.Length == 0) ? 0 : Convert.ToDecimal(others.txtNormalItemDiscount.Text);
                oVipLoo.PromotionDiscount = (others.txtPromotionItemDiscount.Text.Length == 0) ? 0 : Convert.ToDecimal(others.txtPromotionItemDiscount.Text);

                ctx.SaveChanges();
                #endregion

                #region this.SaveVipSupplement(vipId);
                //string query = "MemberVipId = '" + vipId.ToString() + "'";
                var oSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == vipId).FirstOrDefault();
                if (oSupplement == null)
                {
                    oSupplement = new EF6.MemberVipSupplement();
                    oSupplement.VipSupplementId = Guid.NewGuid();
                    oSupplement.MemberVipId = vipId;

                    ctx.MemberVipSupplement.Add(oSupplement);
                }

                // Others Info
                oSupplement.CustomerNumber = others.txtCustomerInfo1.Text;
                oSupplement.BRANCH = others.txtCustomerInfo2.Text;
                oSupplement.Remarks1 = others.txtRemarks1.Text;
                oSupplement.Remarks2 = others.txtRemarks2.Text;
                oSupplement.Remarks3 = others.txtRemarks3.Text;
                oSupplement.Nature = others.cboNature.Text;
                oSupplement.Memo = misc.txtMemo.Text;

                // Marketing Info
                oSupplement.MostVisitedMalls1 = marketing.txtMostVisitedMalls1.Text;
                oSupplement.MostVisitedMalls2 = marketing.txtMostVisitedMalls2.Text;
                oSupplement.MostVisitedMalls3 = marketing.txtMostVisitedMalls3.Text;

                oSupplement.MostBoughtBrands1 = marketing.txtMostBoughtBrands1.Text;
                oSupplement.MostBoughtBrands2 = marketing.txtMostBoughtBrands2.Text;
                oSupplement.MostBoughtBrands3 = marketing.txtMostBoughtBrands3.Text;

                oSupplement.MostReadMagazine1 = marketing.txtMostReadMagazine1.Text;
                oSupplement.MostReadMagazine2 = marketing.txtMostReadMagazine2.Text;
                oSupplement.MostReadMagazine3 = marketing.txtMostReadMagazine3.Text;

                oSupplement.MostUsedCreditCards1 = marketing.txtMostUsedCreditCards1.Text;
                oSupplement.MostUsedCreditCards2 = marketing.txtMostUsedCreditCards2.Text;
                oSupplement.MostUsedCreditCards3 = marketing.txtMostUsedCreditCards3.Text;

                // Photo
                oSupplement.Photo = misc.txtPicFileName.Text;

                ctx.SaveChanges();
                #endregion
            }
        }

        #endregion

        #region Load Member Info
        private void LoadMemberInfo()
        {
            RT2020.DAL.Member oMember = RT2020.DAL.Member.Load(this.MemberId);
            if (oMember != null)
            {
                txtMemberNumber.Text = oMember.MemberNumber;
                main.cboPhoneBook.SelectedValue = oMember.ClassId;
                main.cboWorkplace.SelectedValue = oMember.WorkplaceId;
                main.cboGroup.SelectedValue = oMember.GroupId;
                main.txtNickName.Text = oMember.MemberInitial;
                main.cboSalutation.SelectedValue = oMember.SalutationId;
                main.txtFirstName.Text = oMember.FirstName;
                main.txtLastName.Text = oMember.LastName;
                main.txtChineseName.Text = oMember.FullName_Chs;
                main.cboJobTitle.SelectedValue = oMember.JobTitleId;
                main.txtRemarks.Text = oMember.Remarks;
                others.txtNormalItemDiscount.Text = oMember.NormalDiscount.ToString("n2");

                main.txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(oMember.ModifiedBy);
                main.txtLastUpdatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oMember.ModifiedOn, false);
                main.txtCreatedOn.Text = RT2020.SystemInfo.Settings.DateTimeToString(oMember.CreatedOn, false);
                main.txtStatus.Text = Enum.GetName(typeof(Common.Enums.Status), oMember.Status);

                LoadSmartTag(oMember.MemberId);
                LoadAddress();
                LoadVipData();

                // Disable edit when status is Inactive (-2) or Deleted (-1)
                if (oMember.Status == Convert.ToInt32(Common.Enums.Status.Deleted.ToString("d")) ||
                    oMember.Status == Convert.ToInt32(Common.Enums.Status.Inactive.ToString("d")))
                {
                    this.cboLineOfOperation.Enabled = false;
                    main.cboSalutation.Enabled = false;
                    main.txtSmartTag10.Enabled = false;
                    main.txtNickName.Enabled = false;
                    main.txtFirstName.Enabled = false;
                    main.txtLastName.Enabled = false;
                    main.txtChineseName.Enabled = false;
                    main.cboJobTitle.Enabled = false;
                    main.txtSmartTag13.Enabled = false;
                    main.txtSmartTag14.Enabled = false;
                    main.cboSmartTag11.Enabled = false;
                    main.txtSmartTag12.Enabled = false;
                    main.txtRemarks.Enabled = false;
                    main.cboWorkplace.Enabled = false;
                    main.txtSmartTag1.Enabled = false;
                    main.cboSmartTag2.Enabled = false;
                    main.cboSmartTag3.Enabled = false;
                    main.cboSmartTag4.Enabled = false;
                    main.txtSmartTag5.Enabled = false;
                    main.txtSmartTag6.Enabled = false;
                    main.txtSmartTag7.Enabled = false;
                    main.dtpSmartTag8.Enabled = false;
                    main.dtpSmartTag9.Enabled = false;
                    main.cboPhoneBook.Enabled = false;

                    address.cboAddressType.Enabled = false;
                    address.txtAddress.Enabled = false;
                    address.txtDistrict.Enabled = false;
                    address.txtPostalCode.Enabled = false;
                    address.cboCountry.Enabled = false;
                    address.cboProvince.Enabled = false; 
                    address.cboCity.Enabled = false;
                    address.txtPhoneTag1.Enabled = false;
                    address.txtPhoneTag2.Enabled = false;
                    address.txtPhoneTag3.Enabled = false;
                    address.txtPhoneTag4.Enabled = false;
                    address.txtPhoneTag5.Enabled = false;

                    card.txtFormerPPNumber.Enabled = false;
                    card.dtpCommencementDate.Enabled = false;
                    card.dtpMigrationDate.Enabled = false;
                    card.dtpIssuedOn.Enabled = false;
                    card.dtpCardExpiredOn.Enabled = false;
                    card.txtCardName.Enabled = false;
                    card.chkCardReceived.Enabled = false;
                    card.chkCardActived.Enabled = false;

                    others.txtCreditLimit.Enabled = false;
                    others.txtCreditTerms.Enabled = false;
                    others.txtPaymentDiscount.Enabled = false;
                    others.txtCustomerInfo1.Enabled = false;
                    others.txtCustomerInfo2.Enabled = false;
                    others.txtCustomerInfo3.Enabled = false;
                    others.txtNormalItemDiscount.Enabled = false;
                    others.txtPromotionItemDiscount.Enabled = false;
                    others.chkAddOnDiscount.Enabled = false;
                    others.txtStaffQuota.Enabled = false;
                    others.txtRemarks1.Enabled = false;
                    others.txtRemarks2.Enabled = false;
                    others.txtRemarks3.Enabled = false;

                    misc.txtMemo.Enabled = false;
                    misc.txtPicFileName.Enabled = false;
                    misc.btnFindPic.Enabled = false;
                    misc.btnDelete.Enabled = false;
                    misc.btnRefresh.Enabled = false;

                    marketing.txtMostVisitedMalls1.Enabled = false;
                    marketing.txtMostVisitedMalls2.Enabled = false;
                    marketing.txtMostVisitedMalls3.Enabled = false;
                    marketing.txtMostBoughtBrands1.Enabled = false;
                    marketing.txtMostBoughtBrands2.Enabled = false;
                    marketing.txtMostBoughtBrands3.Enabled = false;
                    marketing.txtMostReadMagazine1.Enabled = false;
                    marketing.txtMostReadMagazine2.Enabled = false;
                    marketing.txtMostReadMagazine3.Enabled = false;
                    marketing.txtMostUsedCreditCards1.Enabled = false;
                    marketing.txtMostUsedCreditCards2.Enabled = false;
                    marketing.txtMostUsedCreditCards3.Enabled = false;

                    this.tbWizardAction.Visible = false;
                    this.tbWizardAction.Enabled = false;
                }
            }
        }

        private void LoadSmartTag(Guid memberId)
        {
            string sql = "MemberId = '" + memberId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";

            for (int i = 0; i < main.Controls.Count; i++)
            {
                string tagId = string.Empty;
                string value = string.Empty;
                Control Ctrl = main.Controls[i];

                if (Ctrl != null && Ctrl.Name.Contains(key))
                {
                    if (Ctrl.Tag != null)
                    {
                        tagId = Ctrl.Tag.ToString();

                        Guid smartTagId = Guid.Empty;
                        if (Guid.TryParse(tagId, out smartTagId))
                        {
                            using (var ctx = new EF6.RT2020Entities())
                            {
                                var oTag = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.TagId == smartTagId).AsNoTracking().FirstOrDefault();
                                if (oTag != null)
                                {
                                    if (Ctrl.GetType().Equals(typeof(TextBox)))
                                    {
                                        TextBox txtTag = Ctrl as TextBox;
                                        txtTag.Text = oTag.SmartTagValue;
                                    }

                                    if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                                    {
                                        MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                                        txtTag.Text = oTag.SmartTagValue;
                                    }

                                    if (Ctrl.GetType().Equals(typeof(ComboBox)))
                                    {
                                        ComboBox cboTag = Ctrl as ComboBox;
                                        cboTag.Text = oTag.SmartTagValue;
                                    }

                                    if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                                    {
                                        DateTimePicker dtpTag = Ctrl as DateTimePicker;
                                        //2014.01.08 paulus: 可以唔輸入 birthday，先決係要有 ShowCheckBox，然後根據 value
                                        //舊 code: dtpTag.Value = (oTag.SmartTagValue.Length == 0) ? DateTime.Now : Convert.ToDateTime(ReformatDateTime(oTag.SmartTagValue));
                                        if (dtpTag.ShowCheckBox)
                                        {
                                            if (oTag.SmartTagValue.Length == 0)
                                            {
                                                dtpTag.Value = dtpTag.MinDate;
                                                dtpTag.Checked = false;
                                            }
                                            else
                                            {
                                                dtpTag.Value = Convert.ToDateTime(ReformatDateTime(oTag.SmartTagValue));
                                                dtpTag.Checked = true;
                                            }
                                        }
                                        else
                                        {
                                            dtpTag.Value = (oTag.SmartTagValue.Length == 0) ? dtpTag.MinDate : Convert.ToDateTime(ReformatDateTime(oTag.SmartTagValue));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private string ReformatDateTime(string value)
        {
            int index = value.IndexOf("/");
            if (index > 0)
            {
                string[] values = value.Split('/');
                if (values.Length == 3)
                {
                    value = values[2] + "-" + values[1] + "-" + values[0];
                }
            }
            return value;
        }

        private void LoadAddress()
        {
            string sql = "MemberId = '" + this.MemberId.ToString() + "'";
            MemberAddressCollection oAddressList = MemberAddress.LoadCollection(sql);

            // Default to show AddressTypeCode = ADDR_EN
            if (oAddressList.Count > 0)
            {
                // Default to show AddressTypeCode = ADDR_EN
                int foundRow = 0;
                bool foundAddrEn = false;
                Guid addressTypeId_ADDR_EN = MemberAddressType.LoadWhere("AddressTypeCode = 'ADDR_EN'").AddressTypeId;
                foreach (MemberAddress oAddress in oAddressList)
                {
                    if (oAddress.AddressTypeId == addressTypeId_ADDR_EN)
                    {
                        foundAddrEn = true;
                        break;
                    }
                    foundRow++;
                }
                if (!foundAddrEn)
                {
                    foundRow = 0;
                }
                address.cboAddressType.SelectedValue = oAddressList[foundRow].AddressTypeId;
                address.txtAddress.Text = oAddressList[foundRow].Address;
                address.txtPostalCode.Text = oAddressList[foundRow].PostalCode;
                address.cboCountry.SelectedValue = oAddressList[foundRow].CountryId;
                address.cboProvince.SelectedValue = oAddressList[foundRow].ProvinceId;
                address.cboCity.SelectedValue = oAddressList[foundRow].CityId;
                address.txtDistrict.Text = oAddressList[foundRow].District;

                address.txtPhoneTag1.Text = oAddressList[foundRow].PhoneTag1Value;
                address.txtPhoneTag2.Text = oAddressList[foundRow].PhoneTag2Value;
                address.txtPhoneTag3.Text = oAddressList[foundRow].PhoneTag3Value;
                address.txtPhoneTag4.Text = oAddressList[foundRow].PhoneTag4Value;
                address.txtPhoneTag5.Text = oAddressList[foundRow].PhoneTag5Value;
            }
            else
            {
                address.cboAddressType.SelectedValue = MemberAddressType.LoadWhere("AddressTypeCode = 'ADDR_EN'").AddressTypeId;
            }

        }

        private void LoadVipData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "MemberId = '" + this.MemberId.ToString() + "'";
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == this.MemberId).AsNoTracking().FirstOrDefault();
                if (oVip != null)
                {
                    chkVIP.Text = "VIP #: " + oVip.VipNumber;
                    chkVIP.Checked = true;
                    chkVIP.Enabled = false;

                    this.VipNumber = oVip.VipNumber;

                    card.txtFormerPPNumber.Text = oVip.FORMER_PPNO;
                    card.chkCardActived.Checked = oVip.CARD_ACTIVE;
                    card.chkCardReceived.Checked = oVip.CARD_RECEIVE;
                    card.txtCardName.Text = oVip.CARD_NAME;
                    card.dtpCardExpiredOn.Value = oVip.CARD_EXPIRE.Value;
                    card.dtpIssuedOn.Value = oVip.CARD_ISSUE.Value;

                    card.dtpCommencementDate.Value = oVip.CommencementDate.Value;
                    card.dtpMigrationDate.Value = oVip.MigrationDate.Value;

                    // Others Info
                    others.txtCreditLimit.Text = oVip.CreditLimit.Value.ToString("n2");
                    others.txtCreditTerms.Text = oVip.CreditTerms.Value.ToString("n0");
                    others.txtPaymentDiscount.Text = oVip.PaymentDiscount.Value.ToString("n2");
                    others.chkAddOnDiscount.Checked = oVip.AddOnDiscount.Value;
                    others.txtStaffQuota.Text = oVip.StaffQuota.Value.ToString("n2");

                    sql = "MemberVipId = '" + oVip.MemberVipId.ToString() + "'";
                    var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == oVip.MemberVipId).AsNoTracking().FirstOrDefault();
                    if (oVipLoo != null)
                    {
                        cboLineOfOperation.SelectedValue = oVipLoo.LineOfOperationId;
                        others.txtPromotionItemDiscount.Text = oVipLoo.PromotionDiscount.Value.ToString("n2");
                    }

                    var oVipSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == oVip.MemberVipId).FirstOrDefault();
                    if (oVipSupplement != null)
                    {
                        others.txtCustomerInfo1.Text = oVipSupplement.CustomerNumber;
                        others.txtCustomerInfo2.Text = oVipSupplement.BRANCH;
                        others.txtRemarks1.Text = oVipSupplement.Remarks1;
                        others.txtRemarks2.Text = oVipSupplement.Remarks2;
                        others.txtRemarks3.Text = oVipSupplement.Remarks3;
                        others.cboNature.Text = oVipSupplement.Nature;


                        // Marketing Info
                        marketing.txtMostVisitedMalls1.Text = oVipSupplement.MostVisitedMalls1;
                        marketing.txtMostVisitedMalls2.Text = oVipSupplement.MostVisitedMalls2;
                        marketing.txtMostVisitedMalls3.Text = oVipSupplement.MostVisitedMalls3;

                        marketing.txtMostBoughtBrands1.Text = oVipSupplement.MostBoughtBrands1;
                        marketing.txtMostBoughtBrands2.Text = oVipSupplement.MostBoughtBrands2;
                        marketing.txtMostBoughtBrands3.Text = oVipSupplement.MostBoughtBrands3;

                        marketing.txtMostReadMagazine1.Text = oVipSupplement.MostReadMagazine1;
                        marketing.txtMostReadMagazine2.Text = oVipSupplement.MostReadMagazine2;
                        marketing.txtMostReadMagazine3.Text = oVipSupplement.MostReadMagazine3;

                        marketing.txtMostUsedCreditCards1.Text = oVipSupplement.MostUsedCreditCards1;
                        marketing.txtMostUsedCreditCards2.Text = oVipSupplement.MostUsedCreditCards2;
                        marketing.txtMostUsedCreditCards3.Text = oVipSupplement.MostUsedCreditCards3;

                        // Photo
                        misc.txtPicFileName.Text = oVipSupplement.Photo;

                        // 2009.12.29 david: 如果为网络路径，则直接显示。
                        string photoPath = Path.Combine(Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), oVipSupplement.Photo);
                        try
                        {
                            Uri uri = new Uri(oVipSupplement.Photo);
                            if (uri.IsUnc)
                            {
                                misc.imgMemberPicture.ImageName = uri.LocalPath;
                            }
                            else
                            {
                                misc.imgMemberPicture.ImageName = photoPath;
                            }
                        }
                        catch { }
                        finally
                        {
                            misc.imgMemberPicture.ImageName = photoPath;
                        }

                        misc.txtMemo.Text = oVipSupplement.Memo;
                    }
                }
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            RT2020.DAL.Member oMember = RT2020.DAL.Member.Load(this.MemberId);
            if (oMember != null)
            {
                oMember.Status = Convert.ToInt32(Common.Enums.Status.Deleted.ToString("d"));
                oMember.DownloadToPOS = true;

                oMember.Save();
                // log activity
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oMember.ToString());
            }
        }

        private void DeleteVIPData(string sql)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oVIPList = ctx.MemberVipData.SqlQuery(string.Format("Select * from MemberVipData Where {0}", sql));
                foreach (var oVip in oVIPList)
                {
                    sql = "MemberVipId = '" + oVip.MemberVipId.ToString() + "'";
                    var oVipSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == oVip.MemberVipId).FirstOrDefault();
                    if (oVipSupplement != null)
                    {
                        ctx.MemberVipSupplement.Remove(oVipSupplement);
                    }

                    sql = "MemberVipId = '" + oVip.MemberVipId.ToString() + "'";
                    var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == oVip.MemberVipId).FirstOrDefault();
                    if (oVipLoo != null)
                    {
                        ctx.MemberVipLineOfOperation.Remove(oVipLoo);
                    }

                    ctx.MemberVipData.Remove(oVip);
                }
            }
        }

        private void DeleteAddress(string sql)
        {
            MemberAddressCollection oAddressList = MemberAddress.LoadCollection(sql);
            foreach (MemberAddress oAddress in oAddressList)
            {
                oAddress.Delete();
            }
        }
        #endregion

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    if (this.MemberId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        MemberWizard wizard = new MemberWizard(this.MemberId);
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
                    if (this.MemberId != System.Guid.Empty)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                        this.Close();
                        MemberWizard wizard = new MemberWizard();
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
                    if (this.MemberId != System.Guid.Empty && Verify())
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

        private void chkVIP_Click(object sender, EventArgs e)
        {
            if (chkVIP.Checked)
            {
                MemberWizard_VipNumber wizVip = new MemberWizard_VipNumber();
                wizVip.MemberId = this.MemberId;
                wizVip.VipNumber = this.VipNumber.Trim().Length == 0 ? txtMemberNumber.Text : this.VipNumber;
                wizVip.Closed += new EventHandler(wizVip_Closed);
                wizVip.ShowDialog();
            }

            this.CheckVipInfo();
        }

        void wizVip_Closed(object sender, EventArgs e)
        {
            if (sender is MemberWizard_VipNumber)
            {
                MemberWizard_VipNumber wizVip = sender as MemberWizard_VipNumber;
                if (wizVip != null)
                {
                    this.VipNumber = wizVip.VipNumber;

                    chkVIP.Checked = (this.VipNumber != string.Empty);

                    this.CheckVipInfo();
                }
            }
        }

        private void cboLineOfOperation_LostFocus(object sender, EventArgs e)
        {
            main.cboSalutation.Focus();
        }

        private void SetDefaults()
        {
            address.cboAddressType.SelectedValue = MemberAddressType.LoadWhere("AddressTypeCode = 'ADDR_EN'").AddressTypeId;
            card.dtpCardExpiredOn.Value = DateTime.Today.AddYears(+100);
        }
    }
}