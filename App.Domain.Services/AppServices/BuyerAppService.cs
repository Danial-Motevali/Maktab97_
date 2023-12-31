﻿using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Entities;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Core.Models.Identity.Role;
using App.Domain.Services.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging.Abstractions;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Claims;
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
        private readonly ICommentService _commentService;
        private readonly IOrderService _orderService;
        private readonly IInventoryOrederService _inventoryOrederService;
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
            , ICommentService commentService
            , IOrderService orderService
            , IInventoryOrederService inventoryOrederService
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
            _commentService = commentService;
            _orderService = orderService;
            _inventoryOrederService = inventoryOrederService;
        }


        public async Task<List<BuyerSearchDto>> ShowAllProduct(CancellationToken cancellation)
        {
            var searchDto = new List<BuyerSearchDto>();
            var allCategory = _categoryService.GetAll(cancellation);

            foreach(var category in allCategory)
            {
                searchDto.AddRange(await SearchWithCategory(category, cancellation));
            }

            return searchDto;
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
            var selllerInventory = _inventoryService.GetByShopId(aShop.Id, cancellation);
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
                    allProductPicture = _productPictureService.GetByProducId(aProduct.Id, cancellation);
                    productCategory = await _categoryService.GetById(aProduct.CategoryId ?? default(int), cancellation);

                    foreach (var picture in allProductPicture)
                    {
                        pictureList.Add(await _pictureService.GetById(picture.PictureId ?? default(int), cancellation));
                    }

                    foreach (var picture in pictureList)
                    {
                        aBuyerSearchDto.ProductUrl = picture.Url;
                        break;
                    }

                    inventoryPrice = await _priceService.GetById(inventory.PriceId ?? default(int), cancellation);

                    aBuyerSearchDto.SellerId = aSeller.Id;
                    aBuyerSearchDto.ProductId = aProduct.Id;
                    aBuyerSearchDto.ShopId = aShop.Id;
                    aBuyerSearchDto.ProductPrice = inventoryPrice.ProdutPrice ?? default(int);
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
                if (inventory.IsDeleted == true)
                    continue;

                var aBuyerSearchDto = new BuyerSearchDto();
                if (inventory.AuctionId == null)
                {
                    var aPrice = await _priceService.GetById(inventory.PriceId ?? default(int), cancellation);
                    var Picture = await FindPictureWithProductId(inventory.ProductId ?? default(int), cancellation);
                    var aProduct = await _productService.GetById(inventory.ProductId ?? default(int), cancellation);
                    var aSeller = await FindSellerIdWithShopId(inventory.ShopId ?? default(int), cancellation);


                    aBuyerSearchDto.ProductId = inventory.ProductId ?? default(int);
                    aBuyerSearchDto.ProductPrice = aPrice.ProdutPrice ?? default(int);
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
                allInventory.AddRange(await _inventoryService.GetByProductId(product.Id, cancellation));
            }

            return allInventory;
        }
        
        public async Task<string> FindPictureWithProductId(int ProductId, CancellationToken cancellation)
        {
            var allProductPicture = _productPictureService.GetByProducId(ProductId, cancellation);
            var url = new Picture();

            foreach(var picture in allProductPicture)
            {
                url = await _pictureService.GetById(picture.PictureId ?? default(int), cancellation);

                return url.Url;
            }

            return null;
        }

        public async Task<User> FindSellerIdWithShopId(int shopId, CancellationToken cancellation)
        {
            var aShop = await _shopService.GetById(shopId, cancellation);
            var aSeller = await _sellerService.GetById(aShop.SellerId ?? default(int), cancellation);
            var aUser = await _userServices.GetById(aSeller.UserId ?? default(int), cancellation);

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
            var allAuction = await FindAuctionWithInventory(cancellation);
            var activeAuction = new List<AuctionDto>();

            if (allAuction.Count() == 0)
                return null;

            foreach(var auction in allAuction)
            {
                if (auction.IsActive == false)
                    continue;

                if(DateTime.Compare(auction.TimeOfEnd??default(DateTime), DateTime.Now) <= 0 )
                {
                    auction.IsActive = false;

                    await _auctionService.Update(auction.Id ??default(int), auction, cancellation);
                }
            }

            foreach (var auction in allAuction)
            {
                var newAuctionDto = new AuctionDto();

                if (auction.IsActive == true && auction.TimeOfEnd != DateTime.Now)
                {
                    newAuctionDto.AuctionId = auction.Id;
                    newAuctionDto.IsActive = true;
                    newAuctionDto.LastPrice = auction.LastPrice;
                    newAuctionDto.TimeOfEnd = auction.TimeOfEnd;
                    newAuctionDto.ProductName = await FindProductName(auction, cancellation);
                    newAuctionDto.TimeOfStart = auction.TimeOfStart;
                    newAuctionDto.SellerId = auction.SellerId;
                    newAuctionDto.ParentId = auction.ParentId;

                    activeAuction.Add(newAuctionDto);
                }
            }

            return activeAuction;
        }

        public async Task<List<Auction>> FindAuctionWithInventory(CancellationToken cancellation)
        {
            var allInventory = _inventoryService.GetAll(cancellation);
            var allAuction = new List<Auction>();

            foreach(var inventory in allInventory)
            {
                if(inventory.AuctionId != null)
                {
                    allAuction.Add(await _auctionService.GetById(inventory.AuctionId ??default(int), cancellation));
                }
            }

            return allAuction;
        }

        public async Task<string> FindProductName(Auction auction, CancellationToken cancellation)
        {
            var aInventory = _inventoryService.GetByAuctionId(auction.Id??default(int), cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);

            return aProduct.Title;
        }

        public async Task<bool> AddNewPrice(int UserId, int newPrice, int AuctionId, CancellationToken cancellation)
        {
            var aAuction = await _auctionService.GetById(AuctionId, cancellation);
            var aInventory = _inventoryService.GetByAuctionId(AuctionId, cancellation);
            var newAuction = new Auction();

            if (aAuction.LastPrice < newPrice && aAuction.ParentId == null)
            {
                aAuction.IsActive = false;

                await _auctionService.Update(aAuction.Id??default(int), aAuction, cancellation);

                newAuction.LastPrice = newPrice;
                newAuction.ParentId = aAuction.Id;
                newAuction.SellerId = aAuction.SellerId ?? default(int);
                newAuction.IsActive = aAuction.IsActive;
                newAuction.TimeOfStart = aAuction.TimeOfStart ?? default(DateTime);
                newAuction.TimeOfEnd = aAuction.TimeOfEnd ?? default(DateTime);
                newAuction.UserId = UserId;
                newAuction.WinnerId = aAuction.WinnerId;

                await _auctionService.Add(newAuction, cancellation);

                aInventory.AuctionId = newAuction.Id;

                await _inventoryService.Update(aInventory.Id, aInventory, cancellation);

                return true;

            } else if (aAuction.LastPrice < newPrice && aAuction.ParentId != null)
            {
                aAuction.IsActive = false;

                await _auctionService.Update(aAuction.Id ?? default(int), aAuction, cancellation);

                newAuction.LastPrice = newPrice;
                newAuction.ParentId = aAuction.ParentId;
                newAuction.SellerId = aAuction.SellerId ?? default(int);
                newAuction.IsActive = aAuction.IsActive;
                newAuction.TimeOfStart = aAuction.TimeOfStart ?? default(DateTime);
                newAuction.TimeOfEnd = aAuction.TimeOfEnd ?? default(DateTime);
                newAuction.UserId = UserId;

                await _auctionService.Add(newAuction, cancellation);

                aInventory.AuctionId = newAuction.Id;

                await _inventoryService.Update(aInventory.Id, aInventory, cancellation);

                return true;
            }


            return false;
        }



        public async Task<List<BuyerCartDto>> Cart(Buyer buyer, CancellationToken cancellation)
        {
            var newListCartDto = new List<BuyerCartDto>();
            var allCart = await _cartService.GetByBuyerId(buyer.Id, cancellation);

            if (allCart != null)
            {
                foreach (var cart in allCart)
                {
                    if(cart.IsActive == true)
                    {
                        var newCart = new BuyerCartDto();

                        newCart.ProdutName = await ProdutNameByCartId(cart, cancellation);
                        newCart.ProductPrice = await PriceByCart(cart, cancellation);
                        newCart.BuyerId = cart.BuyerId;
                        newCart.ProductId = await ProductByCart(cart, cancellation);
                        newCart.Url = await PictureByCart(cart, cancellation);
                        newCart.CartId = cart.Id;
                        newCart.InventoryId = cart.InventoryId;

                        newListCartDto.Add(newCart);
                    }
                }
            }

            return newListCartDto;
        }

        public async Task<string> PictureByCart(Cart cart, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(cart.InventoryId??default(int), cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);
            var allProductPicture = _productPictureService.GetByProducId(aProduct.Id, cancellation);

            foreach(var product in allProductPicture)
            {
                var picture = await _pictureService.GetById(product.PictureId??default(int), cancellation);

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
            var aInventory = await _inventoryService.GetById(cart.InventoryId??default(int), cancellation);
            var aPrice = await _priceService.GetById(aInventory.PriceId??default(int), cancellation);

            return aPrice.ProdutPrice??default(int);
        }

        public async Task<int> ProductByCart(Cart cart, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(cart.InventoryId??default(int), cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);

            return aProduct.Id;
        }



        public async Task<bool> AddOrder(List<BuyerCartDto> input, CancellationToken cancellation)
        {
            foreach(var cart in input)
            {
                await DeActiveCart(cart.CartId??default(int), cancellation);
                await CreateNewOrder(cart.BuyerId ?? default(int), cart.InventoryId ?? default(int), cancellation);
            }

            return true;
        }

        public async Task<bool> CreateNewOrder(int BuyerId, int InventoryId, CancellationToken cancellation)
        {
            var newProOrder = new InventoryOreder();
            var newOrder = new Order();
            var aInventory = await _inventoryService.GetById(InventoryId, cancellation);
            var aProduct = await _productService.GetById(aInventory.ProductId, cancellation);

            newOrder.BuyerId = BuyerId;
            newOrder.IsDeleted = false;

            await _orderService.Add(newOrder, cancellation);

            newProOrder.IsDeleted = false;
            newProOrder.OrederId = newOrder.Id;
            newProOrder.InventoryId = aInventory.Id;

            await _inventoryOrederService.Add(newProOrder, cancellation);

            return true;
        }

        public async Task<bool> DeActiveCart(int CartId, CancellationToken cancellation)
        {
            var aCart = await _cartService.GetById(CartId, cancellation);

            aCart.IsActive = false;
            await _cartService.Update(CartId, aCart, cancellation);

            return true;
        }

        public async Task<List<Comment>> ShowComment(Buyer Buyer, CancellationToken cancellation)
        {
            var allComment = _commentService.GetByBuyerId(Buyer.Id, cancellation);
            var activeComment = new List<Comment>();

            foreach(var comment in allComment)
            {
                if(comment.IsDeleted == false && comment.IsActive == true)
                    activeComment.Add(comment);
            }

            return activeComment;
        }

        public async Task<bool> AddComment(Comment input, CancellationToken cancellation)
        {
            input.TimeOfCreate = DateTime.Now;
            var createdComment = _commentService.Add(input, cancellation);

            return true;
        }

        public async Task<List<BuyerCartDto>> OrderetProdut(Buyer input, CancellationToken cancellation)
        {
            var allOrder = await _orderService.GetByBuyerId(input.Id, cancellation);
            var allInventoryOrder = new List<InventoryOreder>();
            var orderedProduct = new List<BuyerCartDto>();

            foreach (var order in allOrder)
            {
                allInventoryOrder.AddRange(await _inventoryOrederService.GetByOrderId(order.Id, cancellation));
            }

            foreach(var inventory in allInventoryOrder)
            {
                var aBuyerCartDto = new BuyerCartDto();

                var aInventory = await _inventoryService.GetById(inventory.InventoryId??default(int), cancellation);
                var newBuyerCartDto = await OrderetProdutHelper(aInventory, cancellation);

                aBuyerCartDto.BuyerId = input.Id;
                aBuyerCartDto.InventoryId = inventory.InventoryId;
                aBuyerCartDto.ProductId = aInventory.ProductId;
                aBuyerCartDto.ProductPrice = newBuyerCartDto.ProductPrice;
                aBuyerCartDto.ProdutName = newBuyerCartDto.ProdutName;
                aBuyerCartDto.Url = newBuyerCartDto.Url;

                orderedProduct.Add(aBuyerCartDto);
            }

            return orderedProduct;
        }

        public async Task<BuyerCartDto> OrderetProdutHelper(Inventory input, CancellationToken cancellation)
        {
            var aBuyerCartDto = new BuyerCartDto();
            var aPrice = await _priceService.GetById(input.PriceId??default(int), cancellation);
            var aProduct = await _productService.GetById(input.ProductId, cancellation);
            var allProductPicture = _productPictureService.GetByProducId(aProduct.Id, cancellation);
            var allPicture = new Picture();

            foreach (var product in allProductPicture)
            {
                allPicture = await _pictureService.GetById(product.PictureId??default(int), cancellation); 
                aBuyerCartDto.Url = allPicture.Url;

                break;
            }

            aBuyerCartDto.ProductPrice = aPrice.ProdutPrice;
            aBuyerCartDto.ProdutName = aProduct.Title;

            return aBuyerCartDto;
        }

        public async Task<bool> DeleteComment(int CommentId, CancellationToken cancellation)
        {
            var aComment = await _commentService.GetById(CommentId, cancellation);

            aComment.IsDeleted = true;

            await _commentService.Update(CommentId ,aComment, cancellation);

            return true;
        }

        public async Task<List<ProductHistoryDto>> FuildBuyerDto(int UserId, CancellationToken cancellation)
        {
            var newBuyerUserCartDto = new List<ProductHistoryDto>();
            var aBuyer = _buyerService.ByUserId(UserId, cancellation);
            var allCart = await _cartService.GetByBuyerId(aBuyer.Id, cancellation);

            if (allCart != null)
            {
                foreach (var cart in allCart)
                {
                    if (cart.IsActive == false)
                    {
                        var newCart = new ProductHistoryDto();

                        newCart.Title = await ProdutNameByCartId(cart, cancellation);
                        newCart.Price = await PriceByCart(cart, cancellation);
                        newCart.Url = await PictureByCart(cart, cancellation);

                        newBuyerUserCartDto.Add(newCart);
                    }
                }
            }

            return newBuyerUserCartDto;
        }

        public async Task<List<AuctionDashBordDto>> FuilAuctionDto(int UserId, CancellationToken cancellation)
        {
            //all auction that connect to inventory
            var allAuction = await BuyerIsIn(UserId, cancellation);
            var result = new List<AuctionDashBordDto>();
            var dto = new AuctionDashBordDto();

            foreach(var auction in allAuction)
            {
                dto = new AuctionDashBordDto();

                //find picture url from auction
                var ainventroy = _inventoryService.GetByAuctionId(auction.Id??default(int), cancellation);
                var allPictureProduct = _productPictureService.GetByProducId(ainventroy.ProductId??default(int), cancellation).First();
                var aPicture = await _pictureService.GetById(allPictureProduct.PictureId??default(int), cancellation);
                dto.PictureUrl = aPicture.Url;

                //find producttitle from auction
                var aProduct = await _productService.GetById(ainventroy.ProductId, cancellation);
                dto.ProductTitle = aProduct.Title;

                dto.LastPrice = auction.LastPrice??default(int);

                dto.AuctionId = auction.Id??default(int);

                if(auction.UserId == UserId)
                {
                    dto.IsActive = true;
                }
                else
                {
                    dto.IsActive = false;
                }

                result.Add(dto);
            }

            return result;
        }

        //find all the auction that buyer add new price
        public async Task<List<Auction>> BuyerIsIn(int userId, CancellationToken cancellation)
        {
            var result = new List<Auction>();
            var allAuction = _auctionService.GetAll(cancellation);
            var allInventory = _inventoryService.GetAll(cancellation);

            foreach (var auction in allAuction)
            {
                var mark = allInventory.FirstOrDefault(x => x.AuctionId == auction.Id);

                if (mark == null)
                    continue;

                if(auction.UserId == userId )
                    result.Add(auction);
            }

            return result;
        }

        public async Task<List<AuctionHistoryDto>> AActionHistory(int AuctionId, CancellationToken cancellation)
        {
            var aAuction = await _auctionService.GetById(AuctionId, cancellation);
            var allAuction = new List<AuctionHistoryDto>();
            var newAuctionDto = new AuctionHistoryDto();

            if (aAuction.ParentId == null)
            {
                newAuctionDto = new AuctionHistoryDto();

                newAuctionDto.LastPrice = aAuction.LastPrice;

                allAuction.Add(newAuctionDto);

                return allAuction;
            }
            else
            {
                newAuctionDto = new AuctionHistoryDto();

                var parentAuction = await _auctionService.GetById(aAuction.ParentId ?? default(int), cancellation);
                newAuctionDto.LastPrice = parentAuction.LastPrice;

                allAuction.Add(newAuctionDto);

                var auctionWithParent = await _auctionService.GetByParentId(aAuction.ParentId ?? default(int), cancellation);
                foreach (var auction in auctionWithParent)
                {
                    newAuctionDto = new AuctionHistoryDto();

                    newAuctionDto.LastPrice = auction.LastPrice;

                    if (auction.UserId != null)
                    {
                        var Buyer = await _userServices.GetById(auction.UserId ?? default(int), cancellation);

                        newAuctionDto.BuyerName = Buyer.UserName;
                    }
                    else
                    {
                        newAuctionDto.BuyerName = "null";
                    }

                    allAuction.Add(newAuctionDto);
                }

                return allAuction;
            }
        }
    }
    
}
