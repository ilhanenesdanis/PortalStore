namespace PortalStore.Core.Entity
{
    public class OrderItem:Base
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

    }
}
