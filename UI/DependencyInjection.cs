using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Services.AppServices;
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
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAuctionRepository, AuctionRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddScoped<IMedalRepository, MedalRepository>();
            services.AddScoped<IPictureRepository, PictureRepository>();
            services.AddScoped<IPriceRepository, PriceRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IShopRepository, ShopRepository>();
            services.AddScoped<IWageRepository, WageRepository>();
            services.AddScoped<IUserRepsitory, UserRepsitory>();
            services.AddScoped<IProductPicture, ProductPictureRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IInventoryOrderRepository, InventoryOrderRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();


            //configure services

            services.AddScoped<IAddressService, AddressServic>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAuctionService, AuctionServic>();
            services.AddScoped<IBuyerService, BuyerService>();
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICommentService, CommentService>();
            services.AddScoped<IInventoryService, InventoryService>();
            services.AddScoped<IMedalService, MedalService>();
            services.AddScoped<IPictureService, PictureService>();
            services.AddScoped<IPriceService, PriceService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISellerService, SellerService>();
            services.AddScoped<IShopService, ShopService>();
            services.AddScoped<IWageService, WageService>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IProductPictureService, ProductPictureService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IInventoryOrederService, InventoryOrederService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IUserRoleService, UserRoleService>();


            //configure app services

            services.AddScoped<IAdminAppServices, AdminAppServices>();
            services.AddScoped<IAccountAppService, AccountAppService>();
            services.AddScoped<ISellerAppService, SellerAppService>();
            services.AddScoped<IBuyerAppService, BuyerAppService>();
        }
    }
}
