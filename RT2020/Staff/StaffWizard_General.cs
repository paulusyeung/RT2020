#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Controls;
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;
#endregion

namespace RT2020.Staff
{
    public partial class StaffWizard_General : UserControl
    {
        #region public properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _StaffId = System.Guid.Empty;
        public Guid StaffId
        {
            get { return _StaffId; }
            set { _StaffId = value; }
        }

        private string _StaffNumber = "";
        public string StaffNumber
        {
            get { return _StaffNumber; }
            set { _StaffNumber = value; }
        }
        #endregion

        public StaffWizard_General()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();
            SetSmartTags();

            FillComo();
            cboSmartTag2.SelectedIndex = 0;
        }

        #region SetCaptions, SetAttributes & SetSmartTags
        private void SetCaptions()
        {
            lblInitial.Text = WestwindHelper.GetWordWithColon("staff.initial", "Model");
            lblLastName.Text = WestwindHelper.GetWordWithColon("staff.lastName", "Model");
            lblFirstName.Text = WestwindHelper.GetWordWithColon("staff.firstName", "Model");
            lblName.Text = WestwindHelper.GetWordWithColon("staff.fullName", "Model");
            lblNameChs.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameCht.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblPosition.Text = WestwindHelper.GetWordWithColon("member.general.job", "Model");

            lblPassword.Text = WestwindHelper.GetWordWithColon("staff.password", "Model");
            lblStaffGrade.Text = WestwindHelper.GetWordWithColon("staffGroup", "Model");
            lblHiredOn.Text = WestwindHelper.GetWordWithColon("staff.hiredOn", "Model");

            lblAssistant.Text = WestwindHelper.GetWordWithColon("staff.assistant", "Model");
            lblEmploymen.Text = WestwindHelper.GetWordWithColon("staff.employmentNumber", "Model");
            lblMedical.Text = WestwindHelper.GetWordWithColon("staff.medicalNumber", "Model");

            lblCreationDate.Text = WestwindHelper.GetWordWithColon("member.general.shop", "Model");
            lblDept.Text = WestwindHelper.GetWordWithColon("department", "Model");

            //lblURLAddress.Text = WestwindHelper.GetWordWithColon("memberClass", "Model");

            gbxTimeCard.Text = WestwindHelper.GetWord("staff.timeCard", "Model");
            chkPunch.Text = WestwindHelper.GetWord("staff.timeCard.punch", "Model");
            chkAdministration.Text = WestwindHelper.GetWord("staff.timeCard.admin", "Model");

            gbxStatus.Text = WestwindHelper.GetWord("glossary.status", "General");
            lblCreationDate.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblLastUpdate.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblStatus.Text = WestwindHelper.GetWordWithColon("glossary.status", "General");
        }

