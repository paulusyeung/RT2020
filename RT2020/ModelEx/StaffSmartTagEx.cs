using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Helper;

namespace RT2020.ModelEx
{
    public class StaffSmartTagEx
    {
        public static EF6.StaffSmartTag Get(Guid staffid, Guid tagId)
        {
            EF6.StaffSmartTag result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.StaffSmartTag.Where(x => x.StaffId == staffid && x.TagId == tagId).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }

        /// <summary>
        /// Display Smart Tag value of this Staff, varies by typeof Control
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="Ctrl"></param>
        public static void LoadSmartTagValue(Guid staffId, Control Ctrl)
        {
            string sql = "StaffId = '" + staffId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            Guid tagId = Guid.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    tagId = (Guid)Ctrl.Tag;

                    var oTag = ModelEx.StaffSmartTagEx.Get(staffId, tagId);
                    if (oTag != null)
                    {
                        #region typeof TextBox
                        if (Ctrl.GetType().Equals(typeof(TextBox)))
                        {
                            TextBox txtTag = Ctrl as TextBox;
                            txtTag.Text = oTag.SmartTagValue;
                        }
                        #endregion

                        #region typeof MaskedTextBox
                        if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                        {
                            MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                            txtTag.Text = oTag.SmartTagValue;
                        }
                        #endregion

                        #region typeof ComboBox
                        if (Ctrl.GetType().Equals(typeof(ComboBox)))
                        {
                            var id = Guid.Empty;
                            if (Guid.TryParse(oTag.SmartTagValue, out id))
                            {
                                // 2020.12.28 paulus: 如果係 combo box，個 value = dbo.SmartTag_Options.OptionId
                                ComboBox cboTag = Ctrl as ComboBox;
                                //cboTag.Text = oTag.SmartTagValue;
                                cboTag.SelectedValue = id;
                            }
                        }
                        #endregion

                        #region typeof DateTimePicker
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
                                    dtpTag.Value = Convert.ToDateTime(DateTimeHelper.ReformatDateTime(oTag.SmartTagValue));
                                    dtpTag.Checked = true;
                                }
                            }
                            else
                            {
                                dtpTag.Value = (oTag.SmartTagValue.Length == 0) ? dtpTag.MinDate : Convert.ToDateTime(DateTimeHelper.ReformatDateTime(oTag.SmartTagValue));
                            }
                        }
                        #endregion
                    }
                }
            }
        }

        /// <summary>
        /// Save Smart Tag inputs of this Staff, varies by typeof Control
        /// </summary>
        /// <param name="staffId"></param>
        /// <param name="Ctrl"></param>
        public static void SaveSmartTagValue(Guid staffId, Control Ctrl)
        {
            string sql = "StaffId = '" + staffId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            Guid tagId = Guid.Empty;
            string value = string.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    #region typeof TextBox
                    if (Ctrl.GetType().Equals(typeof(TextBox)))
                    {
                        TextBox txtTag = Ctrl as TextBox;
                        tagId = (Guid)txtTag.Tag;
                        value = txtTag.Text;
                    }
                    #endregion

                    #region typeof MaskedTextBox
                    if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                    {
                        MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                        tagId = (Guid)txtTag.Tag;
                        value = txtTag.Text;
                    }
                    #endregion

                    #region typeof ComboBox
                    if (Ctrl.GetType().Equals(typeof(ComboBox)))
                    {
                        ComboBox cboTag = Ctrl as ComboBox;
                        tagId = (Guid)cboTag.Tag;
                        // 2020.12.28 paulus: 如果係 combo box，個 value = dbo.SmartTag_Options.OptionId
                        //value = cboTag.Text;
                        value = (Guid)cboTag.SelectedValue == Guid.Empty ? "" : cboTag.SelectedValue.ToString();
                    }
                    #endregion

                    #region typeof DateTimePicker
                    if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                    {
                        DateTimePicker dtpTag = Ctrl as DateTimePicker;
                        tagId = (Guid)dtpTag.Tag;
                        //value = dtpTag.Value.ToString("yyyy-MM-dd");
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

                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var oTag = ctx.StaffSmartTag.Where(x => x.StaffId == staffId && x.TagId == tagId).FirstOrDefault();
                        if (oTag == null)
                        {
                            oTag = new EF6.StaffSmartTag();
                            oTag.SmartTagId = Guid.NewGuid();
                            oTag.StaffId = staffId;
                            oTag.TagId = tagId;

                            ctx.StaffSmartTag.Add(oTag);
                        }
                        oTag.SmartTagValue = value;
                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}