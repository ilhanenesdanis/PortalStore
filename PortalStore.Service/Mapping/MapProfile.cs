using AutoMapper;
using PortalStore.Core.Entity;
using PortalStore.DTO.Address;
using PortalStore.DTO.Basket;
using PortalStore.DTO.Category;
using PortalStore.DTO.Customer;
using PortalStore.DTO.Order;
using PortalStore.DTO.Product;

namespace PortalStore.Service.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            //Categort
            CreateMap<AddCategoryDto, Category>().ReverseMap();
            CreateMap<CategoryListDto, Category>().ReverseMap();
            CreateMap<UpdateCategoryDto, Category>().ReverseMap();
            //Product
            CreateMap<ProductListDto, Product>().ReverseMap();

            //customer
            CreateMap<AddCustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();
            CreateMap<CustomerListDto, Customer>().ReverseMap();
            //address
            CreateMap<AddressListDto, Address>().ReverseMap();
            CreateMap<AddAddressDto, Address>().ReverseMap();
            CreateMap<UpdateAddressDto, Address>().ReverseMap();
            //Product
            CreateMap<AddProductDto, Product>().ReverseMap();
            CreateMap<UpdateProductDto, Product>().ReverseMap();
            CreateMap<ProductListDto, Product>().ReverseMap();
            //Basket
            CreateMap<BasketListDto, Basket>().ReverseMap();
            CreateMap<AddBasketDto, Basket>().ReverseMap();
            CreateMap<UpdateBasketDto, Basket>().ReverseMap();
            //order
            CreateMap<AddOrderDto, Order>().ReverseMap();
            CreateMap<OrderListDto, Order>().ReverseMap();
        }
    }
}
