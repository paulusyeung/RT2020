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
using RT2020.Common.Helper;

#endregion

namespace RT2020.NavPane
{
    public partial class MemberMgmtNav : UserControl
    {
        public MemberMgmtNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("membermgmt", this.navMemberMgmt.Nodes);
            navMemberMgmt.DoubleClick += navMemberMgmt_DoubleClick;
        }

        private void navMemberMgmt_DoubleClick(object sender, EventArgs e)
        {
            LoadModule();
        }

        private void navMemberMgmt_AfterSelect(object sender, TreeViewEventArgs e)
        {
            LoadModule();
        }

        private void LoadModule()
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                var menuTag = (MenuHelper.MenuTag)navMemberMgmt.SelectedNode.Tag;
                Panel wspPane = (Panel)controls[0];

                if (menuTag != null)
                {
                    if (!menuTag.IsPopup)
                    {
                        wspPane.Text = navMemberMgmt.SelectedNode.Text;

                        wspPane.Controls.Clear();
                    }
                }

                ShowAppToolStrip(menuTag.ResourceId);
                ShowWorkspace(ref wspPane, menuTag.ResourceId);

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
                    case "member.promotion":
                        var promotion = new RT2020.Settings.CampaignWizard();
                        promotion.CampaignType = EnumHelper.CampaignType.TenderType;
                        promotion.ShowDialog();
                        break;
                    case "member.batchupdatediscount":
                        var batchUpdate = new Member.MassUpdateWizard();
                        batchUpdate.ShowDialog();
                        break;
                    case "member.promotetempmembers":
                        var promoteTempMembers = new Member.PromoteMember();
                        promoteTempMembers.ShowDialog();
                        break;
                    case "member.promotewebmembers":
                        var promoteWebMembers = new Member.PromoteWebMember();
                        promoteWebMembers.ShowDialog();
                        break;
                }
            }
        }
    }
}