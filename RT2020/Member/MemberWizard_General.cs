#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.Controls;
using RT2020.Helper;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_General : UserControl
    {
        //2014.01.08 paulus: 根據 Opera 嘅 RT2000，Member Group = Workplace 嘅 Shop

        #region public Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _MemberId = Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        #endregion

        public MemberWizard_General()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();
            InitialSmartTags();
            FillComboList();
        }

        #region SetCaptions & SetAttributes
        private void SetCaptions()
        {
            lblSalutation.Text = WestwindHelper.GetWordWithColon("member.general.salutation", "Model");
            //lblSmartTag10.Text = WestwindHelper.GetWordWithColon("member.general.id", "Model");
            lblNickName.Text = WestwindHelper.GetWordWithColon("member.general.nickname", "Model");
            lblFirstName.Text = WestwindHelper.GetWordWithColon("member.general.firstname", "Model");
            lblLastName.Text = WestwindHelper.GetWordWithColon("member.general.lastname", "Model");
            lblChineseName.Text = WestwindHelper.GetWordWithColon("member.general.alias", "Model");
            lblJobTitle.Text = WestwindHelper.GetWordWithColon("member.general.job", "Model");

            lblRemarks.Text = WestwindHelper.GetWordWithColon("member.general.remarks", "Model");
            lblWorkplace.Text = WestwindHelper.GetWordWithColon("member.general.shop", "Model");

            lblCreatedOn.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblLastUpdated.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblStatus.Text = WestwindHelper.GetWordWithColon("glossary.status", "General");

            lblPhoneBook.Text = WestwindHelper.GetWordWithColon("memberClass", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable saluation label
            lblSalutation.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSalutation.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSalutation.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.SalutationWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillSalutationList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable job title label
            lblJobTitle.AutoSize = true;                        // 減少 whitespace，有字嘅位置先可以 click
            lblJobTitle.Cursor = Cursors.Hand;                  // cursor over 顯示 hand cursor
            lblJobTitle.Click += (s, e) =>                      // 彈出 wizard
            {
                var dialog = new Settings.JobTitleWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillJobTitleList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable phonebook label
            lblPhoneBook.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneBook.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneBook.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new MemberClassWizard();
                dialog.FormClosed += (sender, eventArgs) =>    // 關閉後 refresh 個 combo box items
                {
                    FillMemberClass();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void label_OnClick(object sender, EventArgs e)
        {
            var dialog = new Settings.SalutationWizard();
            dialog.FormClosed += (eventSender, eventArgs) =>
            {
                FillSalutationList();
            };
            dialog.ShowDialog();
        }
        #endregion

        #region initialize Smart Tags
        private void InitialSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            var smartTagList = ModelEx.SmartTag4MemberEx.GetListOrderBy(orderBy, true);

            SmartTagHelper oTag = new SmartTagHelper(this);
            oTag.MemberSmartTagList = smartTagList;
            oTag.SetSmartTags();

            #region 設定 clickable smart tag labels
            lblSmartTag1.AutoSize = true;               // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag1.Cursor = Cursors.Hand;         // cursor over 顯示 hand cursor
            lblSmartTag1.Tag = 1;                       // Tag = Priority
            lblSmartTag1.Click += smartLabel_OnClick;        // 綁定 click event

            lblSmartTag2.AutoSize = true;               // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag2.Cursor = Cursors.Hand;         // cursor over 顯示 hand cursor
            lblSmartTag2.Tag = 2;                       // Tag = Priority
            lblSmartTag2.Click += smartLabel_OnClick;        // 綁定 click event

            lblSmartTag3.AutoSize = true;               // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag3.Cursor = Cursors.Hand;         // cursor over 顯示 hand cursor
            lblSmartTag3.Tag = 3;                       // Tag = Priority
            lblSmartTag3.Click += smartLabel_OnClick;        // 綁定 click event

            lblSmartTag4.AutoSize = true;               // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag4.Cursor = Cursors.Hand;         // cursor over 顯示 hand cursor
            lblSmartTag4.Tag = 4;                       // Tag = Priority
            lblSmartTag4.Click += smartLabel_OnClick;        // 綁定 click event

            lblSmartTag11.AutoSize = true;              // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag11.Cursor = Cursors.Hand;        // cursor over 顯示 hand cursor
            lblSmartTag11.Tag = 11;                     // Tag = Priority
            lblSmartTag11.Click += smartLabel_OnClick;       // 綁定 click event
            #endregion
        }

        private void smartLabel_OnClick(object sender, EventArgs e)
        {
            var label = (Label)sender;
            var priority = (int)label.Tag;
            var id = ModelEx.SmartTag4MemberEx.GetIdByPriority(priority);

            var dialog = new SmartTag4Member_OptionsWizard();
            dialog.FormClosed += smartDialog_Closed;
            dialog.SmartTagId = id;
            dialog.ShowDialog();
        }

        private void smartDialog_Closed(object sender, FormClosedEventArgs e)
        {
            var dialog = (SmartTag4Member_OptionsWizard)sender;
            var smartTag = ModelEx.SmartTag4MemberEx.Get(dialog.SmartTagId);

            switch (smartTag.Priority)
            {
                case 1:
                    ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag1, 1);
                    break;
                case 2:
                    ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag2, 2);
                    break;
                case 3:
                    ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag3, 3);
                    break;
                case 4:
                    ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag4, 4);
                    break;
            }
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillSalutationList();
            FillJobTitleList();
            FillMemberClass();
            FillMemberGroupList();
            FillWorkplace();

            ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag1, 1);
            ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag2, 2);
            ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag3, 3);
            ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag4, 4);
            ModelEx.SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboSmartTag11, 11);
        }

        private void FillSalutationList()
        {
            ModelEx.SalutationEx.LoadCombo(ref cboSalutation, "SalutationName", true, true, String.Empty, String.Empty);
        }

        private void FillJobTitleList()
        {
            ModelEx.JobTitleEx.LoadCombo(ref cboJobTitle, "JobTitleName", true, true, String.Empty, String.Empty);
        }

        private void FillMemberClass()
        {
            ModelEx.MemberClassEx.LoadCombo(ref cboPhoneBook, "ClassName", true, true, String.Empty, String.Empty);
        }

        private void FillMemberGroupList()
        {
            ModelEx.MemberGroupEx.LoadCombo(ref cboGroup, "GroupName", true, true, String.Empty, String.Empty);
        }

        private void FillWorkplace()
        {
            cboWorkplace.Items.Clear();
            RT2020.Controls.Workplace.LoadComboBox_Shops(ref cboWorkplace);
            cboWorkplace.SelectedIndex = 0;
        }
        #endregion

        private void cboPhoneBook_LostFocus(object sender, EventArgs e)
        {
            cboSalutation.Focus();
        }
    }
}