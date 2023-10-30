using App.Domain.Core.Models.DTOs;
using App.Domain.Core.Models.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infrastructure.DataAccess.Mapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //for add part
            CreateMap<AddressDtoInput, Address>();
            CreateMap<AuctionDtoInput, Auction>();
            CreateMap<CartDtoInput, Cart>();
            CreateMap<CategoryDtoInput, Category>();
            CreateMap<CommentDtoInput, Comment>();
            CreateMap<PictureDtoInput, Pictoure>();
            CreateMap<PriceDtoInput, Price>();
            CreateMap<ProductDtoInput, Product>();
            CreateMap<ShopDtoInput, Shop>();
            CreateMap<UserDtoInput, User>();
            CreateMap<WageDtoInput, Wage>();

            //for get part
            CreateMap<Address, AddressDtoOutPut>();
            CreateMap<Auction, AuctionDtoOutput>();
            CreateMap<Cart, CartDtoOutput>();
            CreateMap<Category, CategoryDtoOutput>();
            CreateMap<Comment, CommentDtoOutput>();
            CreateMap<Pictoure, PictureDtoOutput>();
            CreateMap<Price, PriceDtoOutput>();
            CreateMap<Product, ProductDtoOutput>();
            CreateMap<Shop, ShopDtoOutput>();
            CreateMap<User, UserDtoOutput>();
            CreateMap<Wage, WageDtoOutput>();
        }
    }
}
