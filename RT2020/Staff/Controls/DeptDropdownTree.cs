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

#endregion

namespace RT2020.Staff.Controls
{
    public partial class DeptDropdownTreeForm : Form
    {
        private DeptDropdownTree_ComboBox mobjParent = null;

        private int mintIndex = 1;

        private RandomData mobjRandomData = null;

        public DeptDropdownTreeForm(DeptDropdownTree_ComboBox objParent)
        {
            mobjParent = objParent;

            this.Width = mobjParent.Width;
            this.Height = 200;

            mobjRandomData = new RandomData();

            DeptDropdownTree_TreeView objTreeView = new DeptDropdownTree_TreeView();
            objTreeView.Dock = DockStyle.Fill;

            AddNodes(objTreeView.Nodes, 5);

            this.Controls.Add(objTreeView);

            objTreeView.AfterSelect += new TreeViewEventHandler(objTreeView_AfterSelect);
        }

        private void objTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            mobjParent.Text = e.Node.Text;
            this.Close();
        }


        private void AddNodes(TreeNodeCollection objNodes, int intCount)
        {
            for (int intIndex = 0; intIndex < intCount; intIndex++)
            {
                this.AddNode(objNodes, intCount);
            }
        }
        private void AddNode(TreeNodeCollection objNodes, int intCount)
        {
            TreeNode objTreeNode = new TreeNode();
            objTreeNode.Label = "Dept " + mintIndex.ToString();
            objTreeNode.Image = new IconResourceHandle("16x16.ico_16_4007.gif");
            objTreeNode.IsExpanded = false;
            objNodes.Add(objTreeNode);
            mintIndex++;

            if (intCount > 1)
            {
                this.AddNodes(objTreeNode.Nodes, this.mobjRandomData.GetInteger(0, intCount - 1));
            }

        }
    }

    //[Serializable()]
    public class DeptDropdownTree_ComboBox : ComboBox
    {
        private DeptDropdownTreeForm mobjDropDown = null;

        public DeptDropdownTree_ComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }

        protected override Form GetCustomDropDown()
        {
            if (mobjDropDown == null)
            {
                mobjDropDown = new DeptDropdownTreeForm(this);
            }

            return mobjDropDown;
        }

        protected override bool IsCustomDropDown
        {
            get
            {
                return true;
            }
        }
    }

    //[Serializable()]
    public class DeptDropdownTree_TreeView : TreeView
    {
        public DeptDropdownTree_TreeView()
        {

        }

        protected override bool IsDelayedDrawing
        {
            get
            {
                return false;
            }
        }
    }
}