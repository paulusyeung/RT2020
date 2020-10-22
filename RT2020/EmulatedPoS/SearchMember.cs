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
#endregion

namespace RT2020.EmulatedPoS
{
    public partial class SearchMember : Form
    {
        public SearchMember()
        {
            InitializeComponent();
        }

        #region Properties
        private Guid memberId = System.Guid.Empty;
        /// <summary>
        /// Gets or sets the member id.
        /// </summary>
        /// <value>The member id.</value>
        public Guid MemberId
        {
            get { return memberId; }
            set { memberId = value; }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            StringBuilder sqlWhere = new StringBuilder();
            if (txtMemberNumber.Text.Trim().Length > 0)
            {
                sqlWhere.Append("MemberNumber LIKE '").Append(txtMemberNumber.Text.Trim()).Append("%'");
            }
            if (txtFullName.Text.Trim().Length > 0)
            {
                if (sqlWhere.Length > 0)
                {
                    sqlWhere.Append(" AND ");
                }
                sqlWhere.Append("FullName LIKE '").Append(txtFullName.Text.Trim()).Append("%'");
            }

            if (sqlWhere.Length > 0)
            {
                RT2020.DAL.Member oMember = RT2020.DAL.Member.LoadWhere(sqlWhere.ToString());
                if (oMember != null)
                {
                    this.MemberId = oMember.MemberId;
                }
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}