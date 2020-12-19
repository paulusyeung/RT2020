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
using RT2020.Helper;

#endregion

namespace RT2020.Member.Reports
{
    public partial class RptVipVendorSpendingForm : Form
    {
        public RptVipVendorSpendingForm()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            FillList();
            SetCaptions();
        }
        private void SetCaptions()
        {
            chkClass1.Text = RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1");
            this.Text = "Top Vip Spending by " + RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1");
        }

        #region Fill ListView
        private void FillList()
        {
            FillSexList();
            FillSalutationList();
            FillStatusList();
            FillShopList();
            FillClass1List();
            FillMemberNumber();
        }

        private void FillMemberNumber()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var list = ctx.Member.OrderBy(x => x.MemberNumber).AsNoTracking().ToList();
                if (list.Count > 0)
                {
                    foreach (var oMember in list)
                    {
                        string item = oMember.MemberNumber;
                        cmbFrom.Items.Add(item);
                        cmbTo.Items.Add(item);
                    }
                    cmbFrom.SelectedIndex = 0;
                    cmbTo.SelectedIndex = list.Count - 1;
                }
            }
        }

        private void FillSexList()
        {
            string[] Sexs = new string[] { "Male", "FeMale" };
            foreach (string Sex in Sexs)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = Sex;
                listItem.SubItems.Add(Sex.Substring(0, 1));
                listItem.SubItems.Add(string.Empty);
                lvSexList.Items.Add(listItem);
            }
        }

        private void FillSalutationList()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                var SalList = ctx.Salutation.OrderBy(x => x.SalutationName).AsNoTracking().ToList();
                foreach (var Sal in SalList)
                {
                    ListViewItem listItem = this.lvSalutationList.Items.Add(Sal.SalutationId.ToString());
                    listItem.SubItems.Add(Sal.SalutationName);
                    listItem.SubItems.Add(string.Empty);
                }
            }
        }

        private void FillStatusList()
        {
            string[] Status = new string[] { "Active", "Inactive" };
            for (int i = 0; i < Status.Length; i++)
            {
                ListViewItem listItem = new ListViewItem();
                listItem.Text = i.ToString();
                listItem.SubItems.Add(Status[i]);
                listItem.SubItems.Add(string.Empty);
                this.lvVipStatus.Items.Add(listItem);
            }
        }

        private void FillShopList()
        {
            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var list = ctx.Workplace
                    .SqlQuery("Select * from Workplace Where NatureId IN (SELECT NatureId FROM WorkplaceNature WHERE NatureCode='3') Order By WorkplaceCode")
                    .AsNoTracking()
                    .ToList();

                //string sql = "NatureId  IN (SELECT NatureId FROM WorkplaceNature WHERE NatureCode='3')";
                //WorkplaceCollection wpList = RT2020.DAL.Workplace.LoadCollection(sql, new string[] { "WorkplaceCode" }, true);
                foreach (var wp in list)
                {
                    ListViewItem listItem = this.lvShopList.Items.Add(wp.WorkplaceId.ToString());
                    listItem.SubItems.Add(wp.WorkplaceCode);
                    listItem.SubItems.Add(string.Empty);
                }
            }
        }

        private void FillClass1List()
        {
            using (var ctx = new RT2020.EF6.RT2020Entities())
            {
                var Class1List = ctx.ProductClass1.OrderBy(x => x.Class1Code).AsNoTracking().ToList();
                foreach (var Class1 in Class1List)
                {
                    ListViewItem listItem = lvVendorList.Items.Add(Class1.Class1Id.ToString());
                    if (Class1.Class1Code.Length >= 3)
                    {
                        listItem.SubItems.Add(Class1.Class1Code.Substring(0, 3));
                    }
                    else if (Class1.Class1Code.Length > 0 && Class1.Class1Code.Length < 3)
                    {
                        listItem.SubItems.Add(Class1.Class1Code);
                    }

                    listItem.SubItems.Add(string.Empty);
                }
            }
        }

        #endregion

        #region Sex List View Event
        private void lvSexList_Click(object sender, EventArgs e)
        {
            if (this.lvSexList.Items != null && this.lvSexList.SelectedIndex >= 0)
            {
                int index = this.lvSexList.SelectedIndex;
                this.lvSexList.Items[index].SubItems[2].Text = (this.lvSexList.Items[index].SubItems[2].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btnMarkAllSex_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvSexList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvSexList.Items[i];

                if (oItem.SubItems[2].Text == string.Empty)
                {
                    oItem.SubItems[2].Text = "*";
                }
            }
        }

        private void btnMarkNoneSex_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvSexList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvSexList.Items[i];

                oItem.SubItems[2].Text = string.Empty;
            }
        }

        #endregion

        #region Salutation List View Event
        private void lvSalutationList_Click(object sender, EventArgs e)
        {
            if (this.lvSalutationList.Items != null && this.lvSalutationList.SelectedIndex >= 0)
            {
                int index = this.lvSalutationList.SelectedIndex;
                this.lvSalutationList.Items[index].SubItems[2].Text = (this.lvSalutationList.Items[index].SubItems[2].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btnMarkAllSalutation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvSalutationList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvSalutationList.Items[i];
                if (oItem.SubItems[2].Text == string.Empty)
                {
                    oItem.SubItems[2].Text = "*";
                }
            }
        }

        private void btnMarkNoneSalutation_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvSalutationList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvSalutationList.Items[i];
                oItem.SubItems[2].Text = string.Empty;
            }
        }
        #endregion

        #region Status List View Event
        private void lvVipStatus_Click(object sender, EventArgs e)
        {
            if (this.lvVipStatus.Items != null && this.lvVipStatus.SelectedIndex >= 0)
            {
                int index = this.lvVipStatus.SelectedIndex;
                this.lvVipStatus.Items[index].SubItems[2].Text = (this.lvVipStatus.Items[index].SubItems[2].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btnMarkAllVipStatus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvVipStatus.Items.Count; i++)
            {
                ListViewItem oItem = this.lvVipStatus.Items[i];
                if (oItem.SubItems[2].Text == string.Empty)
                {
                    oItem.SubItems[2].Text = "*";
                }
            }
        }

        private void btnMarkNoneVipStatus_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvVipStatus.Items.Count; i++)
            {
                ListViewItem oItem = this.lvVipStatus.Items[i];
                oItem.SubItems[2].Text = string.Empty;
            }
        }
        #endregion

        #region Shop List View Event
        private void lvShopList_Click(object sender, EventArgs e)
        {
            if (this.lvShopList.Items != null && this.lvShopList.SelectedIndex >= 0)
            {
                int index = this.lvShopList.SelectedIndex;
                this.lvShopList.Items[index].SubItems[2].Text = (this.lvShopList.Items[index].SubItems[2].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btnMarkAllShop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvShopList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvShopList.Items[i];
                if (oItem.SubItems[2].Text == string.Empty)
                {
                    oItem.SubItems[2].Text = "*";
                }
            }
        }
        private void btnMarkNoneShop_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvShopList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvShopList.Items[i];
                oItem.SubItems[2].Text = string.Empty;
            }
        }
        #endregion

        #region Class1 List View Event
        private void lvVendorList_Click(object sender, EventArgs e)
        {
            if (this.lvVendorList.Items != null && this.lvVendorList.SelectedIndex >= 0)
            {
                int index = this.lvVendorList.SelectedIndex;
                this.lvVendorList.Items[index].SubItems[2].Text = (this.lvVendorList.Items[index].SubItems[2].Text.Length == 0) ? "*" : string.Empty;
            }
        }

        private void btnMarkAllVendor_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvVendorList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvVendorList.Items[i];
                if (oItem.SubItems[2].Text == string.Empty)
                {
                    oItem.SubItems[2].Text = "*";
                }
            }
        }

        private void btnMarkNoneVendor_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvVendorList.Items.Count; i++)
            {
                ListViewItem oItem = this.lvVendorList.Items[i];
                oItem.SubItems[2].Text = string.Empty;
            }
        }
        #endregion

        #region CheckBox Event
        private void chkSex_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSex.Checked)
            {
                btnMarkAllSex.Enabled = true;
                btnMarkNoneSex.Enabled = true;
            }
            else
            {
                btnMarkAllSex.Enabled = false;
                btnMarkNoneSex.Enabled = false;
            }
        }
        private void chkSalutation_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalutation.Checked)
            {
                btnMarkAllSalutation.Enabled = true;
                btnMarkNoneSalutation.Enabled = true;
            }
            else
            {
                btnMarkAllSalutation.Enabled = false;
                btnMarkNoneSalutation.Enabled = false;
            }
        }

        private void chkVipStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVipStatus.Checked)
            {
                btnMarkAllVipStatus.Enabled = true;
                btnMarkNoneVipStatus.Enabled = true;
            }
            else
            {
                btnMarkAllVipStatus.Enabled = false;
                btnMarkNoneVipStatus.Enabled = false;
            }
        }

        private void chkShop_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShop.Checked)
            {
                btnMarkAllShop.Enabled = true;
                btnMarkNoneShop.Enabled = true;
            }
            else
            {
                btnMarkAllShop.Enabled = false;
                btnMarkNoneShop.Enabled = false;
            }
        }

        private void chkVendor_CheckedChanged(object sender, EventArgs e)
        {
            if (chkClass1.Checked)
            {
                btnMarkAllVendor.Enabled = true;
                btnMarkNoneVendor.Enabled = true;
            }
            else
            {
                btnMarkAllVendor.Enabled = false;
                btnMarkNoneVendor.Enabled = false;
            }
        }

        private void chkVipNumberPattern_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVipNumberPattern.Checked)
            {
                btnAddPattern.Enabled = true;
                btnDeletePattern.Enabled = true;
                btnClearPattern.Enabled = true;
            }
            else
            {
                btnAddPattern.Enabled = false;
                btnDeletePattern.Enabled = false;
                btnClearPattern.Enabled = false;
            }

        }

        private void chkVipRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkVipRange.Checked)
            {
                cmbFrom.Enabled = true;
                cmbTo.Enabled = true;
            }
            else
            {
                cmbFrom.Enabled = false;
                cmbTo.Enabled = false;
            }
        }

        private void chkTopVipSpending_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTopVipSpending.Checked)
            {
                txtTopVipSpendingNumber.Enabled = true;
            }
            else
            {
                txtTopVipSpendingNumber.Enabled = false;
            }
        }

        private void chkSalesAmountOver_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSalesAmountOver.Checked)
            {
                txtSalesAmountOver.Enabled = true;
            }
            else
            {
                txtSalesAmountOver.Enabled = false;
            }
        }

        private void chkTrnDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTrnDate.Checked)
            {
                dtpTrnFromTime.Enabled = true;
                dtpTrnToTime.Enabled = true;
            }
            else
            {
                dtpTrnFromTime.Enabled = false;
                dtpTrnToTime.Enabled = false;
            }
        }

        private void chkBirthday_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBirthday.Checked)
            {
                dtpFromBirthday.Enabled = true;
                dtpToBirthday.Enabled = true;
            }
            else
            {
                dtpFromBirthday.Enabled = false;
                dtpToBirthday.Enabled = false;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                txtNormalItemDiscountOffer.Enabled = true;
            }
            else
            {
                txtNormalItemDiscountOffer.Enabled = false;
            }
        }

        #endregion

        private string SelectedList(ListView listview, int index)
        {
            StringBuilder selectList = new StringBuilder();
            for (int i = 0; i < listview.Items.Count; i++)
            {
                ListViewItem oItem = listview.Items[i];

                if (oItem.SubItems[index].Text == "*")
                {
                    selectList.Append("'" + oItem.SubItems[index - 1].Text + "'" + ",");
                }
            }
            return selectList.ToString().Trim(',');
        }

        private string SelectedSatusList()
        {
            StringBuilder selectList = new StringBuilder();
            for (int i = 0; i < this.lvVipStatus.Items.Count; i++)
            {
                ListViewItem oItem = lvVipStatus.Items[i];

                if (oItem.SubItems[2].Text == "*")
                {
                    selectList.Append("'" + oItem.SubItems[0].Text + "'" + ",");
                }
            }
            return selectList.ToString().Trim(',');
        }

        private string SelectedPatternList()
        {
            StringBuilder selectList = new StringBuilder();
            if (this.lvVipNumberPatternList.Items.Count > 0)
            {
                for (int i = 0; i < this.lvVipNumberPatternList.Items.Count; i++)
                {
                    ListViewItem oItem = lvVipNumberPatternList.Items[i];
                    selectList.Append(" VipNumber Like " + "'" + oItem.SubItems[1].Text.Replace('*', '%') + "'" + "AND LEN(TxDate)<>0 OR");
                }
            }

            return selectList.ToString().Trim(new char[] { 'R', 'O' });
        }

        #region Validate Selections
        private bool IsSelValid()
        {
            bool result = true;

            if (DateTime.Compare(dtpTrnFromTime.Value, dtpTrnToTime.Value) > 0)    // dtpTrnFromTime > dtpTrnToTime
            {
                result = false;
                MessageBox.Show("Range Error: Trn Date", "Message");
            }
            else if (DateTime.Compare(dtpFromBirthday.Value, dtpToBirthday.Value) > 0)    // dtpFromBirthday >  dtpToBirthday
            {
                result = false;
                MessageBox.Show("Range Error: Tx Date", "Message");
            }

            return result;
        }
        #endregion

        #region Bind Data to Report
        private DataTable BindData()
        {
            string fromMonth = dtpFromBirthday.Value.Month.ToString();
            string toMonth = dtpToBirthday.Value.Month.ToString();
            string sexList = SelectedList(this.lvSexList, 2);
            string salutationList = SelectedList(this.lvSalutationList, 2);
            string class1List = SelectedList(this.lvVendorList, 2);
            string statusList = SelectedSatusList();
            string shopList = SelectedList(this.lvShopList, 2);

            string whereClause = @"
WHERE TxDate BETWEEN '" + this.dtpTrnFromTime.Value.ToString("yyyy-MM-dd") + "' AND '" + this.dtpTrnToTime.Value.ToString("yyyy-MM-dd") + @"'
AND [Amount Paid] >= " + decimal.Parse(txtSalesAmountOver.Text.Trim());

            if (chkClass1.Checked && class1List.Length > 0)
            {
                whereClause += " AND Brand In " + "(" + class1List + ")";
            }
            if (chkBirthday.Checked)
            {
                whereClause += " AND DatePart(MM, DateOfBirth) >= " + fromMonth + " AND  DatePart(MM, DateOfBirth) <= " + toMonth;
            }
            if (chkVipRange.Checked)
            {
                whereClause += " AND VipNumber BETWEEN '" + this.cmbFrom.Text.Trim() + "' AND '" + this.cmbTo.Text.Trim() + "'";
            }
            if (sexList.Length > 0 && chkSex.Checked)
            {
                whereClause += " AND LEFT(Sex,1) In " + "(" + sexList + ")";
            }
            if (salutationList.Length > 0 && chkSalutation.Checked)
            {
                whereClause += " AND Salute In " + "(" + salutationList + ")";
            }
            if (statusList.Length > 0 && chkVipStatus.Checked)
            {
                whereClause += " AND [CARD_ACTIVE] In " + "(" + statusList + ")";
            }
            if (shopList.Length > 0 && chkShop.Checked)
            {
                whereClause += " AND SHOP In " + "(" + shopList + ")";
            }
            if (checkBox1.Checked)
            {
                whereClause += " AND Discount>= " + decimal.Parse(txtNormalItemDiscountOffer.Text.Trim());
            }
            if (SelectedPatternList().Length > 0 && chkVipNumberPattern.Checked)
            {
                whereClause += " OR " + SelectedPatternList();
            }

            string sql = @"
SELECT VipRow.Salute,Vip.* FROM 
(
    SELECT VipNumber,LastName,FirstName,NickName,TxDate,Amount
    FROM vwVIP_TopSpending " + whereClause +@"
) AS Vip
INNER JOIN
(
    SELECT ROW_NUMBER() OVER(ORDER BY SUM(Amount) DESC) AS Salute,VipNumber 
    FROM vwVIP_TopSpending " + whereClause + @" GROUP BY VipNumber
) AS VipRow
ON Vip.VipNumber=VipRow.VipNumber WHERE VipRow.Salute <= " + int.Parse(txtTopVipSpendingNumber.Text.Trim()) + @"
ORDER BY VipRow.Salute
";

            System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        private string SelectedSatusList(ListView listView, int p)
        {
            throw new NotImplementedException();
        }
        #endregion

        private void btnAddPattern_Click(object sender, EventArgs e)
        {
            int iCount = 0;
            if (this.txtPattern.Text != null)
            {
                string Pattern = txtPattern.Text;
                iCount = lvVipNumberPatternList.Items.Count + 1;
                ListViewItem OItem = new ListViewItem();
                OItem.SubItems.Add(iCount.ToString());
                OItem.SubItems.Add(Pattern);
                lvVipNumberPatternList.Items.Add(OItem);
            }
            txtPattern.Text = null;
        }

        private void btnDeletePattern_Click(object sender, EventArgs e)
        {
            if (txtRow.Text != null)
            {
                string RowNumber = txtRow.Text;
                for (int i = 0; i < lvVipNumberPatternList.Items.Count; i++)
                {
                    ListViewItem oItem = lvVipNumberPatternList.Items[i];
                    if (oItem.SubItems[0].Text == RowNumber)
                    {
                        oItem.Remove();
                    }
                }
            }
        }

        private void btnClearPattern_Click(object sender, EventArgs e)
        {
            this.lvVipNumberPatternList.Items.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPriview_Click(object sender, EventArgs e)
        {
            if (IsSelValid())
            {
                string[,] param = {
                {"FromTxDate",this.dtpTrnFromTime.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"ToTxDate",this.dtpTrnToTime.Value.ToString(RT2020.SystemInfo.Settings.GetDateFormat())},
                {"TOPNumber",this.txtTopVipSpendingNumber.Text.Trim()},
                {"SalesAmount",this.txtSalesAmountOver.Text.Trim()},
                {"BRAND",SelectedList(this.lvVendorList,2)},
                {"PrintedOn",DateTime.Now.ToString(RT2020.SystemInfo.Settings.GetDateTimeFormat())},
                {"CompanyName",RT2020.SystemInfo.CurrentInfo.Default.CompanyName}
                };

                RT2020.Controls.Reporting.Viewer view = new RT2020.Controls.Reporting.Viewer();

                view.Datasource = BindData();
                view.ReportDatasourceName = "RT2020_Controls_Reporting_DataSource_vwVIP_TopSpending";
                view.ReportName = "RT2020.Member.Reports.VipVendorSpendingFormRdl.rdlc";
                view.Parameters = param;

                if (SelectedList(this.lvVendorList, 2).Length > 0)
                {
                    view.Show();
                }
                else
                {
                    MessageBox.Show(String.Format("Must select at least one {0}!", RT2020.SystemInfo.Settings.GetSystemLabelByKey("CLASS1")), "Please Select");
                    view.Close();
                }
            }
        }

        private void txtTopVipSpendingNumber_TextChanged(object sender, EventArgs e)
        {
            int topNumber = 0;
            bool top = int.TryParse(txtTopVipSpendingNumber.Text.Trim(), out topNumber);
            if (!top || topNumber <= 0)
            {
                MessageBox.Show("Must enter the number greater than 0!", "Please Re-enter");
            }
        }
    }
}