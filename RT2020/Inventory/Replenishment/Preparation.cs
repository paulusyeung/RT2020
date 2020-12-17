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
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Data.Entity;

#endregion

namespace RT2020.Inventory.Replenishment
{
    public partial class Preparation : Form
    {
        DataTable preparedDataList;

        public Preparation()
        {
            InitializeComponent();
            FillList();
        }

        #region Fill the List(ComboBox & ListView)
        private void FillList()
        {
            FillFromList();
            FillToList();
            FillListView();
        }

        private void FillFromList()
        {
            string sql = "NatureId = '" + ModelEx.WorkplaceNatureEx.GetNatureIdeByCode("2").ToString() + "'";

            ModelEx.WorkplaceEx.LoadCombo(ref cboFromWorkplace, "WorkplaceCode", false, false, string.Empty, sql);
        }

        private void FillToList()
        {
            string sql = "NatureId = '" + ModelEx.WorkplaceNatureEx.GetNatureIdeByCode("2").ToString() + "'";

            ModelEx.WorkplaceEx.LoadCombo(ref cboToWorkplace, "WorkplaceCode", false, false, string.Empty, sql);
            cboToWorkplace.SelectedIndex = cboToWorkplace.Items.Count - 1;
        }

        private void FillListView()
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                int iCount = 1;

