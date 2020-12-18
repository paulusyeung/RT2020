using System;
using System.Data;
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
using System.Data.SqlClient;
using RT2020.Helper;

namespace RT2020.Purchasing.Reports.PurchaseOrder.Reports
{
    /// <summary>
    /// PurchaseOrder DataSource class
    /// </summary>
    public class DataSource
    {
        /// <summary>
        /// WorksheetOrderNumber the specified from order number and date.
        /// </summary>
        /// <param name="fromOrderNumber">From order number.</param>
        /// <param name="toOrderNumber">To order number.</param>
        /// <param name="fromDate">From date.</param>
        /// <param name="toDate">To date.</param>
        /// <returns>A DataTable object</returns>
        public static DataTable WorksheetOrderNumber(string fromOrderNumber, string toOrderNumber, DateTime fromDate, DateTime toDate)
        {
            string sql = @"
SELECT * FROM vwPurchaseOrderHeader 
WHERE OrderNumber BETWEEN '" + fromOrderNumber.Trim() + @"' AND '" + toOrderNumber.Trim() + @"' AND
        CONVERT(VARCHAR(10), OrderOn, 101) BETWEEN '" + fromDate.ToString("MM/dd/yyyy") + @"' AND '" + toDate.ToString("MM/dd/yyyy") + @"' 
ORDER BY OrderNumber;
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

        /// <summary>
        /// Worksheets the details.
        /// </summary>
        /// <param name="orderHeaderId">The order header id.</param>
        /// <returns>A DataTable object</returns>
        public static DataTable WorksheetDetails(string orderHeaderId)
        {
            string headerId = Guid.Empty.ToString();
            if (orderHeaderId != null)
            {
                headerId = orderHeaderId;
            }

            string sql = @"
SELECT * FROM vwPurchaseOrderDetail
WHERE       OrderHeaderId = '" + headerId + @"'
ORDER BY LineNumber
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
