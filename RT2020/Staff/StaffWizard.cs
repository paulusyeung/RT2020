#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Linq;
using System.Data.Entity;
using RT2020.Helper;
#endregion

namespace RT2020.Staff
{
    public partial class StaffWizard : Form
    {
        #region tab page params
        bool tabGeneralLoaded = false, tabPersonalLoaded = false;

        StaffWizard_General general;
        StaffWizard_Personal personal;
        #endregion

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
        #endregion

        public StaffWizard()
        {
            InitializeComponent();
        }

        private void StaffCode_Load(object sender, EventArgs e)
        {
            SetCaptions();
            LoadTabPage();

            /**
            if (_StaffId == Guid.Empty)
            {
                toolBarDelete.Enabled = false;
                txtStaffNumber.ReadOnly = false;
                txtStaffNumber.BackColor = Color.LightSkyBlue;
            }
            else
            {
                SetData();
            }
            */
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    toolBarDelete.Enabled = false;
                    txtStaffNumber.ReadOnly = false;
                    txtStaffNumber.BackColor = Color.LightSkyBlue;
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadData();
                    break;
            }
        }

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("staff.setup", "Model");

            toolBarSave.Text = WestwindHelper.GetWord("edit.save", "General");
            toolSaveNew.Text = WestwindHelper.GetWord("edit.save.new", "General");
            toolBarSaveClose.Text = WestwindHelper.GetWord("edit.save.close", "General");
            toolBarDelete.Text = WestwindHelper.GetWord("edit.delete", "General");

