#region Using

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;

using RT2020.Controls;
using RT2020.Helper;

#endregion Using

namespace RT2020.AtsPane
{
    public partial class SettingsAts : UserControl
    {
        public SettingsAts()
        {
            InitializeComponent();

            SetAtsSettings();
        }

        private void SetAtsSettings()
        {
            nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(ConfigHelper.CurrentWordDict, ConfigHelper.CurrentLanguageId);

            this.atsSettings.MenuHandle = false;
            this.atsSettings.DragHandle = false;
            this.atsSettings.TextAlign = ToolBarTextAlign.Right;

            ContextMenu ddlNew = new ContextMenu();
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("staff", "Model"), string.Empty, "Staff"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("department", "Model"), string.Empty, "StaffDept"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("staffGroup", "Model"), string.Empty, "StaffGroup"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("jobTitle", "Model"), string.Empty, "StaffJobTitle"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("smartTag4Staff", "Model"), string.Empty, "SmartTag4Staffe"));
            ddlNew.MenuItems.Add(new MenuItem("-"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("workplace", "Model"), string.Empty, "Workplace"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("workplaceNature", "Model"), string.Empty, "WorkplaceNature"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("smartTag4Workplace", "Model"), string.Empty, "SmartTag4Workplace"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("promotion.campaign", "Model"), string.Empty, "Promotion"));
            ddlNew.MenuItems.Add(new MenuItem("-"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("supplier", "Model"), string.Empty, "Supplier"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("supplier", "Model") + " " + oDict.GetWord("Address Type"), string.Empty, "SupplierAddressType"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("supplier", "Model") + " " + oDict.GetWord("Terms"), string.Empty, "SupplierTerms"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("smartTag4Supplier", "Model"), string.Empty, "SmartTag4Supplier"));
            ddlNew.MenuItems.Add(new MenuItem("-"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("currency", "Model"), string.Empty, "Currency"));
            //ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("promotion", "Model"), string.Empty, "PaymentFactor_Currency"));
            //ddlNew.MenuItems.Add(new MenuItem(oDict.GetWord("Payment Factor") + " (" + oDict.GetWord("Event Code") + ")", string.Empty, "PaymentFactor_EventCode"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("country", "Model"), string.Empty, "Country"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("province", "Model"), string.Empty, "Province"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("city", "Model"), string.Empty, "City"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("workplaceZone", "Model"), string.Empty, "Zone"));
            ddlNew.MenuItems.Add(new MenuItem("-"));
            //ddlNew.MenuItems.Add(new MenuItem(oDict.GetWord("Internet Tag"), string.Empty, "InternetTag"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("lineOfOperation", "Model"), string.Empty, "LineOfOperation"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("marketSector", "Model"), string.Empty, "MarketSector"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("salutation", "Model"), string.Empty, "Salutation"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("phoneTag", "Model"), string.Empty, "PhoneTag"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("jobTitle", "Model"), string.Empty, "JobTitle"));

            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsSettings.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(AtsSettings_MenuClick);

