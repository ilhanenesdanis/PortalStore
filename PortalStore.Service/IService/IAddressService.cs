using PortalStore.Core.Entity;
using PortalStore.Core.IService;
using PortalStore.DTO.Address;

namespace PortalStore.Service.IService
{
    public interface IAddressService:IService<Address>
    {
        List<Address> GetCustomerAddress(int customerId);
    }
}
