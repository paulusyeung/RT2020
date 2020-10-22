#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using System.Windows.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Collections.Specialized;
using RT2020.Client.Common;
using System.Threading;

#endregion

namespace RT2020.Client.Products 
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

            //BindList();
            SetSystemLabels();

            Cursor.Current = Cursors.Default;
        }

        #region Set System label
        private void SetSystemLabels()
        {
            colProductCode.HeaderText = Utility.GetSystemLabelByKey("STKCODE");
            colAPPENDIX1.HeaderText = Utility.GetSystemLabelByKey("APPENDIX1");
            colAPPENDIX2.HeaderText = Utility.GetSystemLabelByKey("APPENDIX2");
            colAPPENDIX3.HeaderText = Utility.GetSystemLabelByKey("APPENDIX3");
        }
        #endregion

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
        private void ShowWizard(Guid productId)
        {
            Cursor.Current = Cursors.WaitCursor;
            Wizard.ProductWizard oWizard = new Wizard.ProductWizard(productId);
            oWizard.EditMode = productId == Guid.Empty ? Mode.New : Mode.Edit;
            oWizard.Closed += new EventHandler(oWizard_Closed);
            oWizard.ShowDialog();
        }
        #endregion

        #region Binding List
        private void BindList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT ProductId, (STKCODE + ' ' + APPENDIX1 + ' ' + APPENDIX2 + ' ' + APPENDIX3) AS ProductCode, ");
            sql.Append(" STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, ProductName, ProductName_Chs, ");
            sql.Append(" ProductName_Cht, Nature, UOM, ");
            sql.Append(" Remarks, CreatedOn, ModifiedOn, CreatedBy, ModifiedBy ");
            sql.Append(" FROM vwProductList ");
            string whereClause = BuildSQLQuery();

            if (whereClause.Length > 0)
            {
                sql.AppendFormat(" WHERE {0} ", whereClause);
            }

            sql.Append(" ORDER BY STKCODE, APPENDIX1, APPENDIX2, APPENDIX3 ");

            DataSet ds = SqlHelper.Default.ExecuteDataSet(CommandType.Text, sql.ToString());

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

        #region Build SQL Query
        private string BuildSQLQuery()
        {
            StringBuilder WhereClause = new StringBuilder();

            if (cboCreateBy.SelectedValue != null && !cboCreateBy.SelectedValue.ToString().Equals(System.Guid.Empty.ToString()))
            {
                WhereClause.AppendFormat(" CreatedBy = '{0}'", cboCreateBy.SelectedValue.ToString());
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
                    WhereClause.Append(" AND ");
                }

                if (!string.IsNullOrEmpty(StartDate))
                {
                    WhereClause.AppendFormat(" CreatedOn BETWEEN '{0} 00:00:00' AND '{1} 23:59:59'", StartDate, DateTime.Now.ToString("yyyy-MM-dd"));
                }
            }

            if (txtLookup.Text.Trim().Length > 0)
            {
                if (WhereClause.Length > 0)
                {
                    WhereClause.Append(" AND ");
                }

                WhereClause.AppendFormat(" ((STKCODE + APPENDIX1 + APPENDIX2 + APPENDIX3) LIKE '%{0}%'", txtLookup.Text.Trim());
                WhereClause.AppendFormat(" OR ProductName LIKE '%{0}%')", txtLookup.Text.Trim());
            }

            return WhereClause.ToString();
        }
        #endregion

        private void ansAddNew_Click(object sender, EventArgs e)
        {
            ShowWizard(System.Guid.Empty);
        }

        void oWizard_Closed(object sender, EventArgs e)
        {
            //txtLookup.Text = "";
            //cboCreateBy.SelectedValue = System.Guid.Empty;
            //cboView.SelectedIndex = cboView.Items.Count - 1;
            //BindList();
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

            this.BindList();
        }

        private void dgvList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                System.Guid productId = new System.Guid(dgvList.Rows[e.RowIndex].Cells["colProductId"].Value.ToString());
                ShowWizard(productId);
            }
        }

        private void cmdLookup_Click(object sender, EventArgs e)
        {
            this.BindList();
        }
    }
}