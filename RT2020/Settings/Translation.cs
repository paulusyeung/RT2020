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

namespace RT2020.Settings
{
    public partial class Translation : UserControl
    {
        public Translation()
        {
            InitializeComponent();
        }

        private void Translation_Load(object sender, EventArgs e)
        {
            boxTranslate.Dock = DockStyle.Fill;
            boxTranslate.Url = "/LocalizationAdmin/index.html";
        }
    }
}