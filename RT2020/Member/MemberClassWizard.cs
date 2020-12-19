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
    public partial class MemberClassWizard : Form
    {
        public MemberClassWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentClassList();
            BindMemberClassList();
            SetCtrlEditable();
        }

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
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);

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

            if (MemberClassId == System.Guid.Empty)
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
                        SetCtrlEditable();
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

        #region MemberClass Code
        private void SetCtrlEditable()
        {
            txtMemberClassCode.BackColor = (this.MemberClassId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtMemberClassCode.ReadOnly = (this.MemberClassId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtMemberClassCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentClassList()
        {
            cboParentClass.DataSource = null;
            cboParentClass.Items.Clear();

            string sql = "ClassId NOT IN ('" + this.MemberClassId.ToString() + "')";
            string[] orderBy = new string[] { "ClassCode" };

            /**
            MemberClassCollection oMemberClassList = MemberClass.LoadCollection(sql, orderBy, true);
            oMemberClassList.Add(new MemberClass(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            cboParentClass.DataSource = oMemberClassList;
            cboParentClass.DisplayMember = "ClassCode";
            cboParentClass.ValueMember = "ClassId";
            */
            cboParentClass.SelectedIndex = cboParentClass.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindMemberClassList()
        {
            this.lvMemberClassList.ListViewItemSorter = new ListViewItemSorter(lvMemberClassList);
            this.lvMemberClassList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ClassId,  ROW_NUMBER() OVER (ORDER BY ClassCode) AS rownum, ");
            sql.Append(" ClassCode, ClassName, ClassName_Chs, ClassName_Cht ");
            sql.Append(" FROM MemberClass ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvMemberClassList.Items.Add(reader.GetGuid(0).ToString()); // MemberClassId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // MemberClassCode
                    objItem.SubItems.Add(reader.GetString(3)); // MemberClass Name
                    objItem.SubItems.Add(reader.GetString(4)); // MemberClass Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // MemberClass Name Cht

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
            errorProvider.SetError(txtMemberClassCode, string.Empty);
            if (txtMemberClassCode.Text.Length == 0)
            {
                errorProvider.SetError(txtMemberClassCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Class Code 係咪 in use
            errorProvider.SetError(txtMemberClassCode, string.Empty);
            if (this.MemberClassId == System.Guid.Empty && ModelEx.MemberGroupEx.IsGroupCodeInUse(txtMemberClassCode.Text.Trim()))
            {
                errorProvider.SetError(txtMemberClassCode, "Class Code in use");
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
                var item = ctx.MemberClass.Find(this.MemberClassId);

                if (item == null)
                {
                    item = new EF6.MemberClass();
                    item.ClassId = new Guid();
                    item.ClassCode = txtMemberClassCode.Text;

                    ctx.MemberClass.Add(item);
                }
                item.ClassName = txtMemberClassName.Text;
                item.ClassName_Chs = txtMemberClassNameChs.Text;
                item.ClassName_Cht = txtMemberClassNameCht.Text;
                item.ParentClass = (cboParentClass.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentClass.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }

        private void Clear()
        {
            this.Close();

            MemberClassWizard wizClass = new MemberClassWizard();
            wizClass.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid MemberClassId
        {
            get
            {
                return countryId;
            }
            set
            {
                countryId = value;
            }
        }
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var oMemberClass = ctx.MemberClass.Find(this.MemberClassId);
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
            if (lvMemberClassList.SelectedItem != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvMemberClassList.SelectedItem.Text, out id))
                {
                    var oMemberClass = ModelEx.MemberClassEx.Get(id);
                    if (oMemberClass != null)
                    {
                        this.MemberClassId = oMemberClass.ClassId;

                        FillParentClassList();

                        txtMemberClassCode.Text = oMemberClass.ClassCode;
                        txtMemberClassName.Text = oMemberClass.ClassName;
                        txtMemberClassNameChs.Text = oMemberClass.ClassName_Chs;
                        txtMemberClassNameCht.Text = oMemberClass.ClassName_Cht;
                        cboParentClass.SelectedValue = oMemberClass.ParentClass;

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