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

namespace RT2020.Supplier
{
    public partial class SmartTag4SupplierWizard : Form
    {
        #region Properties
        private Guid _TagId = System.Guid.Empty;
        public Guid TagId
        {
            get { return _TagId; }
            set { _TagId = value; }
        }
        #endregion

        public SmartTag4SupplierWizard()
        {
            InitializeComponent();
        }

        private void SmartTag4SupplierWizard_Load(object sender, EventArgs e)
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
            this.Text = WestwindHelper.GetWord("smartTag4Supplier.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            //colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colTagCode.Text = WestwindHelper.GetWord("smartTag4Supplier.code", "Model");
            colPriority.Text = WestwindHelper.GetWord("smartTag4Supplier.priority", "Model");
            colTagName.Text = WestwindHelper.GetWord("smartTag4Supplier.name", "Model");
            colTagNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colTagNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblTagCode.Text = WestwindHelper.GetWordWithColon("smartTag4Supplier.code", "Model");
            lblTagName.Text = WestwindHelper.GetWordWithColon("smartTag4Supplier.name", "Model");
            lblTagNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblTagNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblPriority.Text = WestwindHelper.GetWordWithColon("smartTag4Supplier.priority", "Model");

            lnkOptions.Text = WestwindHelper.GetWord("smartTagOptions", "Model");
        }

        private void SetAttributes()
        {
            lvTagList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colParentDept.TextAlign = HorizontalAlignment.Left;
            //colParentDept.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTagCode.TextAlign = HorizontalAlignment.Left;
            colTagCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPriority.TextAlign = HorizontalAlignment.Center;
            colPriority.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTagName.TextAlign = HorizontalAlignment.Left;
            colTagName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTagNameAlt1.TextAlign = HorizontalAlignment.Left;
            colTagNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTagNameAlt2.TextAlign = HorizontalAlignment.Left;
            colTagNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblTagNameAlt2.Visible = txtTagNameAlt2.Visible = false;
                    colTagNameAlt2.Visible = false;
                    // push parent dept. up
                    lblPriority.Location = new Point(lblPriority.Location.X, lblTagNameAlt1.Location.Y);
                    txtPriority.Location = new Point(txtPriority.Location.X, txtTagNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblTagNameAlt1.Visible = lblTagNameAlt2.Visible = txtTagNameAlt2.Visible = false;
                    colTagNameAlt1.Visible = colTagNameAlt2.Visible = false;
                    // push parent dept up
                    lblPriority.Location = new Point(lblPriority.Location.X, lblTagNameAlt1.Location.Y);
                    txtPriority.Location = new Point(txtPriority.Location.X, txtTagNameAlt1.Location.Y);
                    break;
            }

            lnkOptions.Visible = _TagId != Guid.Empty;
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

            if (_TagId == System.Guid.Empty)
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
                        Clear();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindTagList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        Clear();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SmartTag4Supplier Code
        private void SetCtrlEditable()
        {
            txtTagCode.BackColor = (_TagId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtTagCode.ReadOnly = (_TagId != Guid.Empty);

            ClearError();

            lnkOptions.Visible = _TagId != Guid.Empty;
        }

        private void ClearError()
        {
            errorProvider.SetError(txtTagCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }

        private void Clear()
        {
            txtTagCode.Text = txtTagName.Text = txtTagNameAlt1.Text = txtTagNameAlt2.Text = txtPriority.Text = string.Empty;

            _TagId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Binding
        private void BindTagList()
        {
            this.lvTagList.ListViewItemSorter = new Sorter();
            this.lvTagList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.SmartTag4Supplier.OrderBy(x => x.Priority).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    ListViewItem objItem = this.lvTagList.Items.Add(item.TagId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.TagCode);
                    objItem.SubItems.Add(item.Priority.ToString());
                    objItem.SubItems.Add(item.TagName);
                    objItem.SubItems.Add(item.TagName_Chs);
                    objItem.SubItems.Add(item.TagName_Cht);

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
            errorProvider.SetError(txtTagCode, string.Empty);
            if (txtTagCode.Text.Length == 0)
            {
                errorProvider.SetError(txtTagCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Tag Code 係咪 in use
            errorProvider.SetError(txtTagCode, string.Empty);
            if (_TagId == Guid.Empty && ModelEx.SmartTag4WorkplaceEx.IsTagCodeInUse(txtTagCode.Text.Trim()))
            {
                errorProvider.SetError(txtTagCode, "Tag Code in use");
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
                int priority = 0;
                if (int.TryParse(txtPriority.Text, out priority))
                {
                    var item = ctx.SmartTag4Supplier.Find(_TagId);

                    if (item == null)
                    {
                        item = new EF6.SmartTag4Supplier();
                        item.TagId = Guid.NewGuid();
                        item.TagCode = txtTagCode.Text;

                        ctx.SmartTag4Supplier.Add(item);
                        _TagId = item.TagId;
                    }
                    item.TagName = txtTagName.Text;
                    item.TagName_Chs = txtTagNameAlt1.Text;
                    item.TagName_Cht = txtTagNameAlt2.Text;
                    item.Priority = priority;

                    ctx.SaveChanges();
                    result = true;
                }
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
                    var item = ctx.SmartTag4Supplier.Find(_TagId);
                    if (item != null)
                    {
                        ctx.SmartTag4Supplier.Remove(item);
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
                    _TagId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var oTag = ctx.SmartTag4Supplier.Find(id);
                        if (oTag != null)
                        {
                            txtTagCode.Text = oTag.TagCode;
                            txtTagName.Text = oTag.TagName;
                            txtTagNameAlt1.Text = oTag.TagName_Chs;
                            txtTagNameAlt2.Text = oTag.TagName_Cht;
                            txtPriority.Text = oTag.Priority.ToString();

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
                Clear();
            }
        }

        private void lvTagList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 參考：https://stackoverflow.com/a/1214333
            Sorter s = (Sorter)lvTagList.ListViewItemSorter;
            s.Column = e.Column;

            if (s.Order == Gizmox.WebGUI.Forms.SortOrder.Ascending)
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Descending;
            }
            else
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Ascending;
            }
            lvTagList.Sort();
        }

        private void lnkOptions_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var options = new SmartTag4Supplier_OptionsWizard();
            options.SmartTagId = _TagId;
            options.ShowDialog();
        }
    }
}