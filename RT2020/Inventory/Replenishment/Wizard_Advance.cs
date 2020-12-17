#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using Gizmox.WebGUI.Common.Resources;

#endregion

namespace RT2020.Inventory.Replenishment
{
    public partial class Wizard_Advance : Form
    {
        public Wizard_Advance()
        {
            InitializeComponent();

            SetToolBar();
            txtTxNumber.Text = "Auto-Generated";
        }

        #region Properties
        private Guid rplId = System.Guid.Empty;
        public Guid RplId
        {
            get
            {
                return rplId;
            }
            set
            {
                rplId = value;
            }
        }

        private Guid rplDetailId = System.Guid.Empty;
        public Guid RplDetailId
        {
            get
            {
                return rplDetailId;
            }
            set
            {
                rplDetailId = value;
            }
        }

        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }

        //private int SelectedIndex = 0;
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (RplId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Delete);
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                        break;
                    case "save & new":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                        break;
                    case "save & close":
                        MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Save
        private void Save()
        {
        }
        #endregion

        #region Delete
        private void Delete()
        {
            ModelEx.InvtBatchTXF_HeaderEx.DeleteChildToo(this.RplId);
        }

        private void DeleteDetails(string sql)
        {
            InvtBatchTXF_DetailsCollection oDetailList = InvtBatchTXF_Details.LoadCollection(sql);
            foreach (InvtBatchTXF_Details oDetail in oDetailList)
            {
                oDetail.Delete();
            }
        }
        #endregion

        #region Message Handler
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Replenishment.Wizard wizard = new RT2020.Inventory.Replenishment.Wizard(this.RplId);
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                    this.Close();
                    RT2020.Inventory.Replenishment.Wizard wizard = new RT2020.Inventory.Replenishment.Wizard();
                    wizard.ShowDialog();
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                    this.Close();
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                this.Close();
            }
        }

        private void TabChangedMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Save();

                if (this.RplId != System.Guid.Empty)
                {
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    RT2020.Inventory.Replenishment.Wizard wizard = new RT2020.Inventory.Replenishment.Wizard(this.RplId);
                    wizard.ShowDialog();
                }
            }
            else
            {
                tabGoodsRpl.SelectedIndex = 0;
            }
        }
        #endregion
    }
}