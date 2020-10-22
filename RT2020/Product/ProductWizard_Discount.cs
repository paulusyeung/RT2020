#region Using

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;

using Gizmox.WebGUI.Common;
using Gizmox.WebGUI.Forms;

#endregion

namespace RT2020.Product
{
    public partial class ProductWizard_Discount : UserControl
    {
        public ProductWizard_Discount(Guid productId)
        {
            InitializeComponent();
            this.ProductId = productId;
        }

        #region Properties
        private Guid productId = System.Guid.Empty;
        public Guid ProductId
        {
            get
            {
                return productId;
            }
            set
            {
                productId = value;
            }
        }
        #endregion
    }
}