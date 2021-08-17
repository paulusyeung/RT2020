#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

using System.Data.SqlClient;
using RT2020.Controls;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using RT2020.Helper;
#endregion

namespace RT2020.Workplace
{
    public partial class WorkplaceWizard : Form
    {
        private bool _FormLoaded = false;

        #region Properties
        private EnumHelper.EditMode _EditMode = EnumHelper.EditMode.None;
        public EnumHelper.EditMode EditMode
        {
            get { return _EditMode; }
            set { _EditMode = value; }
        }

        private Guid _WorkplaceId = System.Guid.Empty;
        public Guid WorkplaceId
        {
            get { return _WorkplaceId; }
            set { _WorkplaceId = value; }
        }
        #endregion

        public WorkplaceWizard()
        {
            InitializeComponent();
        }

        private void WorkplaceCode_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetSmartTags();
            SetPhoneTags();

            FillComboList();

            //databind(_WorkplaceId);
            switch (_EditMode)
            {
                case EnumHelper.EditMode.Add:
                    break;
                case EnumHelper.EditMode.Edit:
                case EnumHelper.EditMode.Delete:
                    LoadData();
                    break;
            }
            _FormLoaded = true;
        }

        #region SetCaptions, SetAttributes & SetPhoneTag
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("workplace.setup", "Model");

            cmdDelete.Text = WestwindHelper.GetWord("edit.delete", "General");
            cmdSave.Text = WestwindHelper.GetWord("edit.save", "General");
            cmdSaveNew.Text = WestwindHelper.GetWord("edit.save.new", "General");
            cmdSaveClose.Text = WestwindHelper.GetWord("edit.save.close", "General");

            lblLoc.Text = WestwindHelper.GetWordWithColon("workplace.code", "Model");
            lblPriority.Text = WestwindHelper.GetWordWithColon("workplace.priority", "Model");
            lblInitial.Text = WestwindHelper.GetWordWithColon("workplace.initial", "Model");
            lblPassword.Text = WestwindHelper.GetWordWithColon("workplace.password", "Model");
            lblName.Text= WestwindHelper.GetWordWithColon("workplace.name", "Model");
            lblNameChs.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameCht.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblAddress.Text = WestwindHelper.GetWordWithColon("workplace.address", "Model");
            lblDistrict.Text = WestwindHelper.GetWordWithColon("workplace.district", "Model");
            lblPostal.Text = WestwindHelper.GetWordWithColon("workplace.postalCode", "Model");

            lblCountry.Text = WestwindHelper.GetWordWithColon("country", "Model");
            lblProvince.Text = WestwindHelper.GetWordWithColon("province", "Model");
            lblCity.Text = WestwindHelper.GetWordWithColon("city", "Model");

            lblNature.Text = WestwindHelper.GetWordWithColon("workplaceNature", "Model");
            lblZone.Text = WestwindHelper.GetWordWithColon("workplaceZone", "Model");
            lblLOO.Text = WestwindHelper.GetWordWithColon("lineOfOperation", "Model");

