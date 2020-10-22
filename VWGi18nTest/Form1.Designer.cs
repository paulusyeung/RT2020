namespace VWGi18nTest
{
    partial class Form1
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

        #region Visual WebGui Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.htmlBox1 = new Gizmox.WebGUI.Forms.HtmlBox();
            this.SuspendLayout();
            // 
            // htmlBox1
            // 
            this.htmlBox1.ContentType = "text/html";
            this.htmlBox1.Html = "<HTML>No content.</HTML>";
            this.htmlBox1.Location = new System.Drawing.Point(78, 137);
            this.htmlBox1.Name = "htmlBox1";
            this.htmlBox1.Size = new System.Drawing.Size(483, 200);
            this.htmlBox1.TabIndex = 0;
            // 
            // Form1
            // 
            this.Controls.Add(this.htmlBox1);
            this.Size = new System.Drawing.Size(640, 480);
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.HtmlBox htmlBox1;
    }
}