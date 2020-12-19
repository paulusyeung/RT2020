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
using System.IO;
using RT2020.Controls;

using System.Threading;

#endregion

namespace RT2020.Settings
{
    public partial class SystemMonthEnd : UserControl
    {
        Thread processThread;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public SystemMonthEnd()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:System.Windows.Forms.Form.Load"/> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"/> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetAttributes();
        }

        /// <summary>
        /// Sets the attributes.
        /// </summary>
        private void SetAttributes()
        {
            txtProgessMessage.Text = "Preparing...";

            txtCompanyName.Text = SystemInfo.CurrentInfo.Default.CompanyName;
            txtMonthEnded.Text = SystemInfo.CurrentInfo.Default.CurrentSystemDate.ToString("MMMM yyyy");

            txtCompanyName.BackColor = SystemInfo.ControlBackColor.DisabledBox;
            txtMonthEnded.BackColor = SystemInfo.ControlBackColor.DisabledBox;
        }

        /// <summary>
        /// Handles the Click event of the btnCancel control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Cancel processing, Sure?", "Attention", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, new EventHandler(CancelThreadHandler));
        }

        /// <summary>
        /// Cancels the thread handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CancelThreadHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (processThread != null)
                {
                    processThread.Abort();
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnProcess control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnProcess_Click(object sender, EventArgs e)
        {
            MonthEndProcess.ProcessSteps steps = new MonthEndProcess.ProcessSteps();
            steps.ResetServiceItemCDQty = chkResetServiceItemCDQty.Checked;
            steps.StartOn = DateTime.Now;
            steps.UpdatedProgress += new ProgressUpdateEventHandler(steps_UpdatedProgress);

            processThread = new Thread(new ThreadStart(steps.Process));
            processThread.Start();
        }

        /// <summary>
        /// Handles the UpdatedProgress event of the steps control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RT2020.SettingsMonthEndCommon.ProgressUpdateEventArgs"/> instance containing the event data.</param>
        void steps_UpdatedProgress(object sender, ProgressUpdateEventArgs e)
        {
            txtProgessMessage.Text = e.Message;
            txtProgessMessage.Update();

            if (e.Position >= e.Total)
            {
                e.Position = e.Position / e.Total;
            }

            progressBar.Value = e.Position;
            progressBar.Maximum = e.Total;
            progressBar.Update();

            this.Update();
        }
    }
}
