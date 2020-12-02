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
            EF6.Staff staff = null;
            if (!txtStaff.Text.Trim().Equals("*"))
            {
                staff = ModelEx.StaffEx.GetByStaffNumber(txtStaff.Text.Trim());
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

            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.StaffSmartTag.SqlQuery(
                    String.Format(
                        "Select * from StaffSmartTag Where {0}",
                        String.IsNullOrEmpty(whereClause) ? "1 = 1" : whereClause
                    ))
                    .AsNoTracking()
                    .ToList();

                if (list.Count > 0)
                {
                    int iCount = 1;
                    foreach (var item in list)
                    {
                        ListViewItem objItem = this.lvStaffList.Items.Add(iCount.ToString());
                        if (staff == null)
                        {
                            var sta = ModelEx.StaffEx.GetByStaffId(item.StaffId);
                            if (sta != null)
                            {
                                objItem.SubItems.Add(sta.StaffNumber);
                            }
                        }
                        else
                        {
                            objItem.SubItems.Add(txtStaff.Text.Trim());
                        }

                        objItem.SubItems.Add(item.SmartTagValue);

                        iCount++;
                    }
                }
            }
        }
    }
}