using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;

namespace PortalStore.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(Context context) : base(context)
        {
        }
    }
}
