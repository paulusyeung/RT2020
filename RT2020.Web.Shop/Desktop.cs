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

namespace RT2020.Web.Shop
{
    public partial class Desktop : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Default"/> class.
        /// </summary>
        public Desktop()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Load event of the Default control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Default_Load(object sender, EventArgs e)
        {
            headerPane.FormTitle = "Desktop";
        }

        /// <summary>
        /// Handles the Click event of the btnGotoReplenishment control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnGotoReplenishment_Click(object sender, EventArgs e)
        {
            StockReplenishment.Default frmReplenishment = new RT2020.Web.Shop.StockReplenishment.Default();
            frmReplenishment.WindowState = FormWindowState.Maximized;
            frmReplenishment.StartPosition = FormStartPosition.CenterParent;
            //frmReplenishment.Show();

            this.Context.Transfer(frmReplenishment);
        }

        /// <summary>
        /// Handles the Click event of the btnGotoTransferIn control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnGotoTransferIn_Click(object sender, EventArgs e)
        {
            Transfer.Default frmTransfer = new RT2020.Web.Shop.Transfer.Default();
            frmTransfer.WindowState = FormWindowState.Maximized;
            frmTransfer.StartPosition = FormStartPosition.CenterParent;
            //frmTransfer.Show();

            this.Context.Transfer(frmTransfer);
        }
    }
}