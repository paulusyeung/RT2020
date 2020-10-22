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
    public partial class MemberAddressTypeWizard : Form
    {
        public MemberAddressTypeWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            BindAddressTypeList();
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

            if (AddressTypeId == System.Guid.Empty)
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
                            BindAddressTypeList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindAddressTypeList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region MemberAddressType Code
        private void SetCtrlEditable()
        {
            txtAddressTypeCode.BackColor = (this.AddressTypeId == System.Guid.Empty) ? SystemInfo.ControlBackColor.RequiredBox : SystemInfo.ControlBackColor.DisabledBox;
            txtAddressTypeCode.ReadOnly = (this.AddressTypeId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtAddressTypeCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }
        #endregion

        #region Binding
        private void BindAddressTypeList()
        {
            this.lvAddressTypeList.ListViewItemSorter = new ListViewItemSorter(lvAddressTypeList);
            this.lvAddressTypeList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT AddressTypeId,  ROW_NUMBER() OVER (ORDER BY AddressTypeCode) AS rownum, ");
            sql.Append(" AddressTypeCode, AddressTypeName, AddressTypeName_Chs, AddressTypeName_Cht ");
            sql.Append(" FROM MemberAddressType ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvAddressTypeList.Items.Add(reader.GetGuid(0).ToString()); // AddressTypeId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // AddressTypeCode
                    objItem.SubItems.Add(reader.GetString(3)); // MemberAddressType Name
                    objItem.SubItems.Add(reader.GetString(4)); // MemberAddressType Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // MemberAddressType Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "AddressTypeCode = '" + txtAddressTypeCode.Text.Trim() + "'";
            MemberAddressTypeCollection typeList = MemberAddressType.LoadCollection(sql);
            if (typeList.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool Verify()
        {
            if (txtAddressTypeCode.Text.Length == 0)
            {
                errorProvider.SetError(txtAddressTypeCode, "Cannot be blank!");
                return false;
            }
            else if (txtPriority.Text.Length == 0)
            {
                errorProvider.SetError(txtPriority, "Cannot be blank!");
                return false;
            }
            else if (!Common.Utility.IsNumeric(txtPriority.Text))
            {
                errorProvider.SetError(txtPriority, Resources.Common.DigitalNeeded);
                return false;
            }
            else
            {
                errorProvider.SetError(txtAddressTypeCode, string.Empty);
                errorProvider.SetError(txtPriority, string.Empty);
                return true;
            }
        }

        private bool Save()
        {
            if (Verify())
            {
                MemberAddressType oAddressType = MemberAddressType.Load(this.AddressTypeId);
                if (oAddressType == null)
                {
                    oAddressType = new MemberAddressType();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtAddressTypeCode, string.Format(Resources.Common.DuplicatedCode, "Member Address Type Code"));
                        return false;
                    }
                    else
                    {
                        errorProvider.SetError(txtAddressTypeCode, string.Empty);
                        oAddressType.AddressTypeCode = txtAddressTypeCode.Text;
                    }
                }
                oAddressType.AddressTypeName = txtAddressTypeName.Text;
                oAddressType.AddressTypeName_Chs = txtAddressTypeNameChs.Text;
                oAddressType.AddressTypeName_Cht = txtAddressTypeNameCht.Text;
                oAddressType.Priority = Convert.ToInt32(txtPriority.Text);

                oAddressType.Save();

                return true;
            }
            else
            {
                return false;
            }
        }

        private void Clear()
        {
            this.Close();

            MemberAddressTypeWizard wizType = new MemberAddressTypeWizard();
            wizType.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid AddressTypeId
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
            MemberAddressType oAddressType = MemberAddressType.Load(this.AddressTypeId);
            if (oAddressType != null)
            {
                try
                {
                    oAddressType.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }
        #endregion

        private void lvAddressTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAddressTypeList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvAddressTypeList.SelectedItem.Text))
                {
                    MemberAddressType oAddressType = MemberAddressType.Load(new System.Guid(lvAddressTypeList.SelectedItem.Text));
                    if (oAddressType != null)
                    {
                        txtAddressTypeCode.Text = oAddressType.AddressTypeCode;
                        txtAddressTypeName.Text = oAddressType.AddressTypeName;
                        txtAddressTypeNameChs.Text = oAddressType.AddressTypeName_Chs;
                        txtAddressTypeNameCht.Text = oAddressType.AddressTypeName_Cht;
                        txtPriority.Text = oAddressType.Priority.ToString();

                        this.AddressTypeId = oAddressType.AddressTypeId;

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

                BindAddressTypeList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}