using PortalStore.DTO.Base;
using PortalStore.DTO.Category;

namespace PortalStore.DTO.Product
{
    public class ProductListDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal OldPrice { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public CategoryListDto Category { get; set; }
    }
}
