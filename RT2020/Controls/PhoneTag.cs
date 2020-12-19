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
using RT2020.Helper;

#endregion

namespace RT2020.Controls
{
    public class PhoneTag
    {
        Control upCtrl = null;
        string key = "PhoneTag{0}";

        public PhoneTag(Control ctrl)
        {
            upCtrl = ctrl;
        }

        public void SetPhoneTag()
        {
            int iCount = 1;
            string[] orderBy = new string[] { "Priority" };

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PhoneTag.OrderBy(x => x.Priority).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    SetPhoneTagLabel(string.Format(key, iCount.ToString()), item.PhoneTagId, item.PhoneName, item.PhoneName_Chs, item.PhoneName_Cht);
                    iCount++;
                }
            }
        }

        private void SetPhoneTagLabel(string key, object tag, string name, string name_chs, string name_cht)
        {
            switch (ConfigHelper.CurrentLanguageId)
            {
                case 2: // chs, zh-chs, zh-cn
                    name_chs = name_chs + "£º";
                    break;
                case 3: // cht, zh-cht, zh-hk, zh-tw
                    name_cht = name_cht + "£º";
                    break;
                case 1: // en, en-us
                default:
                    name = name + ":";
                    break;
            }

            Control Ctrl = null;
            for (int i = 0; i < upCtrl.Controls.Count; i++)
            {
                Ctrl = upCtrl.Controls[i];

                if (Ctrl != null && Ctrl.Name.Contains(key))
                {
                    if (Ctrl.GetType().Equals(typeof(Label)))
                    {
                        Label lblTag = Ctrl as Label;
                        lblTag.Text = name;
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
}