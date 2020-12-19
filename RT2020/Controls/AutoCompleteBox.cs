#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;

using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.Controls
{
    /// <summary>
    /// Auto-Complete Control
    /// </summary>
    public partial class AutoCompleteBox : UserControl
    {
        #region Variables

        /// <summary>
        /// Query String
        /// </summary>
        private string queryString = string.Empty;

        /// <summary>
        /// count of retrieved items
        /// </summary>
        private int itemCount = 50;

        /// <summary>
        /// Selected Text
        /// </summary>
        private AutoCompleteBoxItem selectedItem = new AutoCompleteBoxItem("", "");

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the query string to retrieve data.
        /// </summary>
        /// <value>The query string. e.g. select [field name 1], [field name 2] from [table]</value>
        public string QueryString
        {
            get
            {
                return queryString;
            }
            set
            {
                queryString = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of retrieved items.
        /// </summary>
        /// <value>The item count.</value>
        public int ItemCount
        {
            get
            {
                return itemCount;
            }
            set
            {
                itemCount = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected item.
        /// </summary>
        /// <value>The selected item.</value>
        public AutoCompleteBoxItem SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                selectedItem = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteBox"/> class.
        /// </summary>
        public AutoCompleteBox()
        {
            InitializeComponent();

            cboAutoComplete.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cboAutoComplete.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        /// <summary>
        /// Handles the Load event of the AutoComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AutoComplete_Load(object sender, EventArgs e)
        {
            //BindData();
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        public void BindData()
        {
            BindData(BuildQueryString());
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        /// <param name="query">The query.</param>
        public void BindData(string query)
        {
            if (query.Length > 0)
            {
                cboAutoComplete.DataSource = null;

                AutoCompleteBoxItemCollection itemList = new AutoCompleteBoxItemCollection();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = query;
                cmd.CommandTimeout = ConfigHelper.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        itemList.Add(new AutoCompleteBoxItem(reader[0].ToString(), reader[1].ToString()));
                    }
                }

                cboAutoComplete.DataSource = itemList;
                cboAutoComplete.DisplayMember = "ItemCode";
                cboAutoComplete.ValueMember = "ItemId";
            }
        }

        private string BuildQueryString()
        {
            string tempQuery = this.QueryString;

            if (tempQuery.Length > 0)
            {
                tempQuery.Insert(6, " TOP " + this.ItemCount.ToString() + " ");

            }

            return tempQuery;
        }

        /// <summary>
        /// Handles the KeyPress event of the cboAutoComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.KeyPressEventArgs"/> instance containing the event data.</param>
        private void cboAutoComplete_KeyPress(object sender, KeyPressEventArgs e)
        {
            //this.AutoComplete(this.cboAutoComplete, e);
        }

        /// <summary>
        /// Handles the SelectedIndexChangedQueued event of the cboAutoComplete control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void cboAutoComplete_SelectedIndexChangedQueued(object sender, EventArgs e)
        {
            this.SelectedItem = cboAutoComplete.SelectedItem as AutoCompleteBoxItem;
        }
    }

    /// <summary>
    /// AutoCompleteBoxItem
    /// </summary>
    public class AutoCompleteBoxItem
    {
        #region Variables

        /// <summary>
        /// Item Id
        /// </summary>
        private string itemId = string.Empty;

        /// <summary>
        /// Item Code
        /// </summary>
        private string itemCode = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the item id.
        /// </summary>
        /// <value>The item id.</value>
        private string ItemId
        {
            get
            {
                return itemId;
            }
            set
            {
                itemId = value;
            }
        }

        /// <summary>
        /// Gets or sets the item code.
        /// </summary>
        /// <value>The item code.</value>
        private string ItemCode
        {
            get
            {
                return itemCode;
            }
            set
            {
                itemCode = value;
            }
        }

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteBoxItem"/> class.
        /// </summary>
        public AutoCompleteBoxItem()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AutoCompleteBoxItem"/> class.
        /// </summary>
        /// <param name="_itemId">The _item id.</param>
        /// <param name="_itemCode">The _item code.</param>
        public AutoCompleteBoxItem(string _itemId, string _itemCode)
        {
            this.itemId = _itemId;
            this.itemCode = _itemCode;
        }
    }

    /// <summary>
    /// Collection of AutoCompleteBoxItem
    /// </summary>
    public class AutoCompleteBoxItemCollection : BindingList<AutoCompleteBoxItem>
    {
    }
}