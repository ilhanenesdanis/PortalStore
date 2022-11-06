using Microsoft.EntityFrameworkCore;
using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IRepository<Product> _repository;
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProduct()
        {
            return _repository.GetAll().Include(x => x.Category).ToList();
        }
    }
}
