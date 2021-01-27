#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_Others : UserControl
    {
        #region Properties
        private Guid _MemberId = System.Guid.Empty;
        public Guid MemberId
        {
            get { return _MemberId; }
            set { _MemberId = value; }
        }
        #endregion

        public MemberWizard_Others()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();
            FillComboBox_Nature();
        }

        #region SetCaptions & SetAttributes
        private void SetCaptions()
        {
            lblCreditLimit.Text = WestwindHelper.GetWordWithColon("member.others.creditLimit", "Model");
            lblCreditTerms.Text = WestwindHelper.GetWordWithColon("member.others.creditTerms", "Model");
            lblPaymentDiscount.Text = WestwindHelper.GetWordWithColon("member.others.paymentDiscount", "Model");
            lblCustomerInfo.Text = WestwindHelper.GetWordWithColon("member.others.customerInfo", "Model");
            lblDiscount.Text = WestwindHelper.GetWordWithColon("member.others.discount", "Model");
            lblNormalItemDiscountPcn.Text = string.Format("%({0})", WestwindHelper.GetWord("member.others.regularItem", "Model"));
            lblPromotionItemDiscountPcn.Text = string.Format("%({0})", WestwindHelper.GetWord("member.others.promotionalItem", "Model"));
            lblAddOnDiscount.Text = WestwindHelper.GetWordWithColon("member.others.addonDiscount", "Model");
            lblStaffQuota.Text = WestwindHelper.GetWordWithColon("member.others.staffQuota", "Model");
            lblRemarks1.Text = WestwindHelper.GetWordWithColon("member.others.remarks1", "Model");
            lblRemarks2.Text = WestwindHelper.GetWordWithColon("member.others.remarks2", "Model");
            lblRemarks3.Text = WestwindHelper.GetWordWithColon("member.others.remarks3", "Model");
            lblNature.Text = WestwindHelper.GetWordWithColon("member.others.nature", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable Nature label
            lblNature.AutoSize = true;                     // 減少 whitespace，有字嘅位置先可以 click
            lblNature.Cursor = Cursors.Hand;               // cursor over 顯示 hand cursor
            lblNature.Click += (s, e) =>                   // 彈出 wizard
            {
                var dialog = new SmartTag4Member_OptionsWizard();
                dialog.SmartTagId = ModelEx.SmartTag4MemberEx.GetIdByPriority(99);
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillComboBox_Nature();
                };
                dialog.ShowDialog();
            };
            #endregion
        }
        #endregion

        private void FillComboBox_Nature()
        {
            var id = ModelEx.SmartTag4MemberEx.GetIdByPriority(99); // member nature
            var textFields = new string[] { "OptionCode", "OptionName" };
            var pattern = "{0} - {1}";
            var where = string.Format("TagId = '{0}'", id.ToString());
            var orderBy = new string[] { "OptionCode" };

            ModelEx.SmartTag4Member_OptionsEx.LoadCombo(ref cboNature, textFields, pattern, true, true, "", where, orderBy);
        }
    }
}