using System;
using System.Collections.Generic;
using LinqToDB.Mapping;

namespace RT2020.Inventory.Reports.TestModels
{
    public partial class customer
    {
        [Association(ThisKey = "CustNo", OtherKey = "CustNo", IsBackReference = true)]
        public List<order> Orders { get; set; }
    }
}