using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using Hangfire;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Reflection.Metadata.Ecma335;

namespace App.Domain.Services.AppServices
{
    public class SellerAppService : ISellerAppService
    {
        private readonly AppSetting _appSetting;
        private readonly ISellerService _sellerService;
        private readonly IShopService _shopService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductPictureService _productPictureService;
        private readonly IPictureService _pictureService;
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;
        private readonly IPriceService _priceService;
        private readonly IWageService _wageService;
        private readonly IAuctionService _auctionService;
        private readonly IMedalService _medalService;
        public SellerAppService(AppSetting appSetting, IMedalService medalService, IAuctionService auctionService, IWageService wageService, IPriceService priceService, ICategoryService categoryService, IProductService productService, IPictureService pictureService, ISellerService sellerService, IShopService shopService, IInventoryService inventoryService, IProductPictureService productPictureService)
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
            _auctionService = auctionService;
            _medalService = medalService;
            _appSetting = appSetting;
        }

        public Seller FindSeller(int UserId, CancellationToken cancellation)
        {
            var aSellers = _sellerService.ByUserId(UserId, cancellation);

            return aSellers;
        }

        public Shop FindShop(int SellerId, CancellationToken cancellation)
        {
            var aShopd = _shopService.GetBySellerId(SellerId, cancellation);

            if (aShopd == null)
                return null;

            if (aShopd.IsDeleted == false)
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

            var createdShop = await _shopService.Add(newShop, cancellation);

            return shopDto;
        }

        public List<ShopDashBordDto> FillTheDto(Shop shop, CancellationToken cancellation) 
        {
            var SellerShop = new List<ShopDashBordDto>();
            var allInventorys = _inventoryService.GetByShopId(shop.Id, cancellation);

            foreach (var inventory in allInventorys)
            {
                if(inventory.PriceId != null && inventory.AuctionId == null && inventory.IsDeleted == false)
                {
                    var newProduct = new ShopDashBordDto
                    {
                        SellerId = shop.SellerId ?? default(int),
                        PictureUrl = PictureUrl(inventory.ProductId ?? default(int), cancellation),
                        ProductTitle = ProductTitle(inventory.ProductId ?? default(int), cancellation),
                        ProductCategory = ProductCategory(inventory.ProductId ?? default(int), cancellation),
                        InventoryQnt = inventory.Qnt ?? default(int),
                        ProdductPrice = ProdductPrice(inventory.PriceId ?? default(int), cancellation),
                        wage = SellerWage(inventory.Id, cancellation),
                        ProductId = inventory.ProductId ?? default(int)
                    };

                    SellerShop.Add(newProduct);
                }
            }

            return (SellerShop);
        }