            ContextMenu ddlReports = new ContextMenu();
            ddlReports.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("staff", "Model") + " " + WestwindHelper.GetWord("edit.reports", "General"), string.Empty, "Staff Reports"));
            ddlReports.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("workplace", "Model") + " " + WestwindHelper.GetWord("edit.reports", "General"), string.Empty, "Workplace Reports"));
            ddlReports.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("supplier", "Model") + " " + WestwindHelper.GetWord("edit.reports", "General"), string.Empty, "Supplier Reports"));

            ToolBarButton cmdReports = new ToolBarButton("Reports", WestwindHelper.GetWord("edit.reports", "General"));
            cmdReports.Style = ToolBarButtonStyle.DropDownButton;
            cmdReports.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReports.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdReports.DropDownMenu = ddlReports;

            this.atsSettings.Buttons.Add(cmdReports);
            cmdReports.MenuClick += new MenuEventHandler(AtsSettings_MenuClick);

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsSettings.Buttons.Add(sep);
        }

        private void AtsSettings_MenuClick(object sender, MenuItemEventArgs e)
        {
            //Control[] controls = this.Form.Controls.Find("wspPane", true);
            //if (controls.Length > 0)
            //{
            //    Panel wspPane = (Panel)controls[0];
            //    wspPane.Text = (string)e.MenuItem.Text;
            //}

            if (!(e.MenuItem.Tag == null))
            {
                switch (e.MenuItem.Tag.ToString().ToLower())
                {
                    case "staff":
                        Staff.StaffWizard staffCode = new RT2020.Staff.StaffWizard();
                        staffCode.EditMode = EnumHelper.EditMode.Add;
                        staffCode.ShowDialog();
                        break;
                    case "staffdept":
                        RT2020.Staff.StaffDeptWizard wizDept = new RT2020.Staff.StaffDeptWizard();
                        wizDept.ShowDialog();
                        break;
                    case "staffgroup":
                        RT2020.Staff.StaffGroupWizard wizGroup = new RT2020.Staff.StaffGroupWizard();
                        wizGroup.ShowDialog();
                        break;
                    case "staffjobtitle":
                        RT2020.Staff.StaffJobTitleWizard wizStaffJobTitle = new RT2020.Staff.StaffJobTitleWizard();
                        wizStaffJobTitle.ShowDialog();
                        break;
                    case "smarttag4staffe":
                        RT2020.Staff.SmartTag4StaffWizard wizSmartTag4Staffe = new RT2020.Staff.SmartTag4StaffWizard();
                        wizSmartTag4Staffe.ShowDialog();
                        break;
                    case "workplace":
                        RT2020.Workplace.WorkplaceWizard workplace = new RT2020.Workplace.WorkplaceWizard();
                        workplace.ShowDialog();
                        break;
                    case "workplacenature":
                        RT2020.Workplace.WorkplaceNatureWizard wizWorkplaceNature = new RT2020.Workplace.WorkplaceNatureWizard();
                        wizWorkplaceNature.ShowDialog();
                        break;
                    case "smarttag4workplace":
                        RT2020.Workplace.SmartTag4WorkplaceWizard wizSmartTag4Workplace = new RT2020.Workplace.SmartTag4WorkplaceWizard();
                        wizSmartTag4Workplace.ShowDialog();
                        break;
                    case "promotion":
                        RT2020.Settings.CampaignWizard promotion = new RT2020.Settings.CampaignWizard();
                        promotion.CampaignType = EnumHelper.CampaignType.TenderType;
                        promotion.ShowDialog();
                        break;
                    case "workplace reports":
                        RT2020.Workplace.Reports.RptWorkplaceList rptWorkplackList = new RT2020.Workplace.Reports.RptWorkplaceList();
                        rptWorkplackList.ShowDialog();
                        break;
                    case "staff reports":
                        RT2020.Staff.Reports.RptStaffList rptStaff = new RT2020.Staff.Reports.RptStaffList();
                        rptStaff.ShowDialog();
                        break;
                    case "supplier reports":
                        RT2020.Supplier.Reports.RptSupplierList rptSupplier = new RT2020.Supplier.Reports.RptSupplierList();
                        rptSupplier.ShowDialog();
                        break;
                    case "supplier":
                        RT2020.Supplier.SupplierWizard wizSupplier = new RT2020.Supplier.SupplierWizard();
                        wizSupplier.EditMode = EnumHelper.EditMode.Add;
                        wizSupplier.ShowDialog();
                        break;
                    case "supplieraddresstype":
                        RT2020.Supplier.SupplierAddressTypeWizard wizAddressType = new RT2020.Supplier.SupplierAddressTypeWizard();
                        wizAddressType.ShowDialog();
                        break;
                    case "supplierterms":
                        RT2020.Supplier.SupplierTermsWizard wizTerms = new RT2020.Supplier.SupplierTermsWizard();
                        wizTerms.ShowDialog();
                        break;
                    case "smarttag4supplier":
                        RT2020.Supplier.SmartTag4SupplierWizard wizSmartTag4Supplier = new RT2020.Supplier.SmartTag4SupplierWizard();
                        wizSmartTag4Supplier.ShowDialog();
                        break;
                    case "currency":
                        RT2020.Settings.CurrencyWizard wizCny = new RT2020.Settings.CurrencyWizard();
                        wizCny.ShowDialog();
                        break;
                    case "paymentfactor_currency":
                        RT2020.Settings.CampaignWizard wizPaymentFactorCurr = new RT2020.Settings.CampaignWizard();
                        wizPaymentFactorCurr.CampaignType = EnumHelper.CampaignType.TenderType;
                        wizPaymentFactorCurr.ShowDialog();
                        break;
                    case "paymentfactor_eventcode":
                        RT2020.Settings.CampaignWizard wizPaymentFactorEvnt = new RT2020.Settings.CampaignWizard();
                        wizPaymentFactorEvnt.CampaignType = EnumHelper.CampaignType.EventCode;
                        wizPaymentFactorEvnt.ShowDialog();
                        break;
                    case "country":
                        RT2020.Settings.CountryWizard wizCountry = new RT2020.Settings.CountryWizard();
                        wizCountry.ShowDialog();
                        break;
                    case "province":
                        RT2020.Settings.ProvinceWizard wizProvince = new RT2020.Settings.ProvinceWizard();
                        wizProvince.ShowDialog();
                        break;
                    case "city":
                        RT2020.Settings.CityWizard wizCity = new RT2020.Settings.CityWizard();
                        wizCity.ShowDialog();
                        break;
                    case "zone":
                        RT2020.Settings.ZoneWizard wizZone = new RT2020.Settings.ZoneWizard();
                        wizZone.ShowDialog();
                        break;
                    case "internettag":
                        RT2020.Settings.InternetTagWizard wizITag = new RT2020.Settings.InternetTagWizard();
                        wizITag.ShowDialog();
                        break;
                    case "lineofoperation":
                        RT2020.Settings.LineOfOperationWizard wizLOO = new RT2020.Settings.LineOfOperationWizard();
                        wizLOO.ShowDialog();
                        break;
                    case "marketsector":
                        RT2020.Supplier.MarketSectorWizard wizMarketSector = new RT2020.Supplier.MarketSectorWizard();
                        wizMarketSector.ShowDialog();
                        break;
                    case "salutation":
                        RT2020.Settings.SalutationWizard wizSalutation = new RT2020.Settings.SalutationWizard();
                        wizSalutation.ShowDialog();
                        break;
                    case "phonetag":
                        RT2020.Settings.PhoneTagWizard wizPhoneTag = new RT2020.Settings.PhoneTagWizard();
                        wizPhoneTag.ShowDialog();
                        break;
                    case "jobtitle":
                        RT2020.Settings.JobTitleWizard wizJobTitle = new RT2020.Settings.JobTitleWizard();
                        wizJobTitle.ShowDialog();
                        break;
                }
            }
        }
    }
}