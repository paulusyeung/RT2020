namespace RT2020.Inventory.StockTake.Import
{
    partial class ImportFromPoS_SelectionWizard
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
            this.lblTitle = new Gizmox.WebGUI.Forms.Label();
            this.lvSelection = new Gizmox.WebGUI.Forms.ListView();
            this.colPOSFile = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.btnMarkAll = new Gizmox.WebGUI.Forms.Button();
            this.btnOK = new Gizmox.WebGUI.Forms.Button();
            this.btnCancel = new Gizmox.WebGUI.Forms.Button();
            this.openFileDialog = new Gizmox.WebGUI.Forms.OpenFileDialog();
            this.colFullPath = new Gizmox.WebGUI.Forms.ColumnHeader();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(13, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 27);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "There are more than one files can be import to stock take. Please select one of t" +
                "hem:";
            // 
            // lvSelection
            // 
            this.lvSelection.CheckBoxes = true;
            this.lvSelection.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colPOSFile,
            this.colFullPath});
            this.lvSelection.DataMember = null;
            this.lvSelection.ItemsPerPage = 20;
            this.lvSelection.Location = new System.Drawing.Point(16, 46);
            this.lvSelection.Name = "lvSelection";
            this.lvSelection.Size = new System.Drawing.Size(310, 195);
            this.lvSelection.TabIndex = 1;
            // 
            // colPOSFile
            // 
            this.colPOSFile.Image = null;
            this.colPOSFile.Text = "POS File";
            this.colPOSFile.Width = 150;
            // 
            // btnMarkAll
            // 
            this.btnMarkAll.Location = new System.Drawing.Point(16, 251);
            this.btnMarkAll.Name = "btnMarkAll";
            this.btnMarkAll.Size = new System.Drawing.Size(75, 23);
            this.btnMarkAll.TabIndex = 2;
            this.btnMarkAll.Text = "Mark All";
            this.btnMarkAll.Click += new System.EventHandler(this.btnMarkAll_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(176, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(251, 251);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "DBF file|*.dbf|*.DBF";
            this.openFileDialog.Title = "Select POS Data file to import";
            this.openFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog_FileOk);
            // 
            // colFullPath
            // 
            this.colFullPath.Image = null;
            this.colFullPath.Text = global::RT2020.Admin.Localization.App_LocalResource.default_aspx.ErrorMessage;
            this.colFullPath.Visible = false;
            this.colFullPath.Width = 150;
            // 
            // ImportFromPoS_SelectionWizard
            // 
            this.CancelButton = this.btnCancel;
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnMarkAll);
            this.Controls.Add(this.lvSelection);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(338, 300);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Import files";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblTitle;
        private Gizmox.WebGUI.Forms.ListView lvSelection;
        private Gizmox.WebGUI.Forms.ColumnHeader colPOSFile;
        private Gizmox.WebGUI.Forms.Button btnMarkAll;
        private Gizmox.WebGUI.Forms.Button btnOK;
        private Gizmox.WebGUI.Forms.Button btnCancel;
        private Gizmox.WebGUI.Forms.OpenFileDialog openFileDialog;
        private Gizmox.WebGUI.Forms.ColumnHeader colFullPath;


    }
}