        private void SetAttributes()
        {
            lblDateFormat.Visible = false;                      // 唔使提示

            #region 設定 clickable smart tag 1 label
            //lblSmartTag5.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag1.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag1.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4StaffWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 2 label
            lblSmartTag2.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag2.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag2.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4StaffWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 3 label
            lblSmartTag3.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag3.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag3.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4StaffWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 4 label
            lblSmartTag4.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag4.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag4.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4StaffWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable saluation label
            lblStaffGrade.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblStaffGrade.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblStaffGrade.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new StaffGroupWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillGroup();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable job title label
            lblPosition.AutoSize = true;                        // 減少 whitespace，有字嘅位置先可以 click
            lblPosition.Cursor = Cursors.Hand;                  // cursor over 顯示 hand cursor
            lblPosition.Click += (s, e) =>                      // 彈出 wizard
            {
                var dialog = new StaffJobTitleWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillPosition();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable dept label
            //lblDept.AutoSize = true;                        // 減少 whitespace，有字嘅位置先可以 click
            lblDept.Cursor = Cursors.Hand;                  // cursor over 顯示 hand cursor
            lblDept.Click += (s, e) =>                      // 彈出 wizard
            {
                var dialog = new StaffDeptWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillDept();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void SetSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            var smartTagList = ModelEx.SmartTag4StaffEx.GetListOrderBy(orderBy, true);

            SmartTagHelper oTag = new SmartTagHelper(this);
            oTag.StaffSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }
        #endregion

        #region fill combo boxes
        #region FillComo
        private void FillComo()
        {
            FillGroup();
            FillDept();
            FillPosition();
            //FillSex();
            FillAssistants();

            ModelEx.SmartTag4Staff_OptionsEx.FillSmartTagComboBox(ref cboSmartTag1, 1);
            ModelEx.SmartTag4Staff_OptionsEx.FillSmartTagComboBox(ref cboSmartTag2, 2);
        }
        #endregion

        #region FillGroup
        private void FillGroup()
        {
            var textFields = new string[] { "GradeCode", "GradeName" };
            var pattern = "{0} - {1}";
            var orderBy = new string[] { "GradeCode" };

            ModelEx.StaffGroupEx.LoadCombo(ref cmbStaffGrade, textFields, pattern, true, false, "", "", orderBy);
        }
        #endregion

        #region FillDept
        private void FillDept()
        {
            var textFields = new string[] { "DeptCode", "DeptName" };
            var pattern = "{0} - {1}";
            var orderBy = new string[] { "DeptCode" };

            ModelEx.StaffDeptEx.LoadCombo(ref cboDeptCode, textFields, pattern, true, true, "", "", orderBy);
        }
        #endregion

        #region FillPosition
        private void FillPosition()
        {
            var textFields = new string[] { "JobTitleCode", "JobTitleName" };
            var pattern = "{0} - {1}";
            var orderBy = new string[] { "JobTitleCode" };

            ModelEx.StaffJobTitleEx.LoadCombo(ref cboPosition, textFields, pattern, true, true, "", "", orderBy);
        }
        #endregion

        #region FillSex
        private void FillSex()
        {
            cboSmartTag1.Items.Clear();
            cboSmartTag1.Items.Add("Male");
            cboSmartTag1.Items.Add("Female");
            cboSmartTag1.SelectedIndex = 0;
        }
        #endregion

        #region Fill Assistants

        private void FillAssistants()
        {
            var textFields = new string[] { "StaffNumber", "StaffCode" };
            var pattern = "{0} - {1}";
            var sql = string.Format("StaffId NOT IN ('{0}') AND Status > 0", _StaffId.ToString());
            var orderBy = new string[] { "StaffNumber" };

            ModelEx.StaffEx.LoadCombo(ref cboSmartTag5, textFields, pattern, true, true, string.Empty, sql, orderBy);
            //if (cboSmartTag6.Items.Count > 0) cboSmartTag6.SelectedIndex = 0;

            ModelEx.StaffEx.LoadCombo(ref cboSmartTag6, textFields, pattern, true, true, string.Empty, sql, orderBy);
            //if (cboSmartTag7.Items.Count > 0) cboSmartTag7.SelectedIndex = 0;  
        }

        #endregion
        #endregion

        #region public method: LoadGeneralData
        public void LoadGeneralData()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    if (_StaffId != Guid.Empty)
                    {
                        LoadCoreData();
                        LoadInternetTag();
                        LoadHR();
                        LoadSmartTagValues();
                    }
                    break;
            }
        }

