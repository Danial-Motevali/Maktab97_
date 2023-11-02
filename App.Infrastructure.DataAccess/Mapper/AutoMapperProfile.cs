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
            CreateMap<AddressDtoInput, Address>().ReverseMap();
            CreateMap<AuctionDtoInput, Auction>().ReverseMap();
            CreateMap<CartDtoInput, Cart>().ReverseMap();
            CreateMap<CategoryDtoInput, Category>().ReverseMap();
            CreateMap<CommentDtoInput, Comment>().ReverseMap();
            CreateMap<PictureDtoInput, Pictoure>().ReverseMap();
            CreateMap<PriceDtoInput, Price>().ReverseMap();
            CreateMap<ProductDtoInput, Product>().ReverseMap();
            CreateMap<ShopDtoInput, Shop>().ReverseMap();
            CreateMap<UserDtoInput, User>().ReverseMap();
            CreateMap<WageDtoInput, Wage>().ReverseMap();

            //for get part
            CreateMap<Address, AddressDtoOutPut>().ReverseMap();
            CreateMap<Auction, AuctionDtoOutput>().ReverseMap();
            CreateMap<Cart, CartDtoOutput>().ReverseMap();
            CreateMap<Category, CategoryDtoOutput>().ReverseMap();
            CreateMap<Comment, CommentDtoOutput>().ReverseMap();
            CreateMap<Pictoure, PictureDtoOutput>().ReverseMap();
            CreateMap<Price, PriceDtoOutput>().ReverseMap();
            CreateMap<Product, ProductDtoOutput>().ReverseMap();
            CreateMap<Shop, ShopDtoOutput>().ReverseMap();
            CreateMap<User, UserDtoOutput>().ReverseMap();
            CreateMap<Wage, WageDtoOutput>().ReverseMap();
        }
    }
}
