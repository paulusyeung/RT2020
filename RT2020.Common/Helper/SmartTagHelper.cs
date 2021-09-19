#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;
using RT2020.Common.Helper;


#endregion

namespace RT2020.Common.Helper
{
    public class SmartTagHelper
    {
        Control upCtrl = null;
        string key = "SmartTag{0}";

        #region declare Smart Tag List
        public List<EF6.SmartTag4Member> MemberSmartTagList = null;
        public List<EF6.SmartTag4Staff> StaffSmartTagList = null;
        public List<EF6.SmartTag4Supplier> SupplierSmartTagList = null;
        public List<EF6.SmartTag4Workplace> WorkplaceSmartTagList = null;
        #endregion

        public SmartTagHelper(Control ctrl)
        {
            upCtrl = ctrl;
        }

        #region SetSmartTag Labels and TextBox Tags
        /// <summary>
        /// 根據 Smart Tag 的 Prioirty 設置
        /// 如果係 Label，Label.Text = TagName_Locale，
        /// 如果係其他（TextBox/MaskedTetBox/ComboBox/DateTimePicker），Control.Tag = TagId
        /// 
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
                        #region typeof Label
                        if (Ctrl.GetType().Equals(typeof(Label)))
                        {
                            Label lblTag = Ctrl as Label;
                            lblTag.Text = displayName;
                            lblTag.Visible = true;
                        }
                        #endregion

                        #region typeof TextBox
                        if (Ctrl.GetType().Equals(typeof(TextBox)))
                        {
                            TextBox txtTag = Ctrl as TextBox;
                            txtTag.Tag = tag;
                            txtTag.Visible = true;
                        }
                        #endregion

                        #region typeof MaskedTextBox
                        if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                        {
                            MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                            txtTag.Tag = tag;
                            txtTag.Visible = true;
                        }
                        #endregion

                        #region typeof ComboBox
                        if (Ctrl.GetType().Equals(typeof(ComboBox)))
                        {
                            ComboBox cboTag = Ctrl as ComboBox;
                            cboTag.Tag = tag;
                            cboTag.Visible = true;
                        }
                        #endregion

                        #region typeof DateTimePicker
                        if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                        {
                            DateTimePicker dtpTag = Ctrl as DateTimePicker;
                            dtpTag.Tag = tag;
                            dtpTag.Visible = true;
                        }
                        #endregion
                    }
                }
            }
        }
        #endregion
    }
}