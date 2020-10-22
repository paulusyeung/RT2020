namespace RT2020.Web.Reports.Forms
{
    partial class OlapMonthlySalesTransaction
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
            this.olapViewer = new RT2020.Web.Reports.Controls.OlapViewer();
            this.SuspendLayout();
            // 
            // olapViewer
            // 
            this.olapViewer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.olapViewer.AspxPagePath = "Olap\\OlapMonthlySalesTransactionPage.aspx";
            this.olapViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.olapViewer.Location = new System.Drawing.Point(0, 0);
            this.olapViewer.Name = "olapViewer";
            this.olapViewer.Size = new System.Drawing.Size(736, 605);
            this.olapViewer.TabIndex = 0;
            this.olapViewer.Text = "OlapViewer";
            // 
            // OlapMonthlySalesTransaction
            // 
            this.Controls.Add(this.olapViewer);
            this.Size = new System.Drawing.Size(736, 605);
            this.Text = "Monthly Sales Transaction [OLAP]";
            this.ResumeLayout(false);

        }

        #endregion

        private RT2020.Web.Reports.Controls.OlapViewer olapViewer;


    }
}