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
using System.Data.Entity;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard_General : UserControl
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

        private string _SupplierCode = string.Empty;
        public string SupplierCode
        {
            get { return _SupplierCode; }
            set { _SupplierCode = value; }
        }
        #endregion

        public SupplierWizard_General()
        {
            InitializeComponent();
        }

        private void SupplierWizard_General_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();
            SetSmartTags();

            FillComboList();
        }

        #region SetCaptions, SetAttributes & SetSmartTags
        private void SetCaptions()
        {
            lblInitial.Text = WestwindHelper.GetWordWithColon("supplier.initial", "Model");
            lblMarketSector.Text = WestwindHelper.GetWordWithColon("marketSector", "Model");

            lblName.Text = WestwindHelper.GetWordWithColon("supplier.name", "Model");
            lblNameChs.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage1.Key.ToLower()), "Menu");
            lblNameCht.Text = WestwindHelper.GetWordWithColon(String.Format("language.{0}", LanguageHelper.AlternateLanguage2.Key.ToLower()), "Menu");
            lblSmartTag1.Text = WestwindHelper.GetWordWithColon("supplier.alternate", "Model");
            lblRemarks.Text = WestwindHelper.GetWordWithColon("supplier.remarks", "Model");

            gbxStatus.Text = WestwindHelper.GetWord("glossary.status", "General");
            lblCreatedOn.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblLastUpdated.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
            lblOnly4AccountPayable.Text = WestwindHelper.GetWordWithColon("supplier.accountPayable", "Model");
        }

        private void SetAttributes()
        {
            #region 設定 clickable smart tag 1 label
            lblSmartTag1.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag1.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag1.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4SupplierWizard();
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
                var dialog = new SmartTag4SupplierWizard();
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
                var dialog = new SmartTag4SupplierWizard();
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
                var dialog = new SmartTag4SupplierWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable smart tag 5 label
            lblSmartTag5.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag5.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag5.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new SmartTag4SupplierWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    SetSmartTags();
                };
                dialog.ShowDialog();
            };
            #endregion

            #region 設定 clickable market sector label
            //lblMarketSector.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblMarketSector.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblMarketSector.Click += (s, e) =>                    // 彈出 wizard
            {
                var dialog = new MarketSectorWizard();
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillMarketSectorList();
                };
                dialog.ShowDialog();
            };
            #endregion
        }

        private void SetSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            var smartTagList = ModelEx.SmartTag4SupplierEx.GetListOrderBy(orderBy, true);

            SmartTagHelper oTag = new SmartTagHelper(this);
            oTag.SupplierSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillMarketSectorList();
        }

        private void FillMarketSectorList()
        {
            var orderBy = new string[] { "MarketSectorName" };
            ModelEx.MarketSectorEx.LoadCombo(ref cboMarketSector, "MarketSectorName", true, true, "", "", orderBy);
        }
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
                    if (_SupplierId != Guid.Empty)
                    {
                        LoadCoreData();
                        LoadSmartTagValues();
                    }
                    break;
            }
        }

        private void LoadCoreData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.Supplier.Find(_SupplierId);
                if (item != null)
                {
                    //txtSupplierCode.Text = oSupplier.SupplierCode;
                    txtInitial.Text = item.SupplierInitial;
                    txtName.Text = item.SupplierName;
                    txtNameChs.Text = item.SupplierName_Chs;
                    txtNameCht.Text = item.SupplierName_Cht;
                    txtRemarks.Text = item.Remarks;

                    cboMarketSector.SelectedValue = item.MarketSectorId.HasValue ? item.MarketSectorId : Guid.Empty;

                    txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(item.ModifiedBy);
                    txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(item.ModifiedOn, false);
                    txtCreatedon.Text = DateTimeHelper.DateTimeToString(item.CreatedOn, false);
                }
            }
        }

        private void LoadSmartTagValues()
        {
            foreach (Control Ctrl in Controls)
            {
                if (Ctrl.Name.Contains("SmartTag") && !Ctrl.Name.StartsWith("lbl"))
                {
                    ModelEx.SupplierSmartTagEx.LoadSmartTagValue(_SupplierId, Ctrl);
                }
            }
        }

        private void GetSmartValue(Guid supplierId, Control Ctrl)
        {
            string sql = "SupplierId = '" + supplierId.ToString() + "' AND TagId = '{0}'";
            string key = "SmartTag";
            Guid tagId = Guid.Empty;

            if (Ctrl != null && Ctrl.Name.Contains(key))
            {
                if (Ctrl.Tag != null)
                {
                    tagId = (Guid)Ctrl.Tag;

                    var oTag = ModelEx.SupplierSmartTagEx.Get(supplierId, tagId);
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
                    var item = ctx.Supplier.Find(_SupplierId);
                    if (item == null)
                    {
                        #region add new dbo.Supplier
                        item = new EF6.Supplier();
                        item.SupplierId = Guid.NewGuid();
                        item.SupplierCode = _SupplierCode;

                        item.Status = (int)EnumHelper.Status.Active;         //2014.01.04 paulus: 一開始就係 Active
                        item.CreatedBy = ConfigHelper.CurrentUserId;
                        item.CreatedOn = DateTime.Now;

                        ctx.Supplier.Add(item);

                        _SupplierId = item.SupplierId;
                        #endregion
                    }
                    item.SupplierInitial = txtInitial.Text;
                    item.SupplierName = txtName.Text;
                    item.SupplierName_Chs = txtNameChs.Text;
                    item.SupplierName_Cht = txtNameCht.Text;
                    if ((Guid)cboMarketSector.SelectedValue != Guid.Empty) item.MarketSectorId = (Guid)cboMarketSector.SelectedValue;
                    item.Remarks = txtRemarks.Text;

                    if (ctx.Entry(item).State != EntityState.Added) item.Status = Convert.ToInt32(EnumHelper.Status.Modified.ToString("d"));

                    item.ModifiedBy = ConfigHelper.CurrentUserId;
                    item.ModifiedOn = DateTime.Now;

                    ctx.SaveChanges();

                    #region log activity (Update)
                    RT2020.Controls.Log4net.LogInfo(ctx.Entry(item).State == EntityState.Added ?
                        RT2020.Controls.Log4net.LogAction.Create : RT2020.Controls.Log4net.LogAction.Update,
                        item.ToString());
                    #endregion

                    #endregion
                }

                #region SaveSmartTagValues
                foreach (Control Ctrl in Controls)
                {
                    if (Ctrl.Name.Contains("SmartTag") && !Ctrl.Name.StartsWith("lbl"))
                    {
                        ModelEx.SupplierSmartTagEx.SaveSmartTagValue(_SupplierId, Ctrl);
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
    }
}