#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Common.Helper;

#endregion

namespace RT2020.NavPane
{
    public partial class ShopNav : UserControl
    {
        public ShopNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("shop", this.navShop.Nodes);
            navShop.DoubleClick += navShop_DoubleClick;
        }

        private void navShop_DoubleClick(object sender, EventArgs e)
        {
            LoadModule();
        }

        private void navShop_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadModule();
        }

        private void LoadModule()
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                var menuTag = (MenuHelper.MenuTag)navShop.SelectedNode.Tag;

                Panel wspPane = (Panel)controls[0];
                if (menuTag != null)
                {
                    if (!menuTag.IsPopup)
                    {
                        wspPane.Text = navShop.SelectedNode.Text;

                        wspPane.Controls.Clear();
                    }
                }

                ShowWorkspace(ref wspPane, menuTag.ResourceId);
                ShowAppToolStrip(menuTag.ResourceId);

                // 2020.08.28 paulus: RT2020 如果 wspPane 有 ActionStripBar，降低 list pane
                if (wspPane.Controls.Count > 1)
                {
                    wspPane.Controls[1].Margin = new Padding(0, 22, 0, 0);
                }
            }
        }

        private void ShowAppToolStrip(string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                //Control[] controls = this.Form.Controls.Find("atsPane", true);
                Control[] controls = this.Form.Controls.Find("wspPane", true);
                if (controls.Length > 0)
                {
                    Panel atsPane = (Panel)controls[0];

                }
            }
        }

        private void ShowWorkspace(ref Panel wspPane, string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                Control[] controls = this.Form.Controls.Find("wspPane", true);

                switch (Tag.ToLower())
                {
                    case "shop.sales":
                        RT2020.EmulatedPoS.DefaultList oSalesInputList = new RT2020.EmulatedPoS.DefaultList(controls[0], EnumHelper.TxType.CAS);
                        oSalesInputList.DockPadding.All = 6;
                        oSalesInputList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSalesInputList);
                        break;
                    case "shop.return":
                        RT2020.EmulatedPoS.DefaultList oSalesReturnList = new RT2020.EmulatedPoS.DefaultList(controls[0], EnumHelper.TxType.CRT);
                        oSalesReturnList.DockPadding.All = 6;
                        oSalesReturnList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSalesReturnList);
                        break;
                }
            }
        }
    }
}