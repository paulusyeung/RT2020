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

namespace RT2020.Helper
{
    public class SmartTagHelper
    {
        Control upCtrl = null;

        public SmartTagHelper(Control ctrl)
        {
            upCtrl = ctrl;
        }

        #region SmartTags

        public List<EF6.SmartTag4Member> MemberSmartTagList = null;
        public List<EF6.SmartTag4Staff> StaffSmartTagList = null;
        public List<EF6.SmartTag4Supplier> SupplierSmartTagList = null;
        public List<EF6.SmartTag4Workplace> WorkplaceSmartTagList = null;

        #endregion

        #region Set SmartTag Labels and TextBox Tags
        /// <summary>
        /// 根據 Smart Tag 的 Prioirty 設置 Control.Tag = TagId, Control.Text = TagName_Locale
        /// Control.Tag 將於 Load Data 和 SaveData 中用到
        /// </summary>
        public void SetSmartTags()
        {
            if (MemberSmartTagList != null)
            {
                SetMemberSmartTag();
            }

            if (StaffSmartTagList != null)
            {
                SetStaffSmartTag();
            }

            if (SupplierSmartTagList != null)
            {
                SetSupplierSmartTag();
            }

            if (WorkplaceSmartTagList != null)
            {
                SetWorkplaceSmartTag();
            }
        }

        string key = "SmartTag{0}";

        private void SetMemberSmartTag()
        {
            int iCount = 1;
            foreach (var oTag in MemberSmartTagList)
            {
                SetSmartTag(string.Format(key, iCount.ToString()), oTag.TagId, oTag.TagName, oTag.TagName_Chs, oTag.TagName_Cht);
                iCount++;
            }
        }

        private void SetStaffSmartTag()
        {
            int iCount = 1;
            foreach (var oTag in StaffSmartTagList)
            {
                SetSmartTag(string.Format(key, iCount.ToString()), oTag.TagId, oTag.TagName, oTag.TagName_Chs, oTag.TagName_Cht);
                iCount++;
            }
        }

        private void SetSupplierSmartTag()
        {
            int iCount = 1;
            foreach (var oTag in SupplierSmartTagList)
            {
                SetSmartTag(string.Format(key, iCount.ToString()), oTag.TagId, oTag.TagName, oTag.TagName_Chs, oTag.TagName_Cht);
                iCount++;
            }
        }

        private void SetWorkplaceSmartTag()
        {
            int iCount = 1;
            foreach (var oTag in WorkplaceSmartTagList)
            {
                SetSmartTag(string.Format(key, iCount.ToString()), oTag.TagId, oTag.TagName, oTag.TagName_Chs, oTag.TagName_Cht);
                iCount++;
            }
        }

        private void SetSmartTag(string key, object tag, string name, string name_chs, string name_cht)
        {
            #region displayName 根據 locale 改變
            var displayName = "";
            switch (LanguageHelper.CurrentLanguageMode)
            {
                case LanguageHelper.LanguageMode.Alt1:
                    displayName = name_chs + "：";
                    break;
                case LanguageHelper.LanguageMode.Alt2:
                    displayName = name_cht + "：";
                    break;
                case LanguageHelper.LanguageMode.Default:
                default:
                    displayName = name + ":";
                    break;
            }
            #endregion

            Control Ctrl = null;
            for (int i = 0; i < upCtrl.Controls.Count; i++)
            {
                Ctrl = upCtrl.Controls[i];

                if (Ctrl != null)
                {
                    if (Ctrl.Name.Contains(key))
                    {
                        if (Ctrl.GetType().Equals(typeof(Label)))
                        {
                            Label lblTag = Ctrl as Label;
                            lblTag.Text = displayName;
                            lblTag.Visible = true;
                        }

                        if (Ctrl.GetType().Equals(typeof(TextBox)))
                        {
                            TextBox txtTag = Ctrl as TextBox;
                            txtTag.Tag = tag;
                            txtTag.Visible = true;
                        }

                        if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                        {
                            MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                            txtTag.Tag = tag;
                            txtTag.Visible = true;
                        }

                        if (Ctrl.GetType().Equals(typeof(ComboBox)))
                        {
                            ComboBox cboTag = Ctrl as ComboBox;
                            cboTag.Tag = tag;
                            cboTag.Visible = true;
                        }

                        if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                        {
                            DateTimePicker dtpTag = Ctrl as DateTimePicker;
                            dtpTag.Tag = tag;
                            dtpTag.Visible = true;
                        }
                    }
                }
            }
        }
        #endregion
    }
}