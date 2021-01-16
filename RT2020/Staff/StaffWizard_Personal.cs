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
    public partial class StaffWizard_Personal : UserControl
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
        #endregion

        public StaffWizard_Personal()
        {
            InitializeComponent();

            SetCaptions();
            SetAttributes();
            SetSmartTags();
            SetPhoneTags();

            FillComo();
            txtSalary.Text = "0.00";
        }

        #region SetCaptions, SetAttributes & SetSmartTags
        private void SetCaptions()
        {
            lblAddress.Text = WestwindHelper.GetWordWithColon("staffAddress", "Model");
            lblPostal.Text = WestwindHelper.GetWordWithColon("staffAddress.postalCode", "Model");
            lblSalary.Text = WestwindHelper.GetWordWithColon("staff.salary", "Model");
            lblBankAC.Text = WestwindHelper.GetWordWithColon("staff.bankAccount", "Model");

            lblCountry.Text = WestwindHelper.GetWordWithColon("country", "Model");
            lblState.Text = WestwindHelper.GetWordWithColon("province", "Model");
            lblCity.Text = WestwindHelper.GetWordWithColon("city", "Model");
        }

        private void SetAttributes()
        {
            lblDateFormat.Visible = false;
            dateofSmartTag8.ShowCheckBox = true;
            dateofSmartTag8.Checked = false;

            #region 設定 clickable smart tag 1 label
            lblSmartTag7.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag7.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag7.Click += (s, e) =>                    // 彈出 wizard
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
            lblSmartTag8.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag8.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag8.Click += (s, e) =>                    // 彈出 wizard
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
            lblSmartTag9.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag9.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag9.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4StaffWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillSalutationList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable phone tag 1 label
            lblPhoneTag1.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag1.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag1.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable phone tag 2 label
            //lblSmartTag10.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag2.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag2.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable phone tag 3 label
            lblPhoneTag3.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag3.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag3.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable phone tag 4 label
            //lblPhoneTag4.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag4.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblPhoneTag4.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable country label
            lblCountry.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblCountry.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblCountry.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.CountryWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillCountry();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable province label
            lblState.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblState.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblState.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.ProvinceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillProvinceList();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable city label
            //lblCity.AutoSize = true;                            // 減少 whitespace，有字嘅位置先可以 click
            lblCity.Cursor = Cursors.Hand;                      // cursor over 顯示 hand cursor
            lblCity.Click += (s, e) =>                          // 彈出 wizard
            {
                var dialog = new Settings.CityWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    //FillCityList();
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

        private void SetPhoneTags()
        {
            var oTag = new PhoneTagHelper(this, "STF");
            oTag.SetPhoneTag();
        }
        #endregion

        #region FillComo
        private void FillComo()
        {
            FillCountry();
        }

        private void FillCountry()
        {
            var textFields = new string[] { "CountryCode", "CountryName" };
            var pattern = "{0} - {1}";
            var sql = "";
            var orderBy = new string[] { "CountryCode" };

            ModelEx.CountryEx.LoadCombo(ref cmbCountry, textFields, pattern, true, true, "", sql, orderBy);

            cmbProvince.DataSource = null;
            cmbProvince.Items.Clear();
            cmbCity.DataSource = null;
            cmbCity.Items.Clear();
        }

        private void FillProvince(System.Guid CountryId)
        {
            cmbProvince.DataSource = null;
            cmbProvince.Items.Clear();

            string sql = " CountryId = '" + CountryId.ToString() + "'";
            ModelEx.ProvinceEx.LoadCombo(ref cmbProvince, "ProvinceName", true, true, String.Empty, sql);

            cmbCity.DataSource = null;
            cmbCity.Items.Clear();
        }

        private void FillCity(System.Guid ProvinceId)
        {
            cmbCity.DataSource = null;
            cmbCity.Items.Clear();

            string sql = " ProvinceId = '" + ProvinceId.ToString() + "'";

            ModelEx.CityEx.LoadCombo(ref cmbCity, "CityName", true, true, String.Empty, sql);
        }
        #endregion

        #region public method: LoadPersonalData
        public void LoadPersonalData()
        {
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    if (_StaffId != Guid.Empty)
                    {
                        LoadAddress();
                        LoadHR();
                        LoadSmartTagValues();
                    }
                    break;
            }
        }

        private void LoadAddress()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var sa = ctx.StaffAddress.Where(x => x.StaffId == _StaffId).AsNoTracking().FirstOrDefault();
                if (sa != null)
                {
                    txtAddress.Text = sa.Address;
                    txtPostal.Text = sa.PostalCode;
                    cmbCountry.SelectedValue = sa.CountryId.HasValue ? sa.CountryId.Value : Guid.Empty;
                    cmbProvince.SelectedValue = sa.ProvinceId.HasValue ? sa.ProvinceId.Value : Guid.Empty;
                    cmbCity.SelectedValue = sa.CityId.HasValue ? sa.CityId.Value : Guid.Empty;
                    txtPhoneTag1.Text = sa.PhoneTag1Value;
                    txtPhoneTag2.Text = sa.PhoneTag2Value;
                    txtPhoneTag3.Text = sa.PhoneTag3Value;
                    txtPhoneTag4.Text = sa.PhoneTag4Value;
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
                    txtSalary.Text = hr.Salary.Value.ToString("n");
                    txtBankAC.Text = hr.BankAccountNumber;
                }
            }
        }

        private void LoadSmartTagValues()
        {
            foreach (Control Ctrl in Controls)
            {
                ModelEx.StaffSmartTagEx.LoadSmartTagValue(_StaffId, Ctrl);
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

        #region public method: SavePersonalData
        public bool SavePersonalData()
        {
            var result = false;

            try
            {
                #region SaveSmartTagValues
                foreach (Control Ctrl in Controls)
                {
                    if (Ctrl.Name.Contains("SmartTag") && !Ctrl.Name.StartsWith("lbl"))
                    {
                        ModelEx.StaffSmartTagEx.SaveSmartTagValue(_StaffId, Ctrl);
                    }
                }
                #endregion

                #region Save Address, HR
                using (var ctx = new EF6.RT2020Entities())
                {
                    #region Save Address
                    var sa = ctx.StaffAddress.Where(x => x.StaffId == _StaffId).FirstOrDefault();
                    if (sa != null)
                    {
                        #region add new dbo.StaffAddress
                        sa = new EF6.StaffAddress();
                        sa.AddressId = Guid.NewGuid();
                        sa.StaffId = _StaffId;
                        ctx.StaffAddress.Add(sa);
                        #endregion
                    }
                    sa.Address = txtAddress.Text.Trim();
                    if (cmbCountry.SelectedIndex >= 0)
                        if ((Guid)cmbCountry.SelectedValue != Guid.Empty) sa.CountryId = (Guid)cmbCountry.SelectedValue;
                    if (cmbProvince.SelectedIndex >= 0)
                        if ((Guid)cmbProvince.SelectedValue != Guid.Empty) sa.ProvinceId = (Guid)cmbProvince.SelectedValue;
                    if (cmbCity.SelectedIndex >= 0)
                        if ((Guid)cmbCity.SelectedValue != Guid.Empty) sa.CityId = (Guid)cmbCity.SelectedValue;
                    sa.PostalCode = txtPostal.Text.Trim();
                    sa.PhoneTag1Value = txtPhoneTag1.Text.Trim();
                    sa.PhoneTag2Value = txtPhoneTag2.Text.Trim();
                    sa.PhoneTag3Value = txtPhoneTag3.Text.Trim();
                    sa.PhoneTag4Value = txtPhoneTag4.Text.Trim();

                    ctx.SaveChanges();
                    #endregion

                    #region Save HR
                    decimal salary = 0;
                    decimal.TryParse(txtSalary.Text.Trim(), out salary);

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

                    hr.Salary = salary;
                    hr.BankAccountNumber = txtBankAC.Text.Trim();

                    ctx.SaveChanges();
                    #endregion
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

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCountry.SelectedValue != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(cmbCountry.SelectedValue.ToString(), out id))
                {
                    FillProvince(id);
                }
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProvince.SelectedValue != null)
            {
                Guid id = Guid.Empty;
                if (Guid.TryParse(cmbProvince.SelectedValue.ToString(), out id))
                {
                    FillCity(id);
                }
            }
        }

        private void btnFindHKID_Click(object sender, EventArgs e)
        {
            FindHKID findHKID = new FindHKID();
            findHKID.Closed += new EventHandler(findHKID_Closed);
            findHKID.ShowDialog(); 
        }

        void findHKID_Closed(object sender, EventArgs e)
        {
            FindHKID findHKID = sender as FindHKID;
            if (findHKID.IsCompleted)
            {
                txtSmartTag7.Text = findHKID.HKID;
            }
        }
    }
}