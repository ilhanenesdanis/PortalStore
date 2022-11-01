using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Service.IService;

namespace PortalStore.Service.Service
{
    public class AddressService : Service<Address>, IAddressService
    {
        public AddressService(IUnitOfWork unitOfWork, IRepository<Address> repository) : base(unitOfWork, repository)
        {
        }
    }
}
