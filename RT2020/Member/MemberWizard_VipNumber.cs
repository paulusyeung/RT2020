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

namespace RT2020.Member
{
    public partial class MemberWizard_VipNumber : Form
    {
        public MemberWizard_VipNumber()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.VipNumber.Trim().Length == 0)
            {
                this.GetMaxmiumVipNumber();
            }
            else
            {
                txtVipNumber.Text = this.VipNumber;
            }
        }

        #region Properties
        private Guid memberId = System.Guid.Empty;
        public Guid MemberId
        {
            get
            {
                return memberId;
            }
            set
            {
                memberId = value;
            }
        }

        private string vipNumber = string.Empty;
        public string VipNumber
        {
            get
            {
                return vipNumber;
            }
            set
            {
                vipNumber = value;
            }
        }
        #endregion

        private void GetMaxmiumVipNumber()
        {
            string sql = "SELECT MAX(VipNumber) + 1 FROM MemberVipData WHERE LEN(VipNumber) > 6 AND SUBSTRING(VipNumber, 1, 1) > CHAR(48) AND SUBSTRING(VipNumber, 1, 1) < CHAR(57)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Convert.ToInt32(ConfigurationManager.AppSettings[""]);
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    txtVipNumber.Text = reader.GetInt32(0).ToString();
                }
            }
        }

        private void chkFillZero_Click(object sender, EventArgs e)
        {
            if (chkFillZero.Checked)
            {
                txtVipNumber.Text = txtVipNumber.Text.Trim().PadLeft(13, '0');
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnok":
                            this.VipNumber = txtVipNumber.Text;
                            break;
                        case "btncancel":
                            this.VipNumber = string.Empty;
                            break;
                    }
                }

                this.Close();
            }
        }
    }
}