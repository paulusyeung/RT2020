#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Helper;

#endregion

namespace RT2020.Help
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void About_Load(object sender, EventArgs e)
        {            
            System.Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;

            this.mobjLabelVersion.Text = String.Format(this.mobjLabelVersion.Text, version.ToString(), Gizmox.WebGUI.WGConst.Version.ToString());

            SetCredits();
        }

        private void SetCredits()
        {
            this.Text = WestwindHelper.GetWord("help.about", "Menu");

            picLogo.Image = new ImageResourceHandle("RT2020.Logo.jpg");

            textBox2.Text += Environment.NewLine + Environment.NewLine +
                "Credits:" + Environment.NewLine +
                "Arron Tam, Brabara Cheung, David Chen, Ken Fong, Paulus Yeung";
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}