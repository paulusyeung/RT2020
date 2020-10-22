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

namespace RT2020.Controls.ProductSearcher
{
    public partial class Basic : UserControl
    {
        private static string stkCode = string.Empty;

        public Basic()
        {
            InitializeComponent();

            this.ResultList = new List<DetailData>();
        }

        #region Properties
        private object m_selectedItem = null;
        public object SelectedItem
        {
            get
            {
                return m_selectedItem;
            }
            set
            {
                if (value != null)
                {
                    m_selectedItem = value;

                    if (cboFullStockCode.Items.Contains(m_selectedItem))
                    {
                        cboFullStockCode.SelectedValue = m_selectedItem;
                    }
                    //else
                    //{
                    //    FillProductList(value.ToString());
                    //}
                }
            }
        }

        private string m_selectedText = string.Empty;
        public string SelectedText
        {
            get
            {
                return m_selectedText;
            }
            set
            {
                if (value != null)
                {
                    m_selectedText = value;

                    cboFullStockCode.Text = m_selectedText;
                }
            }
        }

        public new Color BackColor
        {
            get
            {
                return cboFullStockCode.BackColor;
            }
            set
            {
                cboFullStockCode.BackColor = value;
            }
        }

        public List<DetailData> ResultList { get; set; }

        public bool HasMatrix
        {
            get
            {
                return this.btnFind_Matrix.Visible;
            }
            set
            {
                this.btnFind_Matrix.Visible = value;
            }
        }

        public Common.Enums.TxType TxType { get; set; }

        #endregion

        #region Binding Combo List

        private void FillProductList(string value)
        {
            //if (!cboFullStockCode.Items.Contains(value))
            //{
            //    cboFullStockCode.DataSource = null;
            //}

            //if (cboFullStockCode.DataSource == null)
            //{
                ProductList itemList = new ProductList();

                //cboFullStockCode.Items.Clear();

                string sql = string.Empty;
                if (Common.Utility.IsGUID(value))
                {
                    sql = "ProductId = '" + value + "'";
                }
                else
                {
                    //itemList.Add(new ProductRec(System.Guid.Empty, value));
                    sql = BuildWhereClause(value);
                }

                sql += " AND Retired = 0";

                string[] orderBy = new string[] { "STKCODE" };
                RT2020.DAL.ProductCollection prodList = RT2020.DAL.Product.LoadCollection(sql, orderBy, true);
                foreach (RT2020.DAL.Product prod in prodList)
                {
                    itemList.Add(new ProductRec(prod.ProductId, prod.STKCODE + " " + prod.APPENDIX1 + " " + prod.APPENDIX2 + " " + prod.APPENDIX3));
                }
                cboFullStockCode.DisplayMember = "StockCode";
                cboFullStockCode.ValueMember = "ProductId";
                cboFullStockCode.DataSource = itemList;
                cboFullStockCode.Update();
            //}
        }

        private string BuildWhereClause(string value)
        {
            StringBuilder whereClause = new StringBuilder();
            string a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;

            if (value.Contains(" "))
            {
                string[] prodCode = value.Split(new char[] { ' ' });
                switch (prodCode.Length)
                {
                    case 1:
                        whereClause.Append(" STKCODE LIKE '").Append(prodCode[0]).Append("%'");
                        break;
                    case 2:
                        whereClause.Append(" STKCODE LIKE '").Append(prodCode[0]).Append("%'");
                        whereClause.Append(" AND APPENDIX1 LIKE '").Append(prodCode[1]).Append("%'");
                        break;
                    case 3:
                        whereClause.Append(" STKCODE LIKE '").Append(prodCode[0]).Append("%'");
                        whereClause.Append(" AND (APPENDIX1 LIKE '").Append(prodCode[1]).Append("%'");
                        whereClause.Append(" OR APPENDIX2 LIKE '").Append(prodCode[2]).Append("%')");
                        break;
                    case 4:
                        whereClause.Append(" STKCODE LIKE '").Append(prodCode[0]).Append("%'");
                        whereClause.Append(" AND (APPENDIX1 LIKE '").Append(prodCode[1]).Append("%'");
                        whereClause.Append(" OR APPENDIX2 LIKE '").Append(prodCode[2]).Append("%'");
                        whereClause.Append(" OR APPENDIX3 LIKE '").Append(prodCode[3]).Append("%')");
                        break;
                }
            }
            else
            {
                whereClause.Append(" STKCODE LIKE '" + value + "%' ");
            }

            return whereClause.ToString();
        }

