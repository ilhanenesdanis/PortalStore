using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PortalStore.Core.IRepository;
using PortalStore.Core.IService;
using PortalStore.Core.IUnitOfWork;
using PortalStore.Data;
using PortalStore.Data.Repository;
using PortalStore.Data.UnitOfWork;
using PortalStore.Service.IService;
using PortalStore.Service.Mapping;
using PortalStore.Service.Service;
using System.Reflection;

namespace PortalStore.Service.Dependencies
{
    public static class IOC
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //Core
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<Context>(x =>
                x.UseSqlServer(configuration.GetConnectionString("SqlConnection"), options =>
                {
                    options.MigrationsAssembly(Assembly.GetAssembly(typeof(Context)).GetName().Name);
                })
            );
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddAutoMapper(typeof(MapProfile));
            //Repository
            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<ICategoryRepository,CategoryRepository>();
            services.AddScoped<ICustomerRepository,CustomerRepository>();
            services.AddScoped<IOrderRepository,OrderRepository>();
            services.AddScoped<IOrderItemRepository,OrderItemRepository>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IBasketRepository, BasketRepository>();
            //Service
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<ICategoryService,CategoryService>();
            services.AddScoped<ICustomerService,CustomerService>();
            services.AddScoped<IOrderService,OrderService>();
            services.AddScoped<IOrderItemService,OrderItemService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IBasketService, BasketService>();
            
        }
    }
}
