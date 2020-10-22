using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using RT2020.DAL;
using System.Data.Common;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace RT2020.Client.Inventory.GoodsReceive
{
    public partial class Default : Form
    {
        public Default()
        {
            InitializeComponent();

            FillcboCreateBy();

            dgvList.AutoGenerateColumns = false;
            //this.GetPreference();
            Common.ComboBox.FillView(ref this.cboView);

            BindList();

            Cursor.Current = Cursors.Default;
        }

        #region Set/ Get Preference
        private void GetPreference()
        {
            // Restore state data
            try
            {
                // Restore the columns' state

                StringCollection cols = Properties.Settings.Default.Inventory_GoodsReceive_Default_dgvList;
                for (int i = 0; i < cols.Count; ++i)
                {
                    string[] array = cols[i].Split(',');
                    this.dgvList.Columns[i].DisplayIndex = Int16.Parse(array[0]);
                    this.dgvList.Columns[i].Width = Int16.Parse(array[1]);
                    this.dgvList.Columns[i].Visible = bool.Parse(array[2]);
                }
            }
            catch (NullReferenceException)
            {
                // This happens when settings values are empty
            }
        }

        private void SetPreference()
        {
            // Save column state data
            // including order, column width and whether or not the column is visible

            StringCollection stringCollection = new StringCollection();
            foreach (DataGridViewColumn column in this.dgvList.Columns)
            {
                stringCollection.Add(string.Format(
                    "{0},{1},{2}",
                    column.DisplayIndex,
                    column.Width,
                    column.Visible));
            }
            Properties.Settings.Default.Inventory_GoodsReceive_Default_dgvList = stringCollection;

            // Save the data
            Properties.Settings.Default.Save();
        }
        #endregion

        #region Binding List
        private void BindList()
        {
            string sql = @"SELECT *,
            (CASE [Status] WHEN 0 THEN 'HOLD' ELSE 'POST' END) AS TxStatus
            FROM vwDraftCAPList";
            string whereClause = BuildSQLQuery();

            if (whereClause.Length > 0)
            {
                sql += " WHERE " + whereClause + " AND TxType = '" + RT2020.DAL.Common.Enums.TxType.CAP.ToString() + "'";
            }
            else
            {
                sql += " WHERE TxType = '" + RT2020.DAL.Common.Enums.TxType.CAP.ToString() + "'";
            }

            sql += " ORDER BY TxNumber, TxDate";

            DataSet ds = SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql);

            if (ds.Tables.Count > 0)
            {
                ds.Tables[0].Columns.Add("LN");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    ds.Tables[0].Rows[i]["LN"] = Convert.ToString(i + 1);
                }

                dgvList.DataSource = ds.Tables[0];
            }

            this.dgvList.ClearSelection();
        }

        #endregion

        #region FillComboBox
        private void FillcboCreateBy()
        {
            string[] orderBy = new string[] { "StaffNumber" };
            RT2020.DAL.StaffCollection staffCol = RT2020.DAL.Staff.LoadCollection(orderBy, true);
            staffCol.Add(new RT2020.DAL.Staff());
            cboCreateBy.Items.Clear();
            cboCreateBy.DataSource = staffCol;
            cboCreateBy.DisplayMember = "StaffNumber";
            cboCreateBy.ValueMember = "StaffId";

            if (DAL.Common.Config.CurrentUserId != Guid.Empty)
            {
                cboCreateBy.SelectedValue = DAL.Common.Config.CurrentUserId;
            }
            else
            {
                cboCreateBy.SelectedIndex = cboCreateBy.Items.Count - 1;
            }
        }
        #endregion

        #region ShowWizard
        private void ShowWizard(Guid ledgerHeaderId)
        {
            Wizard oWizard = new Wizard();
            oWizard.CAPHeaderId = ledgerHeaderId;
            oWizard.EditMode = ledgerHeaderId == Guid.Empty ? Mode.New : Mode.Edit;
            oWizard.Closed += new EventHandler(oWizard_Closed);
            oWizard.ShowDialog();
        }
        #endregion

        #region Build SQL Query
        private string BuildSQLQuery()
        {
            string WhereClause = string.Empty;

            if (cboCreateBy.SelectedValue != null && !cboCreateBy.SelectedValue.ToString().Equals(System.Guid.Empty.ToString()))
            {
                WhereClause = WhereClause + " CreatedBy = '" + cboCreateBy.SelectedValue.ToString() + "'";
            }

            if (cboView.Text.Length > 0 || cboView.Text.ToLower() != "all")
            {

                string StartDate = string.Empty;
                switch (cboView.SelectedIndex)
                {
                    case 0:
                        StartDate = DateTime.Now.AddDays(-7).ToString("yyyy-MM-dd");
                        break;
                    case 1:
                        StartDate = DateTime.Now.AddDays(-14).ToString("yyyy-MM-dd");
                        break;
                    case 2:
                        StartDate = DateTime.Now.AddDays(-30).ToString("yyyy-MM-dd");
                        break;
                    case 3:
                        StartDate = DateTime.Now.AddDays(-60).ToString("yyyy-MM-dd");
                        break;
                    case 4:
                        StartDate = DateTime.Now.AddDays(-90).ToString("yyyy-MM-dd");
                        break;
                    case 5:
                    default:
                        StartDate = string.Empty;
                        break;
                }

                if (WhereClause.Length > 0 && StartDate.Trim().Length > 0)
                {
                    WhereClause = WhereClause + " AND ";
                }

                if (!string.IsNullOrEmpty(StartDate))
                {
                    WhereClause = WhereClause + " CreatedOn BETWEEN '" + StartDate + " 00:00:00' AND '" + DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59'";
                }
            }

            if (txtLookup.Text.Trim().Length > 0)
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause = WhereClause + " AND ";
                }

                WhereClause = WhereClause + " TxNumber like '%" + txtLookup.Text.Trim() + "%'";
            }

            return WhereClause;
        }
        #endregion

        private void ansAddNew_Click(object sender, EventArgs e)
        {
            ShowWizard(System.Guid.Empty);
        }

        void oWizard_Closed(object sender, EventArgs e)
        {
            txtLookup.Text = "";
            cboCreateBy.SelectedValue = System.Guid.Empty;
            cboView.SelectedIndex = cboView.Items.Count - 1;
            BindList();
        }

        private void Default_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.SetPreference();
        }

        private void ansRefresh_Click(object sender, EventArgs e)
        {
            txtLookup.Text = "";
            cboCreateBy.SelectedValue = System.Guid.Empty;
            cboView.SelectedIndex = cboView.Items.Count - 1;
            BindList();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Cursor.Current = Cursors.WaitCursor;

                System.Guid ledgerHeaderId = new System.Guid(dgvList.Rows[e.RowIndex].Cells["colHeaderId"].Value.ToString());
                ShowWizard(ledgerHeaderId);
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            BindList();
        }
    }
}