        #region ComboBox Binding Class
        public class ProductRec
        {
            Guid prodId = System.Guid.Empty;
            string stkCode = string.Empty;

            public ProductRec(Guid pId, string sCode)
            {
                prodId = pId;
                stkCode = sCode;
            }

            public Guid ProductId
            {
                get { return prodId; }
                set { prodId = value; }
            }

            public string StockCode
            {
                get { return stkCode; }
                set { stkCode = value; }
            }
        }

        public class ProductList : BindingList<ProductRec>
        {
        }
        #endregion

        #endregion

        private decimal GetAverageCost(Guid productId)
        {
            decimal avgCost = 0;

            ProductCurrentSummary oCurSum = ProductCurrentSummary.LoadWhere("ProductId = '" + productId.ToString() + "'");
            if (oCurSum != null)
            {
                avgCost = oCurSum.AverageCost;
            }

            return avgCost;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string scode = string.Empty, a1 = string.Empty, a2 = string.Empty, a3 = string.Empty;

            if (cboFullStockCode.Text.IndexOf(' ') > 0)
            {
                string[] temp = cboFullStockCode.Text.Trim().Split(' ');
                switch (temp.Length)
                {
                    case 1:
                        scode = temp[0];
                        break;
                    case 2:
                        scode = temp[0];
                        a1 = temp[1];
                        break;
                    case 3:
                        scode = temp[0];
                        a1 = temp[1];
                        a2 = temp[2];
                        break;
                    case 4:
                        scode = temp[0];
                        a1 = temp[1];
                        a2 = temp[2];
                        a3 = temp[3];
                        break;
                }
            }
            else
            {
                scode = cboFullStockCode.Text;
            }

            stkCode = scode;

            Simple prodSimple = new Simple();
            prodSimple.StockCode = scode;
            prodSimple.Appendix1 = a1;
            prodSimple.Appendix2 = a2;
            prodSimple.Appendix3 = a3;
            prodSimple.Closed += new EventHandler(prodSimple_Closed);
            prodSimple.ShowDialog();

            //cboFullStockCode.DataSource = null;
        }

