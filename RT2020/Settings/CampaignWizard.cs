#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using Gizmox.WebGUI.Common.Resources;

using System.Data.SqlClient;
using RT2020.Helper;
using System.Linq;

#endregion

namespace RT2020.Settings
{
    public partial class CampaignWizard : Form
    {
        #region Properties
        private Guid _CampaignId = Guid.Empty;
        public Guid CampaignId
        {
            get { return _CampaignId; }
            set { _CampaignId = value; }
        }

        private EnumHelper.CampaignType _CampaignType = EnumHelper.CampaignType.None;
        public EnumHelper.CampaignType CampaignType
        {
            get { return _CampaignType; }
            set { _CampaignType = value; }
        }
        #endregion

        public CampaignWizard()
        {
            InitializeComponent();
        }

        private void CampaignWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            SwitchComapaignType();
            FillComboList();
            SetToolBar();
            SetEditLayout();
            BindList();
        }

        #region SetCaptions SetAttributes

        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("promotion.setup", "Model");

            colLN.Text = WestwindHelper.GetWord("listview.line", "Tools");
            colWorkplace.Text = WestwindHelper.GetWord("workplace", "Model");
            colTenderType.Text = WestwindHelper.GetWord("posTenderType", "Model");
            colEventCode.Text = WestwindHelper.GetWord("promotion.eventCode", "Model");
            colStartDate.Text = WestwindHelper.GetWord("promotion.startOn", "Model");
            colEndDate.Text = WestwindHelper.GetWord("promotion.endOn", "Model");
            colFactor.Text = string.Format("{0} (%)", WestwindHelper.GetWord("promotion.rebate", "Model"));
            colCreatedOn.Text = WestwindHelper.GetWord("glossary.createdOn", "General");
            colModifiedOn.Text = WestwindHelper.GetWord("glossary.modifiedOn", "General");

