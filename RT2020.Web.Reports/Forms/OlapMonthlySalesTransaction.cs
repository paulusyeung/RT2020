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

namespace RT2020.Web.Reports.Forms
{
    public partial class OlapMonthlySalesTransaction : Controls.WizardBase
    {
        public OlapMonthlySalesTransaction()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            olapViewer.DockPadding.All = 6;
            olapViewer.Dock = DockStyle.Fill;
            olapViewer.AutoSize = true;
            olapViewer.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            olapViewer.AspxPagePath = @"Olap\OlapMonthlySalesTransactionPage.aspx";
        }
    }
}