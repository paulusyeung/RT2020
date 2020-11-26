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
    public partial class ZoneWizard : Form
    {
        public ZoneWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillComboList();
            BindZoneList();
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

            if (ZoneId == System.Guid.Empty)
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
                            BindZoneList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindZoneList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region WorkplaceZone Code
        private void SetCtrlEditable()
        {
            txtZoneCode.BackColor = (this.ZoneId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtZoneCode.ReadOnly = (this.ZoneId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtZoneCode, string.Empty);
        }
        #endregion

        #region Binding
        private void BindZoneList()
        {
            this.lvZoneList.ListViewItemSorter = new ListViewItemSorter(lvZoneList);
            this.lvZoneList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ZoneId,  ROW_NUMBER() OVER (ORDER BY ZoneCode) AS rownum, ");
            sql.Append(" ZoneCode, ZoneName, ZoneName_Chs, ZoneName_Cht ");
            sql.Append(" FROM WorkplaceZone ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvZoneList.Items.Add(reader.GetGuid(0).ToString()); // ZoneId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // ZoneCode
                    objItem.SubItems.Add(reader.GetString(3)); // WorkplaceZone Name
                    objItem.SubItems.Add(reader.GetString(4)); // WorkplaceZone Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // WorkplaceZone Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillCurrencyList();
            FillParentLineList();
        }

        private void FillCurrencyList()
        {
            ModelEx.CurrencyEx.LoadCombo(ref cboCurrency, "CurrencyCode", false);
        }

        private void FillParentLineList()
        {
            chkParentZone.DataSource = null;
            chkParentZone.Items.Clear();

            string sql = "ZoneId NOT IN ('" + this.ZoneId.ToString() + "')";
            string[] orderBy = new string[] { "ZoneCode" };
            WorkplaceZoneCollection oLOOList = WorkplaceZone.LoadCollection(sql, orderBy, true);
            oLOOList.Add(new WorkplaceZone());
            chkParentZone.DataSource = oLOOList;
            chkParentZone.DisplayMember = "ZoneCode";
            chkParentZone.ValueMember = "ZoneId";

            chkParentZone.SelectedIndex = chkParentZone.Items.Count - 1;
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "ZoneCode = '" + txtZoneCode.Text.Trim() + "'";
            WorkplaceZoneCollection zoneList = WorkplaceZone.LoadCollection(sql);
            if (zoneList.Count > 0)
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
            if (txtZoneCode.Text.Length == 0)
            {
                errorProvider.SetError(txtZoneCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtZoneCode, string.Empty);

                WorkplaceZone oZone = WorkplaceZone.Load(this.ZoneId);
                if (oZone == null)
                {
                    oZone = new WorkplaceZone();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtZoneCode, string.Format(Resources.Common.DuplicatedCode, "Zone Code"));
                        return false;
                    }
                    else
                    {
                        oZone.ZoneCode = txtZoneCode.Text;
                        errorProvider.SetError(txtZoneCode, string.Empty);
                    }
                }
                oZone.ZoneInitial = txtZoneInitial.Text;
                oZone.ZoneName = txtZoneName.Text;
                oZone.ZoneName_Chs = txtZoneNameChs.Text;
                oZone.ZoneName_Cht = txtZoneNameCht.Text;
                oZone.CurrencyCode = cboCurrency.Text;
                oZone.PromaryZone = chkPrimaryZone.Checked;
                oZone.ParentZone = (chkParentZone.SelectedValue == null) ? System.Guid.Empty : new System.Guid(chkParentZone.SelectedValue.ToString());
                oZone.Notes = txtRemarks.Text;

                oZone.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            ZoneWizard wizZone = new ZoneWizard();
            wizZone.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid ZoneId
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
            WorkplaceZone oWorkplaceZone = WorkplaceZone.Load(this.ZoneId);
            if (oWorkplaceZone != null)
            {
                try
                {
                    oWorkplaceZone.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvZoneList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvZoneList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvZoneList.SelectedItem.Text))
                {
                    WorkplaceZone oZone = WorkplaceZone.Load(new System.Guid(lvZoneList.SelectedItem.Text));
                    if (oZone != null)
                    {
                        this.ZoneId = oZone.ZoneId;

                        FillComboList();

                        txtZoneCode.Text = oZone.ZoneCode;
                        txtZoneInitial.Text = oZone.ZoneInitial;
                        txtZoneName.Text = oZone.ZoneName;
                        txtZoneNameChs.Text = oZone.ZoneName_Chs;
                        txtZoneNameCht.Text = oZone.ZoneName_Cht;
                        cboCurrency.Text = oZone.CurrencyCode;
                        chkPrimaryZone.Checked = oZone.PromaryZone;
                        chkParentZone.SelectedValue = oZone.ParentZone;
                        txtRemarks.Text = oZone.Notes;

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

                BindZoneList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}