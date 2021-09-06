using Gizmox.WebGUI.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RT2020.Helper
{
    class TreeViewHelper
    {
        /// <summary>
        /// if name = string.Empty, return all checked nodes
        /// if name != string.Empty, return all nodes with checked && Name == name
        /// </summary>
        /// <param name="target"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static List<TreeNode> GetAllCheckedNodes(TreeNodeCollection target, string name = "")
        {
            List<TreeNode> result = new List<TreeNode>();

            foreach (TreeNode node in target)
            {
                GetCheckedNodes(node, name, ref result);
            }

            return result;
        }

        private static void GetCheckedNodes(TreeNode nodes, string name, ref List<TreeNode> list)
        {
            if (nodes.Checked)
            {
                if (name == string.Empty)
                {
                    list.Add(nodes);
                }
                else
                {
                    if (nodes.Name == name)
                    {
                        list.Add(nodes);
                    }
                }
            }
            if (nodes.Nodes.Count > 0)
            {
                foreach (TreeNode node in nodes.Nodes)
                {
                    GetCheckedNodes(node, name, ref list);
                }
            }
        }
    }
}
