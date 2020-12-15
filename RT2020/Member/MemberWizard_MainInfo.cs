#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using RT2020.Controls;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_MainInfo : UserControl
    {
        //2014.01.08 paulus: 根據 Opera 嘅 RT2000，Member Group = Workplace 嘅 Shop

        public MemberWizard_MainInfo()
        {
            InitializeComponent();
            InitialSmartTags();
            FillComboList();
        }

        private void InitialSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            var smartTagList = ModelEx.SmartTag4MemberEx.GetListOrderBy(orderBy, true);

            SmartTag oTag = new SmartTag(this);
            oTag.MemberSmartTagList = smartTagList;
            oTag.SetSmartTags();
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
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillSalutationList();
            FillJobTitleList();
            FillMemberClass();
            FillMemberGroupList();
            FillWorkplace();
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
            cboPhoneBook.Items.Clear();

            MemberClass.LoadCombo(ref cboPhoneBook, "ClassName", true, true, String.Empty, String.Empty);
            cboPhoneBook.SelectedIndex = 0;
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