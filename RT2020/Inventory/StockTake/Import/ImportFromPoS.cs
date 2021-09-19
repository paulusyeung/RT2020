#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.IO;
using System.Web.Configuration;
using FileHelpers.DataLink;
using RT2020.Common.Helper;

#endregion

namespace RT2020.Inventory.StockTake.Import
{
    public partial class ImportFromPoS : Form
    {
        public ImportFromPoS()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            SetAttributes();
        }

        private void SetAttributes()
        {
            txtStockTakeNumber.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtWorkplaceCode.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtHHTID.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtUploadedOn.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;
            txtStatus.BackColor = SystemInfoHelper.ControlBackColor.DisabledBox;

            txtUploadedOn.Text = DateTime.Now.ToString("dd MMM yyyy HH:mm:ss");

            txtStatus.Text = "Press Import to select files.";
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImportData_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "Select import files.";

            ImportFromPoS_SelectionWizard wizSelection = new ImportFromPoS_SelectionWizard();
            wizSelection.Remarks = txtRemarks.Text;
            wizSelection.Closed += new EventHandler(wizSelection_Closed);
            wizSelection.ShowDialog();
        }

        void wizSelection_Closed(object sender, EventArgs e)
        {
            ImportFromPoS_SelectionWizard wizSelection = sender as ImportFromPoS_SelectionWizard;
            if (wizSelection != null)
            {
                List<string[]> resultList = wizSelection.ResultList;

                if (resultList != null)
                {
                    foreach (string[] result in resultList)
                    {
                        ListViewItem lvItem = lvUploadList.Items.Add(result[0]); // File name
                        lvItem.SubItems.Add(result[1]); // Txnumber
                        lvItem.SubItems.Add(result[2]); // Shop#
                        lvItem.SubItems.Add(result[3]); // Status
                        lvItem.SubItems.Add(result[4]); // Remarks
                        lvItem.SubItems.Add(result[5]); // HHT

                        if (result.Contains("Failed") || result.Contains("Ignored/Failed"))
                        {
                            txtStatus.Text = "Data Transform from POS data failed/Igored.";
                        }
                        else
                        {
                            txtStatus.Text = "Data Transform from POS data successfully.";
                        }
                    }
                }
            }
        }

        private void lvUploadList_Click(object sender, EventArgs e)
        {
            ListViewItem lvItem = lvUploadList.SelectedItem;

            txtStockTakeNumber.Text = lvItem.SubItems[1].Text;
            txtWorkplaceCode.Text = lvItem.SubItems[2].Text;
            txtHHTID.Text = lvItem.SubItems[5].Text;
        }
    }
}