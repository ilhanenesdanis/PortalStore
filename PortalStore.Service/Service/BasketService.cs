using Microsoft.EntityFrameworkCore;
using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class BasketService : Service<Basket>, IBasketService
    {
        private readonly IRepository<Basket> _repository;
        public BasketService(IUnitOfWork unitOfWork, IRepository<Basket> repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public List<Basket> GetAllBasket()
        {
            return _repository.GetAll().Include(x => x.Customer).Include(x => x.Product).ToList();
        }

        public List<Basket> GetBasketByCustomerId(int customerId)
        {
            return _repository.GetBy(x => x.CustomerId == customerId).Include(x=>x.Customer).Include(x => x.Product).ToList();
        }
    }
}
