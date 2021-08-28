using LinqToDB.Mapping;

namespace RT2020.Inventory.Reports.TestModels
{
    public partial class item
    {
        [Association(ThisKey = "PartNo", OtherKey = "PartNo")]
        public part Part { get; set; }

        [Association(ThisKey = "OrderNo", OtherKey = "OrderNo")]
        public order Order { get; set; }
    }
}