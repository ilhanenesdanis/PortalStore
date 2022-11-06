namespace PortalStore.Core.Entity
{
    public class Customer : Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public long TCID { get; set; }
        public DateTime BirthDate { get; set; }
        public string GSM { get; set; }
        public List<Address> Addresses { get; set; }
        public List<Order> Orders { get; set; }
        public List<Basket> Baskets { get; set; }
    }
}
