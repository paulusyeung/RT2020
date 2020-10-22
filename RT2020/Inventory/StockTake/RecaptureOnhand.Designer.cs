namespace RT2020.Inventory.StockTake
{
    partial class RecaptureOnhand
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
            this.groupBox1 = new Gizmox.WebGUI.Forms.GroupBox();
            this.lblStockTakeNumber = new Gizmox.WebGUI.Forms.Label();
            this.groupBox2 = new Gizmox.WebGUI.Forms.GroupBox();
            this.progressBar1 = new Gizmox.WebGUI.Forms.ProgressBar();
            this.btnRecapture = new Gizmox.WebGUI.Forms.Button();
            this.btnExit = new Gizmox.WebGUI.Forms.Button();
            this.lbStockTakeList = new Gizmox.WebGUI.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbStockTakeList);
            this.groupBox1.Controls.Add(this.lblStockTakeNumber);
            this.groupBox1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox1.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(395, 306);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.Text = "Stock Take";
            // 
            // lblStockTakeNumber
            // 
            this.lblStockTakeNumber.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblStockTakeNumber.Location = new System.Drawing.Point(6, 26);
            this.lblStockTakeNumber.Name = "lblStockTakeNumber";
            this.lblStockTakeNumber.Size = new System.Drawing.Size(76, 23);
            this.lblStockTakeNumber.TabIndex = 0;
            this.lblStockTakeNumber.Text = "Stock Take#";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.groupBox2.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.groupBox2.Location = new System.Drawing.Point(12, 324);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(395, 74);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.Text = "Progress";
            // 
            // progressBar1
            // 
            this.progressBar1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.progressBar1.Location = new System.Drawing.Point(9, 30);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(380, 23);
            this.progressBar1.TabIndex = 0;
            this.progressBar1.Visible = false;
            // 
            // btnRecapture
            // 
            this.btnRecapture.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnRecapture.Location = new System.Drawing.Point(251, 421);
            this.btnRecapture.Name = "btnRecapture";
            this.btnRecapture.Size = new System.Drawing.Size(75, 23);
            this.btnRecapture.TabIndex = 2;
            this.btnRecapture.Text = "Re-capture";
            this.btnRecapture.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnRecapture.Click += new System.EventHandler(this.btnRecapture_Click);
            // 
            // btnExit
            // 
            this.btnExit.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnExit.Location = new System.Drawing.Point(332, 421);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "Exit";
            this.btnExit.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lbStockTakeList
            // 
            this.lbStockTakeList.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.lbStockTakeList.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lbStockTakeList.Location = new System.Drawing.Point(88, 17);
            this.lbStockTakeList.Name = "lbStockTakeList";
            this.lbStockTakeList.SelectionMode = Gizmox.WebGUI.Forms.SelectionMode.One;
            this.lbStockTakeList.Size = new System.Drawing.Size(301, 277);
            this.lbStockTakeList.TabIndex = 1;
            // 
            // RecaptureOnhand
            // 
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRecapture);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 466);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Stock Take > Re-capture On-hand Quantity (Current)";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.GroupBox groupBox1;
        private Gizmox.WebGUI.Forms.Label lblStockTakeNumber;
        private Gizmox.WebGUI.Forms.GroupBox groupBox2;
        private Gizmox.WebGUI.Forms.ProgressBar progressBar1;
        private Gizmox.WebGUI.Forms.Button btnRecapture;
        private Gizmox.WebGUI.Forms.Button btnExit;
        private Gizmox.WebGUI.Forms.CheckedListBox lbStockTakeList;


    }
}