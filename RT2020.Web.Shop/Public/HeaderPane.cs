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

namespace RT2020.Web.Shop.Public
{
    public partial class HeaderPane : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderPane"/> class.
        /// </summary>
        public HeaderPane()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the HeaderPane control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>  
        private void HeaderPane_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                VersionNumber();
                ShowCustomerCompanyName();
                ShowShop();
            }

            this.lnkLogoff.Visible = this.Context.Session.IsLoggedOn;
            this.lblShop.Visible = this.Context.Session.IsLoggedOn;
        }

        /// <summary>
        /// the number Version.
        /// </summary>
        private void VersionNumber()
        {
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.lblVersionNumber.Text = version.ToString() + " (" + Gizmox.WebGUI.WGConst.Version.ToString() + ")";
        }

        /// <summary>
        /// Shows the name of the customer's company.
        /// </summary>
        private void ShowCustomerCompanyName()
        {
            SystemInfoCollection infoList = SystemInfo.LoadCollection(new string[] { "ShopNumber" }, true);
            if (infoList.Count > 0)
            {
                SystemInfo oInfo = infoList[0];
                if (oInfo != null)
                {
                    lblCompanyName.Text = oInfo.CompanyName;
                }
            }
        }

        /// <summary>
        /// Shows the shop.
        /// </summary>
        private void ShowShop()
        {
            Workplace oWp = Workplace.Load(Common.Utility.CurrentWorkplaceId);
            if (oWp != null)
            {
                lblShop.Text = "Shop : " + oWp.WorkplaceCode + " - " + oWp.WorkplaceName;
            }
        }

        /// <summary>
        /// Handles the Click event of the lnkLogoff control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lnkLogoff_Click(object sender, EventArgs e)
        {
            Common.Utility.CurrentUserId = System.Guid.Empty;
            Common.Utility.CurrentWorkplaceId = System.Guid.Empty;

            //this.Context.Terminate(true); // This will termniate all process

            // While setting the IsLoggedOn to false, will redirect to Logon Page.
            this.Context.Session.IsLoggedOn = false;
        }

        /// <summary>
        /// Gets or sets the form title.
        /// </summary>
        /// <value>The form title.</value>
        public string FormTitle
        {
            get
            {
                return this.lblFormTitle.Text;
            }
            set
            {
                this.lblFormTitle.Text = value;
            }
        }
    }
}