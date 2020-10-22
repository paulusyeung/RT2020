using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.Components.Layout
{
    partial class TopPane
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
            this.picLogo = new Gizmox.WebGUI.Forms.PictureBox();
            this.pnlBaseRight = new Gizmox.WebGUI.Forms.Panel();
            this.pnlTaskbarRight = new Gizmox.WebGUI.Forms.Panel();
            this.butLanguage = new Gizmox.WebGUI.Forms.Button();
            this.butTheme = new Gizmox.WebGUI.Forms.Button();
            this.butPower = new Gizmox.WebGUI.Forms.Button();
            this.pnlTaskbarLeft = new Gizmox.WebGUI.Forms.Panel();
            this.butDrawer = new Gizmox.WebGUI.Forms.Button();
            this.toolTip = new Gizmox.WebGUI.Forms.ToolTip();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnlBaseRight.SuspendLayout();
            this.pnlTaskbarRight.SuspendLayout();
            this.pnlTaskbarLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // picLogo
            // 
            this.picLogo.Dock = Gizmox.WebGUI.Forms.DockStyle.Left;
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(150, 300);
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            // 
            // pnlBaseRight
            // 
            this.pnlBaseRight.Controls.Add(this.pnlTaskbarRight);
            this.pnlBaseRight.Controls.Add(this.pnlTaskbarLeft);
            this.pnlBaseRight.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.pnlBaseRight.Location = new System.Drawing.Point(150, 0);
            this.pnlBaseRight.Name = "pnlBaseRight";
            this.pnlBaseRight.Size = new System.Drawing.Size(450, 300);
            this.pnlBaseRight.TabIndex = 1;
            // 
            // pnlTaskbarRight
            // 
            this.pnlTaskbarRight.Controls.Add(this.butLanguage);
            this.pnlTaskbarRight.Controls.Add(this.butTheme);
            this.pnlTaskbarRight.Controls.Add(this.butPower);
            this.pnlTaskbarRight.Location = new System.Drawing.Point(139, 17);
            this.pnlTaskbarRight.Name = "pnlTaskbarRight";
            this.pnlTaskbarRight.Size = new System.Drawing.Size(293, 100);
            this.pnlTaskbarRight.TabIndex = 1;
            // 
            // butLanguage
            // 
            this.butLanguage.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.butLanguage.ImageSize = new System.Drawing.Size(24, 24);
            this.butLanguage.Location = new System.Drawing.Point(194, 16);
            this.butLanguage.Name = "butLanguage";
            this.butLanguage.Size = new System.Drawing.Size(36, 36);
            this.butLanguage.TabIndex = 0;
            this.butLanguage.TabStop = false;
            this.butLanguage.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageBeforeText;
            // 
            // butTheme
            // 
            this.butTheme.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.butTheme.ImageSize = new System.Drawing.Size(32, 32);
            this.butTheme.Location = new System.Drawing.Point(144, 16);
            this.butTheme.Name = "butTheme";
            this.butTheme.Size = new System.Drawing.Size(36, 36);
            this.butTheme.TabIndex = 0;
            this.butTheme.TabStop = false;
            // 
            // butPower
            // 
            this.butPower.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Top | Gizmox.WebGUI.Forms.AnchorStyles.Right)));
            this.butPower.ImageSize = new System.Drawing.Size(32, 32);
            this.butPower.Location = new System.Drawing.Point(243, 16);
            this.butPower.Name = "butPower";
            this.butPower.Size = new System.Drawing.Size(36, 36);
            this.butPower.TabIndex = 0;
            this.butPower.TabStop = false;
            // 
            // pnlTaskbarLeft
            // 
            this.pnlTaskbarLeft.Controls.Add(this.butDrawer);
            this.pnlTaskbarLeft.Location = new System.Drawing.Point(21, 17);
            this.pnlTaskbarLeft.Name = "pnlTaskbarLeft";
            this.pnlTaskbarLeft.Size = new System.Drawing.Size(100, 100);
            this.pnlTaskbarLeft.TabIndex = 0;
            // 
            // butDrawer
            // 
            this.butDrawer.ImageSize = new System.Drawing.Size(32, 32);
            this.butDrawer.Location = new System.Drawing.Point(16, 16);
            this.butDrawer.Name = "butDrawer";
            this.butDrawer.Size = new System.Drawing.Size(36, 36);
            this.butDrawer.TabIndex = 0;
            this.butDrawer.TabStop = false;
            // 
            // TopPane
            // 
            this.Controls.Add(this.pnlBaseRight);
            this.Controls.Add(this.picLogo);
            this.Size = new System.Drawing.Size(600, 300);
            this.Text = "TopPane";
            this.Load += new System.EventHandler(this.TopPane_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnlBaseRight.ResumeLayout(false);
            this.pnlTaskbarRight.ResumeLayout(false);
            this.pnlTaskbarLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private PictureBox picLogo;
        private Panel pnlBaseRight;
        private Panel pnlTaskbarRight;
        private Panel pnlTaskbarLeft;
        private Button butDrawer;
        private Button butPower;
        private ToolTip toolTip;
        private Button butLanguage;
        private Button butTheme;
    }
}