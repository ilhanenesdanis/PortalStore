using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class OrderItemService : Service<OrderItem>,IOrderItemService
    {
        public OrderItemService(IUnitOfWork unitOfWork, IRepository<OrderItem> repository) : base(unitOfWork, repository)
        {
        }
    }
}
