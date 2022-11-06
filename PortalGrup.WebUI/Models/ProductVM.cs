using PortalStore.DTO.Category;
using PortalStore.DTO.Product;

namespace PortalStore.WebUI.Models
{
    public class ProductVM
    {
        public List<ProductListDto> Product{ get; set; }
        public ProductListDto UpdateProduct { get; set; }
        public List<CategoryListDto> Category { get; set; }
    }
}
