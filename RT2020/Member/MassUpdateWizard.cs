#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using System.Reflection;

using System.Data.SqlClient;
using System.Linq;
using System.Data.Entity;

using RT2020.Common.Helper;
using RT2020.Common.ModelEx;

#endregion

namespace RT2020.Member
{
    public partial class MassUpdateWizard : Form
    {
        //2014.01.08 paulus: 根據 Opera 嘅 RT2000，Member Group = Workplace 嘅 Shop

        /// <summary>
        /// Initializes a new instance of the <see cref="MassUpdateWizard"/> class.
        /// </summary>
        public MassUpdateWizard()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        /**
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.FillComboList();
            txtFromMemberNumber.Focus();

            cboFromShop.AutoCompleteMode = AutoCompleteMode.Append;
            cboToShop.AutoCompleteMode = AutoCompleteMode.Append;
            cboFromGrade.AutoCompleteMode = AutoCompleteMode.Append;
            cboToGrade.AutoCompleteMode = AutoCompleteMode.Append;
        }
        */
        private void MassUpdateWizard_Load(object sender, EventArgs e)
        {
            SetCaptions();
            SetAttributes();

            FillComboList();
            txtFromMemberNumber.Focus();
        }

        #region SetCaptions SetAttributes
        private void SetCaptions()
        {
            this.Text = WestwindHelper.GetWord("member.batchUpdateDiscount", "MenuStrip");
            gbxOptions.Text = WestwindHelper.GetWord("glossary.options", "General");
            lblMemberNumber.Text = WestwindHelper.GetWordWithColon("member.number", "Model");
            lblFromShop.Text = WestwindHelper.GetWordWithColon("workplace", "Model");
            lblToGrade.Text = lblToMemberNumber.Text = lblToShop.Text = WestwindHelper.GetWordWithColon("glossary.to", "General");

            gbxUpdates.Text = WestwindHelper.GetWord("member.others.discount", "Model");
            chkNormalDiscount.Text = WestwindHelper.GetWordWithColon("member.others.regularItem", "Model");
            chkPromotionDiscount.Text = WestwindHelper.GetWordWithColon("member.others.promotionalItem", "Model");
            chkAddOnDiscount.Text = WestwindHelper.GetWordWithColon("member.others.addonDiscount", "Model");
            chkStaffQuota.Text = WestwindHelper.GetWordWithColon("member.others.staffQuota", "Model");
            btnUpdate.Text = WestwindHelper.GetWord("edit.update", "General");
            btnCancel.Text = WestwindHelper.GetWord("glossary.cancel", "General");
        }

        private void SetAttributes()
        {
            cboFromShop.AutoCompleteMode = AutoCompleteMode.Append;
            cboToShop.AutoCompleteMode = AutoCompleteMode.Append;
            cboFromGrade.AutoCompleteMode = AutoCompleteMode.Append;
            cboToGrade.AutoCompleteMode = AutoCompleteMode.Append;

            string[] orderBy = new string[] { "Priority" };
            var smartTagList = SmartTag4MemberEx.GetListOrderBy(orderBy, true);

            SmartTagHelper oTag = new SmartTagHelper(this.gbxOptions);
            oTag.MemberSmartTagList = smartTagList;
            oTag.SetSmartTags();

            #region 設定 clickable saluation label
            lblSmartTag1.AutoSize = true;                      // 減少 whitespace，有字嘅位置先可以 click
            lblSmartTag1.Cursor = Cursors.Hand;                // cursor over 顯示 hand cursor
            lblSmartTag1.Click += (s, e) =>                    // 彈出 wizard
            {
                var id = SmartTag4MemberEx.GetIdByPriority(1);
                var dialog = new SmartTag4Member_OptionsWizard();
                dialog.SmartTagId = id;
                dialog.FormClosed += (sender, eventArgs) =>     // 關閉後 refresh 個 combo box items
                {
                    FillGrade();
                };
                dialog.ShowDialog();
            };
            #endregion
        }
        #endregion

        #region Fill ComboBox

        /// <summary>
        /// Fills the combo list.
        /// </summary>
        private void FillComboList()
        {
            FillGroup();
            FillGrade();
        }

        /// <summary>
        /// Fills the group.
        /// </summary>
        private void FillGroup()
        {
            cboFromShop.Items.Clear();
            cboToShop.Items.Clear();

            //MemberGroup.LoadCombo(ref cboFromGroup, new string[] { "GroupCode", "GroupName" }, "{0} - {1}", false, false, String.Empty, String.Empty);
            //MemberGroup.LoadCombo(ref cboToGroup, new string[] { "GroupCode", "GroupName" }, "{0} - {1}", false, false, String.Empty, String.Empty);
            RT2020.Controls.Workplace.LoadComboBox_Shops(ref cboFromShop);
            RT2020.Controls.Workplace.LoadComboBox_Shops(ref cboToShop);

            cboFromShop.SelectedIndex = 0;
            cboToShop.SelectedIndex = 0;
        }

