namespace RT2020.Member.Reports
{
    partial class VipMatureListRpt
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.NRDISC1 = new DevExpress.XtraReports.UI.XRLabel();
            this.RACE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CARDNAME1 = new DevExpress.XtraReports.UI.XRLabel();
            this.NETSALES1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GROUP1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DATECOMM1 = new DevExpress.XtraReports.UI.XRLabel();
            this.VIPNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text17 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.xrPageInfo1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.hdrCompName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotAMT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text16 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrintDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text14 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text13 = new DevExpress.XtraReports.UI.XRLabel();
            this.hdToVIPNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.hdFmVIPNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 15;
            this.Detail.Name = "Detail";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.NRDISC1,
            this.RACE1,
            this.CARDNAME1,
            this.NETSALES1,
            this.GROUP1,
            this.DATECOMM1,
            this.VIPNO1,
            this.Text17});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("VipNumber", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 17;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // NRDISC1
            // 
            this.NRDISC1.BackColor = System.Drawing.Color.White;
            this.NRDISC1.BorderColor = System.Drawing.Color.Black;
            this.NRDISC1.CanGrow = false;
            this.NRDISC1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.NRDISC", "")});
            this.NRDISC1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.NRDISC1.ForeColor = System.Drawing.Color.Black;
            this.NRDISC1.Location = new System.Drawing.Point(593, 1);
            this.NRDISC1.Name = "NRDISC1";
            this.NRDISC1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NRDISC1.ParentStyleUsing.UseBackColor = false;
            this.NRDISC1.ParentStyleUsing.UseBorderColor = false;
            this.NRDISC1.ParentStyleUsing.UseBorders = false;
            this.NRDISC1.ParentStyleUsing.UseBorderWidth = false;
            this.NRDISC1.ParentStyleUsing.UseFont = false;
            this.NRDISC1.ParentStyleUsing.UseForeColor = false;
            this.NRDISC1.Size = new System.Drawing.Size(65, 12);
            this.NRDISC1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // RACE1
            // 
            this.RACE1.BackColor = System.Drawing.Color.White;
            this.RACE1.BorderColor = System.Drawing.Color.Black;
            this.RACE1.CanGrow = false;
            this.RACE1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.RACE", "")});
            this.RACE1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.RACE1.ForeColor = System.Drawing.Color.Black;
            this.RACE1.Location = new System.Drawing.Point(525, 1);
            this.RACE1.Name = "RACE1";
            this.RACE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RACE1.ParentStyleUsing.UseBackColor = false;
            this.RACE1.ParentStyleUsing.UseBorderColor = false;
            this.RACE1.ParentStyleUsing.UseBorders = false;
            this.RACE1.ParentStyleUsing.UseBorderWidth = false;
            this.RACE1.ParentStyleUsing.UseFont = false;
            this.RACE1.ParentStyleUsing.UseForeColor = false;
            this.RACE1.Size = new System.Drawing.Size(67, 11);
            this.RACE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // CARDNAME1
            // 
            this.CARDNAME1.BackColor = System.Drawing.Color.White;
            this.CARDNAME1.BorderColor = System.Drawing.Color.Black;
            this.CARDNAME1.CanGrow = false;
            this.CARDNAME1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.CARD_NAME", "")});
            this.CARDNAME1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.CARDNAME1.ForeColor = System.Drawing.Color.Black;
            this.CARDNAME1.Location = new System.Drawing.Point(333, 1);
            this.CARDNAME1.Name = "CARDNAME1";
            this.CARDNAME1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CARDNAME1.ParentStyleUsing.UseBackColor = false;
            this.CARDNAME1.ParentStyleUsing.UseBorderColor = false;
            this.CARDNAME1.ParentStyleUsing.UseBorders = false;
            this.CARDNAME1.ParentStyleUsing.UseBorderWidth = false;
            this.CARDNAME1.ParentStyleUsing.UseFont = false;
            this.CARDNAME1.ParentStyleUsing.UseForeColor = false;
            this.CARDNAME1.Size = new System.Drawing.Size(191, 12);
            // 
            // NETSALES1
            // 
            this.NETSALES1.BackColor = System.Drawing.Color.White;
            this.NETSALES1.BorderColor = System.Drawing.Color.Black;
            this.NETSALES1.CanGrow = false;
            this.NETSALES1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.NETSALES", "")});
            this.NETSALES1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.NETSALES1.ForeColor = System.Drawing.Color.Black;
            this.NETSALES1.Location = new System.Drawing.Point(250, 1);
            this.NETSALES1.Name = "NETSALES1";
            this.NETSALES1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NETSALES1.ParentStyleUsing.UseBackColor = false;
            this.NETSALES1.ParentStyleUsing.UseBorderColor = false;
            this.NETSALES1.ParentStyleUsing.UseBorders = false;
            this.NETSALES1.ParentStyleUsing.UseBorderWidth = false;
            this.NETSALES1.ParentStyleUsing.UseFont = false;
            this.NETSALES1.ParentStyleUsing.UseForeColor = false;
            this.NETSALES1.Size = new System.Drawing.Size(75, 12);
            this.NETSALES1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // GROUP1
            // 
            this.GROUP1.BackColor = System.Drawing.Color.White;
            this.GROUP1.BorderColor = System.Drawing.Color.Black;
            this.GROUP1.CanGrow = false;
            this.GROUP1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.GROUP", "")});
            this.GROUP1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.GROUP1.ForeColor = System.Drawing.Color.Black;
            this.GROUP1.Location = new System.Drawing.Point(183, 1);
            this.GROUP1.Name = "GROUP1";
            this.GROUP1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GROUP1.ParentStyleUsing.UseBackColor = false;
            this.GROUP1.ParentStyleUsing.UseBorderColor = false;
            this.GROUP1.ParentStyleUsing.UseBorders = false;
            this.GROUP1.ParentStyleUsing.UseBorderWidth = false;
            this.GROUP1.ParentStyleUsing.UseFont = false;
            this.GROUP1.ParentStyleUsing.UseForeColor = false;
            this.GROUP1.Size = new System.Drawing.Size(67, 11);
            // 
            // DATECOMM1
            // 
            this.DATECOMM1.BackColor = System.Drawing.Color.White;
            this.DATECOMM1.BorderColor = System.Drawing.Color.Black;
            this.DATECOMM1.CanGrow = false;
            this.DATECOMM1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.DATE_COMM", "")});
            this.DATECOMM1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.DATECOMM1.ForeColor = System.Drawing.Color.Black;
            this.DATECOMM1.Location = new System.Drawing.Point(96, 1);
            this.DATECOMM1.Name = "DATECOMM1";
            this.DATECOMM1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DATECOMM1.ParentStyleUsing.UseBackColor = false;
            this.DATECOMM1.ParentStyleUsing.UseBorderColor = false;
            this.DATECOMM1.ParentStyleUsing.UseBorders = false;
            this.DATECOMM1.ParentStyleUsing.UseBorderWidth = false;
            this.DATECOMM1.ParentStyleUsing.UseFont = false;
            this.DATECOMM1.ParentStyleUsing.UseForeColor = false;
            this.DATECOMM1.Size = new System.Drawing.Size(83, 11);
            // 
            // VIPNO1
            // 
            this.VIPNO1.BackColor = System.Drawing.Color.White;
            this.VIPNO1.BorderColor = System.Drawing.Color.Black;
            this.VIPNO1.CanGrow = false;
            this.VIPNO1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.VIPNO", "")});
            this.VIPNO1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.VIPNO1.ForeColor = System.Drawing.Color.Black;
            this.VIPNO1.Location = new System.Drawing.Point(8, 1);
            this.VIPNO1.Name = "VIPNO1";
            this.VIPNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VIPNO1.ParentStyleUsing.UseBackColor = false;
            this.VIPNO1.ParentStyleUsing.UseBorderColor = false;
            this.VIPNO1.ParentStyleUsing.UseBorders = false;
            this.VIPNO1.ParentStyleUsing.UseBorderWidth = false;
            this.VIPNO1.ParentStyleUsing.UseFont = false;
            this.VIPNO1.ParentStyleUsing.UseForeColor = false;
            this.VIPNO1.Size = new System.Drawing.Size(83, 12);
            // 
            // Text17
            // 
            this.Text17.BackColor = System.Drawing.Color.White;
            this.Text17.BorderColor = System.Drawing.Color.Black;
            this.Text17.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.Text17.CanGrow = false;
            this.Text17.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.Text17.ForeColor = System.Drawing.Color.Black;
            this.Text17.Location = new System.Drawing.Point(666, 1);
            this.Text17.Name = "Text17";
            this.Text17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text17.ParentStyleUsing.UseBackColor = false;
            this.Text17.ParentStyleUsing.UseBorderColor = false;
            this.Text17.ParentStyleUsing.UseBorders = false;
            this.Text17.ParentStyleUsing.UseBorderWidth = false;
            this.Text17.ParentStyleUsing.UseFont = false;
            this.Text17.ParentStyleUsing.UseForeColor = false;
            this.Text17.Size = new System.Drawing.Size(100, 12);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 15;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPageInfo1,
            this.hdrCompName1,
            this.TotAMT1,
            this.Text16,
            this.PrintDate1,
            this.Text14,
            this.Text13,
            this.hdToVIPNo1,
            this.hdFmVIPNo1,
            this.Text12,
            this.Text11,
            this.Text10,
            this.Text9,
            this.Text8,
            this.Text7,
            this.Text6,
            this.Text5,
            this.Text4,
            this.Text3,
            this.Text2,
            this.Text1});
            this.PageHeader.Height = 138;
            this.PageHeader.Name = "PageHeader";
            // 
            // xrPageInfo1
            // 
            this.xrPageInfo1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.xrPageInfo1.Location = new System.Drawing.Point(592, 58);
            this.xrPageInfo1.Name = "xrPageInfo1";
            this.xrPageInfo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrPageInfo1.ParentStyleUsing.UseFont = false;
            this.xrPageInfo1.Size = new System.Drawing.Size(100, 12);
            // 
            // hdrCompName1
            // 
            this.hdrCompName1.BackColor = System.Drawing.Color.White;
            this.hdrCompName1.BorderColor = System.Drawing.Color.Black;
            this.hdrCompName1.CanGrow = false;
            this.hdrCompName1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.hdrCompName1.ForeColor = System.Drawing.Color.Black;
            this.hdrCompName1.Location = new System.Drawing.Point(8, 0);
            this.hdrCompName1.Name = "hdrCompName1";
            this.hdrCompName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdrCompName1.ParentStyleUsing.UseBackColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorders = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderWidth = false;
            this.hdrCompName1.ParentStyleUsing.UseFont = false;
            this.hdrCompName1.ParentStyleUsing.UseForeColor = false;
            this.hdrCompName1.Size = new System.Drawing.Size(758, 21);
            // 
            // TotAMT1
            // 
            this.TotAMT1.BackColor = System.Drawing.Color.White;
            this.TotAMT1.BorderColor = System.Drawing.Color.Black;
            this.TotAMT1.CanGrow = false;
            this.TotAMT1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.TotAMT1.ForeColor = System.Drawing.Color.Black;
            this.TotAMT1.Location = new System.Drawing.Point(175, 73);
            this.TotAMT1.Name = "TotAMT1";
            this.TotAMT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotAMT1.ParentStyleUsing.UseBackColor = false;
            this.TotAMT1.ParentStyleUsing.UseBorderColor = false;
            this.TotAMT1.ParentStyleUsing.UseBorders = false;
            this.TotAMT1.ParentStyleUsing.UseBorderWidth = false;
            this.TotAMT1.ParentStyleUsing.UseFont = false;
            this.TotAMT1.ParentStyleUsing.UseForeColor = false;
            this.TotAMT1.Size = new System.Drawing.Size(250, 13);
            // 
            // Text16
            // 
            this.Text16.BackColor = System.Drawing.Color.White;
            this.Text16.BorderColor = System.Drawing.Color.Black;
            this.Text16.CanGrow = false;
            this.Text16.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text16.ForeColor = System.Drawing.Color.Black;
            this.Text16.Location = new System.Drawing.Point(8, 73);
            this.Text16.Name = "Text16";
            this.Text16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text16.ParentStyleUsing.UseBackColor = false;
            this.Text16.ParentStyleUsing.UseBorderColor = false;
            this.Text16.ParentStyleUsing.UseBorders = false;
            this.Text16.ParentStyleUsing.UseBorderWidth = false;
            this.Text16.ParentStyleUsing.UseFont = false;
            this.Text16.ParentStyleUsing.UseForeColor = false;
            this.Text16.Size = new System.Drawing.Size(167, 12);
            this.Text16.Text = "Total Net Sales amount over :";
            // 
            // PrintDate1
            // 
            this.PrintDate1.BackColor = System.Drawing.Color.White;
            this.PrintDate1.BorderColor = System.Drawing.Color.Black;
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.PrintDate1.ForeColor = System.Drawing.Color.Black;
            this.PrintDate1.Location = new System.Drawing.Point(591, 42);
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrintDate1.ParentStyleUsing.UseBackColor = false;
            this.PrintDate1.ParentStyleUsing.UseBorderColor = false;
            this.PrintDate1.ParentStyleUsing.UseBorders = false;
            this.PrintDate1.ParentStyleUsing.UseBorderWidth = false;
            this.PrintDate1.ParentStyleUsing.UseFont = false;
            this.PrintDate1.ParentStyleUsing.UseForeColor = false;
            this.PrintDate1.Size = new System.Drawing.Size(100, 12);
            // 
            // Text14
            // 
            this.Text14.BackColor = System.Drawing.Color.White;
            this.Text14.BorderColor = System.Drawing.Color.Black;
            this.Text14.CanGrow = false;
            this.Text14.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text14.ForeColor = System.Drawing.Color.Black;
            this.Text14.Location = new System.Drawing.Point(487, 57);
            this.Text14.Name = "Text14";
            this.Text14.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text14.ParentStyleUsing.UseBackColor = false;
            this.Text14.ParentStyleUsing.UseBorderColor = false;
            this.Text14.ParentStyleUsing.UseBorders = false;
            this.Text14.ParentStyleUsing.UseBorderWidth = false;
            this.Text14.ParentStyleUsing.UseFont = false;
            this.Text14.ParentStyleUsing.UseForeColor = false;
            this.Text14.Size = new System.Drawing.Size(91, 12);
            this.Text14.Text = "Page:";
            // 
            // Text13
            // 
            this.Text13.BackColor = System.Drawing.Color.White;
            this.Text13.BorderColor = System.Drawing.Color.Black;
            this.Text13.CanGrow = false;
            this.Text13.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text13.ForeColor = System.Drawing.Color.Black;
            this.Text13.Location = new System.Drawing.Point(487, 42);
            this.Text13.Name = "Text13";
            this.Text13.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text13.ParentStyleUsing.UseBackColor = false;
            this.Text13.ParentStyleUsing.UseBorderColor = false;
            this.Text13.ParentStyleUsing.UseBorders = false;
            this.Text13.ParentStyleUsing.UseBorderWidth = false;
            this.Text13.ParentStyleUsing.UseFont = false;
            this.Text13.ParentStyleUsing.UseForeColor = false;
            this.Text13.Size = new System.Drawing.Size(91, 12);
            this.Text13.Text = "Print At :";
            // 
            // hdToVIPNo1
            // 
            this.hdToVIPNo1.BackColor = System.Drawing.Color.White;
            this.hdToVIPNo1.BorderColor = System.Drawing.Color.Black;
            this.hdToVIPNo1.CanGrow = false;
            this.hdToVIPNo1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.hdToVIPNo1.ForeColor = System.Drawing.Color.Black;
            this.hdToVIPNo1.Location = new System.Drawing.Point(97, 59);
            this.hdToVIPNo1.Name = "hdToVIPNo1";
            this.hdToVIPNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdToVIPNo1.ParentStyleUsing.UseBackColor = false;
            this.hdToVIPNo1.ParentStyleUsing.UseBorderColor = false;
            this.hdToVIPNo1.ParentStyleUsing.UseBorders = false;
            this.hdToVIPNo1.ParentStyleUsing.UseBorderWidth = false;
            this.hdToVIPNo1.ParentStyleUsing.UseFont = false;
            this.hdToVIPNo1.ParentStyleUsing.UseForeColor = false;
            this.hdToVIPNo1.Size = new System.Drawing.Size(291, 12);
            // 
            // hdFmVIPNo1
            // 
            this.hdFmVIPNo1.BackColor = System.Drawing.Color.White;
            this.hdFmVIPNo1.BorderColor = System.Drawing.Color.Black;
            this.hdFmVIPNo1.CanGrow = false;
            this.hdFmVIPNo1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.hdFmVIPNo1.ForeColor = System.Drawing.Color.Black;
            this.hdFmVIPNo1.Location = new System.Drawing.Point(97, 44);
            this.hdFmVIPNo1.Name = "hdFmVIPNo1";
            this.hdFmVIPNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdFmVIPNo1.ParentStyleUsing.UseBackColor = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseBorderColor = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseBorders = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseBorderWidth = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseFont = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseForeColor = false;
            this.hdFmVIPNo1.Size = new System.Drawing.Size(291, 13);
            // 
            // Text12
            // 
            this.Text12.BackColor = System.Drawing.Color.White;
            this.Text12.BorderColor = System.Drawing.Color.Black;
            this.Text12.CanGrow = false;
            this.Text12.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text12.ForeColor = System.Drawing.Color.Black;
            this.Text12.Location = new System.Drawing.Point(8, 59);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.ParentStyleUsing.UseBackColor = false;
            this.Text12.ParentStyleUsing.UseBorderColor = false;
            this.Text12.ParentStyleUsing.UseBorders = false;
            this.Text12.ParentStyleUsing.UseBorderWidth = false;
            this.Text12.ParentStyleUsing.UseFont = false;
            this.Text12.ParentStyleUsing.UseForeColor = false;
            this.Text12.Size = new System.Drawing.Size(83, 12);
            this.Text12.Text = "To VIP#   :";
            // 
            // Text11
            // 
            this.Text11.BackColor = System.Drawing.Color.White;
            this.Text11.BorderColor = System.Drawing.Color.Black;
            this.Text11.CanGrow = false;
            this.Text11.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text11.ForeColor = System.Drawing.Color.Black;
            this.Text11.Location = new System.Drawing.Point(8, 44);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.ParentStyleUsing.UseBackColor = false;
            this.Text11.ParentStyleUsing.UseBorderColor = false;
            this.Text11.ParentStyleUsing.UseBorders = false;
            this.Text11.ParentStyleUsing.UseBorderWidth = false;
            this.Text11.ParentStyleUsing.UseFont = false;
            this.Text11.ParentStyleUsing.UseForeColor = false;
            this.Text11.Size = new System.Drawing.Size(83, 12);
            this.Text11.Text = "From VIP# :";
            // 
            // Text10
            // 
            this.Text10.BackColor = System.Drawing.Color.White;
            this.Text10.BorderColor = System.Drawing.Color.Black;
            this.Text10.CanGrow = false;
            this.Text10.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.Text10.ForeColor = System.Drawing.Color.Black;
            this.Text10.Location = new System.Drawing.Point(8, 22);
            this.Text10.Name = "Text10";
            this.Text10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text10.ParentStyleUsing.UseBackColor = false;
            this.Text10.ParentStyleUsing.UseBorderColor = false;
            this.Text10.ParentStyleUsing.UseBorders = false;
            this.Text10.ParentStyleUsing.UseBorderWidth = false;
            this.Text10.ParentStyleUsing.UseFont = false;
            this.Text10.ParentStyleUsing.UseForeColor = false;
            this.Text10.Size = new System.Drawing.Size(316, 15);
            this.Text10.Text = "VIP MATURE LIST";
            // 
            // Text9
            // 
            this.Text9.BackColor = System.Drawing.Color.White;
            this.Text9.BorderColor = System.Drawing.Color.Black;
            this.Text9.CanGrow = false;
            this.Text9.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text9.ForeColor = System.Drawing.Color.Black;
            this.Text9.Location = new System.Drawing.Point(96, 124);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.ParentStyleUsing.UseBackColor = false;
            this.Text9.ParentStyleUsing.UseBorderColor = false;
            this.Text9.ParentStyleUsing.UseBorders = false;
            this.Text9.ParentStyleUsing.UseBorderWidth = false;
            this.Text9.ParentStyleUsing.UseFont = false;
            this.Text9.ParentStyleUsing.UseForeColor = false;
            this.Text9.Size = new System.Drawing.Size(83, 12);
            this.Text9.Text = "DATE";
            // 
            // Text8
            // 
            this.Text8.BackColor = System.Drawing.Color.White;
            this.Text8.BorderColor = System.Drawing.Color.Black;
            this.Text8.CanGrow = false;
            this.Text8.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text8.ForeColor = System.Drawing.Color.Black;
            this.Text8.Location = new System.Drawing.Point(666, 123);
            this.Text8.Name = "Text8";
            this.Text8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text8.ParentStyleUsing.UseBackColor = false;
            this.Text8.ParentStyleUsing.UseBorderColor = false;
            this.Text8.ParentStyleUsing.UseBorders = false;
            this.Text8.ParentStyleUsing.UseBorderWidth = false;
            this.Text8.ParentStyleUsing.UseFont = false;
            this.Text8.ParentStyleUsing.UseForeColor = false;
            this.Text8.Size = new System.Drawing.Size(100, 11);
            this.Text8.Text = "NEW VIP#";
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.White;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.CanGrow = false;
            this.Text7.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.Location = new System.Drawing.Point(593, 123);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.ParentStyleUsing.UseBackColor = false;
            this.Text7.ParentStyleUsing.UseBorderColor = false;
            this.Text7.ParentStyleUsing.UseBorders = false;
            this.Text7.ParentStyleUsing.UseBorderWidth = false;
            this.Text7.ParentStyleUsing.UseFont = false;
            this.Text7.ParentStyleUsing.UseForeColor = false;
            this.Text7.Size = new System.Drawing.Size(66, 12);
            this.Text7.Text = "DISC%";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text6
            // 
            this.Text6.BackColor = System.Drawing.Color.White;
            this.Text6.BorderColor = System.Drawing.Color.Black;
            this.Text6.CanGrow = false;
            this.Text6.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text6.ForeColor = System.Drawing.Color.Black;
            this.Text6.Location = new System.Drawing.Point(525, 123);
            this.Text6.Name = "Text6";
            this.Text6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text6.ParentStyleUsing.UseBackColor = false;
            this.Text6.ParentStyleUsing.UseBorderColor = false;
            this.Text6.ParentStyleUsing.UseBorders = false;
            this.Text6.ParentStyleUsing.UseBorderWidth = false;
            this.Text6.ParentStyleUsing.UseFont = false;
            this.Text6.ParentStyleUsing.UseForeColor = false;
            this.Text6.Size = new System.Drawing.Size(67, 12);
            this.Text6.Text = "RACE";
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.White;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.CanGrow = false;
            this.Text5.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.Location = new System.Drawing.Point(183, 125);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.ParentStyleUsing.UseBackColor = false;
            this.Text5.ParentStyleUsing.UseBorderColor = false;
            this.Text5.ParentStyleUsing.UseBorders = false;
            this.Text5.ParentStyleUsing.UseBorderWidth = false;
            this.Text5.ParentStyleUsing.UseFont = false;
            this.Text5.ParentStyleUsing.UseForeColor = false;
            this.Text5.Size = new System.Drawing.Size(67, 13);
            this.Text5.Text = "GROUP";
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.White;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.CanGrow = false;
            this.Text4.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.Location = new System.Drawing.Point(250, 123);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.ParentStyleUsing.UseBackColor = false;
            this.Text4.ParentStyleUsing.UseBorderColor = false;
            this.Text4.ParentStyleUsing.UseBorders = false;
            this.Text4.ParentStyleUsing.UseBorderWidth = false;
            this.Text4.ParentStyleUsing.UseFont = false;
            this.Text4.ParentStyleUsing.UseForeColor = false;
            this.Text4.Size = new System.Drawing.Size(75, 12);
            this.Text4.Text = "NET SALES";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.White;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.CanGrow = false;
            this.Text3.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.Location = new System.Drawing.Point(333, 123);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.ParentStyleUsing.UseBackColor = false;
            this.Text3.ParentStyleUsing.UseBorderColor = false;
            this.Text3.ParentStyleUsing.UseBorders = false;
            this.Text3.ParentStyleUsing.UseBorderWidth = false;
            this.Text3.ParentStyleUsing.UseFont = false;
            this.Text3.ParentStyleUsing.UseForeColor = false;
            this.Text3.Size = new System.Drawing.Size(191, 12);
            this.Text3.Text = "CARD NAME";
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.White;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.CanGrow = false;
            this.Text2.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.Location = new System.Drawing.Point(108, 107);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.ParentStyleUsing.UseBackColor = false;
            this.Text2.ParentStyleUsing.UseBorderColor = false;
            this.Text2.ParentStyleUsing.UseBorders = false;
            this.Text2.ParentStyleUsing.UseBorderWidth = false;
            this.Text2.ParentStyleUsing.UseFont = false;
            this.Text2.ParentStyleUsing.UseForeColor = false;
            this.Text2.Size = new System.Drawing.Size(100, 15);
            this.Text2.Text = "COMMENCEMENT";
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.White;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.CanGrow = false;
            this.Text1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.Location = new System.Drawing.Point(8, 123);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.ParentStyleUsing.UseBackColor = false;
            this.Text1.ParentStyleUsing.UseBorderColor = false;
            this.Text1.ParentStyleUsing.UseBorders = false;
            this.Text1.ParentStyleUsing.UseBorderWidth = false;
            this.Text1.ParentStyleUsing.UseFont = false;
            this.Text1.ParentStyleUsing.UseForeColor = false;
            this.Text1.Size = new System.Drawing.Size(83, 13);
            this.Text1.Text = "VIPNO";
            // 
            // PageFooter
            // 
            this.PageFooter.Height = 0;
            this.PageFooter.Name = "PageFooter";
            // 
            // VipMatureListRpt
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupHeader1,
            this.GroupFooter1,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 0);
            this.PageHeight = 1169;
            this.PageWidth = 826;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.VipMatureListRpt_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel NRDISC1;
        private DevExpress.XtraReports.UI.XRLabel RACE1;
        private DevExpress.XtraReports.UI.XRLabel CARDNAME1;
        private DevExpress.XtraReports.UI.XRLabel NETSALES1;
        private DevExpress.XtraReports.UI.XRLabel GROUP1;
        private DevExpress.XtraReports.UI.XRLabel DATECOMM1;
        private DevExpress.XtraReports.UI.XRLabel VIPNO1;
        private DevExpress.XtraReports.UI.XRLabel Text17;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel hdrCompName1;
        private DevExpress.XtraReports.UI.XRLabel TotAMT1;
        private DevExpress.XtraReports.UI.XRLabel Text16;
        private DevExpress.XtraReports.UI.XRLabel PrintDate1;
        private DevExpress.XtraReports.UI.XRLabel Text14;
        private DevExpress.XtraReports.UI.XRLabel Text13;
        private DevExpress.XtraReports.UI.XRLabel hdToVIPNo1;
        private DevExpress.XtraReports.UI.XRLabel hdFmVIPNo1;
        private DevExpress.XtraReports.UI.XRLabel Text12;
        private DevExpress.XtraReports.UI.XRLabel Text11;
        private DevExpress.XtraReports.UI.XRLabel Text10;
        private DevExpress.XtraReports.UI.XRLabel Text9;
        private DevExpress.XtraReports.UI.XRLabel Text8;
        private DevExpress.XtraReports.UI.XRLabel Text7;
        private DevExpress.XtraReports.UI.XRLabel Text6;
        private DevExpress.XtraReports.UI.XRLabel Text5;
        private DevExpress.XtraReports.UI.XRLabel Text4;
        private DevExpress.XtraReports.UI.XRLabel Text3;
        private DevExpress.XtraReports.UI.XRLabel Text2;
        private DevExpress.XtraReports.UI.XRLabel Text1;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRPageInfo xrPageInfo1;

    }
}
