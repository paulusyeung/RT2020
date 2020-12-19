#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Authentication;
using System.Web.Security;
using Gizmox.WebGUI.Common.Interfaces;

using System.Reflection;
using RT2020.Controls;
using System.Configuration;
using RT2020.Helper;
using Westwind.Globalization;

#endregion

namespace RT2020.Public
{
    /// <summary>
    /// 
    /// </summary>
    public partial class Logon : LogonForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logon"/> class.
        /// </summary>
        public Logon()
        {
            InitializeComponent();

#if (DEBUG)
            txtStaffNumber.Text = "9999";
            txtPassword.Text = "9999";
#endif
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.Context.CurrentTheme = ThemeHelper.CurrentThemeVWGName;
            this.Context.Session.IsLoggedOn = false;

            ConfigHelper.CurrentUserId = Guid.Empty;

            SetAttributes();
            FillZoneList();
            VersionNumber();
        }

        private void SetAttributes()
        {
            lblStaffNumber.Text = WestwindHelper.GetWordWithColon("logon.staff", "General");
            lblPassword.Text = WestwindHelper.GetWordWithColon("logon.password", "General");
            lblZone.Text = WestwindHelper.GetWordWithColon("logon.zone", "General");
            btnLogon.Text = WestwindHelper.GetWord("logon", "General");
        }

        /// <summary>
        /// the number Version.
        /// </summary>
        private void VersionNumber()
        {
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.lblVersionNumber.Text = version.ToString();    // + " (" + Gizmox.WebGUI.WGConst.Version.ToString() + ")";
        }

        /// <summary>
        /// Fills the zone list.
        /// </summary>
        public void FillZoneList()
        {
            ModelEx.WorkplaceZoneEx.LoadCombo(ref cboZone, "ZoneName", true);

            if (ConfigHelper.CurrentZoneId != Guid.Empty)
                cboZone.SelectedValue = ConfigHelper.CurrentZoneId;
        }

        /// <summary>
        /// Verifies the input string.
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            bool result = true;
            if (txtStaffNumber.Text.Length == 0)
            {
                errorProvider.SetError(txtStaffNumber, RT2020.Controls.Utility.Dictionary.GetWord("err_cannot_blank"));
            }
            else
            {
                errorProvider.SetError(txtStaffNumber, string.Empty);
                result = result & true;
            }

            if (txtPassword.Text.Length == 0)
            {
                errorProvider.SetError(txtPassword, RT2020.Controls.Utility.Dictionary.GetWord("err_cannot_blank"));
            }
            else
            {
                errorProvider.SetError(txtPassword, string.Empty);
                result = result & true;
            }

            if (cboZone.Text.Length == 0)
            {
                errorProvider.SetError(cboZone, RT2020.Controls.Utility.Dictionary.GetWord("err_must_select"));
            }
            else
            {
                errorProvider.SetError(cboZone, string.Empty);
                result = result & true;
            }
            return result;
        }

        /// <summary>
        /// Authes the logon.
        /// </summary>
        /// <returns></returns>
        private bool AuthLogon()
        {
            if (Verify())
            {
                var oUser = ModelEx.UserProfileEx.GetLoginUser(txtStaffNumber.Text.Trim().Replace("'", ""), txtPassword.Text.Trim().Replace("'", ""));
                if (oUser != null)
                {
                    var oStaff = ModelEx.StaffEx.GetByStaffId(oUser.UserSid);
                    if (oStaff != null)
                    {
                        if (oStaff.Status > Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d")))
                        {
                            if (!oStaff.Retired)
                            {
                                this.Context.Session.IsLoggedOn = true;

                                ConfigHelper.CurrentUserId = oStaff.StaffId;
                                ConfigHelper.CurrentZoneId = new Guid(cboZone.SelectedValue.ToString());
                                ConfigHelper.CurrentUserType = oUser.UserType.Value;

                                // The below code will logout the loggedin user when idle for the time specified
                                if (ConfigurationManager.AppSettings["sessionTimeout"] != null)
                                {
                                    this.Context.HttpContext.Session.Timeout = Convert.ToInt32(ConfigurationManager.AppSettings["sessionTimeout"]);
                                }

                                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Login, this.ToString());
                            }
                            else
                            {
                                this.lblErrorMessage.Text = RT2020.Controls.Utility.Dictionary.GetWord("msg_retired_staff");
                                this.Context.Session.IsLoggedOn = false;
                            }
                        }
                        else
                        {
                            this.lblErrorMessage.Text = RT2020.Controls.Utility.Dictionary.GetWord("msg_inactive_staff");
                            this.Context.Session.IsLoggedOn = false;
                        }
                    }
                }
                else
                {
                    // When user inputs incorrect staff number or password, prompt user the error message.
                    // To Do: We can try to limited the times of attempt to 5 or less.
                    this.lblErrorMessage.Text = RT2020.Controls.Utility.Dictionary.GetWord("err_incorrect_staff");
                    this.Context.Session.IsLoggedOn = false;
                }
            }
            else
            {
                this.Context.Session.IsLoggedOn = false;
            }

            return this.Context.Session.IsLoggedOn;
        }

        /// <summary>
        /// Handles the Click event of the btnLogon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnLogon_Click(object sender, EventArgs e)
        {
            if (AuthLogon())
            {
                // Close the Logon form
                this.Close();
            }
        }

        /// <summary>
        /// Handles the Load event of the Logon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Logon_Load(object sender, EventArgs e)
        {
            txtStaffNumber.Focus();
        }
    }
}