#region Using

using System;
using System.Xml;
using System.Drawing;
using System.ComponentModel;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Skins;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

#endregion Using

namespace RT2020.Components
{
    /// <summary>
    /// A Custom ComboBox for Product Appendix 2
    /// </summary>
    [Skin(typeof(Appendix2ComboBoxSkin))]
    [Serializable()]
    public class Appendix2ComboBox : ComboBox
    {
        public Appendix2ComboBox()
        {
            this.CustomStyle = "Appendix2ComboBoxSkin";

            this.DropDownStyle = ComboBoxStyle.DropDown;
            this.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            this.AutoCompleteSource = AutoCompleteSource.ListItems;

            //this.TextChanged += Appendix2ComboBox_TextChanged;    效果唔好，唔用
            this.KeyPress += Appendix2ComboBox_KeyPress;
            this.LostFocus += Appendix2ComboBox_LostFocus;
        }

        private void Appendix2ComboBox_LostFocus(object sender, EventArgs e)
        {
            FilterData(this.Text);
        }

        private void Appendix2ComboBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)  // Keys.Enter or Keys.Tab
                FilterData(this.Text);
        }

        private void Appendix2ComboBox_TextChanged(object sender, EventArgs e)
        {
            FilterData(this.Text);
        }

        public void BindData()
        {
            LoadData();
        }

        private void LoadData()
        {
            this.DataSource = null;
            this.Items.Clear();

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.ProductAppendix2
                    .OrderBy(x => x.Appendix2Code)
                    .AsNoTracking()
                    .ToList();

                BindingList<KeyValuePair<Guid, string>> data = new BindingList<KeyValuePair<Guid, string>>();
                data.Insert(0, new KeyValuePair<Guid, string>(Guid.Empty, ""));

                foreach (var item in list)
                {
                    data.Add(new KeyValuePair<Guid, string>(item.Appendix2Id, item.Appendix2Code));
                }

                this.DataSource = data.ToList();
                this.ValueMember = "Key";
                this.DisplayMember = "Value";
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }

        private void FilterData(string prefix)
        {
            this.DataSource = null;
            this.Items.Clear();

            using (var ctx = new EF6.RT2020Entities())
            {
                List<EF6.ProductAppendix2> list;
                list = string.IsNullOrEmpty(prefix) ?
                    ctx.ProductAppendix2.OrderBy(x => x.Appendix2Code).AsNoTracking().ToList() :
                    ctx.ProductAppendix2
                    .Where(x => x.Appendix2Code.StartsWith(prefix))
                    .OrderBy(x => x.Appendix2Code)
                    .AsNoTracking()
                    .ToList();

                BindingList<KeyValuePair<Guid, string>> data = new BindingList<KeyValuePair<Guid, string>>();
                if (string.IsNullOrEmpty(prefix))
                    data.Insert(0, new KeyValuePair<Guid, string>(Guid.Empty, ""));

                foreach (var item in list)
                {
                    data.Add(new KeyValuePair<Guid, string>(item.Appendix2Id, item.Appendix2Code));
                }

                this.DataSource = data.ToList();
                this.ValueMember = "Key";
                this.DisplayMember = "Value";
            }
            if (this.Items.Count > 0) this.SelectedIndex = 0;
        }
    }

}
