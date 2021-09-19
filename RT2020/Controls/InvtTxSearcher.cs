#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Data.SqlClient;
using System.Configuration;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Controls
{
    public partial class InvtTxSearcher : Form
    {
        public InvtTxSearcher()
        {
            InitializeComponent();
        }

        /// <summary>
        /// SQL Query String, please make sure have these fields (HeaderId, TxNumber, TxType, TxDate) in order.
        /// </summary>
        public string SqlQuery { get; set; }

        public EnumHelper.TxType TxType { get; set; }

        public string SelectedTxNumber { get; set; }
        public DateTime SelectedTxDate { get; set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetAttributes();

            SelectedTxNumber = string.Empty;
            txtTxType.Text = TxType.ToString();
        }

        private void SetAttributes()
        {
            this.Text = string.Format(Utility.Dictionary.GetWord("SearchFor"), Utility.Dictionary.GetWord("TxNumber"));

            lblTxNumber.Text = Utility.Dictionary.GetWordWithColon("TxNumber");
            lblTxType.Text = Utility.Dictionary.GetWordWithColon("TxType");
            btnFind.Text = Utility.Dictionary.GetWord("Find");

            colLine.Text = Utility.Dictionary.GetWord("LN");
            colTxNumber.Text = Utility.Dictionary.GetWord("TxNumber");
            colTxType.Text = Utility.Dictionary.GetWord("TxType");
            colTxDate.Text = Utility.Dictionary.GetWord("TxDate");
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            if (SelectedTxNumber == null)
            {
                SelectedTxNumber = string.Empty;
            }
        }

        private void BuildQuery()
        {
            if (txtTxNumber.Text.Trim().Length > 0 && txtTxType.Text.Trim().Length > 0)
            {
                if (SqlQuery.Contains("WHERE"))
                {
                    SqlQuery += " AND ";
                }
                else
                {
                    SqlQuery += " WHERE ";
                }

                SqlQuery += " TxNumber LIKE '%" + txtTxNumber.Text.Trim() + "%' AND TxType = '" + txtTxType.Text.Trim() + "'";
            }

            SqlQuery += " ORDER BY TxNumber ";
        }
            
        private void BindData()
        {
            BuildQuery();

            if (SqlQuery.Trim().Length > 0)
            {
                int iCount = 1;

                lvResultList.Items.Clear();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = SqlQuery;
                cmd.CommandTimeout = ConfigHelper.CommandTimeout;
                cmd.CommandType = CommandType.Text;

                using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
                {
                    while (reader.Read())
                    {
                        ListViewItem lvItem = lvResultList.Items.Add(reader.GetGuid(0).ToString());
                        lvItem.SubItems.Add(iCount.ToString());
                        lvItem.SubItems.Add(reader.GetString(1));
                        lvItem.SubItems.Add(TxType.ToString());
                        lvItem.SubItems.Add(reader.GetDateTime(3).ToString(DateTimeHelper.GetDateFormat()));

                        iCount++;
                    }
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            BindData();
        }

        private void lvResultList_DoubleClick(object sender, EventArgs e)
        {
            if (lvResultList.SelectedItem != null)
            {
                SelectedTxNumber = lvResultList.SelectedItem.SubItems[2].Text;
                SelectedTxDate = Convert.ToDateTime(lvResultList.SelectedItem.SubItems[4].Text);
                this.Close();
            }
        }

        private void timedTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}