            gbxCampaign.Text = WestwindHelper.GetWord("promotion.campaign", "Model");
            radTender.Text = WestwindHelper.GetWord("posTenderType", "Model");
            radEvent.Text = WestwindHelper.GetWord("promotion.event", "Model");
            lblWorkplace.Text = WestwindHelper.GetWordWithColon("workplace", "Model");
            lblTender.Text = WestwindHelper.GetWordWithColon("posTenderType", "Model");
            lblEventCode.Text = WestwindHelper.GetWordWithColon("promotion.eventCode", "Model");
            lblStartDate.Text = WestwindHelper.GetWordWithColon("promotion.startOn", "Model");
            lblEndDate.Text = WestwindHelper.GetWordWithColon("promotion.endOn", "Model");
            lblFactorRate.Text = string.Format("{0} (%)", WestwindHelper.GetWordWithColon("promotion.rebate", "Model"));
            gbxStatus.Text = WestwindHelper.GetWordWithColon("glossary.status", "General");
            lblCreatedOn.Text = WestwindHelper.GetWordWithColon("glossary.createdOn", "General");
            lblLastUpdated.Text = WestwindHelper.GetWordWithColon("glossary.modifiedOn", "General");
        }

        private void SetAttributes()
        {
            txtEventCode.MaxLength = 6;     // dbo.PromotionPaymentFactor.EventCode varchar(6)
            radTender.Checked = true;       // default

            #region 將補位 controls 移正
            lblEventCode.Location = lblTender.Location;
            txtEventCode.Location = cboTender.Location;
            cbxWorkplace.Location = cboWorkplace.Location;
            #endregion

            #region lvList layout
            lvList.Dock = DockStyle.Fill;
            lvList.GridLines = true;

            colLN.TextAlign = HorizontalAlignment.Center;
            colWorkplace.ContentAlign = ExtendedHorizontalAlignment.Center;
            colWorkplace.TextAlign = HorizontalAlignment.Left;
            colTenderType.ContentAlign = ExtendedHorizontalAlignment.Center;
            colTenderType.TextAlign = HorizontalAlignment.Left;
            colEventCode.ContentAlign = ExtendedHorizontalAlignment.Center;
            colEventCode.TextAlign = HorizontalAlignment.Left;
            colStartDate.ContentAlign = ExtendedHorizontalAlignment.Center;
            colStartDate.TextAlign = HorizontalAlignment.Left;
            colEndDate.ContentAlign = ExtendedHorizontalAlignment.Center;
            colEndDate.TextAlign = HorizontalAlignment.Left;
            colFactor.ContentAlign = ExtendedHorizontalAlignment.Center;
            colFactor.TextAlign = HorizontalAlignment.Right;
            colCreatedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colCreatedOn.TextAlign = HorizontalAlignment.Left;
            colModifiedOn.ContentAlign = ExtendedHorizontalAlignment.Center;
            colModifiedOn.TextAlign = HorizontalAlignment.Left;
            #endregion
        }

        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillWorkplaceList();
            FillTenderList();
        }

        private void FillWorkplaceList()
        {
            ModelEx.WorkplaceEx.LoadCombo(ref cboWorkplace, "WorkplaceCode", false);

            #region cbxWorkplace: CheckBox ComboBox
            cbxWorkplace.SetWidth(120);
            cbxWorkplace.SetSelectionMode(SelectionMode.MultiExtended);
            cbxWorkplace.Items.Clear();
            cbxWorkplace.ClearSelected();

            //cbxWorkplace.SetDataSource(cboWorkplace.DataSource);
            foreach (KeyValuePair<Guid, string> item in cboWorkplace.Items)
            {
                cbxWorkplace.AddKvpItem(item, false);
            }
            cbxWorkplace.SetDisplayMember("Value");
            cbxWorkplace.SetValueMember("Key");
            #endregion
        }

        private void FillTenderList()
        {
            var where = "TypeName <> ''";
            var orderBy = new string[] { "TypeCode", "TypeName" };
            ModelEx.PosTenderTypeEx.LoadCombo(ref cboTender, "TypeName", true, true, "", where, orderBy);
        }
        #endregion

        #region SwitchComapaignType
        private void SwitchComapaignType()
        {
            ClearForm();

            switch (_CampaignType)
            {
                case EnumHelper.CampaignType.TenderType:
                    lblTender.Visible = true;
                    cboTender.Visible = true;

                    lblEventCode.Visible = false;
                    txtEventCode.Visible = false;

                    colTenderType.Visible = true;
                    colEventCode.Visible = false;
                    break;
                case EnumHelper.CampaignType.EventCode:
                    lblTender.Visible = false;
                    cboTender.Visible = false;

                    lblEventCode.Visible = true;
                    txtEventCode.Visible = true;

                    colTenderType.Visible = false;
                    colEventCode.Visible = true;
                    break;
            }

            BindList();
        }
        #endregion

        #region ToolBar
        private void SetToolBar()
        {
            this.tbWizardAction.Buttons.Clear();
            this.tbWizardAction.ButtonClick -= new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);

            this.tbWizardAction.MenuHandle = false;
            this.tbWizardAction.DragHandle = false;
            this.tbWizardAction.TextAlign = ToolBarTextAlign.Right;

            ToolBarButton sep = new ToolBarButton();
            sep.Style = ToolBarButtonStyle.Separator;

            // cmdSave
            ToolBarButton cmdNew = new ToolBarButton("New", WestwindHelper.GetWord("edit.new", "General"));
            cmdNew.Tag = "New";
            cmdNew.Image = new IconResourceHandle("16x16.ico_16_3.gif");

            this.tbWizardAction.Buttons.Add(cmdNew);

            // cmdSave
            ToolBarButton cmdSave = new ToolBarButton("Save", WestwindHelper.GetWord("edit.save", "General"));
            cmdSave.Tag = "Save";
            cmdSave.Image = new IconResourceHandle("16x16.16_L_save.gif");

            this.tbWizardAction.Buttons.Add(cmdSave);

            // cmdSaveNew
            ToolBarButton cmdRefresh = new ToolBarButton("Refresh", WestwindHelper.GetWord("edit.refresh", "General"));
            cmdRefresh.Tag = "refresh";
            cmdRefresh.Image = new IconResourceHandle("16x16.16_L_refresh.gif");

            this.tbWizardAction.Buttons.Add(cmdRefresh);
            this.tbWizardAction.Buttons.Add(sep);

            // cmdDelete
            ToolBarButton cmdDelete = new ToolBarButton("Delete", WestwindHelper.GetWord("edit.delete", "General"));
            cmdDelete.Tag = "Delete";
            cmdDelete.Image = new IconResourceHandle("16x16.16_L_remove.gif");

            if (CampaignId == System.Guid.Empty)
            {
                cmdDelete.Enabled = false;
            }
            else
            {
                cmdDelete.Enabled = true;
            }

            this.tbWizardAction.Buttons.Add(cmdDelete);

            this.tbWizardAction.ButtonClick += new ToolBarButtonClickEventHandler(tbWizardAction_ButtonClick);
        }

        void tbWizardAction_ButtonClick(object sender, ToolBarButtonClickEventArgs e)
        {
            if (e.Button.Tag != null)
            {
                switch (e.Button.Tag.ToString().ToLower())
                {
                    case "new":
                        ClearForm();
                        break;
                    case "save":
                        MessageBox.Show("Save Record?", "Save Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(SaveConfirmationHandler));
                        break;
                    case "refresh":
                        ClearForm();
                        BindList();
                        break;
                    case "delete":
                        MessageBox.Show("Delete Record?", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(DeleteConfirmationHandler));
                        break;
                }
            }
        }
        #endregion

        #region SetEditLayout ClearForm
        private void SetEditLayout()
        {
            gbxStatus.Visible = _CampaignId != Guid.Empty;

            cboWorkplace.Visible = _CampaignId != Guid.Empty;
            cbxWorkplace.Visible = _CampaignId == Guid.Empty;
        }

        private void ClearForm()
        {
            dtpStartDate.Value = dtpEndDate.Value = DateTime.Now;
            txtFactorRate.Text = txtLastUpdatedOn.Text = txtLastUpdatedBy.Text = txtCreatedOn.Text = txtEventCode.Text = string.Empty;

            _CampaignId = Guid.Empty;
            SetEditLayout();
            FillComboList();
        }
        #endregion

        #region Binding list
        private void BindList()
        {
            lvList.Items.Clear();
            int iCount = 1;

            string sql = @"
SELECT     PaymentFactorId, WorkplaceId, WorkplaceCode, CurrencyCode, EventCode, 
            StartOn, EndOn, FactorRate, CreatedOn, CreatedBy, ModifiedOn, ModifiedBy
FROM        vwPaymentFactorList";

            sql += _CampaignType == EnumHelper.CampaignType.TenderType ?
                " WHERE Retired = 0 AND TypeId IS NOT NULL" : _CampaignType == EnumHelper.CampaignType.EventCode ?
                " WHERE Retired = 0 AND EventCode IS NOT NULL AND EventCode <> ''" :
                "";

            /**
            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    ListViewItem listItem = lvList.Items.Add(reader.GetGuid(0).ToString());
                    listItem.SubItems.Add(reader.GetGuid(1).ToString());
                    listItem.SubItems.Add(iCount.ToString());
                    listItem.SubItems.Add(reader.GetString(2)); // Workplace

                    if (this.PaymentFactorType == FactorType.Currency)
                    {
                        listItem.SubItems.Add(reader.GetString(3)); // Currency
                    }
                    else if (this.PaymentFactorType == FactorType.EventCode)
                    {
                        listItem.SubItems.Add(reader.GetString(4)); // Event Code
                    }

                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(5), false)); // Start date
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(6), false)); // End date
                    listItem.SubItems.Add(reader.GetDecimal(7).ToString("n" + RT2020.SystemInfo.Settings.GetQtyDecimalPoint().ToString())); // Factor rate
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(8), true)); // Created On
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(reader.GetDateTime(10), true)); // Modified On

                    iCount++;
                }
            }
            */
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.PromotionPaymentFactor
                    .SqlQuery(string.Format("Select * from PromotionPaymentFactor {0}", sql.Substring(sql.IndexOf("WHERE"))))
                    .AsNoTracking()
                    .ToList();

                foreach (var item in list)
                {
                    ListViewItem listItem = lvList.Items.Add(item.PaymentFactorId.ToString());
                    listItem.SubItems.Add(item.WorkplaceId.ToString());
                    listItem.SubItems.Add(iCount.ToString());
                    listItem.SubItems.Add(item.Workplace != null ? item.Workplace.WorkplaceCode : "");
                    listItem.SubItems.Add(item.TypeId != null ? item.PosTenderType.TypeName : "");
                    listItem.SubItems.Add(item.EventCode);
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.StartOn.Value, false));
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.EndOn.Value, false));
                    listItem.SubItems.Add(item.FactorRate.ToString("n2"));  // " + RT2020.SystemInfo.Settings.GetQtyDecimalPoint().ToString()));
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.CreatedOn, true));
                    listItem.SubItems.Add(DateTimeHelper.DateTimeToString(item.ModifiedOn, true));

                    iCount++;
                }
            }
            lvList.SelectedIndex = -1;
        }
        #endregion

        #region Save Methods
        private bool IsDuplicated()
        {
            string duplicatedMsg = Resources.Common.DuplicatedCode;

            string sql = "WorkplaceId = '" + cboWorkplace.SelectedValue.ToString() + "' AND {0} AND CONVERT(NVARCHAR(10), StartOn, 103) = '" + dtpStartDate.Value.ToString("dd/MM/yyyy") + "' AND CONVERT(NVARCHAR(10), EndOn, 103) = '" + dtpEndDate.Value.ToString("dd/MM/yyyy") + "'";

            if (_CampaignType == EnumHelper.CampaignType.TenderType)
            {
                sql = string.Format(sql, "CurrencyCode = '" + cboTender.Text + "'");
                duplicatedMsg = string.Format(duplicatedMsg, "Workplace + Currency + Data Range");
            }

            if (_CampaignType == EnumHelper.CampaignType.EventCode)
            {
                sql = string.Format(sql, "EventCode = '" + txtEventCode.Text + "'");
                duplicatedMsg = string.Format(duplicatedMsg, "Workplace + Event Code + Data Range");
            }

            var factorListCount = ModelEx.PromotionPaymentFactorEx.Counts(sql);
            if (factorListCount > 0)
            {
                errorProvider.SetError(cboWorkplace, duplicatedMsg);
                errorProvider.SetError(cboTender, duplicatedMsg);
                errorProvider.SetError(txtEventCode, duplicatedMsg);
                errorProvider.SetError(dtpStartDate, duplicatedMsg);
                errorProvider.SetError(dtpEndDate, duplicatedMsg);

                return true;
            }
            else
            {
                errorProvider.SetError(cboWorkplace, string.Empty);
                errorProvider.SetError(cboTender, string.Empty);
                errorProvider.SetError(txtEventCode, string.Empty);
                errorProvider.SetError(dtpStartDate, string.Empty);
                errorProvider.SetError(dtpEndDate, string.Empty);

                return false;
            }
        }

        private bool Verify()
        {
            if (cboWorkplace.SelectedValue == null)
            {
                errorProvider.SetError(cboWorkplace, "Can not null");
                errorProvider.SetIconAlignment(cboWorkplace, ErrorIconAlignment.TopLeft);
                return false;
            }
            else if ((Guid)cboTender.SelectedValue == Guid.Empty && this.CampaignType == EnumHelper.CampaignType.TenderType)
            {
                errorProvider.SetError(cboTender, "Can not null");
                errorProvider.SetIconAlignment(cboTender, ErrorIconAlignment.TopLeft);
                return false;
            }
            else if (txtEventCode.Text.Length == 0 && this.CampaignType == EnumHelper.CampaignType.EventCode)
            {
                errorProvider.SetError(txtEventCode, "Can not null");
                errorProvider.SetIconAlignment(txtEventCode, ErrorIconAlignment.TopLeft);
                return false;
            }
            else
            {
                errorProvider.SetError(txtEventCode, string.Empty);
                errorProvider.SetError(cboWorkplace, string.Empty);
                errorProvider.SetError(cboTender, string.Empty);
                return true;
            }
        }

        private bool Save()
        {
            bool result = false;

            if (Verify() && !IsDuplicated())
            {
                if (_CampaignId == Guid.Empty)
                {
                    #region EidtMode.Add: 多 Workplace
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        using (var scope = ctx.Database.BeginTransaction())
                        {
                            try
                            {
                                var list = cbxWorkplace.GetCheckedComboView();
                                for (int i = 0; i < list.Items.Count; i++)
                                {
                                    var chk = cbxWorkplace.GetCheck(i);
                                    if (cbxWorkplace.GetCheck(i))
                                    {
                                        var row = (KeyValuePair<Guid, string>)list.Items[i];

                                        var item = new EF6.PromotionPaymentFactor();
                                        item = new EF6.PromotionPaymentFactor();
                                        item.PaymentFactorId = Guid.NewGuid();
                                        item.CreatedBy = ConfigHelper.CurrentUserId;
                                        item.CreatedOn = DateTime.Now;
                                        item.Retired = false;

                                        item.WorkplaceId = row.Key;
                                        if ((Guid)cboTender.SelectedValue != Guid.Empty) item.TypeId = (Guid)cboTender.SelectedValue;
                                        item.EventCode = txtEventCode.Text;
                                        item.FactorRate = (txtFactorRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtFactorRate.Text);
                                        item.StartOn = dtpStartDate.Value;
                                        item.EndOn = dtpEndDate.Value;

                                        item.ModifiedBy = ConfigHelper.CurrentUserId;
                                        item.ModifiedOn = DateTime.Now;

                                        ctx.PromotionPaymentFactor.Add(item);
                                        ctx.SaveChanges();
                                    }
                                }
                                scope.Commit();
                                result = true;
                            }
                            catch (Exception ex)
                            {
                                scope.Rollback();
                            }
                        }
                    }
                    #endregion
                }
                else
                {
                    #region EditMode.Edit: 單 Wokrplace
                    using (var ctx = new EF6.RT2020Entities())
                    {
                        var item = ctx.PromotionPaymentFactor.Find(_CampaignId);
                        if (item != null)
                        {
                            if ((Guid)cboWorkplace.SelectedValue != Guid.Empty) item.WorkplaceId = (Guid)cboWorkplace.SelectedValue;
                            if ((Guid)cboTender.SelectedValue != Guid.Empty) item.TypeId = (Guid)cboTender.SelectedValue;
                            item.EventCode = txtEventCode.Text;
                            item.FactorRate = (txtFactorRate.Text.Length == 0) ? 0 : Convert.ToDecimal(txtFactorRate.Text);
                            item.StartOn = dtpStartDate.Value;
                            item.EndOn = dtpEndDate.Value;

                            item.ModifiedBy = ConfigHelper.CurrentUserId;
                            item.ModifiedOn = DateTime.Now;

                            ctx.SaveChanges();
                            result = true;
                        }
                    }
                    #endregion
                }
            }

            return result;
        }
        #endregion

        #region Load Methods
        private void LoadData()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var item = ctx.PromotionPaymentFactor.Find(_CampaignId);
                if (item != null)
                {
                    cboWorkplace.SelectedValue = item.WorkplaceId.HasValue ? item.WorkplaceId : Guid.Empty;
                    cboTender.SelectedValue = item.TypeId.HasValue ? item.TypeId : Guid.Empty;
                    txtEventCode.Text = item.EventCode;
                    txtFactorRate.Text = item.FactorRate.ToString("n2");
                    dtpStartDate.Value = item.StartOn.HasValue ? item.StartOn.Value : DateTimeHelper.DateZero();
                    dtpEndDate.Value = item.EndOn.HasValue ? item.EndOn.Value : DateTimeHelper.DateZero();

                    txtCreatedOn.Text = DateTimeHelper.DateTimeToString(item.CreatedOn, false);
                    txtLastUpdatedBy.Text = ModelEx.StaffEx.GetStaffNumberById(item.ModifiedBy);
                    txtLastUpdatedOn.Text = DateTimeHelper.DateTimeToString(item.ModifiedOn, false);
                }
            }
        }

        #endregion

        private void DeleteConfirmationHandler(object sender, EventArgs e)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                try
                {
                    var item = ctx.PromotionPaymentFactor.Find(this.CampaignId);
                    if (item != null)
                    {
                        item.Retired = true;
                        item.RetiredBy = ConfigHelper.CurrentUserId;
                        item.RetiredOn = DateTime.Now;
                        ctx.SaveChanges();

                        MessageBox.Show("Delete Successfully!", "Delete Result");
                        ClearForm();
                        BindList();
                    }
                }
                catch
                {
                    MessageBox.Show("Cannot delete the record...Might be in use by other record!", "Delete Warning");
                }
            }
        }

        private void SaveConfirmationHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Save())
                {
                    this.ClearForm();
                    BindList();
                }
            }
        }

        private void lvPaymentFactor_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvList.SelectedItem != null)
            {
                var id = Guid.NewGuid();
                if (Guid.TryParse(lvList.SelectedItem.Text, out id))
                {
                    _CampaignId = id;
                    LoadData();
                    SetToolBar();
                    SetEditLayout();
                }
            }
        }

        private void compaign_OnChanged(object sender, EventArgs e)
        {
            if (radTender.Checked) _CampaignType = EnumHelper.CampaignType.TenderType;
            if (radEvent.Checked) _CampaignType = EnumHelper.CampaignType.EventCode;
            SwitchComapaignType();
        }
    }
}