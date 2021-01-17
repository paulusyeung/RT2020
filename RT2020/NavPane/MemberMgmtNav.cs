#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Xml;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.NavPane
{
    public partial class MemberMgmtNav : UserControl
    {
        public MemberMgmtNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("membermgmt", this.navMemberMgmt.Nodes);
        }

        private void navMemberMgmt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                Panel wspPane = (Panel)controls[0];
                wspPane.Text = navMemberMgmt.SelectedNode.Text;

                wspPane.Controls.Clear();

                ShowAppToolStrip((string)navMemberMgmt.SelectedNode.Tag);
                ShowWorkspace(ref wspPane, (string)navMemberMgmt.SelectedNode.Tag);

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
                Control[] controls = this.Form.Controls.Find("wspPane", true);
                if (controls.Length > 0)
                {
                    Panel wspPane = (Panel)controls[0];

                    switch (Tag.ToLower())
                    {
                        case "member":
                        case "member.phonebook":
                            RT2020.AtsPane.MemberMgmtAts oAtsMemberMgmt = new RT2020.AtsPane.MemberMgmtAts();
                            oAtsMemberMgmt.Dock = DockStyle.Top;
                            wspPane.Controls.Add(oAtsMemberMgmt);
                            break;
                        case "pur_olapordersummary":
                            //RT2020.Inventory.GoodsReceive.DefaultAts oRecv = new RT2020.Inventory.GoodsReceive.DefaultAts();
                            //oRecv.Dock = DockStyle.Fill;
                            //atsPane.Controls.Clear();
                            //atsPane.Controls.Add(oRecv);
                            break;
                    }
                }
            }
        }

        private void ShowWorkspace(ref Panel wspPane, string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                switch (Tag.ToLower())
                {
                    case "member":
                        RT2020.Member.MemberList oMemberList = new RT2020.Member.MemberList();
                        oMemberList.DockPadding.All = 6;
                        oMemberList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oMemberList);
                        break;
                    case "member.phonebook":
                        RT2020.Member.PhoneBookList oPhoneBookList = new RT2020.Member.PhoneBookList();
                        oPhoneBookList.DockPadding.All = 6;
                        oPhoneBookList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oPhoneBookList);
                        break;
                }
            }
        }
    }
}