                var natureId = ModelEx.WorkplaceNatureEx.GetNatureIdeByCode("3");   // Workplace Nature Code (2) presents Shop
                var list = ctx.Workplace
                    .Where(x => x.NatureId == natureId)
                    .OrderBy(x => x.WorkplaceCode)
                    .AsNoTracking()
                    .ToList();
                foreach (var wp in list)
                {
                    var listItem = lvToWorkplaceList.Items.Add(wp.WorkplaceId.ToString());
                    listItem.SubItems.Add(iCount.ToString());
                    listItem.SubItems.Add(wp.WorkplaceCode);
                    listItem.SubItems.Add(wp.WorkplaceName);
                    listItem.SubItems.Add(string.Empty);

                    iCount++;
                }
            }
        }

        #endregion

        #region Preparation
        private bool Verify()
        {
            bool isVerified = true;
            if (cboFromWorkplace.Text.Length == 0)
            {
                errorProvider.SetError(cboFromWorkplace, "Must select a location!");
                isVerified = false;
            }
            else
            {
                errorProvider.SetError(cboFromWorkplace, string.Empty);
            }

            if (cboToWorkplace.Text.Length == 0 && cboToWorkplace.Visible)
            {
                errorProvider.SetError(cboToWorkplace, "Must select a location!");
                isVerified = false;
            }
            else
            {
                errorProvider.SetError(cboToWorkplace, string.Empty);
            }

            if (dtpEnd.Value.CompareTo(dtpStart.Value) < 0)
            {
                errorProvider.SetError(dtpEnd, "'To Date' must not earlier than 'From Date'");
                isVerified = false;
            }
            else
            {
                errorProvider.SetError(dtpEnd, string.Empty);
            }

            if (rbtnWH2Shop.Checked)
            {
                if (!chkNetSales_Retail.Checked && !chkNetSales_Wholesale.Checked && !chkTxferOut.Checked)
                {
                    errorProvider.SetError(chkNetSales_Retail, "At Least ONE Transaction Type must be selected!");
                    errorProvider.SetError(chkNetSales_Wholesale, "At Least ONE Transaction Type must be selected!");
                    errorProvider.SetError(chkTxferOut, "At Least ONE Transaction Type must be selected!");
                    isVerified = false;
                }
                else
                {
                    errorProvider.SetError(chkNetSales_Retail, string.Empty);
                    errorProvider.SetError(chkNetSales_Wholesale, string.Empty);
                    errorProvider.SetError(chkTxferOut, string.Empty);
                }

                if (!IsMarkedUp())
                {
                    errorProvider.SetError(lvToWorkplaceList, "Please select one location at least!");
                    isVerified = false;
                }
                else
                {
                    errorProvider.SetError(lvToWorkplaceList, string.Empty);
                }
            }

            return isVerified;
        }

        private bool IsMarkedUp()
        {
            bool isMarked = false;
            int iCount = 0;
            foreach (ListViewItem listItem in lvToWorkplaceList.Items)
            {
                if (listItem.Checked)
                {
                    iCount++;
                }
            }
            if (iCount > 0)
            {
                isMarked = true;
            }
            return isMarked;
        }

        #region Prepare

        private string GetTxType()
        {
            StringBuilder query = new StringBuilder();

            if (chkNetSales_Retail.Checked)
            {
                query.Append("'CAS', 'CRT', 'VOD'");
            }

            if (chkNetSales_Wholesale.Checked)
            {
                if (query.Length > 0)
                {
                    query.Append(", ");
                }

                query.Append("'SAL', 'SRT' ");
            }

            if (chkTxferOut.Checked)
            {
                if (query.Length > 0)
                {
                    query.Append(", ");
                }

                query.Append("'TXI', 'TXO'");
            }

            if (chkUnPost.Checked)
            {
                if (query.Length > 0)
                {
                    query.Append(", ");
                }

                query.Append("'TXI', 'TRI'");
            }

            return query.ToString();
        }

        private string BuildSqlQueryString()
        {
            StringBuilder query = new StringBuilder();

            query.Append(" SELECT DetailsId, HeaderId, TxType, TxNumber, TxDate, ProductId, Qty, STKCODE, APPENDIX1, APPENDIX2, APPENDIX3, OffDisplayItem, Workplace ");
            query.Append(" FROM  vwPrepareReplenishment ");
            query.Append(" WHERE ");
            query.Append(" TxDate >= '").Append(dtpStart.Value.ToString("yyyy-MM-dd 00:00:00")).Append("' ");
            query.Append(" AND ");
            query.Append(" TxDate <= '").Append(dtpEnd.Value.AddDays(1).ToString("yyyy-MM-dd 00:00:00")).Append("' ");

            if (chkIgnoreOffDisplayItem.Checked)
            {
                query.Append(" AND ");
                query.Append(" OffDisplayItem = 0 ");
            }

            if (rbtnWH2Shop.Checked)
            {
                query.AppendFormat(" AND TxType IN ({0}) ", GetTxType());
                query.Append(" AND ");
                query.Append(" (Replenishment = 0 OR Replenishment IS NULL) ");

                string selectedShopList = GetSelectedShopList();
                if (selectedShopList.Trim().Length > 0)
                {
                    query.Append(" AND ");
                    query.Append(" Workplace IN (").Append(selectedShopList).Append(")");
                }
            }
            else if (rbtnWH2WH.Checked)
            {
                query.Append(" AND ");
                query.Append(" Replenishment = 1 ");
            }

            return query.ToString();
        }

        private string GetSelectedShopList()
        {
            StringBuilder selectedShopList = new StringBuilder();

            foreach (ListViewItem lvItem in lvToWorkplaceList.Items)
            {
                if (lvItem.Checked)
                {
                    if (selectedShopList.Length > 0)
                    {
                        selectedShopList.Append(", ");
                    }

                    selectedShopList.Append("'").Append(lvItem.SubItems[2].Text).Append("'");
                }
            }

            return selectedShopList.ToString();
        }

        private void PrepareData()
        {
            string sql = BuildSqlQueryString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            using (DataSet ds = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                preparedDataList = ds.Tables[0];
            }
        }

        #endregion

        private int SaveRec()
        {
            int iCount = 0;
            string sRemarks = dtpStart.Value.ToString("ddMMMyyyy") + "-" + dtpEnd.Value.ToString("ddMMMyyyy") + " ";
            if (chkNetSales_Retail.Checked) sRemarks = sRemarks + "R/";
            if (chkNetSales_Wholesale.Checked) sRemarks = sRemarks + "W/";
            if (chkTxferOut.Checked) sRemarks = sRemarks + "TO/";
            if (chkUnPost.Checked) sRemarks = sRemarks + "UP";

            if (sRemarks.LastIndexOf('/') > 0)
            {
                if (sRemarks.Remove(0, sRemarks.LastIndexOf('/')).Length == 1)
                    sRemarks = sRemarks.Remove(sRemarks.LastIndexOf('/'));
            }

            using (var ctx = new EF6.RT2020Entities())
            {
                using (var scope = ctx.Database.BeginTransaction())
                {
                    if (rbtnWH2WH.Checked)
                    {
                        #region single item
                        DateTime txDate = DateTime.Now;
                        string txNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.RPL);
                        #region Guid headerId = CreateRPLHeader(txNumber, txDate, cboFromWorkplace.Text, cboToWorkplace.Text, sRemarks);
                        string fromLocation = cboFromWorkplace.Text, toLocation = cboToWorkplace.Text;

                        var oHeader = new EF6.InvtBatchRPL_Header();
                        oHeader.HeaderId = Guid.Empty;
                        oHeader.TxNumber = txNumber;
                        oHeader.TxDate = txDate;
                        oHeader.FromLocation = fromLocation;
                        oHeader.ToLocation = toLocation;
                        oHeader.StaffId = Common.Config.CurrentUserId;
                        oHeader.Remarks = sRemarks;

                        oHeader.CreatedBy = Common.Config.CurrentUserId;
                        oHeader.CreatedOn = DateTime.Now;
                        oHeader.ModifiedBy = Common.Config.CurrentUserId;
                        oHeader.ModifiedOn = DateTime.Now;
                        oHeader.Status = Convert.ToInt32(Common.Enums.Status.Draft.ToString("d"));

                        ctx.InvtBatchRPL_Header.Add(oHeader);
                        ctx.SaveChanges();

                        Guid headerId = oHeader.HeaderId;
                        #endregion

                        #region CreateRPLDetails(headerId, txNumber, cboToWorkplace.Text);
                        string workplace = cboToWorkplace.Text;

                        if (preparedDataList != null)
                        {
                            DataTable oTable;
                            int ln = 1;

                            if (rbtnWH2Shop.Checked)
                            {
                                oTable = ProcessPreparedData(workplace);
                            }
                            else
                            {
                                oTable = preparedDataList;
                            }

                            foreach (DataRow preparedData in oTable.Rows)
                            {
                                decimal rplQty = (decimal)preparedData["Qty"];
                                Guid productId = (Guid)preparedData["ProductId"];

                                if (rplQty > 0 && productId != Guid.Empty)
                                {
                                    //string sql = "ProductId = '" + productId.ToString() + "' AND HeaderId = '" + headerId.ToString() + "'";
                                    var oDetail = ctx.InvtBatchRPL_Details.Where(x => x.ProductId == productId && x.HeaderId == headerId).FirstOrDefault();
                                    if (oDetail == null)
                                    {
                                        oDetail = new EF6.InvtBatchRPL_Details();
                                        oDetail.DetailsId = Guid.NewGuid();
                                        oDetail.HeaderId = headerId;
                                        oDetail.TxNumber = txNumber;
                                        oDetail.LineNumber = ln++;
                                        oDetail.ProductId = productId;

                                        ctx.InvtBatchRPL_Details.Add(oDetail);
                                    }
                                    oDetail.QtyRequested += rplQty;
                                    oDetail.QtyIssued += rplQty;

                                    ctx.SaveChanges();

                                    #region UpdateReplenishment(productId);
                                    DataRow[] rowList = preparedDataList.Select("ProductId = '" + productId.ToString() + "'");
                                    for (int i = 0; i < rowList.Length; i++)
                                    {
                                        Guid detailsId = Guid.Empty;
                                        if (Guid.TryParse(rowList[i]["DetailsId"].ToString(), out detailsId))
                                        {
                                            string txType = rowList[i]["TxType"].ToString();
                                            //Guid detailsId = (Guid)rowList[i]["DetailsId"];

                                            // POS
                                            if (txType == "CAS" || txType == "CRT" || txType == "VOD")
                                            {
                                                var oCurDetail = ctx.PosLedgerDetails.Find(detailsId);
                                                if (oCurDetail != null)
                                                {
                                                    oCurDetail.Replenishment = rbtnWH2Shop.Checked ? 1 : 2;
                                                    ctx.SaveChanges();
                                                }
                                                else
                                                {
                                                    var oFepDetail = ctx.FepBatchDetail.Find(detailsId);
                                                    if (oFepDetail != null)
                                                    {
                                                        oFepDetail.REPLENISH = (short)(rbtnWH2Shop.Checked ? 1 : 2);
                                                        ctx.SaveChanges();
                                                    }
                                                }
                                            }
                                            else if (txType == "TXO" || txType == "TRO")  // INVT
                                            {
                                                var oCurDetail = ctx.InvtLedgerDetails.Find(detailsId);
                                                if (oCurDetail != null)
                                                {
                                                    oCurDetail.Replenish = rbtnWH2Shop.Checked ? 1 : 2;
                                                    ctx.SaveChanges();
                                                }
                                            }
                                            else if (txType == "TXI" || txType == "TRI") // Un-Posted FEP
                                            {
                                                var oCurDetail = ctx.FepBatchDetail.Find(detailsId);
                                                if (oCurDetail != null)
                                                {
                                                    oCurDetail.REPLENISH = (short)(rbtnWH2Shop.Checked ? 1 : 2);
                                                    ctx.SaveChanges();
                                                }
                                            }
                                            else if (txType == "SAL" || txType == "SRT") // Wholesale
                                            {
                                            }
                                        }
                                    }
                                    #endregion
                                }
                            }
                        }
                        #endregion

                        iCount++;
                        #endregion
                    }
                    else
                    {
                        #region multiple items
                        foreach (ListViewItem listItem in lvToWorkplaceList.Items)
                        {
                            if (listItem.Checked)
                            {
                                DateTime txDate = DateTime.Now;
                                string txNumber = RT2020.SystemInfo.Settings.QueuingTxNumber(Common.Enums.TxType.RPL);
                                #region Guid headerId = CreateRPLHeader(txNumber, txDate, cboFromWorkplace.Text, listItem.SubItems[2].Text, sRemarks);
                                string fromLocation = cboFromWorkplace.Text, toLocation = cboToWorkplace.Text;

                                var oHeader = new EF6.InvtBatchRPL_Header();
                                oHeader.HeaderId = Guid.Empty;
                                oHeader.TxNumber = txNumber;
                                oHeader.TxDate = txDate;
                                oHeader.FromLocation = fromLocation;
                                oHeader.ToLocation = toLocation;
                                oHeader.StaffId = Common.Config.CurrentUserId;
                                oHeader.Remarks = sRemarks;

                                oHeader.CreatedBy = Common.Config.CurrentUserId;
                                oHeader.CreatedOn = DateTime.Now;
                                oHeader.ModifiedBy = Common.Config.CurrentUserId;
                                oHeader.ModifiedOn = DateTime.Now;
                                oHeader.Status = Convert.ToInt32(Common.Enums.Status.Draft.ToString("d"));

                                ctx.InvtBatchRPL_Header.Add(oHeader);
                                ctx.SaveChanges();

                                Guid headerId = oHeader.HeaderId;
                                #endregion

                                #region CreateRPLDetails(headerId, txNumber, listItem.SubItems[2].Text);
                                string workplace = listItem.SubItems[2].Text;

                                if (preparedDataList != null)
                                {
                                    DataTable oTable;
                                    int ln = 1;

                                    if (rbtnWH2Shop.Checked)
                                    {
                                        oTable = ProcessPreparedData(workplace);
                                    }
                                    else
                                    {
                                        oTable = preparedDataList;
                                    }

                                    foreach (DataRow preparedData in oTable.Rows)
                                    {
                                        decimal rplQty = (decimal)preparedData["Qty"];
                                        Guid productId = (Guid)preparedData["ProductId"];

                                        if (rplQty > 0 && productId != Guid.Empty)
                                        {
                                            //string sql = "ProductId = '" + productId.ToString() + "' AND HeaderId = '" + headerId.ToString() + "'";
                                            var oDetail = ctx.InvtBatchRPL_Details.Where(x => x.ProductId == productId && x.HeaderId == headerId).FirstOrDefault();
                                            if (oDetail == null)
                                            {
                                                oDetail = new EF6.InvtBatchRPL_Details();
                                                oDetail.DetailsId = Guid.NewGuid();
                                                oDetail.HeaderId = headerId;
                                                oDetail.TxNumber = txNumber;
                                                oDetail.LineNumber = ln++;
                                                oDetail.ProductId = productId;

                                                ctx.InvtBatchRPL_Details.Add(oDetail);
                                            }
                                            oDetail.QtyRequested += rplQty;
                                            oDetail.QtyIssued += rplQty;

                                            ctx.SaveChanges();

                                            #region UpdateReplenishment(productId);
                                            DataRow[] rowList = preparedDataList.Select("ProductId = '" + productId.ToString() + "'");
                                            for (int i = 0; i < rowList.Length; i++)
                                            {
                                                Guid detailsId = Guid.Empty;
                                                if (Guid.TryParse(rowList[i]["DetailsId"].ToString(), out detailsId))
                                                {
                                                    string txType = rowList[i]["TxType"].ToString();
                                                    //Guid detailsId = (Guid)rowList[i]["DetailsId"];

                                                    // POS
                                                    if (txType == "CAS" || txType == "CRT" || txType == "VOD")
                                                    {
                                                        var oCurDetail = ctx.PosLedgerDetails.Find(detailsId);
                                                        if (oCurDetail != null)
                                                        {
                                                            oCurDetail.Replenishment = rbtnWH2Shop.Checked ? 1 : 2;
                                                            ctx.SaveChanges();
                                                        }
                                                        else
                                                        {
                                                            var oFepDetail = ctx.FepBatchDetail.Find(detailsId);
                                                            if (oFepDetail != null)
                                                            {
                                                                oFepDetail.REPLENISH = (short)(rbtnWH2Shop.Checked ? 1 : 2);
                                                                ctx.SaveChanges();
                                                            }
                                                        }
                                                    }
                                                    else if (txType == "TXO" || txType == "TRO")  // INVT
                                                    {
                                                        var oCurDetail = ctx.InvtLedgerDetails.Find(detailsId);
                                                        if (oCurDetail != null)
                                                        {
                                                            oCurDetail.Replenish = rbtnWH2Shop.Checked ? 1 : 2;
                                                            ctx.SaveChanges();
                                                        }
                                                    }
                                                    else if (txType == "TXI" || txType == "TRI") // Un-Posted FEP
                                                    {
                                                        var oCurDetail = ctx.FepBatchDetail.Find(detailsId);
                                                        if (oCurDetail != null)
                                                        {
                                                            oCurDetail.REPLENISH = (short)(rbtnWH2Shop.Checked ? 1 : 2);
                                                            ctx.SaveChanges();
                                                        }
                                                    }
                                                    else if (txType == "SAL" || txType == "SRT") // Wholesale
                                                    {
                                                    }
                                                }
                                            }
                                            #endregion
                                        }
                                    }
                                }
                                #endregion

                                iCount++;
                            }
                        }
                        #endregion
                    }
                }
            }

            return iCount;
        }
        /**
        private Guid CreateRPLHeader(string txNumber, DateTime txDate, string fromLocation, string toLocation, string remarks)
        {
            InvtBatchRPL_Header oHeader = new InvtBatchRPL_Header();

            oHeader.TxNumber = txNumber;
            oHeader.TxDate = txDate;
            oHeader.FromLocation = fromLocation;
            oHeader.ToLocation = toLocation;
            oHeader.StaffId = Common.Config.CurrentUserId;
            oHeader.Remarks = remarks;

            oHeader.CreatedBy = Common.Config.CurrentUserId;
            oHeader.CreatedOn = DateTime.Now;
            oHeader.ModifiedBy = Common.Config.CurrentUserId;
            oHeader.ModifiedOn = DateTime.Now;
            oHeader.Status = Convert.ToInt32(Common.Enums.Status.Draft.ToString("d"));

            oHeader.Save();

            return oHeader.HeaderId;
        }

        private void CreateRPLDetails(Guid headerId, string txNumber, string workplace)
        {
            if (preparedDataList != null)
            {
                DataTable oTable;
                int iCount = 1;

                if (rbtnWH2Shop.Checked)
                {
                    oTable = ProcessPreparedData(workplace);
                }
                else
                {
                    oTable = preparedDataList;
                }

                foreach (DataRow preparedData in oTable.Rows)
                {
                    decimal rplQty = (decimal)preparedData["Qty"];
                    System.Guid productId = (System.Guid)preparedData["ProductId"];

                    if (rplQty > 0 && productId != System.Guid.Empty)
                    {
                        string sql = "ProductId = '" + productId.ToString() + "' AND HeaderId = '" + headerId.ToString() + "'";
                        InvtBatchRPL_Details oDetail = InvtBatchRPL_Details.LoadWhere(sql);
                        if (oDetail == null)
                        {
                            oDetail = new InvtBatchRPL_Details();

                            oDetail.HeaderId = headerId;
                            oDetail.TxNumber = txNumber;
                            oDetail.LineNumber = iCount++;
                            oDetail.ProductId = productId;
                        }
                        oDetail.QtyRequested += rplQty;
                        oDetail.QtyIssued += rplQty;

                        oDetail.Save();

                        UpdateReplenishment(productId);
                    }
                }
            }
        }
        */
        private DataTable ProcessPreparedData(string workplace)
        {
            DataTable oTable = new DataTable();
            oTable.Columns.Add("ProductId", typeof(Guid));
            oTable.Columns.Add("Qty", typeof(decimal));

            DataRow[] selectedRow = preparedDataList.Select("Workplace = '" + workplace + "'");

            for (int i = 0; i < selectedRow.Length; i++)
            {
                DataRow preparedData = selectedRow[i];

                System.Guid productId = (System.Guid)preparedData["ProductId"];

                DataRow[] row = oTable.Select("ProductId = '" + productId.ToString() + "'");
                if (row.Length > 0)
                {
                    row[0].BeginEdit();

                    decimal qty = (decimal)row[0]["Qty"];

                    switch (preparedData["TxType"].ToString())
                    {
                        case "CAS":
                        case "SAL":
                        case "TXO":
                        case "TRO":
                            qty += Math.Abs((decimal)preparedData["Qty"]);
                            break;
                        case "CRT":
                        case "VOD":
                        case "SRT":
                        case "TXI":
                        case "TRI":
                            qty += Math.Abs((decimal)preparedData["Qty"]) * (-1);
                            break;
                    }

                    row[0]["Qty"] = qty;

                    row[0].AcceptChanges();
                    row[0].EndEdit();
                }
                else
                {
                    DataRow newRow = oTable.NewRow();
                    newRow["ProductId"] = productId;
                    newRow["Qty"] = preparedData["Qty"];

                    oTable.Rows.Add(newRow);
                }
            }

            return oTable;
        }
        /**
        private void UpdateReplenishment(Guid productId)
        {
            using (var ctx = new EF6.RT2020Entities())
            {
                DataRow[] rowList = preparedDataList.Select("ProductId = '" + productId.ToString() + "'");
                for (int i = 0; i < rowList.Length; i++)
                {
                    Guid detailsId = Guid.Empty;
                    if (Guid.TryParse(rowList[i]["DetailsId"].ToString(), out detailsId))
                    {
                        string txType = rowList[i]["TxType"].ToString();
                        //Guid detailsId = (Guid)rowList[i]["DetailsId"];

                        // POS
                        if (txType == "CAS" || txType == "CRT" || txType == "VOD")
                        {
                            var oDetail = ctx.PosLedgerDetails.Find(detailsId);
                            if (oDetail != null)
                            {
                                oDetail.Replenishment = rbtnWH2Shop.Checked ? 1 : 2;
                                ctx.SaveChanges();
                            }
                            else
                            {
                                var oFepDetail = ctx.FepBatchDetail.Find(detailsId);
                                if (oFepDetail != null)
                                {
                                    oFepDetail.REPLENISH = (short)(rbtnWH2Shop.Checked ? 1 : 2);
                                    ctx.SaveChanges();
                                }
                            }
                        }
                        else if (txType == "TXO" || txType == "TRO")  // INVT
                        {
                            var oDetail = ctx.InvtLedgerDetails.Find(detailsId);
                            if (oDetail != null)
                            {
                                oDetail.Replenish = rbtnWH2Shop.Checked ? 1 : 2;
                                ctx.SaveChanges();
                            }
                        }
                        else if (txType == "TXI" || txType == "TRI") // Un-Posted FEP
                        {
                            var oDetail = ctx.FepBatchDetail.Find(detailsId);
                            if (oDetail != null)
                            {
                                oDetail.REPLENISH = (short)(rbtnWH2Shop.Checked ? 1 : 2);
                                ctx.SaveChanges();
                            }
                        }
                        else if (txType == "SAL" || txType == "SRT") // Wholesale
                        {
                        }
                    }
                }
            }
        }
        */

        #endregion

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtns_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnWH2Shop.Checked)
            {
                cboToWorkplace.Visible = false;
                txtSelectedToWorkplace.Visible = false;

                lvToWorkplaceList.Visible = true;
                btnSelectAll.Visible = true;

                gbTxType.Enabled = true;
            }

            if (rbtnWH2WH.Checked)
            {
                cboToWorkplace.Visible = true;
                txtSelectedToWorkplace.Visible = true;

                lvToWorkplaceList.Visible = false;
                btnSelectAll.Visible = false;

                gbTxType.Enabled = false;
            }
        }

        private void btnPrepare_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Prepare Records?", "Preparation Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, new EventHandler(PrepareMessageHandler));
        }

        private void PrepareMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.Yes)
            {
                if (Verify())
                {
                    PrepareData();

                    int result = SaveRec();
                    if (result > 0)
                    {
                        RT2020.SystemInfo.Settings.RefreshMainList<Default>();
                        MessageBox.Show(result.ToString() + " succeed!", "Preparation result", MessageBoxButtons.OK, new EventHandler(PreparationMessageHandler));
                    }
                    else
                    {
                        MessageBox.Show(result.ToString() + " succeed!", "Preparation result", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void PreparationMessageHandler(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem listItem in lvToWorkplaceList.Items)
            {
                if (Common.Utility.IsGUID(listItem.Text))
                {
                    if (btnSelectAll.Text.Contains("Select"))
                    {
                        listItem.Checked = true;
                    }
                    else
                    {
                        listItem.Checked = false;
                    }
                }
            }
            this.Update();

            btnSelectAll.Text = (btnSelectAll.Text == "Select All") ? "Remove All" : "Select All";
        }

        private void cboFromWorkplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Common.Utility.IsGUID(cboFromWorkplace.SelectedValue.ToString()))
            {
                txtSelectedFromWorkplace.Text = ModelEx.WorkplaceEx.GetWorkplaceNameById((Guid)cboFromWorkplace.SelectedValue);
            }
        }

        private void cboToWorkplace_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Common.Utility.IsGUID(cboToWorkplace.SelectedValue.ToString()))
            {
                txtSelectedToWorkplace.Text = ModelEx.WorkplaceEx.GetWorkplaceNameById((Guid)cboToWorkplace.SelectedValue);
            }
        }
    }
}