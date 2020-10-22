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

namespace RT2020.Web.Shop.Common
{
    public class NavMenu
    {
        /// <summary>
        /// Fills the nav tree.
        /// </summary>
        /// <param name="filter">The filter.</param>
        /// <param name="oNav">The o nav.</param>
        public static void FillNavTree(string filter, TreeNodeCollection oNav)
        {
            XmlDocument oXmlDoc = new XmlDocument();
            string _Source = System.Web.HttpContext.Current.Server.MapPath("~/Resources/Menu/NavMenu.xml");
            try
            {
                oXmlDoc.Load(_Source);
            }
            catch (Exception e)
            {
                throw e;
            }

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
        // 2007.10.23 paulus: I use FillTree_ to skips the first node
        /// <summary>
        /// Fills the tree menu.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="parentnode">The parentnode.</param>
        private static void FillTreeMenu(XmlNode node, TreeNodeCollection parentnode)
        {
            // Add all the children of the current node to the treeview
            foreach (XmlNode tmpchildnode in node.ChildNodes)
            {
                FillTree(tmpchildnode, parentnode);
            }
        }

        /// <summary>
        /// Fills the tree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="parentnode">The parentnode.</param>
        private static void FillTree(XmlNode node, TreeNodeCollection parentnode)
        {
            TreeNodeCollection tmpNodes = AddNodeToTree(node, parentnode);

            // Add all the children of the current node to the treeview
            foreach (XmlNode tmpchildnode in node.ChildNodes)
            {
                FillTree(tmpchildnode, tmpNodes);
            }
        }

        /// <summary>
        /// Adds the node to tree.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <param name="parentnode">The parentnode.</param>
        /// <returns></returns>
        private static TreeNodeCollection AddNodeToTree(XmlNode node, TreeNodeCollection parentnode)
        {
            TreeNode newchildnode = CreateTreeNodeFromXmlNode(node);
            // if nothing to add, return the parent item
            if (newchildnode == null) return parentnode;
            // add the newly created tree node to its parent
            if (parentnode != null) parentnode.Add(newchildnode);
            return newchildnode.Nodes;
        }

        /// <summary>
        /// Creates the tree node from XML node.
        /// </summary>
        /// <param name="node">The node.</param>
        /// <returns></returns>
        private static Gizmox.WebGUI.Forms.TreeNode CreateTreeNodeFromXmlNode(XmlNode node)
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
                if (node.HasChildNodes)
                {
                    Font font = new Font("Tahoma", 11, FontStyle.Bold, GraphicsUnit.Pixel);

                    TreeNode oNode = new TreeNode();

                    oNode.Label = node.Attributes["Caption"].Value;
                    oNode.Image = new IconResourceHandle(node.Attributes["ImageUrl"].Value);
                    oNode.NodeFont      = font;
                    oNode.IsExpanded    = false;

                    tmptreenode = oNode;
                }
                else
                {
                    Font font = new Font("Tahoma", 11, FontStyle.Regular, GraphicsUnit.Pixel);

                    TreeNode oNode = new TreeNode();

                    oNode.Label     = node.Attributes["Caption"].Value;
                    oNode.Tag       = node.Attributes["Tag"].Value;
                    oNode.Image     = new IconResourceHandle(node.Attributes["ImageUrl"].Value);
                    oNode.NodeFont  = font;

                    tmptreenode = oNode;
                }
            }
            return tmptreenode;
        }
    }
}
