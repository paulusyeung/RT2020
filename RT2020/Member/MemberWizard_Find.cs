#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;
using RT2020.Helper;

#endregion

namespace RT2020.Member
{
    public partial class MemberWizard_Find : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MemberWizard_Find"/> class.
        /// </summary>
        public MemberWizard_Find()
        {
            InitializeComponent();
        }

        #region Properties

        /// <summary>
        /// the value be look up to TextBox control
        /// </summary>
        private string lookUpTo = string.Empty;

        /// <summary>
        /// Gets or sets the value be look up to TextBox control.
        /// </summary>
        /// <value>the value be look up to TextBox control</value>
        public string LookUpTo
        {
            get
            {
                return lookUpTo;
            }
            set
            {
                lookUpTo = value;
            }
        }

        /// <summary>
        /// selected member
        /// </summary>
        private string selectedMember = string.Empty;

        /// <summary>
        /// Gets or sets the selected member.
        /// </summary>
        /// <value>The selected member.</value>
        public string SelectedMember
        {
            get
            {
                return selectedMember;
            }
            set
            {
                selectedMember = value;
            }
        }

        #endregion

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        /// <summary>
        /// Buttons the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnfind":
                            this.Find();
                            break;
                        case "btnok":
                            this.SelectedMember = this.lvResultSet.SelectedItem.SubItems[2].Text;

                            this.Close();
                            break;
                        case "btncancel":
                            this.Close();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Finds this instance.
        /// </summary>
        private void Find()
        {
            lvResultSet.Items.Clear();
            int iCount = 1;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = BuildQueryString();
            cmd.CommandTimeout = 600;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = lvResultSet.Items.Add(reader.GetGuid(0).ToString());
                    objItem.SubItems.Add(iCount.ToString());
                    objItem.SubItems.Add(reader.GetString(1));
                    objItem.SubItems.Add(reader.GetString(2));
                    objItem.SubItems.Add(reader.GetString(3));
                    objItem.SubItems.Add(reader.GetString(4));

                    iCount++;
                }
            }
        }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <returns></returns>
        private string BuildQueryString()
        {
            string query = "SELECT DISTINCT MemberId, VipNumber, FirstName, LastName, HKID FROM vwVIP_MemberList ";
            string whereClause = " WHERE {0} ";
            string orderClause = " ORDER BY VipNumber, FirstName, LastName, HKID";
            string condictions = string.Empty;

            if (!txtMemberNumber.Text.Contains("*"))
            {
                if (condictions.Length > 0)
                {
                    condictions += " AND ";
                }

                condictions += "VipNumber LIKE '" + txtMemberNumber.Text.Trim() + "%'";
            }

            if (!txtFirstName.Text.Contains("*"))
            {
                if (condictions.Length > 0)
                {
                    condictions += " AND ";
                }

                condictions += "FirstName LIKE '" + txtFirstName.Text.Trim() + "%'";
            }

            if (!txtLastName.Text.Contains("*"))
            {
                if (condictions.Length > 0)
                {
                    condictions += " AND ";
                }

                condictions += "LastName LIKE '" + txtLastName.Text.Trim() + "%'";
            }

            if (!txtHKID.Text.Contains("*"))
            {
                if (condictions.Length > 0)
                {
                    condictions += " AND ";
                }

                condictions += "HKID LIKE '" + txtHKID.Text.Trim() + "%'";
            }

            if (condictions.Length > 0)
            {
                whereClause = string.Format(whereClause, condictions);

                query += whereClause;
            }

            return query + orderClause;
        }
    }
}