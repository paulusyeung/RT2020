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
                        if (IsValid())
                        {
                            Save();
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
            string sql = "SalutationId NOT IN ('" + this.SalutationId.ToString() + "')";
            string[] orderBy = new string[] { "SalutationCode" };
            ModelEx.SalutationEx.LoadCombo(ref cboParentSalutation, "SalutationCode", false, true, "", sql, orderBy);
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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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

        private bool IsValid()
        {
            bool result = true;

            #region Salutation Code 唔可以吉
            errorProvider.SetError(txtSalutationCode, string.Empty);
            if (txtSalutationCode.Text.Length == 0)
            {
                errorProvider.SetError(txtSalutationCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Salutation Code 係咪 in use
            errorProvider.SetError(txtSalutationCode, string.Empty);
            if (this.SalutationId == Guid.Empty && ModelEx.SalutationEx.IsSalutationCodeInUse(txtSalutationCode.Text.Trim()))
            {
                errorProvider.SetError(txtSalutationCode, "Salutation Code in use");
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
                var item = ctx.Salutation.Find(this.SalutationId);

                if (item == null)
                {
                    item = new EF6.Salutation();
                    item.SalutationId = new Guid();
                    item.SalutationCode = txtSalutationCode.Text;

                    ctx.Salutation.Add(item);
                }
                item.SalutationName = txtSalutationName.Text;
                item.SalutationName_Chs = txtSalutationNameChs.Text;
                item.SalutationName_Cht = txtSalutationNameCht.Text;
                if ((Guid)cboParentSalutation.SelectedValue == Guid.Empty) item.ParentSalutation = (Guid)cboParentSalutation.SelectedValue;

                ctx.SaveChanges();
                result = true;
            }

            return result; ;
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
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.Salutation.Find(this.SalutationId);
                    if (item != null)
                    {
                        ctx.Salutation.Remove(item);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvSalutationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSalutationList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvSalutationList.SelectedItem.Text, out id))
                {
                    this.SalutationId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var item = ctx.Salutation.Find(this.SalutationId);
                        if (item != null)
                        {
                            FillParentSalutationList();

                            txtSalutationCode.Text = item.SalutationCode;
                            txtSalutationName.Text = item.SalutationName;
                            txtSalutationNameChs.Text = item.SalutationName_Chs;
                            txtSalutationNameCht.Text = item.SalutationName_Cht;
                            cboParentSalutation.SelectedValue = item.ParentSalutation;

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

                BindSalutationList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}