namespace RT2020.Purchasing.Wizard
{
    partial class ReceivingFind
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
            this.lblPONumber = new Gizmox.WebGUI.Forms.Label();
            this.txtPONumber = new Gizmox.WebGUI.Forms.TextBox();
            this.txtType = new Gizmox.WebGUI.Forms.TextBox();
            this.lblType = new Gizmox.WebGUI.Forms.Label();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.grbPurchaseOrder = new Gizmox.WebGUI.Forms.GroupBox();
            this.lisReceivingFindList = new Gizmox.WebGUI.Forms.ListView();
            this.colOrderHeaderId = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colRecords = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colPONumber = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.colType = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // lblPONumber
            // 
            this.lblPONumber.AutoSize = true;
            this.lblPONumber.ClientAction = null;
            this.lblPONumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblPONumber.Location = new System.Drawing.Point(72, 20);
            this.lblPONumber.Name = "lblPONumber";
            this.lblPONumber.Size = new System.Drawing.Size(61, 13);
            this.lblPONumber.TabIndex = 0;
            this.lblPONumber.Text = "PO Number";
            // 
            // txtPONumber
            // 
            this.txtPONumber.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtPONumber.ClientAction = null;
            this.txtPONumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtPONumber.Location = new System.Drawing.Point(139, 17);
            this.txtPONumber.Name = "txtPONumber";
            this.txtPONumber.Size = new System.Drawing.Size(153, 20);
            this.txtPONumber.TabIndex = 1;
            // 
            // txtType
            // 
            this.txtType.CharacterCasing = Gizmox.WebGUI.Forms.CharacterCasing.Normal;
            this.txtType.ClientAction = null;
            this.txtType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.txtType.Location = new System.Drawing.Point(139, 43);
            this.txtType.Name = "txtType";
            this.txtType.Size = new System.Drawing.Size(153, 20);
            this.txtType.TabIndex = 1;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.ClientAction = null;
            this.lblType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblType.Location = new System.Drawing.Point(72, 46);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(31, 13);
            this.lblType.TabIndex = 0;
            this.lblType.Text = "Type";
            // 
            // btnFind
            // 
            this.btnFind.ClientAction = null;
            this.btnFind.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnFind.Location = new System.Drawing.Point(312, 41);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // grbPurchaseOrder
            // 
            this.grbPurchaseOrder.ClientAction = null;
            this.grbPurchaseOrder.Controls.Add(this.lisReceivingFindList);
            this.grbPurchaseOrder.Controls.Add(this.btnCancel);
            this.grbPurchaseOrder.Controls.Add(this.btnOK);
            this.grbPurchaseOrder.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.grbPurchaseOrder.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.grbPurchaseOrder.Location = new System.Drawing.Point(12, 70);
            this.grbPurchaseOrder.Name = "grbPurchaseOrder";
            this.grbPurchaseOrder.Size = new System.Drawing.Size(440, 278);
            this.grbPurchaseOrder.TabIndex = 3;
            // 
            // lisReceivingFindList
            // 
            this.lisReceivingFindList.ClientAction = null;
            this.lisReceivingFindList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colOrderHeaderId,
            this.colRecords,
            this.colPONumber,
            this.colType});
            this.lisReceivingFindList.DataMember = null;
            this.lisReceivingFindList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lisReceivingFindList.ItemsPerPage = 20;
            this.lisReceivingFindList.Location = new System.Drawing.Point(11, 19);
            this.lisReceivingFindList.Name = "lisReceivingFindList";
            this.lisReceivingFindList.Size = new System.Drawing.Size(417, 222);
            this.lisReceivingFindList.TabIndex = 3;
            // 
            // colOrderHeaderId
            // 
            this.colOrderHeaderId.ClientAction = null;
            this.colOrderHeaderId.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colOrderHeaderId.Image = null;
            this.colOrderHeaderId.Text = "OrderHeaderId";
            this.colOrderHeaderId.Visible = false;
            this.colOrderHeaderId.Width = 1;
            // 
            // colRecords
            // 
            this.colRecords.ClientAction = null;
            this.colRecords.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colRecords.Image = null;
            this.colRecords.Text = "Records";
            this.colRecords.Width = 80;
            // 
            // colPONumber
            // 
            this.colPONumber.ClientAction = null;
            this.colPONumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colPONumber.Image = null;
            this.colPONumber.Text = "PO Number";
            this.colPONumber.Width = 200;
            // 
            // colType
            // 
            this.colType.ClientAction = null;
            this.colType.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.colType.Image = null;
            this.colType.Text = "Type";
            this.colType.Width = 80;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.btnCancel.ClientAction = null;
            this.btnCancel.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnCancel.Location = new System.Drawing.Point(235, 249);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((Gizmox.WebGUI.Forms.AnchorStyles)((Gizmox.WebGUI.Forms.AnchorStyles.Bottom | Gizmox.WebGUI.Forms.AnchorStyles.Left)));
            this.btnOK.ClientAction = null;
            this.btnOK.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnOK.Location = new System.Drawing.Point(127, 249);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // ReceivingFind
            // 
            this.AcceptButton = this.btnOK;
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.grbPurchaseOrder);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.txtType);
            this.Controls.Add(this.txtPONumber);
            this.Controls.Add(this.lblPONumber);
            this.Size = new System.Drawing.Size(464, 358);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblPONumber;
        private Gizmox.WebGUI.Forms.TextBox txtPONumber;
        private Gizmox.WebGUI.Forms.TextBox txtType;
        private Gizmox.WebGUI.Forms.Label lblType;
        private Gizmox.WebGUI.Forms.Button btnFind;
        private Gizmox.WebGUI.Forms.GroupBox grbPurchaseOrder;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.ListView lisReceivingFindList;
        private Gizmox.WebGUI.Forms.ColumnHeader colOrderHeaderId;
        private Gizmox.WebGUI.Forms.ColumnHeader colRecords;
        private Gizmox.WebGUI.Forms.ColumnHeader colPONumber;
        private Gizmox.WebGUI.Forms.ColumnHeader colType;


    }
}