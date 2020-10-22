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
    public partial class InternetTagWizard : Form
    {
        public InternetTagWizard()
        {
            InitializeComponent();
            SetCtrlEditable();
            SetToolBar();
            BindInternetTagList();
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

            if (TagId == System.Guid.Empty)
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
                            BindInternetTagList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindInternetTagList();
                        this.Update();
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
            txtInternetTagCode.BackColor = (this.TagId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtInternetTagCode.ReadOnly = (this.TagId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtInternetTagCode, string.Empty);
            errorProvider.SetError(txtPriority, string.Empty);
        }
        #endregion

        #region Binding
        private void BindInternetTagList()
        {
            this.lvInternetTagList.ListViewItemSorter = new ListViewItemSorter(lvInternetTagList);
            this.lvInternetTagList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT TagId,  ROW_NUMBER() OVER (ORDER BY TagCode) AS rownum, ");
            sql.Append(" TagCode, TagName, TagName_Chs, TagName_Cht ");
            sql.Append(" FROM InternetTag ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvInternetTagList.Items.Add(reader.GetGuid(0).ToString()); // TagId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // TagCode
                    objItem.SubItems.Add(reader.GetString(3)); // InternetTag Name
                    objItem.SubItems.Add(reader.GetString(4)); // InternetTag Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // InternetTag Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "TagCode = '" + txtInternetTagCode.Text.Trim() + "'";
            InternetTagCollection tagList = InternetTag.LoadCollection(sql);
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
            if (txtInternetTagCode.Text.Length == 0)
            {
                errorProvider.SetError(txtInternetTagCode, "Cannot be blank!");
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
                errorProvider.SetError(txtInternetTagCode, string.Empty);
                errorProvider.SetError(txtPriority, string.Empty);

                InternetTag oInternetTag = InternetTag.Load(this.TagId);
                if (oInternetTag == null)
                {
                    oInternetTag = new InternetTag();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtInternetTagCode, string.Format(Resources.Common.DuplicatedCode, "Internet Tag Code"));
                        return false;
                    }
                    else
                    {
                        oInternetTag.TagCode = txtInternetTagCode.Text;
                        errorProvider.SetError(txtInternetTagCode, string.Empty);
                    }
                }
                oInternetTag.TagName = txtInternetTagName.Text;
                oInternetTag.TagName_Chs = txtInternetTagNameChs.Text;
                oInternetTag.TagName_Cht = txtInternetTagNameCht.Text;
                oInternetTag.Priority = Convert.ToInt32(txtPriority.Text);

                oInternetTag.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            InternetTagWizard wizTag = new InternetTagWizard();
            wizTag.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid TagId
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
            InternetTag oInternetTag = InternetTag.Load(this.TagId);
            if (oInternetTag != null)
            {
                try
                {
                    oInternetTag.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvInternetTagList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvInternetTagList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvInternetTagList.SelectedItem.Text))
                {
                    InternetTag oInternetTag = InternetTag.Load(new System.Guid(lvInternetTagList.SelectedItem.Text));
                    if (oInternetTag != null)
                    {
                        txtInternetTagCode.Text = oInternetTag.TagCode;
                        txtInternetTagName.Text = oInternetTag.TagName;
                        txtInternetTagNameChs.Text = oInternetTag.TagName_Chs;
                        txtInternetTagNameCht.Text = oInternetTag.TagName_Cht;
                        txtPriority.Text = oInternetTag.Priority.ToString();

                        this.TagId = oInternetTag.TagId;

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

                BindInternetTagList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}