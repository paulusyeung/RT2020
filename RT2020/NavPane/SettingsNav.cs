#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;

#endregion

namespace RT2020.NavPane
{
    public partial class SettingsNav : UserControl
    {
        public SettingsNav()
        {
            InitializeComponent();

            NavPane.NavMenu.FillNavTree("settings", this.navSettings.Nodes);
        }

        private void navSettings_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Control[] controls = this.Form.Controls.Find("wspPane", true);
            if (controls.Length > 0)
            {
                Panel wspPane = (Panel)controls[0];
                wspPane.Text = navSettings.SelectedNode.Text;
                //wspPane.BackColor = ThemeHelper.WspPanel_BackgroundColor;

                wspPane.Controls.Clear();

                ShowAppToolStrip((string)navSettings.SelectedNode.Tag);
                ShowWorkspace(ref wspPane, (string)navSettings.SelectedNode.Tag);

                // 2020.08.28 paulus: RT2020 如果 wspPane 有 ActionStripBar，降低 list pane
                if (wspPane.Controls.Count > 1)
                {
                    wspPane.Controls[1].Margin = new Padding(0, 22, 0, 0);
                }
            }
        }

        private void ShowAppToolStrip(string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                Control[] controls = this.Form.Controls.Find("wspPane", true);
                if (controls.Length > 0)
                {
                    Panel wspPane = (Panel)controls[0];

                    switch (Tag.ToLower())
                    {
                        case "settings.staff":
                        case "settings.supplier":
                        case "settings.workplace":
                            RT2020.AtsPane.SettingsAts oAtsSettings = new RT2020.AtsPane.SettingsAts();
                            oAtsSettings.Dock = DockStyle.Top;
                            wspPane.Controls.Add(oAtsSettings);
                            break;
                        case "settings.label":
                        case "settings.info":
                        case "settings.monthend":
                        case "settings.security":
                            //RT2020.Inventory.GoodsReceive.DefaultAts oRecv = new RT2020.Inventory.GoodsReceive.DefaultAts();
                            //oRecv.Dock = DockStyle.Fill;
                            //atsPane.Controls.Clear();
                            //atsPane.Controls.Add(oRecv);
                            break;
                    }
                }
            }
        }

        private void ShowWorkspace(ref Panel wspPane, string Tag)
        {
            if (!string.IsNullOrEmpty(Tag))
            {
                switch (Tag.ToLower())
                {
                    case "settings.staff":
                        RT2020.Staff.StaffList oStaffList = new RT2020.Staff.StaffList();
                        oStaffList.DockPadding.All = 6;
                        oStaffList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oStaffList);
                        break;
                    case "settings.supplier":
                        RT2020.Supplier.SupplierList oSupplierList = new RT2020.Supplier.SupplierList();
                        oSupplierList.DockPadding.All = 6;
                        oSupplierList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oSupplierList);
                        break;
                    case "settings.workplace":
                        RT2020.Workplace.WorkplaceList oWorkplaceList = new RT2020.Workplace.WorkplaceList();
                        oWorkplaceList.DockPadding.All = 6;
                        oWorkplaceList.Dock = DockStyle.Fill;
                        wspPane.Controls.Add(oWorkplaceList);
                        break;
                    case "settings.label":
                        RT2020.Settings.SystemLabels oSysLabel = new RT2020.Settings.SystemLabels();
                        oSysLabel.Dock = DockStyle.Fill;
                        oSysLabel.DockPadding.All = 6;
                        wspPane.Controls.Add(oSysLabel);
                        break;
                    case "settings.info":
                        RT2020.Settings.SystemInfoForm oSysInfo = new RT2020.Settings.SystemInfoForm();
                        oSysInfo.Dock = DockStyle.Fill;
                        oSysInfo.DockPadding.All = 6;
                        wspPane.Controls.Add(oSysInfo);
                        break;
                    case "settings.monthend":
                        RT2020.Settings.SystemMonthEnd oSysMe = new RT2020.Settings.SystemMonthEnd();
                        oSysMe.Dock = DockStyle.Fill;
                        oSysMe.DockPadding.All = 6;
                        wspPane.Controls.Add(oSysMe);
                        break;
                    case "settings.security":
                        if (NetSqlAzManHelper.UseNetSqlAzMan)
                        {
                            #region 使用 RT2020 NetSqlAzMan Access Control
                            var netSql = new VWG.Community.NetSqlAzMan.WebConsole()
                            {
                                Dock = DockStyle.Fill,
                                SqlConnectionString = NetSqlAzManHelper.ConnectionString,
                                Theme = ThemeHelper.CurrentTheme
                            };
                            wspPane.Controls.Add(netSql);
                            #endregion
                        }
                        else
                        {
                            #region 使用 RT2008 Access Control
                            RT2020.Settings.SystemSecurity oSysSec = new RT2020.Settings.SystemSecurity();
                            oSysSec.Dock = DockStyle.Fill;
                            oSysSec.DockPadding.All = 6;
                            wspPane.Controls.Add(oSysSec);
                            #endregion
                        }
                        break;
                    case "settings.translation":
                        RT2020.Settings.Translation oTranslate = new RT2020.Settings.Translation();
                        oTranslate.Dock = DockStyle.Fill;
                        oTranslate.DockPadding.All = 6;
                        wspPane.Controls.Add(oTranslate);
                        break;
                    case "settings.phone":
                        var oPhone = new RT2020.Settings.SuperUser.Phone();
                        oPhone.Dock = DockStyle.Fill;
                        oPhone.DockPadding.All = 6;
                        wspPane.Controls.Add(oPhone);
                        break;
                }
            }
        }
    }
}