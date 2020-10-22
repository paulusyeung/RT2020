namespace RT2020.Controls.ProductSearcher
{
    partial class Basic
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
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle1 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            Gizmox.WebGUI.Common.Resources.IconResourceHandle iconResourceHandle2 = new Gizmox.WebGUI.Common.Resources.IconResourceHandle();
            this.cboFullStockCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.btnFind_Matrix = new Gizmox.WebGUI.Forms.Button();
            this.btnFind = new Gizmox.WebGUI.Forms.Button();
            this.SuspendLayout();
            // 
            // cboFullStockCode
            // 
            this.cboFullStockCode.BackColor = System.Drawing.Color.White;
            this.cboFullStockCode.DropDownWidth = 284;
            this.cboFullStockCode.Location = new System.Drawing.Point(3, 3);
            this.cboFullStockCode.Name = "cboFullStockCode";
            this.cboFullStockCode.Size = new System.Drawing.Size(284, 21);
            this.cboFullStockCode.TabIndex = 1;
            this.cboFullStockCode.TabStop = false;
            this.cboFullStockCode.TextChanged += new System.EventHandler(this.cboFullStockCode_TextChanged);
            this.cboFullStockCode.SelectedIndexChangedQueued += new System.EventHandler(this.cboFullStockCode_SelectedIndexChanged);
            // 
            // btnFind_Matrix
            // 
            iconResourceHandle1.File = "16x16.16_table.gif";
            this.btnFind_Matrix.Image = iconResourceHandle1;
            this.btnFind_Matrix.Location = new System.Drawing.Point(312, 2);
            this.btnFind_Matrix.Name = "btnFind_Matrix";
            this.btnFind_Matrix.Size = new System.Drawing.Size(23, 23);
            this.btnFind_Matrix.TabIndex = 24;
            this.btnFind_Matrix.TabStop = false;
            this.btnFind_Matrix.Click += new System.EventHandler(this.btnFind_Matrix_Click);
            // 
            // btnFind
            // 
            iconResourceHandle2.File = "16x16.16_find.gif";
            this.btnFind.Image = iconResourceHandle2;
            this.btnFind.Location = new System.Drawing.Point(289, 2);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(23, 23);
            this.btnFind.TabIndex = 23;
            this.btnFind.TabStop = false;
            this.btnFind.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.ImageAboveText;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // Basic
            // 
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnFind_Matrix);
            this.Controls.Add(this.cboFullStockCode);
            this.Size = new System.Drawing.Size(337, 27);
            this.Text = "FindProduct";
            this.ResumeLayout(false);

        }

        #endregion

        public Gizmox.WebGUI.Forms.ComboBox cboFullStockCode;
        public Gizmox.WebGUI.Forms.Button btnFind_Matrix;
        public Gizmox.WebGUI.Forms.Button btnFind;



    }
}