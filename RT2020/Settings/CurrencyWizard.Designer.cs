namespace RT2020.Settings
{
    partial class CurrencyWizard
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
            this.lblCurrencyCode = new Gizmox.WebGUI.Forms.Label();
            this.txtCurrencyCode = new Gizmox.WebGUI.Forms.TextBox();
            this.lblCurrencyName = new Gizmox.WebGUI.Forms.Label();
            this.txtCurrencyName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtUnicodeDecimal = new Gizmox.WebGUI.Forms.TextBox();
            this.cboCountryName = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblUnicodeDecimal = new Gizmox.WebGUI.Forms.Label();
            this.tbWizardAction = new Gizmox.WebGUI.Forms.ToolBar();
            this.lblExchangeRate = new Gizmox.WebGUI.Forms.Label();
            this.txtExchangeRate = new Gizmox.WebGUI.Forms.TextBox();
            this.errorProvider = new Gizmox.WebGUI.Forms.ErrorProvider(this.components);
            this.lvCurrencyList = new Gizmox.WebGUI.Forms.ListView();
            this.colCurrencyCode = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colLN = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCurrencyId = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCountryName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCurrencyName = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colExchangeRate = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colCreatedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.colModifiedOn = ((Gizmox.WebGUI.Forms.ColumnHeader)(new Gizmox.WebGUI.Forms.ColumnHeader()));
            this.lblCountryName = new Gizmox.WebGUI.Forms.Label();
            this.lblSymbol = new Gizmox.WebGUI.Forms.Label();
            this.pnlLeftPanel = new Gizmox.WebGUI.Forms.Panel();
            this.pnlLeftPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCurrencyCode
            // 
            this.lblCurrencyCode.Location = new System.Drawing.Point(12, 48);
            this.lblCurrencyCode.Name = "lblCurrencyCode";
            this.lblCurrencyCode.Size = new System.Drawing.Size(115, 23);
            this.lblCurrencyCode.TabIndex = 0;
            this.lblCurrencyCode.Text = "Currency Code:";
            // 
            // txtCurrencyCode
            // 
            this.txtCurrencyCode.Location = new System.Drawing.Point(130, 45);
            this.txtCurrencyCode.MaxLength = 3;
            this.txtCurrencyCode.Name = "txtCurrencyCode";
            this.txtCurrencyCode.Size = new System.Drawing.Size(121, 20);
            this.txtCurrencyCode.TabIndex = 1;
            // 
            // lblCurrencyName
            // 
            this.lblCurrencyName.Location = new System.Drawing.Point(12, 94);
            this.lblCurrencyName.Name = "lblCurrencyName";
            this.lblCurrencyName.Size = new System.Drawing.Size(115, 23);
            this.lblCurrencyName.TabIndex = 2;
            this.lblCurrencyName.Text = "Currency Name:";
            // 
            // txtCurrencyName
            // 
            this.txtCurrencyName.Location = new System.Drawing.Point(130, 91);
            this.txtCurrencyName.Name = "txtCurrencyName";
            this.txtCurrencyName.Size = new System.Drawing.Size(121, 20);
            this.txtCurrencyName.TabIndex = 3;
            // 
            // txtUnicodeDecimal
            // 
            this.txtUnicodeDecimal.Location = new System.Drawing.Point(130, 114);
            this.txtUnicodeDecimal.Name = "txtUnicodeDecimal";
            this.txtUnicodeDecimal.Size = new System.Drawing.Size(121, 20);
            this.txtUnicodeDecimal.TabIndex = 4;
            this.txtUnicodeDecimal.EnterKeyDown += new Gizmox.WebGUI.Forms.KeyEventHandler(this.txtUnicodeDecimal_EnterKeyDown);
            this.txtUnicodeDecimal.Leave += new System.EventHandler(this.txtUnicodeDecimal_Leave);
            // 
            // cboCountryName
            // 
            this.cboCountryName.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboCountryName.DropDownWidth = 121;
            this.cboCountryName.Location = new System.Drawing.Point(130, 68);
            this.cboCountryName.Name = "cboCountryName";
            this.cboCountryName.Size = new System.Drawing.Size(121, 21);
            this.cboCountryName.TabIndex = 2;
            // 
            // lblUnicodeDecimal
            // 
            this.lblUnicodeDecimal.Location = new System.Drawing.Point(12, 117);
            this.lblUnicodeDecimal.Name = "lblUnicodeDecimal";
            this.lblUnicodeDecimal.Size = new System.Drawing.Size(90, 23);
            this.lblUnicodeDecimal.TabIndex = 7;
            this.lblUnicodeDecimal.Text = "Unicode Decimal:";
            // 
            // tbWizardAction
            // 
            this.tbWizardAction.ButtonSize = new System.Drawing.Size(20, 20);
            this.tbWizardAction.DragHandle = true;
            this.tbWizardAction.DropDownArrows = true;
            this.tbWizardAction.ImageSize = new System.Drawing.Size(16, 16);
            this.tbWizardAction.Location = new System.Drawing.Point(0, 0);
            this.tbWizardAction.MenuHandle = true;
            this.tbWizardAction.Name = "tbWizardAction";
            this.tbWizardAction.ShowToolTips = true;
            this.tbWizardAction.Size = new System.Drawing.Size(264, 26);
            this.tbWizardAction.TabIndex = 8;
            // 
            // lblExchangeRate
            // 
            this.lblExchangeRate.Location = new System.Drawing.Point(12, 140);
            this.lblExchangeRate.Name = "lblExchangeRate";
            this.lblExchangeRate.Size = new System.Drawing.Size(115, 23);
            this.lblExchangeRate.TabIndex = 9;
            this.lblExchangeRate.Text = "Exchange Rate:";
            // 
            // txtExchangeRate
            // 
            this.txtExchangeRate.Location = new System.Drawing.Point(130, 137);
            this.txtExchangeRate.Name = "txtExchangeRate";
            this.txtExchangeRate.Size = new System.Drawing.Size(121, 20);
            this.txtExchangeRate.TabIndex = 5;
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkRate = 3;
            // 
            // lvCurrencyList
            // 
            this.lvCurrencyList.Columns.AddRange(new Gizmox.WebGUI.Forms.ColumnHeader[] {
            this.colCurrencyCode,
            this.colLN,
            this.colCurrencyId,
            this.colCountryName,
            this.colCurrencyName,
            this.colExchangeRate,
            this.colCreatedOn,
            this.colModifiedOn});
            this.lvCurrencyList.DataMember = null;
            this.lvCurrencyList.GridLines = true;
            this.lvCurrencyList.Location = new System.Drawing.Point(60, 28);
            this.lvCurrencyList.MultiSelect = false;
            this.lvCurrencyList.Name = "lvCurrencyList";
            this.lvCurrencyList.Size = new System.Drawing.Size(339, 345);
            this.lvCurrencyList.TabIndex = 0;
            this.lvCurrencyList.UseInternalPaging = true;
            this.lvCurrencyList.SelectedIndexChanged += new System.EventHandler(this.lvCurrencyList_SelectedIndexChanged);
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Left;
            this.colCurrencyCode.Text = "Currency Code";
            this.colCurrencyCode.Width = 80;
            // 
            // colLN
            // 
            this.colLN.ContentAlign = Gizmox.WebGUI.Forms.ExtendedHorizontalAlignment.Center;
            this.colLN.Text = "LN";
            this.colLN.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            this.colLN.Width = 30;
            // 
            // colCurrencyId
            // 
            this.colCurrencyId.Text = "CurrencyId";
            this.colCurrencyId.Visible = false;
            this.colCurrencyId.Width = 150;
            // 
            // colCountryName
            // 
            this.colCountryName.Text = "Country Name";
            this.colCountryName.Width = 120;
            // 
            // colCurrencyName
            // 
            this.colCurrencyName.Text = "Currency Name";
            this.colCurrencyName.Width = 120;
            // 
            // colExchangeRate
            // 
            this.colExchangeRate.Text = "Exchange Rate";
            this.colExchangeRate.Width = 80;
            // 
            // colCreatedOn
            // 
            this.colCreatedOn.Text = "Created On";
            this.colCreatedOn.Width = 100;
            // 
            // colModifiedOn
            // 
            this.colModifiedOn.Text = "Modified On";
            this.colModifiedOn.Width = 100;
            // 
            // lblCountryName
            // 
            this.lblCountryName.Location = new System.Drawing.Point(12, 71);
            this.lblCountryName.Name = "lblCountryName";
            this.lblCountryName.Size = new System.Drawing.Size(115, 23);
            this.lblCountryName.TabIndex = 9;
            this.lblCountryName.Text = "Exchange Rate:";
            // 
            // lblSymbol
            // 
            this.lblSymbol.Location = new System.Drawing.Point(111, 117);
            this.lblSymbol.Name = "lblSymbol";
            this.lblSymbol.Size = new System.Drawing.Size(16, 23);
            this.lblSymbol.TabIndex = 7;
            this.lblSymbol.Text = "$";
            this.lblSymbol.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlLeftPanel
            // 
            this.pnlLeftPanel.Controls.Add(this.tbWizardAction);
            this.pnlLeftPanel.Controls.Add(this.lblCountryName);
            this.pnlLeftPanel.Controls.Add(this.txtCurrencyCode);
            this.pnlLeftPanel.Controls.Add(this.lblSymbol);
            this.pnlLeftPanel.Controls.Add(this.txtUnicodeDecimal);
            this.pnlLeftPanel.Controls.Add(this.lblExchangeRate);
            this.pnlLeftPanel.Controls.Add(this.cboCountryName);
            this.pnlLeftPanel.Controls.Add(this.txtCurrencyName);
            this.pnlLeftPanel.Controls.Add(this.txtExchangeRate);
            this.pnlLeftPanel.Controls.Add(this.lblUnicodeDecimal);
            this.pnlLeftPanel.Controls.Add(this.lblCurrencyCode);
            this.pnlLeftPanel.Controls.Add(this.lblCurrencyName);
            this.pnlLeftPanel.Dock = Gizmox.WebGUI.Forms.DockStyle.Right;
            this.pnlLeftPanel.Location = new System.Drawing.Point(536, 0);
            this.pnlLeftPanel.Name = "pnlLeftPanel";
            this.pnlLeftPanel.Size = new System.Drawing.Size(264, 450);
            this.pnlLeftPanel.TabIndex = 12;
            // 
            // CurrencyWizard
            // 
            this.Controls.Add(this.lvCurrencyList);
            this.Controls.Add(this.pnlLeftPanel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(800, 450);
            this.StartPosition = Gizmox.WebGUI.Forms.FormStartPosition.CenterParent;
            this.Text = "Currency Wizard";
            this.Load += new System.EventHandler(this.CurrencyWizard_Load);
            this.pnlLeftPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblCurrencyCode;
        private Gizmox.WebGUI.Forms.TextBox txtCurrencyCode;
        private Gizmox.WebGUI.Forms.Label lblCurrencyName;
        private Gizmox.WebGUI.Forms.TextBox txtCurrencyName;
        private Gizmox.WebGUI.Forms.TextBox txtUnicodeDecimal;
        private Gizmox.WebGUI.Forms.ComboBox cboCountryName;
        private Gizmox.WebGUI.Forms.Label lblUnicodeDecimal;
        private Gizmox.WebGUI.Forms.ToolBar tbWizardAction;
        private Gizmox.WebGUI.Forms.Label lblExchangeRate;
        private Gizmox.WebGUI.Forms.TextBox txtExchangeRate;
        private Gizmox.WebGUI.Forms.ErrorProvider errorProvider;
        private Gizmox.WebGUI.Forms.ListView lvCurrencyList;
        private Gizmox.WebGUI.Forms.ColumnHeader colCurrencyId;
        private Gizmox.WebGUI.Forms.ColumnHeader colLN;
        private Gizmox.WebGUI.Forms.ColumnHeader colCountryName;
        private Gizmox.WebGUI.Forms.ColumnHeader colCurrencyCode;
        private Gizmox.WebGUI.Forms.ColumnHeader colCurrencyName;
        private Gizmox.WebGUI.Forms.ColumnHeader colExchangeRate;
        private Gizmox.WebGUI.Forms.ColumnHeader colCreatedOn;
        private Gizmox.WebGUI.Forms.ColumnHeader colModifiedOn;
        private Gizmox.WebGUI.Forms.Label lblSymbol;
        private Gizmox.WebGUI.Forms.Label lblCountryName;
        private Gizmox.WebGUI.Forms.Panel pnlLeftPanel;
    }
}