        /// <summary>
        /// Fills the grade.
        /// </summary>
        private void FillGrade()
        {
            /**
            cboFromGrade.Items.Clear();
            cboToGrade.Items.Clear();

            string query = "SELECT DISTINCT SmartTagValue FROM MemberSmartTag WHERE TagId IN (SELECT TagId FROM SmartTag4Member WHERE TagCode = 'Grade' AND Priority = 1) ORDER BY SmartTagValue";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = 600;
            cmd.CommandType = CommandType.Text;

            using (SqlDataReader reader = SqlHelper.Default.ExecuteReader(cmd))
            {
                while (reader.Read())
                {
                    cboFromGrade.Items.Add(reader.GetString(0));
                    cboToGrade.Items.Add(reader.GetString(0));
                }
            }
            if (cboFromGrade.Items.Count > 0)
            {
                cboFromGrade.SelectedIndex = 0;
                cboToGrade.SelectedIndex = 0;
            }
            */
            SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboFromGrade, 1);
            SmartTag4Member_OptionsEx.FillSmartTagComboBox(ref cboToGrade, 1);
        }

        #endregion

        #region Events

        /// <summary>
        /// Buttons the click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ButtonClick(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button btnCtrl = sender as Button;
                if (btnCtrl != null)
                {
                    switch (btnCtrl.Name.ToLower())
                    {
                        case "btnlookupfrommembernumber":
                            this.ShowSearchForm(txtFromMemberNumber.Name);
                            break;
                        case "btnlookuptomembernumber":
                            this.ShowSearchForm(txtToMemberNumber.Name);
                            break;
                        case "btnupdate":
                            MessageBox.Show("Update Records?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(UpdateMessageHandler));
                            break;
                        case "btncancel":
                            this.Close();
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Checks the box click.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void CheckBoxClick(object sender, EventArgs e)
        {
            if (sender is CheckBox)
            {
                CheckBox chkCtrl = sender as CheckBox;
                if (chkCtrl != null)
                {
                    switch (chkCtrl.Name.ToLower())
                    {
                        case "chknormaldiscount":
                            txtNormalDiscount.Enabled = chkNormalDiscount.Checked;
                            txtNormalDiscount.Select(0, txtNormalDiscount.Text.Length);
                            break;
                        case "chkpromotiondiscount":
                            txtPromotionDiscount.Enabled = chkPromotionDiscount.Checked;
                            txtPromotionDiscount.Select(0, txtPromotionDiscount.Text.Length);
                            break;
                        case "chkaddondiscount":
                            chkCheckAddOnDiscount.Enabled = chkAddOnDiscount.Checked;
                            chkCheckAddOnDiscount.Select();
                            break;
                        case "chkstaffquota":
                            txtStaffQuota.Enabled = chkStaffQuota.Checked;
                            txtStaffQuota.Select(0, txtStaffQuota.Text.Length);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Shows the search form.
        /// </summary>
        /// <param name="searchForm">the value be look up to TextBox control</param>
        private void ShowSearchForm(string lookupTo)
        {
            MemberWizard_Find findForm = new MemberWizard_Find();
            findForm.Closed += new EventHandler(findForm_Closed);
            findForm.LookUpTo = lookupTo;
            findForm.ShowDialog();
        }

        /// <summary>
        /// Handles the Closed event of the findForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void findForm_Closed(object sender, EventArgs e)
        {
            MemberWizard_Find findForm = sender as MemberWizard_Find;
            if (findForm != null)
            {
                Control[] txtCtrls = this.gbxOptions.Controls.Find(findForm.LookUpTo, false);
                if (txtCtrls.Length > 0)
                {
                    TextBox txtCtrl = txtCtrls[0] as TextBox;
                    if (txtCtrl != null)
                    {
                        txtCtrl.Text = findForm.SelectedMember;
                    }
                }
            }
        }

        /// <summary>
        /// Updates the message handler.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UpdateMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                int succeedRec = UpdateVip();
                if (succeedRec > 0)
                {
                    MessageBox.Show("Updated " + succeedRec.ToString() + " records!", "Success!");
                }
                else
                {
                    MessageBox.Show("Updated 0 record!", "Failed!");
                }
            }
        }

        #endregion

        /// <summary>
        /// Determines whether the specified member id is updatable.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        /// <returns>
        /// 	<c>true</c> if the specified member id is updatable; otherwise, <c>false</c>.
        /// </returns>
        private bool IsUpdatable(Guid memberId)
        {
            bool result = true;
            List<Guid> shopRange = GetShopRange();

            using (var ctx = new EF6.RT2020Entities())
            {
                var objMember = ctx.Member.Find(memberId);
                if (objMember != null)
                {
                    result = result & shopRange.Contains(objMember.WorkplaceId.Value);
                }
                else
                {
                    result = result & false;
                }

                //String query = String.Format("MemberId = '{0}' AND SmartTagValue >= '{1}' AND SmartTagValue <= '{2}' AND TagId IN (SELECT TagId FROM SmartTag4Member WHERE TagCode = 'Grade' AND Priority = 1)",
                //    memberId.ToString(), cboFromGrade.Text, cboToGrade.Text);

                var tag = ctx.SmartTag4Member.Where(x => x.TagCode == "Grade" && x.Priority == 1).FirstOrDefault();
                if (tag != null)
                {
                    var list = ctx.MemberSmartTag.Where(x => x.MemberId == memberId && x.SmartTagValue == cboFromGrade.Text && x.TagId == tag.TagId).ToList();
                    result = result & (list.Count > 0);
                }
            }

            return result;
        }

        /// <summary>
        /// Full updates of this instance.
        /// </summary>
        /// <returns></returns>
        private int UpdateVip()
        {
            int result = 0;
            String query = String.Format("VipNumber >= '{0}' AND VipNumber <= '{1}'", txtFromMemberNumber.Text.Trim(), txtToMemberNumber.Text.Trim());
            var fromMember = txtFromMemberNumber.Text.Trim();
            var toMember = txtToMemberNumber.Text.Trim();

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    try
                    {
                        var objMemberVipList = ctx.MemberVipData
                            .Where(x => x.VipNumber.CompareTo(fromMember) >= 0 && x.VipNumber.CompareTo(toMember) <= 0);
                        foreach (var objMemberVip in objMemberVipList)
                        {
                            if (objMemberVip != null)
                            {
                                if (IsUpdatable(objMemberVip.MemberId))
                                {
                                    #region Normal Discount (Member)
                                    var objMember = ctx.Member.Find(objMemberVip.MemberId);
                                    if (objMember != null)
                                    {
                                        if (chkNormalDiscount.Checked)
                                        {
                                            decimal normalDiscount = 0;
                                            objMember.NormalDiscount = decimal.TryParse(txtNormalDiscount.Text, out normalDiscount) ? normalDiscount : objMember.NormalDiscount;
                                        }

                                        objMember.ModifiedBy = ConfigHelper.CurrentUserId;
                                        objMember.ModifiedOn = DateTime.Now;
                                        objMember.Status = (int)EnumHelper.Status.Modified;
                                        ctx.SaveChanges();
                                    }
                                    #endregion

                                    #region Add-on Discount & Staff Quota (Member VIP Data)
                                    if (chkAddOnDiscount.Checked)
                                    {
                                        objMemberVip.AddOnDiscount = chkCheckAddOnDiscount.Checked;
                                    }

                                    if (chkStaffQuota.Checked)
                                    {
                                        decimal quote = 0;
                                        objMemberVip.StaffQuota = decimal.TryParse(txtStaffQuota.Text, out quote) ? quote: objMemberVip.StaffQuota;
                                    }
                                    #endregion

                                    ctx.SaveChanges();

                                    #region Promotion Discount
                                    //query = "MemberVipId = '" + objMemberVip.MemberVipId.ToString() + "'";
                                    var objVipLoo = ctx.MemberVipLineOfOperation.Where(x => x.MemberVipId == objMemberVip.MemberVipId).FirstOrDefault();
                                    if (objVipLoo != null)
                                    {
                                        if (chkPromotionDiscount.Checked)
                                        {
                                            decimal promoDiscount = 0;
                                            decimal.TryParse(txtPromotionDiscount.Text, out promoDiscount);
                                            objVipLoo.PromotionDiscount = decimal.TryParse(txtPromotionDiscount.Text, out promoDiscount) ? promoDiscount : objVipLoo.PromotionDiscount;
                                        }

                                        ctx.SaveChanges();
                                    }
                                    #endregion

                                    result++;
                                }
                            }
                        }
                        scope.Commit();
                    }
                    catch (Exception ex)
                    {
                        scope.Rollback();
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Gets the group range.
        /// </summary>
        /// <returns></returns>
        private List<Guid> GetShopRange()
        {
            List<Guid> shopRange = new List<Guid>();
            using (var ctx = new EF6.RT2020Entities())
            {
                var from = cboFromShop.Text.Substring(0, cboFromShop.Text.IndexOf('-')).Trim();
                var to = cboToShop.Text.Substring(0, cboToShop.Text.IndexOf('-')).Trim();
                // WorkplaceCode BETWEEN from AND to
                var list = ctx.Workplace
                    .Where(x => string.Compare(x.WorkplaceCode, from) > 0 && string.Compare(x.WorkplaceCode, to) < 0)
                    .OrderBy(x => x.WorkplaceCode)
                    .AsNoTracking()
                    .ToList();

                //String query = String.Format("WorkplaceCode BETWEEN '{0}' AND '{1}",
                //cboFromShop.Text.Substring(0, cboFromShop.Text.IndexOf('-')).Trim(), cboToShop.Text.Substring(0, cboToShop.Text.IndexOf('-')).Trim());
                //DAL.WorkplaceCollection shopList = DAL.Workplace.LoadCollection(query, new string[] { "WorkplaceCode" }, true);
                for (int i = 0; i < list.Count; i++)
                {
                    shopRange.Add(list[i].WorkplaceId);
                }
            }

            return shopRange;
        }
    }
}