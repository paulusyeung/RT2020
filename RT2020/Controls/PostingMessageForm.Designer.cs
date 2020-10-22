namespace RT2020.Controls
{
    partial class PostingMessageForm
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
            this.lblHeaderId = new Gizmox.WebGUI.Forms.Label();
            this.txtMessage = new Gizmox.WebGUI.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblHeaderId
            // 
            this.lblHeaderId.Location = new System.Drawing.Point(12, 9);
            this.lblHeaderId.Name = "lblHeaderId";
            this.lblHeaderId.Size = new System.Drawing.Size(100, 23);
            this.lblHeaderId.TabIndex = 0;
            this.lblHeaderId.Text = "HeaderID";
            this.lblHeaderId.Visible = false;
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(12, 12);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.ScrollBars = Gizmox.WebGUI.Forms.ScrollBars.Vertical;
            this.txtMessage.Size = new System.Drawing.Size(395, 272);
            this.txtMessage.TabIndex = 4;
            // 
            // PostingMessageForm
            // 
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.lblHeaderId);
            this.FormBorderStyle = Gizmox.WebGUI.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Size = new System.Drawing.Size(419, 296);
            this.Text = "Posting Message Form";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Label lblHeaderId;
        private Gizmox.WebGUI.Forms.TextBox txtMessage;


    }
}