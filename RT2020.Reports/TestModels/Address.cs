namespace RT2020.Inventory.Reports.TestModels
{
    public class Address
    {
        /// <inheritdoc />
        public Address(string country, string city, string street)
        {
            City = city;
            Country = country;
            Street = street;
        }

        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
    }
}