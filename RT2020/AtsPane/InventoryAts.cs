#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using RT2020.Product;
using RT2020.Inventory;

#endregion

namespace RT2020.AtsPane
{
    public partial class InventoryAts : UserControl
    {
        public InventoryAts()
        {
            InitializeComponent();

            InvtToolbar tb = new InvtToolbar(null, ref atsInvt, InvtToolbar.FormType.All);

            //SetAtsInvt();
        }

        //private void SetAtsInvt()
        //{
        //    this.atsInvt.MenuHandle = false;
        //    this.atsInvt.DragHandle = false;
        //    this.atsInvt.TextAlign = ToolBarTextAlign.Right;

        //    this.atsInvt.Buttons.Add(new ToolBarButton("StockStatus", "Stock Status"));
        //    this.atsInvt.Buttons[this.atsInvt.Buttons.Count - 1].Image = new IconResourceHandle("16x16.16_find.gif");
        //    this.atsInvt.ButtonClick += new ToolBarButtonClickEventHandler(atsInvt_ButtonClick);           
           
        //}

        //private void atsInvt_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        //{
        //    Control[] controls = this.Form.Controls.Find("wspPane", true);
        //    if (controls.Length > 0)
        //    {
        //        Panel wspPane = (Panel)controls[0];
        //        wspPane.Text = (string)e.Button.Text;
        //    }
        //}
    }
}