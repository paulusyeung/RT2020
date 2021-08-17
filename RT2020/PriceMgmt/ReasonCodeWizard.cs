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
        #region public properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _ReasonId = Guid.Empty;
        public Guid ReasonId
        {
            get { return _ReasonId; }
            set { _ReasonId = value; }
        }
        #endregion

        public ReasonCodeWizard()
        {
            InitializeComponent();
        }

        private void ReasonCodeWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetToolBar();
            SetLayout();

            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadReason();
                    break;
            }
            txtCode.Focus();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("priceManagementReason.setup", "Model");

            lblCode.Text = WestwindHelper.GetWordWithColon("priceManagementReason.code", "Model");
            lblName.Text = WestwindHelper.GetWordWithColon("priceManagementReason.name", "Model");
            lblNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
        }

        private void SetAttributes()
        {
            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblNameAlt2.Visible = txtNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblNameAlt1.Visible = lblNameAlt2.Visible = txtNameAlt1.Visible = txtNameAlt2.Visible = false;
                    break;
            }
        }

        private void SetLayout()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    txtCode.BackColor = SystemInfoHelper.ControlBackColor.RequiredBox;
                    txtCode.Focus();
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    txtCode.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
                    txtCode.ReadOnly = true;
                    txtName.Focus();
                    break;
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
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdSaveNew = new ToolBarButton("Save & New", WestwindHelper.GetWord("edit.save.new", "General"));
            cmdSaveNew.Tag = "Save & New";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_saveOpen.gif");
            cmdSaveNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveNew);

            // cmdSaveClose
            ToolBarButton cmdSaveClose = new ToolBarButton("Save & Close", WestwindHelper.GetWord("edit.save.close", "General"));
            cmdSaveClose.Tag = "Save & Close";
            cmdSaveClose.Image = new IconResourceHandle("16x16.16_saveClose.gif");
            cmdSaveClose.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdSaveClose);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_ReasonId == System.Guid.Empty)
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

        #region Load Data

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void LoadReason()
        {
            var objReason = ModelEx.PriceManagementReasonEx.Get(_ReasonId);
            if (objReason != null)
            {
                txtCode.Text = objReason.ReasonCode;
                txtName.Text = objReason.ReasonName;
                txtNameAlt1.Text = objReason.ReasonName_Chs;
                txtNameAlt2.Text = objReason.ReasonName_Cht;
            }
        }

        #endregion

        #region Save Data

        /// <summary>
        /// Verifies this instance.
        /// </summary>
        /// <returns></returns>
        private bool Verify()
        {
            bool result = true;

            if (this.txtCode.Text.Trim().Length == 0)
            {
                result = result & false;
                errorProvider.SetError(this.txtCode, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(this.txtCode, string.Empty);
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
                    var objReason = ctx.PriceManagementReason.Find(_ReasonId);
                    if (objReason == null)
                    {
                        objReason = new EF6.PriceManagementReason();
                        objReason.ReasonId = Guid.NewGuid();
                        objReason.ReasonCode = txtCode.Text;

                        ctx.PriceManagementReason.Add(objReason);
                    }
                    objReason.ReasonName = txtName.Text;
                    objReason.ReasonName_Chs = txtNameAlt1.Text;
                    objReason.ReasonName_Cht = txtNameAlt2.Text;

                    ctx.SaveChanges();
                    result = true;

                    _ReasonId = objReason.ReasonId;
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
                    SystemInfoHelper.Settings.RefreshMainList<DiscountReasonList>();
                    MessageBox.Show("Success!", "Save Result");

                    this.Close();
                    ReasonCodeWizard wizard = new ReasonCodeWizard();
                    wizard.ReasonId = _ReasonId;
                    wizard.EditMode = EnumHelper.EditMode.Edit;
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
                    SystemInfoHelper.Settings.RefreshMainList<DiscountReasonList>();
                    this.Close();
                    ReasonCodeWizard wizard = new ReasonCodeWizard();
                    wizard.EditMode = EnumHelper.EditMode.Add;
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
                    SystemInfoHelper.Settings.RefreshMainList<DiscountReasonList>();
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
                    var item = ctx.PriceManagementReason.Find(_ReasonId);
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