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
using System.Configuration;

#endregion

namespace RT2020.Client.Products.Wizard
{
    public partial class ProductNatureWizard : Form
    {
        public ProductNatureWizard()
        {
            InitializeComponent();
            FillParentNatureList();
            BindProductNatureList();
            SetCtrlEditable();
        }

        #region ProductNature Code
        private void SetCtrlEditable()
        {
            txtProductNatureCode.BackColor = (this.ProductNatureId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtProductNatureCode.ReadOnly = (this.ProductNatureId != System.Guid.Empty);
        }
        #endregion

        #region Fill Combo List
        private void FillParentNatureList()
        {
            string sql = "NatureId NOT IN ('" + this.ProductNatureId.ToString() + "')";
            string[] orderBy = new string[] { "NatureCode" };
            ProductNatureCollection oProductNatureList = ProductNature.LoadCollection(sql, orderBy, true);
            oProductNatureList.Add(new ProductNature());
            cboParentNature.DataSource = oProductNatureList;
            cboParentNature.DisplayMember = "NatureCode";
            cboParentNature.ValueMember = "NatureId";

            cboParentNature.SelectedIndex = cboParentNature.Items.Count - 1;
        }
        #endregion

        #region Binding
        private void BindProductNatureList()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("SELECT NatureId,  ROW_NUMBER() OVER (ORDER BY NatureCode) AS rownum, ");
            sql.Append(" NatureCode, NatureName, NatureName_Chs, NatureName_Cht ");
            sql.Append(" FROM ProductNature ");
            sql.Append(" ORDER BY NatureCode ");
            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql.ToString();
            cmd.CommandTimeout = DAL.Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd);

            this.lvProductNatureList.DataSource = ds.Tables[0];
        }
        #endregion

        #region Save
        private bool CodeExists()
        {
            string sql = "NatureCode = '" + txtProductNatureCode.Text.Trim() + "'";
            ProductNatureCollection natureList = ProductNature.LoadCollection(sql);
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
            if (txtProductNatureCode.Text.Length == 0)
            {
                errorProvider.SetError(txtProductNatureCode, "Cannot be blank!");
                return false;
            }
            else
            {
                ProductNature oProductNature = ProductNature.Load(this.ProductNatureId);
                if (oProductNature == null)
                {
                    oProductNature = new ProductNature();

                    if (CodeExists())
                    {
                        errorProvider.SetError(txtProductNatureCode, "Duplicated Product Nature Code!");
                        return false;
                    }
                    else
                    {
                        oProductNature.NatureCode = txtProductNatureCode.Text;
                        errorProvider.SetError(txtProductNatureCode, string.Empty);
                    }
                }
                oProductNature.NatureName = txtProductNatureName.Text;
                oProductNature.NatureName_Chs = txtProductNatureNameChs.Text;
                oProductNature.NatureName_Cht = txtProductNatureNameCht.Text;
                oProductNature.ParentNature = (cboParentNature.SelectedValue == null)? System.Guid.Empty:new System.Guid(cboParentNature.SelectedValue.ToString());

                oProductNature.Save();
                return true;
            }
        }

        private void Clear()
        {
            this.Close();

            ProductNatureWizard wizNature = new ProductNatureWizard();
            wizNature.ShowDialog();
        }
        #endregion

        #region Properties
        private Guid countryId = System.Guid.Empty;
        public Guid ProductNatureId
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

        #region Delete
        private void Delete()
        {
            ProductNature oNature = ProductNature.Load(this.ProductNatureId);
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
        #endregion

        void lvProductNatureList_CellClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            DataGridViewRow natureIdRow = lvProductNatureList.Rows[e.RowIndex];
            if (DAL.Common.Utility.IsGUID(natureIdRow.Cells["colProductNatureId"].Value.ToString()))
            {
                ProductNature oProductNature = ProductNature.Load(new System.Guid(natureIdRow.Cells["colProductNatureId"].Value.ToString()));
                if (oProductNature != null)
                {
                    this.ProductNatureId = oProductNature.NatureId;

                    FillParentNatureList();

                    txtProductNatureCode.Text = oProductNature.NatureCode;
                    txtProductNatureName.Text = oProductNature.NatureName;
                    txtProductNatureNameChs.Text = oProductNature.NatureName_Chs;
                    txtProductNatureNameCht.Text = oProductNature.NatureName_Cht;
                    cboParentNature.SelectedValue = oProductNature.ParentNature;

                    SetCtrlEditable();
                }
            }
        }

        private void cmdNew_Click(object sender, EventArgs e)
        {
            Clear();
            SetCtrlEditable();
        }

        private void cmdSave_Click(object sender, EventArgs e)
        {
            if (Save())
            {
                Clear();
                BindProductNatureList();
                this.Update();
            }
        }

        private void cmdRefresh_Click(object sender, EventArgs e)
        {
            BindProductNatureList();
            this.Update();
        }

        private void cmdDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Delete();
                Clear();
            }
        }
    }
}