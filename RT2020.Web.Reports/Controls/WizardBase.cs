#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Configuration;

#endregion

namespace RT2020.Web.Reports.Controls
{
    public partial class WizardBase : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WizardBase"/> class.
        /// </summary>
        public WizardBase()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            if (!this.DesignMode)
            {
                base.OnLoad(e);

                int width = 0, height = 0;

                if (PrevForm != null)
                {
                    Control container = PrevForm;
                    width = container.Size.Width;
                    height = container.Size.Height;
                }
                else
                {
                    string[] size = new string[] { "1024", "768" };
                    string viewerSize = ConfigurationManager.AppSettings["ReportViewerSize"];

                    if (viewerSize.IndexOf(',') > 0)
                    {
                        size = viewerSize.Split(new char[] { ',' }, StringSplitOptions.None);
                    }

                    int.TryParse(size[0].Trim(), out width);
                    int.TryParse(size[1].Trim(), out height);

                    width = (width == 0) ? 1024 : width;
                    height = (height == 0) ? 768 : height;
                }

                this.Size = new Size(width, height);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private Form prevForm = null;

        /// <summary>
        /// Gets or sets the previous form.
        /// </summary>
        /// <value>The previous form.</value>
        public Form PrevForm
        {
            get
            {
                return prevForm;
            }
            set
            {
                prevForm = value;
            }
        }
    }
}