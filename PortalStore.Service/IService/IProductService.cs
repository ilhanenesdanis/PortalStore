using PortalStore.Core.Entity;
using PortalStore.Core.IService;

namespace PortalStore.Service.IService
{
    public interface IProductService:IService<Product>
    {
        List<Product> GetAllProduct();
    }
}
