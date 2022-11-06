using PortalStore.DTO.Base;

namespace PortalStore.DTO.Product
{
    public class UpdateProductDto:BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
