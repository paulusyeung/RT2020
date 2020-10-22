#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Web.Shop.Transfer
{
    public partial class Default : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Default"/> class.
        /// </summary>
        public Default()
        {
            InitializeComponent();

            headerPane.FormTitle = "Transfer-In Confirmation";
        }

        /// <summary>
        /// Handles the Load event of the Default control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void Default_Load(object sender, EventArgs e)
        {
            FillMenuTree();
        }

        /// <summary>
        /// Fills the menu tree.
        /// </summary>
        private void FillMenuTree()
        {
            Common.NavMenu.FillNavTree("txf", this.tvLeftPaneMenu.Nodes);

            this.tvLeftPaneMenu.ExpandAll();
        }

        /// <summary>
        /// Handles the NodeMouseClick event of the tvLeftPaneMenu control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        private void tvLeftPaneMenu_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node != null)
            {
                contentPane.Controls.Clear();

                ShowWorkspace(ref contentPane, (string)e.Node.Tag);
            }
        }

        /// <summary>
        /// Shows the workspace.
        /// </summary>
        /// <param name="wspPane">The WSP pane.</param>
        /// <param name="Tag">The tag.</param>
        private void ShowWorkspace(ref Panel wspPane, string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                switch (Tag.ToLower())
                {
                    case "txf_intransit":
                        InTransit frmInTransit = new InTransit();
                        frmInTransit.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(frmInTransit);
                        break;
                    case "txf_confirmation":
                        Confirmation frmConfirmation = new Confirmation();
                        frmConfirmation.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(frmConfirmation);
                        break;
                    case "txf_history":
                        History frmHistory = new History();
                        frmHistory.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(frmHistory);
                        break;
                    case "txf_dailysummary":
                        DailySummary frmDailySummary = new DailySummary();
                        frmDailySummary.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(frmDailySummary);
                        break;
                    case "txf_back":
                        //this.Close();
                        this.Context.Transfer(new Desktop());
                        break;
                }
            }
        }
    }
}