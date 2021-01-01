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

#endregion

namespace RT2020.Member
{
    public partial class MemberGroupWizard : Form
    {
        #region Properties
        private Guid _GroupId = System.Guid.Empty;
        public Guid MemberGroupId
        {
            get { return _GroupId; }
            set { _GroupId = value; }
        }
        #endregion

        public MemberGroupWizard()
        {
            InitializeComponent();
        }

        private void MemberGroupWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SetToolBar();
            FillParentGroupList();
            BindMemberGroupList();
            SetCtrlEditable();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("memberGroup.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");

            colGroupCode.Text = WestwindHelper.GetWord("memberGroup.code", "Model");
            colGroupName.Text = WestwindHelper.GetWord("memberGroup.name", "Model");
            colGroupNameAlt1.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            colGroupNameAlt2.Text = WestwindHelper.GetWord(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblGroupCode.Text = WestwindHelper.GetWordWithColon("memberGroup.code", "Model");
            lblGroupName.Text = WestwindHelper.GetWordWithColon("memberGroup.name", "Model");
            lblGroupNameAlt1.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblGroupNameAlt2.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");

            lblParentGroup.Text = WestwindHelper.GetWordWithColon("memberGroup.parent", "Model");
        }

        private void SetAttributes()
        {
            lvMemberGroupList.Dock = DockStyle.Fill;

            colLN.TextAlign = HorizontalAlignment.Center;
            //colParentClass.TextAlign = HorizontalAlignment.Left;
            //colParentClass.ContentAlign = ExtendedHorizontalAlignment.Center;
            colGroupCode.TextAlign = HorizontalAlignment.Left;
            colGroupCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colGroupName.TextAlign = HorizontalAlignment.Left;
            colGroupName.ContentAlign = ExtendedHorizontalAlignment.Center;
            colGroupNameAlt1.TextAlign = HorizontalAlignment.Left;
            colGroupNameAlt1.ContentAlign = ExtendedHorizontalAlignment.Center;
            colGroupNameAlt2.TextAlign = HorizontalAlignment.Left;
            colGroupNameAlt2.ContentAlign = ExtendedHorizontalAlignment.Center;

            switch (LanguageHelper.AlternateLanguagesUsed)
            {
                case 1:
                    // hide alt2
                    lblGroupNameAlt2.Visible = txtGroupNameAlt2.Visible = false;
                    colGroupNameAlt2.Visible = false;
                    // push parent dept. up
                    lblParentGroup.Location = new Point(lblParentGroup.Location.X, lblGroupNameAlt1.Location.Y);
                    cboParentGroup.Location = new Point(cboParentGroup.Location.X, txtGroupNameAlt2.Location.Y);
                    break;
                case 2:
                    // do nothing
                    break;
                case 0:
                default:
                    // hide alt1 & alt2
                    lblGroupNameAlt1.Visible = lblGroupNameAlt2.Visible = txtGroupNameAlt2.Visible = false;
                    colGroupNameAlt1.Visible = colGroupNameAlt2.Visible = false;
                    // push parent dept up
                    cboParentGroup.Location = new Point(lblParentGroup.Location.X, lblGroupNameAlt1.Location.Y);
                    cboParentGroup.Location = new Point(cboParentGroup.Location.X, txtGroupNameAlt1.Location.Y);
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

            if (_GroupId == System.Guid.Empty)
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
                            BindMemberGroupList();
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

        #region MemberGroup Code
        private void SetCtrlEditable()
        {
            txtGroupCode.BackColor = (_GroupId == Guid.Empty) ? SystemInfo.ControlBackColor.RequiredBox : SystemInfo.ControlBackColor.DisabledBox;
            txtGroupCode.ReadOnly = (_GroupId != Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtGroupCode, string.Empty);
        }

        private void Clear()
        {
            txtGroupCode.Text = txtGroupName.Text = txtGroupNameAlt1.Text = txtGroupNameAlt2.Text = string.Empty;
            cboParentGroup.SelectedIndex = 0;

            _GroupId = Guid.Empty;
            SetCtrlEditable();
        }
        #endregion

        #region Fill Combo List
        private void FillParentGroupList()
        {
            //cboParentGroup.DataSource = null;
            //cboParentGroup.Items.Clear();

            string sql = "GroupId NOT IN ('" + _GroupId.ToString() + "')";
            string[] orderBy = new string[] { "GroupCode" };

            ModelEx.MemberGroupEx.LoadCombo(ref cboParentGroup, "GroupCode", true, true, "", sql, orderBy);
            /**
            MemberGroupCollection oMemberGroupList = MemberGroup.LoadCollection(sql, orderBy, true);
            oMemberGroupList.Add(new MemberGroup(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            cboParentGroup.DataSource = oMemberGroupList;
            cboParentGroup.DisplayMember = "GroupCode";
            cboParentGroup.ValueMember = "GroupId";
            */
            cboParentGroup.SelectedIndex = cboParentGroup.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindMemberGroupList()
        {
            this.lvMemberGroupList.ListViewItemSorter = new ListViewItemSorter(lvMemberGroupList);
            this.lvMemberGroupList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT GroupId,  ROW_NUMBER() OVER (ORDER BY GroupCode) AS rownum, ");
            sql.Append(" GroupCode, GroupName, GroupName_Chs, GroupName_Cht ");
            sql.Append(" FROM MemberGroup ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvMemberGroupList.Items.Add(reader.GetGuid(0).ToString()); // MemberGroupId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // MemberGroupCode
                    objItem.SubItems.Add(reader.GetString(3)); // MemberGroup Name
                    objItem.SubItems.Add(reader.GetString(4)); // MemberGroup Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // MemberGroup Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save

        private bool IsValid()
        {
            bool result = true;

            #region Group Code 唔可以吉
            errorProvider.SetError(txtGroupCode, string.Empty);
            if (txtGroupCode.Text.Length == 0)
            {
                errorProvider.SetError(txtGroupCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Group Code 係咪 in use
            errorProvider.SetError(txtGroupCode, string.Empty);
            if (_GroupId == System.Guid.Empty && ModelEx.MemberGroupEx.IsGroupCodeInUse(txtGroupCode.Text.Trim()))
            {
                errorProvider.SetError(txtGroupCode, "Groud Code in use");
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
                var item = ctx.MemberGroup.Find(_GroupId);

                if (item == null)
                {
                    item = new EF6.MemberGroup();
                    item.GroupId = new Guid();
                    item.GroupCode = txtGroupCode.Text;

                    ctx.MemberGroup.Add(item);
                }
                item.GroupName = txtGroupName.Text;
                item.GroupName_Chs = txtGroupNameAlt1.Text;
                item.GroupName_Cht = txtGroupNameAlt2.Text;
                if ((Guid)cboParentGroup.SelectedValue != Guid.Empty) item.ParentGroup = (Guid)cboParentGroup.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result; ;
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oMemberGroup = ctx.MemberGroup.Find(_GroupId);
                if (oMemberGroup != null)
                {
                    try
                    {
                        ctx.MemberGroup.Remove(oMemberGroup);
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

        private void lvMemberGroupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMemberGroupList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvMemberGroupList.SelectedItem.Text, out id))
                {
                    var oMemberGroup = ModelEx.MemberGroupEx.Get(id);
                    if (oMemberGroup != null)
                    {
                        _GroupId = oMemberGroup.GroupId;

                        FillParentGroupList();

                        txtGroupCode.Text = oMemberGroup.GroupCode;
                        txtGroupName.Text = oMemberGroup.GroupName;
                        txtGroupNameAlt1.Text = oMemberGroup.GroupName_Chs;
                        txtGroupNameAlt2.Text = oMemberGroup.GroupName_Cht;
                        cboParentGroup.SelectedValue = oMemberGroup.ParentGroup.HasValue ? oMemberGroup.ParentGroup : Guid.Empty;

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

                BindMemberGroupList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}