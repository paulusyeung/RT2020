#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.ModelEx;



#endregion

namespace RT2020.EmulatedPoS
{
    public partial class FastModeLogin : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FastModeLogin"/> class.
        /// </summary>
        public FastModeLogin()
        {
            InitializeComponent();

            FillLocationList();

            dtpTxDate.Value = Convert.ToDateTime(SystemInfoEx.CurrentInfo.Default.CurrentSystemDate.ToString("yyyy-MM-" + DateTime.Now.ToString("dd")));
        }

        private DateTime txDate;
        /// <summary>
        /// Gets or sets the tx date.
        /// </summary>
        /// <value>The tx date.</value>
        public DateTime TxDate
        {
            get { return txDate; }
            set { txDate = value; }
        }

        private Guid workplaceId = System.Guid.Empty;
        /// <summary>
        /// Gets or sets the workplace id.
        /// </summary>
        /// <value>The workplace id.</value>
        public Guid WorkplaceId
        {
            get { return workplaceId; }
            set { workplaceId = value; }
        }

        /// <summary>
        /// Fills the location list.
        /// </summary>
        private void FillLocationList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboWorkplace, "WorkplaceCode", false);
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnOk control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.TxDate = this.dtpTxDate.Value;
            this.WorkplaceId = new Guid(this.cboWorkplace.SelectedValue.ToString());

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}