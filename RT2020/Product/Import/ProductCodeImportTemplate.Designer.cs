namespace RT2020.Product.Import
{
    partial class ProductCodeImportTemplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCodeImportTemplate));
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lnkTemplateFor03 = new Gizmox.WebGUI.Forms.LinkLabel();
            this.lnkTemplateFor07 = new Gizmox.WebGUI.Forms.LinkLabel();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.lblExcelTemplates = new Gizmox.WebGUI.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 279);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // lnkTemplateFor03
            // 
            this.lnkTemplateFor03.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lnkTemplateFor03.Location = new System.Drawing.Point(22, 317);
            this.lnkTemplateFor03.Name = "lnkTemplateFor03";
            this.lnkTemplateFor03.Size = new System.Drawing.Size(65, 19);
            this.lnkTemplateFor03.TabIndex = 1;
            this.lnkTemplateFor03.Text = "Excel 2003";
            this.lnkTemplateFor03.Url = "Resources/Templates/Stock Code Import Template (03).xls";
            // 
            // lnkTemplateFor07
            // 
            this.lnkTemplateFor07.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lnkTemplateFor07.Location = new System.Drawing.Point(112, 317);
            this.lnkTemplateFor07.Name = "lnkTemplateFor07";
            this.lnkTemplateFor07.Size = new System.Drawing.Size(71, 19);
            this.lnkTemplateFor07.TabIndex = 2;
            this.lnkTemplateFor07.Text = "Excel 2007";
            this.lnkTemplateFor07.Url = "Resources/Templates/Stock Code Import Template (07).xlsx";
            // 
            // btnOK
            // 
            this.btnOK.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.btnOK.Location = new System.Drawing.Point(186, 341);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.TextImageRelation = Gizmox.WebGUI.Forms.TextImageRelation.Overlay;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lblExcelTemplates
            // 
            this.lblExcelTemplates.DragTargets = new Gizmox.WebGUI.Forms.Component[0];
            this.lblExcelTemplates.Location = new System.Drawing.Point(12, 294);
            this.lblExcelTemplates.Name = "lblExcelTemplates";
            this.lblExcelTemplates.Size = new System.Drawing.Size(100, 20);
            this.lblExcelTemplates.TabIndex = 4;
            this.lblExcelTemplates.Text = "Templates:";
            // 
            // ProductCodeImportTemplate
            // 
            this.Controls.Add(this.lblExcelTemplates);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lnkTemplateFor07);
            this.Controls.Add(this.lnkTemplateFor03);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(273, 385);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Template for Importing Stock Code";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.LinkLabel lnkTemplateFor03;
        private Gizmox.WebGUI.Forms.LinkLabel lnkTemplateFor07;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Label lblExcelTemplates;


    }
}