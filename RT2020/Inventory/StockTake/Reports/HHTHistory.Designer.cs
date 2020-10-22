namespace RT2020.Inventory.StockTake.Reports
{
    partial class HHTHistory
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
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.cboTxNumber = new Gizmox.WebGUI.Forms.ComboBox();
            this.gbData = new Gizmox.WebGUI.Forms.GroupBox();
            this.rbtnUnmatchedData = new Gizmox.WebGUI.Forms.RadioButton();
            this.rbtnAllData = new Gizmox.WebGUI.Forms.RadioButton();
            this.btnPreview = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.Location = new System.Drawing.Point(12, 9);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(231, 18);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "From TRN# / HHT-ID / Upload Date :";
            // 
            // cboTxNumber
            // 
            this.cboTxNumber.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboTxNumber.Location = new System.Drawing.Point(15, 30);
            this.cboTxNumber.MaxDropDownItems = 6;
            this.cboTxNumber.Name = "cboTxNumber";
            this.cboTxNumber.Size = new System.Drawing.Size(392, 21);
            this.cboTxNumber.TabIndex = 1;
            // 
            // gbData
            // 
            this.gbData.Controls.Add(this.rbtnUnmatchedData);
            this.gbData.Controls.Add(this.rbtnAllData);
            this.gbData.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbData.Location = new System.Drawing.Point(15, 57);
            this.gbData.Name = "gbData";
            this.gbData.Size = new System.Drawing.Size(200, 82);
            this.gbData.TabIndex = 2;
            this.gbData.Text = "Data";
            // 
            // rbtnUnmatchedData
            // 
            this.rbtnUnmatchedData.Enabled = false;
            this.rbtnUnmatchedData.Location = new System.Drawing.Point(18, 43);
            this.rbtnUnmatchedData.Name = "rbtnUnmatchedData";
            this.rbtnUnmatchedData.Size = new System.Drawing.Size(104, 24);
            this.rbtnUnmatchedData.TabIndex = 4;
            this.rbtnUnmatchedData.Text = "Un-matched";
            // 
            // rbtnAllData
            // 
            this.rbtnAllData.Checked = true;
            this.rbtnAllData.Location = new System.Drawing.Point(18, 19);
            this.rbtnAllData.Name = "rbtnAllData";
            this.rbtnAllData.Size = new System.Drawing.Size(104, 24);
            this.rbtnAllData.TabIndex = 3;
            this.rbtnAllData.Text = "All";
            // 
            // btnPreview
            // 
            this.btnPreview.Location = new System.Drawing.Point(237, 116);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(75, 23);
            this.btnPreview.TabIndex = 3;
            this.btnPreview.Text = "Preview";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(332, 116);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // HHTHistory
            // 
            this.CancelButton = this.btnExit;
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.gbData);
            this.Controls.Add(this.cboTxNumber);
            this.Controls.Add(this.lblTxNumber);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 156);
            this.Text = "HHT Quantity History";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.ComboBox cboTxNumber;
        private Gizmox.WebGUI.Forms.GroupBox gbData;
        private Gizmox.WebGUI.Forms.RadioButton rbtnUnmatchedData;
        private Gizmox.WebGUI.Forms.RadioButton rbtnAllData;
        private Gizmox.WebGUI.Forms.Button btnPreview;
        private Gizmox.WebGUI.Forms.Button btnExit;


    }
}