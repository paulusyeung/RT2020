using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using Gizmox.WebGUI.Forms;

namespace RT2020.Controls.Reporting
{
	/// <summary>
    /// Provides a Visual WebGui callable wrapper for Microsoft.Reporting.WebForms.ReportViewer.
    /// </summary>
    [System.ComponentModel.ToolboxItem(true)]
	public partial class ReportViewer : Gizmox.WebGUI.Forms.Hosts.AspControlBoxBase
	{
		public ReportViewer()
		{
			InitializeComponent();
		}		
		
	
	}
}
