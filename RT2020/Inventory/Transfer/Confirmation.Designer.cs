namespace RT2020.Inventory.Transfer
{
    partial class Confirmation
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
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lvPostTxList = new Gizmox.WebGUI.Forms.ListView();
            this.colTxId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLN = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxferDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colCompDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colFromWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colToWorkplace = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLastUpdated = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colErrorMsg = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.SuspendLayout();
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(15, 32);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(253, 20);
            this.txtTxNumber.TabIndex = 1;
            this.txtTxNumber.KeyUp += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtTxNumber_KeyUp);
            this.txtTxNumber.TextChanged += new System.EventHandler(this.txtTxNumber_TextChanged);
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(12, 9);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(300, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "Please input a Transfer Number to search:";
            // 
            // lvPostTxList
            // 
            this.lvPostTxList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colTxId,
            this.colLN,
            this.colTxNumber,
            this.colTxDate,
            this.colTxferDate,
            this.colCompDate,
            this.colFromWorkplace,
            this.colToWorkplace,
            this.colLastUpdated,
            this.colErrorMsg});
            this.lvPostTxList.DataMember = null;
            this.lvPostTxList.ItemsPerPage = 20;
            this.lvPostTxList.Location = new System.Drawing.Point(15, 58);
            this.lvPostTxList.Name = "lvPostTxList";
            this.lvPostTxList.Size = new System.Drawing.Size(731, 475);
            this.lvPostTxList.TabIndex = 0;
            this.lvPostTxList.DoubleClick += new System.EventHandler(this.lvPostTxList_DoubleClick);
            // 
            // colTxId
            // 
            this.colTxId.Image = null;
            this.colTxId.Text = "TxId";
            this.colTxId.Visible = false;
            this.colTxId.Width = 150;
            // 
            // colLN
            // 
            this.colLN.Image = null;
            this.colLN.Text = "LN";
            this.colLN.Width = 30;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Tx Number";
            this.colTxNumber.Width = 80;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Tx Date";
            this.colTxDate.Width = 70;
            // 
            // colTxferDate
            // 
            this.colTxferDate.Image = null;
            this.colTxferDate.Text = "Txfer Date";
            this.colTxferDate.Width = 70;
            // 
            // colCompDate
            // 
            this.colCompDate.Image = null;
            this.colCompDate.Text = "Completed Date";
            this.colCompDate.Width = 70;
            // 
            // colFromWorkplace
            // 
            this.colFromWorkplace.Image = null;
            this.colFromWorkplace.Text = "From Loc#";
            this.colFromWorkplace.Width = 80;
            // 
            // colToWorkplace
            // 
            this.colToWorkplace.Image = null;
            this.colToWorkplace.Text = "To Loc#";
            this.colToWorkplace.Width = 80;
            // 
            // colLastUpdated
            // 
            this.colLastUpdated.Image = null;
            this.colLastUpdated.Text = "Last Update";
            this.colLastUpdated.Width = 80;
            // 
            // colErrorMsg
            // 
            this.colErrorMsg.Image = null;
            this.colErrorMsg.Text = "Error Message";
            this.colErrorMsg.Width = 150;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            this.errorProvider.BlinkStyle = Gizmox.WebGUI.Forms.ErrorBlinkStyle.BlinkIfDifferentError;
            this.errorProvider.DataMember = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.DataSource = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.errorProvider.Icon = null;
            // 
            // Confirmation
            // 
            this.Controls.Add(this.lvPostTxList);
            this.Controls.Add(this.lblTxNumber);
            this.Controls.Add(this.txtTxNumber);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(758, 546);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Transfer > Confirmation";
            this.Load += new System.EventHandler(this.Confirmation_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.ListView lvPostTxList;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxferDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colCompDate;
        private Gizmox.WebGUI.Forms.ColumnHeader colFromWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colToWorkplace;
        private Gizmox.WebGUI.Forms.ColumnHeader colLastUpdated;
        private Gizmox.WebGUI.Forms.ColumnHeader colErrorMsg;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;


    }
}