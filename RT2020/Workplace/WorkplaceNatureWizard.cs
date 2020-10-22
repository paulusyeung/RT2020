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

namespace RT2020.Workplace
{
    public partial class WorkplaceNatureWizard : Form
    {
        public WorkplaceNatureWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentNatureList();
            BindWorkplaceNatureList();
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

            if (WorkplaceNatureId == System.Guid.Empty)
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
                            BindWorkplaceNatureList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindWorkplaceNatureList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region WorkplaceNature Code
        private void SetCtrlEditable()
        {
            txtWorkplaceNatureCode.BackColor = (this.WorkplaceNatureId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtWorkplaceNatureCode.ReadOnly = (this.WorkplaceNatureId != System.Guid.Empty);

            ClearError();
        }
    
        private void ClearError()
        {
            errorProvider.SetError(txtWorkplaceNatureCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentNatureList()
        {
            cboParentNature.DataSource = null;
            cboParentNature.Items.Clear();

            string sql = "NatureId NOT IN ('" + this.WorkplaceNatureId.ToString() + "')";
            string[] orderBy = new string[] { "NatureCode" };
            WorkplaceNatureCollection oWorkplaceNatureList = WorkplaceNature.LoadCollection(sql, orderBy, true);
            oWorkplaceNatureList.Add(new WorkplaceNature());
            cboParentNature.DataSource = oWorkplaceNatureList;
            cboParentNature.DisplayMember = "NatureCode";
            cboParentNature.ValueMember = "NatureId";

            cboParentNature.SelectedIndex = cboParentNature.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindWorkplaceNatureList()
        {
            this.lvWorkplaceNatureList.ListViewItemSorter = new ListViewItemSorter(lvWorkplaceNatureList);
            this.lvWorkplaceNatureList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT NatureId,  ROW_NUMBER() OVER (ORDER BY NatureCode) AS rownum, ");
            sql.Append(" NatureCode, NatureName, NatureName_Chs, NatureName_Cht ");
            sql.Append(" FROM WorkplaceNature ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvWorkplaceNatureList.Items.Add(reader.GetGuid(0).ToString()); // WorkplaceNatureId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // WorkplaceNatureCode
                    objItem.SubItems.Add(reader.GetString(3)); // WorkplaceNature Name
                    objItem.SubItems.Add(reader.GetString(4)); // WorkplaceNature Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // WorkplaceNature Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "NatureCode = '" + txtWorkplaceNatureCode.Text.Trim() + "'";
            WorkplaceNatureCollection natureList = WorkplaceNature.LoadCollection(sql);
            if (natureList.Count > 0)
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
            if (txtWorkplaceNatureCode.Text.Length == 0)
            {
                errorProvider.SetError(txtWorkplaceNatureCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtWorkplaceNatureCode, string.Empty);

                WorkplaceNature oWorkplaceNature = WorkplaceNature.Load(this.WorkplaceNatureId);
                if (oWorkplaceNature == null)
                {
                    oWorkplaceNature = new WorkplaceNature();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtWorkplaceNatureCode, string.Format(Resources.Common.DuplicatedCode, "Workplace Nature Code"));
                        return false;
                    }
                    else
                    {
                        oWorkplaceNature.NatureCode = txtWorkplaceNatureCode.Text;
                        errorProvider.SetError(txtWorkplaceNatureCode, string.Empty);
                    }
                }
                oWorkplaceNature.NatureName = txtWorkplaceNatureName.Text;
                oWorkplaceNature.NatureName_Chs = txtWorkplaceNatureNameChs.Text;
                oWorkplaceNature.NatureName_Cht = txtWorkplaceNatureNameCht.Text;
                oWorkplaceNature.ParentNature = (cboParentNature.SelectedValue == null)? System.Guid.Empty:new System.Guid(cboParentNature.SelectedValue.ToString());

                oWorkplaceNature.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            WorkplaceNatureWizard wizNature = new WorkplaceNatureWizard();
            wizNature.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid WorkplaceNatureId
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
            WorkplaceNature oNature = WorkplaceNature.Load(this.WorkplaceNatureId);
            if (oNature != null)
            {
                try
                {
                    oNature.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvWorkplaceNatureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWorkplaceNatureList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvWorkplaceNatureList.SelectedItem.Text))
                {
                    WorkplaceNature oWorkplaceNature = WorkplaceNature.Load(new System.Guid(lvWorkplaceNatureList.SelectedItem.Text));
                    if (oWorkplaceNature != null)
                    {
                        this.WorkplaceNatureId = oWorkplaceNature.NatureId;

                        FillParentNatureList();

                        txtWorkplaceNatureCode.Text = oWorkplaceNature.NatureCode;
                        txtWorkplaceNatureName.Text = oWorkplaceNature.NatureName;
                        txtWorkplaceNatureNameChs.Text = oWorkplaceNature.NatureName_Chs;
                        txtWorkplaceNatureNameCht.Text = oWorkplaceNature.NatureName_Cht;
                        cboParentNature.SelectedValue = oWorkplaceNature.ParentNature;

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

                BindWorkplaceNatureList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}