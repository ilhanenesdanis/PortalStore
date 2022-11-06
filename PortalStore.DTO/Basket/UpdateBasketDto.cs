using PortalStore.DTO.Base;

namespace PortalStore.DTO.Basket
{
    public class UpdateBasketDto:BaseDto
    {
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public int Quantity { get; set; }
    }
}
