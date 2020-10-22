using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Threading;

namespace RT2020.Client
{
	public partial class Login : Form
	{
		public Login()
		{
			InitializeComponent();

            DefaultSettingsStartup();
        }

        #region Properties.Settings.Default Startup
        private void DefaultSettingsStartup()
        {
            if (Properties.Settings.Default.RunOnce)
            {
                RT2020.Client.SqlConnection oSqlConn = new RT2020.Client.SqlConnection();
                oSqlConn.ShowDialog();
                Properties.Settings.Default.RunOnce = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                if (!(Common.Utility.CheckSqlConnection()))
                {
                    if (Properties.Settings.Default.PersonalizedConnectionString.Trim() != String.Empty)
                    {
                        // 採用 Properties.Settings.Default.PersonalizedConnectionString
                        Common.Config.SetSqlConnectionString(Properties.Settings.Default.PersonalizedConnectionString);
                    }
                    else
                    {
                        // 重设 SQL Connection String
                        SqlConnection connForm = new SqlConnection();
                        connForm.TopMost = true;
                        connForm.ShowDialog();
                    }
                }
            }

            if (Properties.Settings.Default.UpdateRequired)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.UpdateRequired = false;
                Properties.Settings.Default.Save();
            }
        }
        #endregion

        private void LoginForm_Load(object sender, EventArgs e)
        {

            lblVersion.Text = "Version " + Application.ProductVersion;

			if (Properties.Settings.Default.rememberLogin == true)
			{
				txtUserName.Text = Properties.Settings.Default.username;
				txtPassword.Text = Properties.Settings.Default.password;
				cbRemember.Checked = true;
			}

			txtUserName.Focus();
		}

		#region Event Click
		private void btnOK_Click(object sender, EventArgs e)
		{
			LoginAction();
		}

		private void butCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void butSetting_Click(object sender, EventArgs e)
		{

		}

		private void LoginForm_KeyUp(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				if (txtUserName.Text != string.Empty && txtPassword.Text != string.Empty)
				{
					LoginAction();
				}
				else if (txtUserName.Text == string.Empty)
				{
					txtUserName.Focus();
				}
				else
				{
					txtPassword.Focus();
				}
			}
		}
		#endregion

		#region Login Action
		private void LoginAction()
        {
            this.DialogResult = DialogResult.None;

            if (txtUserName.Text.Trim() != string.Empty && txtPassword.Text.Trim() != string.Empty)
            {
                base.Cursor = Cursors.WaitCursor;
                RT2020.Client.Common.SignOnPrincipal.SignOnIdentity(txtUserName.Text, txtPassword.Text);
                base.Cursor = Cursors.Arrow;

                IPrincipal threadPrincipal = Thread.CurrentPrincipal;
                if (threadPrincipal.Identity.IsAuthenticated)
                {

                    this.DialogResult = DialogResult.OK;
                    this.Close();

                    Properties.Settings.Default.username = txtUserName.Text;

                    if (cbRemember.Checked)
                    {
                        Properties.Settings.Default.password = txtPassword.Text;
                        Properties.Settings.Default.rememberLogin = cbRemember.Checked;
                    }
                    else
                    {
                        //Properties.Settings.Default.userName = string.Empty;
                        Properties.Settings.Default.password = string.Empty;
                        Properties.Settings.Default.rememberLogin = false;
                    }

                    Properties.Settings.Default.Save();
                    Common.UserLog.Write(RT2020.Client.Common.UserLog.Action.Login, "");      // create a log
                }
                else
                {
                    txtUserName.Focus();
                }
            }
        } 
		#endregion
	}
}