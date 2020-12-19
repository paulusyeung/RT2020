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
using System.Data.Entity;
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
            using (var ctx = new EF6.RT2020Entities())
            {
                List<EF6.Workplace> list = null;

                list = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();

                string whereClause = string.Empty;
                if (!txtLoc.Text.Trim().Equals("*"))
                {
                    //whereClause = " WorkplaceCode = '" + txtLoc.Text.Trim() + "'";
                    list = ctx.Workplace
                        .Where(x => x.WorkplaceCode == txtLoc.Text.Trim())
                        .OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                }

                if (!txtInitial.Text.Trim().Equals("*"))
                {
                    if (whereClause == string.Empty)
                    {
                        //whereClause = " WorkplaceInitial = '" + txtInitial.Text.Trim() + "'";
                        list = ctx.Workplace
                            .Where(x => x.WorkplaceInitial == txtInitial.Text.Trim())
                            .OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                    }
                    else
                    {
                        //whereClause = whereClause + " AND WorkplaceInitial = '" + txtInitial.Text.Trim() + "'";
                        list = ctx.Workplace
                        .Where(x => x.WorkplaceCode == txtLoc.Text.Trim() && x.WorkplaceInitial == txtInitial.Text.Trim())
                        .OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                    }
                }

                if (txtLoc.Text.Trim().Equals("*") && txtInitial.Text.Trim().Equals("*"))
                {
                    list = ctx.Workplace.OrderBy(x => x.WorkplaceCode).AsNoTracking().ToList();
                }

                if (list.Count > 0)
                {
                    int iCount = 1;
                    foreach (var workplace in list)
                    {
                        ListViewItem objItem = this.lvWorkplaceList.Items.Add(workplace.WorkplaceId.ToString());
                        objItem.SubItems.Add(iCount.ToString()); // Line Number
                        objItem.SubItems.Add(workplace.WorkplaceCode);
                        objItem.SubItems.Add(workplace.WorkplaceInitial);

                        iCount++;
                    }
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
                Guid id = Guid.Empty;
                if (Guid.TryParse(lvWorkplaceList.SelectedItem.Text, out id))
                {
                    this.IsCompleted = true;
                    this.WorkplaceID = id;
                    this.Close();
                }
            }
        }
    }
}