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

namespace RT2020.Staff
{
    public partial class StaffDeptWizard : Form
    {
        #region Properties
        private Guid _DeptId = System.Guid.Empty;
        public Guid StaffDeptId
        {
            get { return _DeptId; }
            set { _DeptId = value; }
        }
        #endregion

        public StaffDeptWizard()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();
            SetToolBar();
            FillParentDeptList();
            BindStaffDeptList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("department.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colParentDept.Text = WestwindHelper.GetWord("department.parent", "Model");
            colStaffDeptCode.Text = WestwindHelper.GetWord("department.code", "Model");
            colStaffDeptName.Text = WestwindHelper.GetWord("department.name", "Model");
            colStaffDeptNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colStaffDeptNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblStaffDeptCode.Text = WestwindHelper.GetWordWithColon("department.code", "Model");
            lblStaffDeptName.Text = WestwindHelper.GetWordWithColon("department.name", "Model");
            lblStaffDeptNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblStaffDeptNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentDept.Text = WestwindHelper.GetWordWithColon("department.parent", "Model");
        }

        private void SetAttributes()
        {
            colLN.TextAlign = HorizontalAlignment.Center;
            colParentDept.TextAlign = HorizontalAlignment.Left;
            colParentDept.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffDeptCode.TextAlign = HorizontalAlignment.Left;
            colStaffDeptCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffDeptName.TextAlign = HorizontalAlignment.Left;
            colStaffDeptName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffDeptNameAlt1.TextAlign = HorizontalAlignment.Left;
            colStaffDeptNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStaffDeptNameAlt2.TextAlign = HorizontalAlignment.Left;
            colStaffDeptNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblStaffDeptNameAlt2.Visible = txtStaffDeptNameAlt2.Visible = false;
                    colStaffDeptNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentDept.Location = new Point(lblParentDept.Location.X, lblStaffDeptNameAlt2.Location.Y);
                    cboParentDept.Location = new Point(cboParentDept.Location.X, txtStaffDeptNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblStaffDeptNameAlt1.Visible = lblStaffDeptNameAlt2.Visible = txtStaffDeptNameAlt2.Visible = false;
                    colStaffDeptNameAlt1.Visible = colStaffDeptNameAlt2.Visible = false;
                    // push parent dept up
                    lblParentDept.Location = new Point(lblParentDept.Location.X, lblStaffDeptNameAlt1.Location.Y);
                    cboParentDept.Location = new Point(cboParentDept.Location.X, txtStaffDeptNameAlt1.Location.Y);
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

            if (_DeptId == System.Guid.Empty)
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
                            BindStaffDeptList();
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

        #region StaffDept Code
        private void SetCtrlEditable()
        {
            txtStaffDeptCode.BackColor = (_DeptId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtStaffDeptCode.ReadOnly = (_DeptId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtStaffDeptCode, string.Empty);
        }

        private void Clear()
        {
            txtStaffDeptCode.Text = txtStaffDeptName.Text = txtStaffDeptNameAlt1.Text = txtStaffDeptNameAlt2.Text = string.Empty;
            cboParentDept.SelectedIndex = 0;

            _DeptId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentDeptList()
        {
            ModelEx.StaffDeptEx.LoadCombo(ref cboParentDept, "DeptName", true, true, string.Empty, "");
        }
        #endregion

        #region Binding
        private void BindStaffDeptList()
        {
            this.lvStaffDeptList.ListViewItemSorter = new ListViewItemSorter(lvStaffDeptList);
            this.lvStaffDeptList.Items.Clear();

            int iCount = 1;
            using (var ctx = new EF6.RT2020Entities())
            {
                //ctx.Configuration.LazyLoadingEnabled = false;
                var list = ctx.StaffDept.OrderBy(x => x.DeptCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var parent = ctx.StaffDept.Where(x => x.DeptId == item.ParentDept).FirstOrDefault();

                    ListViewItem objItem = this.lvStaffDeptList.Items.Add(item.DeptId.ToString());
                    objItem.SubItems.Add(iCount.ToString());
                    objItem.SubItems.Add(parent == null ? "" : parent.DeptCode);
                    objItem.SubItems.Add(item.DeptCode);
                    objItem.SubItems.Add(item.DeptName);
                    objItem.SubItems.Add(item.DeptName_Chs);
                    objItem.SubItems.Add(item.DeptName_Cht);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region DeptCode 唔可以吉
            errorProvider.SetError(txtStaffDeptCode, string.Empty);
            if (txtStaffDeptCode.Text.Length == 0)
            {
                errorProvider.SetError(txtStaffDeptCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CityCode 係咪 in use
            errorProvider.SetError(txtStaffDeptCode, string.Empty);
            if (ModelEx.StaffDeptEx.IsDeptCodeInUse(txtStaffDeptCode.Text.Trim()))
            {
                errorProvider.SetError(txtStaffDeptCode, "Dept Code in use");
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
                var dept = ctx.StaffDept.Find(_DeptId);

                if (dept == null)
                {
                    dept = new EF6.StaffDept();
                    dept.DeptId = new Guid();

                    ctx.StaffDept.Add(dept);
                    dept.DeptCode = txtStaffDeptCode.Text;
                }
                dept.DeptName = txtStaffDeptName.Text;
                dept.DeptName_Chs = txtStaffDeptNameAlt1.Text;
                dept.DeptName_Cht = txtStaffDeptNameAlt2.Text;
                dept.ParentDept = new Guid(cboParentDept.SelectedValue.ToString());

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
                    var dept = ctx.StaffDept.Find(_DeptId);
                    if (dept != null)
                    {
                        ctx.StaffDept.Remove(dept);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvStaffDeptList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvStaffDeptList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvStaffDeptList.SelectedItem.Text, out id))
                {
                    _DeptId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var dept = ctx.StaffDept.Find(_DeptId);
                        if (dept != null)
                        {
                            txtStaffDeptCode.Text = dept.DeptCode;
                            txtStaffDeptName.Text = dept.DeptName;
                            txtStaffDeptNameAlt1.Text = dept.DeptName_Chs;
                            txtStaffDeptNameAlt2.Text = dept.DeptName_Cht;
                            cboParentDept.SelectedValue = dept.ParentDept.HasValue ? dept.ParentDept.Value : Guid.Empty ;

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

                BindStaffDeptList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}