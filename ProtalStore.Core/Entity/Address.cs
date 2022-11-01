namespace PortalStore.Core.Entity
{
    public class Address:Base
    {
        public string AddressLine { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public int ZipCode { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public List<Order> Orders { get; set; }
    }
}
