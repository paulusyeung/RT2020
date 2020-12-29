using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace RT2020.Helper
{
    public class ComboBoxHelper
    {
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