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

namespace RT2020.Settings
{
    public partial class PhoneTagWizard : Form
    {
        public PhoneTagWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            BindPhoneList();
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

            if (PhoneId == System.Guid.Empty)
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
                        SetCtrlEditable();
                        break;
                    case "save":
                        if (Save())
                        {
                            Clear();
                            BindPhoneList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindPhoneList();
                        this.Update();
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
            txtPhoneCode.BackColor = (this.PhoneId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtPhoneCode.ReadOnly = (this.PhoneId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtPhoneCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }
        #endregion

        #region Binding
        private void BindPhoneList()
        {
            this.lvPhoneList.ListViewItemSorter = new ListViewItemSorter(lvPhoneList);
            this.lvPhoneList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT PhoneTagId,  ROW_NUMBER() OVER (ORDER BY PhoneCode) AS rownum, ");
            sql.Append(" PhoneCode, PhoneName, PhoneName_Chs, PhoneName_Cht ");
            sql.Append(" FROM PhoneTag ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvPhoneList.Items.Add(reader.GetGuid(0).ToString()); // PhoneId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // PhoneCode
                    objItem.SubItems.Add(reader.GetString(3)); // PhoneTag Name
                    objItem.SubItems.Add(reader.GetString(4)); // PhoneTag Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // PhoneTag Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "PhoneCode = '" + txtPhoneCode.Text.Trim() + "'";
            PhoneTagCollection tagList = PhoneTag.LoadCollection(sql);
            if (tagList.Count > 0)
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
            if (txtPhoneCode.Text.Length == 0)
            {
                errorProvider.SetError(txtPhoneCode, "Cannot be blank!");
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
                errorProvider.SetError(txtPhoneCode, string.Empty);
                errorProvider.SetError(txtPriority, string.Empty);

                PhoneTag oPhone = PhoneTag.Load(this.PhoneId);
                if (oPhone == null)
                {
                    oPhone = new PhoneTag();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtPhoneCode, string.Format(Resources.Common.DuplicatedCode, "Phone Tag Code"));
                        return false;
                    }
                    else
                    {
                        oPhone.PhoneCode = txtPhoneCode.Text;
                        errorProvider.SetError(txtPhoneCode, string.Empty);
                    }
                }
                oPhone.PhoneName = txtPhoneName.Text;
                oPhone.PhoneName_Chs = txtPhoneNameChs.Text;
                oPhone.PhoneName_Cht = txtPhoneNameCht.Text;
                oPhone.Priority = Convert.ToInt32(txtPriority.Text);

                oPhone.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            PhoneTagWizard wizTag = new PhoneTagWizard();
            wizTag.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid PhoneId
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

        private void Delete()
        {
            PhoneTag oPhone = PhoneTag.Load(this.PhoneId);
            if (oPhone != null)
            {
                try
                {
                    oPhone.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvPhoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvPhoneList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvPhoneList.SelectedItem.Text))
                {
                    PhoneTag oPhone = PhoneTag.Load(new System.Guid(lvPhoneList.SelectedItem.Text));
                    if (oPhone != null)
                    {
                        txtPhoneCode.Text = oPhone.PhoneCode;
                        txtPhoneName.Text = oPhone.PhoneName;
                        txtPhoneNameChs.Text = oPhone.PhoneName_Chs;
                        txtPhoneNameCht.Text = oPhone.PhoneName_Cht;
                        txtPriority.Text = oPhone.Priority.ToString();

                        this.PhoneId = oPhone.PhoneTagId;

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

                BindPhoneList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}