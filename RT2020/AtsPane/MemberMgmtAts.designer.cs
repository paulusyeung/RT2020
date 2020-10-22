namespace RT2020.AtsPane
{
    partial class MemberMgmtAts
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
            this.atsMemberMgmt = new Gizmox.WebGUI.Forms.ToolBar();
            this.SuspendLayout();
            // 
            // atsMemberMgmt
            // 
            this.atsMemberMgmt.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.atsMemberMgmt.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.atsMemberMgmt.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.atsMemberMgmt.DragHandle = true;
            this.atsMemberMgmt.DropDownArrows = false;
            this.atsMemberMgmt.ImageList = null;
            this.atsMemberMgmt.Location = new System.Drawing.Point(0, 0);
            this.atsMemberMgmt.MenuHandle = false;
            this.atsMemberMgmt.Name = "atsMemberMgmt";
            //this.atsMemberMgmt.RightToLeft = false;
            this.atsMemberMgmt.ShowToolTips = true;
            this.atsMemberMgmt.TabIndex = 0;
            // 
            // MemberMgmt
            // 
            this.Controls.Add(this.atsMemberMgmt);
            this.Name = "MemberMgmt";
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Member Mgmt";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar atsMemberMgmt;


    }
}