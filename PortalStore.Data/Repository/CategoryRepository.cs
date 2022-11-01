using PortalStore.Core.Entity;
using PortalStore.Core.IRepository;

namespace PortalStore.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Context context) : base(context)
        {
        }
    }
}
