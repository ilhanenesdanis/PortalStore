using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class CustomerService : Service<Customer>, ICustomerService
    {
        public CustomerService(IUnitOfWork unitOfWork, IRepository<Customer> repository) : base(unitOfWork, repository)
        {
        }
    }
}
