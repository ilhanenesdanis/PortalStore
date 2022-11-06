using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;

namespace PortalStore.Data.Repository
{
    public class BasketRepository : Repository<Basket>, IBasketRepository
    {
        public BasketRepository(Context context) : base(context)
        {
        }
    }
}
