using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RT2020.Client
{
    public partial class SqlConnection : Form
    {
        public SqlConnection()
        {
            InitializeComponent();

            this.radSqlAuth.Checked = true;
            this.radSqlAuth.Enabled = false;
            this.radWinAuth.Enabled = false;
            this.txtLogin.Text = "******";
            this.txtLogin.Enabled = false;
            this.txtPassword.Text = "**********";
            this.txtPassword.Enabled = false;
        }

        private void Auth_CheckedChanged(object sender, EventArgs e)
        {
            if (radWinAuth.Checked)
            {
                txtLogin.Enabled = false;
                txtPassword.Enabled = false;
            }
            else
            {
                txtLogin.Enabled = true;
                txtPassword.Enabled = true;
            }
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void Save()
        {
            string sql = String.Empty;
            if (radWinAuth.Checked)
            {
                // Data Source=localhost;Initial Catalog=RT2020.Client;Integrated Security=True
                sql = String.Format("Data Source={0};Initial Catalog=RT2020;Integrated Security=True", txtServerName.Text.Trim());
            }
            else
            {
                // Data Source=localhost;Initial Catalog=RT2020.Client;Persist Security Info=True;User ID=sa;Password=sa9602
                sql = String.Format("Data Source={0};Initial Catalog=RT2020;Persist Security Info=True;User ID=sa;Password=Isaboutique123", txtServerName.Text.Trim());
            }

            Common.Config.SetSqlConnectionString(sql);

            Properties.Settings.Default.Reload();

            string confirmationMsg = string.Format("Please make sure the following connection info is correct. {0}\"{1}\"{2}{3}Continue?", Environment.NewLine, Properties.Settings.Default.SysDb, Environment.NewLine, Environment.NewLine);

            //if (MessageBox.Show(confirmationMsg, "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            //{
            //    // 把这台 PC 的 SQL ConnectionString 记在 user.config 中
            //    Properties.Settings.Default.PersonalizedConnectionString = sql;
            //    Properties.Settings.Default.Save();

            //    this.Close();
            //}

            // 把这台 PC 的 SQL ConnectionString 记在 user.config 中
            Properties.Settings.Default.PersonalizedConnectionString = sql;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void SqlConnection_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Save();
            }
        }
    }
}
