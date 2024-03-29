#region Using

using Gizmox.WebGUI.Common.Resources;
using Gizmox.WebGUI.Forms;
using RT2020.Controls;
using RT2020.Common.Helper;

#endregion Using

namespace RT2020.AtsPane
{
    public partial class MemberMgmtAts : UserControl
    {
        public MemberMgmtAts()
        {
            InitializeComponent();

            SetAtsMemberMgmt();
        }

        private void SetAtsMemberMgmt()
        {
            nxStudio.BaseClass.WordDict oDict = new nxStudio.BaseClass.WordDict(ConfigHelper.CurrentWordDict, ConfigHelper.CurrentLanguageId);

            this.atsMemberMgmt.MenuHandle = false;
            this.atsMemberMgmt.DragHandle = false;
            this.atsMemberMgmt.TextAlign = ToolBarTextAlign.Right;

            ContextMenu ddlNew = new ContextMenu();
            //ddlNew.MenuItems.Add(new MenuItem(Utility.Dictionary.GetWord("Member"), string.Empty, "MemberWizard"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("member", "Model"), string.Empty, "MemberWizard"));
            ddlNew.MenuItems.Add(new MenuItem("-"));
            //ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("member.batchUpdateDiscount", "MenuStrip"), string.Empty, "MemberWizard_MassUpdate"));
            //ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("member.promoteTempMembers", "MenuStrip"), string.Empty, "MemberWizard_Migration"));
            //ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("member.promoteWebMembers", "MenuStrip"), string.Empty, "MemberWizard_Migration_Web"));
            //ddlNew.MenuItems.Add(new MenuItem(oDict.GetWord("Temporary Member for Web"), string.Empty, "TempMember4Web"));
            //ddlNew.MenuItems.Add(new MenuItem("-"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("memberAddressType", "Model"), string.Empty, "MemberAddressType"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("memberClass", "Model"), string.Empty, "MemberClass"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("memberGroup", "Model"), string.Empty, "MemberGroup"));
            ddlNew.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("smartTag4Member", "Model"), string.Empty, "SmartTag4Member"));

            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Style = ToolBarButtonStyle.DropDownButton;
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");
            cmdNew.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdNew.DropDownMenu = ddlNew;

            this.atsMemberMgmt.Buttons.Add(cmdNew);
            cmdNew.MenuClick += new MenuEventHandler(AtsMenuClick);