        private void prodSimple_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                Simple prodSimple = sender as Simple;
                if (prodSimple.StockCode.Length > 0)
                {
                    string prodCode = prodSimple.StockCode + " " + prodSimple.Appendix1 + " " + prodSimple.Appendix2 + " " + prodSimple.Appendix3;
                    FillProductList(prodCode.Trim());
                }
            }
        }

        private void btnFind_Matrix_Click(object sender, EventArgs e)
        {
            string[] temp = stkCode.Trim().Split(' ');

            MatrixDetail prodMatrix = new MatrixDetail();
            prodMatrix.StockCode = temp[0];
            prodMatrix.TxType = this.TxType;
            prodMatrix.ResultList = this.ResultList;
            prodMatrix.Closed += new EventHandler(prodMatrix_Closed);
            prodMatrix.ShowDialog();
        }

        private void prodMatrix_Closed(object sender, EventArgs e)
        {
            if (((Form)sender).DialogResult == DialogResult.OK)
            {
                MatrixDetail prodMatrix = sender as MatrixDetail;
                if (prodMatrix != null)
                {
                    this.ResultList = prodMatrix.ResultList;

                    if (this.Parent.Parent.Parent != null)
                    {
                        IWizard wizard = this.Parent.Parent.Parent as IWizard;
                        if (wizard != null)
                        {
                            wizard.AddItemByList(this.ResultList);
                        }
                    }
                }
            }
        }

        private void cboFullStockCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = string.Empty;
            if (cboFullStockCode.SelectedValue != null && Common.Utility.IsGUID(cboFullStockCode.SelectedValue.ToString()))
            {
                query = "ProductId = '" + cboFullStockCode.SelectedValue.ToString() + "'";
            }
            else
            {
                query = BuildWhereClause(cboFullStockCode.Text.Trim());
            }

            if (query.Length > 0)
            {
                RT2020.DAL.Product oProd = RT2020.DAL.Product.LoadWhere(query);
                if (oProd != null)
                {
                    this.SelectedItem = oProd.ProductId;

                    ProductSelectionEventArgs args = new ProductSelectionEventArgs(oProd.ProductId, oProd.STKCODE, oProd.APPENDIX1, oProd.APPENDIX2,
                        oProd.APPENDIX3, oProd.ProductName, oProd.RetailPrice, Utility.GetOnHandQtyByCurrentZone(oProd.ProductId), oProd.OriginalRetailPrice, GetAverageCost(oProd.ProductId), oProd.NormalDiscount);

                    OnSelectionChanged(args);
                }
            }
        }

        private void cboFullStockCode_TextChanged(object sender, EventArgs e)
        {
            stkCode = cboFullStockCode.Text.Trim();

            //if (stkCode.Length > 0)
            //{
            //    FillProductList(stkCode);
            //}
        }

        #region Product Selection Event
        public event EventHandler<ProductSelectionEventArgs> SelectionChanged;

        protected virtual void OnSelectionChanged(ProductSelectionEventArgs e)
        {
            EventHandler<ProductSelectionEventArgs> temp = SelectionChanged;

            if (temp != null)
            {
                temp(this, e);
            }
        }

        public class ProductSelectionEventArgs : EventArgs
        {
            private readonly Guid m_ProductId;
            private readonly string m_StockCode, m_Appendix1, m_Appendix2, m_Appendix3, m_Description;
            private readonly decimal m_UnitPrice, m_QtyOnHand, m_UnitCost, m_AverageCost, m_Discount;

            public ProductSelectionEventArgs(
                Guid productId, string stockCode,
                string appendix1, string appendix2, string appendix3, string description,
                decimal unitPrice, decimal qtyOnHand, decimal unitCost, decimal averageCost, decimal discount)
            {
                m_ProductId = productId;
                m_StockCode = stockCode;
                m_Appendix1 = appendix1;
                m_Appendix2 = appendix2;
                m_Appendix3 = appendix3;
                m_Description = description;
                m_UnitPrice = unitPrice;
                m_QtyOnHand = qtyOnHand;
                m_UnitCost = unitCost;
                m_AverageCost = averageCost;
                m_Discount = discount;
            }

            public Guid ProductId
            {
                get
                {
                    return m_ProductId;
                }
            }

            public string STKCode
            {
                get
                {
                    return m_StockCode;
                }
            }

            public string Appendix1
            {
                get
                {
                    return m_Appendix1;
                }
            }

            public string Appendix2
            {
                get
                {
                    return m_Appendix2;
                }
            }

            public string Appendix3
            {
                get
                {
                    return m_Appendix3;
                }
            }

            public string Description
            {
                get
                {
                    return m_Description;
                }
            }

            public decimal UnitPrice
            {
                get
                {
                    return m_UnitPrice;
                }
            }

            public decimal QtyOnHand
            {
                get
                {
                    return m_QtyOnHand;
                }
            }

            public decimal UnitCost
            {
                get
                {
                    return m_UnitCost;
                }
            }

            public decimal AverageCost
            {
                get
                {
                    return m_AverageCost;
                }
            }

            public decimal Discount
            {
                get
                {
                    return m_Discount;
                }
            }
        }
        #endregion
    }
}