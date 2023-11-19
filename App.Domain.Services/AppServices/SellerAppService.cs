using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Services.AppServices
{
    public class SellerAppService : ISellerAppService
    {
        private readonly ISellerService _sellerService;
        private readonly IShopService _shopService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductPictureService _productPictureService;
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPriceService _priceService;
        private readonly IWageService _wageService;
        public SellerAppService(IWageService wageService, IPriceService priceService, ICategoryService categoryService, IProductService productService, IPictureService pictureService, ISellerService sellerService, IShopService shopService, IInventoryService inventoryService, IProductPictureService productPictureService)
        {
            _sellerService = sellerService;
            _shopService = shopService;
            _inventoryService = inventoryService;
            _productPictureService = productPictureService;
            _pictureService = pictureService;
            _productService = productService;
            _categoryService = categoryService;
            _priceService = priceService;
            _wageService = wageService;
        }

        public Seller FindSeller(int UserId, CancellationToken cancellation)
        {
            var aSellers = _sellerService.ByUserId(UserId, cancellation);

            return aSellers;
        }

        public Shop FindShop(int SellerId, CancellationToken cancellation)
        {
            var aShopd = _shopService.GetBySellerId(SellerId, cancellation);

            if(aShopd == null)
                return null; 

            if(aShopd.IsDeleted == false)
                return aShopd;

            return null;
        }

        public async Task<List<ShopDashBordDto>> CreateAShop(ShopDashBordDto shop, CancellationToken cancellation)
        {
            var shopDto = new List<ShopDashBordDto>();
            var newShopList = new ShopDashBordDto
            {
                SellerId = shop.SellerId,
                ShopName = shop.ShopName
            };

            shopDto.Add(newShopList);

            var newShop = new Shop()
            {
                Name = shop.ShopName,
                Inventories = null,
                Seller = null,
                SellerId = shop.SellerId,
                TimeOfCreate = DateTime.Now,
                IsDeleted = false,
            };

            await _shopService.Add(newShop, cancellation);

            return shopDto;
        }

        public List<ShopDashBordDto> FillTheDto(Shop shop, CancellationToken cancellation) // call -> PictureUrl, ProductTitle, ProductCategory
        {
            var SellerShop = new List<ShopDashBordDto>();
            var allInventorys = _inventoryService.GetByShopId(shop.Id ?? default(int) ,cancellation);

            foreach(var inventory in allInventorys)
            {
                var newProduct = new ShopDashBordDto
                {
                    SellerId = shop.SellerId ?? default(int),
                    PictureUrl = PictureUrl(inventory.ProductId ?? default(int) ,cancellation),
                    ProductTitle = ProductTitle(inventory.ProductId ?? default(int), cancellation),
                    ProductCategory = ProductCategory(inventory.ProductId ?? default(int), cancellation),
                    InventoryQnt = inventory.Qnt,
                    ProdductPrice = ProdductPrice(inventory.PriceId ?? default(int), cancellation),
                    wage = SellerWage(shop.SellerId ?? default(int), cancellation)
                };

                SellerShop.Add(newProduct);
            }

            return (SellerShop);
        }

        private string PictureUrl(int ProductId ,CancellationToken cancellation)
        {
            var allProductPricture = _productPictureService.GetByProducId(ProductId, cancellation);

            if(allProductPricture != null)
            {
                foreach (var product in allProductPricture)
                {
                    var picture = _pictureService.GetById(product.PictureId, cancellation).Result;
                    return picture.Url;
                }
            }
            
            return "hello";
        }

        public string ProductTitle(int ProductId, CancellationToken cancellation)
        {
            var product = _productService.GetById(ProductId, cancellation).Result;

            return product.Title;
        }

        public string ProductCategory(int ProductId, CancellationToken cancellation)
        {
            var product = _productService.GetById(ProductId, cancellation).Result;
            var category = _categoryService.GetById(product.CategoryId ?? default(int), cancellation).Result;

            return category.Title;
        }
        
        public int ProdductPrice(int PriceId, CancellationToken cancellation)
        {
            var price = _priceService.GetById(PriceId, cancellation).Result;

            return price.ProdutPrice;
        }
        
        public int SellerWage(int Sellerid, CancellationToken cancellation)
        {
            var wage = _wageService.GetAllBySellerId(Sellerid, cancellation).Result;

            foreach (var w in wage)
            {
                return w.HowMuch;
            }

            return 0;
        }

    }
}
