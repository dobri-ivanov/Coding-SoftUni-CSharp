using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile() 
        {
            //Users
            this.CreateMap<ImportUsersDTO, User>();

            //Products
            this.CreateMap<ImportProductsDTO, Product>();

            //Categories
            this.CreateMap<ImportCategoriesDTO, Category>();

            //CategoryProducts
            this.CreateMap<ImportCategoriesProductsDTO, CategoryProduct>();
        }
    }
}
