#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Staff
{
    public partial class FindHKID : Form
    {
        public FindHKID()
        {
            InitializeComponent();
        }

        #region Properties
        private bool isCompleted = false;
        public bool IsCompleted
        {
            get
            {
                return isCompleted;
            }
            set
            {
                isCompleted = value;
            }
        }

        private string HKid = string.Empty; 
        public string HKID
        {
            get
            {
                return HKid;
            }
            set
            {
                HKid = value;
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lvStaffList.SelectedItem != null)
            {
                this.IsCompleted = true;
                this.HKID = lvStaffList.SelectedItem.SubItems[2].Text;
                this.Close();
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string whereClause = string.Empty;
            RT2020.DAL.Staff staff = null;
            if (!txtStaff.Text.Trim().Equals("*"))
            {
                string whereStr = " StaffNumber = '" + txtStaff.Text.Trim() + "'";
                staff = RT2020.DAL.Staff.LoadWhere(whereStr);
            }

            RT2020.DAL.SmartTag4Staff smartTag4Staff = RT2020.DAL.SmartTag4Staff.LoadWhere(" TagCode = 'HKID'");

            if (!txtHKID.Text.Trim().Equals("*"))
            {
                if (smartTag4Staff != null)
                {
                    if (staff != null)
                    {
                        whereClause = " StaffId = '" + staff.StaffId.ToString() + "' AND TagId = '" + smartTag4Staff.TagId.ToString() + "' AND SmartTagValue = '" + txtHKID.Text.Trim() + "'";
                    }
                    else
                    {
                        whereClause = " TagId = '" + smartTag4Staff.TagId.ToString() + "' AND SmartTagValue = '" + txtHKID.Text.Trim() + "'";
                    }
                }
            }
            else
            {
                if (smartTag4Staff != null)
                {
                    if (staff != null)
                    {
                        whereClause = " StaffId = '" + staff.StaffId.ToString() + "' AND TagId = '" + smartTag4Staff.TagId.ToString() + "'";
                    }
                    else
                    {
                        whereClause = " TagId = '" + smartTag4Staff.TagId.ToString() + "'";
                    }
                }
            }

            RT2020.DAL.StaffSmartTagCollection oStaffSmartTag = RT2020.DAL.StaffSmartTag.LoadCollection(whereClause);

            if (oStaffSmartTag.Count > 0)
            {
                int iCount = 1;
                foreach (RT2020.DAL.StaffSmartTag staffSmartTag in oStaffSmartTag)
                {
                    ListViewItem objItem = this.lvStaffList.Items.Add(iCount.ToString());
                    if (staff == null)
                    {
                        RT2020.DAL.Staff sta = RT2020.DAL.Staff.Load(staffSmartTag.StaffId);
                        if (sta != null)
                        {
                            objItem.SubItems.Add(sta.StaffNumber);
                        }
                    }
                    else
                    {
                        objItem.SubItems.Add(txtStaff.Text.Trim());
                    }

                    objItem.SubItems.Add(staffSmartTag.SmartTagValue);

                    iCount++;
                }
            }
        }
    }
}