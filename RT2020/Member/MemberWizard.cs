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

using System.IO;
using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard : Form
    {
        Boolean _EveryMemberIsVip = true;           //RT2000 default = false; Opera default = true;
        Boolean _Use13DigitsVipNumber = false;      //Works if and only if _EveryMemberIsVip = true

        #region Declare Tab Pages
        bool tabGeneralLoaded = false, tabAddressLoaded = false, tabCardLoaded = false, tabOthersLoaded = false, tabMiscLoaded = false, tabMarketingLoaded = false;

        MemberWizard_General tabGeneral = null;
        MemberWizard_Card tabCard = null;
        MemberWizard_Address tabAddress = null;
        MemberWizard_Others tabOthers = null;
        MemberWizard_Misc tabMisc = null;
        MemberWizard_Marketing tabMarketing = null;
        #endregion

        #region public properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _MemberId = System.Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }

        private string _VipNumber = string.Empty;
        public string VipNumber
        {
            get { return _VipNumber; }
            set { _VipNumber = value; }
        }
        #endregion

        public MemberWizard()
        {
            InitializeComponent();
        }

        private void MemberWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            FillLineOfOperationList();
            SetToolBar();
            LoadTabControl();
            SetCtrlEditable();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadGeneral();
                    break;
            }
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

        #region SetCaptions & Attributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("member.wizard", "Model");

            lblMemberNumber.Text = WestwindHelper.GetWordWithColon("member.number", "Model");
            lblLineOfOperation.Text = WestwindHelper.GetWordWithColon("lineOfOperation", "Model");
            chkVIP.Text = WestwindHelper.GetWord("member.vip.upgrade", "Model");

            tpMainInfo.Text = WestwindHelper.GetWord("member.general", "Model");
            tpAddressInfo.Text = WestwindHelper.GetWord("memberAddress", "Model");
            //tpCardInfo.Text = WestwindHelper.GetWord("memberVipData", "Model");
            tpCardInfo.Text = WestwindHelper.GetWord("member.card", "Model");
            tpOthersInfo.Text = WestwindHelper.GetWord("member.others", "Model");
            tpMiscInfo.Text = WestwindHelper.GetWord("member.misc", "Model");
            tpMarketingInfo.Text = WestwindHelper.GetWord("member.marketing", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable line-of-operation label
            //lblLineOfOperation.AutoSize = true;                     // 減少 whitespace，有字嘅位置先可以 click
            lblLineOfOperation.Cursor = Cursors.Hand;               // cursor over 顯示 hand cursor
            lblLineOfOperation.Click += (s, e) =>                   // 彈出 wizard
            {
                var dialog = new Settings.LineOfOperationWizard();
                dialog.FormClosed += (sender, eventArgs) =>         // 關閉後 refresh 個 combo box items
                {
                    FillLineOfOperationList();
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

            if (MemberId == Guid.Empty)
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

        #region Fill Combo List
        private void FillLineOfOperationList()
        {
            LineOfOperationEx.LoadCombo(ref cboLineOfOperation, "LineOfOperationName", true);
        }
        #endregion

        #region Controls

        #region Member Code
        private void SetCtrlEditable()
        {
            txtMemberNumber.BackColor = (this.MemberId == System.Guid.Empty) ? SystemInfoHelper.ControlBackColor.RequiredBox : SystemInfoHelper.ControlBackColor.DisabledBox;
            txtMemberNumber.ReadOnly = (this.MemberId != System.Guid.Empty);

            cboLineOfOperation.BackColor = SystemInfoHelper.ControlBackColor.RequiredBox;
        }
        #endregion

        #region Load Tab
        /// <summary>
        /// tab page 最初係吉嘅，要顯示先 load，咁樣安排係等 form load 快啲
        /// </summary>
        /// <param name="tabIndex"></param>
        private void LoadTabControl(int tabIndex = 0)
        {
            switch (tabIndex)
            {
                case 0:
                    #region Tab Page: General
                    if (!tabGeneralLoaded)
                    {
                        tabGeneral = new MemberWizard_General();
                        tabGeneral.Dock = DockStyle.Fill;
                        tabGeneral.EditMode = _EditMode;
                        tabGeneral.MemberId = _MemberId;
                        tpMainInfo.Controls.Add(tabGeneral);

                        tabGeneralLoaded = true;
                    }
                    break;
                    #endregion
                case 1:
                    #region Tab Page: Address
                    if (!tabAddressLoaded)
                    {
                        tabAddress = new MemberWizard_Address();
                        tabAddress.Dock = DockStyle.Fill;
                        tabAddress.MemberId = _MemberId;
                        tpAddressInfo.Controls.Add(tabAddress);

                        tabAddressLoaded = true;
                        SetAddressDefaults();
                        if (_EditMode == EnumHelper.EditMode.Edit || _EditMode == EnumHelper.EditMode.Delete) LoadAddress(this.MemberId);
                    }
                    break;
                    #endregion
                case 2:
                    #region Tab Page: Card
                    if (!tabCardLoaded)
                    {
                        tabCard = new MemberWizard_Card();
                        tabCard.Dock = DockStyle.Fill;
                        tabCard.MemberId = _MemberId;
                        tpCardInfo.Controls.Add(tabCard);

                        tabCardLoaded = true;
                        SetCardDefaults();
                        if (_EditMode == EnumHelper.EditMode.Edit || _EditMode == EnumHelper.EditMode.Delete) LoadCard(this.MemberId);
                    }
                    break;
                    #endregion
                case 3:
                    #region Tab Page: Others
                    if (!tabOthersLoaded)
                    {
                        tabOthers = new MemberWizard_Others();
                        tabOthers.Dock = DockStyle.Fill;
                        tabOthers.MemberId = _MemberId;
                        tpOthersInfo.Controls.Add(tabOthers);

                        tabOthersLoaded = true;
                        if (_EditMode == EnumHelper.EditMode.Edit || _EditMode == EnumHelper.EditMode.Delete) LoadOthers(this.MemberId);
                    }
                    break;
                    #endregion
                case 4:
                    #region Tab Page: Misc
                    if (!tabMiscLoaded)
                    {
                        tabMisc = new MemberWizard_Misc();
                        tabMisc.Dock = DockStyle.Fill;
                        tabMisc.MemberId = _MemberId;
                        tpMiscInfo.Controls.Add(tabMisc);

                        tabMiscLoaded = true;
                        if (_EditMode == EnumHelper.EditMode.Edit || _EditMode == EnumHelper.EditMode.Delete) LoadMisc(this.MemberId);
                    }
                    break;
                    #endregion
                case 5:
                    #region Tab Page: Marketing
                    if (!tabMarketingLoaded)
                    {
                        tabMarketing = new MemberWizard_Marketing();
                        tabMarketing.Dock = DockStyle.Fill;
                        tabMarketing.MemberId = _MemberId;
                        tpMarketingInfo.Controls.Add(tabMarketing);

                        tabMarketingLoaded = true;
                        if (_EditMode == EnumHelper.EditMode.Edit || _EditMode == EnumHelper.EditMode.Delete) LoadMarketing(this.MemberId);
                    }
                    break;
                    #endregion
            }
            /**
            // Tab Page: General
            tabGeneral = new MemberWizard_General();
            tabGeneral.Dock = DockStyle.Fill;
            tabGeneral.MemberId = _MemberId;
            tpMainInfo.Controls.Add(tabGeneral);
            
            // Address Info
            tabAddress = new MemberWizard_Address();
            tabAddress.Dock = DockStyle.Fill;
            tabAddress.MemberId = _MemberId;
            tpAddressInfo.Controls.Add(tabAddress);

            // Card Info
            tabCard = new MemberWizard_Card();
            tabCard.Dock = DockStyle.Fill;
            tabCard.MemberId = _MemberId;
            tpCardInfo.Controls.Add(tabCard);

            // Others Info
            tabOthers = new MemberWizard_Others();
            tabOthers.Dock = DockStyle.Fill;
            tabOthers.MemberId = _MemberId;
            tpOthersInfo.Controls.Add(tabOthers);

            // Misc Info
            tabMisc = new MemberWizard_Misc();
            tabMisc.Dock = DockStyle.Fill;
            tabMisc.MemberId = _MemberId;
            tpMiscInfo.Controls.Add(tabMisc);

            // Marketing Info
            tabMarketing = new MemberWizard_Marketing();
            tabMarketing.Dock = DockStyle.Fill;
            tabMarketing.MemberId = _MemberId;
            tpMarketingInfo.Controls.Add(tabMarketing);
            */
        }
        #endregion

        #endregion

        #region set defaults
        private void SetAddressDefaults()
        {
            tabAddress.cboAddressType.SelectedValue = MemberAddressTypeEx.GetIdByCode("ADDR_EN");
        }

        private void SetCardDefaults()
        {
            tabCard.dtpCardExpiredOn.Value = DateTime.Today.AddYears(+100);
        }
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
                    //string sql = "MemberNumber = '" + txtMemberNumber.Text + "'";
                    //RT2020.DAL.Member oMember = RT2020.DAL.Member.LoadWhere(sql);
                    if (MemberEx.IsMemberNumberInUse(txtMemberNumber.Text))
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

            decimal numeric = 0;
            if (tabOthersLoaded)
            {
                errorProvider.SetError(tabOthers.txtCreditLimit, string.Empty);
                errorProvider.SetError(tabOthers.txtNormalItemDiscount, string.Empty);
                errorProvider.SetError(tabOthers.txtPaymentDiscount, string.Empty);
                errorProvider.SetError(tabOthers.txtPromotionItemDiscount, string.Empty);
                errorProvider.SetError(tabOthers.txtStaffQuota, string.Empty);

                if (!decimal.TryParse(tabOthers.txtCreditLimit.Text, out numeric))
                {
                    errorProvider.SetError(tabOthers.txtCreditLimit, Resources.Common.DigitalNeeded);
                    result = false;
                }
                else if (!decimal.TryParse(tabOthers.txtNormalItemDiscount.Text, out numeric))
                {
                    errorProvider.SetError(tabOthers.txtNormalItemDiscount, Resources.Common.DigitalNeeded);
                    result = false;
                }
                else if (!decimal.TryParse(tabOthers.txtPaymentDiscount.Text, out numeric))
                {
                    errorProvider.SetError(tabOthers.txtPaymentDiscount, Resources.Common.DigitalNeeded);
                    result = false;
                }
                else if (!decimal.TryParse(tabOthers.txtPromotionItemDiscount.Text, out numeric))
                {
                    errorProvider.SetError(tabOthers.txtPromotionItemDiscount, Resources.Common.DigitalNeeded);
                    result = false;
                }
                else if (!decimal.TryParse(tabOthers.txtStaffQuota.Text, out numeric))
                {
                    errorProvider.SetError(tabOthers.txtStaffQuota, Resources.Common.DigitalNeeded);
                    result = false;
                }
            }

            if (!result)
            {
                tabMember.SelectedIndex = 3;
            }

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oMember = ctx.Member.Find(this.MemberId);
                        if (oMember == null)
                        {
                            #region add new Member
                            oMember = new EF6.Member();

                            oMember.MemberId = Guid.NewGuid();
                            oMember.MemberNumber = txtMemberNumber.Text;

                            oMember.Status = (int)EnumHelper.Status.Active;
                            oMember.CreatedBy = ConfigHelper.CurrentUserId;
                            oMember.CreatedOn = DateTime.Now;

                            ctx.Member.Add(oMember);
                            #endregion
                        }
                        #region update Member core data
                        if ((Guid)tabGeneral.cboWorkplace.SelectedValue != Guid.Empty) oMember.WorkplaceId = (Guid)tabGeneral.cboWorkplace.SelectedValue;
                        if ((Guid)tabGeneral.cboPhoneBook.SelectedValue != Guid.Empty) oMember.ClassId = (Guid)tabGeneral.cboPhoneBook.SelectedValue;
                        if ((Guid)tabGeneral.cboGroup.SelectedValue != Guid.Empty) oMember.GroupId = (Guid)tabGeneral.cboGroup.SelectedValue;
                        oMember.MemberInitial = tabGeneral.txtNickName.Text;
                        if ((Guid)tabGeneral.cboSalutation.SelectedValue != Guid.Empty) oMember.SalutationId = (Guid)tabGeneral.cboSalutation.SelectedValue;
                        oMember.FirstName = tabGeneral.txtFirstName.Text;
                        oMember.LastName = tabGeneral.txtLastName.Text;
                        oMember.FullName = tabGeneral.txtLastName.Text + "," + tabGeneral.txtFirstName.Text;
                        oMember.FullName_Chs = tabGeneral.txtChineseName.Text;
                        oMember.FullName_Cht = tabGeneral.txtChineseName.Text;
                        if ((Guid)tabGeneral.cboJobTitle.SelectedValue != Guid.Empty) oMember.JobTitleId = (Guid)tabGeneral.cboJobTitle.SelectedValue;
                        oMember.AssignedTo = Guid.Empty;
                        oMember.Remarks = tabGeneral.txtRemarks.Text;
                        if (tabOthersLoaded) oMember.NormalDiscount = (tabOthers.txtNormalItemDiscount.Text.Length == 0) ? 0 : Convert.ToDecimal(tabOthers.txtNormalItemDiscount.Text);
                        oMember.DownloadToPOS = true;

                        oMember.Status = ctx.Entry(oMember).State == EntityState.Added ?
                            (int)EnumHelper.Status.Active : (int)EnumHelper.Status.Modified;

                        oMember.ModifiedBy = ConfigHelper.CurrentUserId;
                        oMember.ModifiedOn = DateTime.Now;
                        ctx.SaveChanges();
                        #endregion

                        this.MemberId = oMember.MemberId;

                        var memberId = oMember.MemberId;
                        #region SaveSmartTag(oMember.MemberId);
                        string key = "SmartTag";

                        for (int i = 0; i < tabGeneral.Controls.Count; i++)
                        {
                            string tagId = String.Empty;
                            string value = String.Empty;
                            Control Ctrl = tabGeneral.Controls[i];

                            if (Ctrl != null && Ctrl.Name.Contains(key))
                            {
                                #region prepare the update value
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
                                    // 2020.12.28 paulus: 如果係 combo box，個 value = dbo.SmartTag_Options.OptionId
                                    //value = cboTag.Text;
                                    value = (Guid)cboTag.SelectedValue == Guid.Empty ? "" : cboTag.SelectedValue.ToString();
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
                                #endregion

                                #region save the MemberSmartTag
                                Guid smartTagId = Guid.Empty;
                                if (Guid.TryParse(tagId, out smartTagId))
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
                                #endregion
                            }
                        }

                        #endregion

                        #region SaveAddress(oMember.MemberId);
                        if (tabAddressLoaded)
                        {
                            var oAddress = ctx.MemberAddress.Where(x => x.MemberId == memberId && x.AddressTypeId == (Guid)tabAddress.cboAddressType.SelectedValue).FirstOrDefault();
                            if (oAddress == null)
                            {
                                oAddress = new EF6.MemberAddress();
                                oAddress.AddressId = Guid.NewGuid();
                                oAddress.MemberId = memberId;
                                oAddress.AddressTypeId = new Guid(tabAddress.cboAddressType.SelectedValue.ToString());

                                ctx.MemberAddress.Add(oAddress);
                            }
                            if (tabAddressLoaded)
                            {
                                oAddress.Address = tabAddress.txtAddress.Text;
                                oAddress.PostalCode = tabAddress.txtPostalCode.Text;
                                oAddress.CountryId = new Guid(tabAddress.cboCountry.SelectedValue.ToString());
                                oAddress.ProvinceId = new Guid(tabAddress.cboProvince.SelectedValue.ToString());
                                oAddress.CityId = new Guid(tabAddress.cboCity.SelectedValue.ToString());
                                oAddress.District = tabAddress.txtDistrict.Text;
                                oAddress.Mailing = true;
                                oAddress.PhoneTag1 = (tabAddress.txtPhoneTag1.Tag == null) ? System.Guid.Empty : new System.Guid(tabAddress.txtPhoneTag1.Tag.ToString());
                                oAddress.PhoneTag1Value = tabAddress.txtPhoneTag1.Text;
                                oAddress.PhoneTag2 = (tabAddress.txtPhoneTag2.Tag == null) ? System.Guid.Empty : new System.Guid(tabAddress.txtPhoneTag2.Tag.ToString());
                                oAddress.PhoneTag2Value = tabAddress.txtPhoneTag2.Text;
                                oAddress.PhoneTag3 = (tabAddress.txtPhoneTag3.Tag == null) ? System.Guid.Empty : new System.Guid(tabAddress.txtPhoneTag3.Tag.ToString());
                                oAddress.PhoneTag3Value = tabAddress.txtPhoneTag3.Text;
                                oAddress.PhoneTag4 = (tabAddress.txtPhoneTag4.Tag == null) ? System.Guid.Empty : new System.Guid(tabAddress.txtPhoneTag4.Tag.ToString());
                                oAddress.PhoneTag4Value = tabAddress.txtPhoneTag4.Text;
                                oAddress.PhoneTag5 = (tabAddress.txtPhoneTag5.Tag == null) ? System.Guid.Empty : new System.Guid(tabAddress.txtPhoneTag5.Tag.ToString());
                                oAddress.PhoneTag5Value = tabAddress.txtPhoneTag5.Text;
                            }
                            ctx.SaveChanges();
                        }
                        #endregion

                        if (chkVIP.Checked && this.VipNumber.Trim().Length > 0)
                        {
                            #region SaveVipData(oMember.MemberId);
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
                            if (tabCardLoaded)
                            {
                                oVip.FORMER_PPNO = tabCard.txtFormerPPNumber.Text;
                                oVip.CARD_ACTIVE = tabCard.chkCardActived.Checked;
                                oVip.CARD_RECEIVE = tabCard.chkCardReceived.Checked;
                                oVip.CARD_NAME = tabCard.txtCardName.Text;
                                oVip.CARD_EXPIRE = tabCard.dtpCardExpiredOn.Value;
                                oVip.CARD_ISSUE = tabCard.dtpIssuedOn.Value;

                                oVip.CommencementDate = tabCard.dtpCommencementDate.Value;
                                oVip.MigrationDate = tabCard.dtpMigrationDate.Value;
                            }
                            if (tabOthersLoaded)
                            {
                                decimal credit = 0;
                                if (Decimal.TryParse(tabOthers.txtCreditLimit.Text.Trim(), out credit))
                                {
                                    oVip.CreditLimit = credit;
                                }

                                decimal terms = 0;
                                if (Decimal.TryParse(tabOthers.txtCreditTerms.Text.Trim(), out terms))
                                {
                                    oVip.CreditTerms = terms;
                                }

                                decimal paydisc = 0;
                                if (Decimal.TryParse(tabOthers.txtPaymentDiscount.Text.Trim(), out paydisc))
                                {
                                    oVip.PaymentDiscount = paydisc;
                                }

                                decimal staffQuota = 0;
                                if (Decimal.TryParse(tabOthers.txtStaffQuota.Text.Trim(), out staffQuota))
                                {
                                    oVip.StaffQuota = staffQuota;
                                }

                                oVip.AddOnDiscount = tabOthers.chkAddOnDiscount.Checked;
                            }
                            ctx.SaveChanges();

                            var vipId = oVip.MemberVipId;

                            #region this.SaveVipLineOfOperation(vipId);
                            var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == vipId).FirstOrDefault();
                            if (oVipLoo == null)
                            {
                                oVipLoo = new EF6.MemberVipLineOfOperation();
                                oVipLoo.MemberVipId = vipId;
                                oVipLoo.VipLooId = Guid.NewGuid();

                                ctx.MemberVipLineOfOperation.Add(oVipLoo);
                            }
                            oVipLoo.LineOfOperationId = new Guid(cboLineOfOperation.SelectedValue.ToString());

                            if (tabOthersLoaded)
                            {
                                oVipLoo.NormalDiscount = (tabOthers.txtNormalItemDiscount.Text.Length == 0) ? 0 : Convert.ToDecimal(tabOthers.txtNormalItemDiscount.Text);
                                oVipLoo.PromotionDiscount = (tabOthers.txtPromotionItemDiscount.Text.Length == 0) ? 0 : Convert.ToDecimal(tabOthers.txtPromotionItemDiscount.Text);
                            }

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

                            #region Others Info
                            if (tabOthersLoaded)
                            {
                                oSupplement.CustomerNumber = tabOthers.txtCustomerInfo1.Text;
                                oSupplement.BRANCH = tabOthers.txtCustomerInfo2.Text;
                                oSupplement.Remarks1 = tabOthers.txtRemarks1.Text;
                                oSupplement.Remarks2 = tabOthers.txtRemarks2.Text;
                                oSupplement.Remarks3 = tabOthers.txtRemarks3.Text;
                                oSupplement.Nature = tabOthers.cboNature.Text;
                                oSupplement.Memo = tabMisc.txtMemo.Text;
                            }
                            #endregion

                            #region Marketing Info
                            if (tabMarketingLoaded)
                            {
                                oSupplement.MostVisitedMalls1 = tabMarketing.txtMostVisitedMalls1.Text;
                                oSupplement.MostVisitedMalls2 = tabMarketing.txtMostVisitedMalls2.Text;
                                oSupplement.MostVisitedMalls3 = tabMarketing.txtMostVisitedMalls3.Text;

                                oSupplement.MostBoughtBrands1 = tabMarketing.txtMostBoughtBrands1.Text;
                                oSupplement.MostBoughtBrands2 = tabMarketing.txtMostBoughtBrands2.Text;
                                oSupplement.MostBoughtBrands3 = tabMarketing.txtMostBoughtBrands3.Text;

                                oSupplement.MostReadMagazine1 = tabMarketing.txtMostReadMagazine1.Text;
                                oSupplement.MostReadMagazine2 = tabMarketing.txtMostReadMagazine2.Text;
                                oSupplement.MostReadMagazine3 = tabMarketing.txtMostReadMagazine3.Text;

                                oSupplement.MostUsedCreditCards1 = tabMarketing.txtMostUsedCreditCards1.Text;
                                oSupplement.MostUsedCreditCards2 = tabMarketing.txtMostUsedCreditCards2.Text;
                                oSupplement.MostUsedCreditCards3 = tabMarketing.txtMostUsedCreditCards3.Text;
                            }
                            #endregion

                            #region Photo
                            if (tabMiscLoaded) oSupplement.Photo = tabMisc.txtPicFileName.Text;
                            #endregion

                            ctx.SaveChanges();
                            #endregion

                            #endregion
                        }

                        scope.Commit();
                        result = true;

                        #region write Log
                        RT2020.Controls.Log4net.LogInfo(
                            ctx.Entry(oMember).State == EntityState.Added ?
                            RT2020.Controls.Log4net.LogAction.Create : RT2020.Controls.Log4net.LogAction.Update,
                            oMember.ToString());
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
        }
        /**
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
                    #region prepare the update value
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
                    #endregion

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
            using (var ctx = new EF6.RT2020Entities())
            {
                string sql = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + address.cboAddressType.SelectedValue.ToString() + "'";
                var oAddress = ctx.MemberAddress.Where(x => x.MemberId == memberId && x.AddressTypeId == (Guid)address.cboAddressType.SelectedValue).FirstOrDefault();
                if (oAddress == null)
                {
                    oAddress = new EF6.MemberAddress();
                    oAddress.AddressId = Guid.NewGuid();
                    oAddress.MemberId = memberId;
                    oAddress.AddressTypeId = new Guid(address.cboAddressType.SelectedValue.ToString());

                    ctx.MemberAddress.Add(oAddress);
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

                ctx.SaveChanges();
            }
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
        */
        #endregion

        #region Load Member Info
        private void LoadGeneral()
        {
            var oMember = MemberEx.Get(this.MemberId);
            if (oMember != null)
            {
                txtMemberNumber.Text = oMember.MemberNumber;
                tabGeneral.cboPhoneBook.SelectedValue = oMember.ClassId.HasValue ? oMember.ClassId : Guid.Empty;
                tabGeneral.cboWorkplace.SelectedValue = oMember.WorkplaceId.HasValue ? oMember.WorkplaceId : Guid.Empty;
                tabGeneral.cboGroup.SelectedValue = oMember.GroupId.HasValue ? oMember.GroupId : Guid.Empty;
                tabGeneral.txtNickName.Text = oMember.MemberInitial;
                tabGeneral.cboSalutation.SelectedValue = oMember.SalutationId.HasValue ? oMember.SalutationId : Guid.Empty;
                tabGeneral.txtFirstName.Text = oMember.FirstName;
                tabGeneral.txtLastName.Text = oMember.LastName;
                tabGeneral.txtChineseName.Text = oMember.FullName_Chs;
                tabGeneral.cboJobTitle.SelectedValue = oMember.JobTitleId.HasValue ? oMember.JobTitleId : Guid.Empty;
                tabGeneral.txtRemarks.Text = oMember.Remarks;
                //tabOthers.txtNormalItemDiscount.Text = oMember.NormalDiscount.HasValue ? oMember.NormalDiscount.Value.ToString("n2") : "";

                tabGeneral.txtLastUpdatedBy.Text = StaffEx.GetStaffNumberById(oMember.ModifiedBy);
                tabGeneral.txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(oMember.ModifiedOn, false);
                tabGeneral.txtCreatedOn.Text = DateTimeHelper.DateTimeToString(oMember.CreatedOn, false);
                tabGeneral.txtStatus.Text = Enum.GetName(typeof(EnumHelper.Status), oMember.Status);

                LoadSmartTag(oMember.MemberId);

                LoadHeaderData(oMember.MemberId);

                #region Disable edit when status is Inactive (-2) or Deleted (-1)
                if (oMember.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                    oMember.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                {
                    tabGeneral.cboSalutation.Enabled = false;
                    tabGeneral.txtSmartTag10.Enabled = false;
                    tabGeneral.txtNickName.Enabled = false;
                    tabGeneral.txtFirstName.Enabled = false;
                    tabGeneral.txtLastName.Enabled = false;
                    tabGeneral.txtChineseName.Enabled = false;
                    tabGeneral.cboJobTitle.Enabled = false;
                    tabGeneral.txtSmartTag13.Enabled = false;
                    tabGeneral.txtSmartTag14.Enabled = false;
                    tabGeneral.cboSmartTag11.Enabled = false;
                    tabGeneral.txtSmartTag12.Enabled = false;
                    tabGeneral.txtRemarks.Enabled = false;
                    tabGeneral.cboWorkplace.Enabled = false;
                    tabGeneral.cboSmartTag1.Enabled = false;
                    tabGeneral.cboSmartTag2.Enabled = false;
                    tabGeneral.cboSmartTag3.Enabled = false;
                    tabGeneral.cboSmartTag4.Enabled = false;
                    tabGeneral.txtSmartTag5.Enabled = false;
                    tabGeneral.txtSmartTag6.Enabled = false;
                    tabGeneral.txtSmartTag7.Enabled = false;
                    tabGeneral.dtpSmartTag8.Enabled = false;
                    tabGeneral.dtpSmartTag9.Enabled = false;
                    tabGeneral.cboPhoneBook.Enabled = false;
                }
                #endregion
            }
        }

        private void LoadSmartTag(Guid memberId)
        {
            string sql = "MemberId = '" + memberId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";

            for (int i = 0; i < tabGeneral.Controls.Count; i++)
            {
                string tagId = string.Empty;
                string value = string.Empty;
                Control Ctrl = tabGeneral.Controls[i];

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
                                        var id = Guid.Empty;
                                        if (Guid.TryParse(oTag.SmartTagValue, out id))
                                        {
                                            ComboBox cboTag = Ctrl as ComboBox;
                                            // 2020.12.28 paulus: 如果係 combo box，個 value = dbo.SmartTag_Options.OptionId
                                            //cboTag.Text = oTag.SmartTagValue;
                                            cboTag.SelectedValue = id;
                                        }
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

        private void LoadAddress(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oAddressList = ctx.MemberAddress.Where(x => x.MemberId == memberId).AsNoTracking().ToList();

                // Default to show AddressTypeCode = ADDR_EN
                if (oAddressList.Count > 0)
                {
                    // Default to show AddressTypeCode = ADDR_EN
                    int foundRow = 0;
                    bool foundAddrEn = false;
                    Guid addressTypeId_ADDR_EN = MemberAddressTypeEx.GetIdByCode("ADDR_EN");
                    foreach (var oAddress in oAddressList)
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
                    tabAddress.cboAddressType.SelectedValue = oAddressList[foundRow].AddressTypeId;
                    tabAddress.txtAddress.Text = oAddressList[foundRow].Address;
                    tabAddress.txtPostalCode.Text = oAddressList[foundRow].PostalCode;
                    tabAddress.cboCountry.SelectedValue = oAddressList[foundRow].CountryId.HasValue ? oAddressList[foundRow].CountryId : Guid.Empty;
                    tabAddress.cboProvince.SelectedValue = oAddressList[foundRow].ProvinceId.HasValue ? oAddressList[foundRow].ProvinceId : Guid.Empty;
                    tabAddress.cboCity.SelectedValue = oAddressList[foundRow].CityId.HasValue ? oAddressList[foundRow].CityId : Guid.Empty;
                    tabAddress.txtDistrict.Text = oAddressList[foundRow].District;

                    tabAddress.txtPhoneTag1.Text = oAddressList[foundRow].PhoneTag1Value;
                    tabAddress.txtPhoneTag2.Text = oAddressList[foundRow].PhoneTag2Value;
                    tabAddress.txtPhoneTag3.Text = oAddressList[foundRow].PhoneTag3Value;
                    tabAddress.txtPhoneTag4.Text = oAddressList[foundRow].PhoneTag4Value;
                    tabAddress.txtPhoneTag5.Text = oAddressList[foundRow].PhoneTag5Value;

                    #region Disable edit when status is Inactive (-2) or Deleted (-1)
                    if (oAddressList[0].Member.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                        oAddressList[0].Member.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                    {
                        tabAddress.cboAddressType.Enabled = false;
                        tabAddress.txtAddress.Enabled = false;
                        tabAddress.txtDistrict.Enabled = false;
                        tabAddress.txtPostalCode.Enabled = false;
                        tabAddress.cboCountry.Enabled = false;
                        tabAddress.cboProvince.Enabled = false;
                        tabAddress.cboCity.Enabled = false;
                        tabAddress.txtPhoneTag1.Enabled = false;
                        tabAddress.txtPhoneTag2.Enabled = false;
                        tabAddress.txtPhoneTag3.Enabled = false;
                        tabAddress.txtPhoneTag4.Enabled = false;
                        tabAddress.txtPhoneTag5.Enabled = false;
                    }
                    #endregion
                }
                else
                {
                    tabAddress.cboAddressType.SelectedValue = MemberAddressTypeEx.GetIdByCode("ADDR_EN");
                }
            }
        }

        private void LoadHeaderData(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).AsNoTracking().FirstOrDefault();
                if (oVip != null)
                {
                    chkVIP.Text = "VIP #: " + oVip.VipNumber;
                    chkVIP.Checked = true;
                    chkVIP.Enabled = false;

                    this.VipNumber = oVip.VipNumber;

                    var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == oVip.MemberVipId).AsNoTracking().FirstOrDefault();
                    if (oVipLoo != null)
                    {
                        cboLineOfOperation.SelectedValue = oVipLoo.LineOfOperationId;
                    }

                    #region Disable edit when status is Inactive (-2) or Deleted (-1)
                    if (oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                        oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                    {
                        this.cboLineOfOperation.Enabled = false;

                        this.tbWizardAction.Visible = false;
                        this.tbWizardAction.Enabled = false;
                    }
                    #endregion
                }
            }
        }

        private void LoadCard(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).AsNoTracking().FirstOrDefault();
                if (oVip != null)
                {
                    tabCard.txtFormerPPNumber.Text = oVip.FORMER_PPNO;
                    tabCard.chkCardActived.Checked = oVip.CARD_ACTIVE;
                    tabCard.chkCardReceived.Checked = oVip.CARD_RECEIVE;
                    tabCard.txtCardName.Text = oVip.CARD_NAME;
                    tabCard.dtpCardExpiredOn.Value = oVip.CARD_EXPIRE.Value;
                    tabCard.dtpIssuedOn.Value = oVip.CARD_ISSUE.Value;

                    tabCard.dtpCommencementDate.Value = oVip.CommencementDate.Value;
                    tabCard.dtpMigrationDate.Value = oVip.MigrationDate.Value;

                    #region Disable edit when status is Inactive (-2) or Deleted (-1)
                    if (oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                        oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                    {
                        tabCard.txtFormerPPNumber.Enabled = false;
                        tabCard.dtpCommencementDate.Enabled = false;
                        tabCard.dtpMigrationDate.Enabled = false;
                        tabCard.dtpIssuedOn.Enabled = false;
                        tabCard.dtpCardExpiredOn.Enabled = false;
                        tabCard.txtCardName.Enabled = false;
                        tabCard.chkCardReceived.Enabled = false;
                        tabCard.chkCardActived.Enabled = false;
                    }
                    #endregion
                }
            }
        }

        private void LoadOthers(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).AsNoTracking().FirstOrDefault();
                if (oVip != null)
                {
                    tabOthers.txtNormalItemDiscount.Text = oVip.Member.NormalDiscount.HasValue ? oVip.Member.NormalDiscount.Value.ToString("n2") : "";

                    var oVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == oVip.MemberVipId).AsNoTracking().FirstOrDefault();
                    if (oVipLoo != null)
                    {
                        //cboLineOfOperation.SelectedValue = oVipLoo.LineOfOperationId;
                        tabOthers.txtPromotionItemDiscount.Text = oVipLoo.PromotionDiscount.Value.ToString("n2");
                    }

                    var oVipSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == oVip.MemberVipId).FirstOrDefault();
                    if (oVipSupplement != null)
                    {
                        tabOthers.txtCustomerInfo1.Text = oVipSupplement.CustomerNumber;
                        tabOthers.txtCustomerInfo2.Text = oVipSupplement.BRANCH;
                        tabOthers.txtRemarks1.Text = oVipSupplement.Remarks1;
                        tabOthers.txtRemarks2.Text = oVipSupplement.Remarks2;
                        tabOthers.txtRemarks3.Text = oVipSupplement.Remarks3;
                        tabOthers.cboNature.Text = oVipSupplement.Nature;
                    }

                    #region Disable edit when status is Inactive (-2) or Deleted (-1)
                    if (oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                        oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                    {
                        tabOthers.txtCreditLimit.Enabled = false;
                        tabOthers.txtCreditTerms.Enabled = false;
                        tabOthers.txtPaymentDiscount.Enabled = false;
                        tabOthers.txtCustomerInfo1.Enabled = false;
                        tabOthers.txtCustomerInfo2.Enabled = false;
                        tabOthers.txtCustomerInfo3.Enabled = false;
                        tabOthers.txtNormalItemDiscount.Enabled = false;
                        tabOthers.txtPromotionItemDiscount.Enabled = false;
                        tabOthers.chkAddOnDiscount.Enabled = false;
                        tabOthers.txtStaffQuota.Enabled = false;
                        tabOthers.txtRemarks1.Enabled = false;
                        tabOthers.txtRemarks2.Enabled = false;
                        tabOthers.txtRemarks3.Enabled = false;
                    }
                    #endregion
                }
            }
        }

        private void LoadMisc(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).AsNoTracking().FirstOrDefault();
                if (oVip != null)
                {
                    var oVipSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == oVip.MemberVipId).FirstOrDefault();
                    if (oVipSupplement != null)
                    {
                        tabMisc.txtPicFileName.Text = oVipSupplement.Photo;

                        // 2009.12.29 david: 如果为网络路径，则直接显示。
                        string photoPath = Path.Combine(Path.Combine(Context.Config.GetDirectory("RTImages"), "Product"), oVipSupplement.Photo);
                        try
                        {
                            Uri uri = new Uri(oVipSupplement.Photo);
                            if (uri.IsUnc)
                            {
                                tabMisc.imgMemberPicture.ImageName = uri.LocalPath;
                            }
                            else
                            {
                                tabMisc.imgMemberPicture.ImageName = photoPath;
                            }
                        }
                        catch { }
                        finally
                        {
                            tabMisc.imgMemberPicture.ImageName = photoPath;
                        }

                        tabMisc.txtMemo.Text = oVipSupplement.Memo;
                    }

                    #region Disable edit when status is Inactive (-2) or Deleted (-1)
                    if (oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                        oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                    {
                        tabMisc.txtMemo.Enabled = false;
                        tabMisc.txtPicFileName.Enabled = false;
                        tabMisc.btnFindPic.Enabled = false;
                        tabMisc.btnDelete.Enabled = false;
                        tabMisc.btnRefresh.Enabled = false;
                    }
                    #endregion
                }
            }
        }

        private void LoadMarketing(Guid memberId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oVip = ctx.MemberVipData.Where(x => x.MemberId == memberId).AsNoTracking().FirstOrDefault();
                if (oVip != null)
                {
                    var oVipSupplement = ctx.MemberVipSupplement.Where(x => x.MemberVipId == oVip.MemberVipId).FirstOrDefault();
                    if (oVipSupplement != null)
                    {
                        tabMarketing.txtMostVisitedMalls1.Text = oVipSupplement.MostVisitedMalls1;
                        tabMarketing.txtMostVisitedMalls2.Text = oVipSupplement.MostVisitedMalls2;
                        tabMarketing.txtMostVisitedMalls3.Text = oVipSupplement.MostVisitedMalls3;

                        tabMarketing.txtMostBoughtBrands1.Text = oVipSupplement.MostBoughtBrands1;
                        tabMarketing.txtMostBoughtBrands2.Text = oVipSupplement.MostBoughtBrands2;
                        tabMarketing.txtMostBoughtBrands3.Text = oVipSupplement.MostBoughtBrands3;

                        tabMarketing.txtMostReadMagazine1.Text = oVipSupplement.MostReadMagazine1;
                        tabMarketing.txtMostReadMagazine2.Text = oVipSupplement.MostReadMagazine2;
                        tabMarketing.txtMostReadMagazine3.Text = oVipSupplement.MostReadMagazine3;

                        tabMarketing.txtMostUsedCreditCards1.Text = oVipSupplement.MostUsedCreditCards1;
                        tabMarketing.txtMostUsedCreditCards2.Text = oVipSupplement.MostUsedCreditCards2;
                        tabMarketing.txtMostUsedCreditCards3.Text = oVipSupplement.MostUsedCreditCards3;
                    }


                    #region Disable edit when status is Inactive (-2) or Deleted (-1)
                    if (oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d")) ||
                        oVip.Member.Status == Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                    {
                        tabMarketing.txtMostVisitedMalls1.Enabled = false;
                        tabMarketing.txtMostVisitedMalls2.Enabled = false;
                        tabMarketing.txtMostVisitedMalls3.Enabled = false;
                        tabMarketing.txtMostBoughtBrands1.Enabled = false;
                        tabMarketing.txtMostBoughtBrands2.Enabled = false;
                        tabMarketing.txtMostBoughtBrands3.Enabled = false;
                        tabMarketing.txtMostReadMagazine1.Enabled = false;
                        tabMarketing.txtMostReadMagazine2.Enabled = false;
                        tabMarketing.txtMostReadMagazine3.Enabled = false;
                        tabMarketing.txtMostUsedCreditCards1.Enabled = false;
                        tabMarketing.txtMostUsedCreditCards2.Enabled = false;
                        tabMarketing.txtMostUsedCreditCards3.Enabled = false;
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oMember = ctx.Member.Find(this.MemberId);
                if (oMember != null)
                {
                    oMember.Status = Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d"));
                    oMember.DownloadToPOS = true;

                    ctx.SaveChanges();

                    // log activity
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, oMember.ToString());
                }
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
        #endregion

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Verify() && VerifyNumbers())
                {
                    Save();
                    if (this.MemberId != System.Guid.Empty)
                    {
                        Helper.DesktopHelper.RefreshMainList<MemberList>();
                        MessageBox.Show("Success!", "Save Result");

                        this.Close();
                        MemberWizard wizard = new MemberWizard();
                        wizard.MemberId = this.MemberId;
                        wizard.EditMode = EnumHelper.EditMode.Edit;
                        wizard.ShowDialog();
                    }
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Verify() && VerifyNumbers())
                {
                    Save();
                    if (this.MemberId != System.Guid.Empty)
                    {
                        Helper.DesktopHelper.RefreshMainList<MemberList>();
                        this.Close();
                        MemberWizard wizard = new MemberWizard();
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
                if (Verify() && VerifyNumbers())
                {
                    Save();
                    if (this.MemberId != System.Guid.Empty && Verify())
                    {
                        Helper.DesktopHelper.RefreshMainList<MemberList>();
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
            tabGeneral.cboSalutation.Focus();
        }

        private void tabMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tabMember.SelectedTab.Name;
            LoadTabControl(tabMember.SelectedIndex);
        }
    }
}