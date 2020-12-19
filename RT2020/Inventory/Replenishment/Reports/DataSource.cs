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


using RT2020.Helper;

namespace RT2020.Inventory.Replenishment.Reports
{
    public class DataSource
    {
        public static DataTable Worksheet(string FromTxNumber, string ToTxNumber, DateTime FromTxDate, DateTime ToTxDate)
        {
            string sql = @"
SELECT  TOP (100) PERCENT
		h.HeaderId, h.TxNumber, h.TxDate, s1.StaffCode AS OperatorCode, s1.FullName AS OperatorName,
		ISNULL(h.FromLocation,  '') AS FmLocationCode, ISNULL(h.FromLocation, '') AS FmLocationName,
		ISNULL(h.ToLocation, '') AS ToLocationCode, ISNULL(h.ToLocation, '') AS ToLocationName,
		h.TXFOn AS TransferredOn, h.CompletedOn,
		(
		CASE
			WHEN h.Status = 0 THEN 'HOLD'
			WHEN h.Status = 1 THEN 'POST'
		END
		) AS Status,
		h.ModifiedOn, s2.StaffCode AS ModifiedBy
FROM    dbo.Staff AS s2 INNER JOIN
        dbo.InvtBatchRPL_Header AS h INNER JOIN
        dbo.Staff AS s1
			ON h.StaffId = s1.StaffId
			ON s2.StaffId = h.ModifiedBy
WHERE	h.TxNumber BETWEEN '" + FromTxNumber.Trim() + @"' AND '" + ToTxNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), h.TxDate, 101) BETWEEN '" + FromTxDate.ToString("MM/dd/yyyy") + @"' AND '" + ToTxDate.ToString("MM/dd/yyyy") + @"'
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
SELECT     TOP (100) PERCENT p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.ProductName, d.QtyRequested, d.QtyIssued, 
                      d.Remarks AS Notes
FROM         dbo.InvtBatchRPL_Details AS d INNER JOIN
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
		h.HeaderId, h.TxNumber, h.TxDate, s1.StaffCode AS OperatorCode, s1.FullName AS OperatorName,
		ISNULL(h.FromLocation,  '') AS FmLocationCode, ISNULL(h.FromLocation, '') AS FmLocationName,
		ISNULL(h.ToLocation, '') AS ToLocationCode, ISNULL(h.ToLocation, '') AS ToLocationName,
		h.TXFOn AS TransferredOn, h.CompletedOn,
		(
		CASE
			WHEN h.Status = 0 THEN 'HOLD'
			WHEN h.Status = 1 THEN 'POST'
		END
		) AS Status,
		h.ModifiedOn, s2.StaffCode AS ModifiedBy
FROM    dbo.Staff AS s2 INNER JOIN
        dbo.InvtSubLedgerRPL_Header AS h INNER JOIN
        dbo.Staff AS s1
			ON h.StaffId = s1.StaffId
			ON s2.StaffId = h.ModifiedBy
WHERE	h.TxNumber BETWEEN '" + FromTxNumber.Trim() + @"' AND '" + ToTxNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), h.TxDate, 101) BETWEEN '" + FromTxDate.ToString("MM/dd/yyyy") + @"' AND '" + ToTxDate.ToString("MM/dd/yyyy") + @"'
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
SELECT     TOP (100) PERCENT p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.ProductName, d.QtyRequested, d.QtyIssued, 
                      d.Remarks AS Notes
FROM         dbo.InvtSubLedgerRPL_Details AS d INNER JOIN
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
