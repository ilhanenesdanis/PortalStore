using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;

namespace PortalStore.Data.Repository
{
    public class OrderItemRepository : Repository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(Context context) : base(context)
        {
        }
    }
}
