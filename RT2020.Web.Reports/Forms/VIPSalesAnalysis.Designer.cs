namespace RT2020.Web.Reports.Forms
{
    partial class VIPSalesAnalysis
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VIPSalesAnalysis));
            this.mainPane = new Gizmox.WebGUI.Forms.Panel();
            this.splitContainer = new Gizmox.WebGUI.Forms.SplitContainer();
            this.gbInfo = new Gizmox.WebGUI.Forms.GroupBox();
            this.txtExpiryDate = new Gizmox.WebGUI.Forms.Label();
            this.lblExpiryDate = new Gizmox.WebGUI.Forms.Label();
            this.txtRegDate = new Gizmox.WebGUI.Forms.Label();
            this.txtRemarks = new Gizmox.WebGUI.Forms.Label();
            this.lblRegDate = new Gizmox.WebGUI.Forms.Label();
            this.lblRemarks = new Gizmox.WebGUI.Forms.Label();
            this.txtProfile = new Gizmox.WebGUI.Forms.Label();
            this.txtBirthday = new Gizmox.WebGUI.Forms.Label();
            this.txtEmail = new Gizmox.WebGUI.Forms.Label();
            this.txtTypeAndNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblProfile = new Gizmox.WebGUI.Forms.Label();
            this.txtAccumulativeTransactionNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblBirthday = new Gizmox.WebGUI.Forms.Label();
            this.lblAccumulativeSpending = new Gizmox.WebGUI.Forms.Label();
            this.lblTypeAndNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblAccumulativeTransactionNumber = new Gizmox.WebGUI.Forms.Label();
            this.lblEmail = new Gizmox.WebGUI.Forms.Label();
            this.txtAccumulativeSpending = new Gizmox.WebGUI.Forms.Label();
            this.txtContactNumber = new Gizmox.WebGUI.Forms.Label();
            this.txtVipName = new Gizmox.WebGUI.Forms.Label();
            this.txtSalute = new Gizmox.WebGUI.Forms.Label();
            this.lblSalute = new Gizmox.WebGUI.Forms.Label();
            this.lblVipName = new Gizmox.WebGUI.Forms.Label();
            this.lblContactNumber = new Gizmox.WebGUI.Forms.Label();
            this.btnSearch = new Gizmox.WebGUI.Forms.Button();
            this.dtDateFrom = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.dtDateTo = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.label12 = new Gizmox.WebGUI.Forms.Label();
            this.label11 = new Gizmox.WebGUI.Forms.Label();
            this.txtLayout = new Gizmox.WebGUI.Forms.TextBox();
            this.label10 = new Gizmox.WebGUI.Forms.Label();
            this.label9 = new Gizmox.WebGUI.Forms.Label();
            this.label8 = new Gizmox.WebGUI.Forms.Label();
            this.txtCode = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLoyalty = new Gizmox.WebGUI.Forms.TextBox();
            this.label7 = new Gizmox.WebGUI.Forms.Label();
            this.label6 = new Gizmox.WebGUI.Forms.Label();
            this.label5 = new Gizmox.WebGUI.Forms.Label();
            this.label4 = new Gizmox.WebGUI.Forms.Label();
            this.label3 = new Gizmox.WebGUI.Forms.Label();
            this.label1 = new Gizmox.WebGUI.Forms.Label();
            this.lblBarcode = new Gizmox.WebGUI.Forms.Label();
            this.txtHKID = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNumber = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNumber = new Gizmox.WebGUI.Forms.Label();
            this.rptViewer = new RT2020.Web.Reports.Controls.Viewer();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.SuspendLayout();
            // 
            // mainPane
            // 
            this.mainPane.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.mainPane.Controls.Add(this.splitContainer);
            this.mainPane.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.mainPane.DockPadding.All = 6;
            this.mainPane.Location = new System.Drawing.Point(0, 0);
            this.mainPane.Name = "mainPane";
            this.mainPane.Size = new System.Drawing.Size(962, 641);
            this.mainPane.TabIndex = 0;
            // 
            // splitContainer
            // 
            this.splitContainer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.splitContainer.BorderStyle = Gizmox.WebGUI.Forms.BorderStyle.Clear;
            this.splitContainer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.splitContainer.FixedPanel = Gizmox.WebGUI.Forms.FixedPanel.Panel1;
            this.splitContainer.Location = new System.Drawing.Point(6, 6);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = Gizmox.WebGUI.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.gbInfo);
            this.splitContainer.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer.Panel1.Controls.Add(this.dtDateFrom);
            this.splitContainer.Panel1.Controls.Add(this.dtDateTo);
            this.splitContainer.Panel1.Controls.Add(this.label12);
            this.splitContainer.Panel1.Controls.Add(this.label11);
            this.splitContainer.Panel1.Controls.Add(this.txtLayout);
            this.splitContainer.Panel1.Controls.Add(this.label10);
            this.splitContainer.Panel1.Controls.Add(this.label9);
            this.splitContainer.Panel1.Controls.Add(this.label8);
            this.splitContainer.Panel1.Controls.Add(this.txtCode);
            this.splitContainer.Panel1.Controls.Add(this.txtLoyalty);
            this.splitContainer.Panel1.Controls.Add(this.label7);
            this.splitContainer.Panel1.Controls.Add(this.label6);
            this.splitContainer.Panel1.Controls.Add(this.label5);
            this.splitContainer.Panel1.Controls.Add(this.label4);
            this.splitContainer.Panel1.Controls.Add(this.label3);
            this.splitContainer.Panel1.Controls.Add(this.label1);
            this.splitContainer.Panel1.Controls.Add(this.lblBarcode);
            this.splitContainer.Panel1.Controls.Add(this.txtHKID);
            this.splitContainer.Panel1.Controls.Add(this.txtNumber);
            this.splitContainer.Panel1.Controls.Add(this.lblNumber);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.rptViewer);
            this.splitContainer.Size = new System.Drawing.Size(950, 629);
            this.splitContainer.SplitterDistance = 225;
            this.splitContainer.TabIndex = 0;
            // 
            // gbInfo
            // 
            this.gbInfo.Controls.Add(this.txtExpiryDate);
            this.gbInfo.Controls.Add(this.lblExpiryDate);
            this.gbInfo.Controls.Add(this.txtRegDate);
            this.gbInfo.Controls.Add(this.txtRemarks);
            this.gbInfo.Controls.Add(this.lblRegDate);
            this.gbInfo.Controls.Add(this.lblRemarks);
            this.gbInfo.Controls.Add(this.txtProfile);
            this.gbInfo.Controls.Add(this.txtBirthday);
            this.gbInfo.Controls.Add(this.txtEmail);
            this.gbInfo.Controls.Add(this.txtTypeAndNumber);
            this.gbInfo.Controls.Add(this.lblProfile);
            this.gbInfo.Controls.Add(this.txtAccumulativeTransactionNumber);
            this.gbInfo.Controls.Add(this.lblBirthday);
            this.gbInfo.Controls.Add(this.lblAccumulativeSpending);
            this.gbInfo.Controls.Add(this.lblTypeAndNumber);
            this.gbInfo.Controls.Add(this.lblAccumulativeTransactionNumber);
            this.gbInfo.Controls.Add(this.lblEmail);
            this.gbInfo.Controls.Add(this.txtAccumulativeSpending);
            this.gbInfo.Controls.Add(this.txtContactNumber);
            this.gbInfo.Controls.Add(this.txtVipName);
            this.gbInfo.Controls.Add(this.txtSalute);
            this.gbInfo.Controls.Add(this.lblSalute);
            this.gbInfo.Controls.Add(this.lblVipName);
            this.gbInfo.Controls.Add(this.lblContactNumber);
            this.gbInfo.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbInfo.Location = new System.Drawing.Point(476, 6);
            this.gbInfo.Name = "gbInfo";
            this.gbInfo.Size = new System.Drawing.Size(471, 213);
            this.gbInfo.TabIndex = 11;
            this.gbInfo.Text = "VIP Information";
            this.gbInfo.Visible = false;
            // 
            // txtExpiryDate
            // 
            this.txtExpiryDate.Location = new System.Drawing.Point(149, 187);
            this.txtExpiryDate.Name = "txtExpiryDate";
            this.txtExpiryDate.Size = new System.Drawing.Size(316, 15);
            this.txtExpiryDate.TabIndex = 21;
            this.txtExpiryDate.Text = ":[Expiry Date]";
            // 
            // lblExpiryDate
            // 
            this.lblExpiryDate.Location = new System.Drawing.Point(25, 187);
            this.lblExpiryDate.Name = "lblExpiryDate";
            this.lblExpiryDate.Size = new System.Drawing.Size(65, 15);
            this.lblExpiryDate.TabIndex = 9;
            this.lblExpiryDate.Text = "Expiry Date";
            // 
            // txtRegDate
            // 
            this.txtRegDate.Location = new System.Drawing.Point(149, 172);
            this.txtRegDate.Name = "txtRegDate";
            this.txtRegDate.Size = new System.Drawing.Size(316, 15);
            this.txtRegDate.TabIndex = 20;
            this.txtRegDate.Text = ":[Reg Date]";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(149, 157);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(316, 15);
            this.txtRemarks.TabIndex = 19;
            this.txtRemarks.Text = ":[Remarks]";
            // 
            // lblRegDate
            // 
            this.lblRegDate.Location = new System.Drawing.Point(25, 172);
            this.lblRegDate.Name = "lblRegDate";
            this.lblRegDate.Size = new System.Drawing.Size(118, 15);
            this.lblRegDate.TabIndex = 9;
            this.lblRegDate.Text = "Registration Date";
            // 
            // lblRemarks
            // 
            this.lblRemarks.Location = new System.Drawing.Point(25, 157);
            this.lblRemarks.Name = "lblRemarks";
            this.lblRemarks.Size = new System.Drawing.Size(57, 15);
            this.lblRemarks.TabIndex = 9;
            this.lblRemarks.Text = "Remark(s)";
            // 
            // txtProfile
            // 
            this.txtProfile.Location = new System.Drawing.Point(149, 142);
            this.txtProfile.Name = "txtProfile";
            this.txtProfile.Size = new System.Drawing.Size(316, 15);
            this.txtProfile.TabIndex = 18;
            this.txtProfile.Text = ":[Profile]";
            // 
            // txtBirthday
            // 
            this.txtBirthday.Location = new System.Drawing.Point(149, 127);
            this.txtBirthday.Name = "txtBirthday";
            this.txtBirthday.Size = new System.Drawing.Size(316, 15);
            this.txtBirthday.TabIndex = 17;
            this.txtBirthday.Text = ":[Birthday]";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(149, 112);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(316, 15);
            this.txtEmail.TabIndex = 16;
            this.txtEmail.Text = ":[Email]";
            // 
            // txtTypeAndNumber
            // 
            this.txtTypeAndNumber.Location = new System.Drawing.Point(149, 97);
            this.txtTypeAndNumber.Name = "txtTypeAndNumber";
            this.txtTypeAndNumber.Size = new System.Drawing.Size(316, 15);
            this.txtTypeAndNumber.TabIndex = 15;
            this.txtTypeAndNumber.Text = ":[Type] + [Loy Number]";
            // 
            // lblProfile
            // 
            this.lblProfile.Location = new System.Drawing.Point(25, 142);
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(118, 15);
            this.lblProfile.TabIndex = 9;
            this.lblProfile.Text = "Profile";
            // 
            // txtAccumulativeTransactionNumber
            // 
            this.txtAccumulativeTransactionNumber.Location = new System.Drawing.Point(149, 82);
            this.txtAccumulativeTransactionNumber.Name = "txtAccumulativeTransactionNumber";
            this.txtAccumulativeTransactionNumber.Size = new System.Drawing.Size(316, 15);
            this.txtAccumulativeTransactionNumber.TabIndex = 14;
            this.txtAccumulativeTransactionNumber.Text = ":[Transaction Number]";
            // 
            // lblBirthday
            // 
            this.lblBirthday.Location = new System.Drawing.Point(25, 127);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(118, 15);
            this.lblBirthday.TabIndex = 9;
            this.lblBirthday.Text = "Birthday";
            // 
            // lblAccumulativeSpending
            // 
            this.lblAccumulativeSpending.Location = new System.Drawing.Point(25, 67);
            this.lblAccumulativeSpending.Name = "lblAccumulativeSpending";
            this.lblAccumulativeSpending.Size = new System.Drawing.Size(118, 15);
            this.lblAccumulativeSpending.TabIndex = 9;
            this.lblAccumulativeSpending.Text = "Accumulative Spending";
            // 
            // lblTypeAndNumber
            // 
            this.lblTypeAndNumber.Location = new System.Drawing.Point(25, 97);
            this.lblTypeAndNumber.Name = "lblTypeAndNumber";
            this.lblTypeAndNumber.Size = new System.Drawing.Size(118, 15);
            this.lblTypeAndNumber.TabIndex = 9;
            this.lblTypeAndNumber.Text = "Type/Number";
            // 
            // lblAccumulativeTransactionNumber
            // 
            this.lblAccumulativeTransactionNumber.Location = new System.Drawing.Point(25, 82);
            this.lblAccumulativeTransactionNumber.Name = "lblAccumulativeTransactionNumber";
            this.lblAccumulativeTransactionNumber.Size = new System.Drawing.Size(118, 15);
            this.lblAccumulativeTransactionNumber.TabIndex = 9;
            this.lblAccumulativeTransactionNumber.Text = "Accumulative TRN No";
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(25, 112);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(38, 15);
            this.lblEmail.TabIndex = 9;
            this.lblEmail.Text = "Email";
            // 
            // txtAccumulativeSpending
            // 
            this.txtAccumulativeSpending.Location = new System.Drawing.Point(149, 67);
            this.txtAccumulativeSpending.Name = "txtAccumulativeSpending";
            this.txtAccumulativeSpending.Size = new System.Drawing.Size(316, 15);
            this.txtAccumulativeSpending.TabIndex = 13;
            this.txtAccumulativeSpending.Text = ":[Spending]";
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(149, 52);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(316, 15);
            this.txtContactNumber.TabIndex = 12;
            this.txtContactNumber.Text = ": [W] + [H] + [P]";
            // 
            // txtVipName
            // 
            this.txtVipName.Location = new System.Drawing.Point(149, 37);
            this.txtVipName.Name = "txtVipName";
            this.txtVipName.Size = new System.Drawing.Size(316, 13);
            this.txtVipName.TabIndex = 11;
            this.txtVipName.Text = ": [Vip Name]";
            // 
            // txtSalute
            // 
            this.txtSalute.Location = new System.Drawing.Point(149, 21);
            this.txtSalute.Name = "txtSalute";
            this.txtSalute.Size = new System.Drawing.Size(316, 15);
            this.txtSalute.TabIndex = 10;
            this.txtSalute.Text = ": [Salute]";
            // 
            // lblSalute
            // 
            this.lblSalute.Location = new System.Drawing.Point(25, 21);
            this.lblSalute.Name = "lblSalute";
            this.lblSalute.Size = new System.Drawing.Size(118, 15);
            this.lblSalute.TabIndex = 9;
            this.lblSalute.Text = "Salute";
            // 
            // lblVipName
            // 
            this.lblVipName.Location = new System.Drawing.Point(25, 37);
            this.lblVipName.Name = "lblVipName";
            this.lblVipName.Size = new System.Drawing.Size(118, 15);
            this.lblVipName.TabIndex = 9;
            this.lblVipName.Text = "Name";
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Location = new System.Drawing.Point(25, 52);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(127, 13);
            this.lblContactNumber.TabIndex = 9;
            this.lblContactNumber.Text = "Contact Number (W/H/P)";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Tahoma", 9F);
            this.btnSearch.Location = new System.Drawing.Point(99, 183);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtDateFrom
            // 
            this.dtDateFrom.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateFrom.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateFrom.CustomFormat = "dd/MM/yyyy";
            this.dtDateFrom.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateFrom.Location = new System.Drawing.Point(99, 93);
            this.dtDateFrom.Name = "dtDateFrom";
            this.dtDateFrom.Size = new System.Drawing.Size(103, 20);
            this.dtDateFrom.TabIndex = 5;
            // 
            // dtDateTo
            // 
            this.dtDateTo.BorderColor = System.Drawing.Color.LightYellow;
            this.dtDateTo.CalendarFirstDayOfWeek = Gizmox.WebGUI.Forms.Day.Default;
            this.dtDateTo.CustomFormat = "dd/MM/yyyy";
            this.dtDateTo.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.dtDateTo.Location = new System.Drawing.Point(99, 119);
            this.dtDateTo.Name = "dtDateTo";
            this.dtDateTo.Size = new System.Drawing.Size(103, 20);
            this.dtDateTo.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(205, 173);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(252, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "6:Full List By CATEGORY; Else:Full List;)";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(205, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(252, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "4:No. of Visits  Date; 5:By BRAND, CATEGORY;";
            // 
            // txtLayout
            // 
            this.txtLayout.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtLayout.Location = new System.Drawing.Point(99, 154);
            this.txtLayout.Name = "txtLayout";
            this.txtLayout.Size = new System.Drawing.Size(100, 22);
            this.txtLayout.TabIndex = 7;
            this.txtLayout.Text = "4";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label10.Location = new System.Drawing.Point(17, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 0;
            this.label10.Text = "View Layout";
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(205, 143);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(252, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "(1:Full List; 2:Last TRN; 3:By YEAR, Qty,Amount;";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label8.Location = new System.Drawing.Point(17, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "OR Code#";
            // 
            // txtCode
            // 
            this.txtCode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtCode.Location = new System.Drawing.Point(99, 64);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(100, 22);
            this.txtCode.TabIndex = 3;
            // 
            // txtLoyalty
            // 
            this.txtLoyalty.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtLoyalty.Location = new System.Drawing.Point(294, 62);
            this.txtLoyalty.Name = "txtLoyalty";
            this.txtLoyalty.Size = new System.Drawing.Size(123, 22);
            this.txtLoyalty.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label7.Location = new System.Drawing.Point(209, 67);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 17);
            this.label7.TabIndex = 0;
            this.label7.Text = "OR Loyalty#";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(205, 123);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 18);
            this.label6.TabIndex = 0;
            this.label6.Text = "(DD/MM/YYYY)";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(206, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 18);
            this.label5.TabIndex = 0;
            this.label5.Text = "(DD/MM/YYYY)";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label4.Location = new System.Drawing.Point(17, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "To Date";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F);
            this.label3.Location = new System.Drawing.Point(17, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "From Date";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(7, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(431, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "VIP Sales Analysis";
            // 
            // lblBarcode
            // 
            this.lblBarcode.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblBarcode.Location = new System.Drawing.Point(209, 39);
            this.lblBarcode.Name = "lblBarcode";
            this.lblBarcode.Size = new System.Drawing.Size(66, 17);
            this.lblBarcode.TabIndex = 0;
            this.lblBarcode.Text = "OR HKID#";
            // 
            // txtHKID
            // 
            this.txtHKID.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtHKID.Location = new System.Drawing.Point(294, 36);
            this.txtHKID.Name = "txtHKID";
            this.txtHKID.Size = new System.Drawing.Size(123, 22);
            this.txtHKID.TabIndex = 2;
            // 
            // txtNumber
            // 
            this.txtNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.txtNumber.Location = new System.Drawing.Point(99, 36);
            this.txtNumber.Name = "txtNumber";
            this.txtNumber.Size = new System.Drawing.Size(100, 22);
            this.txtNumber.TabIndex = 1;
            // 
            // lblNumber
            // 
            this.lblNumber.Font = new System.Drawing.Font("Tahoma", 9F);
            this.lblNumber.Location = new System.Drawing.Point(17, 39);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(65, 17);
            this.lblNumber.TabIndex = 0;
            this.lblNumber.Text = "VIP#";
            // 
            // rptViewer
            // 
            this.rptViewer.Anchor = Gizmox.WebGUI.Forms.AnchorStyles.None;
            this.rptViewer.Datasource = null;
            this.rptViewer.Dock = Gizmox.WebGUI.Forms.DockStyle.Fill;
            this.rptViewer.Location = new System.Drawing.Point(0, 0);
            this.rptViewer.Name = "rptViewer";
            this.rptViewer.Parameters = null;
            this.rptViewer.ReportDatasourceName = "";
            this.rptViewer.ReportDestination = RT2020.Web.Reports.Controls.Viewer.ReportDestinations.Preview;
            this.rptViewer.ReportName = "";
            this.rptViewer.Size = new System.Drawing.Size(950, 400);
            this.rptViewer.SubDataSource = null;
            this.rptViewer.SubDataSourceName = null;
            this.rptViewer.SubReportDataSourceList = ((System.Collections.Generic.Dictionary<string, System.Data.DataTable>)(resources.GetObject("rptViewer.SubReportDataSourceList")));
            this.rptViewer.TabIndex = 0;
            this.rptViewer.Text = "Viewer";
            // 
            // VIPSalesAnalysis
            // 
            this.AcceptButton = this.btnSearch;
            this.Controls.Add(this.mainPane);
            this.Location = new System.Drawing.Point(15, -20);
            this.Size = new System.Drawing.Size(962, 641);
            this.Text = "VIPSalesAnalysis";
            this.ResumeLayout(false);

        }

        #endregion

        private Gizmox.WebGUI.Forms.Panel mainPane;
        private Gizmox.WebGUI.Forms.SplitContainer splitContainer;
        private RT2020.Web.Reports.Controls.Viewer rptViewer;
        private Gizmox.WebGUI.Forms.TextBox txtNumber;
        private Gizmox.WebGUI.Forms.Label lblNumber;
        private System.ServiceProcess.ServiceController serviceController1;
        private Gizmox.WebGUI.Forms.Label lblBarcode;
        private Gizmox.WebGUI.Forms.TextBox txtHKID;
        private Gizmox.WebGUI.Forms.Label label1;
        private Gizmox.WebGUI.Forms.Label label4;
        private Gizmox.WebGUI.Forms.Label label3;
        private Gizmox.WebGUI.Forms.Label label6;
        private Gizmox.WebGUI.Forms.Label label5;
        private Gizmox.WebGUI.Forms.TextBox txtLayout;
        private Gizmox.WebGUI.Forms.Label label10;
        private Gizmox.WebGUI.Forms.Label label9;
        private Gizmox.WebGUI.Forms.Label label8;
        private Gizmox.WebGUI.Forms.TextBox txtCode;
        private Gizmox.WebGUI.Forms.TextBox txtLoyalty;
        private Gizmox.WebGUI.Forms.Label label7;
        private Gizmox.WebGUI.Forms.Label label11;
        private Gizmox.WebGUI.Forms.Label label12;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateFrom;
        private Gizmox.WebGUI.Forms.DateTimePicker dtDateTo;
        private Gizmox.WebGUI.Forms.Button btnSearch;
        private Gizmox.WebGUI.Forms.Label lblSalute;
        private Gizmox.WebGUI.Forms.Label lblTypeAndNumber;
        private Gizmox.WebGUI.Forms.Label lblAccumulativeTransactionNumber;
        private Gizmox.WebGUI.Forms.Label lblRegDate;
        private Gizmox.WebGUI.Forms.Label lblProfile;
        private Gizmox.WebGUI.Forms.Label lblBirthday;
        private Gizmox.WebGUI.Forms.Label lblAccumulativeSpending;
        private Gizmox.WebGUI.Forms.Label lblVipName;
        private Gizmox.WebGUI.Forms.Label lblContactNumber;
        private Gizmox.WebGUI.Forms.Label lblEmail;
        private Gizmox.WebGUI.Forms.Label lblExpiryDate;
        private Gizmox.WebGUI.Forms.Label lblRemarks;
        private Gizmox.WebGUI.Forms.GroupBox gbInfo;
        private Gizmox.WebGUI.Forms.Label txtVipName;
        private Gizmox.WebGUI.Forms.Label txtSalute;
        private Gizmox.WebGUI.Forms.Label txtAccumulativeSpending;
        private Gizmox.WebGUI.Forms.Label txtContactNumber;
        private Gizmox.WebGUI.Forms.Label txtAccumulativeTransactionNumber;
        private Gizmox.WebGUI.Forms.Label txtTypeAndNumber;
        private Gizmox.WebGUI.Forms.Label txtEmail;
        private Gizmox.WebGUI.Forms.Label txtProfile;
        private Gizmox.WebGUI.Forms.Label txtBirthday;
        private Gizmox.WebGUI.Forms.Label txtRemarks;
        private Gizmox.WebGUI.Forms.Label txtRegDate;
        private Gizmox.WebGUI.Forms.Label txtExpiryDate;


    }
}