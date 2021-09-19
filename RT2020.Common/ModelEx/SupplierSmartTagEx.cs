using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;

namespace RT2020.Common.ModelEx
{
    public class SupplierSmartTagEx
    {
        public static EF6.SupplierSmartTag Get(Guid supplierid, Guid tagId)
        {
            EF6.SupplierSmartTag result = null;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierid && x.TagId == tagId).AsNoTracking().FirstOrDefault();
                if (item != null) result = item;
            }

            return result;
        }

        public static bool Delete(Guid id)
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierSmartTag.Find(id);
                if (item != null)
                {
                    ctx.SupplierSmartTag.Remove(item);
                    ctx.SaveChanges();
                    result = true;
                }
            }

            return result;
        }

        /// <summary>
        /// Display Smart Tag value of this Supplier, varies by typeof Control
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="Ctrl"></param>
        public static void LoadSmartTagValue(Guid supplierId, Control Ctrl)
        {
            string sql = "SupplierId = '" + supplierId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            Guid tagId = Guid.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    tagId = (Guid)Ctrl.Tag;

                    var oTag = ModelEx.SupplierSmartTagEx.Get(supplierId, tagId);
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
        /// Save Smart Tag inputs of this Supplier, varies by typeof Control
        /// </summary>
        /// <param name="supplierId"></param>
        /// <param name="Ctrl"></param>
        public static void SaveSmartTagValue(Guid supplierId, Control Ctrl)
        {
            string sql = "SupplierId = '" + supplierId.ToString() + "' AND TagId = '{0}'";
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
                        var oTag = ctx.SupplierSmartTag.Where(x => x.SupplierId == supplierId && x.TagId == tagId).FirstOrDefault();
                        if (oTag == null)
                        {
                            oTag = new EF6.SupplierSmartTag();
                            oTag.SmartTagId = Guid.NewGuid();
                            oTag.SupplierId = supplierId;
                            oTag.TagId = tagId;

                            ctx.SupplierSmartTag.Add(oTag);
                        }
                        oTag.SmartTagValue = value;
                        ctx.SaveChanges();
                    }
                }
            }
        }
    }
}