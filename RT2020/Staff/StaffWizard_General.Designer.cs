namespace RT2020.Staff
{
    partial class StaffWizard_General
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

        #region Visual WebGui UserControl Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cboSmartTag8 = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboDeptCode = new Gizmox.WebGUI.Forms.ComboBox();
            this.cboPosition = new Gizmox.WebGUI.Forms.ComboBox();
            this.txtFirstName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblFirstName = new Gizmox.WebGUI.Forms.Label();
            this.lblLastName = new Gizmox.WebGUI.Forms.Label();
            this.txtLastName = new Gizmox.WebGUI.Forms.TextBox();
            this.lblSmartTag12 = new Gizmox.WebGUI.Forms.Label();
            this.txtSmartTag12 = new Gizmox.WebGUI.Forms.TextBox();
            this.txtSmartTag4 = new Gizmox.WebGUI.Forms.TextBox();
            this.chkAdministration = new Gizmox.WebGUI.Forms.CheckBox();
            this.chkPunch = new Gizmox.WebGUI.Forms.CheckBox();
            this.lblMedical = new Gizmox.WebGUI.Forms.Label();
            this.txtMedical = new Gizmox.WebGUI.Forms.TextBox();
            this.txtEmploymen = new Gizmox.WebGUI.Forms.TextBox();
            this.lblEmploymen = new Gizmox.WebGUI.Forms.Label();
            this.lblDept = new Gizmox.WebGUI.Forms.Label();
            this.datHiredOn = new Gizmox.WebGUI.Forms.DateTimePicker();
            this.lblDateFormat = new Gizmox.WebGUI.Forms.Label();
            this.lblHiredOn = new Gizmox.WebGUI.Forms.Label();
            this.cboSmartTag7 = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblB = new Gizmox.WebGUI.Forms.Label();
            this.lblA = new Gizmox.WebGUI.Forms.Label();
            this.lblAssistant = new Gizmox.WebGUI.Forms.Label();
            this.cboSmartTag6 = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblSmartTag8 = new Gizmox.WebGUI.Forms.Label();
            this.txtPassword = new Gizmox.WebGUI.Forms.TextBox();
            this.lblPassword = new Gizmox.WebGUI.Forms.Label();
            this.btnChangePassword = new Gizmox.WebGUI.Forms.Button();
            this.lblStaffGrade = new Gizmox.WebGUI.Forms.Label();
            this.cmbStaffGrade = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblPosition = new Gizmox.WebGUI.Forms.Label();
            this.cboSmartTag5 = new Gizmox.WebGUI.Forms.ComboBox();
            this.lblNameCht = new Gizmox.WebGUI.Forms.Label();
            this.txtStateCounter = new Gizmox.WebGUI.Forms.TextBox();
            this.txtStateOffice = new Gizmox.WebGUI.Forms.TextBox();
            this.lblStatus = new Gizmox.WebGUI.Forms.Label();
            this.lblCreationDate = new Gizmox.WebGUI.Forms.Label();
            this.txtModified = new Gizmox.WebGUI.Forms.TextBox();
            this.txtCreationDate = new Gizmox.WebGUI.Forms.TextBox();
            this.txtLastUpdate = new Gizmox.WebGUI.Forms.TextBox();
            this.lblLastUpdate = new Gizmox.WebGUI.Forms.Label();
            this.lblSmartTag5 = new Gizmox.WebGUI.Forms.Label();
            this.txtNameCht = new Gizmox.WebGUI.Forms.TextBox();
            this.txtNameChs = new Gizmox.WebGUI.Forms.TextBox();
            this.txtName = new Gizmox.WebGUI.Forms.TextBox();
            this.txtInitial = new Gizmox.WebGUI.Forms.TextBox();
            this.lblNameChs = new Gizmox.WebGUI.Forms.Label();
            this.lblSmartTag4 = new Gizmox.WebGUI.Forms.Label();
            this.lblName = new Gizmox.WebGUI.Forms.Label();
            this.lblInitial = new Gizmox.WebGUI.Forms.Label();
            this.gbxTimeCard = new Gizmox.WebGUI.Forms.GroupBox();
            this.gbxStatus = new Gizmox.WebGUI.Forms.GroupBox();
            this.gbxTimeCard.SuspendLayout();
            this.gbxStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // cboSmartTag8
            // 
            this.cboSmartTag8.Items.AddRange(new object[] {
            "N - None",
            "O - Office",
            "S - SHOP",
            "W - Warehouse",
            "M - MIS"});
            this.cboSmartTag8.Location = new System.Drawing.Point(116, 206);
            this.cboSmartTag8.Name = "cboSmartTag8";
            this.cboSmartTag8.Size = new System.Drawing.Size(121, 21);
            this.cboSmartTag8.TabIndex = 11;
            // 
            // cboDeptCode
            // 
            this.cboDeptCode.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboDeptCode.DropDownWidth = 121;
            this.cboDeptCode.Location = new System.Drawing.Point(322, 204);
            this.cboDeptCode.Name = "cboDeptCode";
            this.cboDeptCode.Size = new System.Drawing.Size(121, 21);
            this.cboDeptCode.TabIndex = 12;
            // 
            // cboPosition
            // 
            this.cboPosition.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cboPosition.DropDownWidth = 121;
            this.cboPosition.Location = new System.Drawing.Point(116, 130);
            this.cboPosition.Name = "cboPosition";
            this.cboPosition.Size = new System.Drawing.Size(121, 21);
            this.cboPosition.TabIndex = 7;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Location = new System.Drawing.Point(322, 33);
            this.txtFirstName.Name = "txtFirstName";
            this.txtFirstName.Size = new System.Drawing.Size(121, 21);
            this.txtFirstName.TabIndex = 4;
            this.txtFirstName.TextChanged += new System.EventHandler(this.txtFirstName_TextChanged);
            // 
            // lblFirstName
            // 
            this.lblFirstName.Location = new System.Drawing.Point(245, 33);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(75, 23);
            this.lblFirstName.TabIndex = 1;
            this.lblFirstName.Text = "First Name";
            this.lblFirstName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLastName
            // 
            this.lblLastName.Location = new System.Drawing.Point(10, 33);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(79, 23);
            this.lblLastName.TabIndex = 1;
            this.lblLastName.Text = "Last Name";
            this.lblLastName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtLastName
            // 
            this.txtLastName.Location = new System.Drawing.Point(116, 33);
            this.txtLastName.Name = "txtLastName";
            this.txtLastName.Size = new System.Drawing.Size(100, 21);
            this.txtLastName.TabIndex = 3;
            this.txtLastName.TextChanged += new System.EventHandler(this.txtLastName_TextChanged);
            // 
            // lblSmartTag12
            // 
            this.lblSmartTag12.Location = new System.Drawing.Point(9, 300);
            this.lblSmartTag12.Name = "lblSmartTag12";
            this.lblSmartTag12.Size = new System.Drawing.Size(101, 23);
            this.lblSmartTag12.TabIndex = 1;
            this.lblSmartTag12.Text = "SmartTag12";
            this.lblSmartTag12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtSmartTag12
            // 
            this.txtSmartTag12.Location = new System.Drawing.Point(116, 300);
            this.txtSmartTag12.Name = "txtSmartTag12";
            this.txtSmartTag12.Size = new System.Drawing.Size(327, 21);
            this.txtSmartTag12.TabIndex = 18;
            // 
            // txtSmartTag4
            // 
            this.txtSmartTag4.Location = new System.Drawing.Point(116, 277);
            this.txtSmartTag4.Name = "txtSmartTag4";
            this.txtSmartTag4.Size = new System.Drawing.Size(327, 21);
            this.txtSmartTag4.TabIndex = 17;
            // 
            // chkAdministration
            // 
            this.chkAdministration.Location = new System.Drawing.Point(17, 46);
            this.chkAdministration.Name = "chkAdministration";
            this.chkAdministration.Size = new System.Drawing.Size(109, 24);
            this.chkAdministration.TabIndex = 21;
            this.chkAdministration.Text = "Administration";
            // 
            // chkPunch
            // 
            this.chkPunch.Location = new System.Drawing.Point(17, 23);
            this.chkPunch.Name = "chkPunch";
            this.chkPunch.Size = new System.Drawing.Size(109, 24);
            this.chkPunch.TabIndex = 20;
            this.chkPunch.Text = "Punch In/Out";
            // 
            // lblMedical
            // 
            this.lblMedical.Location = new System.Drawing.Point(245, 254);
            this.lblMedical.Name = "lblMedical";
            this.lblMedical.Size = new System.Drawing.Size(75, 23);
            this.lblMedical.TabIndex = 0;
            this.lblMedical.Text = "Medical#";
            this.lblMedical.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMedical
            // 
            this.txtMedical.Location = new System.Drawing.Point(322, 254);
            this.txtMedical.Name = "txtMedical";
            this.txtMedical.Size = new System.Drawing.Size(121, 21);
            this.txtMedical.TabIndex = 16;
            // 
            // txtEmploymen
            // 
            this.txtEmploymen.Location = new System.Drawing.Point(322, 230);
            this.txtEmploymen.Name = "txtEmploymen";
            this.txtEmploymen.Size = new System.Drawing.Size(121, 21);
            this.txtEmploymen.TabIndex = 14;
            // 
            // lblEmploymen
            // 
            this.lblEmploymen.Location = new System.Drawing.Point(245, 230);
            this.lblEmploymen.Name = "lblEmploymen";
            this.lblEmploymen.Size = new System.Drawing.Size(75, 23);
            this.lblEmploymen.TabIndex = 0;
            this.lblEmploymen.Text = "Employment#";
            this.lblEmploymen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDept
            // 
            this.lblDept.Location = new System.Drawing.Point(245, 205);
            this.lblDept.Name = "lblDept";
            this.lblDept.Size = new System.Drawing.Size(75, 23);
            this.lblDept.TabIndex = 0;
            this.lblDept.Text = "Dept#";
            this.lblDept.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // datHiredOn
            // 
            this.datHiredOn.CustomFormat = "dd/MM/yyyy";
            this.datHiredOn.Format = Gizmox.WebGUI.Forms.DateTimePickerFormat.Custom;
            this.datHiredOn.Location = new System.Drawing.Point(322, 155);
            this.datHiredOn.Name = "datHiredOn";
            this.datHiredOn.Size = new System.Drawing.Size(121, 21);
            this.datHiredOn.TabIndex = 9;
            // 
            // lblDateFormat
            // 
            this.lblDateFormat.Location = new System.Drawing.Point(320, 180);
            this.lblDateFormat.Name = "lblDateFormat";
            this.lblDateFormat.Size = new System.Drawing.Size(79, 23);
            this.lblDateFormat.TabIndex = 0;
            this.lblDateFormat.Text = "(dd/MM/yyyy)";
            this.lblDateFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblHiredOn
            // 
            this.lblHiredOn.Location = new System.Drawing.Point(245, 155);
            this.lblHiredOn.Name = "lblHiredOn";
            this.lblHiredOn.Size = new System.Drawing.Size(75, 23);
            this.lblHiredOn.TabIndex = 0;
            this.lblHiredOn.Text = "Hired On";
            this.lblHiredOn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cboSmartTag7
            // 
            this.cboSmartTag7.DropDownWidth = 121;
            this.cboSmartTag7.Location = new System.Drawing.Point(116, 254);
            this.cboSmartTag7.Name = "cboSmartTag7";
            this.cboSmartTag7.Size = new System.Drawing.Size(121, 21);
            this.cboSmartTag7.TabIndex = 15;
            // 
            // lblB
            // 
            this.lblB.Location = new System.Drawing.Point(78, 254);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(32, 23);
            this.lblB.TabIndex = 0;
            this.lblB.Text = "(2)";
            this.lblB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblA
            // 
            this.lblA.Location = new System.Drawing.Point(78, 230);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(32, 23);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "(1)";
            this.lblA.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblAssistant
            // 
            this.lblAssistant.Location = new System.Drawing.Point(9, 230);
            this.lblAssistant.Name = "lblAssistant";
            this.lblAssistant.Size = new System.Drawing.Size(73, 23);
            this.lblAssistant.TabIndex = 0;
            this.lblAssistant.Text = "Assistant#";
            this.lblAssistant.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSmartTag6
            // 
            this.cboSmartTag6.DropDownWidth = 121;
            this.cboSmartTag6.Location = new System.Drawing.Point(116, 230);
            this.cboSmartTag6.Name = "cboSmartTag6";
            this.cboSmartTag6.Size = new System.Drawing.Size(121, 21);
            this.cboSmartTag6.TabIndex = 13;
            // 
            // lblSmartTag8
            // 
            this.lblSmartTag8.Location = new System.Drawing.Point(9, 205);
            this.lblSmartTag8.Name = "lblSmartTag8";
            this.lblSmartTag8.Size = new System.Drawing.Size(79, 23);
            this.lblSmartTag8.TabIndex = 0;
            this.lblSmartTag8.Text = "Belongs";
            this.lblSmartTag8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPassword
            // 
            this.txtPassword.BackColor = System.Drawing.Color.LightYellow;
            this.txtPassword.Location = new System.Drawing.Point(116, 155);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.ReadOnly = true;
            this.txtPassword.Size = new System.Drawing.Size(87, 21);
            this.txtPassword.TabIndex = 90;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(9, 154);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(79, 23);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Location = new System.Drawing.Point(204, 155);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(33, 23);
            this.btnChangePassword.TabIndex = 8;
            this.btnChangePassword.Text = "...";
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // lblStaffGrade
            // 
            this.lblStaffGrade.Location = new System.Drawing.Point(9, 180);
            this.lblStaffGrade.Name = "lblStaffGrade";
            this.lblStaffGrade.Size = new System.Drawing.Size(79, 23);
            this.lblStaffGrade.TabIndex = 0;
            this.lblStaffGrade.Text = "Grade";
            this.lblStaffGrade.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbStaffGrade
            // 
            this.cmbStaffGrade.DropDownStyle = Gizmox.WebGUI.Forms.ComboBoxStyle.DropDownList;
            this.cmbStaffGrade.DropDownWidth = 121;
            this.cmbStaffGrade.Location = new System.Drawing.Point(116, 180);
            this.cmbStaffGrade.Name = "cmbStaffGrade";
            this.cmbStaffGrade.Size = new System.Drawing.Size(121, 21);
            this.cmbStaffGrade.TabIndex = 10;
            // 
            // lblPosition
            // 
            this.lblPosition.Location = new System.Drawing.Point(9, 130);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(79, 23);
            this.lblPosition.TabIndex = 0;
            this.lblPosition.Text = "Position";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboSmartTag5
            // 
            this.cboSmartTag5.DropDownWidth = 121;
            this.cboSmartTag5.Location = new System.Drawing.Point(322, 10);
            this.cboSmartTag5.Name = "cboSmartTag5";
            this.cboSmartTag5.Size = new System.Drawing.Size(121, 21);
            this.cboSmartTag5.TabIndex = 2;
            // 
            // lblNameCht
            // 
            this.lblNameCht.Location = new System.Drawing.Point(20, 104);
            this.lblNameCht.Name = "lblNameCht";
            this.lblNameCht.Size = new System.Drawing.Size(104, 23);
            this.lblNameCht.TabIndex = 0;
            this.lblNameCht.Text = "Full Name(Cht)";
            this.lblNameCht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtStateCounter
            // 
            this.txtStateCounter.BackColor = System.Drawing.Color.LightYellow;
            this.txtStateCounter.Location = new System.Drawing.Point(84, 160);
            this.txtStateCounter.Name = "txtStateCounter";
            this.txtStateCounter.ReadOnly = true;
            this.txtStateCounter.Size = new System.Drawing.Size(63, 21);
            this.txtStateCounter.TabIndex = 91;
            this.txtStateCounter.Text = "M";
            this.txtStateCounter.TextAlign = Gizmox.WebGUI.Forms.HorizontalAlignment.Center;
            // 
            // txtStateOffice
            // 
            this.txtStateOffice.BackColor = System.Drawing.Color.LightYellow;
            this.txtStateOffice.Location = new System.Drawing.Point(17, 160);
            this.txtStateOffice.Name = "txtStateOffice";
            this.txtStateOffice.ReadOnly = true;
            this.txtStateOffice.Size = new System.Drawing.Size(61, 21);
            this.txtStateOffice.TabIndex = 92;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(17, 137);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(151, 23);
            this.lblStatus.TabIndex = 7;
            this.lblStatus.Text = "Status (Office/Counter)";
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblCreationDate
            // 
            this.lblCreationDate.Location = new System.Drawing.Point(17, 91);
            this.lblCreationDate.Name = "lblCreationDate";
            this.lblCreationDate.Size = new System.Drawing.Size(139, 23);
            this.lblCreationDate.TabIndex = 7;
            this.lblCreationDate.Text = "Creation Date";
            this.lblCreationDate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtModified
            // 
            this.txtModified.BackColor = System.Drawing.Color.LightYellow;
            this.txtModified.Location = new System.Drawing.Point(17, 67);
            this.txtModified.Name = "txtModified";
            this.txtModified.ReadOnly = true;
            this.txtModified.Size = new System.Drawing.Size(130, 21);
            this.txtModified.TabIndex = 82;
            // 
            // txtCreationDate
            // 
            this.txtCreationDate.BackColor = System.Drawing.Color.LightYellow;
            this.txtCreationDate.Location = new System.Drawing.Point(17, 114);
            this.txtCreationDate.Name = "txtCreationDate";
            this.txtCreationDate.ReadOnly = true;
            this.txtCreationDate.Size = new System.Drawing.Size(130, 21);
            this.txtCreationDate.TabIndex = 83;
            // 
            // txtLastUpdate
            // 
            this.txtLastUpdate.BackColor = System.Drawing.Color.LightYellow;
            this.txtLastUpdate.Location = new System.Drawing.Point(17, 42);
            this.txtLastUpdate.Name = "txtLastUpdate";
            this.txtLastUpdate.ReadOnly = true;
            this.txtLastUpdate.Size = new System.Drawing.Size(130, 21);
            this.txtLastUpdate.TabIndex = 81;
            // 
            // lblLastUpdate
            // 
            this.lblLastUpdate.Location = new System.Drawing.Point(17, 17);
            this.lblLastUpdate.Name = "lblLastUpdate";
            this.lblLastUpdate.Size = new System.Drawing.Size(123, 23);
            this.lblLastUpdate.TabIndex = 7;
            this.lblLastUpdate.Text = "Last Update";
            this.lblLastUpdate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSmartTag5
            // 
            this.lblSmartTag5.Location = new System.Drawing.Point(245, 10);
            this.lblSmartTag5.Name = "lblSmartTag5";
            this.lblSmartTag5.Size = new System.Drawing.Size(75, 23);
            this.lblSmartTag5.TabIndex = 0;
            this.lblSmartTag5.Text = "SmartTag5";
            this.lblSmartTag5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNameCht
            // 
            this.txtNameCht.Location = new System.Drawing.Point(116, 106);
            this.txtNameCht.Name = "txtNameCht";
            this.txtNameCht.Size = new System.Drawing.Size(327, 21);
            this.txtNameCht.TabIndex = 6;
            // 
            // txtNameChs
            // 
            this.txtNameChs.Location = new System.Drawing.Point(116, 82);
            this.txtNameChs.Name = "txtNameChs";
            this.txtNameChs.Size = new System.Drawing.Size(327, 21);
            this.txtNameChs.TabIndex = 5;
            // 
            // txtName
            // 
            this.txtName.BackColor = System.Drawing.Color.LightYellow;
            this.txtName.Location = new System.Drawing.Point(116, 58);
            this.txtName.Name = "txtName";
            this.txtName.ReadOnly = true;
            this.txtName.Size = new System.Drawing.Size(327, 21);
            this.txtName.TabIndex = 50;
            // 
            // txtInitial
            // 
            this.txtInitial.Location = new System.Drawing.Point(116, 10);
            this.txtInitial.MaxLength = 16;
            this.txtInitial.Name = "txtInitial";
            this.txtInitial.Size = new System.Drawing.Size(100, 21);
            this.txtInitial.TabIndex = 1;
            // 
            // lblNameChs
            // 
            this.lblNameChs.Location = new System.Drawing.Point(20, 82);
            this.lblNameChs.Name = "lblNameChs";
            this.lblNameChs.Size = new System.Drawing.Size(104, 23);
            this.lblNameChs.TabIndex = 0;
            this.lblNameChs.Text = "Full Name(Chs)";
            this.lblNameChs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblSmartTag4
            // 
            this.lblSmartTag4.Location = new System.Drawing.Point(9, 277);
            this.lblSmartTag4.Name = "lblSmartTag4";
            this.lblSmartTag4.Size = new System.Drawing.Size(101, 23);
            this.lblSmartTag4.TabIndex = 1;
            this.lblSmartTag4.Text = "SmartTag4";
            this.lblSmartTag4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(9, 58);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(79, 23);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Full Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblInitial
            // 
            this.lblInitial.Location = new System.Drawing.Point(9, 10);
            this.lblInitial.Name = "lblInitial";
            this.lblInitial.Size = new System.Drawing.Size(79, 23);
            this.lblInitial.TabIndex = 0;
            this.lblInitial.Text = "Initial";
            this.lblInitial.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbxTimeCard
            // 
            this.gbxTimeCard.Controls.Add(this.chkAdministration);
            this.gbxTimeCard.Controls.Add(this.chkPunch);
            this.gbxTimeCard.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxTimeCard.Location = new System.Drawing.Point(460, 2);
            this.gbxTimeCard.Name = "gbxTimeCard";
            this.gbxTimeCard.Size = new System.Drawing.Size(169, 80);
            this.gbxTimeCard.TabIndex = 93;
            this.gbxTimeCard.TabStop = false;
            this.gbxTimeCard.Text = "Time Card Function";
            // 
            // gbxStatus
            // 
            this.gbxStatus.Controls.Add(this.txtLastUpdate);
            this.gbxStatus.Controls.Add(this.lblLastUpdate);
            this.gbxStatus.Controls.Add(this.txtCreationDate);
            this.gbxStatus.Controls.Add(this.txtModified);
            this.gbxStatus.Controls.Add(this.lblCreationDate);
            this.gbxStatus.Controls.Add(this.lblStatus);
            this.gbxStatus.Controls.Add(this.txtStateOffice);
            this.gbxStatus.Controls.Add(this.txtStateCounter);
            this.gbxStatus.FlatStyle = Gizmox.WebGUI.Forms.FlatStyle.Flat;
            this.gbxStatus.Location = new System.Drawing.Point(460, 147);
            this.gbxStatus.Name = "gbxStatus";
            this.gbxStatus.Size = new System.Drawing.Size(169, 197);
            this.gbxStatus.TabIndex = 94;
            this.gbxStatus.TabStop = false;
            this.gbxStatus.Text = "Status";
            // 
            // StaffWizard_General
            // 
            this.Controls.Add(this.gbxStatus);
            this.Controls.Add(this.gbxTimeCard);
            this.Controls.Add(this.lblInitial);
            this.Controls.Add(this.cboSmartTag8);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.cboDeptCode);
            this.Controls.Add(this.lblSmartTag4);
            this.Controls.Add(this.cboPosition);
            this.Controls.Add(this.txtFirstName);
            this.Controls.Add(this.txtInitial);
            this.Controls.Add(this.lblFirstName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblLastName);
            this.Controls.Add(this.txtNameChs);
            this.Controls.Add(this.txtLastName);
            this.Controls.Add(this.txtNameCht);
            this.Controls.Add(this.lblSmartTag5);
            this.Controls.Add(this.lblSmartTag12);
            this.Controls.Add(this.cboSmartTag5);
            this.Controls.Add(this.txtSmartTag12);
            this.Controls.Add(this.lblPosition);
            this.Controls.Add(this.txtSmartTag4);
            this.Controls.Add(this.cmbStaffGrade);
            this.Controls.Add(this.lblMedical);
            this.Controls.Add(this.lblStaffGrade);
            this.Controls.Add(this.txtMedical);
            this.Controls.Add(this.btnChangePassword);
            this.Controls.Add(this.txtEmploymen);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblEmploymen);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblDept);
            this.Controls.Add(this.lblSmartTag8);
            this.Controls.Add(this.datHiredOn);
            this.Controls.Add(this.cboSmartTag6);
            this.Controls.Add(this.lblDateFormat);
            this.Controls.Add(this.lblAssistant);
            this.Controls.Add(this.lblHiredOn);
            this.Controls.Add(this.lblA);
            this.Controls.Add(this.cboSmartTag7);
            this.Controls.Add(this.lblB);
            this.Controls.Add(this.lblNameChs);
            this.Controls.Add(this.lblNameCht);
            this.Location = new System.Drawing.Point(15, 15);
            this.Size = new System.Drawing.Size(642, 360);
            this.Text = "StaffGenneral";
            this.gbxTimeCard.ResumeLayout(false);
            this.gbxStatus.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Gizmox.WebGUI.Forms.Label lblNameCht;
        private Gizmox.WebGUI.Forms.Label lblStatus;
        private Gizmox.WebGUI.Forms.Label lblCreationDate;
        private Gizmox.WebGUI.Forms.Label lblLastUpdate;
        private Gizmox.WebGUI.Forms.Label lblSmartTag5;
        private Gizmox.WebGUI.Forms.Label lblNameChs;
        private Gizmox.WebGUI.Forms.Label lblSmartTag4;
        private Gizmox.WebGUI.Forms.Label lblName;
        private Gizmox.WebGUI.Forms.Label lblInitial;
        private Gizmox.WebGUI.Forms.Label lblStaffGrade;
        private Gizmox.WebGUI.Forms.Label lblPosition;
        private Gizmox.WebGUI.Forms.Label lblAssistant;
        private Gizmox.WebGUI.Forms.Label lblSmartTag8;
        private Gizmox.WebGUI.Forms.Label lblPassword;
        private Gizmox.WebGUI.Forms.Button btnChangePassword;
        private Gizmox.WebGUI.Forms.Label lblA;
        private Gizmox.WebGUI.Forms.Label lblB;
        private Gizmox.WebGUI.Forms.Label lblHiredOn;
        private Gizmox.WebGUI.Forms.Label lblDateFormat;
        private Gizmox.WebGUI.Forms.Label lblMedical;
        private Gizmox.WebGUI.Forms.Label lblEmploymen;
        private Gizmox.WebGUI.Forms.Label lblDept;
        private Gizmox.WebGUI.Forms.Label lblSmartTag12;
        private Gizmox.WebGUI.Forms.Label lblLastName;
        private Gizmox.WebGUI.Forms.Label lblFirstName;
        public Gizmox.WebGUI.Forms.TextBox txtLastName;
        public Gizmox.WebGUI.Forms.TextBox txtFirstName;
        public Gizmox.WebGUI.Forms.TextBox txtNameCht;
        public Gizmox.WebGUI.Forms.TextBox txtNameChs;
        public Gizmox.WebGUI.Forms.TextBox txtName;
        public Gizmox.WebGUI.Forms.TextBox txtInitial;
        public Gizmox.WebGUI.Forms.ComboBox cboSmartTag5;
        public Gizmox.WebGUI.Forms.ComboBox cmbStaffGrade;
        public Gizmox.WebGUI.Forms.ComboBox cboSmartTag6;
        public Gizmox.WebGUI.Forms.TextBox txtPassword;
        public Gizmox.WebGUI.Forms.ComboBox cboSmartTag7;
        public Gizmox.WebGUI.Forms.DateTimePicker datHiredOn;
        public Gizmox.WebGUI.Forms.TextBox txtMedical;
        public Gizmox.WebGUI.Forms.TextBox txtEmploymen;
        public Gizmox.WebGUI.Forms.CheckBox chkAdministration;
        public Gizmox.WebGUI.Forms.CheckBox chkPunch;
        public Gizmox.WebGUI.Forms.TextBox txtSmartTag4;
        public Gizmox.WebGUI.Forms.TextBox txtSmartTag12;
        public Gizmox.WebGUI.Forms.ComboBox cboPosition;
        public Gizmox.WebGUI.Forms.TextBox txtStateCounter;
        public Gizmox.WebGUI.Forms.TextBox txtStateOffice;
        public Gizmox.WebGUI.Forms.TextBox txtModified;
        public Gizmox.WebGUI.Forms.TextBox txtCreationDate;
        public Gizmox.WebGUI.Forms.TextBox txtLastUpdate;
        public Gizmox.WebGUI.Forms.ComboBox cboDeptCode;
        //private Gizmox.WebGUI.Forms.Extenders.SilverlightExtender silverlightExtender1;
        public Gizmox.WebGUI.Forms.ComboBox cboSmartTag8;
        private Gizmox.WebGUI.Forms.GroupBox gbxStatus;
        private Gizmox.WebGUI.Forms.GroupBox gbxTimeCard;
    }
}