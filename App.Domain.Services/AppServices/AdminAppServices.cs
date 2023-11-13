﻿using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Identity.Entites;

namespace App.Domain.Services.AppServices
{
    public class AdminAppServices : IAdminAppServices
    {
        private readonly IUserServices _userServices;
        private readonly ISellerService _sellerSercies;
        private readonly IBuyerService _buyerService;
        private readonly IShopService _shopServices;
        private readonly ICommentService _commentService;
        private readonly IInventoryService _inventoryService;
        private readonly IProductService _productService;
        private readonly IWageService _wageService;
        public AdminAppServices(IUserServices userServices, ISellerService sellerService, IShopService shopService, IInventoryService inventoryService, IProductService productService, IBuyerService buyerService, ICommentService commentService, IWageService wageService)
        {
            _userServices = userServices;
            _sellerSercies = sellerService;
            _shopServices = shopService;
            _inventoryService = inventoryService;
            _inventoryService = inventoryService;
            _productService = productService;
            _buyerService = buyerService;
            _commentService = commentService;
            _wageService = wageService;
        }

        //Buyer Dashbord
        public int FindBuyer(int UserId, CancellationToken cancellation)
        {
            var allBuyers = _buyerService.GetAll(cancellation);

            foreach (var buyer in allBuyers)
            {
                if (buyer.UserId == UserId)
                    return buyer.Id;
            }

            return 0;
        }

        public bool DeleteComment(int CommenttId, CancellationToken cancellation)
        {
            var rsult = _commentService.Delete(CommenttId, cancellation);

            if (rsult.IsCompleted)
            {
                return true;
            }

            return false;
        }

        //public List<Comment> FindCommentByUserId(int BuyerId, CancellationToken cancellation)
        //{
        //    return _commentService.GetAllByBuyerId(BuyerId, cancellation);
        //}

        public List<User> FindAlBuyer(CancellationToken cancellation)
        {
            var allUser = _userServices.GetAll(cancellation);
            var allSeller = _buyerService.GetAll(cancellation);
            var sellerUser = new List<User>();

            foreach (var user in allUser)
            {
                foreach (var seller in allSeller)
                {
                    if (seller.UserId == user.Id && user.IsDeleted == false)
                        sellerUser.Add(user);
                }
            }

            return sellerUser;
        }




        //Seller Dashbord

        public bool DeleteProduct(int ProductId, CancellationToken cancellation)
        {
            var rsult = _productService.Delete(ProductId, cancellation);

            if (rsult.IsCompleted)
            {
                return true;
            }

            return false;

        }

        public List<User> FindAllSeller(CancellationToken cancellation)
        {
            var allSeller = _sellerSercies.GetAll(cancellation);

            foreach (var user in allSeller)
            {
                foreach (var seller in allSeller)
                {
                    if (seller.UserId == user.Id && user.IsDeleted == false)
                        sellerUser.Add(user);
                }
            }

            return sellerUser;
        }
        public List<Inventory> FindInventoryByShopId(int ShopSId, CancellationToken cancellation)
        {
            var allInventory = _inventoryService.GetAll(cancellation);
            var myShopInventory = new List<Inventory>();

            foreach (var inventory in allInventory)
            {
                if (inventory.ShopId == ShopSId && inventory.IsDeleted == false)
                    myShopInventory.Add(inventory);
            }

            return myShopInventory;
        }

        public List<Product> FindProductByProductId(List<Inventory> SellerInventory, CancellationToken cancellation)
        {
            var allProduct = _productService.GetAll(cancellation);
            var myProduct = new List<Product>();

            foreach (var invenoty in SellerInventory)
            {
                foreach (var product in allProduct)
                {
                    if (invenoty.ProductId == product.Id && invenoty.IsDeleted == false)
                        myProduct.Add(product);
                }
            }

            return myProduct;
        }

        public int FindSeller(int UserId, CancellationToken cancellation)
        {
            var allSeller = _sellerSercies.GetAll(cancellation);

            foreach (var seller in allSeller)
            {
                if (seller.UserId == UserId)
                    return seller.Id;
            }

            return 0;
        }

        public int FindSellerShop(int sellerSId, CancellationToken cancellation)
        {
            var allShops = _shopServices.GetAll(cancellation);

            foreach (var shop in allShops)
            {
                if (shop.SellerId == sellerSId && shop.IsDeleted == false)
                    return shop.Id;
            }

            return 0;
        }

        public int ShowSellerWage(int SellerId, CancellationToken cancellation)
        {
            var allSellerWage = _wageService.GetAllBySellerId(SellerId, cancellation).Result;
            int sellerWage = 0;

            foreach (var wage in allSellerWage)
            {
                sellerWage = sellerWage + wage.HowMuch;
            }

            return sellerWage;
        }
    }
}
