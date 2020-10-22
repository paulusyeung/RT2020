#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Inventory.StockTake.Import
{
    public partial class ImportFromPPC_DataSelectionCtrl : UserControl
    {

        public ImportFromPPC_DataSelectionCtrl()
        {
            InitializeComponent();
        }

        #region Properties

        public bool HasChanged { get; set; }
        public int SelectedIndex { get; set; }

        public string Workplace
        {
            get
            {
                return cboWorkplace.Text;
            }
            set
            {
                cboWorkplace.Text = value;
            }
        }

        public string HHTTxNumber
        {
            get
            {
                return txtHHTTxNumber.Text;
            }
            set
            {
                txtHHTTxNumber.Text = value;
            }
        }

        public string StockTakeNumber
        {
            get
            {
                return cboStockTakeNumber.Text;
            }
            set
            {
                cboStockTakeNumber.Text = value;
            }
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            LoadWorkplaceList();

            txtHHTTxNumber.BackColor = SystemInfo.ControlBackColor.DisabledBox;
        }

        private void LoadWorkplaceList()
        {
            RT2020.DAL.Workplace.LoadCombo(ref cboWorkplace, "WorkplaceCode", false, false, string.Empty, string.Empty);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.HasChanged = false;
            this.Hide();
        }

        private void chkHHTNumAsSTKTKNum_Click(object sender, EventArgs e)
        {
            cboStockTakeNumber.Text = txtHHTTxNumber.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.HasChanged = true;
            this.Hide();
        }
    }
}