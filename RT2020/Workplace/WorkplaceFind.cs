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

namespace RT2020.Workplace
{
    public partial class WorkplaceFind : Form
    {
        public WorkplaceFind()
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

        private Guid workplaceID = System.Guid.Empty;
        public Guid WorkplaceID
        {
            get
            {
                return workplaceID;
            }
            set
            {
                workplaceID = value;
            }
        }
        #endregion

        private void btnFind_Click(object sender, EventArgs e)
        {
            string whereClause = string.Empty; 
            if (!txtLoc.Text.Trim().Equals("*"))
            {
                whereClause = " WorkplaceCode = '" + txtLoc.Text.Trim() + "'";
            }

            if (!txtInitial.Text.Trim().Equals("*"))
            {
                if (whereClause == string.Empty)
                {
                    whereClause = " WorkplaceInitial = '" + txtInitial.Text.Trim() + "'";
                }
                else
                {
                    whereClause = whereClause + " AND WorkplaceInitial = '" + txtInitial.Text.Trim() + "'";
                }
            }

            RT2020.DAL.WorkplaceCollection WorkplaceCol;
            if (whereClause != string.Empty)
            {
                WorkplaceCol = RT2020.DAL.Workplace.LoadCollection(whereClause);
            }
            else
            {
                WorkplaceCol = RT2020.DAL.Workplace.LoadCollection();   
            }

            if (WorkplaceCol.Count > 0)
            {
                int iCount = 1;
                foreach (RT2020.DAL.Workplace workplace in WorkplaceCol)
                {
                    ListViewItem objItem = this.lvWorkplaceList.Items.Add(workplace.WorkplaceId.ToString()); 
                    objItem.SubItems.Add(iCount.ToString()); // Line Number
                    objItem.SubItems.Add(workplace.WorkplaceCode); 
                    objItem.SubItems.Add(workplace.WorkplaceInitial); 

                    iCount++;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lvWorkplaceList.SelectedItem != null)
            {
                if (Common.Utility.IsGUID(lvWorkplaceList.SelectedItem.Text))
                {
                    this.IsCompleted = true;
                    this.WorkplaceID = new Guid(lvWorkplaceList.SelectedItem.Text);
                    this.Close();
                }
            }
        }
    }
}