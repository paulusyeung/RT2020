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
using System.Configuration;
using System.Web;

#endregion

namespace RT2020.Web.Reports.Controls
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
            lblTitle.ForeColor = Color.FromArgb(83, 99, 159);

            if (!this.DesignMode)
            {
                Uri request = VWGContext.Current.HttpContext.Request.Url;
                lnkGotoWepShop.Url = string.Format(ConfigurationManager.AppSettings["WebShop"], request.Host);

                VersionNumber();
                ShowCustomerCompanyName();
            }
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
        /// Handles the Click event of the lnkHome control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lnkHome_Click(object sender, EventArgs e)
        {
            this.Context.Transfer(new WebReports());
        }
    }
}