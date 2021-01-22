using System;
using Gizmox.WebGUI.Forms;

namespace RT2020.NavPane
{
    partial class MemberMgmtNav
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.navMemberMgmt = new Gizmox.WebGUI.Forms.TreeView();
            this.SuspendLayout();
            // 
            // navMemberMgmt
            // 
            this.navMemberMgmt.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.navMemberMgmt.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.None;
            this.navMemberMgmt.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.navMemberMgmt.Location = new System.Drawing.Point(0, 0);
            this.navMemberMgmt.Name = "navMemberMgmt";
            this.navMemberMgmt.ShowLines = false;
            this.navMemberMgmt.Size = new System.Drawing.Size(1119, 871);
            this.navMemberMgmt.TabIndex = 0;
            this.navMemberMgmt.AfterSelect += new Gizmox.WebGUI.Forms.TreeViewEventHandler(this.navMemberMgmt_AfterSelect);
            // 
            // MemberMgmt
            // 
            this.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.Controls.Add(this.navMemberMgmt);
            this.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.Size = new System.Drawing.Size(1119, 871);
            this.Text = "Member Mgmt";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TreeView navMemberMgmt;


    }
}