            lblStaffNumber.Text = WestwindHelper.GetWordWithColon("staff.number", "Model");
            tabGeneral.Text = WestwindHelper.GetWord("staff.general", "Model");
            tabPersonal.Text = WestwindHelper.GetWord("staff.personal", "Model");
        }

        #region Load Tab Ctrl
        private void LoadTabPage(int idx = 0)
        {
            switch (idx)
            {
                case 0:
                    #region Tab Page: General
                    if (!tabGeneralLoaded)
                    {
                        general = new StaffWizard_General();
                        general.Dock = DockStyle.Fill;
                        general.EditMode = _EditMode;
                        general.StaffId = _StaffId;
                        tabGeneral.Controls.Add(general);

                        general.LoadGeneralData();
                        tabGeneralLoaded = true;
                    }
                    break;
                    #endregion
                case 1:
                    #region Tab Page: Personal
                    if (!tabPersonalLoaded)
                    {
                        personal = new StaffWizard_Personal();
                        personal.Dock = DockStyle.Fill;
                        personal.EditMode = _EditMode;
                        personal.StaffId = _StaffId;
                        tabPersonal.Controls.Add(personal);

                        personal.LoadPersonalData();
                        tabPersonalLoaded = true;
                    }
                    break;
                #endregion
            }
        }
        #endregion

        #region Load Data
        private void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var staff = ctx.Staff.Find(_StaffId);
                if (staff != null)
                {
                    txtStaffNumber.Text = staff.StaffNumber;
                    /**
                    general.txtInitial.Text = staff.StaffCode;
                    general.txtFirstName.Text = staff.FirstName;
                    general.txtLastName.Text = staff.LastName;
                    general.txtName.Text = staff.FullName;
                    general.txtNameChs.Text = staff.FullName_Chs;
                    general.txtNameCht.Text = staff.FullName_Cht;
                    general.txtPassword.Text = staff.Password;
                    general.txtCreationDate.Text = RT2020.SystemInfo.Settings.DateTimeToString(staff.CreatedOn, false);
                    general.txtLastUpdate.Text = RT2020.SystemInfo.Settings.DateTimeToString(staff.ModifiedOn, false);
                    general.txtModified.Text = ModelEx.StaffEx.GetStaffNumberById(staff.ModifiedBy);
                    general.txtStateOffice.Text = "";
                    general.txtStateCounter.Text = "";
                    general.cboPosition.SelectedValue = staff.JobTitleId.HasValue ? staff.JobTitleId.Value : Guid.Empty;
                    general.cmbStaffGrade.SelectedValue = staff.GroupId.HasValue ? staff.GroupId.Value : Guid.Empty;
                    general.cboDeptCode.SelectedValue = staff.DeptId.HasValue ? staff.DeptId.Value : Guid.Empty;

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
                    */
                }
            }
            /** 搬咗去各自嘅 Tab Page
            GetSmartValue(_StaffId);
            SetAddress(_StaffId);
            GetStaffInternetTag(_StaffId);
            GetStaffHR(_StaffId);
            */
        }
        #endregion

        #region Save Data

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtStaffNumber, string.Empty);

            #region Staff Number 唔可以吉
            errorProvider.SetError(txtStaffNumber, string.Empty);
            if (txtStaffNumber.Text.Trim() == string.Empty)
            {
                errorProvider.SetError(txtStaffNumber, "Cannot be blank!");
                return false;
            }
            #endregion

            #region 新增，要 check Staff Number 係咪 in use
            if (_EditMode == EnumHelper.EditMode.Add && txtStaffNumber.Text.Trim() != string.Empty)
            {
                if (ModelEx.StaffEx.IsStaffNumberInUse(txtStaffNumber.Text.Trim()))
                {
                    errorProvider.SetError(txtStaffNumber, "Staff Number in use");
                    return false;
                }
            }
            #endregion

            return result;
        }

        private void Save(Guid staffID)
        {
            var result = false;

            if (tabGeneralLoaded)
            {
                if (_EditMode == EnumHelper.EditMode.Add)
                    general.StaffNumber = txtStaffNumber.Text.Trim();   // 傳個 StaffNumber 俾 child
                result = general.SaveGeneralData();
            }
            if (tabPersonalLoaded && result)
            {
                if (_EditMode == EnumHelper.EditMode.Add)
                {
                    _StaffId = general.StaffId;
                    personal.StaffId = _StaffId;
                }
                result = personal.SavePersonalData();
            }

            if (result)
            {
                RT2020.SystemInfo.Settings.RefreshMainList<StaffList>();
                MessageBox.Show("Save successfully!", "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            /**
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

                _StaffId = AddStaff(_StaffId);
                if (_StaffId != Guid.Empty)
                {
                    //AddStaffAddress(_StaffId);
                    AddStaffHR(_StaffId);

                    // 冇用嘅嘢，取消，要嘅話，可以用 Smart Tag 代替
                    //AddStaffInternet(_StaffId);
                    AddStaffSmart(_StaffId);
                }

                if (_StaffId != Guid.Empty)
                {
                    LoadData();

                    RT2020.SystemInfo.Settings.RefreshMainList<DefaultList>();
                    MessageBox.Show("Save successfully!", "Save Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            */
        }
        #endregion

        #region SetWizardToAddNew
        private void SetWizardToAddNew()
        {
            toolBarDelete.Enabled = false;
            txtStaffNumber.ReadOnly = false;
            txtStaffNumber.BackColor = Color.LightSkyBlue;
            txtStaffNumber.Text = "";
         
            _StaffId = Guid.Empty;
            _EditMode = EnumHelper.EditMode.Add;

            if (tabGeneralLoaded) tabGeneral.Controls.Clear();
            if (tabPersonalLoaded) tabPersonal.Controls.Clear();
            tabGeneralLoaded = tabPersonalLoaded = false;

            LoadTabPage();
        }
        #endregion

        #region Delete
        private void Delete(System.Guid staffID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var staff = ctx.Staff.Find(staffID);
                if (staff != null)
                {
                    staff.Status = Convert.ToInt32(EnumHelper.Status.Inactive.ToString("d"));

                    staff.Retired = true;
                    staff.RetiredBy = ConfigHelper.CurrentUserId;
                    staff.RetiredOn = DateTime.Now;

                    staff.ModifiedBy = ConfigHelper.CurrentUserId;
                    staff.ModifiedOn = DateTime.Now;

                    ctx.SaveChanges();

                    // 2013.11.27 paulus: 要同時刪除 UserProfile 的資料
                    RT2020.Controls.UserProfile.DelRec(staff.StaffId);

                    // log activity
                    RT2020.Controls.Log4net.LogInfo(RT2020.Controls.Log4net.LogAction.Delete, staff.ToString());
                }
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
                if (IsValid())
                {
                    Save(_StaffId);

                    _EditMode = EnumHelper.EditMode.Edit;
                }
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (IsValid())
                {
                    Save(_StaffId);
                    SetWizardToAddNew();
                }
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (IsValid())
                {
                    Save(_StaffId);
                    this.Close();
                }
            }
        }

        private void tabStaff_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedTab = tabStaff.SelectedTab.Name;
            LoadTabPage(tabStaff.SelectedIndex);
        }

        private void DeleteMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete(_StaffId);
                // 2008-01-21 David: Close the dialog window after delete the record.
                //SetAddNew(); 
                this.Close();
            }
        }
    }
}