            // cmdImport
            ContextMenu ddlImport = new ContextMenu();
            ddlImport.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("member", "Model"), string.Empty, "ImportMember"));

            ToolBarButton cmdImport = new ToolBarButton("Import", WestwindHelper.GetWord("edit.import", "General"));
            cmdImport.Style = ToolBarButtonStyle.DropDownButton;
            cmdImport.Image = new IconResourceHandle("16x16.ico_16_4407.gif");
            cmdImport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdImport.DropDownMenu = ddlImport;

            this.atsMemberMgmt.Buttons.Add(cmdImport);
            cmdImport.MenuClick += new MenuEventHandler(AtsMenuClick);

            // cmdExport
            ContextMenu ddlExport = new ContextMenu();
            ddlExport.MenuItems.Add(new MenuItem(WestwindHelper.GetWord("member", "Model"), string.Empty, "ExportMember"));

            ToolBarButton cmdExport = new ToolBarButton("Export", WestwindHelper.GetWord("edit.export", "General"));
            cmdExport.Style = ToolBarButtonStyle.DropDownButton;
            cmdExport.Image = new IconResourceHandle("16x16.ico_16_exportCustomizations.gif");
            cmdExport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdExport.DropDownMenu = ddlExport;

            this.atsMemberMgmt.Buttons.Add(cmdExport);
            cmdExport.MenuClick += new MenuEventHandler(AtsMenuClick);

            // Separator
            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;
            this.atsMemberMgmt.Buttons.Add(sep);

            //  cmdReport
            ContextMenu ddlReport = new ContextMenu();
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Code List"), string.Empty, "vip_code_list"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Thanks Letter"), string.Empty, "vip_thanks_letter"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Mature List"), string.Empty, "vip_mature_list"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Birthday List"), string.Empty, "vip_birthday_list"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Expire List"), string.Empty, "vip_expire_list"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Commencement List"), string.Empty, "vip_commencement_list"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Daily Join In List"), string.Empty, "vip_daily_join_in_list"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Mailing Label (ATD)"), string.Empty, "vip_mailing_label_atd"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Mailing Label (YTD)"), string.Empty, "vip_mailing_label_ytd"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Mailing Lable - Birthday (ATD)"), string.Empty, "vip_mailing_lable_birthday_atd"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Mailing Lable - Birthday (YTD)"), string.Empty, "vip_mailing_lable_birthday_ytd"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Mailing Label by Top VIP Spending"), string.Empty, "vip_mailing_label_by_top_vip_spending"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem(oDict.GetWord("VIP Sales Summay List"), string.Empty, "vip_sales_summay_list"));
            ddlReport.MenuItems.Add(new MenuItem("-"));
            ddlReport.MenuItems.Add(new MenuItem(string.Format(oDict.GetWord("Top VIP Spending by"), SystemInfoHelper.Settings.GetSystemLabelByKey("CLASS1")), string.Empty, "top_vip_spending_by_class1"));

            ToolBarButton cmdReport = new ToolBarButton("Reports", WestwindHelper.GetWord("edit.reports", "General"));
            cmdReport.Style = ToolBarButtonStyle.DropDownButton;
            cmdReport.Image = new IconResourceHandle("16x16.16_reports.gif");
            cmdReport.Enabled = RT2020.Controls.UserUtility.IsAccessAllowed(EnumHelper.Permission.Write);
            cmdReport.DropDownMenu = ddlReport;

            this.atsMemberMgmt.Buttons.Add(cmdReport);
            cmdReport.MenuClick += new MenuEventHandler(AtsMenuClick);
        }

        private void AtsMenuClick(object sender, MenuItemEventArgs e)
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
                    case "memberwizard":
                        RT2020.Member.MemberWizard wizMember = new RT2020.Member.MemberWizard();
                        wizMember.EditMode = EnumHelper.EditMode.Add;
                        wizMember.ShowDialog();
                        break;
                    case "memberwizard_massupdate":
                        RT2020.Member.MassUpdateWizard wizMemberMassUpdate = new RT2020.Member.MassUpdateWizard();
                        wizMemberMassUpdate.ShowDialog();
                        break;
                    case "memberwizard_migration":
                        RT2020.Member.PromoteMember wizMemberMigration = new RT2020.Member.PromoteMember();
                        wizMemberMigration.ShowDialog();
                        break;
                    case "memberwizard_migration_web":
                        RT2020.Member.PromoteWebMember wizMemberMigration4Web = new RT2020.Member.PromoteWebMember();
                        wizMemberMigration4Web.ShowDialog();
                        break;
                    case "memberaddresstype":
                        RT2020.Member.MemberAddressTypeWizard wizAddressType = new RT2020.Member.MemberAddressTypeWizard();
                        wizAddressType.ShowDialog();
                        break;
                    case "memberclass":
                        RT2020.Member.MemberClassWizard wizMemberClass = new RT2020.Member.MemberClassWizard();
                        wizMemberClass.ShowDialog();
                        break;
                    case "membergroup":
                        RT2020.Member.MemberGroupWizard wizMemberGroup = new RT2020.Member.MemberGroupWizard();
                        wizMemberGroup.ShowDialog();
                        break;
                    case "smarttag4member":
                        RT2020.Member.SmartTag4MemberWizard wizSmartTag4Member = new RT2020.Member.SmartTag4MemberWizard();
                        wizSmartTag4Member.ShowDialog();
                        break;
                    case "tempmember4web":
                        //RT2020.Settings.SmartTag4MemberWizard wizSmartTag4Member = new RT2020.Settings.SmartTag4MemberWizard();
                        //wizSmartTag4Member.ShowDialog();
                        break;
                    case "importmember":
                        RT2020.Member.Import.ImportMember oImportMember = new RT2020.Member.Import.ImportMember();
                        oImportMember.ShowDialog();
                        break;
                    case "exportmember":
                        RT2020.Member.Export.ExportMember oExportMember = new RT2020.Member.Export.ExportMember();
                        oExportMember.ShowDialog();
                        break;
                    case "vip_code_list":
                        RT2020.Member.Reports.RptVipCodeListForm vipCodeList = new RT2020.Member.Reports.RptVipCodeListForm();
                        vipCodeList.ShowDialog();
                        break;
                    case "vip_thanks_letter":
                        RT2020.Member.Reports.RptVipThanksLetterForm vipThanksLetter = new RT2020.Member.Reports.RptVipThanksLetterForm();
                        vipThanksLetter.ShowDialog();
                        break;
                    case "vip_mature_list":
                        RT2020.Member.Reports.RptVipMatureListForm vipMatureList = new RT2020.Member.Reports.RptVipMatureListForm();
                        vipMatureList.ShowDialog();
                        break;
                    case "vip_birthday_list":
                        RT2020.Member.Reports.RptVipBirthdayListForm vipBirthdayList = new RT2020.Member.Reports.RptVipBirthdayListForm();
                        vipBirthdayList.ShowDialog();
                        break;
                    case "vip_expire_list":
                        RT2020.Member.Reports.RptVipExpireListForm vipExpireList = new RT2020.Member.Reports.RptVipExpireListForm();
                        vipExpireList.ShowDialog();
                        break;
                    case "vip_commencement_list":
                        RT2020.Member.Reports.RptVipCommtListForm vipCommencementList = new RT2020.Member.Reports.RptVipCommtListForm();
                        vipCommencementList.ShowDialog();
                        break;
                    case "vip_daily_join_in_list":
                        RT2020.Member.Reports.RptVipDailyJoinListForm vipDailyJoinList = new RT2020.Member.Reports.RptVipDailyJoinListForm();
                        vipDailyJoinList.ShowDialog();
                        break;
                    case "vip_mailing_label_atd":
                        RT2020.Member.Reports.RptVipMLblAtdForm vipMailingLabelAtd = new RT2020.Member.Reports.RptVipMLblAtdForm();
                        vipMailingLabelAtd.ShowDialog();
                        break;
                    case "vip_mailing_label_ytd":
                        RT2020.Member.Reports.RptVipMLblYtdForm vipMailingLabelYtd = new RT2020.Member.Reports.RptVipMLblYtdForm();
                        vipMailingLabelYtd.ShowDialog();
                        break;
                    case "vip_mailing_lable_birthday_atd":
                        RT2020.Member.Reports.RptVipMLblBirthdayAtdForm vipMailingLabelBirthdayAtd = new RT2020.Member.Reports.RptVipMLblBirthdayAtdForm();
                        vipMailingLabelBirthdayAtd.ShowDialog();
                        break;
                    case "vip_mailing_lable_birthday_ytd":
                        RT2020.Member.Reports.RptVipMLblBirthdayYtdForm vipMailingLabelBirthdayYtd = new RT2020.Member.Reports.RptVipMLblBirthdayYtdForm();
                        vipMailingLabelBirthdayYtd.ShowDialog();
                        break;
                    case "vip_mailing_label_by_top_vip_spending":
                        RT2020.Member.Reports.RptVipMLblBySpendingForm vipMailingLabelBySpending = new RT2020.Member.Reports.RptVipMLblBySpendingForm();
                        vipMailingLabelBySpending.ShowDialog();
                        break;
                    case "vip_sales_summay_list":
                        RT2020.Member.Reports.RptVipSummaryListForm vipSummaryList = new RT2020.Member.Reports.RptVipSummaryListForm();
                        vipSummaryList.ShowDialog();
                        break;
                    case "top_vip_spending_by_class1":
                        RT2020.Member.Reports.RptVipVendorSpendingForm vipVendorSpending = new RT2020.Member.Reports.RptVipVendorSpendingForm();
                        vipVendorSpending.ShowDialog();
                        break;
                }
            }
        }

        private void AtsMemberMgmt_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            MessageBox.Show(e.Button.Text);
        }
    }
}