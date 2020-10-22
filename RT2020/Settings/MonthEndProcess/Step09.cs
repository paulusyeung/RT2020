using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using RT2020.DAL;
using RT2020.Controls;

namespace RT2020.Settings.MonthEndProcess
{
    /// <summary>
    /// Re-calculate FEP Qty
    /// </summary>
    public class Step09:IStep
    {
        #region IStep Members

        public event ProgressUpdateEventHandler UpdatedProgress;

        public void DoAction()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 Processing ...", 1, 100));

            this.UpdateFepData();

            // SHOP
            this.AddNewProductWorkplace("'CAS', 'CRT', 'VOD', 'TXI', 'TXO'", "SHOP");
            this.DeductShopFepQty();
            this.AddShopFepQty();

            // FTSHOP
            this.AddNewProductWorkplace("'TXI', 'TXO'", "FTSHOP");
            this.DeductFtShopFepQty();
            this.AddFtShopFepQty();
        }

        #endregion

        private void UpdateFepData()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Update Data [FepBatchHeader].", 10, 100));
            // Update Data
            string query = @"UPDATE FepBatchHeader SET STATUS = '' WHERE STATUS IS NULL";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);

            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Update Data [ProductWorkplace].", 20, 100));
            // Update Data
            query = @"UPDATE ProductWorkplace SET FEPQty = 0";

            cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Adds the new product workplace.
        /// </summary>
        /// <param name="txType">'CAS', 'CRT', 'VOD', 'TXI', 'TXO' (SHOP) or 'TXI', 'TXO' (FTSHOP)</param>
        /// <param name="shopType">SHOP, FTSHOP</param>
        private void AddNewProductWorkplace(string txType, string shopType)
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Add new product workplace." + txType + ";" + shopType, 30, 100));
            // Add new product workplace
            string query = @"
INSERT INTO ProductWorkplace ( ProductId, WorkplaceId )
SELECT fep.ProductId, fep.WorkplaceId
FROM 
	(SELECT fd.ProductId, w.WorkplaceId
	FROM Workplace w INNER JOIN (Product p INNER JOIN 
		(FepBatchDetail fd INNER JOIN FepBatchHeader fh ON (fh.HeaderId = fd.HeaderId)) 
		ON (p.ProductId = fd.ProductId)) ON w.WorkplaceCode = fh." + shopType + @"
	WHERE (fd.TxType IN (" + txType + @")) And (fh.[STATUS] <> 'P')
	GROUP BY fd.ProductId, w.WorkplaceId) fep
        LEFT JOIN ProductWorkplace pw ON (fep.WorkplaceId = pw.WorkplaceId) AND 
        (fep.ProductId = pw.ProductId)
GROUP BY fep.ProductId, fep.WorkplaceId, pw.ProductId HAVING (pw.ProductId Is Null)";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        #region SHOP
        /// <summary>
        /// Update FEPQty from CRT, VOD, TXI (SHOP)
        /// </summary>
        private void DeductShopFepQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Deduct Shop FEP Qty", 40, 100));
            // Deduct Shop FEP Qty
            string query = @"
UPDATE ProductWorkplace
SET ProductWorkplace.FEPQTY = pw.[FEPQTY] - fd.[QTY]
FROM FepBatchHeader fh INNER JOIN FepBatchDetail fd ON 
	 (fd.HeaderId = fh.HeaderId)
      INNER JOIN ProductWorkplace pw ON 
      (pw.ProductId = fd.ProductId) 
      AND (fh.SHOP = (SELECT WorkplaceCode FROM Workplace WHERE WorkplaceId = pw.WorkplaceId))
WHERE (fh.TxType IN ('CRT', 'VOD', 'TXI') AND fh.[STATUS]<>'P') ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Update FEPQty from CAS, TXO (SHOP)
        /// </summary>
        private void AddShopFepQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Add Shop FEP Qty", 50, 100));
            // Add Shop FEP Qty
            string query = @"
UPDATE ProductWorkplace
SET ProductWorkplace.FEPQTY = pw.[FEPQTY] + fd.[QTY]
FROM FepBatchHeader fh INNER JOIN FepBatchDetail fd ON 
	 (fd.HeaderId = fh.HeaderId)
      INNER JOIN ProductWorkplace pw ON 
      (pw.ProductId = fd.ProductId) 
      AND (fh.SHOP = (SELECT WorkplaceCode FROM Workplace WHERE WorkplaceId = pw.WorkplaceId))
WHERE (fh.TxType IN ('CAS', 'TXO') AND fh.[STATUS]<>'P') ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        } 
        #endregion

        #region FTSHOP
        /// <summary>
        /// Update TXO FTSHOP FEPQty
        /// </summary>
        private void DeductFtShopFepQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Deduct Ft Shop FEP Qty", 60, 100));
            // Deduct FT Shop FEP Qty
            string query = @"
UPDATE ProductWorkplace
SET ProductWorkplace.FEPQTY = [FEPQTY]-[QTY] 
FROM (SELECT fd.ProductId, w.WorkplaceId, fd.TxType, fd.QTY 
		FROM Workplace w INNER JOIN (Product p INNER JOIN (FepBatchDetail fd INNER JOIN FepBatchHeader fh 
			ON (fh.HeaderId = fd.HeaderId)) ON p.ProductId = fd.ProductId)
			ON (fh.FTSHOP = w.WorkplaceCode)
		WHERE (fd.TxType) IN ('TXI', 'TXO') AND fh.[STATUS]<>'P') fep
	INNER JOIN ProductWorkplace pw
	 ON (fep.WorkplaceId = pw.WorkplaceId) AND (fep.ProductId = pw.ProductId)
WHERE (fep.TxType = 'TXO') ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }

        /// <summary>
        /// Update TXI FTSHOP FQPQty
        /// </summary>
        private void AddFtShopFepQty()
        {
            UpdatedProgress(this, new ProgressUpdateEventArgs("Step09 - Add Ft Shop FEP Qty", 70, 100));
            // Add FT Shop FEP Qty
            string query = @"
UPDATE ProductWorkplace
SET ProductWorkplace.FEPQTY = [FEPQTY]+[QTY] 
FROM (SELECT fd.ProductId, w.WorkplaceId, fd.TxType, fd.QTY 
		FROM Workplace w INNER JOIN (Product p INNER JOIN (FepBatchDetail fd INNER JOIN FepBatchHeader fh 
			ON (fh.HeaderId = fd.HeaderId)) ON p.ProductId = fd.ProductId)
			ON (fh.FTSHOP = w.WorkplaceCode)
		WHERE (fd.TxType) IN ('TXI', 'TXO') AND fh.[STATUS]<>'P') fep
	INNER JOIN ProductWorkplace pw
	 ON (fep.WorkplaceId = pw.WorkplaceId) AND (fep.ProductId = pw.ProductId)
WHERE (fep.TxType = 'TXI') ";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = query;
            cmd.CommandTimeout = Common.Config.CommandTimeout;
            cmd.CommandType = CommandType.Text;

            SqlHelper.Default.ExecuteNonQuery(cmd);
        }
        #endregion
    }
}
