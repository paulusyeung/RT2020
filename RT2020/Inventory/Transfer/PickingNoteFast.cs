#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using DevExpress.Web;
using Gizmox.WebGUI.Common.Resources;
using System.Linq;
using RT2020.Helper;

#endregion

namespace RT2020.Inventory.Transfer
{
    public partial class PickingNoteFast : Form
    {
        private WorkplaceList wpList = new WorkplaceList();
        private String _Selected = System.Web.HttpUtility.HtmlDecode("&#9745;");        //System.Web.HttpUtility.HtmlDecode("&#10004;");
        private String _NotSelected = System.Web.HttpUtility.HtmlDecode("&#9744;");     //String.Empty;

        public PickingNoteFast()
        {
            InitializeComponent();

            FillCboList();
            FillWorkplaceList(cboFromLocation.SelectedValue == null ? System.Guid.Empty : new System.Guid(cboFromLocation.SelectedValue.ToString()));
            BindWorkplaceList();

            dgvToLocation.RowHeadersVisible = false;
            dataGridViewTextBoxColumn2.Width = 50;

            dtpTxDate.Value = Convert.ToDateTime(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-" + DateTime.Now.ToString("dd")));
            dtpTxferDate.Value = Convert.ToDateTime(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-" + DateTime.Now.ToString("dd")));
            dtpCompDate.Value = Convert.ToDateTime(RT2020.SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-" + DateTime.Now.ToString("dd")));
        }

        #region Fill Combo List
        private void FillCboList()
        {
            FillFromLocationList();
            FillStaffList();
        }

        private void FillFromLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboFromLocation, "WorkplaceCode", false);
        }

        private void FillStaffList()
        {
            ModelEx.StaffEx.LoadCombo(ref cboOperatorCode, "StaffNumber", false);

            cboOperatorCode.SelectedValue = ConfigHelper.CurrentUserId;
        }

        #endregion

        #region Bind Zone List
        private void BindWorkplaceList()
        {
            dgvToLocation.AutoGenerateColumns = false;

            dataGridViewTextBoxColumn4.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewTextBoxColumn4.DefaultCellStyle.BackColor = Color.LightSkyBlue;

            dgvToLocation.DataSource = wpList;
        }

        private void FillWorkplaceList(Guid workplaceId)
        {
            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.Workplace
                    .SqlQuery(String.Format("Select * from Workplace Where WorkplaceId NOT IN ('{0}') Order By WorkplaceCode", workplaceId.ToString()))
                    .AsNoTracking()
                    .ToList();

                //string sql = "WorkplaceId NOT IN ('" + workplaceId.ToString() + "')";
                //string[] orderBy = new string[] { "WorkplaceCode" };
                //WorkplaceCollection oWpList = RT2020.DAL.Workplace.LoadCollection(sql, orderBy, true);
                for (int i = 0; i < list.Count; i++)
                {
                    WorkplaceRec wkpl = new WorkplaceRec(list[i].WorkplaceId, i + 1, list[i].WorkplaceCode, _NotSelected, 1, "");
                    wpList.Add(wkpl);
                }
            }
        }

        #region DataGrid Binding Class
        public class WorkplaceRec
        {
            Guid wpId = System.Guid.Empty;
            int rownum = 1;
            string wpCode = string.Empty;
            string selStatus = string.Empty;
            int numberOfPN = 1;
            string resultOfAct = string.Empty;

            public WorkplaceRec(Guid wId, int rnum, string wCode, string s, int pnq, string result)
            {
                wpId = wId;
                rownum = rnum;
                wpCode = wCode;
                selStatus = s;
                numberOfPN = pnq;
                resultOfAct = result;
            }

            public Guid ZoneId
            {
                get { return wpId; }
                set { wpId = value; }
            }

            public int RowNum
            {
                get { return rownum; }
                set { rownum = value; }
            }

            public string Shop
            {
                get { return wpCode; }
                set { wpCode = value; }
            }

            public string SelStatus
            {
                get { return selStatus; }
                set { selStatus = value; }
            }

            public int NumberOfPN
            {
                get { return numberOfPN; }
                set { numberOfPN = value; }
            }

            public string Result
            {
                get { return resultOfAct; }
                set { resultOfAct = value; }
            }
        }

        public class WorkplaceList : BindingList<WorkplaceRec>
        {
        }
        #endregion
        #endregion

        #region Generate Picking Note
        private bool VerifySelection()
        {
            bool verified = false;
            for (int i = 0; i < dgvToLocation.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)(dgvToLocation.Rows[i].Cells[colStatus.Name]);
                verified = (chkCell.Value != null) ? Convert.ToBoolean(chkCell.Value.ToString()) : false;
                if (verified)
                {
                    return verified;
                }
            }
            return verified;
        }

