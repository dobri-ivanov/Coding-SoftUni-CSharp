﻿using AutoMapper;
using ProductShop.DTOs.Import;
using ProductShop.Models;

namespace ProductShop
{
    public class ProductShopProfile : Profile
    {
        public ProductShopProfile()
        {
            this.CreateMap<ImportUsersDto, User>();
            this.CreateMap<ImportProductsDto, Product>();
        }
    }
}