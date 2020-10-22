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
using RT2020.DAL;

#endregion

namespace RT2020.Web.Shop.Public
{
    public partial class Logon : LogonForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Logon"/> class.
        /// </summary>
        public Logon()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Logon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Logon_Load(object sender, EventArgs e)
        {
            headerPane.FormTitle = "Logon";

            txtUserName.Focus();

            FillShopList();
        }

        /// <summary>
        /// Fills the shop list.
        /// </summary>
        public void FillShopList()
        {
            cboShopList.Items.Clear();

            Workplace.LoadCombo(ref cboShopList, new string[] { "WorkplaceCode", "WorkplaceName" }, "{0} - {1}", false, false, string.Empty, string.Empty, null);

            if (Common.Utility.CurrentWorkplaceId != System.Guid.Empty)
            {
                cboShopList.SelectedValue = Common.Utility.CurrentWorkplaceId;
            }
        }

        /// <summary>
        /// Verifies the input string.
        /// </summary>
        /// <returns></returns>
        public bool Verify()
        {
            bool result = true;
            if (txtUserName.Text.Length == 0)
            {
                errorProvider.SetError(txtUserName, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(txtUserName, string.Empty);
                result = result & true;
            }

            if (txtPassword.Text.Length == 0)
            {
                errorProvider.SetError(txtPassword, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(txtPassword, string.Empty);
                result = result & true;
            }

            if (cboShopList.SelectedItem.ToString().Length == 0)
            {
                errorProvider.SetError(cboShopList, "Must select a shop!");
            }
            else
            {
                errorProvider.SetError(cboShopList, string.Empty);
                result = result & true;
            }

            if (txtShopPassword.Text.Length == 0)
            {
                errorProvider.SetError(txtShopPassword, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(txtShopPassword, string.Empty);
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
            string sql = "StaffNumber = '" + txtUserName.Text.Trim().Replace("'", "") + "' AND Password = '" + txtPassword.Text.Trim().Replace("'", "") + "'";
            RT2020.DAL.Staff oStaff = RT2020.DAL.Staff.LoadWhere(sql);
            if (oStaff != null)
            {
                if (oStaff.Status > Convert.ToInt32(RT2020.DAL.Common.Enums.Status.Inactive.ToString("d")))
                {
                    if (!oStaff.Retired)
                    {
                        this.Context.Session.IsLoggedOn = AuthShopLogon();

                        Common.Utility.CurrentUserId = oStaff.StaffId;
                    }
                    else
                    {
                        this.lblErrorMessage.Text = "Staff was retired!";
                    }
                }
                else
                {
                    this.lblErrorMessage.Text = "Staff is inactivate! Please contact system administrator!";
                }
            }
            else
            {
                // When user inputs incorrect staff number or password, prompt user the error message.
                // To Do: We can try to limited the times of attempt to 5 or less.
                this.lblErrorMessage.Text = "Incorrect Staff Number or Password! Please try again!";
                this.Context.Session.IsLoggedOn = false;
            }

            return this.Context.Session.IsLoggedOn;
        }

        /// <summary>
        /// Authes the logon.
        /// </summary>
        /// <returns></returns>
        private bool AuthShopLogon()
        {
            bool bFailed = false;
            string wpId = cboShopList.SelectedValue.ToString();
            if (RT2020.DAL.Common.Utility.IsGUID(wpId))
            {
                System.Guid workplaceId = new Guid(wpId);
                Workplace oWp = Workplace.Load(workplaceId);
                if (oWp != null)
                {
                    if (oWp.Password.Equals(txtShopPassword.Text, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (oWp.Status > Convert.ToInt32(RT2020.DAL.Common.Enums.Status.Inactive.ToString("d")))
                        {
                            if (!oWp.Retired)
                            {
                                this.Context.Session.IsLoggedOn = true;

                                Common.Utility.CurrentWorkplaceId = oWp.WorkplaceId;
                            }
                            else
                            {
                                this.lblErrorMessage.Text = "Shop was retired!";
                            }
                        }
                        else
                        {
                            this.lblErrorMessage.Text = "Shop is inactivate! Please contact system administrator!";
                        }
                    }
                    else
                    {
                        bFailed = true;
                    }
                }
                else
                {
                    bFailed = true;
                }
            }
            else
            {
                bFailed = true;
            }

            if (bFailed)
            {
                // When user inputs incorrect staff number or password, prompt user the error message.
                // To Do: We can try to limited the times of attempt to 5 or less.
                this.lblErrorMessage.Text = "Incorrect Shop Number or Password! Please try again!";
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
            if (Verify())
            {
                if (AuthLogon())
                {
                    // Close the Logon form
                    this.Close();
                }
            }
            else
            {
                this.Context.Session.IsLoggedOn = false;
            }
        }
    }
}