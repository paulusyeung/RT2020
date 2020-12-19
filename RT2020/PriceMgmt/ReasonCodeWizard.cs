#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;
using RT2020.Helper;


#endregion

namespace RT2020.PriceMgmt
{
    public partial class ReasonCodeWizard : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReasonCodeWizard"/> class.
        /// </summary>
        public ReasonCodeWizard()
        {
            InitializeComponent();

            SetToolBar();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ReasonCodeWizard"/> class.
        /// </summary>
        /// <param name="reasonId">The reason id.</param>
        public ReasonCodeWizard(Guid reasonId)
        {
            InitializeComponent();

            this.reasonId = reasonId;

            SetToolBar();

            this.LoadReason();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.ReasonId != System.Guid.Empty)
            {
                this.txtReasonCode.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
                this.txtReasonCode.ReadOnly = true;
                this.txtReasonName.Focus();
            }
            else
            {
                this.txtReasonCode.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;
                this.txtReasonCode.Focus();
            }
        }

        #region Properties

        /// <summary>
        /// reason id
        /// </summary>
        private Guid reasonId = System.Guid.Empty;

        /// <summary>
        /// Gets or sets the reason id.
        /// </summary>
        /// <value>The reason id.</value>
        public Guid ReasonId
        {
            get
            {
                return reasonId;
            }
            set
            {
                reasonId = value;
            }
        }

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
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", "Save & New");
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", "Save & Close");
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (this.ReasonId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Delete);
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
                        MessageBox.Show("Save Record And Add New?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
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

        #region Load

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void LoadReason()
        {
            var objReason = ModelEx.PriceManagementReasonEx.Get(this.ReasonId);
            if (objReason != null)
            {
                txtReasonCode.Text = objReason.ReasonCode;
                txtReasonName.Text = objReason.ReasonName;
                txtReasonName_Chs.Text = objReason.ReasonName_Chs;
                txtReasonName_Cht.Text = objReason.ReasonName_Cht;
            }
        }

        #endregion

        #region Save

        /// <summary>
        /// Verifies this instance.
        /// </summary>
        /// <returns></returns>
        private bool Verify()
        {
            bool result = true;

            if (this.txtReasonCode.Text.Trim().Length == 0)
            {
                result = result & false;
                errorProvider.SetError(this.txtReasonCode, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(this.txtReasonCode, string.Empty);
            }

            return result;
        }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        /// <returns></returns>
        private bool Save()
        {
            bool result = false;

            if (Verify())
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var objReason = ctx.PriceManagementReason.Find(this.ReasonId);
                    if (objReason == null)
                    {
                        objReason = new EF6.PriceManagementReason();
                        objReason.ReasonId = Guid.NewGuid();
                        objReason.ReasonId = System.Guid.NewGuid();
                        objReason.ReasonCode = txtReasonCode.Text;

                        ctx.PriceManagementReason.Add(objReason);
                    }
                    objReason.ReasonName = txtReasonName.Text;
                    objReason.ReasonName_Chs = txtReasonName_Chs.Text;
                    objReason.ReasonName_Cht = txtReasonName_Cht.Text;

                    ctx.SaveChanges();
                    result = true;

                    this.ReasonId = objReason.ReasonId;
                }
            }
            return result;
        }

        #endregion

        /// <summary>
        /// Saves the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultReasonList>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    ReasonCodeWizard wizard = new ReasonCodeWizard(this.ReasonId);
                    wizard.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Saves the new message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultReasonList>();
                    this.Close();
                    ReasonCodeWizard wizard = new ReasonCodeWizard();
                    wizard.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Saves the close message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultReasonList>();
                    this.Close();
                }
            }
        }

        /// <summary>
        /// Deletes the confirmation handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.PriceManagementReason.Find(this.ReasonId);
                    if (item != null)
                    {
                        ctx.PriceManagementReason.Remove(item);
                        ctx.SaveChanges();

                        MessageBox.Show("Record [" + item.ReasonCode + "] deleted!", "Delete Successful!");

                        this.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }
    }
}