            gbxStatus.Text = WestwindHelper.GetWord("glossary.status", "General");
            lblCreationDate.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblLastUpdate.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblStatus.Text = WestwindHelper.GetWordWithColon("glossary.sync", "General");
        }

        private void SetAttributes()
        {
            #region 設定 clickable Smart Tag 1 label
            lblSmartTag1.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag1.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag1.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Smart Tag 2 label
            //lblSmartTag2.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag2.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag2.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Smart Tag 3 label
            lblSmartTag3.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag3.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag3.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Smart Tag 4 label
            lblSmartTag4.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag4.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblSmartTag4.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new SmartTag4WorkplaceWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 1 label
            lblPhoneTag1.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag1.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag1.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 2 label
            //lblPhoneTag2.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag2.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag2.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 3 label
            lblPhoneTag3.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag3.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag3.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.PhoneTagWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetPhoneTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Phone Tag 4 label
            //lblPhoneTag4.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblPhoneTag4.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblPhoneTag4.Click += (s, e) =>                       // 彈出 wizard
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
            //lblCountry.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
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
            //lblDistrict.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblDistrict.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblDistrict.Click += (s, e) =>                       // 彈出 wizard
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

            #region 設定 clickable LOO label
            //lblLOO.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblLOO.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblLOO.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.LineOfOperationWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillLineOfOperation();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Nature label
            //lblNature.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblNature.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblNature.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new WorkplaceNatureWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillNature();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable Zone label
            //lblZone.AutoSize = true;                         // 減少 whitespace，有字嘅位置先可以 click
            lblZone.Cursor = Cursors.Hand;                   // cursor over 顯示 hand cursor
            lblZone.Click += (s, e) =>                       // 彈出 wizard
            {
                var dialog = new Settings.ZoneWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillZone();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void SetSmartTags()
        {
            var smartTagList = ModelEx.SmartTag4WorkplaceEx.GetListOrderBy(new string[] { "Priority" });

            SmartTagHelper oTag = new SmartTagHelper(this.groupBoxMain);
            oTag.WorkplaceSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }

        private void SetPhoneTags()
        {
            var oTag = new PhoneTagHelper(groupBoxMain, "WRK");
            oTag.SetPhoneTag();
        }
        #endregion

        #region FillComo
        private void FillComboList()
        {
            FillCountry();
            FillProvince(Guid.Empty);
            FillCity(Guid.Empty);

            FillNature();
            FillZone();
            FillLineOfOperation();

            //2014.01.05 paulus: 唔明掂解要選 Customer？暫時取消先
            //SetCustomerInfo();
        }

        #region FillCountry
        private void FillCountry()
        {
            var fields = new string[] { "CountryCode", "CountryName" };
            var pattern = "{0} - {1}";
            var orderby = new string[] { "CountryCode" };
            ModelEx.CountryEx.LoadCombo(ref cboCountry, fields, pattern, true, true, "", "", orderby);
        }
        #endregion

        #region FillProvince
        private void FillProvince(Guid countryId)
        {
            var sql = string.Format("CountryId = '{0}'", countryId.ToString());

            ModelEx.ProvinceEx.LoadCombo(ref cboProvince, "ProvinceName", true, true, "", sql);
        }
        #endregion

        #region FillCity
        private void FillCity(Guid provinceId)
        {
            var sql = String.Format("ProvinceId = '{0}'", provinceId.ToString());

            ModelEx.CityEx.LoadCombo(ref cboCity, "CityName", true, true, "", sql);
        }
        #endregion

        private void FillNature()
        {
            ModelEx.WorkplaceNatureEx.LoadCombo(ref cboNature, "NatureName", true, true, "", "");
        }

        private void FillZone()
        {
            ModelEx.WorkplaceZoneEx.LoadCombo(ref cboZone, "ZoneName", true);
        }

        private void FillLineOfOperation()
        {
            ModelEx.LineOfOperationEx.LoadCombo(ref cboLOO, "LineOfOperationName", true, true, String.Empty, String.Empty);
        }

        #endregion

        #region ClearForm
        private void ClearForm()
        {
            txtLoc.BackColor = Color.LightSkyBlue;
            txtLoc.ReadOnly = false;
            cmdDelete.Enabled = false;

            ClearAllTextBox();
            FillComboList();

            _WorkplaceId = Guid.Empty;
            _EditMode = EnumHelper.EditMode.Add;
        }

        private void ClearAllTextBox()
        {
            txtLoc.Text = "";
            txtInitial.Text = "";
            txtPassword.Text = "";
            txtName.Text = "";
            txtNameChs.Text = "";
            txtNameCht.Text = "";
            txtAddress.Text = "";
            txtDistrict.Text = "";
            txtPriority.Text = "";
            txtPhoneTag4.Text = "";
            txtPostal.Text = "";
            txtPhoneTag1.Text = "";
            txtSmartTag1.Text = "";
            txtSmartTag2.Text = "";
            txtPhoneTag3.Text = "";
            txtPhoneTag2.Text = "";
            txtLastUpdate.Text = "";
            txtCreationDate.Text = "";
            txtModified.Text = "";
            txtStatus_Office.Text = "";
            txtStatus_Counter.Text = "";
        }
        #endregion

        #region LoadData
        private void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var workplace = ctx.Workplace.Find(_WorkplaceId);
                if (workplace != null)
                {
                    txtLoc.Text = workplace.WorkplaceCode;
                    txtInitial.Text = workplace.WorkplaceInitial; ;
                    txtPassword.Text = workplace.Password;
                    txtName.Text = workplace.WorkplaceName;
                    txtNameChs.Text = workplace.WorkplaceName_Chs;
                    txtNameCht.Text = workplace.WorkplaceName_Cht;
                    //txtSmartTag3.Text = workplace.AlternateWorkplaceCode;
                    txtPriority.Text = workplace.Priority.ToString();
                    txtPhoneTag2.Text = workplace.Email;
                    txtLastUpdate.Text = DateTimeHelper.DateTimeToString(workplace.ModifiedOn, false);
                    txtCreationDate.Text = DateTimeHelper.DateTimeToString(workplace.CreatedOn, false);
                    txtModified.Text = ModelEx.StaffEx.GetStaffNumberById(workplace.ModifiedBy);
                    txtStatus_Office.Text = "";
                    txtStatus_Counter.Text = "";
                    cboLOO.SelectedValue = workplace.LineOfOperationId.HasValue ? workplace.LineOfOperationId : Guid.Empty;
                    cboZone.SelectedValue = workplace.ZoneId;
                    cboNature.SelectedValue = workplace.NatureId != null ? workplace.NatureId : Guid.Empty;

                    #region DownloadToPOS
                    if (workplace.DownloadToPOS)
                    {
                        if (workplace.ModifiedOn.Date.Equals(workplace.CreatedOn.Date))
                        {
                            txtStatus_Office.Text = "A";
                        }
                        else
                        {
                            txtStatus_Office.Text = "M";
                        }
                    }
                    #endregion

                    #region DownloadToCounter
                    if (workplace.DownloadToCounter)
                    {
                        if (workplace.ModifiedOn.Date.Equals(workplace.CreatedOn.Date))
                        {
                            txtStatus_Counter.Text = "A";
                        }
                        else
                        {
                            txtStatus_Counter.Text = "M";
                        }
                    }
                    #endregion

                    #region LoadWorkplaceAddress();
                    var address = ctx.WorkplaceAddress.Where(x => x.WorkplaceId == _WorkplaceId).AsNoTracking().FirstOrDefault();
                    if (address != null)
                    {
                        txtAddress.Text = address.Address;
                        txtDistrict.Text = address.District;
                        txtPostal.Text = address.PostalCode;
                        cboCountry.SelectedValue = address.CountryId.HasValue ? address.CountryId : Guid.Empty;
                        cboProvince.SelectedValue = address.ProvinceId.HasValue ? address.ProvinceId : Guid.Empty;
                        cboCity.SelectedValue = address.CityId.HasValue ? address.CityId : Guid.Empty;
                        txtPhoneTag1.Text = address.PhoneTag1Value;
                        txtPhoneTag3.Text = address.Phonetage3Value;
                        txtPhoneTag4.Text = address.PhoneTag4Value;
                    }
                    #endregion

                    #region LoadSmartTag();
                    var oTag1 = ctx.WorkplaceSmartTag.Where(x => x.WorkplaceId == _WorkplaceId && x.TagId == (Guid)txtSmartTag1.Tag).AsNoTracking().FirstOrDefault();
                    if (oTag1 != null)
                    {
                        txtSmartTag1.Text = oTag1.SmartTagValue;
                    }

                    var oTag2 = ctx.WorkplaceSmartTag.Where(x => x.WorkplaceId == _WorkplaceId && x.TagId == (Guid)txtSmartTag2.Tag).AsNoTracking().FirstOrDefault();
                    if (oTag2 != null)
                    {
                        txtSmartTag2.Text = oTag2.SmartTagValue;
                    }
                    #endregion
                }
            }
        }
        #endregion

        #region SaveData
        private bool DoSaveData()
        {
            bool result = false;

            if (IsValid())
            {
                result = SaveData();

                MessageBox.Show(result ? "Save successfully!" : "Save failed!", "Save Result");
            }

            return result;
        }

        private bool IsValid()
        {
            bool result = true;
            errorProvider.SetError(txtLoc, "");

            #region IsWorkplace Empty
            if (txtLoc.Text.Trim() == "")
            {
                errorProvider.SetError(txtLoc, "Cannot be blank!");
                result = false;
            }
            #endregion

            #region IsWorkplaceCodeInUse
            if (_WorkplaceId == Guid.Empty)
            {
                if (ModelEx.WorkplaceEx.IsWorkplaceCodeInUse(txtLoc.Text.Trim()))
                {
                    errorProvider.SetError(txtLoc, string.Format(Resources.Common.DuplicatedCode, "Workplace Code"));
                    result = false;
                }
            }
            #endregion

            return result;
        }

        private bool SaveData()
        {
            bool result = false;

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        #region save Wokrplace core data
                        var wp = ctx.Workplace.Find(_WorkplaceId);
                        if (wp == null)
                        {
                            #region add new dbo.Workplace
                            wp = new EF6.Workplace();
                            wp.WorkplaceId = Guid.NewGuid();
                            wp.WorkplaceCode = txtLoc.Text.Trim();
                            wp.CreatedOn = DateTime.Now;
                            wp.CreatedBy = ConfigHelper.CurrentUserId;
                            wp.Status = (int)EnumHelper.Status.Active;

                            ctx.Workplace.Add(wp);
                            _WorkplaceId = wp.WorkplaceId;
                            #endregion
                        }
                        wp.WorkplaceInitial = txtInitial.Text.Trim();
                        wp.WorkplaceName = txtName.Text.Trim();
                        wp.WorkplaceName_Chs = txtNameChs.Text.Trim();
                        wp.WorkplaceName_Cht = txtNameCht.Text.Trim();
                        //wp.AlternateWorkplaceCode = txtSmartTag3.Text;
                        wp.Priority = Convert.ToInt32((txtPriority.Text.Length == 0) ? "0" : txtPriority.Text.Trim());
                        wp.Email = txtPhoneTag2.Text.Trim();
                        wp.Password = txtPassword.Text.Trim();

                        if ((Guid)cboNature.SelectedValue != Guid.Empty) wp.NatureId = (Guid)cboNature.SelectedValue;
                        wp.ZoneId = (Guid)cboZone.SelectedValue;
                        if ((Guid)cboLOO.SelectedValue != Guid.Empty) wp.LineOfOperationId = (Guid)cboLOO.SelectedValue;
                        wp.DownloadToCounter = true;
                        wp.DownloadToPOS = true;
                        wp.DownloadToShop = true;

                        wp.Status = ctx.Entry(wp).State == EntityState.Added ?
                            (int)EnumHelper.Status.Active : (int)EnumHelper.Status.Modified;
                        wp.ModifiedOn = DateTime.Now;
                        wp.ModifiedBy = ConfigHelper.CurrentUserId;

                        ctx.SaveChanges();
                        #endregion

                        #region save WorkplaceAddress
                        var address = ctx.WorkplaceAddress.Where(x => x.WorkplaceId == _WorkplaceId).FirstOrDefault();
                        if (address == null)
                        {
                            #region add new dboWorkplaceAddress
                            address = new EF6.WorkplaceAddress();
                            address.AddressId = Guid.NewGuid();
                            address.WorkplaceId = _WorkplaceId;

                            ctx.WorkplaceAddress.Add(address);
                            #endregion
                        }
                        address.Address = txtAddress.Text.Trim();
                        address.PostalCode = txtPostal.Text.Trim();
                        if ((Guid)cboCountry.SelectedValue != Guid.Empty) address.CountryId = (Guid)cboCountry.SelectedValue;
                        if ((Guid)cboProvince.SelectedValue != Guid.Empty) address.ProvinceId = (Guid)cboProvince.SelectedValue;
                        if ((Guid)cboCity.SelectedValue != Guid.Empty) address.CityId = (Guid)cboCity.SelectedValue;
                        address.District = txtDistrict.Text.Trim();

                        // Phone Tag 1
                        address.PhoneTag1 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(1);
                        address.PhoneTag1Value = txtPhoneTag1.Text;

                        // Phone Tag 3
                        address.PhoneTag3 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(3);
                        address.Phonetage3Value = txtPhoneTag3.Text;

                        // Phone Tag 4
                        address.PhoneTag4 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(4);
                        address.PhoneTag4Value = txtPhoneTag4.Text;

                        ctx.SaveChanges();
                        #endregion

                        #region save Smart Tags
                        #region Smart Tag 1
                        var oTag1 = ctx.WorkplaceSmartTag.Where(x => x.WorkplaceId == _WorkplaceId && x.TagId == (Guid)txtSmartTag1.Tag).FirstOrDefault();
                        if (oTag1 == null)
                        {
                            oTag1 = new EF6.WorkplaceSmartTag();
                            oTag1.SmartTagId = Guid.NewGuid();
                            oTag1.WorkplaceId = _WorkplaceId;
                            oTag1.TagId = (txtSmartTag1.Tag == null) ? Guid.Empty : new Guid(txtSmartTag1.Tag.ToString());
                            ctx.WorkplaceSmartTag.Add(oTag1);
                        }
                        oTag1.SmartTagValue = txtSmartTag1.Text;
                        ctx.SaveChanges();
                        #endregion

                        #region Smart Tag 2
                        var oTag2 = ctx.WorkplaceSmartTag.Where(x => x.WorkplaceId == _WorkplaceId && x.TagId == (Guid)txtSmartTag2.Tag).FirstOrDefault();
                        if (oTag2 == null)
                        {
                            oTag2 = new EF6.WorkplaceSmartTag();
                            oTag2.SmartTagId = Guid.NewGuid();
                            oTag2.WorkplaceId = _WorkplaceId;
                            oTag2.TagId = (txtSmartTag2.Tag == null) ? Guid.Empty : new Guid(txtSmartTag2.Tag.ToString());
                            ctx.WorkplaceSmartTag.Add(oTag2);
                        }
                        oTag2.SmartTagValue = txtSmartTag2.Text;
                        ctx.SaveChanges();
                        #endregion
                        #endregion

                        scope.Commit();
                        result = true;
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
            /** abbendon
            int priority = 0;
            if (txtLoc.Text.Trim().Length <= 0)
            {
                errorProvider.SetError(txtLoc, "Cannot be blank!");
                return false;
            }
            else if (!int.TryParse(txtPriority.Text.Trim(), out priority))
            {
                errorProvider.SetError(txtPriority, Resources.Common.DigitalNeeded);
                return false;
            }
            else
            {
                errorProvider.SetError(txtLoc, string.Empty);
                errorProvider.SetError(txtPriority, string.Empty);

                if (txtLoc.ReadOnly)
                {
                    var workplaceId = AddWorkplace(_WorkplaceId);
                    _WorkplaceId = workplaceId;

                    if (workplaceId != Guid.Empty)
                    {
                        AddWorkplaceAddress(workplaceId);
                        AddWorkplaceSmart(workplaceId);
                    }
                }
                else
                {
                    var workplaceId = AddWorkplace(Guid.Empty);
                    if (workplaceId != Guid.Empty)
                    {
                        AddWorkplaceAddress(workplaceId);
                        AddWorkplaceSmart(workplaceId);
                    }
                }
                if (_WorkplaceId != Guid.Empty)
                {
                    txtLoc.ReadOnly = true;
                    txtLoc.BackColor = Color.LightYellow;

                    ClearForm();
                    MessageBox.Show("Save successfully!", "Save Result");

                    return true;
                }
                else
                {
                    return false;
                }
            }
            */
        }
        /** abbendon
        #region AddWorkplace
        private Guid AddWorkplace(Guid workplaceId)
        {
            bool isNew = false;
            Guid result = Guid.Empty;

            if (ModelEx.WorkplaceEx.IsWorkplaceCodeInUse(txtLoc.Text.Trim()))
            {
                errorProvider.SetError(txtLoc, string.Format(Resources.Common.DuplicatedCode, "Workplace Code"));
                txtLoc.ReadOnly = false;
            }
            else
            {
                errorProvider.SetError(txtLoc, string.Empty);

                using (var ctx = new EF6.RT2020Entities())
                {
                    var workplace = ctx.Workplace.Find(workplaceId);
                    if (workplace == null)
                    {
                        workplace = new EF6.Workplace();
                        workplace.WorkplaceId = Guid.NewGuid();
                        workplace.WorkplaceCode = txtLoc.Text.Trim();
                        workplace.CreatedOn = DateTime.Now;
                        workplace.CreatedBy = ConfigHelper.CurrentUserId;
                        workplace.Status = Convert.ToInt32(EnumHelper.Status.Active.ToString("d"));

                        ctx.Workplace.Add(workplace);
                        isNew = true;
                    }
                    workplace.WorkplaceInitial = txtInitial.Text.Trim();
                    workplace.WorkplaceName = txtName.Text.Trim();
                    workplace.WorkplaceName_Chs = txtNameChs.Text.Trim();
                    workplace.WorkplaceName_Cht = txtNameCht.Text.Trim();
                    workplace.AlternateWorkplaceCode = txtAltWorkplaceNum.Text;
                    workplace.Priority = Convert.ToInt32((txtPriority.Text.Length == 0) ? "0" : txtPriority.Text.Trim());
                    workplace.Email = txtPhoneTag2.Text.Trim();
                    workplace.Password = txtPassword.Text.Trim();
                    workplace.ModifiedOn = DateTime.Now;
                    workplace.ModifiedBy = ConfigHelper.CurrentUserId;
                    workplace.NatureId = new Guid(((System.Web.UI.WebControls.ListItem)cboNature.SelectedItem).Value);
                    workplace.ZoneId = (System.Guid)cboZone.SelectedValue;
                    workplace.LineOfOperationId = (Guid)cboLOO.SelectedValue;   // Common.Utility.IsGUID(cmbLOO.SelectedValue.ToString()) ? new System.Guid(cmbLOO.SelectedValue.ToString()) : System.Guid.Empty;
                    workplace.DownloadToCounter = true;
                    workplace.DownloadToPOS = true;
                    workplace.DownloadToShop = true;

                    if (!isNew)
                    {
                        workplace.Status = Convert.ToInt32(EnumHelper.Status.Modified.ToString("d"));
                    }

                    ctx.SaveChanges();
                    _WorkplaceId = result = workplace.WorkplaceId;
                }
            }
            return result;
        }
        #endregion

        #region AddWorkplaceAddress
        private void AddWorkplaceAddress(Guid workplaceID)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var address = ctx.WorkplaceAddress.Where(x => x.WorkplaceId == workplaceID).FirstOrDefault();
                if (address == null)
                {
                    address = new EF6.WorkplaceAddress();
                    address.AddressId = Guid.NewGuid();
                    ctx.WorkplaceAddress.Add(address);
                }
                address.WorkplaceId = workplaceID;
                address.Address = txtAddress.Text.Trim();
                address.PostalCode = txtPostal.Text.Trim();
                if ((Guid)cboCountry.SelectedValue != Guid.Empty) address.CountryId = (Guid)cboCountry.SelectedValue;
                if ((Guid)cboProvince.SelectedValue != Guid.Empty) address.ProvinceId = (Guid)cboProvince.SelectedValue;
                if ((Guid)cboCity.SelectedValue != Guid.Empty) address.CityId = (Guid)cboCity.SelectedValue;
                address.District = txtDistrict.Text.Trim();

                // Phone Tag 1
                address.PhoneTag1 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(1);
                address.PhoneTag1Value = txtPhoneTag1.Text;

                // Phone Tag 3
                address.PhoneTag3 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(3);
                address.Phonetage3Value = txtPhoneTag3.Text;

                // Phone Tag 4
                address.PhoneTag4 = ModelEx.PhoneTagEx.GetPhoneTagIdByPriority(4);
                address.PhoneTag4Value = txtPhoneTag4.Text;

                ctx.SaveChanges();
            }
        }
        #endregion

        #region AddWorkplaceSmart
        private void AddWorkplaceSmart(Guid workplaceId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                #region Smart Tag 1
                var oTag1 = ctx.WorkplaceSmartTag.Where(x => x.WorkplaceId == workplaceId && x.TagId == (Guid)txtSmartTag1.Tag).FirstOrDefault();
                if (oTag1 == null)
                {
                    oTag1 = new EF6.WorkplaceSmartTag();
                    oTag1.SmartTagId = Guid.NewGuid();
                    oTag1.WorkplaceId = workplaceId;
                    oTag1.TagId = (txtSmartTag1.Tag == null) ? Guid.Empty : new Guid(txtSmartTag1.Tag.ToString());
                    ctx.WorkplaceSmartTag.Add(oTag1);
                }
                oTag1.SmartTagValue = txtSmartTag1.Text;
                ctx.SaveChanges();
                #endregion

                #region Smart Tag 2
                var oTag2 = ctx.WorkplaceSmartTag.Where(x => x.WorkplaceId == workplaceId && x.TagId == (Guid)txtSmartTag2.Tag).FirstOrDefault();
                if (oTag2 == null)
                {
                    oTag2 = new EF6.WorkplaceSmartTag();
                    oTag2.SmartTagId = Guid.NewGuid();
                    oTag2.WorkplaceId = workplaceId;
                    oTag2.TagId = (txtSmartTag2.Tag == null) ? System.Guid.Empty : new System.Guid(txtSmartTag2.Tag.ToString());
                    ctx.WorkplaceSmartTag.Add(oTag2);
                }
                oTag2.SmartTagValue = txtSmartTag2.Text;
                ctx.SaveChanges();
                #endregion
            }
        }
        #endregion
        */
        #endregion

        #region Delete
        private void Delete()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var workplace = ctx.Workplace.Find(_WorkplaceId);
                if (workplace != null)
                {
                    switch ((int)workplace.Status)
                    {
                        case (int)EnumHelper.Status.Active:
                            workplace.Status = Convert.ToInt32(EnumHelper.Status.Deleted.ToString("d"));
                            workplace.Retired = true;
                            workplace.RetiredOn = DateTime.Now;
                            workplace.RetiredBy = ConfigHelper.CurrentUserId;
                            ctx.SaveChanges();
                            break;
                        case (int)EnumHelper.Status.Draft:
                            ModelEx.WorkplaceAddressEx.DeleteTagByWorkplaceId(_WorkplaceId);
                            ModelEx.WorkplaceSmartTagEx.DeleteTagByWorkplaceId(_WorkplaceId);

                            ctx.Workplace.Remove(workplace);
                            break;
                    }
                }
            }

            MessageBox.Show("Delete succeeded.");
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
                /**
                if (SaveData() && _WorkplaceId != Guid.Empty)
                {
                    SystemInfoHelper.Settings.RefreshMainList<DefaultList>();
                }
                */
                DoSaveData();
            }
        }

        private void SaveNewMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                /**
                if (SaveData() && _WorkplaceId != System.Guid.Empty)
                {
                    SystemInfoHelper.Settings.RefreshMainList<DefaultList>();
                    ClearForm();
                }
                */
                if (DoSaveData()) ClearForm();
            }
        }

        private void SaveCloseMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (DoSaveData()) this.Close();
            }
        }

        private void DeleteMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                Delete();
                // 2008-01-21 David: close the dialog window after delete the record
                //AddNew(); 
                this.Close();
            }
        }

        private void cmbCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCountry.SelectedValue != null && _FormLoaded)
            {
                FillProvince((Guid)cboCountry.SelectedValue);
            }
        }

        private void cmbProvince_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProvince.SelectedValue != null && _FormLoaded)
            {
                FillCity((Guid)cboProvince.SelectedValue);
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            if (_WorkplaceId != Guid.Empty)
            {
                if (txtLoc.ReadOnly)
                {
                    ChangePassword changePassword = new ChangePassword();
                    changePassword.WorkplaceId = _WorkplaceId;
                    changePassword.Closed += new EventHandler(changePassword_Closed);
                    changePassword.ShowDialog();
                }
                else
                {
                    ChangePassword changePassword = new ChangePassword();
                    changePassword.Closed += new EventHandler(changePassword_Closed);
                    changePassword.ShowDialog();
                }
            }
            else
            {
                ChangePassword changePassword = new ChangePassword();
                changePassword.Closed += new EventHandler(changePassword_Closed);
                changePassword.ShowDialog();
            }
        }

        void changePassword_Closed(object sender, EventArgs e)
        {
            ChangePassword changePassword = sender as ChangePassword;
            if (changePassword.IsCompleted)
            {
                txtPassword.Text = changePassword.Password;
            }
        }
    }
}