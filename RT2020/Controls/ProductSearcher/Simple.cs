#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;
using RT2020.Helper;

#endregion

namespace RT2020.Controls.ProductSearcher
{
    public partial class Simple : Form
    {
        public bool IsCompleted = false;

        public Simple()
        {
            InitializeComponent();
            SetSystemLabels();
        }

        #region System Labels
        private void SetSystemLabels()
        {
            this.lblStockCode.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("STKCODE");
            this.lblAppendix1.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX1");
            this.lblAppendix2.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX2");
            this.lblAppendix3.Text = SystemInfoHelper.Settings.GetSystemLabelByKey("APPENDIX3");

            this.lblDescription.Text = RT2020.Controls.Utility.Dictionary.GetWord("description");
            this.btnFind.Text = RT2020.Controls.Utility.Dictionary.GetWord("Find");
            this.btnCancel.Text = RT2020.Controls.Utility.Dictionary.GetWord("Cancel");

            this.Text = string.Format(Utility.Dictionary.GetWord("SearchFor"), Utility.Dictionary.GetWord("Product"));
        }
        #endregion

        #region Properties
        private Guid prodId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return prodId;
            }
            set
            {
                prodId = value;
            }
        }

        public string StockCode
        {
            get
            {
                return txtStockCode.Text;
            }
            set
            {
                txtStockCode.Text = value;
            }
        }

        public string Appendix1
        {
            get
            {
                return txtAppendix1.Text;
            }
            set
            {
                txtAppendix1.Text = value;
            }
        }

        public string Appendix2
        {
            get
            {
                return txtAppendix2.Text;
            }
            set
            {
                txtAppendix2.Text = value;
            }
        }

        public string Appendix3
        {
            get
            {
                return txtAppendix3.Text;
            }
            set
            {
                txtAppendix3.Text = value;
            }
        }

        public string Description
        {
            get
            {
                return txtDescription.Text;
            }
            set
            {
                txtDescription.Text = value;
            }
        }

        private string barcode = string.Empty;
        public string Barcode
        {
            get
            {
                return barcode;
            }
            set
            {
                barcode = value;
            }
        }
        #endregion

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            //StringBuilder sql = new StringBuilder();
            //if (txtStockCode.Text.Length > 0)
            //{
            //    sql.Append("STKCODE LIKE '").Append(txtStockCode.Text.Trim()).Append("%'");
            //}

            //if (txtAppendix1.Text.Length > 0)
            //{
            //    if (sql.Length > 0)
            //    {
            //        sql.Append(" AND ");
            //    }

            //    sql.Append("Appendix1 LIKE '").Append(txtAppendix1.Text.Trim()).Append("%'");
            //}

            //if (txtAppendix2.Text.Length > 0)
            //{
            //    if (sql.Length > 0)
            //    {
            //        sql.Append(" AND ");
            //    }

            //    sql.Append("Appendix2 LIKE '").Append(txtAppendix2.Text.Trim()).Append("%'");
            //}

            //if (txtAppendix3.Text.Length > 0)
            //{
            //    if (sql.Length > 0)
            //    {
            //        sql.Append(" AND ");
            //    }

            //    sql.Append("Appendix3 LIKE '").Append(txtAppendix3.Text.Trim()).Append("%'");
            //}

            //if (txtDescription.Text.Length > 0)
            //{
            //    if (sql.Length > 0)
            //    {
            //        sql.Append(" AND ");
            //    }

            //    sql.Append("ProductName LIKE '%").Append(txtDescription.Text.Trim()).Append("%'");
            //}

            this.StockCode = txtStockCode.Text.Trim();
            this.Appendix1 = txtAppendix1.Text.Trim();
            this.Appendix2 = txtAppendix2.Text.Trim();
            this.Appendix3 = txtAppendix3.Text.Trim();
            this.Description = txtDescription.Text.Trim();

            //if (sql.Length > 0)
            //{
            //    RT2020.DAL.Product oProd = RT2020.DAL.Product.LoadWhere(sql.ToString());
            //    if (oProd != null)
            //    {
            //        //this.ProductId = oProd.ProductId;
            //        this.StockCode = oProd.STKCODE;
            //        this.Appendix1 = oProd.APPENDIX1;
            //        this.Appendix2 = oProd.APPENDIX2;
            //        this.Appendix3 = oProd.APPENDIX3;
            //        //this.Description = oProd.ProductName;
            //        this.IsCompleted = true;
            //    }
            //}

            this.IsCompleted = true;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}