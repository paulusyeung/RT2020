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
    public partial class LineOfOperationWizard : Form
    {
        public LineOfOperationWizard()
        {
            InitializeComponent();
            SetToolBar();
            FillComboList();
            BindLineOfOperationList();
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

            if (LineOfOperationId == System.Guid.Empty)
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
                            BindLineOfOperationList();
                            this.Update();
                        }
                        break;
                    case "refresh":
                        BindLineOfOperationList();
                        this.Update();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region LineOfOperation Code
        private void SetCtrlEditable()
        {
            txtLineOfOperationCode.BackColor = (this.LineOfOperationId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtLineOfOperationCode.ReadOnly = (this.LineOfOperationId != System.Guid.Empty);

            ClearError();
        }

        private void ClearError()
        {
            errorProvider.SetError(txtLineOfOperationCode, string.Empty);
        }
        #endregion

        #region Binding
        private void BindLineOfOperationList()
        {
            this.lvLineOfOperationList.ListViewItemSorter = new ListViewItemSorter(lvLineOfOperationList);
            this.lvLineOfOperationList.Items.Clear();

            int iCount = 1;
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT LineOfOperationId,  ROW_NUMBER() OVER (ORDER BY LineOfOperationCode) AS rownum, ");
            sql.Append(" LineOfOperationCode, LineOfOperationName, LineOfOperationName_Chs, LineOfOperationName_Cht ");
            sql.Append(" FROM LineOfOperation ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem objItem = this.lvLineOfOperationList.Items.Add(reader.GetGuid(0).ToString()); // LineOfOperationId
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(reader.GetString(2)); // LineOfOperationCode
                    objItem.SubItems.Add(reader.GetString(3)); // LineOfOperation Name
                    objItem.SubItems.Add(reader.GetString(4)); // LineOfOperation Name Chs
                    objItem.SubItems.Add(reader.GetString(5)); // LineOfOperation Name Cht

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
            cboCurrency.DataSource = null;
            cboCurrency.Items.Clear();

            string[] orderBy = new string[] { "CurrencyCode" };
            CurrencyCollection oCnyList = Currency.LoadCollection(orderBy, true);
            oCnyList.Add(new Currency(System.Guid.Empty, string.Empty, string.Empty, string.Empty, 0, 0, DateTime.Now, System.Guid.Empty, DateTime.Now, System.Guid.Empty, false, DateTime.Now, System.Guid.Empty));
            cboCurrency.DataSource = oCnyList;
            cboCurrency.DisplayMember = "CurrencyCode";
            cboCurrency.ValueMember = "CurrencyId";

            cboCurrency.SelectedIndex = cboCurrency.Items.Count - 1;
        }

        private void FillParentLineList()
        {
            cboParentLine.DataSource = null;
            cboParentLine.Items.Clear();

            string sql = "LineOfOperationId NOT IN ('" + this.LineOfOperationId.ToString() + "')";
            string[] orderBy = new string[] { "LineOfOperationCode" };
            LineOfOperationCollection oLOOList = LineOfOperation.LoadCollection(sql, orderBy, true);
            oLOOList.Add(new LineOfOperation(System.Guid.Empty, System.Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, false));
            cboParentLine.DataSource = oLOOList;
            cboParentLine.DisplayMember = "LineOfOperationCode";
            cboParentLine.ValueMember = "LineOfOperationId";

            cboParentLine.SelectedIndex = cboParentLine.Items.Count - 1;
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "LineOfOperationCode = '" + txtLineOfOperationCode.Text.Trim() + "'";
            LineOfOperationCollection locList = LineOfOperation.LoadCollection(sql);
            if (locList.Count > 0)
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
            if (txtLineOfOperationCode.Text.Length == 0)
            {
                errorProvider.SetError(txtLineOfOperationCode, "Cannot be blank!");
                return false;
            }
            else
            {
                errorProvider.SetError(txtLineOfOperationCode, string.Empty);

                LineOfOperation oLineOfOperation = LineOfOperation.Load(this.LineOfOperationId);
                if (oLineOfOperation == null)
                {
                    oLineOfOperation = new LineOfOperation();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtLineOfOperationCode, string.Format(Resources.Common.DuplicatedCode, "Line of Operation Code"));
                        return false;
                    }
                    else
                    {
                        oLineOfOperation.LineOfOperationCode = txtLineOfOperationCode.Text;
                        errorProvider.SetError(txtLineOfOperationCode, string.Empty);
                    }
                }
                oLineOfOperation.LineOfOperationName = txtLineOfOperationName.Text;
                oLineOfOperation.LineOfOperationName_Chs = txtLineOfOperationNameChs.Text;
                oLineOfOperation.LineOfOperationName_Cht = txtLineOfOperationNameCht.Text;
                oLineOfOperation.CurrencyCode = cboCurrency.Text;
                oLineOfOperation.PrimaryLine = chkPrimaryLine.Checked;
                oLineOfOperation.ParentLine = (cboParentLine.SelectedValue == null) ? System.Guid.Empty : new System.Guid(cboParentLine.SelectedValue.ToString());

                oLineOfOperation.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            LineOfOperationWizard wizLOC = new LineOfOperationWizard();
            wizLOC.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid LineOfOperationId
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
            LineOfOperation oLineOfOperation = LineOfOperation.Load(this.LineOfOperationId);
            if (oLineOfOperation != null)
            {
                try
                {
                    oLineOfOperation.Delete();
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record being used by other record!", "Delete Warning");
                }
            }
        }

        private void lvLineOfOperationList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvLineOfOperationList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvLineOfOperationList.SelectedItem.Text))
                {
                    LineOfOperation oLineOfOperation = LineOfOperation.Load(new System.Guid(lvLineOfOperationList.SelectedItem.Text));
                    if (oLineOfOperation != null)
                    {
                        this.LineOfOperationId = oLineOfOperation.LineOfOperationId;

                        FillComboList();

                        txtLineOfOperationCode.Text = oLineOfOperation.LineOfOperationCode;
                        txtLineOfOperationName.Text = oLineOfOperation.LineOfOperationName;
                        txtLineOfOperationNameChs.Text = oLineOfOperation.LineOfOperationName_Chs;
                        txtLineOfOperationNameCht.Text = oLineOfOperation.LineOfOperationName_Cht;
                        cboCurrency.Text = oLineOfOperation.CurrencyCode;
                        chkPrimaryLine.Checked = oLineOfOperation.PrimaryLine;
                        cboParentLine.SelectedValue = oLineOfOperation.ParentLine;

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

                BindLineOfOperationList();
                Clear();
                SetCtrlEditable();
            }
        }
    }
}