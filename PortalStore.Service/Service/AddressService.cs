using Microsoft.EntityFrameworkCore;
using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class AddressService : Service<Address>, IAddressService
    {
        private readonly IRepository<Address> _repository;
        public AddressService(IUnitOfWork unitOfWork, IRepository<Address> repository) : base(unitOfWork, repository)
        {
            _repository= repository;
        }

        public List<Address> GetCustomerAddress(int customerId)
        {
            return _repository.GetBy(x => x.CustomerId == customerId).Include(x => x.Customer).ToList();
        }
    }
}
