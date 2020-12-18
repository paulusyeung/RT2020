#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.Linq;
using RT2020.Helper;

#endregion

namespace RT2020.Member
{
    public partial class Member_MigrationForWeb : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Member_MigrationForWeb"/> class.
        /// </summary>
        public Member_MigrationForWeb()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            this.CheckTempRecords();
            this.GetTheLargestVipNumber();

            base.OnLoad(e);

            this.SetAttributes();

            this.FillLineOfOperationList();

            this.BindData();
        }

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {
            txtLargestVipNumber.BackColor = RT2020.SystemInfo.ControlBackColor.DisabledBox;
            cboNature.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;
            cboNature.SelectedIndex = 0;
            cboLineOfOperation.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;
            txtNormalDiscount.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;
            txtPromotionDiscount.BackColor = RT2020.SystemInfo.ControlBackColor.RequiredBox;

            dgvTempVipList.AutoGenerateColumns = false;
            dgvTempVipList.RowHeadersVisible = false;
        }

        /// <summary>
        /// clicks the Buttons.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnreload":
                            break;
                        case "btnprocess":
                            break;
                        case "btnexit":
                            this.Close();
                            break;
                    }
                }
            }
        }

        #region Loading Table

        /// <summary>
        /// Loads the table columns.
        /// </summary>
        private void LoadTableColumns()
        {
            // Status
            DataGridViewColumn dgvcStatus = new DataGridViewColumn();
            dgvcStatus.HeaderText = "Status";
            dgvcStatus.DataPropertyName = "";
            dgvcStatus.Width = 50;
            dgvTempVipList.Columns.Add(dgvcStatus);

            // New Vip #
            DataGridViewColumn dgvcNewVipNumber = new DataGridViewColumn();
            dgvcNewVipNumber.HeaderText = "New VIP#";
            dgvcNewVipNumber.DataPropertyName = "";
            dgvcNewVipNumber.Width = 90;
            dgvTempVipList.Columns.Add(dgvcNewVipNumber);

            // Temp Vip #
            DataGridViewColumn dgvcTempVipNumber = new DataGridViewColumn();
            dgvcTempVipNumber.HeaderText = "Temp VIP#";
            dgvcTempVipNumber.DataPropertyName = "";
            dgvcTempVipNumber.Width = 90;
            dgvTempVipList.Columns.Add(dgvcTempVipNumber);

            // Group
            DataGridViewColumn dgvcGroup = new DataGridViewColumn();
            dgvcGroup.HeaderText = "Group";
            dgvcGroup.DataPropertyName = "";
            dgvcGroup.Width = 60;
            dgvTempVipList.Columns.Add(dgvcGroup);

            // Salute
            DataGridViewColumn dgvcSalute = new DataGridViewColumn();
            dgvcSalute.HeaderText = "Salute";
            dgvcSalute.DataPropertyName = "";
            dgvcSalute.Width = 60;
            dgvTempVipList.Columns.Add(dgvcSalute);

            // First name
            DataGridViewColumn dgvcFirstName = new DataGridViewColumn();
            dgvcFirstName.HeaderText = "First Name";
            dgvcFirstName.DataPropertyName = "";
            dgvcFirstName.Width = 70;
            dgvTempVipList.Columns.Add(dgvcFirstName);

            // Last name
            DataGridViewColumn dgvcLastName = new DataGridViewColumn();
            dgvcLastName.HeaderText = "Last Name";
            dgvcLastName.DataPropertyName = "";
            dgvcLastName.Width = 70;
            dgvTempVipList.Columns.Add(dgvcLastName);

            // Nick name
            DataGridViewColumn dgvcNickName = new DataGridViewColumn();
            dgvcNickName.HeaderText = "Nick Name";
            dgvcNickName.DataPropertyName = "";
            dgvcNickName.Width = 70;
            dgvTempVipList.Columns.Add(dgvcNickName);
        }

        /// <summary>
        /// Binds the data.
        /// </summary>
        private void BindData()
        {
            this.LoadTableColumns();

        }

        /// <summary>
        /// Builds the query.
        /// </summary>
        /// <returns></returns>
        private string BuildQuery()
        {
            string query = string.Empty;

            return query;
        }

        #endregion

        #region Custom Methods

        /// <summary>
        /// Checks the temp records.
        /// </summary>
        private void CheckTempRecords()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                //string query = "RECORD_SOURCE = 'WEB'";
                //MemberApply4TempVipCollection objTempVip = MemberApply4TempVip.LoadCollection(query);
                var counts = ctx.MemberApply4TempVip.Where(x => x.RECORD_SOURCE == "WEB").Count();
                if (counts == 0)
                {
                    MessageBox.Show("No record found.", "Warning!");
                }

                btnProcess.Enabled = (counts != 0);
            }
        }

        /// <summary>
        /// Gets the largest vip number.
        /// </summary>
        private void GetTheLargestVipNumber()
        {
            string query = "SELECT MAX(MemberNumber) as LargestNumber FROM Member";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 600;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    if (reader[0] != null)
                    {
                        txtLargestVipNumber.Text = reader.GetString(0);
                    }
                    else
                    {
                        txtLargestVipNumber.Text = "1".PadLeft(13, '0');
                    }
                }
            }
        }

        #region Fill Combo List

        /// <summary>
        /// Fills the line of operation list.
        /// </summary>
        private void FillLineOfOperationList()
        {
            string[] orderBy = new string[] { "LineOfOperationName" };
            ModelEx.LineOfOperationEx.LoadCombo(ref cboLineOfOperation, "LineOfOperationName", true, false, "", "", orderBy);
        }

        #endregion

        #endregion
    }
}