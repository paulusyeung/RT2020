#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Data.SqlClient;
using System.Configuration;

using RT2020.Common.Helper;

#endregion

namespace RT2020.Inventory.Transfer.Import
{
    public partial class AdvanceImport_ListView : UserControl
    {
        public AdvanceImport_ListView()
        {
            InitializeComponent();
        }

        public AdvanceImport_ListView(string sqlQuery, bool notInMatch)
        {
            InitializeComponent();

            SetSystemLabel();
            BindList(sqlQuery, notInMatch);
        }

        private void SetSystemLabel()
        {
            colStockCode.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            colAppendix1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            colAppendix2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            colAppendix3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");
        }

        private void BindList(string query, bool notInMatch)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem lvItem = lvDetailList.Items.Add(reader.GetString(0)); // TxNumber
                    lvItem.SubItems.Add(reader.GetString(1)); // Stock Code
                    lvItem.SubItems.Add(reader.GetString(2)); // Appendix1
                    lvItem.SubItems.Add(reader.GetString(3)); // Appendix2
                    lvItem.SubItems.Add(reader.GetString(4)); // Appendix3
                    lvItem.SubItems.Add(reader.GetString(5)); // Barcode
                    lvItem.SubItems.Add(reader.GetString(6)); // Description
                    lvItem.SubItems.Add(reader.GetDecimal(7).ToString("n0")); // Qty
                    lvItem.BackColor = notInMatch ? SystemInfoHelper.ControlBackColor.DisabledBox : Color.White;
                }
            }
        }

        private void lvDetailList_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                lvDetailList.Items[e.Index].Checked = (lvDetailList.Items[e.Index].BackColor != SystemInfoHelper.ControlBackColor.DisabledBox);
            }
        }
    }
}