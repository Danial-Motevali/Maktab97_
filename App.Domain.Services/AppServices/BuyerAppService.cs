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
        public BuyerAppService(
             IPriceService priceService 
            ,ICategoryService categoryService
            , IPictureService pictureService
            , IProductPictureService productPictureService
            , IProductService productService
            ,  IShopService shopService
            , IInventoryService inventoryService
            , ISellerService sellerService
            , IUserServices userServices)
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
            var aBuyerSearchDto = new BuyerSearchDto();
            var aSeller = _sellerService.ByUserId(user.Id, cancellation);
            var aShop = _shopService.GetBySellerId(aSeller.Id, cancellation);
            var selllerInventory = _inventoryService.GetByShopId(aShop.Id ?? default(int), cancellation);
            var aProduct = new Product();
            var allProductPicture = new List<ProductPicture>();
            var productCategory = new Category();
            var pictureList = new List<Picture>();
            var inventoryPrice = new Price();

            foreach(var inventory in selllerInventory)
            {
                aProduct = await _productService.GetById(inventory.ProductId, cancellation);
                allProductPicture =  _productPictureService.GetByProducId(aProduct.Id ?? default(int), cancellation);
                productCategory = await _categoryService.GetById(aProduct.CategoryId ?? default(int), cancellation);

                foreach(var picture in allProductPicture)
                {
                    pictureList.Add(await _pictureService.GetById(picture.PictureId, cancellation));
                }

                foreach(var picture in pictureList)
                {
                    aBuyerSearchDto.ProductUrl = picture.Url;
                    break;
                }

                inventoryPrice = await _priceService.GetById(inventory.PriceId ?? default(int), cancellation);

                aBuyerSearchDto.SellerId = aSeller.Id;
                aBuyerSearchDto.ProductId = aProduct.Id ?? default (int);
                aBuyerSearchDto.ShopId = aShop.Id?? default(int);
                aBuyerSearchDto.ProductPrice = inventoryPrice.ProdutPrice;
                aBuyerSearchDto.Category = productCategory.Title;
                aBuyerSearchDto.Category = productCategory.Title;
                aBuyerSearchDto.ProductTitle = aProduct.Title;

                newBuyerSearchDto.Add(aBuyerSearchDto);
            }

            return newBuyerSearchDto;
        }

        public async Task<List<BuyerSearchDto>> SearchWithCategory(Category Category, CancellationToken cancellation)
        {
            var targetInventorys = await FindInventorybyCategoryAsync(Category, cancellation);
            var aBuyerSearchDto = new BuyerSearchDto();
            var newBuyerSearchDto = new List<BuyerSearchDto>();

            foreach (var inventory in targetInventorys)
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
    }
}
