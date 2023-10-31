using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Services.Services;
using App.Infrastructure.DataAccess.Repository;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace UI
{
    public static class DependencyInjection
    {
        public static void Infstracture(this IServiceCollection services)
        {
            //configure repository

            services.AddScoped<IAddressRepository, AddressRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IPictourRepository, PictureRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUSerRepository, UserRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IWageRepository, WageRepository>();

            //configure services

            services.AddScoped<IAddressService, AddressServic>();
            services.AddScoped<IAuctionService, AuctionServic>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoruService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IWageService, WageService>();

        }
    }
}