        private int Generate()
        {
            if (VerifySelection())
            {
                int iCount = 0;
                using (var ctx = new EF6.RT2020Entities())
                {
                    for (int i = 0; i < dgvToLocation.Rows.Count; i++)
                    {
                        DataGridViewCheckBoxCell chkCell = (DataGridViewCheckBoxCell)(dgvToLocation.Rows[i].Cells[colStatus.Name]);
                        bool verified = (chkCell.Value != null) ? Convert.ToBoolean(chkCell.Value.ToString()) : false;
                        if (verified)
                        {
                            DataGridViewTextBoxCell idCell = (DataGridViewTextBoxCell)(dgvToLocation.Rows[i].Cells[dataGridViewTextBoxColumn1.Name]);
                            Guid id = Guid.Empty;
                            if (Guid.TryParse(idCell.Value.ToString(), out id))
                            {
                                DataGridViewTextBoxCell pnqCell = (DataGridViewTextBoxCell)(dgvToLocation.Rows[i].Cells[dataGridViewTextBoxColumn4.Name]);
                                int pnq = pnqCell.Value == null ? 0 : Convert.ToInt32(pnqCell.Value.ToString());

                                #region InvtBatchTXF_Header header = GeneratePNQ(id, pnq);
                                Guid toLocation = id;
                                int pickingNumber = pnq;

                                var oHeader = new EF6.InvtBatchTXF_Header();
                                oHeader.HeaderId = Guid.NewGuid();
                                oHeader.TxNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(EnumHelper.TxType.PNQ);
                                oHeader.TxType = EnumHelper.TxType.PNQ.ToString();
                                oHeader.TxDate = dtpTxDate.Value;

                                oHeader.CreatedBy = ConfigHelper.CurrentUserId;
                                oHeader.CreatedOn = DateTime.Now;

                                oHeader.FromLocation = (Guid)cboFromLocation.SelectedValue; // new Guid(cboFromLocation.SelectedValue.ToString());
                                oHeader.ToLocation = toLocation;
                                oHeader.StaffId = (Guid)cboOperatorCode.SelectedValue;  // new Guid(cboOperatorCode.SelectedValue.ToString());
                                oHeader.TransferredOn = dtpTxferDate.Value;
                                oHeader.CompletedOn = dtpCompDate.Value;
                                oHeader.Remarks = txtRemarks.Text;
                                oHeader.Picked = true;

                                oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
                                oHeader.ModifiedOn = DateTime.Now;

                                ctx.InvtBatchTXF_Header.Add(oHeader);
                                ctx.SaveChanges();
                                #endregion

                                dgvToLocation.Rows[i].Cells[dataGridViewTextBoxColumn5.Name].Value = oHeader.TxNumber;
                                //if (oHeader.HeaderId != Guid.Empty)
                                //{
                                //    dgvToLocation.Rows[i].Cells[dataGridViewTextBoxColumn5.Name].Value = header.TxNumber;

                                //    iCount++;
                                //}
                                iCount++;
                            }
                        }
                    }
                }
                return iCount;
            }
            else
            {
                return 0;
            }
        }
        /**
        private InvtBatchTXF_Header GeneratePNQ(Guid toLocation, int pickingNumber)
        {
            System.Guid headerId = System.Guid.Empty;
            InvtBatchTXF_Header oHeader = new InvtBatchTXF_Header();

            oHeader.TxNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(EnumHelper.TxType.PNQ);
            oHeader.TxType = EnumHelper.TxType.PNQ.ToString();
            oHeader.TxDate = dtpTxDate.Value;

            oHeader.CreatedBy = ConfigHelper.CurrentUserId;
            oHeader.CreatedOn = DateTime.Now;

            oHeader.FromLocation = new Guid(cboFromLocation.SelectedValue.ToString());
            oHeader.ToLocation = toLocation;
            oHeader.StaffId = new Guid(cboOperatorCode.SelectedValue.ToString());
            oHeader.TransferredOn = dtpTxferDate.Value;
            oHeader.CompletedOn = dtpCompDate.Value;
            oHeader.Remarks = txtRemarks.Text;
            oHeader.Picked = true;

            oHeader.ModifiedBy = ConfigHelper.CurrentUserId;
            oHeader.ModifiedOn = DateTime.Now;

            oHeader.Save();
            headerId = oHeader.HeaderId;

            //GeneratePickingDetail(headerId, oHeader.TxNumber, oHeader.TxType, pickingNumber);

            return oHeader;
        }

        private void GeneratePickingDetail(System.Guid headerId, string txNumber, string txType, int pickingNumber)
        {
            InvtBatchTXF_Details oDetail = new InvtBatchTXF_Details();
            oDetail.HeaderId = headerId;
            oDetail.LineNumber = 1;
            oDetail.TxNumber = txNumber;
            oDetail.TxType = txType;
            oDetail.QtyRequested = pickingNumber;
            oDetail.Remarks = "Picking Note";
            oDetail.Save();
        }
        */
        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnInfo_Click(object sender, EventArgs e)
        {
            StringBuilder msg = new StringBuilder();
            msg.Append("Instruction").Append("\n\r");
            msg.Append("\n\r");
            msg.Append("Column ``Number of PN``").Append("\n\r");
            msg.Append("=> Key in the needed Number of PN directly").Append("\n\r");
            msg.Append("=> Press <DELETE> to Reset Value (Default : 1)").Append("\n\r");
            msg.Append("=> Press <ESC> to Skip Editing").Append("\n\r");
            msg.Append("\n\r");

            MessageBox.Show(msg.ToString(), "Instruction");
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvToLocation.Rows.Count; i++)
            {
                dgvToLocation.Rows[i].Cells[colStatus.Index].Value = _Selected;
                dgvToLocation.Rows[i].Cells[colStatus.Index].Update();
            }
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvToLocation.Rows.Count; i++)
            {
                dgvToLocation.Rows[i].Cells[colStatus.Index].Value = _NotSelected;
                dgvToLocation.Rows[i].Cells[colStatus.Index].Update();
            }
        }

        private void dgvToLocation_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == colStatus.Index + 1) && (e.RowIndex >= 0) && (e.RowIndex < dgvToLocation.Rows.Count))
            {
                dgvToLocation.Rows[e.RowIndex].Cells[colStatus.Index].Value = _Selected;
                dgvToLocation.Rows[e.RowIndex].Cells[colStatus.Index].Update();
            }
        }

        private void dgvToLocation_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Enum.Parse(typeof(Keys), ((int)e.KeyChar).ToString()).Equals(Keys.Delete))
            {
                for (int i = 0; i < dgvToLocation.SelectedRows.Count; i++)
                {
                    DataGridViewTextBoxCell txtCell = (DataGridViewTextBoxCell)(dgvToLocation.SelectedRows[i].Cells[dataGridViewTextBoxColumn4.Name]);
                    txtCell.Value = "1";
                    dgvToLocation.SelectedRows[i].Cells[dataGridViewTextBoxColumn4.Name].Update();
                }
            }
        }

        private void dgvToLocation_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == colStatus.Index && e.RowIndex >= 0 && e.RowIndex < dgvToLocation.Rows.Count)
            {
                if (dgvToLocation.Rows[e.RowIndex].DataBoundItem != null)
                {
                    String select = (String)dgvToLocation.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                    if (select == _NotSelected)
                    {
                        dgvToLocation.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _Selected;
                    }
                    else
                    {
                        dgvToLocation.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = _NotSelected;
                    }
                    dgvToLocation.Rows[e.RowIndex].Cells[e.ColumnIndex].Update();
                }
            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            if (errorProvider.GetError(cboOperatorCode).Length == 0 && errorProvider.GetError(cboFromLocation).Length == 0)
            {
                MessageBox.Show("Generate Record(s)?", "Generation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(GenerateMessageHandler));
            }
        }

        private void GenerateMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                int result = Generate();

                if (result > 0)
                {
                    RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                    MessageBox.Show("Result : Successfully generated " + result.ToString() + " picking note(s)", "Success!");

                    //this.Close();
                }
                else
                {
                    if (VerifySelection())
                    {
                        MessageBox.Show("Result : Successfully generated " + result.ToString() + " picking note(s)", "Fail!");
                    }
                    else
                    {
                        MessageBox.Show("Please select one shop at least!", "Warning");
                    }
                }
            }
        }

        private void cboFromLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            Guid id = Guid.Empty;
            if (cboFromLocation.SelectedValue != null && Guid.TryParse(cboFromLocation.SelectedValue.ToString(), out id))
            {
                dgvToLocation.Rows.Clear();
                FillWorkplaceList(id);
                BindWorkplaceList();
            }
        }

        private void cboFromLocation_TextChanged(object sender, EventArgs e)
        {
            if (cboFromLocation.Text.Trim().Length > 0)
            {
                string wpCode = cboFromLocation.Text.Trim();
                if (wpCode.Length >= 4)
                {
                    if (ModelEx.WorkplaceEx.IsWorkplaceCodeInUse(wpCode.Substring(0, 4)))
                    {
                        errorProvider.SetError(cboFromLocation, "Location code does exist!");
                    }
                    else
                    {
                        errorProvider.SetError(cboFromLocation, string.Empty);
                    }
                }
                else
                {
                    errorProvider.SetError(cboFromLocation, "Location code should be 4 digits!");
                }
            }
        }

        private void cboOperatorCode_TextChanged(object sender, EventArgs e)
        {
            if (cboOperatorCode.Text.Trim().Length > 0)
            {
                string staffNumber = cboOperatorCode.Text.Trim();
                if (staffNumber.Length >= 4)
                {
                    var staff = ModelEx.StaffEx.GetByStaffNumber(staffNumber.Substring(0, 4));
                    if (staff == null)
                    {
                        errorProvider.SetError(cboOperatorCode, "Operator code does exist!");
                    }
                    else
                    {
                        errorProvider.SetError(cboOperatorCode, string.Empty);
                    }
                }
                else
                {
                    errorProvider.SetError(cboOperatorCode, "Operator code should be 4 digits!");
                }
            }
        }
    }
}