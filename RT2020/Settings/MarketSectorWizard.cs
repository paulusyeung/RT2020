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
    public partial class MarketSectorWizard : Form
    {
        public MarketSectorWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillParentSectorList();
            BindMarketSectorList();
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

            if (MarketSectorId == System.Guid.Empty)
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
                            BindMarketSectorList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindMarketSectorList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region MarketSector Code
        private void SetCtrlEditable()
        {
            txtMarketSectorCode.BackColor = (this.MarketSectorId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtMarketSectorCode.ReadOnly = (this.MarketSectorId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtMarketSectorCode, string.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentSectorList()
        {
            cboParentSector.DataSource = null;
            cboParentSector.Items.Clear();

            string sql = "MarketSectorId NOT IN ('" + this.MarketSectorId.ToString() + "')";
            string[] orderBy = new string[] { "MarketSectorCode" };
            MarketSectorCollection oMarketSectorList = MarketSector.LoadCollection(sql, orderBy, true);
            oMarketSectorList.Add(new MarketSector(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty));
            cboParentSector.DataSource = oMarketSectorList;
            cboParentSector.DisplayMember = "MarketSectorCode";
            cboParentSector.ValueMember = "MarketSectorId";

            cboParentSector.SelectedIndex = cboParentSector.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindMarketSectorList()
        {
            this.lvMarketSectorList.ListViewItemSorter = new ListViewItemSorter(lvMarketSectorList);
            this.lvMarketSectorList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT MarketSectorId,  ROW_NUMBER() OVER (ORDER BY MarketSectorCode) AS rownum, ");
            sql.Append(" MarketSectorCode, MarketSectorName, MarketSectorName_Chs, MarketSectorName_Cht ");
            sql.Append(" FROM MarketSector ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvMarketSectorList.Items.Add(reader.GetGuid(0).ToString()); // MarketSectorId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // MarketSectorCode
                    objItem.SubItems.Add(reader.GetString(3)); // MarketSector Name
                    objItem.SubItems.Add(reader.GetString(4)); // MarketSector Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // MarketSector Name Cht

                    iCount++;
                }
            }
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "MarketSectorCode = '" + txtMarketSectorCode.Text.Trim() + "'";
            MarketSectorCollection mList = MarketSector.LoadCollection(sql);
            if (mList.Count > 0)
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
            if (txtMarketSectorCode.Text.Length == 0)
            {
                errorProvider.SetError(txtMarketSectorCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtMarketSectorCode, string.Empty);

                MarketSector oMarketSector = MarketSector.Load(this.MarketSectorId);
                if (oMarketSector == null)
                {
                    oMarketSector = new MarketSector();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtMarketSectorCode, string.Format(Resources.Common.DuplicatedCode, "Market Sector Code"));
                        return false;
                    }
                    else
                    {
                        oMarketSector.MarketSectorCode = txtMarketSectorCode.Text;
                        errorProvider.SetError(txtMarketSectorCode, string.Empty);
                    }
                }
                oMarketSector.MarketSectorName = txtMarketSectorName.Text;
                oMarketSector.MarketSectorName_Chs = txtMarketSectorNameChs.Text;
                oMarketSector.MarketSectorName_Cht = txtMarketSectorNameCht.Text;
                oMarketSector.ParentSector = (cboParentSector.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentSector.SelectedValue.ToString());

                oMarketSector.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            MarketSectorWizard wizMarket = new MarketSectorWizard();
            wizMarket.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid MarketSectorId
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
            MarketSector oMarketSector = MarketSector.Load(this.MarketSectorId);
            if (oMarketSector != null)
            {
                try
                {
                    oMarketSector.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvMarketSectorList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvMarketSectorList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvMarketSectorList.SelectedItem.Text))
                {
                    MarketSector oMarketSector = MarketSector.Load(new System.Guid(lvMarketSectorList.SelectedItem.Text));
                    if (oMarketSector != null)
                    {
                        this.MarketSectorId = oMarketSector.MarketSectorId;

                        FillParentSectorList();

                        txtMarketSectorCode.Text = oMarketSector.MarketSectorCode;
                        txtMarketSectorName.Text = oMarketSector.MarketSectorName;
                        txtMarketSectorNameChs.Text = oMarketSector.MarketSectorName_Chs;
                        txtMarketSectorNameCht.Text = oMarketSector.MarketSectorName_Cht;
                        cboParentSector.SelectedValue = oMarketSector.ParentSector;

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

                BindMarketSectorList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}