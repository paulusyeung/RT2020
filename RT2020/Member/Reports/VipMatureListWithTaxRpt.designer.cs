namespace RT2020.Member.Reports
{
    partial class VipMatureListWithTaxRpt
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
            this.oleDbDataAdapter1 = new System.Data.OleDb.OleDbDataAdapter();
            this.oleDbCommand1 = new System.Data.OleDb.OleDbCommand();
            this.oleDbConnection1 = new System.Data.OleDb.OleDbConnection();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.Text19 = new DevExpress.XtraReports.UI.XRLabel();
            this.VIPNO1 = new DevExpress.XtraReports.UI.XRLabel();
            this.DATECOMM1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GROUP1 = new DevExpress.XtraReports.UI.XRLabel();
            this.NETSALES1 = new DevExpress.XtraReports.UI.XRLabel();
            this.RACE1 = new DevExpress.XtraReports.UI.XRLabel();
            this.NRDISC1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TOTNETSALES1 = new DevExpress.XtraReports.UI.XRLabel();
            this.TOTTAX1 = new DevExpress.XtraReports.UI.XRLabel();
            this.CARDNAME1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.Text1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text2 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text3 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text4 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text5 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text6 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text7 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text8 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text9 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text10 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text11 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text12 = new DevExpress.XtraReports.UI.XRLabel();
            this.hdFmVIPNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.hdToVIPNo1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text13 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text14 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageNumber1 = new DevExpress.XtraReports.UI.XRPageInfo();
            this.Text15 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotalPageCount1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrintDate1 = new DevExpress.XtraReports.UI.XRLabel();
            this.PrintTime1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text16 = new DevExpress.XtraReports.UI.XRLabel();
            this.TotAMT1 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text17 = new DevExpress.XtraReports.UI.XRLabel();
            this.Text18 = new DevExpress.XtraReports.UI.XRLabel();
            this.hdrCompName1 = new DevExpress.XtraReports.UI.XRLabel();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xCont1 = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Height = 38;
            this.Detail.Name = "Detail";
            this.Detail.Visible = false;
            // 
            // oleDbDataAdapter1
            // 
            this.oleDbDataAdapter1.SelectCommand = this.oleDbCommand1;
            this.oleDbDataAdapter1.TableMappings.AddRange(new System.Data.Common.DataTableMapping[] {
            new System.Data.Common.DataTableMapping("Table", "tblVIP", new System.Data.Common.DataColumnMapping[0])});
            // 
            // oleDbCommand1
            // 
            this.oleDbCommand1.CommandText = "SELECT * FROM tblVIP";
            this.oleDbCommand1.Connection = this.oleDbConnection1;
            // 
            // oleDbConnection1
            // 
            this.oleDbConnection1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=.\\rptVIP2300.mdb";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.CARDNAME1,
            this.TOTTAX1,
            this.TOTNETSALES1,
            this.NRDISC1,
            this.RACE1,
            this.NETSALES1,
            this.GROUP1,
            this.DATECOMM1,
            this.VIPNO1,
            this.Text19});
            this.GroupHeader1.GroupFields.AddRange(new DevExpress.XtraReports.UI.GroupField[] {
            new DevExpress.XtraReports.UI.GroupField("VIPNO", DevExpress.XtraReports.UI.XRColumnSortOrder.Ascending)});
            this.GroupHeader1.Height = 16;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // Text19
            // 
            this.Text19.BackColor = System.Drawing.Color.White;
            this.Text19.BorderColor = System.Drawing.Color.Black;
            this.Text19.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.Text19.CanGrow = false;
            this.Text19.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.Text19.ForeColor = System.Drawing.Color.Black;
            this.Text19.Location = new System.Drawing.Point(699, 1);
            this.Text19.Name = "Text19";
            this.Text19.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text19.ParentStyleUsing.UseBackColor = false;
            this.Text19.ParentStyleUsing.UseBorderColor = false;
            this.Text19.ParentStyleUsing.UseBorders = false;
            this.Text19.ParentStyleUsing.UseBorderWidth = false;
            this.Text19.ParentStyleUsing.UseFont = false;
            this.Text19.ParentStyleUsing.UseForeColor = false;
            this.Text19.Size = new System.Drawing.Size(71, 12);
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
            this.VIPNO1.Location = new System.Drawing.Point(0, 1);
            this.VIPNO1.Name = "VIPNO1";
            this.VIPNO1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.VIPNO1.ParentStyleUsing.UseBackColor = false;
            this.VIPNO1.ParentStyleUsing.UseBorderColor = false;
            this.VIPNO1.ParentStyleUsing.UseBorders = false;
            this.VIPNO1.ParentStyleUsing.UseBorderWidth = false;
            this.VIPNO1.ParentStyleUsing.UseFont = false;
            this.VIPNO1.ParentStyleUsing.UseForeColor = false;
            this.VIPNO1.Size = new System.Drawing.Size(90, 12);
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
            this.DATECOMM1.Location = new System.Drawing.Point(90, 1);
            this.DATECOMM1.Name = "DATECOMM1";
            this.DATECOMM1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.DATECOMM1.ParentStyleUsing.UseBackColor = false;
            this.DATECOMM1.ParentStyleUsing.UseBorderColor = false;
            this.DATECOMM1.ParentStyleUsing.UseBorders = false;
            this.DATECOMM1.ParentStyleUsing.UseBorderWidth = false;
            this.DATECOMM1.ParentStyleUsing.UseFont = false;
            this.DATECOMM1.ParentStyleUsing.UseForeColor = false;
            this.DATECOMM1.Size = new System.Drawing.Size(88, 12);
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
            this.GROUP1.Location = new System.Drawing.Point(178, 1);
            this.GROUP1.Name = "GROUP1";
            this.GROUP1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.GROUP1.ParentStyleUsing.UseBackColor = false;
            this.GROUP1.ParentStyleUsing.UseBorderColor = false;
            this.GROUP1.ParentStyleUsing.UseBorders = false;
            this.GROUP1.ParentStyleUsing.UseBorderWidth = false;
            this.GROUP1.ParentStyleUsing.UseFont = false;
            this.GROUP1.ParentStyleUsing.UseForeColor = false;
            this.GROUP1.Size = new System.Drawing.Size(36, 12);
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
            this.NETSALES1.Location = new System.Drawing.Point(215, 1);
            this.NETSALES1.Name = "NETSALES1";
            this.NETSALES1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NETSALES1.ParentStyleUsing.UseBackColor = false;
            this.NETSALES1.ParentStyleUsing.UseBorderColor = false;
            this.NETSALES1.ParentStyleUsing.UseBorders = false;
            this.NETSALES1.ParentStyleUsing.UseBorderWidth = false;
            this.NETSALES1.ParentStyleUsing.UseFont = false;
            this.NETSALES1.ParentStyleUsing.UseForeColor = false;
            this.NETSALES1.Size = new System.Drawing.Size(74, 12);
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
            this.RACE1.Location = new System.Drawing.Point(619, 1);
            this.RACE1.Name = "RACE1";
            this.RACE1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.RACE1.ParentStyleUsing.UseBackColor = false;
            this.RACE1.ParentStyleUsing.UseBorderColor = false;
            this.RACE1.ParentStyleUsing.UseBorders = false;
            this.RACE1.ParentStyleUsing.UseBorderWidth = false;
            this.RACE1.ParentStyleUsing.UseFont = false;
            this.RACE1.ParentStyleUsing.UseForeColor = false;
            this.RACE1.Size = new System.Drawing.Size(30, 12);
            this.RACE1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
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
            this.NRDISC1.Location = new System.Drawing.Point(650, 1);
            this.NRDISC1.Name = "NRDISC1";
            this.NRDISC1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.NRDISC1.ParentStyleUsing.UseBackColor = false;
            this.NRDISC1.ParentStyleUsing.UseBorderColor = false;
            this.NRDISC1.ParentStyleUsing.UseBorders = false;
            this.NRDISC1.ParentStyleUsing.UseBorderWidth = false;
            this.NRDISC1.ParentStyleUsing.UseFont = false;
            this.NRDISC1.ParentStyleUsing.UseForeColor = false;
            this.NRDISC1.Size = new System.Drawing.Size(44, 12);
            // 
            // TOTNETSALES1
            // 
            this.TOTNETSALES1.BackColor = System.Drawing.Color.White;
            this.TOTNETSALES1.BorderColor = System.Drawing.Color.Black;
            this.TOTNETSALES1.CanGrow = false;
            this.TOTNETSALES1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.TOT_NETSALES", "")});
            this.TOTNETSALES1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.TOTNETSALES1.ForeColor = System.Drawing.Color.Black;
            this.TOTNETSALES1.Location = new System.Drawing.Point(290, 1);
            this.TOTNETSALES1.Name = "TOTNETSALES1";
            this.TOTNETSALES1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TOTNETSALES1.ParentStyleUsing.UseBackColor = false;
            this.TOTNETSALES1.ParentStyleUsing.UseBorderColor = false;
            this.TOTNETSALES1.ParentStyleUsing.UseBorders = false;
            this.TOTNETSALES1.ParentStyleUsing.UseBorderWidth = false;
            this.TOTNETSALES1.ParentStyleUsing.UseFont = false;
            this.TOTNETSALES1.ParentStyleUsing.UseForeColor = false;
            this.TOTNETSALES1.Size = new System.Drawing.Size(67, 12);
            // 
            // TOTTAX1
            // 
            this.TOTTAX1.BackColor = System.Drawing.Color.White;
            this.TOTTAX1.BorderColor = System.Drawing.Color.Black;
            this.TOTTAX1.CanGrow = false;
            this.TOTTAX1.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null, "tblVIP.TOT_TAX", "")});
            this.TOTTAX1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.TOTTAX1.ForeColor = System.Drawing.Color.Black;
            this.TOTTAX1.Location = new System.Drawing.Point(357, 1);
            this.TOTTAX1.Name = "TOTTAX1";
            this.TOTTAX1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TOTTAX1.ParentStyleUsing.UseBackColor = false;
            this.TOTTAX1.ParentStyleUsing.UseBorderColor = false;
            this.TOTTAX1.ParentStyleUsing.UseBorders = false;
            this.TOTTAX1.ParentStyleUsing.UseBorderWidth = false;
            this.TOTTAX1.ParentStyleUsing.UseFont = false;
            this.TOTTAX1.ParentStyleUsing.UseForeColor = false;
            this.TOTTAX1.Size = new System.Drawing.Size(67, 12);
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
            this.CARDNAME1.Location = new System.Drawing.Point(430, 1);
            this.CARDNAME1.Name = "CARDNAME1";
            this.CARDNAME1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.CARDNAME1.ParentStyleUsing.UseBackColor = false;
            this.CARDNAME1.ParentStyleUsing.UseBorderColor = false;
            this.CARDNAME1.ParentStyleUsing.UseBorders = false;
            this.CARDNAME1.ParentStyleUsing.UseBorderWidth = false;
            this.CARDNAME1.ParentStyleUsing.UseFont = false;
            this.CARDNAME1.ParentStyleUsing.UseForeColor = false;
            this.CARDNAME1.Size = new System.Drawing.Size(190, 12);
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Height = 15;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Height = 84;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.hdrCompName1,
            this.Text18,
            this.Text17,
            this.TotAMT1,
            this.Text16,
            this.PrintTime1,
            this.PrintDate1,
            this.TotalPageCount1,
            this.Text15,
            this.PageNumber1,
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
            this.PageHeader.Height = 133;
            this.PageHeader.Name = "PageHeader";
            // 
            // Text1
            // 
            this.Text1.BackColor = System.Drawing.Color.White;
            this.Text1.BorderColor = System.Drawing.Color.Black;
            this.Text1.CanGrow = false;
            this.Text1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text1.ForeColor = System.Drawing.Color.Black;
            this.Text1.Location = new System.Drawing.Point(0, 118);
            this.Text1.Name = "Text1";
            this.Text1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text1.ParentStyleUsing.UseBackColor = false;
            this.Text1.ParentStyleUsing.UseBorderColor = false;
            this.Text1.ParentStyleUsing.UseBorders = false;
            this.Text1.ParentStyleUsing.UseBorderWidth = false;
            this.Text1.ParentStyleUsing.UseFont = false;
            this.Text1.ParentStyleUsing.UseForeColor = false;
            this.Text1.Size = new System.Drawing.Size(90, 13);
            this.Text1.Text = "VIPNO";
            // 
            // Text2
            // 
            this.Text2.BackColor = System.Drawing.Color.White;
            this.Text2.BorderColor = System.Drawing.Color.Black;
            this.Text2.CanGrow = false;
            this.Text2.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text2.ForeColor = System.Drawing.Color.Black;
            this.Text2.Location = new System.Drawing.Point(90, 105);
            this.Text2.Name = "Text2";
            this.Text2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text2.ParentStyleUsing.UseBackColor = false;
            this.Text2.ParentStyleUsing.UseBorderColor = false;
            this.Text2.ParentStyleUsing.UseBorders = false;
            this.Text2.ParentStyleUsing.UseBorderWidth = false;
            this.Text2.ParentStyleUsing.UseFont = false;
            this.Text2.ParentStyleUsing.UseForeColor = false;
            this.Text2.Size = new System.Drawing.Size(88, 10);
            this.Text2.Text = "COMMENCEMENT";
            // 
            // Text3
            // 
            this.Text3.BackColor = System.Drawing.Color.White;
            this.Text3.BorderColor = System.Drawing.Color.Black;
            this.Text3.CanGrow = false;
            this.Text3.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text3.ForeColor = System.Drawing.Color.Black;
            this.Text3.Location = new System.Drawing.Point(430, 118);
            this.Text3.Name = "Text3";
            this.Text3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text3.ParentStyleUsing.UseBackColor = false;
            this.Text3.ParentStyleUsing.UseBorderColor = false;
            this.Text3.ParentStyleUsing.UseBorders = false;
            this.Text3.ParentStyleUsing.UseBorderWidth = false;
            this.Text3.ParentStyleUsing.UseFont = false;
            this.Text3.ParentStyleUsing.UseForeColor = false;
            this.Text3.Size = new System.Drawing.Size(190, 12);
            this.Text3.Text = "CARD NAME";
            // 
            // Text4
            // 
            this.Text4.BackColor = System.Drawing.Color.White;
            this.Text4.BorderColor = System.Drawing.Color.Black;
            this.Text4.CanGrow = false;
            this.Text4.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text4.ForeColor = System.Drawing.Color.Black;
            this.Text4.Location = new System.Drawing.Point(215, 118);
            this.Text4.Name = "Text4";
            this.Text4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text4.ParentStyleUsing.UseBackColor = false;
            this.Text4.ParentStyleUsing.UseBorderColor = false;
            this.Text4.ParentStyleUsing.UseBorders = false;
            this.Text4.ParentStyleUsing.UseBorderWidth = false;
            this.Text4.ParentStyleUsing.UseFont = false;
            this.Text4.ParentStyleUsing.UseForeColor = false;
            this.Text4.Size = new System.Drawing.Size(74, 12);
            this.Text4.Text = "NET SALES";
            this.Text4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text5
            // 
            this.Text5.BackColor = System.Drawing.Color.White;
            this.Text5.BorderColor = System.Drawing.Color.Black;
            this.Text5.CanGrow = false;
            this.Text5.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text5.ForeColor = System.Drawing.Color.Black;
            this.Text5.Location = new System.Drawing.Point(178, 120);
            this.Text5.Name = "Text5";
            this.Text5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text5.ParentStyleUsing.UseBackColor = false;
            this.Text5.ParentStyleUsing.UseBorderColor = false;
            this.Text5.ParentStyleUsing.UseBorders = false;
            this.Text5.ParentStyleUsing.UseBorderWidth = false;
            this.Text5.ParentStyleUsing.UseFont = false;
            this.Text5.ParentStyleUsing.UseForeColor = false;
            this.Text5.Size = new System.Drawing.Size(36, 12);
            this.Text5.Text = "GROUP";
            // 
            // Text6
            // 
            this.Text6.BackColor = System.Drawing.Color.White;
            this.Text6.BorderColor = System.Drawing.Color.Black;
            this.Text6.CanGrow = false;
            this.Text6.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text6.ForeColor = System.Drawing.Color.Black;
            this.Text6.Location = new System.Drawing.Point(619, 118);
            this.Text6.Name = "Text6";
            this.Text6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text6.ParentStyleUsing.UseBackColor = false;
            this.Text6.ParentStyleUsing.UseBorderColor = false;
            this.Text6.ParentStyleUsing.UseBorders = false;
            this.Text6.ParentStyleUsing.UseBorderWidth = false;
            this.Text6.ParentStyleUsing.UseFont = false;
            this.Text6.ParentStyleUsing.UseForeColor = false;
            this.Text6.Size = new System.Drawing.Size(30, 12);
            this.Text6.Text = "RACE";
            // 
            // Text7
            // 
            this.Text7.BackColor = System.Drawing.Color.White;
            this.Text7.BorderColor = System.Drawing.Color.Black;
            this.Text7.CanGrow = false;
            this.Text7.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text7.ForeColor = System.Drawing.Color.Black;
            this.Text7.Location = new System.Drawing.Point(650, 118);
            this.Text7.Name = "Text7";
            this.Text7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text7.ParentStyleUsing.UseBackColor = false;
            this.Text7.ParentStyleUsing.UseBorderColor = false;
            this.Text7.ParentStyleUsing.UseBorders = false;
            this.Text7.ParentStyleUsing.UseBorderWidth = false;
            this.Text7.ParentStyleUsing.UseFont = false;
            this.Text7.ParentStyleUsing.UseForeColor = false;
            this.Text7.Size = new System.Drawing.Size(44, 12);
            this.Text7.Text = "DISC%";
            this.Text7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text8
            // 
            this.Text8.BackColor = System.Drawing.Color.White;
            this.Text8.BorderColor = System.Drawing.Color.Black;
            this.Text8.CanGrow = false;
            this.Text8.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text8.ForeColor = System.Drawing.Color.Black;
            this.Text8.Location = new System.Drawing.Point(699, 118);
            this.Text8.Name = "Text8";
            this.Text8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text8.ParentStyleUsing.UseBackColor = false;
            this.Text8.ParentStyleUsing.UseBorderColor = false;
            this.Text8.ParentStyleUsing.UseBorders = false;
            this.Text8.ParentStyleUsing.UseBorderWidth = false;
            this.Text8.ParentStyleUsing.UseFont = false;
            this.Text8.ParentStyleUsing.UseForeColor = false;
            this.Text8.Size = new System.Drawing.Size(71, 11);
            this.Text8.Text = "NEW VIP#";
            // 
            // Text9
            // 
            this.Text9.BackColor = System.Drawing.Color.White;
            this.Text9.BorderColor = System.Drawing.Color.Black;
            this.Text9.CanGrow = false;
            this.Text9.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text9.ForeColor = System.Drawing.Color.Black;
            this.Text9.Location = new System.Drawing.Point(90, 120);
            this.Text9.Name = "Text9";
            this.Text9.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text9.ParentStyleUsing.UseBackColor = false;
            this.Text9.ParentStyleUsing.UseBorderColor = false;
            this.Text9.ParentStyleUsing.UseBorders = false;
            this.Text9.ParentStyleUsing.UseBorderWidth = false;
            this.Text9.ParentStyleUsing.UseFont = false;
            this.Text9.ParentStyleUsing.UseForeColor = false;
            this.Text9.Size = new System.Drawing.Size(88, 12);
            this.Text9.Text = "DATE";
            // 
            // Text10
            // 
            this.Text10.BackColor = System.Drawing.Color.White;
            this.Text10.BorderColor = System.Drawing.Color.Black;
            this.Text10.CanGrow = false;
            this.Text10.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.Text10.ForeColor = System.Drawing.Color.Black;
            this.Text10.Location = new System.Drawing.Point(0, 20);
            this.Text10.Name = "Text10";
            this.Text10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text10.ParentStyleUsing.UseBackColor = false;
            this.Text10.ParentStyleUsing.UseBorderColor = false;
            this.Text10.ParentStyleUsing.UseBorders = false;
            this.Text10.ParentStyleUsing.UseBorderWidth = false;
            this.Text10.ParentStyleUsing.UseFont = false;
            this.Text10.ParentStyleUsing.UseForeColor = false;
            this.Text10.Size = new System.Drawing.Size(380, 16);
            this.Text10.Text = "VIP2300T - VIP MATURE LIST (TAX)";
            // 
            // Text11
            // 
            this.Text11.BackColor = System.Drawing.Color.White;
            this.Text11.BorderColor = System.Drawing.Color.Black;
            this.Text11.CanGrow = false;
            this.Text11.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text11.ForeColor = System.Drawing.Color.Black;
            this.Text11.Location = new System.Drawing.Point(0, 41);
            this.Text11.Name = "Text11";
            this.Text11.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text11.ParentStyleUsing.UseBackColor = false;
            this.Text11.ParentStyleUsing.UseBorderColor = false;
            this.Text11.ParentStyleUsing.UseBorders = false;
            this.Text11.ParentStyleUsing.UseBorderWidth = false;
            this.Text11.ParentStyleUsing.UseFont = false;
            this.Text11.ParentStyleUsing.UseForeColor = false;
            this.Text11.Size = new System.Drawing.Size(90, 12);
            this.Text11.Text = "From VIP# :";
            // 
            // Text12
            // 
            this.Text12.BackColor = System.Drawing.Color.White;
            this.Text12.BorderColor = System.Drawing.Color.Black;
            this.Text12.CanGrow = false;
            this.Text12.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text12.ForeColor = System.Drawing.Color.Black;
            this.Text12.Location = new System.Drawing.Point(0, 57);
            this.Text12.Name = "Text12";
            this.Text12.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text12.ParentStyleUsing.UseBackColor = false;
            this.Text12.ParentStyleUsing.UseBorderColor = false;
            this.Text12.ParentStyleUsing.UseBorders = false;
            this.Text12.ParentStyleUsing.UseBorderWidth = false;
            this.Text12.ParentStyleUsing.UseFont = false;
            this.Text12.ParentStyleUsing.UseForeColor = false;
            this.Text12.Size = new System.Drawing.Size(90, 12);
            this.Text12.Text = "To VIP#   :";
            // 
            // hdFmVIPNo1
            // 
            this.hdFmVIPNo1.BackColor = System.Drawing.Color.White;
            this.hdFmVIPNo1.BorderColor = System.Drawing.Color.Black;
            this.hdFmVIPNo1.CanGrow = false;
            this.hdFmVIPNo1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.hdFmVIPNo1.ForeColor = System.Drawing.Color.Black;
            this.hdFmVIPNo1.Location = new System.Drawing.Point(90, 41);
            this.hdFmVIPNo1.Name = "hdFmVIPNo1";
            this.hdFmVIPNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdFmVIPNo1.ParentStyleUsing.UseBackColor = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseBorderColor = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseBorders = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseBorderWidth = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseFont = false;
            this.hdFmVIPNo1.ParentStyleUsing.UseForeColor = false;
            this.hdFmVIPNo1.Size = new System.Drawing.Size(291, 12);
            this.hdFmVIPNo1.Text = "Untranslated";
            // 
            // hdToVIPNo1
            // 
            this.hdToVIPNo1.BackColor = System.Drawing.Color.White;
            this.hdToVIPNo1.BorderColor = System.Drawing.Color.Black;
            this.hdToVIPNo1.CanGrow = false;
            this.hdToVIPNo1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.hdToVIPNo1.ForeColor = System.Drawing.Color.Black;
            this.hdToVIPNo1.Location = new System.Drawing.Point(90, 57);
            this.hdToVIPNo1.Name = "hdToVIPNo1";
            this.hdToVIPNo1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdToVIPNo1.ParentStyleUsing.UseBackColor = false;
            this.hdToVIPNo1.ParentStyleUsing.UseBorderColor = false;
            this.hdToVIPNo1.ParentStyleUsing.UseBorders = false;
            this.hdToVIPNo1.ParentStyleUsing.UseBorderWidth = false;
            this.hdToVIPNo1.ParentStyleUsing.UseFont = false;
            this.hdToVIPNo1.ParentStyleUsing.UseForeColor = false;
            this.hdToVIPNo1.Size = new System.Drawing.Size(291, 12);
            this.hdToVIPNo1.Text = "Untranslated";
            // 
            // Text13
            // 
            this.Text13.BackColor = System.Drawing.Color.White;
            this.Text13.BorderColor = System.Drawing.Color.Black;
            this.Text13.CanGrow = false;
            this.Text13.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text13.ForeColor = System.Drawing.Color.Black;
            this.Text13.Location = new System.Drawing.Point(523, 41);
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
            // Text14
            // 
            this.Text14.BackColor = System.Drawing.Color.White;
            this.Text14.BorderColor = System.Drawing.Color.Black;
            this.Text14.CanGrow = false;
            this.Text14.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text14.ForeColor = System.Drawing.Color.Black;
            this.Text14.Location = new System.Drawing.Point(523, 57);
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
            // PageNumber1
            // 
            this.PageNumber1.BackColor = System.Drawing.Color.White;
            this.PageNumber1.BorderColor = System.Drawing.Color.Black;
            this.PageNumber1.CanGrow = false;
            this.PageNumber1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.PageNumber1.ForeColor = System.Drawing.Color.Black;
            this.PageNumber1.Location = new System.Drawing.Point(615, 57);
            this.PageNumber1.Name = "PageNumber1";
            this.PageNumber1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PageNumber1.PageInfo = DevExpress.XtraPrinting.PageInfo.Number;
            this.PageNumber1.ParentStyleUsing.UseBackColor = false;
            this.PageNumber1.ParentStyleUsing.UseBorderColor = false;
            this.PageNumber1.ParentStyleUsing.UseBorders = false;
            this.PageNumber1.ParentStyleUsing.UseBorderWidth = false;
            this.PageNumber1.ParentStyleUsing.UseFont = false;
            this.PageNumber1.ParentStyleUsing.UseForeColor = false;
            this.PageNumber1.Size = new System.Drawing.Size(50, 12);
            this.PageNumber1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text15
            // 
            this.Text15.BackColor = System.Drawing.Color.White;
            this.Text15.BorderColor = System.Drawing.Color.Black;
            this.Text15.CanGrow = false;
            this.Text15.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text15.ForeColor = System.Drawing.Color.Black;
            this.Text15.Location = new System.Drawing.Point(690, 57);
            this.Text15.Name = "Text15";
            this.Text15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text15.ParentStyleUsing.UseBackColor = false;
            this.Text15.ParentStyleUsing.UseBorderColor = false;
            this.Text15.ParentStyleUsing.UseBorders = false;
            this.Text15.ParentStyleUsing.UseBorderWidth = false;
            this.Text15.ParentStyleUsing.UseFont = false;
            this.Text15.ParentStyleUsing.UseForeColor = false;
            this.Text15.Size = new System.Drawing.Size(19, 12);
            this.Text15.Text = "of";
            this.Text15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TotalPageCount1
            // 
            this.TotalPageCount1.BackColor = System.Drawing.Color.White;
            this.TotalPageCount1.BorderColor = System.Drawing.Color.Black;
            this.TotalPageCount1.CanGrow = false;
            this.TotalPageCount1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.TotalPageCount1.ForeColor = System.Drawing.Color.Black;
            this.TotalPageCount1.Location = new System.Drawing.Point(709, 57);
            this.TotalPageCount1.Name = "TotalPageCount1";
            this.TotalPageCount1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotalPageCount1.ParentStyleUsing.UseBackColor = false;
            this.TotalPageCount1.ParentStyleUsing.UseBorderColor = false;
            this.TotalPageCount1.ParentStyleUsing.UseBorders = false;
            this.TotalPageCount1.ParentStyleUsing.UseBorderWidth = false;
            this.TotalPageCount1.ParentStyleUsing.UseFont = false;
            this.TotalPageCount1.ParentStyleUsing.UseForeColor = false;
            this.TotalPageCount1.Size = new System.Drawing.Size(51, 12);
            this.TotalPageCount1.Text = "Untranslated";
            // 
            // PrintDate1
            // 
            this.PrintDate1.BackColor = System.Drawing.Color.White;
            this.PrintDate1.BorderColor = System.Drawing.Color.Black;
            this.PrintDate1.CanGrow = false;
            this.PrintDate1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.PrintDate1.ForeColor = System.Drawing.Color.Black;
            this.PrintDate1.Location = new System.Drawing.Point(615, 41);
            this.PrintDate1.Name = "PrintDate1";
            this.PrintDate1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrintDate1.ParentStyleUsing.UseBackColor = false;
            this.PrintDate1.ParentStyleUsing.UseBorderColor = false;
            this.PrintDate1.ParentStyleUsing.UseBorders = false;
            this.PrintDate1.ParentStyleUsing.UseBorderWidth = false;
            this.PrintDate1.ParentStyleUsing.UseFont = false;
            this.PrintDate1.ParentStyleUsing.UseForeColor = false;
            this.PrintDate1.Size = new System.Drawing.Size(75, 12);
            this.PrintDate1.Text = "Untranslated";
            this.PrintDate1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // PrintTime1
            // 
            this.PrintTime1.BackColor = System.Drawing.Color.White;
            this.PrintTime1.BorderColor = System.Drawing.Color.Black;
            this.PrintTime1.CanGrow = false;
            this.PrintTime1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.PrintTime1.ForeColor = System.Drawing.Color.Black;
            this.PrintTime1.Location = new System.Drawing.Point(690, 41);
            this.PrintTime1.Name = "PrintTime1";
            this.PrintTime1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.PrintTime1.ParentStyleUsing.UseBackColor = false;
            this.PrintTime1.ParentStyleUsing.UseBorderColor = false;
            this.PrintTime1.ParentStyleUsing.UseBorders = false;
            this.PrintTime1.ParentStyleUsing.UseBorderWidth = false;
            this.PrintTime1.ParentStyleUsing.UseFont = false;
            this.PrintTime1.ParentStyleUsing.UseForeColor = false;
            this.PrintTime1.Size = new System.Drawing.Size(77, 12);
            this.PrintTime1.Text = "Untranslated";
            this.PrintTime1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text16
            // 
            this.Text16.BackColor = System.Drawing.Color.White;
            this.Text16.BorderColor = System.Drawing.Color.Black;
            this.Text16.CanGrow = false;
            this.Text16.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text16.ForeColor = System.Drawing.Color.Black;
            this.Text16.Location = new System.Drawing.Point(0, 76);
            this.Text16.Name = "Text16";
            this.Text16.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text16.ParentStyleUsing.UseBackColor = false;
            this.Text16.ParentStyleUsing.UseBorderColor = false;
            this.Text16.ParentStyleUsing.UseBorders = false;
            this.Text16.ParentStyleUsing.UseBorderWidth = false;
            this.Text16.ParentStyleUsing.UseFont = false;
            this.Text16.ParentStyleUsing.UseForeColor = false;
            this.Text16.Size = new System.Drawing.Size(208, 12);
            this.Text16.Text = "Total Net Sales amount over :";
            // 
            // TotAMT1
            // 
            this.TotAMT1.BackColor = System.Drawing.Color.White;
            this.TotAMT1.BorderColor = System.Drawing.Color.Black;
            this.TotAMT1.CanGrow = false;
            this.TotAMT1.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.TotAMT1.ForeColor = System.Drawing.Color.Black;
            this.TotAMT1.Location = new System.Drawing.Point(215, 76);
            this.TotAMT1.Name = "TotAMT1";
            this.TotAMT1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.TotAMT1.ParentStyleUsing.UseBackColor = false;
            this.TotAMT1.ParentStyleUsing.UseBorderColor = false;
            this.TotAMT1.ParentStyleUsing.UseBorders = false;
            this.TotAMT1.ParentStyleUsing.UseBorderWidth = false;
            this.TotAMT1.ParentStyleUsing.UseFont = false;
            this.TotAMT1.ParentStyleUsing.UseForeColor = false;
            this.TotAMT1.Size = new System.Drawing.Size(246, 12);
            this.TotAMT1.Text = "Untranslated";
            // 
            // Text17
            // 
            this.Text17.BackColor = System.Drawing.Color.White;
            this.Text17.BorderColor = System.Drawing.Color.Black;
            this.Text17.CanGrow = false;
            this.Text17.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text17.ForeColor = System.Drawing.Color.Black;
            this.Text17.Location = new System.Drawing.Point(290, 118);
            this.Text17.Name = "Text17";
            this.Text17.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text17.ParentStyleUsing.UseBackColor = false;
            this.Text17.ParentStyleUsing.UseBorderColor = false;
            this.Text17.ParentStyleUsing.UseBorders = false;
            this.Text17.ParentStyleUsing.UseBorderWidth = false;
            this.Text17.ParentStyleUsing.UseFont = false;
            this.Text17.ParentStyleUsing.UseForeColor = false;
            this.Text17.Size = new System.Drawing.Size(67, 12);
            this.Text17.Text = "NET$";
            this.Text17.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // Text18
            // 
            this.Text18.BackColor = System.Drawing.Color.White;
            this.Text18.BorderColor = System.Drawing.Color.Black;
            this.Text18.CanGrow = false;
            this.Text18.Font = new System.Drawing.Font("Arial Unicode MS", 7F, System.Drawing.FontStyle.Bold);
            this.Text18.ForeColor = System.Drawing.Color.Black;
            this.Text18.Location = new System.Drawing.Point(357, 118);
            this.Text18.Name = "Text18";
            this.Text18.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.Text18.ParentStyleUsing.UseBackColor = false;
            this.Text18.ParentStyleUsing.UseBorderColor = false;
            this.Text18.ParentStyleUsing.UseBorders = false;
            this.Text18.ParentStyleUsing.UseBorderWidth = false;
            this.Text18.ParentStyleUsing.UseFont = false;
            this.Text18.ParentStyleUsing.UseForeColor = false;
            this.Text18.Size = new System.Drawing.Size(67, 12);
            this.Text18.Text = "GST$";
            this.Text18.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // hdrCompName1
            // 
            this.hdrCompName1.BackColor = System.Drawing.Color.White;
            this.hdrCompName1.BorderColor = System.Drawing.Color.Black;
            this.hdrCompName1.CanGrow = false;
            this.hdrCompName1.Font = new System.Drawing.Font("Arial Unicode MS", 9F, System.Drawing.FontStyle.Bold);
            this.hdrCompName1.ForeColor = System.Drawing.Color.Black;
            this.hdrCompName1.Location = new System.Drawing.Point(0, 0);
            this.hdrCompName1.Name = "hdrCompName1";
            this.hdrCompName1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.hdrCompName1.ParentStyleUsing.UseBackColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderColor = false;
            this.hdrCompName1.ParentStyleUsing.UseBorders = false;
            this.hdrCompName1.ParentStyleUsing.UseBorderWidth = false;
            this.hdrCompName1.ParentStyleUsing.UseFont = false;
            this.hdrCompName1.ParentStyleUsing.UseForeColor = false;
            this.hdrCompName1.Size = new System.Drawing.Size(770, 21);
            this.hdrCompName1.Text = "Untranslated";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Height = 15;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xCont1});
            this.PageFooter.Height = 38;
            this.PageFooter.Name = "PageFooter";
            // 
            // xCont1
            // 
            this.xCont1.BackColor = System.Drawing.Color.White;
            this.xCont1.BorderColor = System.Drawing.Color.Black;
            this.xCont1.CanGrow = false;
            this.xCont1.Font = new System.Drawing.Font("Arial Unicode MS", 7F);
            this.xCont1.ForeColor = System.Drawing.Color.Black;
            this.xCont1.Location = new System.Drawing.Point(0, 13);
            this.xCont1.Name = "xCont1";
            this.xCont1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xCont1.ParentStyleUsing.UseBackColor = false;
            this.xCont1.ParentStyleUsing.UseBorderColor = false;
            this.xCont1.ParentStyleUsing.UseBorders = false;
            this.xCont1.ParentStyleUsing.UseBorderWidth = false;
            this.xCont1.ParentStyleUsing.UseFont = false;
            this.xCont1.ParentStyleUsing.UseForeColor = false;
            this.xCont1.Size = new System.Drawing.Size(183, 12);
            this.xCont1.Text = "Untranslated";
            // 
            // VIP2300T
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.GroupHeader1,
            this.GroupFooter1,
            this.ReportHeader,
            this.PageHeader,
            this.ReportFooter,
            this.PageFooter});
            this.DataAdapter = this.oleDbDataAdapter1;
            this.Margins = new System.Drawing.Printing.Margins(25, 25, 25, 0);
            this.PageHeight = 1169;
            this.PageWidth = 826;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private System.Data.OleDb.OleDbDataAdapter oleDbDataAdapter1;
        private System.Data.OleDb.OleDbCommand oleDbCommand1;
        private System.Data.OleDb.OleDbConnection oleDbConnection1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel CARDNAME1;
        private DevExpress.XtraReports.UI.XRLabel TOTTAX1;
        private DevExpress.XtraReports.UI.XRLabel TOTNETSALES1;
        private DevExpress.XtraReports.UI.XRLabel NRDISC1;
        private DevExpress.XtraReports.UI.XRLabel RACE1;
        private DevExpress.XtraReports.UI.XRLabel NETSALES1;
        private DevExpress.XtraReports.UI.XRLabel GROUP1;
        private DevExpress.XtraReports.UI.XRLabel DATECOMM1;
        private DevExpress.XtraReports.UI.XRLabel VIPNO1;
        private DevExpress.XtraReports.UI.XRLabel Text19;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel hdrCompName1;
        private DevExpress.XtraReports.UI.XRLabel Text18;
        private DevExpress.XtraReports.UI.XRLabel Text17;
        private DevExpress.XtraReports.UI.XRLabel TotAMT1;
        private DevExpress.XtraReports.UI.XRLabel Text16;
        private DevExpress.XtraReports.UI.XRLabel PrintTime1;
        private DevExpress.XtraReports.UI.XRLabel PrintDate1;
        private DevExpress.XtraReports.UI.XRLabel TotalPageCount1;
        private DevExpress.XtraReports.UI.XRLabel Text15;
        private DevExpress.XtraReports.UI.XRPageInfo PageNumber1;
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
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xCont1;

    }
}
