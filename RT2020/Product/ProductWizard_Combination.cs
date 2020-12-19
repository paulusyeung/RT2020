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

using RT2020.Helper;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Combination : Form
    {
        public ProductWizard_Combination()
        {
            InitializeComponent();
            FillComboList();
            SetToolBar();
            SetCtrlEditable();
            SetFormLayoutWithType();
            LoadCombinationList();
        }

        public ProductWizard_Combination(FormLayoutType type)
        {
            InitializeComponent();
            this.FormType = type;
            FillComboList();
            SetToolBar();
            SetCtrlEditable();
            SetFormLayoutWithType();
            LoadCombinationList();
        }

        public ProductWizard_Combination(Guid combinId)
        {
            InitializeComponent();
            this.CombinId = combinId;
            InitialFormWithType();
            FillComboList();
            SetToolBar();
            SetCtrlEditable();
            SetFormLayoutWithType();
            LoadCombinationList();
        }

        #region ToolBar

        private void SetCtrlEditable()
        {
            txtCombinNumber.BackColor = (this.CombinId == System.Guid.Empty) ? Color.LightSkyBlue : Color.LightYellow;
            txtCombinNumber.ReadOnly = (this.CombinId != System.Guid.Empty);

            dgvCombinationList.AutoGenerateColumns = false;

            lblAppendix1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
            lblAppendix2.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
            lblAppendix3.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");

            this.Text = string.Format("Combination Wizard [{0}]", RT2020.SystemInfo.Settings.GetSystemLabelByKey(this.FormType.ToString().ToUpper()));
        }

        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdNew
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
            ToolBarButton cmdSaveNew = new ToolBarButton("Refresh", "Refresh");
            cmdSaveNew.Tag = "refresh";
            cmdSaveNew.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdSaveNew);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", "Delete");
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (CombinId == System.Guid.Empty)
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
                        this.Update();
                        break;
                    case "save":
                        if (IsValid())
                        {
                            Save();
                            LoadCombinationList();
                            SetCtrlEditable();
                            this.Update();
                            if (this.CombinId != System.Guid.Empty)
                            {
                                MessageBox.Show("Save Successful");
                            }
                        }
                        break;
                    case "refresh":
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion
        
        #region Fill Combo List
        private void FillComboList()
        {
            FillAppendixes();
        }

        #region Appendix
        private void FillAppendixes()
        {
            FillAppendixe1();
            FillAppendixe2();
            FillAppendixe3();
        }

        private void FillAppendixe1()
        {
            string[] orderBy = new string[] { "Appendix1Code" };
            ModelEx.ProductAppendix1Ex.LoadCombo(ref cboAppendix1, "Appendix1Code", false, true, "", "", orderBy);
            /**
            cboAppendix1.Items.Clear();

            string[] orderBy = new string[] { "Appendix1Code"};
            ProductAppendix1Collection oA1List = ProductAppendix1.LoadCollection(orderBy, true);
            oA1List.Add(new ProductAppendix1());
            cboAppendix1.DataSource = oA1List;
            cboAppendix1.DisplayMember = "Appendix1Code";
            cboAppendix1.ValueMember = "Appendix1Id";
            */
            cboAppendix1.SelectedIndex = cboAppendix1.Items.Count - 1;
        } 

        private void FillAppendixe2()
        {
            string[] orderBy = new string[] { "Appendix2Code" };
            ModelEx.ProductAppendix2Ex.LoadCombo(ref cboAppendix2, "Appendix2Code", false, true, "", "", orderBy);
            /**
            cboAppendix2.Items.Clear();

            string[] orderBy = new string[] { "Appendix2Code" };
            ProductAppendix2Collection oA2List = ProductAppendix2.LoadCollection(orderBy, true);
            oA2List.Add(new ProductAppendix2());
            cboAppendix2.DataSource = oA2List;
            cboAppendix2.DisplayMember = "Appendix2Code";
            cboAppendix2.ValueMember = "Appendix2Id";
            */
            cboAppendix2.SelectedIndex = cboAppendix2.Items.Count - 1;
        }

        private void FillAppendixe3()
        {
            string[] orderBy = new string[] { "Appendix3Code" };
            ModelEx.ProductAppendix3Ex.LoadCombo(ref cboAppendix3, "Appendix3Code", false, true, "", "", orderBy);
            /**
            cboAppendix3.Items.Clear();

            string[] orderBy = new string[] { "Appendix3Code" };
            ProductAppendix3Collection oA3List = ProductAppendix3.LoadCollection(orderBy, true);
            oA3List.Add(new ProductAppendix3());
            cboAppendix3.DataSource = oA3List;
            cboAppendix3.DisplayMember = "Appendix3Code";
            cboAppendix3.ValueMember = "Appendix3Id";
            */
            cboAppendix3.SelectedIndex = cboAppendix3.Items.Count - 1;
        }
        #endregion

        #endregion

        #region Set Form Layout with type
        private void InitialFormWithType()
        {
            var detailList = ModelEx.ProductDim_DetailsEx.GetListByDimensionId(this.CombinId);
            foreach (var detail in detailList)
            {
                if (detail.APPENDIX1.Length > 0 && detail.APPENDIX2.Length == 0 && detail.APPENDIX3.Length == 0)
                {
                    this.FormType = FormLayoutType.Appendix1;
                }
                else if (detail.APPENDIX1.Length == 0 && detail.APPENDIX2.Length > 0 && detail.APPENDIX3.Length == 0)
                {
                    this.FormType = FormLayoutType.Appendix2;
                }
                else if (detail.APPENDIX1.Length == 0 && detail.APPENDIX2.Length == 0 && detail.APPENDIX3.Length > 0)
                {
                    this.FormType = FormLayoutType.Appendix3;
                }
                else
                {
                    this.FormType = FormLayoutType.All;
                }
            }
        }

        private void SetFormLayoutWithType()
        {
            switch (this.FormType)
            {
                case FormLayoutType.All:
                    VisibleCtrl(true, true, true);
                    VisibleGridColumn(true, true, true);
                    break;
                case FormLayoutType.Appendix1:
                    VisibleCtrl(true, false, false);
                    VisibleGridColumn(true, false, false);
                    break;
                case FormLayoutType.Appendix2:
                    VisibleCtrl(false, true, false);
                    VisibleGridColumn(false, true, false);
                    break;
                case FormLayoutType.Appendix3:
                    VisibleCtrl(false, false, true);
                    VisibleGridColumn(false, false, true);
                    break;
            }
        }

        private void VisibleCtrl(bool a1, bool a2, bool a3)
        {
            lblAppendix1.Visible = a1;
            cboAppendix1.Visible = a1;

            lblAppendix2.Visible = a2;
            cboAppendix2.Visible = a2;

            if (!a1)
            {
                lblAppendix2.Location = lblAppendix1.Location;
                cboAppendix2.Location = cboAppendix1.Location;
            }

            lblAppendix3.Visible = a3;
            cboAppendix3.Visible = a3;

            if (!a1)
            {
                lblAppendix3.Location = lblAppendix1.Location;
                cboAppendix3.Location = cboAppendix1.Location;
            }
        }

        private void VisibleGridColumn(bool a1, bool a2, bool a3)
        {
            DataGridViewTextBoxColumn colId = new DataGridViewTextBoxColumn();
            colId.DataPropertyName = "DimDetailId";
            colId.Width = 50;
            colId.Visible = false;

            dgvCombinationList.Columns.Add(colId);

            DataGridViewTextBoxColumn colRow = new DataGridViewTextBoxColumn();
            colRow.Name = "Row";
            colRow.DataPropertyName = "rownum";
            colRow.Width = 50;

            dgvCombinationList.Columns.Add(colRow);

            if (a1)
            {
                DataGridViewTextBoxColumn colA1 = new DataGridViewTextBoxColumn();
                colA1.Name = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX1");
                colA1.DataPropertyName = "Appendix1";

                dgvCombinationList.Columns.Add(colA1);
            }

            if (a2)
            {
                DataGridViewTextBoxColumn colA2 = new DataGridViewTextBoxColumn();
                colA2.Name = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX2");
                colA2.DataPropertyName = "Appendix2";

                dgvCombinationList.Columns.Add(colA2);
            }

            if (a3)
            {
                DataGridViewTextBoxColumn colA3 = new DataGridViewTextBoxColumn();
                colA3.Name = RT2020.SystemInfo.Settings.GetSystemLabelByKey("APPENDIX3");
                colA3.DataPropertyName = "Appendix3";

                dgvCombinationList.Columns.Add(colA3);
            }
        }
        #endregion

        #region Properties
        private FormLayoutType formType = FormLayoutType.All;
        public FormLayoutType FormType
        {
            get
            {
                return formType;
            }
            set
            {
                formType = value;
            }
        }

        public enum FormLayoutType { Appendix1 = 1, Appendix2, Appendix3, All = 0 }

        private Guid combinId = System.Guid.Empty;
        public Guid CombinId
        {
            get
            {
                return combinId;
            }
            set
            {
                combinId = value;
            }
        }
        #endregion

        #region Save Methods
        private bool IsValid()
        {
            bool result = true;

            if (txtCombinNumber.Text.Length == 0)
            {
                errorProvider.SetError(txtCombinNumber, "Can not be blank!");
                result = false;
            }
            else
            {
                errorProvider.SetError(txtCombinNumber, string.Empty);
            }

            return result;
        }

        private void Save()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var oDim = ctx.ProductDim.Find(this.CombinId);
                        if (oDim == null)
                        {
                            #region new ProductDim
                            oDim = new EF6.ProductDim();
                            oDim.DimensionId = Guid.NewGuid();
                            oDim.DimCode = txtCombinNumber.Text;

                            switch (this.FormType)
                            {
                                case FormLayoutType.Appendix1:
                                    oDim.DimType = "A1";
                                    break;
                                case FormLayoutType.Appendix2:
                                    oDim.DimType = "A2";
                                    break;
                                case FormLayoutType.Appendix3:
                                    oDim.DimType = "A3";
                                    break;
                                case FormLayoutType.All:
                                default:
                                    oDim.DimType = "";
                                    break;
                            }

                            oDim.CreatedBy = ConfigHelper.CurrentUserId;
                            oDim.CreatedOn = DateTime.Now;

                            ctx.ProductDim.Add(oDim);
                            #endregion
                        }
                        oDim.ModifiedBy = ConfigHelper.CurrentUserId;
                        oDim.ModifiedOn = DateTime.Now;

                        ctx.SaveChanges();
                        this.CombinId = oDim.DimensionId;

                        #region SaveDetails(oDim.DimensionId);
                        var dimensionId = oDim.DimensionId;
                        DataTable oTable = null;
                        if (dgvCombinationList.DataSource != null)
                        {
                            oTable = dgvCombinationList.DataSource as DataTable;

                            ModelEx.ProductDim_DetailsEx.DeleteByDimensionId(dimensionId);
                            foreach (DataRow row in oTable.Rows)
                            {
                                var oDetail = ctx.ProductDim_Details.Find(row["DimDetailId"]);
                                if (oDetail == null)
                                {
                                    oDetail = new EF6.ProductDim_Details();
                                    oDetail.DimDetailId = Guid.NewGuid();
                                    oDetail.DimensionId = dimensionId;

                                    ctx.ProductDim_Details.Add(oDetail);
                                }
                                oDetail.APPENDIX1 = row["Appendix1"].ToString();
                                oDetail.APPENDIX2 = row["Appendix2"].ToString();
                                oDetail.APPENDIX3 = row["Appendix3"].ToString();

                                ctx.SaveChanges();
                            }
                        }
                        #endregion

                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            if (this.CombinId != Guid.Empty)
            {
                RT2020.SystemInfo.Settings.RefreshMainList<DefaultCombinList>();
            }
        }

        private void Clear()
        {
            this.Close();

            ProductWizard_Combination wizCombin = new ProductWizard_Combination(this.FormType);
            wizCombin.ShowDialog();
        }
        #endregion

        #region Load Methods
        private void LoadCombinationList()
        {
            txtCombinNumber.Text = ModelEx.ProductDimEx.GetDimCode(this.CombinId);
            BindAppendixList();
        }

        #region Bind Appendix List
        private DataTable GenDataTable()
        {
            DataTable oTable = new DataTable();
            oTable.Columns.Add(new DataColumn("DimDetailId", typeof(Guid)));
            oTable.Columns.Add(new DataColumn("rownum", typeof(String)));
            oTable.Columns.Add(new DataColumn("Appendix1", typeof(String)));
            oTable.Columns.Add(new DataColumn("Appendix2", typeof(String)));
            oTable.Columns.Add(new DataColumn("Appendix3", typeof(String)));
            return oTable;
        }

        private void BindAppendixList()
        {
            string sql = @"
SELECT  DimDetailId, ROW_NUMBER() OVER (ORDER BY DimCode) AS rownum, Appendix1, Appendix2, Appendix3
FROM    vwDimensionList 
Where   DimensionId = '" + this.CombinId.ToString() + "'";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                DataTable oTable = GenDataTable();
                oTable = dataset.Tables[0].Copy();

                dgvCombinationList.DataSource = oTable;
            }
        }

        private void AddRowsToGrid(string rownum, string appendix1, string appendix2, string appendix3)
        {
            DataTable oTable = null;
            if (dgvCombinationList.DataSource != null)
            {
                oTable = dgvCombinationList.DataSource as DataTable;

                DataRow row = oTable.NewRow();

                row["DimDetailId"] = System.Guid.Empty;
                row["rownum"] = rownum;
                row["Appendix1"] = appendix1;
                row["Appendix2"] = appendix2;
                row["Appendix3"] = appendix3;

                oTable.Rows.Add(row);
            }
            else
            {
                oTable = GenDataTable();

                DataRow row = oTable.NewRow();

                row["DimDetailId"] = System.Guid.Empty;
                row["rownum"] = rownum;
                row["Appendix1"] = appendix1;
                row["Appendix2"] = appendix2;
                row["Appendix3"] = appendix3;

                oTable.Rows.Add(row);
            }

            if (oTable != null)
            {
                dgvCombinationList.DataSource = oTable;
            }
        }
        #endregion

        #endregion

        #region Grid Row Operation
        private void DeleteRow(string rownum)
        {
            DataTable oTable = null;
            if (dgvCombinationList.DataSource != null)
            {
                oTable = dgvCombinationList.DataSource as DataTable;

                DeleteRow(ref oTable, rownum);

                if (string.IsNullOrEmpty(rownum))
                {
                    oTable.Rows.Clear();
                }
            }

            if (oTable != null)
            {
                ResetRowNumber(ref oTable);
                dgvCombinationList.DataSource = oTable;
            }
        }

        private void DeleteRow(ref DataTable oTable, string rownum)
        {
            for (int i = 1; i <= oTable.Rows.Count; i++)
            {
                DataRow row = oTable.Rows[i - 1];

                if (row["rownum"].ToString().Length > 0 && row["rownum"].ToString() == rownum)
                {
                    oTable.Rows.Remove(row);
                }
            }
        }

        private void ResetRowNumber(ref DataTable oTable)
        {
            int iCount = 1;
            foreach (DataRow row in oTable.Rows)
            {
                row.BeginEdit();
                row["rownum"] = iCount.ToString();
                row.AcceptChanges();
                row.EndEdit();

                iCount++;
            }
        }
        #endregion

        #region Delete Methods

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                ModelEx.ProductDimEx.Delete(this.CombinId);

                this.Close();
            }
        }
        #endregion

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (IsDetailRecordValid())
            {
                AddDetails();
            }
            else
            {
                MessageBox.Show("Duplicate record!");
            }
        }

        private bool IsDetailRecordValid()
        {
            bool result = true;

            DataTable oTable = null;
            if (dgvCombinationList.DataSource != null)
            {
                oTable = dgvCombinationList.DataSource as DataTable;

                foreach (DataRow row in oTable.Rows)
                {
                    if ((row["Appendix1"].ToString() == cboAppendix1.Text) &&
                        row["Appendix2"].ToString() == cboAppendix2.Text &&
                        row["Appendix3"].ToString() == cboAppendix3.Text)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }

        private void AddDetails()
        {
            string appendix1 = string.Empty, appendix2 = string.Empty, appendix3 = string.Empty;

            if (!cboAppendix1.SelectedValue.Equals(System.Guid.Empty))
            {
                appendix1 = cboAppendix1.Text;
            }
            else
            {
                if (cboAppendix1.Visible)
                {
                    MessageBox.Show("Must select a value of season!");
                }
            }

            if (!cboAppendix2.SelectedValue.Equals(System.Guid.Empty))
            {
                appendix2 = cboAppendix2.Text;
            }

            if (!cboAppendix3.SelectedValue.Equals(System.Guid.Empty))
            {
                appendix3 = cboAppendix3.Text;
            }

            if (!string.IsNullOrEmpty(appendix1))
            {
                AddRowsToGrid((dgvCombinationList.Rows.Count + 1).ToString(), appendix1, appendix2, appendix3);
            }
            else if (!cboAppendix1.Visible)
            {
                AddRowsToGrid((dgvCombinationList.Rows.Count + 1).ToString(), appendix1, appendix2, appendix3);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DeleteRow(string.Empty);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            errorProvider.SetError(txtRowNum, string.Empty);
            if (!string.IsNullOrEmpty(txtRowNum.Text))
            {
                DeleteRow(txtRowNum.Text);
            }
            else
            {
                errorProvider.SetError(txtRowNum, "Please input a row number to delete!");
            }
        }

        private void dgvCombinationList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtRowNum.Text = (e.RowIndex + 1).ToString();
        }
    }
}