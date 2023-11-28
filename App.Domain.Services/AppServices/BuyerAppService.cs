using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Core.Models.Identity.Role;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace App.Domain.Services.AppServices
{
    public class BuyerAppService : IBuyerAppService
    {
        private readonly IUserServices _userServices;
        private readonly ISellerService _sellerService;
        private readonly IInventoryService _inventoryService;
        private readonly IShopService _shopService;
        private readonly IProductPictureService _productPictureService;
        private readonly IPictureService _pictureService;
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IPriceService _priceService;
        private readonly ICartService _cartService;
        private readonly IBuyerService _buyerService;
        private readonly IAuctionService _auctionService;
        public BuyerAppService(
             IPriceService priceService 
            ,ICategoryService categoryService
            , IPictureService pictureService
            , IProductPictureService productPictureService
            , IProductService productService
            ,  IShopService shopService
            , IInventoryService inventoryService
            , ISellerService sellerService
            , IUserServices userServices
            , ICartService cartService
            , IBuyerService buyerService
            , IAuctionService auctionService
            )
        {
            _userServices = userServices;
            _sellerService = sellerService;
            _inventoryService = inventoryService;
            _shopService = shopService;
            _productPictureService = productPictureService;
            _pictureService = pictureService;
            _categoryService = categoryService;
            _productService = productService;
            _priceService = priceService;
            _cartService = cartService;
            _buyerService = buyerService;
            _auctionService = auctionService;
        }


        public async Task<List<BuyerSearchDto>> Search(string search, CancellationToken cancellation)
        {
            var searchDto = new List<BuyerSearchDto>();
            var allUser = _userServices.GetAll(cancellation);
            var allCategory = _categoryService.GetAll(cancellation);

            foreach(var user in allUser)
            {
                if (user.UserName == search)
                    searchDto = SearchWithUserName(user, cancellation).Result;
            }

            foreach (var category in allCategory)
            {
                if(category.Title == search)
                    searchDto = SearchWithCategory(category, cancellation).Result;
            }

            return searchDto;
        }

        public async Task<List<BuyerSearchDto>> SearchWithUserName(User user, CancellationToken cancellation) // need test
        {
            var newBuyerSearchDto = new List<BuyerSearchDto>();
            
            var aSeller = _sellerService.ByUserId(user.Id, cancellation);
            var aShop = _shopService.GetBySellerId(aSeller.Id, cancellation);
            var selllerInventory = _inventoryService.GetByShopId(aShop.Id ?? default(int), cancellation);
            var aProduct = new Product();
            var allProductPicture = new List<ProductPicture>();
            var productCategory = new Category();
            var inventoryPrice = new Price();

            if (aShop.Inventories == null)
                return null;

            foreach(var inventory in aShop.Inventories)
            {
                var aBuyerSearchDto = new BuyerSearchDto();
                var pictureList = new List<Picture>();
                if (inventory.AuctionId == null)
                {
                    aProduct = await _productService.GetById(inventory.ProductId, cancellation);
                    allProductPicture = _productPictureService.GetByProducId(aProduct.Id ?? default(int), cancellation);
                    productCategory = await _categoryService.GetById(aProduct.CategoryId ?? default(int), cancellation);

                    foreach (var picture in allProductPicture)
                    {
                        pictureList.Add(await _pictureService.GetById(picture.PictureId, cancellation));
                    }

                    foreach (var picture in pictureList)
                    {
                        aBuyerSearchDto.ProductUrl = picture.Url;
                        break;
                    }

                    inventoryPrice = await _priceService.GetById(inventory.PriceId ?? default(int), cancellation);

                    aBuyerSearchDto.SellerId = aSeller.Id;
                    aBuyerSearchDto.ProductId = aProduct.Id ?? default(int);
                    aBuyerSearchDto.ShopId = aShop.Id ?? default(int);
                    aBuyerSearchDto.ProductPrice = inventoryPrice.ProdutPrice;
                    aBuyerSearchDto.Category = productCategory.Title;
                    aBuyerSearchDto.Category = productCategory.Title;
                    aBuyerSearchDto.ProductTitle = aProduct.Title;

                    newBuyerSearchDto.Add(aBuyerSearchDto);
                }
            }

            return newBuyerSearchDto;
        }

        public async Task<List<BuyerSearchDto>> SearchWithCategory(Category Category, CancellationToken cancellation)
        {
            var targetInventorys = await FindInventorybyCategoryAsync(Category, cancellation);
            var newBuyerSearchDto = new List<BuyerSearchDto>();

            foreach (var inventory in targetInventorys)
            {
                var aBuyerSearchDto = new BuyerSearchDto();
                if (inventory.AuctionId == null)
                {
                    var aPrice = await _priceService.GetById(inventory.PriceId ?? default(int), cancellation);
                    var Picture = await FindPictureWithProductId(inventory.ProductId ?? default(int), cancellation);
                    var aProduct = await _productService.GetById(inventory.ProductId ?? default(int), cancellation);
                    var aSeller = await FindSellerIdWithShopId(inventory.ShopId ?? default(int), cancellation);


                    aBuyerSearchDto.ProductId = inventory.ProductId ?? default(int);
                    aBuyerSearchDto.ProductPrice = aPrice.ProdutPrice;
                    aBuyerSearchDto.ProductUrl = Picture;
                    aBuyerSearchDto.ProductTitle = aProduct.Title;
                    aBuyerSearchDto.SellerId = aSeller.Id;
                    aBuyerSearchDto.SellerName = aSeller.UserName;
                    aBuyerSearchDto.Category = Category.Title;
                    aBuyerSearchDto.ShopId = inventory.ShopId ?? default(int);

                    newBuyerSearchDto.Add(aBuyerSearchDto);
                }
            }

            return newBuyerSearchDto;
        }

        public async Task<List<Inventory>> FindInventorybyCategoryAsync(Category category, CancellationToken cancellation)
        {
            var allProduct = await _productService.GetCategoryId(category.Id, cancellation);
            var allInventory = new List<Inventory>();

            foreach (var product in allProduct)
            {
                allInventory.AddRange(await _inventoryService.GetByProductId(product.Id ?? default(int), cancellation));
            }

            return allInventory;
        }
        
        public async Task<string> FindPictureWithProductId(int ProductId, CancellationToken cancellation)
        {
            var allProductPicture = _productPictureService.GetByProducId(ProductId, cancellation);
            var url = new Picture();

            foreach(var picture in allProductPicture)
            {
                url = await _pictureService.GetById(picture.PictureId, cancellation);

                return url.Url;
            }

            return null;
        }

        public async Task<User> FindSellerIdWithShopId(int shopId, CancellationToken cancellation)
        {
            var aShop = await _shopService.GetById(shopId, cancellation);
            var aSeller = await _sellerService.GetById(aShop.SellerId ?? default(int), cancellation);
            var aUser = await _userServices.GetById(aSeller.UserId, cancellation);

            return aUser;
        }





        public async Task<bool> AddToCart(Buyer buyer, int ProductId, int ShopId, CancellationToken cancellation)
        {
            var newCart = new Cart();
            var aInventory = await FindInventory(ProductId, ShopId, cancellation);

            newCart.InventoryId = aInventory.Id;
            newCart.IsActive = true;
            newCart.TimeOfCreate = DateTime.Now;
            newCart.BuyerId = buyer.Id;

            await _cartService.Add(newCart, cancellation);

            return true;
        }

        public async Task<Inventory> FindInventory(int ProductId, int ShopId, CancellationToken cancellation)
        {
            var shopInventory =  _inventoryService.GetByShopId(ShopId, cancellation);

            foreach (var inventory in shopInventory)
            {
                if(inventory.ProductId == ProductId)
                    return inventory;
            }

            return null;
        }

        public Buyer FindBuyer(int UserId, CancellationToken cancellation)
        {
            var aBuyer = _buyerService.ByUserId(UserId, cancellation);

            return aBuyer;
        }




        public async Task<List<AuctionDto>> Action(CancellationToken cancellation)
        {
            var allAuction = _auctionService.GetAll(cancellation);
            var activeAuction = new List<AuctionDto>();
            var newAuctionDto = new AuctionDto();

            if (allAuction == null)
                return null;

            foreach(var auction in allAuction)
            {
                if(auction.TimeOfEnd == DateTime.Now)
                {
                    auction.IsActive = false;

                    await _auctionService.Update(auction.Id ??default(int), auction, cancellation);
                }
            }

            foreach(var auction in allAuction)
            {
                if(auction.IsActive == true && auction.TimeOfEnd != DateTime.Now)
                {
                    newAuctionDto.IsActive = true;
                    newAuctionDto.LastPrice = auction.LastPrice;
                    newAuctionDto.TimeOfEnd = auction.TimeOfEnd;
                    newAuctionDto.TimeOfStart = auction.TimeOfStart;
                    newAuctionDto.SellerId = auction.SellerId;

                    activeAuction.Add(newAuctionDto);
                }
            }

            return activeAuction;
        }

        public async Task<bool> AddNewPrice(int newPrice, int AuctionId, CancellationToken cancellation)
        {
            var aAuction = await _auctionService.GetById(AuctionId, cancellation);

            if(aAuction == null)
                return false;

            if(aAuction.LastPrice >= newPrice && aAuction.TimeOfEnd != DateTime.Now)
            {
                aAuction.LastPrice = newPrice;
                await _auctionService.Update(aAuction.Id ?? default(int) ,aAuction, cancellation);

                return true;
            }

            return false;
        }



        public async Task<List<BuyerCartDto>> Cart(Buyer buyer, CancellationToken cancellation)
        {
            var newListCartDto = new List<BuyerCartDto>();
            var newCart = new BuyerCartDto();
            var allCart = await _cartService.GetByBuyerId(buyer.Id, cancellation);

            if (allCart != null)
            {
                foreach (var cart in allCart)
                {
                    newCart.ProdutName = await ProdutNameByCartId(cart, cancellation);
                    newCart.ProductPrice = await PriceByCart(cart, cancellation);
                    newCart.BuyerId = cart.BuyerId;
                    newCart.ProductId = await ProductByCart(cart, cancellation);
                    newCart.Url = await PictureByCart(cart, cancellation);

                    newListCartDto.Add(newCart);
                }
            }

            return newListCartDto;
        }

        public async Task<string> PictureByCart(Cart cart, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(cart.InventoryId??default(int), cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);
            var allProductPicture = _productPictureService.GetByProducId(aProduct.Id??default(int), cancellation);

            foreach(var product in allProductPicture)
            {
                var picture = await _pictureService.GetById(product.PictureId, cancellation);

                return picture.Url;
            }

            return null;
        }

        public async Task<string> ProdutNameByCartId(Cart cart, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(cart.InventoryId??default(int), cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);

            return aProduct.Title;
        }

        public async Task<int> PriceByCart(Cart cart, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(cart.Id, cancellation);
            var aPrice = await _priceService.GetById(aInventory.PriceId??default(int), cancellation);

            return aPrice.ProdutPrice;
        }

        public async Task<int> ProductByCart(Cart cart, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(cart.InventoryId??default(int), cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);

            return aProduct.Id??default(int);
        }

        public Task<bool> AddOrder(List<BuyerCartDto> input, CancellationToken cancellation)
        {
            throw new NotImplementedException();
        }
    }
}
