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
                        if (IsValid())
                        {
                            Save();
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
            string sql = "NatureId NOT IN ('" + this.WorkplaceNatureId.ToString() + "')";
            string[] orderBy = new string[] { "NatureCode" };
            ModelEx.WorkplaceNatureEx.LoadCombo(ref cboParentNature, "NatureCode", false, false, "", sql, orderBy);
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
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
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

        private bool IsValid()
        {
            bool result = true;

            #region CountryCode 唔可以吉
            errorProvider.SetError(txtWorkplaceNatureCode, string.Empty);
            if (txtWorkplaceNatureCode.Text.Length == 0)
            {
                errorProvider.SetError(txtWorkplaceNatureCode, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check CountryCode 係咪 in use
            errorProvider.SetError(txtWorkplaceNatureCode, string.Empty);
            if (this.WorkplaceNatureId == System.Guid.Empty && ModelEx.WorkplaceNatureEx.IsNatureCodeInUse(txtWorkplaceNatureCode.Text.Trim()))
            {
                errorProvider.SetError(txtWorkplaceNatureCode, "Nature Code in use");
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
                var wn = ctx.WorkplaceNature.Find(this.WorkplaceNatureId);

                if (wn == null)
                {
                    wn = new EF6.WorkplaceNature();
                    wn.NatureId = new Guid();

                    ctx.WorkplaceNature.Add(wn);
                    wn.NatureCode = txtWorkplaceNatureCode.Text;
                }
                wn.NatureName = txtWorkplaceNatureName.Text;
                wn.NatureName_Chs = txtWorkplaceNatureNameChs.Text;
                wn.NatureName_Cht = txtWorkplaceNatureNameCht.Text;
                wn.ParentNature = (cboParentNature.SelectedValue == null) ? Guid.Empty : new Guid(cboParentNature.SelectedValue.ToString());

                ctx.SaveChanges();
                result = true;
            }

            return result;
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
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var m = ctx.WorkplaceNature.Find(this.WorkplaceNatureId);
                    if (m != null)
                    {
                        ctx.WorkplaceNature.Remove(m);
                        ctx.SaveChanges();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void lvWorkplaceNatureList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvWorkplaceNatureList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvWorkplaceNatureList.SelectedItem.Text, out id))
                {
                    this.WorkplaceNatureId = id;
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var w = ctx.WorkplaceNature.Find(this.WorkplaceNatureId);
                        if (w != null)
                        {
                            FillParentNatureList();

                            txtWorkplaceNatureCode.Text = w.NatureCode;
                            txtWorkplaceNatureName.Text = w.NatureName;
                            txtWorkplaceNatureNameChs.Text = w.NatureName_Chs;
                            txtWorkplaceNatureNameCht.Text = w.NatureName_Cht;
                            cboParentNature.SelectedValue = w.ParentNature;

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

                BindWorkplaceNatureList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}