using App.Domain.Core.Contract.Repository;
using App.Infrastructure.DataAccess.Repository;
using AutoMapper;
using System.Runtime.CompilerServices;

namespace UI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddService(this IServiceCollection services)
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

            return services;
        }
    }
}
