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

namespace RT2020.Member
{
    public partial class MemberClassWizard : Form
    {
        #region Properties
        private Guid _ClassId = System.Guid.Empty;
        public Guid MemberClassId
        {
            get { return _ClassId; }
            set { _ClassId = value; }
        }
        #endregion

        public MemberClassWizard()
        {
            InitializeComponent();
        }

        private void MemberClassWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentClassList();
            BindMemberClassList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("memberClass.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colParentClass.Text = WestwindHelper.GetWord("memberClass.parent", "Model");
            colClassCode.Text = WestwindHelper.GetWord("memberClass.code", "Model");
            //colPriority.Text = WestwindHelper.GetWord("smartTag4Member.priority", "Model");
            colClassName.Text = WestwindHelper.GetWord("memberClass.name", "Model");
            colClassNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colClassNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblClassCode.Text = WestwindHelper.GetWordWithColon("memberClass.code", "Model");
            lblClassName.Text = WestwindHelper.GetWordWithColon("memberClass.name", "Model");
            lblClassNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblClassNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentClass.Text = WestwindHelper.GetWordWithColon("memberClass.parent", "Model");
        }

        private void SetAttributes()
        {
            lvClassList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            colParentClass.TextAlign = HorizontalAlignment.Left;
            colParentClass.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassCode.TextAlign = HorizontalAlignment.Left;
            colClassCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassName.TextAlign = HorizontalAlignment.Left;
            colClassName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassNameAlt1.TextAlign = HorizontalAlignment.Left;
            colClassNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colClassNameAlt2.TextAlign = HorizontalAlignment.Left;
            colClassNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblClassNameAlt2.Visible = txtClassNameAlt2.Visible = false;
                    colClassNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentClass.Location = new Point(lblParentClass.Location.X, lblClassNameAlt1.Location.Y);
                    cboParentClass.Location = new Point(cboParentClass.Location.X, txtClassNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblClassNameAlt1.Visible = lblClassNameAlt2.Visible = txtClassNameAlt2.Visible = false;
                    colClassNameAlt1.Visible = colClassNameAlt2.Visible = false;
                    // push parent dept up
                    cboParentClass.Location = new Point(lblParentClass.Location.X, lblClassNameAlt1.Location.Y);
                    cboParentClass.Location = new Point(cboParentClass.Location.X, txtClassNameAlt1.Location.Y);
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
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

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

            if (_ClassId == Guid.Empty)
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
                    case "new":
                        Clear();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            Clear();
                            BindMemberClassList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        Clear();
                        BindMemberClassList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Clear/ set
        private void SetCtrlEditable()
        {
            txtClassCode.BackColor = (_ClassId == Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtClassCode.ReadOnly = (_ClassId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtClassCode, string.Empty);
        }

        private void Clear()
        {
            txtClassCode.Text = txtClassName.Text = txtClassNameAlt1.Text = txtClassNameAlt2.Text = String.Empty;
            cboParentClass.SelectedIndex = 0;

            _ClassId = Guid.Empty;

            SetCtrlEditable();
            FillParentClassList();
        }
        #endregion

        #region Fill Combo List
        private void FillParentClassList()
        {
            string sql = "ClassId NOT IN ('" + _ClassId.ToString() + "')";
            string[] orderBy = new string[] { "ClassCode" };

            MemberClassEx.LoadCombo(ref cboParentClass, "ClassName", true, true, "", sql, orderBy);
        }
        #endregion

        #region Binding
        private void BindMemberClassList()
        {
            this.lvClassList.ListViewItemSorter = new ListViewItemSorter(lvClassList);
            this.lvClassList.Items.Clear();

            int iCount = 1;
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.MemberClass.OrderBy(x => x.ClassCode).AsNoTracking().ToList();
                foreach (var item in list)
                {
                    var parent = MemberClassEx.GetParentName(item);

                    ListViewItem objItem = this.lvClassList.Items.Add(item.ClassId.ToString());
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(item.ClassCode);
                    objItem.SubItems.Add(item.ClassName);
                    objItem.SubItems.Add(item.ClassName_Chs);
                    objItem.SubItems.Add(item.ClassName_Cht);
                    objItem.SubItems.Add(parent);

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Class Code 唔可以吉
            errorProvider.SetError(txtClassCode, string.Empty);
            if (txtClassCode.Text.Length == 0)
            {
                errorProvider.SetError(txtClassCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Class Code 係咪 in use
            errorProvider.SetError(txtClassCode, string.Empty);
            if (_ClassId == Guid.Empty && MemberGroupEx.IsGroupCodeInUse(txtClassCode.Text.Trim()))
            {
                errorProvider.SetError(txtClassCode, "Class Code in use");
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
                var item = ctx.MemberClass.Find(_ClassId);

                if (item == null)
                {
                    item = new EF6.MemberClass();
                    item.ClassId = new Guid();
                    item.ClassCode = txtClassCode.Text;

                    ctx.MemberClass.Add(item);
                }
                item.ClassName = txtClassName.Text;
                item.ClassName_Chs = txtClassNameAlt1.Text;
                item.ClassName_Cht = txtClassNameAlt2.Text;
                item.ParentClass = (cboParentClass.SelectedValue == null) ? Guid.Empty : new Guid(cboParentClass.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oMemberClass = ctx.MemberClass.Find(_ClassId);
                if (oMemberClass != null)
                {
                    try
                    {
                        ctx.MemberClass.Remove(oMemberClass);
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                    }
                }
            }
        }
        #endregion

        private void lvMemberClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvClassList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvClassList.SelectedItem.Text, out id))
                {
                    var oMemberClass = MemberClassEx.Get(id);
                    if (oMemberClass != null)
                    {
                        _ClassId = oMemberClass.ClassId;

                        FillParentClassList();

                        txtClassCode.Text = oMemberClass.ClassCode;
                        txtClassName.Text = oMemberClass.ClassName;
                        txtClassNameAlt1.Text = oMemberClass.ClassName_Chs;
                        txtClassNameAlt2.Text = oMemberClass.ClassName_Cht;
                        cboParentClass.SelectedValue = oMemberClass.ParentClass.HasValue ? oMemberClass.ParentClass.Value : Guid.Empty;

                        SetCtrlEditable();
                        SetToolBar();
                    }
                }
            }
        }

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();

                BindMemberClassList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}