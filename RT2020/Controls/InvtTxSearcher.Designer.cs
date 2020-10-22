namespace RT2020.Controls
{
    partial class InvtTxSearcher
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
            this.lblTxNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblTxType = new Gizmox.WebGUI.Forms.Label();
            this.txtTxNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtTxType = new Gizmox.WebGUI.Forms.TextBox();
            this.lvResultList = new Gizmox.WebGUI.Forms.ListView();
            this.colHeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colLine = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxNumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colTxDate = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.toolTip = new Gizmox.WebGUI.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lblTxNumber
            // 
            this.lblTxNumber.AutoSize = true;
            this.lblTxNumber.Location = new System.Drawing.Point(47, 27);
            this.lblTxNumber.Name = "lblTxNumber";
            this.lblTxNumber.Size = new System.Drawing.Size(100, 23);
            this.lblTxNumber.TabIndex = 0;
            this.lblTxNumber.Text = "Tx Number:";
            // 
            // lblTxType
            // 
            this.lblTxType.AutoSize = true;
            this.lblTxType.Location = new System.Drawing.Point(47, 53);
            this.lblTxType.Name = "lblTxType";
            this.lblTxType.Size = new System.Drawing.Size(100, 23);
            this.lblTxType.TabIndex = 1;
            this.lblTxType.Text = "Tx Type:";
            // 
            // txtTxNumber
            // 
            this.txtTxNumber.Location = new System.Drawing.Point(116, 24);
            this.txtTxNumber.Name = "txtTxNumber";
            this.txtTxNumber.Size = new System.Drawing.Size(163, 20);
            this.txtTxNumber.TabIndex = 2;
            // 
            // txtTxType
            // 
            this.txtTxType.Location = new System.Drawing.Point(116, 50);
            this.txtTxType.Name = "txtTxType";
            this.txtTxType.Size = new System.Drawing.Size(163, 20);
            this.txtTxType.TabIndex = 3;
            // 
            // lvResultList
            // 
            this.lvResultList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colHeaderId,
            this.colLine,
            this.colTxNumber,
            this.colTxType,
            this.colTxDate});
            this.lvResultList.DataMember = null;
            this.lvResultList.ItemsPerPage = 20;
            this.lvResultList.Location = new System.Drawing.Point(12, 77);
            this.lvResultList.MultiSelect = false;
            this.lvResultList.Name = "lvResultList";
            this.lvResultList.Size = new System.Drawing.Size(395, 377);
            this.lvResultList.TabIndex = 4;
            this.toolTip.SetToolTip(this.lvResultList, "Double click the Transaction number");
            this.lvResultList.DoubleClick += new System.EventHandler(this.lvResultList_DoubleClick);
            // 
            // colHeaderId
            // 
            this.colHeaderId.Image = null;
            this.colHeaderId.Text = "HeaderId";
            this.colHeaderId.Visible = false;
            this.colHeaderId.Width = 150;
            // 
            // colLine
            // 
            this.colLine.Image = null;
            this.colLine.Text = "Line";
            this.colLine.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colLine.Width = 40;
            // 
            // colTxNumber
            // 
            this.colTxNumber.Image = null;
            this.colTxNumber.Text = "Tx Number";
            this.colTxNumber.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colTxNumber.Width = 90;
            // 
            // colTxType
            // 
            this.colTxType.Image = null;
            this.colTxType.Text = "Tx Type";
            this.colTxType.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colTxType.Width = 55;
            // 
            // colTxDate
            // 
            this.colTxDate.Image = null;
            this.colTxDate.Text = "Tx Date";
            this.colTxDate.Width = 90;
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(297, 48);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 5;
            this.btnFind.Text = "Find";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // InvtTxSearcher
            // 
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lvResultList);
            this.Controls.Add(this.txtTxType);
            this.Controls.Add(this.txtTxNumber);
            this.Controls.Add(this.lblTxType);
            this.Controls.Add(this.lblTxNumber);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 466);
            this.Text = "InvtTxSearcher";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTxNumber;
        private Gizmox.WebGUI.Forms.Label lblTxType;
        private Gizmox.WebGUI.Forms.TextBox txtTxNumber;
        private Gizmox.WebGUI.Forms.TextBox txtTxType;
        private Gizmox.WebGUI.Forms.ListView lvResultList;
        private Gizmox.WebGUI.Forms.ColumnHeader colHeaderId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLine;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxNumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxType;
        private Gizmox.WebGUI.Forms.ColumnHeader colTxDate;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.ToolTip toolTip;


    }
}