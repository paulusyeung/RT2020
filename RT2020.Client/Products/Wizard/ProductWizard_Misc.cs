#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;


using System.Windows.Forms;
using RT2020.DAL;
using System.Data.SqlClient;
using System.IO;

using System.Threading;

#endregion

namespace RT2020.Client.Products.Wizard
{
    public partial class ProductWizard_Misc : UserControl
    {
        private Guid _ProductId = System.Guid.Empty;
        string mstrDirectory = String.Empty;

        #region Pulbic Properties
        public Guid ProductId
        {
            get
            {
                return _ProductId;
            }
            set
            {
                _ProductId = value;
            }
        }
        #endregion

        public ProductWizard_Misc(Guid productId)
        {
            InitializeComponent();

            if (productId != System.Guid.Empty)
            {
                this.ProductId = productId;
                ShowRec();
            }
        }

        private void ShowRec()
        {
            string sql = "ProductId = '" + _ProductId.ToString() + "'";
            ProductRemarks oRemarks = ProductRemarks.LoadWhere(sql);
            if (oRemarks != null)
            {
                txtMemo.Text = oRemarks.Notes;
                txtPicFileName.Text = oRemarks.Photo;
            }
        }

        public bool SaveRec(Guid productId)
        {
            bool result = false;

            RT2020.DAL.Product oProduct = RT2020.DAL.Product.Load(productId);
            if (oProduct != null)
            {
                string sql = "ProductId = '" + productId.ToString() + "'";
                DAL.ProductRemarks oRemarks = DAL.ProductRemarks.LoadWhere(sql);
                if (oRemarks == null)
                {
                    oRemarks = new DAL.ProductRemarks();

                    oRemarks.ProductId = productId;
                }

                oRemarks.Notes = txtMemo.Text;

                if (string.IsNullOrEmpty(oRemarks.Photo))
                {
                    oRemarks.Photo = txtPicFileName.Text;
                }
                else if (oRemarks.Photo != txtPicFileName.Text)
                {
                    oRemarks.Photo5 = oRemarks.Photo4;
                    oRemarks.Photo4 = oRemarks.Photo3;
                    oRemarks.Photo3 = oRemarks.Photo2;
                    oRemarks.Photo2 = oRemarks.Photo;
                    oRemarks.Photo = txtPicFileName.Text;
                }

                oRemarks.Save();

                _ProductId = productId;
                result = true;
            }

            return result;
        }
    }
}