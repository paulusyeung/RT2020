#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Linq;
using System.Data.Entity;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Helper
{
    public class PhoneTagHelper
    {
        Control upCtrl = null;
        string key = "PhoneTag{0}";
        private string _Prefix = "";

        public PhoneTagHelper(Control ctrl, string prefix = "")
        {
            upCtrl = ctrl;
            _Prefix = prefix;
        }

        /// <summary>
        /// 根據 Smart Tag 的 Prioirty 設置
        /// 如果係 Label，Label.Text = TagName_Locale，
        /// 如果係其他（TextBox/MaskedTetBox/ComboBox/DateTimePicker），Control.Tag = TagId
        /// 
        /// Control.Tag 將於 Load Data 和 SaveData 中用到
        /// </summary>
        public void SetPhoneTag()
        {
            int iCount = 1;
            string[] orderBy = new string[] { "Priority" };

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PhoneTag.Where(x => x.PhoneCode.StartsWith(_Prefix)).OrderBy(x => x.Priority).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    SetPhoneTagLabel(string.Format(key, iCount.ToString()), item.PhoneTagId, item.PhoneName, item.PhoneName_Chs, item.PhoneName_Cht);
                    iCount++;
                }
            }
        }

        private void SetPhoneTagLabel(string key, object tag, string name, string name_chs, string name_cht)
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

                if (Ctrl != null && Ctrl.Name.Contains(key))
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
}