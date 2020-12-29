namespace RT2020.Member
{
    partial class MemberWizard
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
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.tabMember = new Gizmox.WebGUI.Forms.TabControl();
            this.tpMainInfo = new Gizmox.WebGUI.Forms.TabPage();
            this.tpAddressInfo = new Gizmox.WebGUI.Forms.TabPage();
            this.tpCardInfo = new Gizmox.WebGUI.Forms.TabPage();
            this.tpOthersInfo = new Gizmox.WebGUI.Forms.TabPage();
            this.tpMiscInfo = new Gizmox.WebGUI.Forms.TabPage();
            this.tpMarketingInfo = new Gizmox.WebGUI.Forms.TabPage();
            this.lblMemberNumber = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.txtMemberNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLineOfOperation = new Gizmox.WebGUI.Forms.Label();
            this.cboLineOfOperation = new Gizmox.WebGUI.Forms.ComboBox();
            this.chkVIP = new Gizmox.WebGUI.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.tabMember)).BeginInit();
            this.tabMember.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.DataMember = "\"\"";
            this.errorProvider.DataSource = null;
            // 
            // tabMember
            // 
            this.tabMember.Controls.Add(this.tpMainInfo);
            this.tabMember.Controls.Add(this.tpAddressInfo);
            this.tabMember.Controls.Add(this.tpCardInfo);
            this.tabMember.Controls.Add(this.tpOthersInfo);
            this.tabMember.Controls.Add(this.tpMiscInfo);
            this.tabMember.Controls.Add(this.tpMarketingInfo);
            this.tabMember.Location = new System.Drawing.Point(12, 83);
            this.tabMember.Name = "tabMember";
            this.tabMember.SelectedIndex = 0;
            this.tabMember.Size = new System.Drawing.Size(774, 421);
            this.tabMember.TabIndex = 2;
            this.tabMember.SelectedIndexChanged += new System.EventHandler(this.tabMember_SelectedIndexChanged);
            // 
            // tpMainInfo
            // 
            this.tpMainInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpMainInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMainInfo.Name = "tpMainInfo";
            this.tpMainInfo.Size = new System.Drawing.Size(766, 395);
            this.tpMainInfo.TabIndex = 0;
            this.tpMainInfo.Text = "Main Info";
            // 
            // tpAddressInfo
            // 
            this.tpAddressInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpAddressInfo.Location = new System.Drawing.Point(4, 22);
            this.tpAddressInfo.Name = "tpAddressInfo";
            this.tpAddressInfo.Size = new System.Drawing.Size(766, 395);
            this.tpAddressInfo.TabIndex = 0;
            this.tpAddressInfo.Text = "Address Info";
            // 
            // tpCardInfo
            // 
            this.tpCardInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpCardInfo.Location = new System.Drawing.Point(4, 22);
            this.tpCardInfo.Name = "tpCardInfo";
            this.tpCardInfo.Size = new System.Drawing.Size(766, 395);
            this.tpCardInfo.TabIndex = 2;
            this.tpCardInfo.Text = "Card Info";
            // 
            // tpOthersInfo
            // 
            this.tpOthersInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpOthersInfo.Location = new System.Drawing.Point(4, 22);
            this.tpOthersInfo.Name = "tpOthersInfo";
            this.tpOthersInfo.Size = new System.Drawing.Size(766, 395);
            this.tpOthersInfo.TabIndex = 1;
            this.tpOthersInfo.Text = "Others Info";
            // 
            // tpMiscInfo
            // 
            this.tpMiscInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpMiscInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMiscInfo.Name = "tpMiscInfo";
            this.tpMiscInfo.Size = new System.Drawing.Size(766, 395);
            this.tpMiscInfo.TabIndex = 3;
            this.tpMiscInfo.Text = "Misc Info";
            // 
            // tpMarketingInfo
            // 
            this.tpMarketingInfo.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.tpMarketingInfo.Location = new System.Drawing.Point(4, 22);
            this.tpMarketingInfo.Name = "tpMarketingInfo";
            this.tpMarketingInfo.Size = new System.Drawing.Size(766, 395);
            this.tpMarketingInfo.TabIndex = 4;
            this.tpMarketingInfo.Text = "Marketing Info";
            // 
            // lblMemberNumber
            // 
            this.lblMemberNumber.Location = new System.Drawing.Point(23, 46);
            this.lblMemberNumber.Name = "lblMemberNumber";
            this.lblMemberNumber.Size = new System.Drawing.Size(61, 23);
            this.lblMemberNumber.TabIndex = 0;
            this.lblMemberNumber.Text = "Member #:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(100, 22);
            this.tbWizardAction.TabIndex = 0;
            // 
            // txtMemberNumber
            // 
            this.txtMemberNumber.Location = new System.Drawing.Point(90, 43);
            this.txtMemberNumber.MaxLength = 13;
            this.txtMemberNumber.Name = "txtMemberNumber";
            this.txtMemberNumber.Size = new System.Drawing.Size(100, 20);
            this.txtMemberNumber.TabIndex = 0;
            // 
            // lblLineOfOperation
            // 
            this.lblLineOfOperation.Location = new System.Drawing.Point(257, 46);
            this.lblLineOfOperation.Name = "lblLineOfOperation";
            this.lblLineOfOperation.Size = new System.Drawing.Size(98, 23);
            this.lblLineOfOperation.TabIndex = 0;
            this.lblLineOfOperation.Text = "Line Of Operation:";
            this.lblLineOfOperation.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // cboLineOfOperation
            // 
            this.cboLineOfOperation.BackColor = System.Drawing.Color.PaleTurquoise;
            this.cboLineOfOperation.DropDownWidth = 121;
            this.cboLineOfOperation.Location = new System.Drawing.Point(363, 43);
            this.cboLineOfOperation.Name = "cboLineOfOperation";
            this.cboLineOfOperation.Size = new System.Drawing.Size(121, 21);
            this.cboLineOfOperation.TabIndex = 1;
            this.cboLineOfOperation.LostFocus += new System.EventHandler(this.cboLineOfOperation_LostFocus);
            // 
            // chkVIP
            // 
            this.chkVIP.Location = new System.Drawing.Point(567, 41);
            this.chkVIP.Name = "chkVIP";
            this.chkVIP.Size = new System.Drawing.Size(215, 24);
            this.chkVIP.TabIndex = 3;
            this.chkVIP.Text = "Upgrade to VIP";
            this.chkVIP.Click += new System.EventHandler(this.chkVIP_Click);
            // 
            // MemberWizard
            // 
            this.Controls.Add(this.chkVIP);
            this.Controls.Add(this.cboLineOfOperation);
            this.Controls.Add(this.lblLineOfOperation);
            this.Controls.Add(this.txtMemberNumber);
            this.Controls.Add(this.tbWizardAction);
            this.Controls.Add(this.lblMemberNumber);
            this.Controls.Add(this.tabMember);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(798, 516);
            this.Text = "Member Wizard";
            this.Load += new System.EventHandler(this.MemberWizard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabMember)).EndInit();
            this.tabMember.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.TabControl tabMember;
        private Gizmox.WebGUI.Forms.TabPage tpMainInfo;
        private Gizmox.WebGUI.Forms.TabPage tpAddressInfo;
        private Gizmox.WebGUI.Forms.TabPage tpCardInfo;
        private Gizmox.WebGUI.Forms.TabPage tpOthersInfo;
        private Gizmox.WebGUI.Forms.TabPage tpMiscInfo;
        private Gizmox.WebGUI.Forms.TabPage tpMarketingInfo;
        private Gizmox.WebGUI.Forms.Label lblMemberNumber;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.TextBox txtMemberNumber;
        private Gizmox.WebGUI.Forms.Label lblLineOfOperation;
        private Gizmox.WebGUI.Forms.ComboBox cboLineOfOperation;
        private Gizmox.WebGUI.Forms.CheckBox chkVIP;


    }
}