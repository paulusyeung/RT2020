using System;
using System.Data;
using System.Configuration;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

namespace RT2020.Staff.Controls
{


    //[Serializable()]
	public class OwnerDrawnComboBoxForm : Form
    {
        private OwnerDrawnComboBox mobjParent = null;

        private int mintIndex = 1;

        private RandomData mobjRandomData = null;

        public OwnerDrawnComboBoxForm(OwnerDrawnComboBox objParent)
        {
            mobjParent = objParent;

            this.Width = mobjParent.Width;
            this.Height = 200;

            mobjRandomData = new RandomData();

            OwnerDrawnComboBoxTreeView objTreeView = new OwnerDrawnComboBoxTreeView();
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
	public class OwnerDrawnComboBox : ComboBox
    {
        private OwnerDrawnComboBoxForm mobjDropDown = null;

        public OwnerDrawnComboBox()
        {
            this.DropDownStyle = ComboBoxStyle.DropDown;
        }

        protected override Form GetCustomDropDown()
        {
            if (mobjDropDown == null)
            {
                mobjDropDown = new OwnerDrawnComboBoxForm(this);                
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
	public class OwnerDrawnComboBoxTreeView : TreeView
    {
        public OwnerDrawnComboBoxTreeView()
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