        private void LoadCoreData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var staff = ctx.Staff.Find(_StaffId);
                if (staff != null)
                {
                    txtInitial.Text = staff.StaffCode;
                    txtFirstName.Text = staff.FirstName;
                    txtLastName.Text = staff.LastName;
                    txtName.Text = staff.FullName;
                    txtNameChs.Text = staff.FullName_Chs;
                    txtNameCht.Text = staff.FullName_Cht;
                    txtPassword.Text = staff.Password;
                    txtCreationDate.Text = DateTimeHelper.DateTimeToString(staff.CreatedOn, false);
                    txtLastUpdate.Text = DateTimeHelper.DateTimeToString(staff.ModifiedOn, false);
                    txtModified.Text = ModelEx.StaffEx.GetStaffNumberById(staff.ModifiedBy);
                    txtStateOffice.Text = "";
                    txtStateCounter.Text = "";
                    cboPosition.SelectedValue = staff.JobTitleId.HasValue ? staff.JobTitleId.Value : Guid.Empty;
                    cmbStaffGrade.SelectedValue = staff.GroupId.HasValue ? staff.GroupId.Value : Guid.Empty;
                    cboDeptCode.SelectedValue = staff.DeptId.HasValue ? staff.DeptId.Value : Guid.Empty;

                    #region txtStateOffice.Text
                    if (staff.DownloadToPOS)
                    {
                        if (staff.CreatedOn.Date.Equals(staff.ModifiedOn.Date))
                        {
                            txtStateOffice.Text = "A";
                        }
                        else
                        {
                            txtStateOffice.Text = "M";
                        }
                    }
                    #endregion

                    #region txtStateCounter.Text
                    if (staff.DownloadToCounter)
                    {
                        if (staff.CreatedOn.Date.Equals(staff.ModifiedOn.Date))
                        {
                            txtStateCounter.Text = "A";
                        }
                        else
                        {
                            txtStateCounter.Text = "M";
                        }
                    }
                    #endregion
                }
            }
        }

        private void LoadInternetTag()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var staff = ctx.StaffInternetTag.Where(x => x.StaffId == _StaffId).AsNoTracking().FirstOrDefault();
                if (staff != null)
                {
                    #region Tag: Internet
                    var internetTag = ctx.InternetTag.Where(x => x.TagCode == "Internet").AsNoTracking().FirstOrDefault();
                    if (internetTag != null)
                    {
                        if (staff.InternetTag1 == internetTag.TagId)
                        {
                            txtSmartTag3.Text = staff.InternetTag1Value;
                        }
                        else if (staff.InternetTag2 == internetTag.TagId)
                        {
                            txtSmartTag3.Text = staff.InternetTag2Value;
                        }
                        else if (staff.InternetTag3 == internetTag.TagId)
                        {
                            txtSmartTag3.Text = staff.InternetTag3Value;
                        }
                    }
                    #endregion

                    #region Tag: Exchange
                    var internetTagEx = ctx.InternetTag.Where(x => x.TagCode == "Exchange").AsNoTracking().FirstOrDefault();
                    if (internetTag != null)
                    {
                        if (staff.InternetTag1 == internetTagEx.TagId)
                        {
                            txtSmartTag4.Text = staff.InternetTag1Value;
                        }
                        else if (staff.InternetTag2 == internetTagEx.TagId)
                        {
                            txtSmartTag4.Text = staff.InternetTag2Value;
                        }
                        else if (staff.InternetTag3 == internetTagEx.TagId)
                        {
                            txtSmartTag4.Text = staff.InternetTag3Value;
                        }
                    }
                    #endregion

                    #region Tag: URL
                    var internetTagURL = ctx.InternetTag.Where(x => x.TagCode == "URL").AsNoTracking().FirstOrDefault();
                    if (internetTag != null)
                    {
                        if (staff.InternetTag1 == internetTagURL.TagId)
                        {
                            //txtSmartTag11.Text = staff.InternetTag1Value;
                        }
                        else if (staff.InternetTag2 == internetTagURL.TagId)
                        {
                            //txtSmartTag11.Text = staff.InternetTag2Value;
                        }
                        else if (staff.InternetTag3 == internetTagURL.TagId)
                        {
                            //txtSmartTag11.Text = staff.InternetTag3Value;
                        }
                    }
                    #endregion
                }
            }
        }

        private void LoadHR()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hr = ctx.StaffHR.Where(x => x.StaffId == _StaffId).AsNoTracking().FirstOrDefault();
                if (hr != null)
                {
                    txtEmploymen.Text = hr.EmploymentNumber;
                    txtMedical.Text = hr.MedicalNumber;
                    datHiredOn.Value = hr.HiredOn;
                    chkPunch.Checked = hr.TC_PunchEnable_InOut;
                    chkAdministration.Checked = hr.TC_AdminEnable;
                }
            }
        }

        private void LoadSmartTagValues()
        {
            foreach (Control Ctrl in Controls)
            {
                if (Ctrl.Name.Contains("SmartTag") && !Ctrl.Name.StartsWith("lbl"))
                {
                    ModelEx.StaffSmartTagEx.LoadSmartTagValue(_StaffId, Ctrl);
                }
            }
        }

        private void GetSmartValue(Guid staffId, Control Ctrl)
        {
            string sql = "StaffId = '" + staffId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            Guid tagId = Guid.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    tagId = (Guid)Ctrl.Tag;

                    var oTag = ModelEx.StaffSmartTagEx.Get(staffId, tagId);
                    if (oTag != null)
                    {
                        if (Ctrl.GetType().Equals(typeof(TextBox)))
                        {
                            TextBox txtTag = Ctrl as TextBox;
                            txtTag.Text = oTag.SmartTagValue;
                        }

                        if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                        {
                            MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                            txtTag.Text = oTag.SmartTagValue;
                        }

                        if (Ctrl.GetType().Equals(typeof(ComboBox)))
                        {
                            var id = Guid.Empty;
                            if (Guid.TryParse(oTag.SmartTagValue, out id))
                            {
                                // 2020.12.28 paulus: 如果係 combo box，個 value = dbo.SmartTag_Options.OptionId
                                ComboBox cboTag = Ctrl as ComboBox;
                                //cboTag.Text = oTag.SmartTagValue;
                                cboTag.SelectedValue = id;
                            }
                        }

                        if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                        {
                            DateTimePicker dtpTag = Ctrl as DateTimePicker;
                            //2014.01.08 paulus: 可以唔輸入 birthday，先決係要有 ShowCheckBox，然後根據 value
                            //舊 code: dtpTag.Value = (oTag.SmartTagValue.Length == 0) ? DateTime.Now : Convert.ToDateTime(ReformatDateTime(oTag.SmartTagValue));
                            if (dtpTag.ShowCheckBox)
                            {
                                if (oTag.SmartTagValue.Length == 0)
                                {
                                    dtpTag.Value = dtpTag.MinDate;
                                    dtpTag.Checked = false;
                                }
                                else
                                {
                                    dtpTag.Value = Convert.ToDateTime(DateTimeHelper.ReformatDateTime(oTag.SmartTagValue));
                                    dtpTag.Checked = true;
                                }
                            }
                            else
                            {
                                dtpTag.Value = (oTag.SmartTagValue.Length == 0) ? dtpTag.MinDate : Convert.ToDateTime(DateTimeHelper.ReformatDateTime(oTag.SmartTagValue));
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region public method: SaveGeneralData
        public bool SaveGeneralData()
        {
            var result = false;

            try
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    #region save core data
                    var staff = ctx.Staff.Find(_StaffId);
                    if (staff == null)
                    {
                        #region add new dbo.Staff
                        staff = new EF6.Staff();
                        staff.StaffId = Guid.NewGuid();
                        staff.StaffNumber = _StaffNumber;
                        staff.CreatedOn = DateTime.Now;
                        staff.CreatedBy = ConfigHelper.CurrentUserId;
                        staff.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                        ctx.Staff.Add(staff);

                        _StaffId = staff.StaffId;
                        #endregion
                    }
                    else
                    {
                        staff.Status = Convert.ToInt32(EnumHelper.Status.Modified.ToString("d"));
                    }

                    staff.StaffCode = txtInitial.Text.Trim();
                    staff.FirstName = txtFirstName.Text.Trim();
                    staff.LastName = txtLastName.Text.Trim();
                    staff.FullName = txtName.Text.Trim();
                    staff.FullName_Chs = txtNameChs.Text.Trim();
                    staff.FullName_Cht = txtNameCht.Text.Trim();
                    staff.Password = txtPassword.Text.Trim();
                    if ((Guid)cboDeptCode.SelectedValue != Guid.Empty) staff.DeptId = (Guid)cboDeptCode.SelectedValue;
                    if ((Guid)cboPosition.SelectedValue != Guid.Empty) staff.JobTitleId = (Guid)cboPosition.SelectedValue;
                    if ((Guid)cmbStaffGrade.SelectedValue != Guid.Empty) staff.GroupId = (Guid)cmbStaffGrade.SelectedValue;

                    staff.DownloadToCounter = true;
                    staff.DownloadToPOS = true;
                    staff.ModifiedOn = DateTime.Now;
                    staff.ModifiedBy = ConfigHelper.CurrentUserId;

                    ctx.SaveChanges();

                    // 2013.11.27 paulus: 要同時更新 UserProfile 的資料，否則 login 時就沒有這個 Staff 的資料
                    RT2020.Controls.UserProfile.SaveRec(staff.StaffId, (int)EnumHelper.UserType.Staff, staff.StaffNumber, staff.Password, staff.StaffCode);

                    #region log activity (Update)
                    RT2020.Controls.Log4net.LogInfo(ctx.Entry(staff).State == EntityState.Added ?
                        RT2020.Controls.Log4net.LogAction.Create : RT2020.Controls.Log4net.LogAction.Update,
                        staff.ToString());
                    #endregion

                    #endregion

                    #region save staff HR
                    var hr = ctx.StaffHR.Where(x => x.StaffId == _StaffId).FirstOrDefault();
                    if (hr == null)
                    {
                        #region add new dbo.StaffHR
                        hr = new EF6.StaffHR();
                        hr.HRId = Guid.NewGuid();
                        hr.StaffId = _StaffId;

                        ctx.StaffHR.Add(hr);
                        #endregion
                    }

                    hr.HiredOn = datHiredOn.Value;
                    hr.EmploymentNumber = txtEmploymen.Text.Trim();
                    hr.MedicalNumber = txtMedical.Text.Trim();
                    hr.TC_PunchEnable_InOut = chkPunch.Checked;
                    hr.TC_AdminEnable = chkAdministration.Checked;

                    ctx.SaveChanges();
                    #endregion
                }

                #region SaveSmartTagValues
                foreach (Control Ctrl in Controls)
                {
                    if (Ctrl.Name.Contains("SmartTag") && !Ctrl.Name.StartsWith("lbl"))
                    {
                        ModelEx.StaffSmartTagEx.SaveSmartTagValue(_StaffId, Ctrl);
                    }
                }
                #endregion

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            return result;
        }
        #endregion

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            ChangePassword changePassword = new ChangePassword();
            changePassword.StaffId = _StaffId;
            changePassword.Closed += new EventHandler(changePassword_Closed);
            changePassword.ShowDialog(); 

        }

        void changePassword_Closed(object sender, EventArgs e)
        {
            ChangePassword changePassword = sender as ChangePassword;
            if (changePassword.IsCompleted)
            {
                txtPassword.Text = changePassword.Password;
            }
        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {
            if (txtFirstName.Text.Trim().Length > 0)
            {
                if (txtLastName.Text.Trim().Length > 0)
                {
                    txtName.Text = txtLastName.Text.Trim() + "," + txtFirstName.Text.Trim();
                }
                else
                {
                    txtName.Text = txtFirstName.Text.Trim();
                }
            }
            else
            {
                txtName.Text = txtLastName.Text.Trim();
            }
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            if (txtLastName.Text.Trim().Length > 0)
            {
                if (txtFirstName.Text.Trim().Length > 0)
                {
                    txtName.Text = txtLastName.Text.Trim() + "," + txtFirstName.Text.Trim();
                }
                else
                {
                    txtName.Text = txtLastName.Text.Trim();
                }
            }
            else
            {
                txtName.Text = txtFirstName.Text.Trim();
            }
        }
    }
}