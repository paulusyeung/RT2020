#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using RT2020.DAL;
using System.Linq;
using System.Data.Entity;
#endregion

namespace RT2020.Staff
{
    public partial class StaffCode : Form
    {
        StaffGeneral general;
        StaffPersonal peronal;

        public StaffCode()
        {
            InitializeComponent();
            TalCtrl();
        }

        private void StaffCode_Load(object sender, EventArgs e)
        {
            if (this.StaffId == System.Guid.Empty)
            {
                toolBarDelete.Enabled = false;
                txtStaffNumber.ReadOnly = false;
                txtStaffNumber.BackColor = Color.LightSkyBlue;
            }
            else
            {
                SetData();
            }
        }

        #region Properties
        private Guid staffId = System.Guid.Empty;
        public Guid StaffId
        {
            get
            {
                return staffId;
            }
            set
            {
                staffId = value;
            }
        }
        #endregion

        #region TalCtrl
        private void TalCtrl()
        {
            general = new StaffGeneral();
            general.Dock = DockStyle.Fill;
            general.StaffId = this.StaffId;
            tabGeneral.Controls.Add(general);

            peronal = new StaffPersonal();
            peronal.Dock = DockStyle.Fill;
            peronal.StaffId = this.StaffId;
            tabPersonal.Controls.Add(peronal);


        }
        #endregion

        #region SetData
        private void SetData()
        {
            RT2020.DAL.Staff staff = RT2020.DAL.Staff.Load(this.StaffId);
            if (staff != null)
            {
                txtStaffNumber.Text = staff.StaffNumber;
                general.txtInitial.Text = staff.StaffCode;
                general.txtFirstName.Text = staff.FirstName;
                general.txtLastName.Text = staff.LastName;
                general.txtName.Text = staff.FullName;
                general.txtNameChs.Text = staff.FullName_Chs;
                general.txtNameCht.Text = staff.FullName_Cht;
                general.txtPassword.Text = staff.Password;
                general.txtCreationDate.Text = RT2020.SystemInfo.Settings.DateTimeToString(staff.CreatedOn, false);
                general.txtLastUpdate.Text = RT2020.SystemInfo.Settings.DateTimeToString(staff.ModifiedOn, false);
                general.txtModified.Text = GetStaffNum(staff.ModifiedBy);
                general.txtStateOffice.Text = "";
                general.txtStateCounter.Text = "";
                general.cmbPosition.SelectedValue = staff.JobTitleId;
                general.cmbStaffGrade.SelectedValue = staff.GroupId;
                general.cboDeptCode.SelectedValue = staff.DeptId;

                if (staff.DownloadToPOS)
                {
                    if (staff.CreatedOn.Date.Equals(staff.ModifiedOn.Date))
                    {
                        general.txtStateOffice.Text = "A";
                    }
                    else
                    {
                        general.txtStateOffice.Text = "M";
                    }
                }

                if (staff.DownloadToCounter)
                {
                    if (staff.CreatedOn.Date.Equals(staff.ModifiedOn.Date))
                    {
                        general.txtStateCounter.Text = "A";
                    }
                    else
                    {
                        general.txtStateCounter.Text = "M";
                    }
                }
            }

            GetSmartValue(this.StaffId);
            SetAddress(this.StaffId);
            GetStaffInternetTag(this.StaffId);
            GetStaffHR(this.StaffId);
        }
        #endregion

        #region GetStaffNum
        private string GetStaffNum(Guid ModifiedId)
        {
            RT2020.DAL.Staff staff = RT2020.DAL.Staff.Load(ModifiedId);
            if (staff != null)
            {
                return staff.StaffNumber;
            }
            else
            {
                return string.Empty;
            }
        }
        #endregion

        #region SetAddress
        private void SetAddress(Guid staffID)
        {
            if (staffID != Guid.Empty)
            {
                using (var ctx = new EF6.RT2020Entities())
                {
                    var sa = ctx.StaffAddress.Where(x => x.StaffId == staffID).AsNoTracking().FirstOrDefault();
                    if (sa != null)
                    {
                        peronal.txtAddress.Text = sa.Address;
                        peronal.txtPostal.Text = sa.PostalCode;
                        peronal.cmbCountry.SelectedValue = sa.CountryId;
                        peronal.cmbProvince.SelectedValue = sa.ProvinceId;
                        peronal.cmbCity.SelectedValue = sa.CityId;
                    }
                }
            }
        }
        #endregion

