using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.Security;
using System.Xml;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using System.IO;
using System.Collections.Generic;
using RT2020.Common.Helper;

namespace RT2020.NavPane
{
    public class NavMenu
    {
        private static String _MenuGroup = "";
        private static XmlDocument NavDocument
        {
            get
            {
                XmlDocument oXmlDoc = new XmlDocument();

                string xmlFile = string.Format("~/Resources/Menu/NavMenu_{0}.xml", RT2020.Controls.UserUtility.PermissionLevel());

                string _Source = System.Web.HttpContext.Current.Server.MapPath(xmlFile);
                if (File.Exists(_Source))
                {
                    oXmlDoc.Load(_Source);

                    return oXmlDoc;
                }

                return null;
            }
        }

        public static void FillNavPane(ref NavigationTabs navTabs)
        {
            XmlDocument oXmlDoc = NavDocument;

            if (oXmlDoc != null)
            {
                navTabs.TabPages.Clear();

                XmlNodeList oNodeList = oXmlDoc.DocumentElement.ChildNodes;
                foreach (XmlNode oNode in oNodeList)
                {
                    XmlNode oCurNode = oNode;

                    if (oCurNode.HasChildNodes)
                    {
                        var tabPage = new NavigationTab();
                        var caption = oCurNode.Attributes["Caption"].Value;

                        tabPage.Image = new IconResourceHandle(oCurNode.Attributes["ImageUrl"].Value);
                        tabPage.Location = new System.Drawing.Point(4, 22);
                        tabPage.Name = "tab" + oCurNode.Attributes["Caption"].Value;
                        tabPage.Size = new System.Drawing.Size(142, 316);
                        tabPage.TabIndex = 0;
                        tabPage.Text = WestwindHelper.GetWord(caption.ToLower(), "Menu");
                        tabPage.Tag = oCurNode.Attributes["Caption"].Value;

                        navTabs.Controls.Add(tabPage);

                        switch (oCurNode.Name.ToLower())
                        {
                            case "inventory":
                                RT2020.NavPane.InventoryNav navInvt = new RT2020.NavPane.InventoryNav();
                                navInvt.Dock = DockStyle.Fill;
                                tabPage.Controls.Add(navInvt);
                                break;
                            case "purchasing":
                                RT2020.NavPane.PurchasingNav navPurchasing = new RT2020.NavPane.PurchasingNav();
                                navPurchasing.Dock = DockStyle.Fill;
                                tabPage.Controls.Add(navPurchasing);
                                break;
                            case "shop":
                                RT2020.NavPane.ShopNav navShop = new RT2020.NavPane.ShopNav();
                                navShop.Dock = DockStyle.Fill;
                                tabPage.Controls.Add(navShop);
                                break;
                            case "membermgmt":
                                RT2020.NavPane.MemberMgmtNav navMemberMgmt = new RT2020.NavPane.MemberMgmtNav();
                                navMemberMgmt.Dock = DockStyle.Fill;
                                tabPage.Controls.Add(navMemberMgmt);
                                break;
                            case "settings":
                                RT2020.NavPane.SettingsNav navSettings = new RT2020.NavPane.SettingsNav();
                                navSettings.Dock = DockStyle.Fill;
                                tabPage.Controls.Add(navSettings);
                                break;
                            case "product":
                                RT2020.NavPane.ProductNav navProduct = new RT2020.NavPane.ProductNav();
                                navProduct.Dock = DockStyle.Fill;
                                tabPage.Controls.Add(navProduct);
                                break;
                        }
                    }
                }
            }
        }

        public static void FillNavTree(string filter, TreeNodeCollection oNav)
        {
            _MenuGroup = filter;

            XmlDocument oXmlDoc = NavDocument;

            if (oXmlDoc != null)
            {
                XmlNodeList oNodeList = oXmlDoc.DocumentElement.ChildNodes;
                foreach (XmlNode oNode in oNodeList)
                {
                    XmlNode oCurNode = oNode;

                    if (oCurNode.HasChildNodes && oCurNode.Name.ToLower() == filter)
                    {
                        FillTreeMenu(oNode, oNav);
                    }
                }
            }
        }

        // 2007.10.23 paulus: I use FillTree_ to skips the first node
        private static void FillTreeMenu(XmlNode node, TreeNodeCollection parentnode)
        {
            // Add all the children of the current node to the treeview
            foreach (XmlNode tmpchildnode in node.ChildNodes)
            {
                FillTree(tmpchildnode, parentnode);
            }
        }

        private static void FillTree(XmlNode node, TreeNodeCollection parentnode)
        {
            TreeNodeCollection tmpNodes = AddNodeToTree(node, parentnode);

            // Add all the children of the current node to the treeview
            foreach (XmlNode tmpchildnode in node.ChildNodes)
            {
                FillTree(tmpchildnode, tmpNodes);
            }
        }

        private static TreeNodeCollection AddNodeToTree(XmlNode node, TreeNodeCollection parentnode)
        {
            TreeNode newchildnode = CreateTreeNodeFromXmlNode(node);
            // if nothing to add, return the parent item
            if (newchildnode == null) return parentnode;
            // add the newly created tree node to its parent
            if (parentnode != null) parentnode.Add(newchildnode);
            return newchildnode.Nodes;
        }

        private static TreeNode CreateTreeNodeFromXmlNode(XmlNode node)
        {
            TreeNode tmptreenode = new TreeNode();
            if ((node.HasChildNodes) && (node.FirstChild.Value != null))
            {
                tmptreenode = new TreeNode(node.Name);
                TreeNode tmptreenode2 = new TreeNode(node.FirstChild.Value);
                tmptreenode.Nodes.Add(tmptreenode2);
            }
            else if (node.NodeType != XmlNodeType.CDATA)
            {
                String label = string.Empty, tag = "";
                bool popup = false;

                var caption = node.Attributes["Caption"].Value;
                tag = node.Attributes["Tag"] == null ? "" : node.Attributes["Tag"].Value;
                popup = node.Attributes["Popup"] == null ? false : bool.TryParse(node.Attributes["Popup"].Value, out popup);

                var menuTag = new MenuHelper.MenuTag(tag, popup);

                switch (_MenuGroup)
                {
                    case "shop":
                    case "product":
                    case "membermgmt":
                    case "settings":
                        label = HttpUtility.UrlDecode(WestwindHelper.GetWord(tag, "Menu"));
                        break;
                    default:
                        label = HttpUtility.UrlDecode(RT2020.Controls.Utility.Dictionary.GetWord(caption));
                        break;
                }

                if (node.HasChildNodes)
                {
                    #region parent: collapsed, bold, 冇 icon
                    Font font = new Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel);

                    TreeNode oNode = new TreeNode()
                    {
                        IsExpanded = false,
                        Label = label,
                        NodeFont = font
                    };
                    tmptreenode = oNode;
                    #endregion
                }
                else
                {
                    #region child: expanded, regular, 帶 icon
                    Font font = new Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel);

                    TreeNode oNode = new TreeNode()
                    {
                        Image = new IconResourceHandle(node.Attributes["ImageUrl"].Value),
                        Label = label,
                        NodeFont = font,
                        Tag = menuTag   //node.Attributes["Tag"].Value
                    };
                    tmptreenode = oNode;
                    #endregion
                }
            }
            return tmptreenode;
        }
    }
}
