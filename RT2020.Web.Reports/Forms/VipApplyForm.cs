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

#endregion

namespace RT2020.Web.Reports.Forms
{
    public partial class VipApplyForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VipApplyForm"/> class.
        /// </summary>
        public VipApplyForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Raises the <see cref="E:Gizmox.WebGUI.Forms.Form.Load"></see> event.
        /// </summary>
        /// <param name="e">An <see cref="T:System.EventArgs"></see> that contains the event data.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GetDraftVIPNumber();
        }

        /// <summary>
        /// Gets the draft VIP number.
        /// </summary>
        private void GetDraftVIPNumber()
        {
            string query = @"LEN(LTRIM(RTRIM(MemberInitial))) = 0 AND LEN(LTRIM(RTRIM(FirstName))) = 0 AND LEN(LTRIM(RTRIM(LastName))) = 0 AND LEN(LTRIM(RTRIM(REPLACE(FullName, ',', '')))) = 0 AND (LEN(LTRIM(RTRIM(FullName_Chs))) = 0 AND LEN(LTRIM(RTRIM(FullName_Cht))) = 0)";
            RT2020.DAL.MemberCollection oMemberList = RT2020.DAL.Member.LoadCollection(query, new string[] { "MemberNumber" }, true);
            foreach (RT2020.DAL.Member oMember in oMemberList)
            {
                query = @"MemberId = '" + oMember.MemberId.ToString() + @"' AND LEN(LTRIM(RTRIM(PhoneTag1Value))) = 0 AND LEN(LTRIM(RTRIM(PhoneTag2Value))) = 0
                 AND LEN(LTRIM(RTRIM(PhoneTag3Value))) = 0 AND LEN(LTRIM(RTRIM(PhoneTag4Value))) = 0 AND LEN(LTRIM(RTRIM(PhoneTag5Value))) = 0";
                MemberAddress oAddress = MemberAddress.LoadWhere(query);
                if (oAddress != null)
                {
                    txtTempVipNumber.Text = oMember.MemberNumber;
                    txtTempVipNumber.ForeColor = Color.Blue;
                    break;
                }
            }
        }

        /// <summary>
        /// Handles the Click event of the btnSubmit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Verify())
            {
                string query = "StaffNumber = '" + txtStaffNumber.Text.Replace("'", "") + "'";
                Staff objStaff = Staff.LoadWhere(query);
                if (objStaff != null)
                {
                    if (objStaff.Password == txtPassword.Text)
                    {
                        // if the staff exists. apply a temp vip number.
                        System.Guid memberId = ApplyVipNumber(objStaff.StaffId);

                        if (memberId != System.Guid.Empty)
                        {
                            this.ApplyMemberAddress(memberId);
                            this.ApplyMemberSmartTag(memberId);
                            this.ApplyMemberVipData(memberId);

                            MessageBox.Show("Successful!", "Result", new EventHandler(ResultEventHandle));
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Results the event handle.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ResultEventHandle(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Apply VIP

        /// <summary>
        /// Gets the temp vip number.
        /// </summary>
        /// <returns></returns>
        //private int GetTempVipNumber()
        //{
        //    int tmpVip = 0;
        //    string query = "QueuingType = 'TVP'";
        //    SystemQueue objQueue = SystemQueue.LoadWhere(query);
        //    if (objQueue == null)
        //    {
        //        objQueue = new SystemQueue();
        //        objQueue.QueuingType = "TVP";
        //    }

        //    tmpVip = objQueue.LastNumber + 1;
        //    objQueue.LastNumber = tmpVip;
        //    objQueue.Save();

        //    return tmpVip;
        //}

        /// <summary>
        /// Verifies this instance.
        /// </summary>
        /// <returns></returns>
        private bool Verify()
        {
            bool isValid = true;

            // HKID
            if (txtHKID.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtHKID, "ID# cannot be blank!");
                isValid = isValid & false;
            }
            else
            {
                if (HasHKID())
                {
                    errorProvider.SetError(txtHKID, "ID# exists!");
                    isValid = isValid & false;
                }
                else
                {
                    errorProvider.SetError(txtHKID, string.Empty);
                }
            }

            // First name
            if (txtFirstName.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtFirstName, "First name cannot be blank!");
                isValid = isValid & false;
            }
            else
            {
                errorProvider.SetError(txtFirstName, string.Empty);
            }

            // Last Name
            if (txtPhone1.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtPhone1, "Last name cannot be blank!");
                isValid = isValid & false;
            }
            else
            {
                errorProvider.SetError(txtPhone1, string.Empty);
            }

            // Phone #
            if (txtPhone2.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtPhone2, "Phone # cannot be blank!");
                isValid = isValid & false;
            }
            else
            {
                errorProvider.SetError(txtPhone2, string.Empty);
            }

            // Staff number
            if (txtStaffNumber.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtStaffNumber, "Staff number cannot be blank!");
                isValid = isValid & false;
            }
            else
            {
                errorProvider.SetError(txtStaffNumber, string.Empty);
            }

            // Password
            if (txtPassword.Text.Trim().Length == 0)
            {
                errorProvider.SetError(txtPassword, "Password cannot be blank!");
                isValid = isValid & false;
            }
            else
            {
                errorProvider.SetError(txtPassword, string.Empty);
            }

            return isValid;
        }

        /// <summary>
        /// Determines whether this instance has HKID.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if this instance has HKID; otherwise, <c>false</c>.
        /// </returns>
        private bool HasHKID()
        {
            bool isValid = false;

            string query = "SmartTagValue = '" + txtHKID.Text + "' AND TagId IN (SELECT TagId FROM SmartTag4Member WHERE TagCode = 'HKID')";
            MemberSmartTagCollection objTagList = MemberSmartTag.LoadCollection(query);
            if (objTagList.Count > 0)
            {
                isValid = true;
            }

            return isValid;
        }

        /// <summary>
        /// Checks the vip number.
        /// </summary>
        //private string GetValidVipNumber()
        //{
        //    string tempNum = GetTempVipNumber().ToString().PadLeft(13, '0');
        //    string query = "MemberNumber = '" + tempNum + "'";
        //    Member objMember = Member.LoadWhere(query);
        //    if (objMember != null)
        //    {
        //        return GetValidVipNumber();
        //    }
        //    else
        //    {
        //        return tempNum;
        //    }
        //}

        /// <summary>
        /// Applies the vip number.
        /// </summary>
        private Guid ApplyVipNumber(Guid staffId)
        {
            GetDraftVIPNumber();
            string query = "MemberNumber = '" + txtTempVipNumber.Text + "'";

            Member objMember = Member.LoadWhere(query);
            if (objMember != null)
            {
                objMember.FirstName = txtFirstName.Text;
                objMember.FullName = txtFirstName.Text + ",";

                objMember.ModifiedBy = staffId;
                objMember.ModifiedOn = DateTime.Now;

                objMember.Save();

                return objMember.MemberId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        /// <summary>
        /// Applies the member address.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        private void ApplyMemberAddress(Guid memberId)
        {
            System.Guid addrTypeId = GetAddressTypeId();
            string query = "MemberId = '" + memberId.ToString() + "' AND AddressTypeId = '" + addrTypeId.ToString() + "'";
            MemberAddress objAddress = MemberAddress.LoadWhere(query);
            if (objAddress == null)
            {
                objAddress = new MemberAddress();
                objAddress.MemberId = memberId;
                objAddress.AddressTypeId = addrTypeId;
            }

            objAddress.PhoneTag1 = GetPhoneTag(1); //Work
            objAddress.PhoneTag1Value = txtPhone1.Text;
            objAddress.PhoneTag2 = GetPhoneTag(2); //Home
            objAddress.PhoneTag2Value = txtPhone2.Text;
            objAddress.Save();
        }

        /// <summary>
        /// Gets the address type id.
        /// </summary>
        /// <returns></returns>
        private Guid GetAddressTypeId()
        {
            string query = "AddressTypeCode = 'ADDR_EN'";
            MemberAddressType oAddrType = MemberAddressType.LoadWhere(query);
            if (oAddrType != null)
            {
                return oAddrType.AddressTypeId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        /// <summary>
        /// Gets the phone tag.
        /// </summary>
        /// <returns></returns>
        private Guid GetPhoneTag(int priority)
        {
            string query = "Priority = " + priority.ToString();
            PhoneTag oPhoneTag = PhoneTag.LoadWhere(query);
            if (oPhoneTag != null)
            {
                return oPhoneTag.PhoneTagId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        /// <summary>
        /// Applies the member smart tag.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        private void ApplyMemberSmartTag(Guid memberId)
        {
            System.Guid tagId = GetSmartTagId("HKID");
            string query = "MemberId = '" + memberId.ToString() + "' AND TagId = '" + tagId.ToString() + "'";
            MemberSmartTag objTag = MemberSmartTag.LoadWhere(query);
            if (objTag == null)
            {
                objTag = new MemberSmartTag();
                objTag.MemberId = memberId;
                objTag.TagId = tagId;
            }
            objTag.SmartTagValue = txtHKID.Text;
            objTag.Save();
        }

        /// <summary>
        /// Gets the smart tag id.
        /// </summary>
        /// <param name="p">The smartTagCode.</param>
        /// <returns></returns>
        private Guid GetSmartTagId(string smartTagCode)
        {
            string query = "TagCode = '" + smartTagCode + "'";
            SmartTag4Member oSTM = SmartTag4Member.LoadWhere(query);
            if (oSTM != null)
            {
                return oSTM.TagId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }

        /// <summary>
        /// Applies the member vip data.
        /// </summary>
        /// <param name="memberId">The member id.</param>
        private void ApplyMemberVipData(Guid memberId)
        {
            string query = "MemberId = '" + memberId.ToString() + "'";
            MemberVipData objVip = MemberVipData.LoadWhere(query);
            if (objVip == null)
            {
                objVip = new MemberVipData();
                objVip.MemberId = memberId;
            }
            objVip.VipNumber = txtTempVipNumber.Text;
            objVip.Save();

            this.ApplyVIPLineOfOperation(objVip.MemberVipId);
        }

        /// <summary>
        /// Applies the VIP line of operation.
        /// </summary>
        /// <param name="vipMemberId">The vip member id.</param>
        private void ApplyVIPLineOfOperation(Guid vipMemberId)
        {
            System.Guid looId = GetLooId();
            if (looId != System.Guid.Empty)
            {
                string query = "MemberVipId = '" + vipMemberId.ToString() + "'";
                MemberVipLineOfOperation objLoo = MemberVipLineOfOperation.LoadWhere(query);
                if (objLoo == null)
                {
                    objLoo = new MemberVipLineOfOperation();
                    objLoo.MemberVipId = vipMemberId;
                }
                objLoo.LineOfOperationId = looId;
                objLoo.Save();
            }
        }

        private Guid GetLooId()
        {
            LineOfOperation loo = LineOfOperation.LoadWhere("LineOfOperationCode = 'HKR'");
            if (loo != null)
            {
                return loo.LineOfOperationId;
            }
            else
            {
                return System.Guid.Empty;
            }
        }
        #endregion
    }
}