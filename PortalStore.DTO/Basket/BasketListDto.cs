using PortalStore.DTO.Base;
using PortalStore.DTO.Customer;
using PortalStore.DTO.Product;

namespace PortalStore.DTO.Basket
{
    public class BasketListDto:BaseDto
    {
        public int ProductId { get; set; }
        public ProductListDto Product { get; set; }
        public int CustomerId { get; set; }
        public CustomerListDto Customer { get; set; }
        public int Quantity { get; set; }
    }
}
