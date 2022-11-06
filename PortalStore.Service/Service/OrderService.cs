using Microsoft.EntityFrameworkCore;
using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IRepository<Order> _repository;
        public OrderService(IUnitOfWork unitOfWork, IRepository<Order> repository) : base(unitOfWork, repository)
        {
            _repository=repository;
        }

        public List<Order> GetAllOrder()
        {
            return _repository.GetAll().Include(x => x.Customer).Include(x => x.Address).ToList();
        }
    }
}
