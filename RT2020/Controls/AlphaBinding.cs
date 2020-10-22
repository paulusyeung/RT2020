#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Controls
{
    public partial class AlphaBinding : UserControl
    {
        public event EventHandler ButtonClick;

        public AlphaBinding()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.AddAlphaControls();
        }

        private void AddAlphaControls()
        {
            // # control
            for (int i = 0; i < 10; i++)
            {
                Button btnNumCtrl = new Button();
                btnNumCtrl.Name = "btn" + i.ToString().PadLeft(2, '0');
                btnNumCtrl.Text = i.ToString();
                btnNumCtrl.Tag = i.ToString();
                btnNumCtrl.Size = new Size(20, 20);
                btnNumCtrl.Click += new EventHandler(btnCtrl_Click);

                flowLayoutPanel.Controls.Add(btnNumCtrl);
            }

            // Letter controls
            for (int i = 65; i < 91; i++)
            {
                Button btnLetterCtrl = new Button();
                btnLetterCtrl.Name = "btn" + ((char)i).ToString();
                btnLetterCtrl.Text = ((char)i).ToString();
                btnLetterCtrl.Tag = ((char)i).ToString();
                btnLetterCtrl.Size = new Size(20, 20);
                btnLetterCtrl.Click += new EventHandler(btnCtrl_Click);

                flowLayoutPanel.Controls.Add(btnLetterCtrl);
            }

            // All Control
            Button btnAllCtrl = new Button();
            btnAllCtrl.Name = "btnAll";
            btnAllCtrl.Text = "All";
            btnAllCtrl.Tag = "All";
            btnAllCtrl.Size = new Size(24, 20);
            btnAllCtrl.Click += new EventHandler(btnCtrl_Click);

            flowLayoutPanel.Controls.Add(btnAllCtrl);
        }

        void btnCtrl_Click(object sender, EventArgs e)
        {
            this.ButtonClick(sender, e);
        }
    }
}