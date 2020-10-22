namespace RT2020.PriceMgmt
{
    partial class ReasonCodeWizard
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.lblReasonName_Cht = new Gizmox.WebGUI.Forms.Label();
            this.lblReasonName_Chs = new Gizmox.WebGUI.Forms.Label();
            this.lblReasonName = new Gizmox.WebGUI.Forms.Label();
            this.lblReasonCode = new Gizmox.WebGUI.Forms.Label();
            this.txtReasonCode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtReasonName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtReasonName_Chs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtReasonName_Cht = new Gizmox.WebGUI.Forms.TextBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.tbWizardAction.Appearance = Gizmox.WebGUI.Forms.ToolBarAppearance.Normal;
            this.tbWizardAction.Dock = Gizmox.WebGUI.Forms.DockStyle.Top;
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = false;
            this.tbWizardAction.ImageList = null;
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            //this.tbWizardAction.RightToLeft = false;
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.TabIndex = 0;
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.txtReasonName_Cht);
            this.mainPane.Controls.Add(this.txtReasonName_Chs);
            this.mainPane.Controls.Add(this.txtReasonName);
            this.mainPane.Controls.Add(this.txtReasonCode);
            this.mainPane.Controls.Add(this.lblReasonName_Cht);
            this.mainPane.Controls.Add(this.lblReasonName_Chs);
            this.mainPane.Controls.Add(this.lblReasonName);
            this.mainPane.Controls.Add(this.lblReasonCode);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 28);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(419, 438);
            this.mainPane.TabIndex = 1;
            // 
            // lblReasonName_Cht
            // 
            this.lblReasonName_Cht.Location = new System.Drawing.Point(22, 101);
            this.lblReasonName_Cht.Name = "lblReasonName_Cht";
            this.lblReasonName_Cht.Size = new System.Drawing.Size(111, 23);
            this.lblReasonName_Cht.TabIndex = 3;
            this.lblReasonName_Cht.Text = "Reason Name (Cht):";
            // 
            // lblReasonName_Chs
            // 
            this.lblReasonName_Chs.Location = new System.Drawing.Point(22, 75);
            this.lblReasonName_Chs.Name = "lblReasonName_Chs";
            this.lblReasonName_Chs.Size = new System.Drawing.Size(111, 23);
            this.lblReasonName_Chs.TabIndex = 2;
            this.lblReasonName_Chs.Text = "Reason Name (Chs):";
            // 
            // lblReasonName
            // 
            this.lblReasonName.Location = new System.Drawing.Point(22, 49);
            this.lblReasonName.Name = "lblReasonName";
            this.lblReasonName.Size = new System.Drawing.Size(111, 23);
            this.lblReasonName.TabIndex = 1;
            this.lblReasonName.Text = "Reason Name : ";
            // 
            // lblReasonCode
            // 
            this.lblReasonCode.Location = new System.Drawing.Point(22, 23);
            this.lblReasonCode.Name = "lblReasonCode";
            this.lblReasonCode.Size = new System.Drawing.Size(111, 23);
            this.lblReasonCode.TabIndex = 0;
            this.lblReasonCode.Text = "Reason Code : ";
            // 
            // txtReasonCode
            // 
            this.txtReasonCode.Location = new System.Drawing.Point(139, 20);
            this.txtReasonCode.Name = "txtReasonCode";
            this.txtReasonCode.Size = new System.Drawing.Size(100, 20);
            this.txtReasonCode.TabIndex = 4;
            // 
            // txtReasonName
            // 
            this.txtReasonName.Location = new System.Drawing.Point(139, 46);
            this.txtReasonName.Name = "txtReasonName";
            this.txtReasonName.Size = new System.Drawing.Size(189, 20);
            this.txtReasonName.TabIndex = 5;
            // 
            // txtReasonName_Chs
            // 
            this.txtReasonName_Chs.Location = new System.Drawing.Point(139, 72);
            this.txtReasonName_Chs.Name = "txtReasonName_Chs";
            this.txtReasonName_Chs.Size = new System.Drawing.Size(189, 20);
            this.txtReasonName_Chs.TabIndex = 6;
            // 
            // txtReasonName_Cht
            // 
            this.txtReasonName_Cht.Location = new System.Drawing.Point(139, 98);
            this.txtReasonName_Cht.Name = "txtReasonName_Cht";
            this.txtReasonName_Cht.Size = new System.Drawing.Size(189, 20);
            this.txtReasonName_Cht.TabIndex = 7;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.Icon = null;
            // 
            // ReasonCodeWizard
            // 
            this.Controls.Add(this.mainPane);
            this.Controls.Add(this.tbWizardAction);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "Reason Code Maintenance";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.Label lblReasonName_Cht;
        private Gizmox.WebGUI.Forms.Label lblReasonName_Chs;
        private Gizmox.WebGUI.Forms.Label lblReasonName;
        private Gizmox.WebGUI.Forms.Label lblReasonCode;
        private Gizmox.WebGUI.Forms.TextBox txtReasonName_Cht;
        private Gizmox.WebGUI.Forms.TextBox txtReasonName_Chs;
        private Gizmox.WebGUI.Forms.TextBox txtReasonName;
        private Gizmox.WebGUI.Forms.TextBox txtReasonCode;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}