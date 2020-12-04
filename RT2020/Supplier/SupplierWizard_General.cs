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
using RT2020.Controls;

#endregion

namespace RT2020.Supplier
{
    public partial class SupplierWizard_General : UserControl
    {
        public SupplierWizard_General()
        {
            InitializeComponent();
            InitialSmartTags();
            FillComboList();
        }

        private void InitialSmartTags()
        {
            string[] orderBy = new string[] { "Priority" };
            var smartTagList = ModelEx.SmartTag4SupplierEx.GetListOrderBy(orderBy, true);

            SmartTag oTag = new SmartTag(this);
            oTag.SupplierSmartTagList = smartTagList;
            oTag.SetSmartTags();
        }

        #region Properties
        private Guid supplierId = System.Guid.Empty;
        public Guid SupplierId
        {
            get
            {
                return supplierId;
            }
            set
            {
                supplierId = value;
            }
        }
        #endregion

        #region Fill Combo List
        private void FillComboList()
        {
            FillMarketSectorList();
            //2014.01.04 paulus: 唔明掂解要選 Customer？Load 一次 N 咁耐！而且又係 cboCustomer.Visible = false
            //FillCustomerList();
        }

        private void FillMarketSectorList()
        {
            ModelEx.MarketSectorEx.LoadCombo(ref cboMarketSector, "MarketSectorCode", true, false, "", "");
        }

        private void FillCustomerList()
        {
            cboCustomer.DataSource = null;
            cboCustomer.Items.Clear();

            string[] orderBy = new string[] { "MemberNumber" };
            MemberCollection memberList = RT2020.DAL.Member.LoadCollection(orderBy, true);
            memberList.Add(new RT2020.DAL.Member());

            cboCustomer.DataSource = memberList;
            cboCustomer.DisplayMember = "MemberNumber";
            cboCustomer.ValueMember = "MemberId";

            cboCustomer.SelectedIndex = cboCustomer.Items.Count - 1;
        }
        #endregion

        private void SupplierWizard_General_Load(object sender, EventArgs e)
        {

        }
    }
}