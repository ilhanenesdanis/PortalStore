namespace PortalStore.DTO.Order
{
    public class AddOrderDto
    {
        public int CustomerId { get; set; }
        public int AddressId { get; set; }
        public decimal TotalPrice { get; set; }
       
    }
}
