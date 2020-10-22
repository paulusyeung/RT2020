namespace RT2020.Controls
{
    partial class AutoCompleteBox
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
            this.cboAutoComplete = new Gizmox.WebGUI.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cboAutoComplete
            // 
            this.cboAutoComplete.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.cboAutoComplete.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Fixed3D;
            this.cboAutoComplete.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.cboAutoComplete.Location = new System.Drawing.Point(0, 0);
            this.cboAutoComplete.Name = "cboAutoComplete";
            this.cboAutoComplete.Size = new System.Drawing.Size(391, 21);
            this.cboAutoComplete.TabIndex = 0;
            this.cboAutoComplete.KeyPress += new Gizmox.WebGUI.Forms.KeyPressEventHandler(this.cboAutoComplete_KeyPress);
            this.cboAutoComplete.SelectedIndexChangedQueued += new System.EventHandler(this.cboAutoComplete_SelectedIndexChangedQueued);
            // 
            // AutoCompleteBox
            // 
            this.Controls.Add(this.cboAutoComplete);
            this.Size = new System.Drawing.Size(391, 21);
            this.Text = "AutoComplet";
            this.Load += new System.EventHandler(this.AutoComplete_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.ComboBox cboAutoComplete;


    }
}