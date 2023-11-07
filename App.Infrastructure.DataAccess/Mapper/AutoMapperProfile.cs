using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
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
            CreateMap<AdminMyDtoInput, MyAdmin>().ReverseMap();
            CreateMap<AuctionDtoInput, Auction>().ReverseMap();
            CreateMap<BuyerDtoInput, Buyer>().ReverseMap();
            CreateMap<CartDtoInput, Cart>().ReverseMap();
            CreateMap<CategoryDtoInput, Category>().ReverseMap();
            CreateMap<CommentDtoInput, Comment>().ReverseMap();
            CreateMap<InventoryDtoInput, Inventory>().ReverseMap();
            CreateMap<MedalDtoInput, Medal>().ReverseMap();
            CreateMap<PictureDtoInput, Picture>().ReverseMap();
            CreateMap<PriceDtoInput, Price>().ReverseMap();
            CreateMap<ProductDtoInput, Product>().ReverseMap();
            CreateMap<SellerDtoInput, Seller>().ReverseMap();
            CreateMap<ShopDtoInput, Shop>().ReverseMap();
            CreateMap<WageDtoInput, Wage>().ReverseMap();

            //for get part
            CreateMap<Address, AddressDtoOutput>().ReverseMap();
            CreateMap<MyAdmin, AdminMyDtoOutput>().ReverseMap();
            CreateMap<Auction, AuctionDtoOutput>().ReverseMap();
            CreateMap<Buyer, BuyerDtoOutput>().ReverseMap();
            CreateMap<Cart, CartDtoOutput>().ReverseMap();
            CreateMap<Category, CategoryDtoOutput>().ReverseMap();
            CreateMap<Comment, CommentDtoOutput>().ReverseMap();
            CreateMap<Inventory, InventoryDtoOutput>().ReverseMap();
            CreateMap<Medal, MedalDtoOutput>().ReverseMap();
            CreateMap<Picture, PictureDtoOutput>().ReverseMap();
            CreateMap<Price, PriceDtoOutput>().ReverseMap();
            CreateMap<Product, ProductDtoOutput>().ReverseMap();
            CreateMap<Seller, SellerDtoOutput>().ReverseMap();
            CreateMap<Shop, ShopDtoOutput>().ReverseMap();
            CreateMap<Wage, WageDtoOutput>().ReverseMap();
        }
    }
}
