using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


using RT2020.Common.Helper;

namespace RT2020.Inventory.Adjustment.Reports
{
    public class DataSource
    {
        public static DataTable Worksheet(string FromTxNumber, string ToTxNumber, DateTime FromTxDate, DateTime ToTxDate)
        {
            string sql = @"
SELECT  TOP (100) PERCENT
		h.HeaderId, h.TxNumber, h.TxDate, s1.StaffCode AS OperatorCode, s1.FullName AS OperatorName, h.Reference, w.WorkplaceCode AS LocationCode, w.WorkplaceName AS LocationName,
		h.Remarks, s2.StaffCode AS ModifiedBy, h.ModifiedOn,
		(SELECT isnull(sum(Qty), 0) FROM dbo.InvtBatchADJ_Details WHERE dbo.InvtBatchADJ_Details.TxNumber = h.TxNumber) AS TotalQty,
		(SELECT isnull(sum(Qty * AverageCost), 0) FROM dbo.InvtBatchADJ_Details WHERE dbo.InvtBatchADJ_Details.TxNumber = h.TxNumber) AS TotalAmount
FROM    dbo.InvtBatchADJ_Header AS h INNER JOIN
        dbo.Staff AS s1 ON h.StaffId = s1.StaffId INNER JOIN
        dbo.Staff AS s2 ON h.ModifiedBy = s2.StaffId INNER JOIN
        dbo.Workplace AS w ON h.WorkplaceId = w.WorkplaceId
WHERE	h.TxNumber BETWEEN '" + FromTxNumber.Trim() + @"' AND '" + ToTxNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), h.TxDate, 101) BETWEEN '" + FromTxDate.ToString("MM/dd/yyyy") + @"' AND '" + ToTxDate.ToString("MM/dd/yyyy") + @"' AND
        h.TxType = '" + EnumHelper.TxType.ADJ.ToString() + @"'
ORDER BY h.TxNumber, h.TxDate;
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        public static DataTable WorksheetDetails(string HeaderId)
        {
            string headerId = Guid.Empty.ToString();
            if (HeaderId != null)
            {
                headerId = HeaderId;
            }

            string sql = @"
SELECT     TOP (100) PERCENT p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.ProductName, d.Qty, d.AverageCost, 
                      d.Qty * d.AverageCost AS Amount, d.Remarks AS Notes
FROM         dbo.InvtBatchADJ_Details AS d INNER JOIN
                      dbo.Product AS p ON d.ProductId = p.ProductId
WHERE       d.HeaderId = '" + headerId + @"'
ORDER BY d.TxNumber, d.LineNumber
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        public static DataTable History(string FromTxNumber, string ToTxNumber, DateTime FromTxDate, DateTime ToTxDate)
        {
            string sql = @"
SELECT  TOP (100) PERCENT
		h.HeaderId, h.TxNumber, h.TxDate, s1.StaffCode AS OperatorCode, s1.FullName AS OperatorName, h.Reference, w.WorkplaceCode AS LocationCode, w.WorkplaceName AS LocationName,
		h.Remarks, s2.StaffCode AS ModifiedBy, h.ModifiedOn,
		(SELECT isnull(sum(Qty), 0) FROM dbo.InvtSubLedgerADJ_Details WHERE dbo.InvtSubLedgerADJ_Details.TxNumber = h.TxNumber) AS TotalQty,
		(SELECT isnull(sum(Qty * AverageCost), 0) FROM dbo.InvtSubLedgerADJ_Details WHERE dbo.InvtSubLedgerADJ_Details.TxNumber = h.TxNumber) AS TotalAmount
FROM    dbo.InvtSubLedgerADJ_Header AS h INNER JOIN
        dbo.Staff AS s1 ON h.StaffId = s1.StaffId INNER JOIN
        dbo.Staff AS s2 ON h.ModifiedBy = s2.StaffId INNER JOIN
        dbo.Workplace AS w ON h.WorkplaceId = w.WorkplaceId
WHERE	h.TxNumber BETWEEN '" + FromTxNumber.Trim() + @"' AND '" + ToTxNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), h.TxDate, 101) BETWEEN '" + FromTxDate.ToString("MM/dd/yyyy") + @"' AND '" + ToTxDate.ToString("MM/dd/yyyy") + @"' AND
        h.TxType = '" + EnumHelper.TxType.ADJ.ToString() + @"'
ORDER BY h.TxNumber, h.TxDate;
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }

        public static DataTable HistoryDetails(string HeaderId)
        {
            string headerId = Guid.Empty.ToString();
            if (HeaderId != null)
            {
                headerId = HeaderId;
            }

            string sql = @"
SELECT     TOP (100) PERCENT p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.ProductName, d.Qty, d.AverageCost, 
                      d.Qty * d.AverageCost AS Amount, d.Remarks AS Notes
FROM         dbo.InvtSubLedgerADJ_Details AS d INNER JOIN
                      dbo.Product AS p ON d.ProductId = p.ProductId
WHERE       d.HeaderId = '" + headerId + @"'
ORDER BY d.TxNumber, d.LineNumber
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = ConfigHelper.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
    }
}
