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

namespace RT2020.Staff
{
    public partial class StaffGroupWizard : Form
    {
        #region Properties
        private Guid _GroupId = Guid.Empty;
        public Guid StaffGroupId
        {
            get { return _GroupId; }
            set { _GroupId = value; }
        }
        #endregion

        public StaffGroupWizard()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentGradeList();
            BindStaffGroupList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("staffGroup.setup", "Model");

            lblStaffGroupCode.Text = WestwindHelper.GetWordWithColon("staffGroup.code", "Model");
            lblStaffGroupName.Text = WestwindHelper.GetWordWithColon("staffGroup.name", "Model");
            lblStaffGroupNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblStaffGroupNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentGrade.Text = WestwindHelper.GetWordWithColon("staffGroup.parent", "Model");

            chkCanRead.Text = WestwindHelper.GetWord("security.read", "General");
            chkCanWrite.Text = WestwindHelper.GetWord("security.write", "General");
            chkCanDelete.Text = WestwindHelper.GetWord("security.delete", "General");
            chkCanPost.Text = WestwindHelper.GetWord("security.post", "General");

            //colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colStaffGroupCode.Text = WestwindHelper.GetWord("staffGroup.code", "Model");
            colStaffGroupName.Text = WestwindHelper.GetWord("staffGroup.name", "Model");
            colStaffGroupNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colStaffGroupNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
        }

        private void SetAttributes()
        {
            lvStaffGroupList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colParentDept.TextAlign = HorizontalAlignment.Left;
            //colParentDept.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffGroupCode.TextAlign = HorizontalAlignment.Left;
            colStaffGroupCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffGroupName.TextAlign = HorizontalAlignment.Left;
            colStaffGroupName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffGroupNameAlt1.TextAlign = HorizontalAlignment.Left;
            colStaffGroupNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffGroupNameAlt2.TextAlign = HorizontalAlignment.Left;
            colStaffGroupNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblStaffGroupNameAlt2.Visible = txtStaffGroupNameAlt2.Visible = false;
                    colStaffGroupNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentGrade.Location = new Point(lblParentGrade.Location.X, lblStaffGroupNameAlt1.Location.Y);
                    cboParentGrade.Location = new Point(cboParentGrade.Location.X, txtStaffGroupNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblStaffGroupNameAlt1.Visible = lblStaffGroupNameAlt2.Visible = txtStaffGroupNameAlt2.Visible = false;
                    colStaffGroupNameAlt1.Visible = colStaffGroupNameAlt2.Visible = false;
                    // push parent dept up
                    lblParentGrade.Location = new Point(lblParentGrade.Location.X, lblStaffGroupNameAlt1.Location.Y);
                    cboParentGrade.Location = new Point(cboParentGrade.Location.X, txtStaffGroupNameAlt1.Location.Y);
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

            if (StaffGroupId == System.Guid.Empty)
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
                            BindStaffGroupList();
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

        #region StaffGroup Code
        private void SetCtrlEditable()
        {
            txtStaffGroupCode.BackColor = (this.StaffGroupId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtStaffGroupCode.ReadOnly = (this.StaffGroupId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtStaffGroupCode, string.Empty);
        }

        private void Clear()
        {
            txtStaffGroupCode.Text = txtStaffGroupName.Text = txtStaffGroupNameAlt1.Text = txtStaffGroupNameAlt2.Text = string.Empty;
            chkCanRead.Checked = chkCanWrite.Checked = chkCanDelete.Checked = chkCanPost.Checked = false;
            cboParentGrade.SelectedIndex = 0;

            _GroupId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentGradeList()
        {
            var textFields = new string[] { "GradeCode", "GradeName" };
            var pattern = "{0} - {1}";
            var sql = "GroupId NOT IN ('" + this.StaffGroupId.ToString() + "')";
            var orderBy = new string[] { "GradeCode" };

            StaffGroupEx.LoadCombo(ref cboParentGrade, textFields, pattern, true, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindStaffGroupList()
        {
            this.lvStaffGroupList.ListViewItemSorter = new ListViewItemSorter(lvStaffGroupList);
            this.lvStaffGroupList.Items.Clear();

            int iCount = 1;

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.StaffGroup.OrderBy(x => x.GradeCode).AsNoTracking().ToList();

                foreach (var item in list)
                {
                    var oItem = this.lvStaffGroupList.Items.Add(item.GroupId.ToString());
                    oItem.SubItems.Add(iCount.ToString());
                    oItem.SubItems.Add(item.GradeCode);
                    oItem.SubItems.Add(item.GradeName);
                    oItem.SubItems.Add(item.GradeName_Chs);
                    oItem.SubItems.Add(item.GradeName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtStaffGroupCode, string.Empty);

            #region DeptCode 唔可以吉
            if (txtStaffGroupCode.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtStaffGroupCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CityCode 係咪 in use
            if (_GroupId == Guid.Empty)
            {
                if (StaffGroupEx.IsGradeCodeInUse(txtStaffGroupCode.Text.Trim()))
                {
                    errorProvider.SetError(txtStaffGroupCode, "Grade Code in use");
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
                var sg = ctx.StaffGroup.Find(this.StaffGroupId);

                if (sg == null)
                {
                    sg = new EF6.StaffGroup();
                    sg.GroupId = new Guid();
                    sg.GradeCode = txtStaffGroupCode.Text;

                    ctx.StaffGroup.Add(sg);
                }
                sg.GradeName = txtStaffGroupName.Text;
                sg.GradeName_Chs = txtStaffGroupNameAlt1.Text;
                sg.GradeName_Cht = txtStaffGroupNameAlt2.Text;
                if ((Guid)cboParentGrade.SelectedValue != Guid.Empty) sg.ParentGrade = (Guid)cboParentGrade.SelectedValue;

                sg.CanRead = chkCanRead.Checked;
                sg.CanWrite = chkCanWrite.Checked;
                sg.CanDelete = chkCanDelete.Checked;
                sg.CanPost = chkCanPost.Checked;

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        private void Delete()
        {
            if (!StaffGroupEx.Delete(this.StaffGroupId))
            {
                MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
            }
        }

        private void lvStaffGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffGroupList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvStaffGroupList.SelectedItem.Text, out id))
                {
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var sg = ctx.StaffGroup.Where(x => x.GroupId == id).AsNoTracking().FirstOrDefault();
                        if (sg != null)
                        {
                            this.StaffGroupId = sg.GroupId;

                            FillParentGradeList();

                            txtStaffGroupCode.Text = sg.GradeCode;
                            txtStaffGroupName.Text = sg.GradeName;
                            txtStaffGroupNameAlt1.Text = sg.GradeName_Chs;
                            txtStaffGroupNameAlt2.Text = sg.GradeName_Cht;
                            cboParentGrade.SelectedValue = sg.ParentGrade.HasValue ? sg.ParentGrade.Value : Guid.Empty;

                            chkCanRead.Checked = sg.CanRead.Value;
                            chkCanWrite.Checked = sg.CanWrite.Value;
                            chkCanDelete.Checked = sg.CanDelete.Value;
                            chkCanPost.Checked = sg.CanPost.Value;

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

                BindStaffGroupList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}