        private string PictureUrl(int ProductId, CancellationToken cancellation)
        {
            var allProductPricture = _productPictureService.GetByProducId(ProductId, cancellation);

            if (allProductPricture != null)
            {
                foreach (var product in allProductPricture)
                {
                    var picture = _pictureService.GetById(product.PictureId ?? default(int), cancellation).Result;
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

            if (price == null)
                return 0;

            return price.ProdutPrice ?? default(int);
        }

        public int SellerWage(int InventoryId, CancellationToken cancellation)
        {
            var wage = _wageService.GetAllByInventoyId(InventoryId, cancellation).Result;

            return wage.HowMuch;
        }


        public async Task<bool> AddProduct(AddProductDto input, Seller seller, CancellationToken cancellation)
        {
            var newProduct = new Product();
            var newInventory = new Inventory();
            var newPrice = new Price();
            var newPicture = new Picture();
            var newProductPicture = new ProductPicture();
            var newWage = new Wage();
            int sellerWage = 0;
            int categoryId = 1;
            var createdProduct = new Product();
            var createdPrice = new Price();
            var createdInventory = new Inventory();
            var createdWage = new Wage();
            var createdPicture = new Picture();
            var createdProductPicture = new ProductPicture();

            newProduct.Title = input.ProductTitle;
            newProduct.IsDeleted = false;

            if (input.ProductCategory != null)
            {
                var allCategory = _categoryService.GetAll(cancellation);

                foreach (var category in allCategory)
                {
                    if (category.Title == input.ProductCategory)
                        categoryId = category.Id;
                }

                newProduct.CategoryId = categoryId;

                createdProduct = await _productService.Add(newProduct, cancellation);
            }

            if (input.ProductPrice != null)
            {
                newPrice.ProdutPrice = input.ProductPrice ?? default(int);
                newPrice.IsDeleted = false;

                createdPrice = await _priceService.Add(newPrice, cancellation);
            }

            newInventory.IsDeleted = false;
            newInventory.ShopId = input.ShopId;
            newInventory.Qnt = input.Qnt;
            newInventory.ProductId = /*FindProductId(input, cancellation);*/ createdProduct.Id;
            if(input.ProductPrice != null)
            {
                newInventory.PriceId =  createdPrice.Id/*FindPriceId(input, cancellation)*/;
            };

            createdInventory = await _inventoryService.Add(newInventory, cancellation);


            newWage.IsDeleted = false;
            newWage.SellerId = seller.Id;
            newWage.HowMuch = await CaculeteWage(seller, input.ProductPrice ??default(int), cancellation);
            newWage.IsPaid = false;
            newWage.InventoryId = createdInventory.Id;

            createdWage = await _wageService.Add(newWage, cancellation);

            if(input.PictureUrl != null)
            {
                newPicture.Url = input.PictureUrl;
                newPicture.IsDeleted = false;

                createdPicture = await _pictureService.Add(newPicture, cancellation);

                newProductPicture.PictureId = FindPictureId(input, cancellation);
                newProductPicture.ProductId = createdProduct.Id; /*FindProductId(input, cancellation);*/

                createdProductPicture = await _productPictureService.Add(newProductPicture, cancellation);
            }

            return true;
        }

        public async Task<int> CaculeteWage(Seller seller, int price, CancellationToken cancellation)
        {
            var allUserMedal =  _medalService.GetBySellerId(seller.Id, cancellation);
            var markMedal = new Medal();
            var aWage = 0;
            var wagePercent = 0;

            foreach(var medal in allUserMedal)
            {
                if (medal.Rank == _appSetting.Rank2 && medal.IsExpired == false)
                {
                    markMedal = medal;
                    break;
                }else if(medal.Rank == _appSetting.Rank1 && medal.IsExpired == false)
                {
                    markMedal= medal;
                    break;
                }else if(medal.Rank == _appSetting.Rank0 && medal.IsExpired == false)
                {
                    markMedal = medal;
                    break;
                }
            }

            if(markMedal.Rank == "Gold")
            {
                wagePercent = _appSetting.Gold;
            }else if(markMedal.Rank == "Silver")
            {
                wagePercent = _appSetting.Silver;
            }
            else
            {
                wagePercent = _appSetting.Copper;
            }

            aWage = (int)Math.Round((decimal)(price * wagePercent) / 100);

            return aWage;
        }

        public int FindPictureId(AddProductDto add, CancellationToken cancellation)
        {
            var allPicture = _pictureService.GetAll(cancellation);

            foreach (var product in allPicture)
            {
                if (product.Url == add.PictureUrl)
                {
                    return product.Id;
                }
            }

            return 0;
        }

        //public int FindProductId(AddProductDto add, CancellationToken cancellation)
        //{
        //    var allProduct = _productService.GetAll(cancellation);

        //    foreach (var product in allProduct)
        //    {
        //        if (product.Title == add.ProductTitle)
        //        {
        //            return product.Id;
        //        }
        //    }

        //    return 0;
        //}

        //public int FindPriceId(AddProductDto input, CancellationToken cancellation)
        //{
        //    var allProduct = _priceService.GetAll(cancellation);

        //    foreach (var product in allProduct)
        //    {
        //        if (product.ProdutPrice == input.ProductPrice)
        //        {
        //            return product.Id;
        //        }
        //    }

        //    return 0;
        //}

        public async Task<bool> AddToAcuion(int ProductId, int SellerId, CancellationToken cancellation)
        {
            var productInInventorys = await _inventoryService.GetByProductId(ProductId, cancellation);
            var aShop = _shopService.GetBySellerId(SellerId, cancellation);
            var aInventory = new Inventory();
            var newAuction = new Auction();

            foreach (var inventory in productInInventorys)
            {
                if (inventory.ProductId == ProductId && inventory.ShopId == aShop.Id)
                {
                    aInventory = inventory;
                }
            }

            newAuction.TimeOfStart = DateTime.Now;
            newAuction.TimeOfEnd =  DateTime.Now.AddDays(1);
            newAuction.SellerId = SellerId;
            newAuction.LastPrice = 0;
            newAuction.ParentId = null;

            await _auctionService.Add(newAuction, cancellation);

            aInventory.AuctionId = newAuction.Id;

            await _inventoryService.Update(aInventory.Id ,aInventory, cancellation);

            var scedul = DateTime.Now.AddDays(1);
            var defultScedul = new DateTimeOffset(scedul);

             BackgroundJob.Schedule(() => EndAuction(SellerId, cancellation), defultScedul);

            return true;
        }

        public async Task EndAuction(int sellerId, CancellationToken cancellation)
        {
            var allAuction = await _auctionService.GetBySellerId(sellerId, cancellation);
            var specficAuction = new Auction();

            foreach(var auction in allAuction)
            {
                if(auction.TimeOfEnd == DateTime.Now)
                    specficAuction.IsActive = false;
            };

            await _auctionService.Update(specficAuction.Id ??default(int),specficAuction, cancellation);
        }

        public async Task<List<AuctionDashBordDto>> FillAuctionDto(Seller seller, CancellationToken cancellation)
        {
            var DtoList = new List<AuctionDashBordDto>();
            var allInventory = await InventoryHasAuction(seller.Id, cancellation);
            var allAuction = new List<Auction>();
            var aDto = new AuctionDashBordDto();

            //find all auctive auction
            foreach(var inventory in allInventory)
            {
                allAuction.Add(await _auctionService.GetById(inventory.AuctionId??default(int), cancellation));
            }
            
            //fild the auction dto
            foreach(var auction in allAuction)
            {
                aDto = new AuctionDashBordDto();

                aDto.AuctionId = auction.Id??default(int);
                aDto.TimeOfEnd = auction.TimeOfEnd??default(DateTime);
                aDto.LastPrice = auction.LastPrice ?? default(int);
                var helper = await FillAuctionDtoHelper(aDto, auction.Id ?? default(int), cancellation); //find product name , and product picture

                DtoList.Add(helper);
            }

            return DtoList;
        }

        //give all the inventorys that have auctionId
        public async Task<List<Inventory>> InventoryHasAuction(int sellerId, CancellationToken cancellation)
        {
            var aShop = _shopService.GetBySellerId(sellerId, cancellation);
            var allInventory = _inventoryService.GetByShopId(aShop.Id, cancellation);
            var markList = new List<Inventory>();

            foreach(var inventory in allInventory)
            {
                if (inventory.AuctionId != null)
                    markList.Add(inventory);
            }

            return markList;
        }

        //get a dto fild the missing part and return that dto
        public async Task<AuctionDashBordDto> FillAuctionDtoHelper(AuctionDashBordDto dto, int AuctionId, CancellationToken cancellation)
        {
            var aInventory = _inventoryService.GetByAuctionId(AuctionId, cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);
            var allProductPicture = _productPictureService.GetByProducId(aProduct.Id, cancellation);

            foreach(var item in allProductPicture)
            {
                var picture = await _pictureService.GetById(item.PictureId??default(int), cancellation);

                dto.PictureUrl = picture.Url;
                break;
            }

            dto.ProductTitle = aProduct.Title;
            dto.ProductId = aProduct.Id;

            return dto;
        }

        public Task<bool> UpdateTheAcuion(int AuctionId, bool DeleteAuction, int AddTheDays, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
