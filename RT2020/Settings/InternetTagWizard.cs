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
using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Settings
{
    public partial class InternetTagWizard : Form
    {
        #region Properties
        private Guid _TagId = System.Guid.Empty;
        public Guid TagId
        {
            get { return _TagId; }
            set { _TagId = value; }
        }
        #endregion

        public InternetTagWizard()
        {
            InitializeComponent();
        }

        private void InternetTagWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            BindInternetTagList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("internetTag.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colInternetTagCode.Text = WestwindHelper.GetWord("internetTag.code", "Model");
            colPriority.Text = WestwindHelper.GetWord("internetTag.priority", "Model");
            colInternetTagName.Text = WestwindHelper.GetWord("internetTag.name", "Model");
            colInternetTagNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colInternetTagNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblInternetTagCode.Text = WestwindHelper.GetWordWithColon("internetTag.code", "Model");
            lblInternetTagName.Text = WestwindHelper.GetWordWithColon("internetTag.name", "Model");
            lblInternetTagNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblInternetTagNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblPriority.Text = WestwindHelper.GetWord("internetTag.priority", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colInternetTagCode.TextAlign = HorizontalAlignment.Left;
            colInternetTagCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPriority.TextAlign = HorizontalAlignment.Center;
            colPriority.ContentAlign = ExtendedHorizontalAlignment.Center;
            colInternetTagName.TextAlign = HorizontalAlignment.Left;
            colInternetTagName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colInternetTagNameAlt1.TextAlign = HorizontalAlignment.Left;
            colInternetTagNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colInternetTagNameAlt2.TextAlign = HorizontalAlignment.Left;
            colInternetTagNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblInternetTagNameAlt2.Visible = txtInternetTagNameAlt2.Visible = false;
                    colInternetTagNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblInternetTagNameAlt1.Visible = lblInternetTagNameAlt2.Visible = txtInternetTagNameAlt1.Visible = txtInternetTagNameAlt2.Visible = false;
                    colInternetTagNameAlt1.Visible = colInternetTagNameAlt2.Visible = false;
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

            if (_TagId == Guid.Empty)
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
                            BindInternetTagList();
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

        #region InternetTag Code
        private void SetCtrlEditable()
        {
            txtInternetTagCode.BackColor = (_TagId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtInternetTagCode.ReadOnly = (_TagId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtInternetTagCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }

        private void Clear()
        {
            txtInternetTagCode.Text = txtInternetTagName.Text = txtInternetTagNameAlt1.Text = txtInternetTagNameAlt2.Text = txtPriority.Text = string.Empty;

            _TagId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Binding
        private void BindInternetTagList()
        {
            this.lvInternetTagList.ListViewItemSorter = new Sorter();   // 參考：https://stackoverflow.com/a/1214333
            this.lvInternetTagList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.InternetTag.OrderBy(x => x.TagCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var objItem = this.lvInternetTagList.Items.Add(item.TagId.ToString());
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

            #region CountryCode 唔可以吉
            errorProvider.SetError(txtInternetTagCode, string.Empty);
            if (txtInternetTagCode.Text.Length == 0)
            {
                errorProvider.SetError(txtInternetTagCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check TagCode 係咪 in use
            errorProvider.SetError(txtInternetTagCode, string.Empty);
            if (_TagId == Guid.Empty && InternetTagEx.IsInternetTagCodeInUse(txtInternetTagCode.Text.Trim()))
            {
                errorProvider.SetError(txtInternetTagCode, "Tag Code in use");
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
                var tag = ctx.InternetTag.Find(_TagId);

                if (tag == null)
                {
                    tag = new EF6.InternetTag();
                    tag.TagId = new Guid();

                    ctx.InternetTag.Add(tag);
                    tag.TagCode = txtInternetTagCode.Text;
                }
                tag.TagName = txtInternetTagName.Text;
                tag.TagName_Chs = txtInternetTagNameAlt1.Text;
                tag.TagName_Cht = txtInternetTagNameAlt2.Text;
                tag.Priority = Convert.ToInt32(txtPriority.Text);

                ctx.SaveChanges();
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
                    var tag = ctx.InternetTag.Find(_TagId);
                    if (tag != null)
                    {
                        ctx.InternetTag.Remove(tag);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvInternetTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInternetTagList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvInternetTagList.SelectedItem.Text, out id))
                {
                    _TagId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var tag = ctx.InternetTag.Find(_TagId);
                        if (tag != null)
                        {
                            txtInternetTagCode.Text = tag.TagCode;
                            txtInternetTagName.Text = tag.TagName;
                            txtInternetTagNameAlt1.Text = tag.TagName_Chs;
                            txtInternetTagNameAlt2.Text = tag.TagName_Cht;
                            txtPriority.Text = tag.Priority.ToString();

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

                BindInternetTagList();
                Clear();
                SetCtrlEditable();
            }
        }

        private void lvInternetTagList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 參考：https://stackoverflow.com/a/1214333
            Sorter s = (Sorter)lvInternetTagList.ListViewItemSorter;
            s.Column = e.Column;

            if (s.Order == Gizmox.WebGUI.Forms.SortOrder.Ascending)
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Descending;
            }
            else
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Ascending;
            }
            lvInternetTagList.Sort();
        }
    }
}