        #region GetSmartValue
        private void GetSmartValue(Guid staffId)
        {
            for (int i = 0; i < general.Controls[0].Controls.Count; i++)
            {
                Control Ctrl = general.Controls[0].Controls[i];
                GetSmartValue(staffId, Ctrl);
            }

            for (int i = 0; i < peronal.Controls[0].Controls.Count; i++)
            {
                Control Ctrl = peronal.Controls[0].Controls[i];
                GetSmartValue(staffId, Ctrl);
            }
        }

        private void GetSmartValue(Guid staffId, Control Ctrl)
        {
            string sql = "StaffId = '" + staffId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            string tagId = string.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    tagId = Ctrl.Tag.ToString();

                    if (Common.Utility.IsGUID(tagId))
                    {
                        StaffSmartTag oTag = StaffSmartTag.LoadWhere(string.Format(sql, tagId));
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
                                ComboBox cboTag = Ctrl as ComboBox;
                                cboTag.Text = oTag.SmartTagValue;
                            }

                            if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                            {
                                DateTimePicker dtpTag = Ctrl as DateTimePicker;
                                dtpTag.Value = (oTag.SmartTagValue.Length == 0) ? DateTime.Now : Convert.ToDateTime(ReformatDateTime(oTag.SmartTagValue));
                            }
                        }
                    }
                }
            }
        }

        private string ReformatDateTime(string value)
        {
            int index = value.IndexOf(" ");
            if (index > 0)
            {
                value = value.Remove(index);
                index = value.IndexOf("/");
                if (index > 0)
                {
                    string[] values = value.Split('/');
                    if (values.Length == 3)
                    {
                        if (Convert.ToInt32(values[1]) > 12)
                        {
                            value = values[2].Trim() + "-" + values[0].Trim() + "-" + values[1].Trim();
                        }
                        else
                        {
                            value = values[2].Trim() + "-" + values[1].Trim() + "-" + values[0].Trim();
                        }
                    }
                }
            }
            return value;
        }
        #endregion

        #region GetStaffInternetTag
        private void GetStaffInternetTag(System.Guid staffID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var staff = ctx.StaffInternetTag.Where(x => x.StaffId == staffId).AsNoTracking().FirstOrDefault();
                if (staff != null)
                {
                    var internetTag = ctx.InternetTag.Where(x => x.TagCode == "Internet").AsNoTracking().FirstOrDefault();
                    if (internetTag != null)
                    {
                        if (staff.InternetTag1 == internetTag.TagId)
                        {
                            general.txtIntAddress.Text = staff.InternetTag1Value;
                        }
                        else if (staff.InternetTag2 == internetTag.TagId)
                        {
                            general.txtIntAddress.Text = staff.InternetTag2Value;
                        }
                        else if (staff.InternetTag3 == internetTag.TagId)
                        {
                            general.txtIntAddress.Text = staff.InternetTag3Value;
                        }
                    }

                    var internetTagEx = ctx.InternetTag.Where(x => x.TagCode == "Exchange").AsNoTracking().FirstOrDefault();
                    if (internetTag != null)
                    {
                        if (staff.InternetTag1 == internetTagEx.TagId)
                        {
                            general.txtExAddress.Text = staff.InternetTag1Value;
                        }
                        else if (staff.InternetTag2 == internetTagEx.TagId)
                        {
                            general.txtExAddress.Text = staff.InternetTag2Value;
                        }
                        else if (staff.InternetTag3 == internetTagEx.TagId)
                        {
                            general.txtExAddress.Text = staff.InternetTag3Value;
                        }
                    }

                    var internetTagURL = ctx.InternetTag.Where(x => x.TagCode == "URL").AsNoTracking().FirstOrDefault();
                    if (internetTag != null)
                    {
                        if (staff.InternetTag1 == internetTagURL.TagId)
                        {
                            general.txtURLAddress.Text = staff.InternetTag1Value;
                        }
                        else if (staff.InternetTag2 == internetTagURL.TagId)
                        {
                            general.txtURLAddress.Text = staff.InternetTag2Value;
                        }
                        else if (staff.InternetTag3 == internetTagURL.TagId)
                        {
                            general.txtURLAddress.Text = staff.InternetTag3Value;
                        }
                    }

                }
            }
        }
        #endregion

        #region GetStaffHR
        private void GetStaffHR(System.Guid staffID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hr = ctx.StaffHR.Where(x => x.StaffId == staffID).AsNoTracking().FirstOrDefault();
                if (hr != null)
                {
                    general.txtEmploymen.Text = hr.EmploymentNumber;
                    general.txtMedical.Text = hr.MedicalNumber;
                    general.dateofApt.Value = hr.HiredOn;
                    general.chkPunch.Checked = hr.TC_PunchEnable_InOut;
                    general.chkAdministration.Checked = hr.TC_AdminEnable;
                    peronal.txtSalary.Text = hr.Salary.Value.ToString("n");
                    peronal.txtBankAC.Text = hr.BankAccountNumber;
                }
            }
        }
        #endregion

        #region Save
        private void Save(System.Guid staffID)
        {
            if (txtStaffNumber.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtStaffNumber, "Cannot be blank!");
            }
            else
            {
                errorProvider.SetError(txtStaffNumber, string.Empty);

                if (!txtStaffNumber.ReadOnly)
                {
                    txtStaffNumber.ReadOnly = true;
                    txtStaffNumber.BackColor = Color.LightYellow;
                }

                this.StaffId = AddStaff(this.StaffId);
                if (this.StaffId != System.Guid.Empty)
                {
                    AddStaffAddress(this.StaffId);
                    AddStaffHR(this.staffId);
                    AddStaffInternet(this.StaffId);
                    AddStaffSmart(this.StaffId);
                }

                if (this.StaffId != System.Guid.Empty)
                {
                    SetData();

                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                    MessageBox.Show("Save successfully!", "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        #endregion

        #region AddStaff
        private bool CheckStaffExists()
        {
            RT2020.DAL.Staff staff = RT2020.DAL.Staff.LoadWhere("StaffNumber = '" + txtStaffNumber.Text.Trim() + "'");
            if (staff != null)
            {
                if (staff.Retired)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        private bool Verify()
        {
            if (!Common.Utility.IsNumeric(peronal.txtSalary.Text))
            {
                errorProvider.SetError(peronal.txtSalary, Resources.Common.DigitalNeeded);
                tabPersonal.Select();
                return false;
            }
            else
            {
                errorProvider.SetError(peronal.txtSalary, string.Empty);
                return true;
            }
        }

        private Guid AddStaff(System.Guid staffID)
        {
            bool canSave = false, isNew = false;
            System.Guid sId = System.Guid.Empty;

            RT2020.DAL.Staff staff;
            if (staffID == System.Guid.Empty)
            {
                staff = new RT2020.DAL.Staff();

                staff.StaffNumber = txtStaffNumber.Text.Trim();
                staff.CreatedOn = DateTime.Now;
                staff.CreatedBy = Common.Config.CurrentUserId;
                staff.Status = Convert.ToInt32(Common.Enums.Status.Active.ToString("d"));
                isNew = true; 

                canSave = CheckStaffExists();

                
                if (canSave)
                {
                    errorProvider.SetError(txtStaffNumber, "Duplicated Staff #!");
                }
                else
                {
                    errorProvider.SetError(txtStaffNumber, string.Empty);
                }
            }
            else
            {
                staff = RT2020.DAL.Staff.Load(staffID);               
            }

            staff.StaffCode = general.txtInitial.Text.Trim();
            staff.FirstName = general.txtFirstName.Text.Trim();
            staff.LastName = general.txtLastName.Text.Trim();
            staff.FullName = general.txtName.Text.Trim();
            staff.FullName_Chs = general.txtNameChs.Text.Trim();
            staff.FullName_Cht = general.txtNameCht.Text.Trim();
            staff.Password = general.txtPassword.Text.Trim();
            staff.DeptId = (general.cboDeptCode.SelectedValue == null) ? System.Guid.Empty : new Guid(general.cboDeptCode.SelectedValue.ToString());
            staff.JobTitleId = (general.cmbPosition.SelectedValue == null) ? System.Guid.Empty : new Guid(general.cmbPosition.SelectedValue.ToString());
            staff.GroupId = (general.cmbStaffGrade.SelectedValue == null) ? System.Guid.Empty : new Guid(general.cmbStaffGrade.SelectedValue.ToString());
            staff.DownloadToCounter = true;
            staff.DownloadToPOS = true;
            staff.ModifiedOn = DateTime.Now;
            staff.ModifiedBy = Common.Config.CurrentUserId;

            if (!isNew)
            {
                staff.Status = Convert.ToInt32(Common.Enums.Status.Modified.ToString("d"));
            }

            if (!canSave)
            {
                staff.Save();
                sId = staff.StaffId;

                // 2013.11.27 paulus: 要同時更新 UserProfile 的資料，否則 login 時就沒有這個 Staff 的資料
                RT2020.Controls.UserProfile.SaveRec(staff.StaffId, (int)RT2020.DAL.Common.Enums.UserType.Staff, staff.StaffNumber, staff.Password, staff.StaffCode);

                if (isNew)
                {// log activity (New Record)
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Create, staff.ToString());
                }
                else
                { // log activity (Update)
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Update, staff.ToString());
                }                                
            }

            return sId;
        }
        #endregion

        #region AddStaffAddress
        private void AddStaffAddress(System.Guid staffID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var sa = ctx.StaffAddress.Where(x => x.StaffId == staffID).AsNoTracking().FirstOrDefault();
                if (sa != null)
                {
                    sa = new EF6.StaffAddress();
                    sa.AddressId = Guid.NewGuid();
                    sa.StaffId = staffID;
                    ctx.StaffAddress.Add(sa);
                }
                sa.Address = peronal.txtAddress.Text.Trim();
                if ((Guid)peronal.cmbCountry.SelectedValue != Guid.Empty) sa.CountryId = (Guid)peronal.cmbCountry.SelectedValue;
                if ((Guid)peronal.cmbProvince.SelectedValue != Guid.Empty) sa.ProvinceId = (Guid)peronal.cmbProvince.SelectedValue;
                if ((Guid)peronal.cmbCity.SelectedValue != Guid.Empty) sa.CityId = (Guid)peronal.cmbCity.SelectedValue;
                sa.PostalCode = peronal.txtPostal.Text.Trim();

                ctx.SaveChanges();
            }
        }
        #endregion

        #region AddStaffHR
        private void AddStaffHR(System.Guid staffID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var hr = ctx.StaffHR.Where(x => x.StaffId == staffID).AsNoTracking().FirstOrDefault();
                if (hr == null)
                {
                    hr = new EF6.StaffHR();
                    hr.HRId = Guid.NewGuid();
                    hr.StaffId = staffID;
                    ctx.StaffHR.Add(hr);
                }

                hr.HiredOn = general.dateofApt.Value;
                hr.EmploymentNumber = general.txtEmploymen.Text.Trim();
                hr.MedicalNumber = general.txtMedical.Text.Trim();
                hr.TC_PunchEnable_InOut = general.chkPunch.Checked;
                hr.TC_AdminEnable = general.chkAdministration.Checked;
                if (peronal.txtSalary.Text.Trim().Length > 0)
                {
                    hr.Salary = Convert.ToDecimal(peronal.txtSalary.Text.Trim());
                }
                hr.BankAccountNumber = peronal.txtBankAC.Text.Trim();

                ctx.SaveChanges();
            }
        }
        #endregion

        #region AddStaffInternet
        private void AddStaffInternet(System.Guid staffID)
        {
            AddStaffInternetTag(staffID, "Internet", general.txtIntAddress.Text.Trim());
            AddStaffInternetTag(staffID, "Exchange", general.txtExAddress.Text.Trim());
            AddStaffInternetTag(staffID, "URL", general.txtURLAddress.Text.Trim());
        }
        #endregion

        #region AddStaffInternetTag
        private void AddStaffInternetTag(System.Guid staffID, string tagCode, string tagValue)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var internetTag = ctx.InternetTag.Where(x => x.TagCode == tagCode).AsNoTracking().FirstOrDefault();
                if (internetTag != null)
                {
                    var tag = ctx.StaffInternetTag.Where(x => x.StaffId == staffID).FirstOrDefault();
                    if (tag == null)
                    {
                        tag = new EF6.StaffInternetTag();
                        tag.TagId = Guid.NewGuid();
                        tag.StaffId = staffID;

                        ctx.StaffInternetTag.Add(tag);

                        if (tagCode == "Internet")
                        {
                            tag.InternetTag1 = internetTag.TagId;
                            tag.InternetTag1Value = tagValue;
                        }
                        else if (tagCode == "Exchange")
                        {
                            tag.InternetTag2 = internetTag.TagId;
                            tag.InternetTag2Value = tagValue;
                        }
                        else if (tagCode == "URL")
                        {
                            tag.InternetTag3 = internetTag.TagId;
                            tag.InternetTag3Value = tagValue;
                        }

                    }
                    else
                    {
                        if (tag.InternetTag1 == internetTag.TagId)
                        {
                            tag.InternetTag1Value = tagValue;
                        }
                        else if (tag.InternetTag2 == internetTag.TagId)
                        {
                            tag.InternetTag2Value = tagValue;
                        }
                        else if (tag.InternetTag3 == internetTag.TagId)
                        {
                            tag.InternetTag3Value = tagValue;
                        }
                        else
                        {
                            if (tagCode == "Internet")
                            {
                                tag.InternetTag1 = internetTag.TagId;
                                tag.InternetTag1Value = tagValue;
                            }
                            else if (tagCode == "Exchange")
                            {
                                tag.InternetTag2 = internetTag.TagId;
                                tag.InternetTag2Value = tagValue;
                            }
                            else if (tagCode == "URL")
                            {
                                tag.InternetTag3 = internetTag.TagId;
                                tag.InternetTag3Value = tagValue;
                            }
                        }
                    }
                    ctx.SaveChanges();
                }
            }
        }
        #endregion

        #region AddStaffSmart
        private void AddStaffSmart(Guid staffId)
        {
            for (int i = 0; i < general.Controls[0].Controls.Count; i++)
            {
                Control Ctrl = general.Controls[0].Controls[i];
                AddStaffSmart(staffId, Ctrl);
            }

            for (int i = 0; i < peronal.Controls[0].Controls.Count; i++)
            {
                Control Ctrl = peronal.Controls[0].Controls[i];
                AddStaffSmart(staffId, Ctrl);
            }
        }

        private void AddStaffSmart(Guid staffId, Control Ctrl)
        {
            string sql = "StaffId = '" + staffId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            string tagId = string.Empty;
            string value = string.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    if (Ctrl.GetType().Equals(typeof(TextBox)))
                    {
                        TextBox txtTag = Ctrl as TextBox;
                        tagId = txtTag.Tag.ToString();
                        value = txtTag.Text;
                    }

                    if (Ctrl.GetType().Equals(typeof(MaskedTextBox)))
                    {
                        MaskedTextBox txtTag = Ctrl as MaskedTextBox;
                        tagId = txtTag.Tag.ToString();
                        value = txtTag.Text;
                    }

                    if (Ctrl.GetType().Equals(typeof(ComboBox)))
                    {
                        ComboBox cboTag = Ctrl as ComboBox;
                        tagId = cboTag.Tag.ToString();
                        value = cboTag.Text;
                    }

                    if (Ctrl.GetType().Equals(typeof(DateTimePicker)))
                    {
                        DateTimePicker dtpTag = Ctrl as DateTimePicker;
                        tagId = dtpTag.Tag.ToString();
                        value = dtpTag.Value.ToString("yyyy-MM-dd");
                    }

                    if (Common.Utility.IsGUID(tagId))
                    {
                        StaffSmartTag oTag = StaffSmartTag.LoadWhere(string.Format(sql, tagId));
                        if (oTag == null)
                        {
                            oTag = new StaffSmartTag();
                            oTag.StaffId = staffId;
                            oTag.TagId = new Guid(tagId);
                        }
                        oTag.SmartTagValue = value;
                        oTag.Save();
                    }
                }
            }
        }
        #endregion

        #region SetAddNew
        private void SetAddNew()
        {
            toolBarDelete.Enabled = false;
            txtStaffNumber.ReadOnly = false;
            txtStaffNumber.BackColor = Color.LightSkyBlue;
            txtStaffNumber.Text = "";
            this.StaffId = System.Guid.Empty;
            tabGeneral.Controls.Clear();
            tabPersonal.Controls.Clear();
            TalCtrl();
         
        }
        #endregion

        #region Delete
        private void Delete(System.Guid staffID)
        {
            RT2020.DAL.Staff staff = RT2020.DAL.Staff.Load(staffID);
            if (staff != null)
            {
                staff.Status = Convert.ToInt32(Common.Enums.Status.Inactive.ToString("d"));

                staff.Retired = true;
                staff.RetiredBy = Common.Config.CurrentUserId;
                staff.RetiredOn = DateTime.Now;

                staff.ModifiedBy = Common.Config.CurrentUserId;
                staff.ModifiedOn = DateTime.Now;

                staff.Save();

                // 2013.11.27 paulus: 要同時刪除 UserProfile 的資料
                RT2020.Controls.UserProfile.DelRec(staff.StaffId);

                // log activity
                RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, staff.ToString());
            }

            MessageBox.Show("Delete succeeded.", "Delete Result");
        }
        #endregion

        private void toolBar_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            switch (e.Button.Tag.ToString().ToLower())
            {
                case "save":
                    MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveMessageHandler));
                    break;
                case "savenew":
                    MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveNewMessageHandler));
                    break;
                case "saveclose":
                    MessageBox.Show("Save Record And Close?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveCloseMessageHandler));
                    break;
                case "delete":
                    MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteMessageHandler));
                    break;
            }
        }

        private void SaveMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Verify())
                {
                    Save(this.StaffId);
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Verify())
                {
                    Save(this.StaffId);
                    SetAddNew();
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Verify())
                {
                    Save(this.StaffId);
                    this.Close();
                }
            }
        }

        private void DeleteMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete(this.StaffId);
                // 2008-01-21 David: Close the dialog window after delete the record.
                //SetAddNew(); 
                this.Close();
            }
        }
    }
}