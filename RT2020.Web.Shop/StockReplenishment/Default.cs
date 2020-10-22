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

namespace RT2020.Web.Shop.StockReplenishment
{
    public partial class Default : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Default"/> class.
        /// </summary>
        public Default()
        {
            InitializeComponent();

            headerPane.FormTitle = "Stock Replenishment Confirmation";
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
            Common.NavMenu.FillNavTree("rpl", this.tvLeftPaneMenu.Nodes);

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
                    case "rpl_confirmation":
                        Confirmation oConfirmation = new Confirmation();
                        oConfirmation.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oConfirmation);
                        break;
                    case "rpl_specialrequest":
                        SpecialRequest oSpecialRequest = new SpecialRequest();
                        oSpecialRequest.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSpecialRequest);
                        break;
                    case "rpl_back":
                        //this.Close();
                        this.Context.Transfer(new Desktop());
                        break;
                }
            }
        }
    }
}