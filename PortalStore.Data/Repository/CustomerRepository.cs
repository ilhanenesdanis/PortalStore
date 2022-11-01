using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;

namespace PortalStore.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(Context context) : base(context)
        {
        }
    }
}
