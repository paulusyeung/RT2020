using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RT2020.Common.Helper
{
    public class ComboBoxHelper
    {
        /// <summary>
        /// fill the combobox with Yes/No/Empty, localized.
        /// triStat = true: with empty item, false: without empty item.
        /// </summary>
        /// <param name="cbo"></param>
        /// <param name="triState"></param>
        public static void FillSimpleYesNo(ref Gizmox.WebGUI.Forms.ComboBox cbo, bool triState = false)
        {
            cbo.Items.Clear();
            if (triState) cbo.Items.Add(string.Empty);
            cbo.Items.Add(string.Format("{0}", WestwindHelper.GetWord("dialog.no", "General")));
            cbo.Items.Add(string.Format("{0}", WestwindHelper.GetWord("dialog.yes", "General")));
            cbo.SelectedIndex = 0;
        }

        public class ComboBoxItem
        {
            public Guid Key { get; set; }
            public string Value { get; set;}

            /// <summary>
            /// 吉嘅 ComboBox Item：Key Value pair (Guid.Empty, String.Empty)
            /// </summary>
            public ComboBoxItem()
            {
                this.Key = Guid.Empty;
                this.Value = string.Empty;
            }

            public ComboBoxItem(Guid key, string value)
            {
                this.Key = key;
                this.Value = value;
            }

            public override string ToString()
            {
                return this.Value;
            }
        }

        /// <summary>
        /// Represents a collection of <see cref="ComboBoxItem">ComboBoxItem</see> objects.
        /// </summary>
        public class ComboBoxItems : BindingList<ComboBoxItem>
        {
        }
    }
}