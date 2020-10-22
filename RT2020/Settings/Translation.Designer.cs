using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;

namespace RT2020.Settings
{
    partial class Translation
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
            this.boxTranslate = new Gizmox.WebGUI.Forms.HtmlBox();
            this.SuspendLayout();
            // 
            // boxTranslate
            // 
            this.boxTranslate.ContentType = "text/html";
            this.boxTranslate.Html = "<HTML>No content.</HTML>";
            this.boxTranslate.Location = new System.Drawing.Point(52, 71);
            this.boxTranslate.Name = "boxTranslate";
            this.boxTranslate.Size = new System.Drawing.Size(277, 133);
            this.boxTranslate.TabIndex = 0;
            // 
            // Translation
            // 
            this.Controls.Add(this.boxTranslate);
            this.Size = new System.Drawing.Size(391, 306);
            this.Text = "Translation";
            this.Load += new System.EventHandler(this.Translation_Load);
            this.ResumeLayout(false);

        }


        #endregion

        private HtmlBox boxTranslate;
    }
}