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

using RT2020.DAL;
using RT2020.Helper;

namespace RT2020.Inventory.Transfer.Reports
{
    public class DataSource
    {
        public static DataTable Worksheet(string FromTxNumber, string ToTxNumber, DateTime FromTxDate, DateTime ToTxDate)
        {
            string sql = @"
SELECT  TOP (100) PERCENT
		h.HeaderId, h.TxNumber, h.TxDate, s1.StaffNumber AS OperatorCode, s1.FullName AS OperatorName,
		ISNULL(w1.WorkplaceCode,  '') AS FmLocationCode, ISNULL(w1.WorkplaceName, '') AS FmLocationName,
		ISNULL(w2.WorkplaceCode, '') AS ToLocationCode, ISNULL(w2.WorkplaceName, '') AS ToLocationName,
		h.TransferredOn, h.CompletedOn, h.Remarks,
		(
		CASE
			WHEN h.Status = 0 THEN 'HOLD'
			WHEN h.Status = 1 THEN 'POST'
		END
		) AS Status,
		h.ModifiedOn, s2.StaffCode AS ModifiedBy,
		(SELECT isnull(sum(QtyRequested), 0) FROM dbo.InvtBatchTXF_Details WHERE dbo.InvtBatchTXF_Details.TxNumber = h.TxNumber) AS TotalQty,
		(SELECT isnull(sum(QtyRequested * RetailPrice), 0) FROM dbo.InvtBatchTXF_Details INNER JOIN dbo.Product ON dbo.InvtBatchTXF_Details.ProductId = dbo.Product.ProductId WHERE dbo.InvtBatchTXF_Details.TxNumber = h.TxNumber) AS TotalAmount
FROM    dbo.Workplace AS w1 RIGHT OUTER JOIN
        dbo.Workplace AS w2 RIGHT OUTER JOIN
        dbo.Staff AS s2 INNER JOIN
        dbo.InvtBatchTXF_Header AS h INNER JOIN
        dbo.Staff AS s1
			ON h.StaffId = s1.StaffId
			ON s2.StaffId = h.ModifiedBy
			ON w2.WorkplaceId = h.ToLocation
			ON w1.WorkplaceId = h.FromLocation
WHERE	h.TxNumber BETWEEN '" + FromTxNumber.Trim() + @"' AND '" + ToTxNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), h.TxDate, 101) BETWEEN '" + FromTxDate.ToString("MM/dd/yyyy") + @"' AND '" + ToTxDate.ToString("MM/dd/yyyy") + @"' 
ORDER BY h.TxNumber, h.TxDate;
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
SELECT      TOP (100) PERCENT
            p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.ProductName, d.QtyRequested, p.RetailPrice AS UnitAmount, 
            d.QtyRequested * p.RetailPrice AS Amount, d.Remarks AS Notes
FROM        dbo.InvtBatchTXF_Details AS d INNER JOIN
            dbo.Product AS p ON d.ProductId = p.ProductId
WHERE       d.HeaderId = '" + headerId + @"'
ORDER BY d.TxNumber, d.LineNumber
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
		h.HeaderId, h.TxNumber, h.TxDate, s1.StaffNumber AS OperatorCode, s1.FullName AS OperatorName,
		ISNULL(w1.WorkplaceCode,  '') AS FmLocationCode, ISNULL(w1.WorkplaceName, '') AS FmLocationName,
		ISNULL(w2.WorkplaceCode, '') AS ToLocationCode, ISNULL(w2.WorkplaceName, '') AS ToLocationName,
		h.TransferredOn, h.CompletedOn, h.Remarks,
		(
		CASE
			WHEN h.Status = 0 THEN 'HOLD'
			WHEN h.Status = 1 THEN 'POST'
		END
		) AS Status,
		h.ModifiedOn, s2.StaffCode AS ModifiedBy,
		(SELECT isnull(sum(QtyRequested), 0) FROM dbo.InvtSubLedgerTXF_Details WHERE dbo.InvtSubLedgerTXF_Details.TxNumber = h.TxNumber) AS TotalQty,
		(SELECT isnull(sum(QtyRequested * RetailPrice), 0) FROM dbo.InvtSubLedgerTXF_Details INNER JOIN dbo.Product ON dbo.InvtSubLedgerTXF_Details.ProductId = dbo.Product.ProductId WHERE dbo.InvtSubLedgerTXF_Details.TxNumber = h.TxNumber) AS TotalAmount
FROM    dbo.Workplace AS w1 RIGHT OUTER JOIN
        dbo.Workplace AS w2 RIGHT OUTER JOIN
        dbo.Staff AS s2 INNER JOIN
        dbo.InvtSubLedgerTXF_Header AS h INNER JOIN
        dbo.Staff AS s1
			ON h.StaffId = s1.StaffId
			ON s2.StaffId = h.ModifiedBy
			ON w2.WorkplaceId = h.ToLocation
			ON w1.WorkplaceId = h.FromLocation
WHERE	h.TxNumber BETWEEN '" + FromTxNumber.Trim() + @"' AND '" + ToTxNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), h.TxDate, 101) BETWEEN '" + FromTxDate.ToString("MM/dd/yyyy") + @"' AND '" + ToTxDate.ToString("MM/dd/yyyy") + @"' AND
        h.TxType = '" + Common.Enums.TxType.TXF.ToString() + @"'
ORDER BY h.TxNumber, h.TxDate;
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
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
SELECT      TOP (100) PERCENT
            p.STKCODE, p.APPENDIX1, p.APPENDIX2, p.APPENDIX3, p.ProductName, d.QtyRequested, p.RetailPrice AS UnitAmount, 
            d.QtyRequested * p.RetailPrice AS Amount, d.Remarks AS Notes
FROM        dbo.InvtBatchTXF_Details AS d INNER JOIN
            dbo.Product AS p ON d.ProductId = p.ProductId
WHERE       d.HeaderId = '" + headerId + @"'
ORDER BY d.TxNumber, d.LineNumber
";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = sql;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = System.Data.CommandType.Text;

            using (DataSet dataset = SqlHelper.Default.ExecuteDataSet(cmd))
            {
                return dataset.Tables[0];
            }
        }
    }
}
