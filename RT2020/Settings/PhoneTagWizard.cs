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

namespace RT2020.Settings
{
    public partial class PhoneTagWizard : Form
    {
        #region Properties
        private Guid _PhoneId = System.Guid.Empty;
        public Guid PhoneId
        {
            get { return _PhoneId; }
            set { _PhoneId = value; }
        }
        #endregion

        public PhoneTagWizard()
        {
            InitializeComponent();
        }

        private void PhoneTagWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetCtrlEditable();
            SetToolBar();
            BindPhoneList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("phoneTag.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colPhoneCode.Text = WestwindHelper.GetWord("phoneTag.code", "Model");
            colPhoneName.Text = WestwindHelper.GetWord("phoneTag.name", "Model");
            colPhoneNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colPhoneNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            colPriority.Text = WestwindHelper.GetWord("phoneTag.priority", "Model");

            lblPhoneCode.Text = WestwindHelper.GetWordWithColon("phoneTag.code", "Model");
            lblPhoneName.Text = WestwindHelper.GetWordWithColon("phoneTag.name", "Model");
            lblPhoneNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblPhoneNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblPriority.Text = WestwindHelper.GetWord("phoneTag.priority", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colPhoneCode.TextAlign = HorizontalAlignment.Left;
            colPhoneCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneName.TextAlign = HorizontalAlignment.Left;
            colPhoneName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneNameAlt1.TextAlign = HorizontalAlignment.Left;
            colPhoneNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPhoneNameAlt2.TextAlign = HorizontalAlignment.Left;
            colPhoneNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;
            colPriority.TextAlign = HorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblPhoneNameAlt2.Visible = txtPhoneNameAlt2.Visible = false;
                    colPhoneNameAlt2.Visible = false;
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblPhoneNameAlt1.Visible = lblPhoneNameAlt2.Visible = txtPhoneNameAlt1.Visible = txtPhoneNameAlt2.Visible = false;
                    colPhoneNameAlt1.Visible = colPhoneNameAlt2.Visible = false;
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
            ToolBarButton cmdNew = new ToolBarButton("New", "New");
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", "Refresh");
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (_PhoneId == System.Guid.Empty)
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
                            BindPhoneList();
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

        #region PhoneTag Code
        private void SetCtrlEditable()
        {
            txtPhoneCode.BackColor = (_PhoneId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtPhoneCode.ReadOnly = (_PhoneId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtPhoneCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }

        private void Clear()
        {
            txtPhoneCode.Text = txtPhoneName.Text = txtPhoneNameAlt1.Text = txtPhoneNameAlt2.Text = txtPriority.Text = string.Empty;

            _PhoneId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Binding
        private void BindPhoneList()
        {
            //this.lvPhoneList.ListViewItemSorter = new ListViewItemSorter(lvPhoneList);
            this.lvPhoneList.ListViewItemSorter = new Sorter();   // 參考：https://stackoverflow.com/a/1214333
            this.lvPhoneList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PhoneTag.OrderBy(x => x.Priority).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var objItem = this.lvPhoneList.Items.Add(item.PhoneTagId.ToString());
                    objItem.SubItems.Add(iCount.ToString());
                    objItem.SubItems.Add(item.PhoneCode);
                    objItem.SubItems.Add(item.Priority.ToString());
                    objItem.SubItems.Add(item.PhoneName);
                    objItem.SubItems.Add(item.PhoneName_Chs);
                    objItem.SubItems.Add(item.PhoneName_Cht);

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
            errorProvider.SetError(txtPhoneCode, string.Empty);
            if (txtPhoneCode.Text.Length == 0)
            {
                errorProvider.SetError(txtPhoneCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check TagCode 係咪 in use
            errorProvider.SetError(txtPhoneCode, string.Empty);
            if (_PhoneId == Guid.Empty)
            {
                if (ModelEx.PhoneTagEx.IsPhoneTagCodeInUse(txtPhoneCode.Text.Trim()))
                {
                    errorProvider.SetError(txtPhoneCode, "Tag Code in use");
                    errorProvider.SetIconAlignment(txtPhoneCode, ErrorIconAlignment.TopLeft);
                    return false;
                }
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
                    var tag = ctx.PhoneTag.Find(_PhoneId);

                    if (tag == null)
                    {
                        tag = new EF6.PhoneTag();
                        tag.PhoneTagId = Guid.NewGuid();
                        tag.PhoneCode = txtPhoneCode.Text;

                        ctx.PhoneTag.Add(tag);
                        _PhoneId = tag.PhoneTagId;
                    }
                    tag.PhoneName = txtPhoneName.Text;
                    tag.PhoneName_Chs = txtPhoneNameAlt1.Text;
                    tag.PhoneName_Cht = txtPhoneNameAlt2.Text;
                    tag.Priority = priority;

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
                    var tag = ctx.PhoneTag.Find(_PhoneId);
                    if (tag != null)
                    {
                        ctx.PhoneTag.Remove(tag);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvPhoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhoneList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvPhoneList.SelectedItem.Text, out id))
                {
                    _PhoneId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var tag = ctx.PhoneTag.Find(_PhoneId);
                        if (tag != null)
                        {
                            txtPhoneCode.Text = tag.PhoneCode;
                            txtPhoneName.Text = tag.PhoneName;
                            txtPhoneNameAlt1.Text = tag.PhoneName_Chs;
                            txtPhoneNameAlt2.Text = tag.PhoneName_Cht;
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

                BindPhoneList();
                Clear();
                SetCtrlEditable();
            }
        }

        private void lvPhoneList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // 參考：https://stackoverflow.com/a/1214333
            Sorter s = (Sorter)lvPhoneList.ListViewItemSorter;
            s.Column = e.Column;

            if (s.Order == Gizmox.WebGUI.Forms.SortOrder.Ascending)
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Descending;
            }
            else
            {
                s.Order = Gizmox.WebGUI.Forms.SortOrder.Ascending;
            }
            lvPhoneList.Sort();
        }
    }
}