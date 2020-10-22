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
    public partial class SalutationWizard : Form
    {
        public SalutationWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentSalutationList();
            BindSalutationList();
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

            if (SalutationId == System.Guid.Empty)
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
                            BindSalutationList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindSalutationList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region Salutation Code
        private void SetCtrlEditable()
        {
            txtSalutationCode.BackColor = (this.SalutationId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtSalutationCode.ReadOnly = (this.SalutationId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtSalutationCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentSalutationList()
        {
            cboParentSalutation.DataSource = null;
            cboParentSalutation.Items.Clear();

            string sql = "SalutationId NOT IN ('" + this.SalutationId.ToString() + "')";
            string[] orderBy = new string[] { "SalutationCode" };
            SalutationCollection oSalutationList = Salutation.LoadCollection(sql, orderBy, true);
            oSalutationList.Add(new Salutation(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            cboParentSalutation.DataSource = oSalutationList;
            cboParentSalutation.DisplayMember = "SalutationCode";
            cboParentSalutation.ValueMember = "SalutationId";

            cboParentSalutation.SelectedIndex = cboParentSalutation.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindSalutationList()
        {
            this.lvSalutationList.ListViewItemSorter = new ListViewItemSorter(lvSalutationList);
            this.lvSalutationList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT SalutationId,  ROW_NUMBER() OVER (ORDER BY SalutationCode) AS rownum, ");
            sql.Append(" SalutationCode, SalutationName, SalutationName_Chs, SalutationName_Cht ");
            sql.Append(" FROM Salutation ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvSalutationList.Items.Add(reader.GetGuid(0).ToString()); // SalutationId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // SalutationCode
                    objItem.SubItems.Add(reader.GetString(3)); // Salutation Name
                    objItem.SubItems.Add(reader.GetString(4)); // Salutation Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // Salutation Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "SalutationCode = '" + txtSalutationCode.Text.Trim() + "'";
            SalutationCollection salutationList = Salutation.LoadCollection(sql);
            if (salutationList.Count > 0)
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
            if (txtSalutationCode.Text.Length == 0)
            {
                errorProvider.SetError(txtSalutationCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtSalutationCode, string.Empty);

                Salutation oSalutation = Salutation.Load(this.SalutationId);
                if (oSalutation == null)
                {
                    oSalutation = new Salutation();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtSalutationCode, string.Format(Resources.Common.DuplicatedCode, "Salutatoin Code"));
                        return false;
                    }
                    else
                    {
                        oSalutation.SalutationCode = txtSalutationCode.Text;
                        errorProvider.SetError(txtSalutationCode, string.Empty);
                    }
                }
                oSalutation.SalutationName = txtSalutationName.Text;
                oSalutation.SalutationName_Chs = txtSalutationNameChs.Text;
                oSalutation.SalutationName_Cht = txtSalutationNameCht.Text;
                oSalutation.ParentSalutation = (cboParentSalutation.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentSalutation.SelectedValue.ToString());

                oSalutation.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            SalutationWizard wizSalutation = new SalutationWizard();
            wizSalutation.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid SalutationId
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
            Salutation oSalutation = Salutation.Load(this.SalutationId);
            if (oSalutation != null)
            {
                try
                {
                    oSalutation.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvSalutationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSalutationList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvSalutationList.SelectedItem.Text))
                {
                    Salutation oSalutation = Salutation.Load(new System.Guid(lvSalutationList.SelectedItem.Text));
                    if (oSalutation != null)
                    {
                        this.SalutationId = oSalutation.SalutationId;

                        FillParentSalutationList();

                        txtSalutationCode.Text = oSalutation.SalutationCode;
                        txtSalutationName.Text = oSalutation.SalutationName;
                        txtSalutationNameChs.Text = oSalutation.SalutationName_Chs;
                        txtSalutationNameCht.Text = oSalutation.SalutationName_Cht;
                        cboParentSalutation.SelectedValue = oSalutation.ParentSalutation;

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

                BindSalutationList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}