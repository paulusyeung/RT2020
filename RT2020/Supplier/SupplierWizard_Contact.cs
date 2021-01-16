#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard_Contact : UserControl
    {
        #region Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _SupplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get { return _SupplierId; }
            set { _SupplierId = value; }
        }
        #endregion

        public SupplierWizard_Contact()
        {
            InitializeComponent();
        }

        private void SupplierWizard_Contact_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetPhoneTags();

            FillComboList();
        }

        #region SetCaptions, SetAttributes & SetSmartTags
        private void SetCaptions()
        {
            lblSalutation.Text = WestwindHelper.GetWordWithColon("salutation", "Model");
            lblJobTitle.Text = WestwindHelper.GetWordWithColon("jobTitle", "Model");

            lblPrimaryContact.Text = WestwindHelper.GetWordWithColon("supplierContact.primary", "Model");
            lblFirstName.Text = WestwindHelper.GetWordWithColon("supplierContact.firstName", "Model");
            lblLastName.Text = WestwindHelper.GetWordWithColon("supplierContact.lastName", "Model");
            lblFullName.Text = WestwindHelper.GetWordWithColon("supplierContact.fullName", "Model");
            lblDuty.Text = WestwindHelper.GetWordWithColon("supplierContact.duty", "Model");
            lblNotes.Text = WestwindHelper.GetWordWithColon("supplierContact.notes", "Model");

            
        }

        private void SetAttributes()
        {
            #region 設定 clickable saluation label
            //lblSalutation.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSalutation.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSalutation.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.SalutationWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillSalutationList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable job title label
            lblJobTitle.AutoSize = true;                        // 減少 whitespace，有字嘅位置先可以 click
            lblJobTitle.Cursor = Cursors.Hand;                  // cursor over 顯示 hand cursor
            lblJobTitle.Click += (s, e) =>                      // 彈出 wizard
            {
                var dialog = new Settings.JobTitleWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillJobTitleList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 9 label
            lblPhoneTag5.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag5.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag5.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 6 label
            lblPhoneTag7.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag7.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag7.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 3 label
            //lblPhoneTag3.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag6.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag6.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 4 label
            //lblPhoneTag4.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag8.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag8.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void SetPhoneTags()
        {
            var oTag = new PhoneTagHelper(this, "SUP");
            oTag.SetPhoneTag();
        }
        #endregion

        #region Fill Combo list
        private void FillComboList()
        {
            FillSalutationList();
            FillJobTitleList();
        }

        private void FillSalutationList()
        {
            ModelEx.SalutationEx.LoadCombo(ref cboSalutation, "SalutationName", true, true, String.Empty, String.Empty);
        }

        private void FillJobTitleList()
        {
            ModelEx.JobTitleEx.LoadCombo(ref cboJobTitle, "JobTitleName", true, true, String.Empty, String.Empty);
        }
        #endregion

        #region LoadContactData
        public void LoadContactData()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    if (_SupplierId != Guid.Empty)
                    {
                        LoadContact();
                    }
                    break;
            }
        }

        private void LoadContact()
        { 
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierContact.Where(x => x.SupplierId == _SupplierId).AsNoTracking().FirstOrDefault();
                if (item != null)
                {
                    cboJobTitle.SelectedValue = item.JobTitleId.HasValue ? item.JobTitleId : Guid.Empty;
                    cboSalutation.SelectedValue = item.SalutationId.HasValue ? item.SalutationId : Guid.Empty;

                    chkPrimary.Checked = item.PrimaryRec;
                    txtFirstName.Text = item.FirstName;
                    txtLastName.Text = item.LastName;
                    txtFullName.Text = item.FullName;
                    txtDuty.Text = item.Duty;
                    txtPhoneTag5.Text = item.PhoneTag1Value;
                    txtPhoneTag6.Text = item.PhoneTag2Value;
                    txtPhoneTag7.Text = item.PhoneTag3Value;
                    txtPhoneTag8.Text = item.PhoneTag4Value;
                    txtNotes.Text = item.Notes;
                }
            }
        }

        public bool SaveContctData()
        {
            var result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.SupplierContact.Where(x => x.SupplierId == _SupplierId).FirstOrDefault();
                if (item == null)
                {
                    item = new EF6.SupplierContact();
                    item.ContactId = Guid.NewGuid();
                    item.SupplierId = _SupplierId;

                    ctx.SupplierContact.Add(item);
                }
                if ((Guid)cboJobTitle.SelectedValue != Guid.Empty) item.JobTitleId = (Guid)cboJobTitle.SelectedValue;
                if ((Guid)cboSalutation.SelectedValue != Guid.Empty) item.SalutationId = (Guid)cboSalutation.SelectedValue;

                item.PrimaryRec = chkPrimary.Checked;
                item.FirstName = txtFirstName.Text.Trim();
                item.LastName = txtLastName.Text.Trim();
                item.FullName = txtFullName.Text.Trim();
                item.Duty = txtDuty.Text.Trim();
                item.PhoneTag1Value = txtPhoneTag5.Text.Trim();
                item.PhoneTag2Value = txtPhoneTag6.Text.Trim();
                item.PhoneTag3Value = txtPhoneTag7.Text.Trim();
                item.PhoneTag4Value = txtPhoneTag8.Text.Trim();
                item.Notes = txtNotes.Text.Trim();

                ctx.SaveChanges();
                result = true;
            }

            return result;
        }
        #endregion
    }
}