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
using RT2020.DAL;
using System.Data.SqlClient;
using System.Configuration;

#endregion

namespace RT2020.Settings
{
    public partial class SystemSecurity : UserControl
    {
        public SystemSecurity()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.SetToolBar();

            this.LoadListView();
        }

        #region ToolBar

        /// <summary>
        /// Sets the tool bar.
        /// </summary>
        private void SetToolBar()
        {
            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdAdd
            ToolBarButton cmdAdd = new ToolBarButton("Add", "Add");
            cmdAdd.Tag = "Add";
            cmdAdd.Image = new IconResourceHandle("16x16.18_addsecurity.gif");

            //this.tbWizardAction.Buttons.Add(cmdAdd);
            //this.tbWizardAction.Buttons.Add(sep);

            //this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        /// <summary>
        /// Handles the ButtonClick event of the tbWizardAction control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Gizmox.WebGUI.Forms.ToolBarButtonClickEventArgs"/> instance containing the event data.</param>
        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "Add":
                        SystemSecurityWizard wizSystemSecurity = new SystemSecurityWizard();
                        wizSystemSecurity.Closed += new EventHandler(wizSystemSecurity_Closed);
                        wizSystemSecurity.ShowDialog();
                        break;
                }
            }
        }

        void wizSystemSecurity_Closed(object sender, EventArgs e)
        {
            this.LoadListView();
        }

        #endregion

        #region Load list

        private void LoadListView()
        {
            lvStaffSecurity.Items.Clear();

            int iCount = 1;
            string query = @"
SELECT DISTINCT [SecurityId],[StaffId],[StaffNumber],[GradeCode],[Module],[Functions],[CanRead],[CanWrite],[CanDelete],[CanPost] 
FROM (
    SELECT * FROM vwStaffListWithDefaultSecurity WHERE StaffId NOT IN (SELECT StaffId FROM vwStaffListWithSpecifiedSecurity)
    UNION ALL
    SELECT * FROM vwStaffListWithSpecifiedSecurity) lst ";

            if (txtLookfor.Text.Trim().Length > 0)
            {
                query += " WHERE StaffNumber LIKE '" + txtLookfor.Text.Trim() + "%' ";
            }

            query += " ORDER BY StaffNumber, GradeCode ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType= CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem lvItem = lvStaffSecurity.Items.Add(reader.GetGuid(0).ToString()); // GroupId or SecurityId
                    lvItem.SubItems.Add(reader.GetGuid(1).ToString()); // StaffId
                    lvItem.SubItems.Add(iCount.ToString()); // LineNumber
                    lvItem.SubItems.Add(reader.GetString(2)); // Staff Number
                    lvItem.SubItems.Add(reader.GetString(3)); // Grade Code
                    lvItem.SubItems.Add(reader.GetString(4)); // Module
                    lvItem.SubItems.Add(reader.GetString(5)); // Functions

                    // Can Read
                    lvItem.SubItems.Add(new IconResourceHandle(reader.GetBoolean(6) ? "16x16.ico_18_role_g.gif" : "16x16.ico_18_role_x.gif").ToString());

                    // Can Write
                    lvItem.SubItems.Add(new IconResourceHandle(reader.GetBoolean(7) ? "16x16.ico_18_role_g.gif" : "16x16.ico_18_role_x.gif").ToString());

                    // Can Delete
                    lvItem.SubItems.Add(new IconResourceHandle(reader.GetBoolean(8) ? "16x16.ico_18_role_g.gif" : "16x16.ico_18_role_x.gif").ToString());

                    // Can Post
                    lvItem.SubItems.Add(new IconResourceHandle(reader.GetBoolean(9) ? "16x16.ico_18_role_g.gif" : "16x16.ico_18_role_x.gif").ToString());

                    iCount++;
                }
            }
        }

        #endregion

        private void lvStaffSecurity_DoubleClick(object sender, EventArgs e)
        {
            if (lvStaffSecurity.SelectedItem != null)
            {
                SystemSecurityWizard wizSystemSecurity = new SystemSecurityWizard();
                wizSystemSecurity._SecurityId = Guid.Parse(lvStaffSecurity.SelectedItem.SubItems[0].Text);
                wizSystemSecurity._StaffId = Guid.Parse(lvStaffSecurity.SelectedItem.SubItems[1].Text);
                wizSystemSecurity.Closed += new EventHandler(wizSystemSecurity_Closed);
                wizSystemSecurity.ShowDialog();
            }
        }

        private void btnLookfor_Click(object sender, EventArgs e)
        {
            this.LoadListView();
        }

        private void txtLookfor_TextChanged(object sender, EventArgs e)
        {
            this.LoadListView();
        }
    }
}