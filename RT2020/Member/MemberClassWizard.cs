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
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;

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
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", "Save");
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");
            cmdSave.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Write);

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
                cmdDelete.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(Common.Enums.Permission.Delete);
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
                        if (Save())
                        {
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
            MemberClassCollection oMemberClassList = MemberClass.LoadCollection(sql, orderBy, true);
            oMemberClassList.Add(new MemberClass(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            cboParentClass.DataSource = oMemberClassList;
            cboParentClass.DisplayMember = "ClassCode";
            cboParentClass.ValueMember = "ClassId";

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
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
        private bool CodeExists()
        {
            string sql = "ClassCode = '" + txtMemberClassCode.Text.Trim() + "'";
            MemberClassCollection classList = MemberClass.LoadCollection(sql);
            if (classList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Save()
        {
            if (txtMemberClassCode.Text.Length == 0)
            {
                errorProvider.SetError(txtMemberClassCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtMemberClassCode, string.Empty);

                MemberClass oMemberClass = MemberClass.Load(this.MemberClassId);
                if (oMemberClass == null)
                {
                    oMemberClass = new MemberClass();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtMemberClassCode, string.Format(Resources.Common.DuplicatedCode, "Member Class Code"));
                        return false;
                    }
                    else
                    {
                        oMemberClass.ClassCode = txtMemberClassCode.Text;
                        errorProvider.SetError(txtMemberClassCode, string.Empty);
                    }
                }
                oMemberClass.ClassName = txtMemberClassName.Text;
                oMemberClass.ClassName_Chs = txtMemberClassNameChs.Text;
                oMemberClass.ClassName_Cht = txtMemberClassNameCht.Text;
                oMemberClass.ParentClass = (cboParentClass.SelectedValue == null)? System.Guid.Empty:new System.Guid(cboParentClass.SelectedValue.ToString());

                oMemberClass.Save();
                return true;
            }
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
            MemberClass oMemberClass = MemberClass.Load(this.MemberClassId);
            if (oMemberClass != null)
            {
                try
                {
                    oMemberClass.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }
        #endregion

        private void lvMemberClassList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMemberClassList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvMemberClassList.SelectedItem.Text))
                {
                    MemberClass oMemberClass = MemberClass.Load(new System.Guid(lvMemberClassList.SelectedItem.Text));
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