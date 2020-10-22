#region Using

using System;
using System.Text;
using System.Data;
using System.Drawing;
using System.ComponentModel;
using System.Collections.Generic;

using Gizmox.WebGUI;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms.Design;
using Gizmox.WebGUI.Common.Interfaces;
using Gizmox.WebGUI.Common.Extensibility;
using Gizmox.WebGUI.DevExpressControls.Web.ASPxClasses;
using System.Web.UI;

#endregion

namespace Gizmox.WebGUI.DevExpressControls.Web.ASPxPivotGridView
{
    /// <summary>
    /// Summary description for DxASPxPivotGrid
    /// </summary>
    [ToolboxItem(true)]
    [DesignTimeController("Gizmox.WebGUI.Forms.Design.PlaceHolderController, Gizmox.WebGUI.Forms.Design, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=dd2a1fd4d120c769")]
    [ClientController("Gizmox.WebGUI.Client.Controllers.PlaceHolderController, Gizmox.WebGUI.Client, Version=2.0.5701.0, Culture=neutral, PublicKeyToken=0fb8f99bd6cd7e23")]
    public partial class DxASPxPivotGrid : DxASPxDataWebControl
    {
        public DxASPxPivotGrid()
        {
            this.TagName = "Gizmox.WebGUI.DevExpressControls.Web.ASPxPivotGridView.DxASPxPivotGrid";

            InitializeComponent();
        }


        protected override void RenderAttributes(IContext context, IAttributeWriter writer)
        {
            base.RenderAttributes(context, writer);

            writer.WriteAttributeString(WGAttributes.Text, Text);
        }

        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
                if (base.Text != value)
                {
                    base.Text = value;
                    this.Update();
                }
            }
        }
    }
}