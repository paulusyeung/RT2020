#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Forms.Hosts;

#endregion

namespace RT2020.Web.Reports.Controls
{
    public partial class OlapViewer : UserControl
    {
        OlapViewerBox objOlapViewerBox = new OlapViewerBox();

        public OlapViewer()
        {
            InitializeComponent();

            objOlapViewerBox.Dock = DockStyle.Fill;
            this.Controls.Add(objOlapViewerBox);
        }

        private void OlapViewer_Load(object sender, EventArgs e)
        {
            objOlapViewerBox.Path = this.AspxPagePath;
        }

        #region Variables

        private string aspxPagePath = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the name of the aspx page.
        /// </summary>
        /// <value>The name of the aspx page.</value>
        public string AspxPagePath
        {
            get
            {
                return aspxPagePath;
            }
            set
            {
                aspxPagePath = value;
            }
        }

        #endregion
    }

    public class OlapViewerBox : AspPageBox
    {
        //protected override void FireEvent(Gizmox.WebGUI.Common.Interfaces.IEvent objEvent)
        //{
        //    base.FireEvent(objEvent);

        //    if (objEvent.Type == "MessageBox")
        //    {
        //        MessageBox.Show(objEvent["message"]);
        //    }
        //}
    }
}