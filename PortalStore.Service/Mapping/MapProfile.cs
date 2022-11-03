﻿using AutoMapper;
using PortalStore.Core.Entity;
using PortalStore.DTO.Category;
using PortalStore.DTO.Customer;
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
        }
    }
}
