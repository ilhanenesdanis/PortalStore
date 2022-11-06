using PortalStore.Core.Entity;
using PortalStore.Core.IService;

namespace PortalStore.Service.IService
{
    public interface IBasketService:IService<Basket>
    {
        List<Basket> GetBasketByCustomerId(int customerId);
        List<Basket> GetAllBasket();
    }
}
