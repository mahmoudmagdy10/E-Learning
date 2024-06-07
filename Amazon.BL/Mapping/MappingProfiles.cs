using Amazon.BL.Models;
using Amazon.DAL.Entity;
using AutoMapper;
using ConsoleApp1.Entities;

namespace Amazon.BL.Mapping
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Products, ProductVM>();
            CreateMap<ProductVM, Products>();
            
            CreateMap<Brands, BrandVM>();
            CreateMap<BrandVM, Brands>();
            
            CreateMap<Categories, CategoryVM>();
            CreateMap<CategoryVM, Categories>();

            CreateMap<Cart, CartVM>();
            CreateMap<CartVM, Cart>();

        }
    }
}
