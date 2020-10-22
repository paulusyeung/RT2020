#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using i18n;
using System.Threading;
using System.Globalization;
using System.Web;
using System.Linq;
using i18n.Domain.Abstract;
using System.Configuration;
using i18n.Domain.Concrete;
using Westwind.Globalization;

#endregion

namespace VWGi18nTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            htmlBox1.Dock = DockStyle.Fill;
            htmlBox1.Url = @"/LocalizationAdmin/index.html";
        }
    }
}