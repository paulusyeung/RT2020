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

using System.Data.SqlClient;
using System.Configuration;
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Member
{
    public partial class SmartTag4Member_OptionsWizard : Form
    {
        #region public properties
        private Guid _SmartTagId = Guid.Empty;
        public Guid SmartTagId
        {
            get { return _SmartTagId; }
            set { _SmartTagId = value; }
        }

        private Guid _OptionId = Guid.Empty;
        public Guid OptionId
        {
            get { return _OptionId; }
            set { _OptionId = value; }
        }
        #endregion

        public SmartTag4Member_OptionsWizard()
        {
            InitializeComponent();
        }

        private void SmartTag4MemberWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            BindTagList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("smartTagOptions.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            //colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colOptionCode.Text = WestwindHelper.GetWord("smartTagOptions.code", "Model");

            colOptionName.Text = WestwindHelper.GetWord("smartTagOptions.name", "Model");
            colOptionNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colOptionNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblOptionCode.Text = WestwindHelper.GetWordWithColon("smartTagOptions.code", "Model");
            lblOptionName.Text = WestwindHelper.GetWordWithColon("smartTagOptions.name", "Model");
            lblOptionNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblOptionNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

        }

        private void SetAttributes()
        {
            lvTagList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colParentDept.TextAlign = HorizontalAlignment.Left;
            //colParentDept.ContentAlign = ExtendedHorizontalAlignment.Center;
            colOptionCode.TextAlign = HorizontalAlignment.Left;
            colOptionCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colOptionName.TextAlign = HorizontalAlignment.Left;
            colOptionName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colOptionNameAlt1.TextAlign = HorizontalAlignment.Left;
            colOptionNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colOptionNameAlt2.TextAlign = HorizontalAlignment.Left;
            colOptionNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblOptionNameAlt2.Visible = txtOptionNameAlt2.Visible = false;
                    colOptionNameAlt2.Visible = false;
                    // push parent dept. up
                    //lblPriority.Location = new Point(lblPriority.Location.X, lblTagNameAlt1.Location.Y);
                    //txtPriority.Location = new Point(txtPriority.Location.X, txtTagNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblOptionNameAlt1.Visible = lblOptionNameAlt2.Visible = txtOptionNameAlt2.Visible = false;
                    colOptionNameAlt1.Visible = colOptionNameAlt2.Visible = false;
                    // push parent dept up
                    //lblPriority.Location = new Point(lblPriority.Location.X, lblTagNameAlt1.Location.Y);
                    //txtPriority.Location = new Point(txtPriority.Location.X, txtTagNameAlt1.Location.Y);
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
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_OptionId == Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
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
                    case "new":
                        ClearEntries();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            ClearEntries();
                            BindTagList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        ClearEntries();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SmartTag4Member Code
        private void SetCtrlEditable()
        {
            txtOptionCode.BackColor = (_OptionId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtOptionCode.ReadOnly = (_OptionId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtOptionCode, string.Empty);
            //errorProvider.SetError(txtPriority, string.Empty);
        }

        private void ClearEntries()
        {
            txtOptionCode.Text = txtOptionName.Text = txtOptionNameAlt1.Text = txtOptionNameAlt2.Text = String.Empty;
            _OptionId = Guid.Empty;

            SetCtrlEditable();
        }
        #endregion

        #region Binding
        private void BindTagList()
        {
            this.lvTagList.ListViewItemSorter = new ListViewItemSorter(lvTagList);
            this.lvTagList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.SmartTag4Member_Options.Where(x => x.TagId == _SmartTagId).OrderBy(x => x.OptionCode).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvTagList.Items.Add(item.OptionId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.OptionCode);
                    objItem.SubItems.Add(item.OptionName);
                    objItem.SubItems.Add(item.OptionName_Alt1);
                    objItem.SubItems.Add(item.OptionName_Alt2);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Tag Code 唔可以吉
            errorProvider.SetError(txtOptionCode, string.Empty);
            if (txtOptionCode.Text.Length == 0)
            {
                errorProvider.SetError(txtOptionCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Tag Code 係咪 in use
            errorProvider.SetError(txtOptionCode, string.Empty);
            if (_OptionId == Guid.Empty && ModelEx.SmartTag4Member_OptionsEx.IsTagCodeInUse(_SmartTagId, txtOptionCode.Text.Trim()))
            {
                errorProvider.SetError(txtOptionCode, "Option Code in use");
                return false;
            }
            #endregion

            return result;
        }

        private bool Save()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SmartTag4Member_Options.Find(_OptionId);

                if (item == null)
                {
                    item = new EF6.SmartTag4Member_Options();
                    item.OptionId = Guid.NewGuid();
                    item.TagId = _SmartTagId;
                    item.OptionCode = txtOptionCode.Text;

                    ctx.SmartTag4Member_Options.Add(item);
                }
                item.OptionName = txtOptionName.Text;
                item.OptionName_Alt1 = txtOptionNameAlt1.Text;
                item.OptionName_Alt2 = txtOptionNameAlt2.Text;

                ctx.SaveChanges();

                _OptionId = item.OptionId;
                result = true;
            }

            return result;
        }
        #endregion

        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.SmartTag4Member_Options.Find(_OptionId);
                    if (item != null)
                    {
                        ctx.SmartTag4Member_Options.Remove(item);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvTagList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvTagList.SelectedItem.Text, out id))
                {
                    _OptionId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var item = ctx.SmartTag4Member_Options.Find(id);
                        if (item != null)
                        {
                            txtOptionCode.Text = item.OptionCode;
                            txtOptionName.Text = item.OptionName;
                            txtOptionNameAlt1.Text = item.OptionName_Alt1;
                            txtOptionNameAlt2.Text = item.OptionName_Alt2;

                            SetCtrlEditable();
                            SetToolBar();
                        }
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();
                BindTagList();
                ClearEntries();
                SetCtrlEditable();
            }
        }
    }
}