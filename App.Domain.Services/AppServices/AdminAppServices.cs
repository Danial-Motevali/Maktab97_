using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Admin;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Services.Services;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel;

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
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;
        private readonly IProductPictureService _productPictureService;
        private readonly IPictureService _pictureService;
        private readonly ICategoryService _categoryService;
        private readonly IPriceService _priceService;
        public AdminAppServices(IPriceService priceService, ICategoryService categoryService, IPictureService pictureService, IProductPictureService productPictureService, IRoleService roleService, IUserRoleService userRoleService, IUserServices userServices, ISellerService sellerService, IShopService shopService, IInventoryService inventoryService, IProductService productService, IBuyerService buyerService, ICommentService commentService, IWageService wageService)
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
            _roleService = roleService;
            _userRoleService = userRoleService;
            _productPictureService = productPictureService;
            _pictureService = pictureService;
            _categoryService = categoryService;
            _priceService = priceService;
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
        } // from Interface

        public async Task<bool> DeleteComment(int CommenttId, CancellationToken cancellation)
        {
            var aComment = await _commentService.GetById(CommenttId, cancellation);
            
            if(aComment.IsDeleted == false)
            {
                aComment.IsDeleted = true;

               await _commentService.Update(CommenttId ,aComment, cancellation);

               return true;
            }

            aComment.IsDeleted = false;
            await _commentService.Update(CommenttId , aComment, cancellation);

            return true;
        } // from Interface

        public List<Comment> FindCommentByUserId(int BuyerId, CancellationToken cancellation) // from Interface
        {
            var allComment = _commentService.GetByBuyerId(BuyerId, cancellation);

            return allComment;
        } 

        public List<User> FindAllBuyer(CancellationToken cancellation)
        {
            var allBuyer = _buyerService.FindBuyerInUser(cancellation);

            return allBuyer;
        } // from Interface



        //Seller Dashbord

        public async Task<bool> DeleteProduct(int InventoryId, CancellationToken cancellation)
        {
            var aInventory = await _inventoryService.GetById(InventoryId, cancellation);

            if(aInventory.IsDeleted == false)
            {
                aInventory.IsDeleted = true;
            }
            else
            {
                aInventory.IsDeleted = false;
            }

            await _inventoryService.Update(aInventory.Id , aInventory, cancellation);

            return true;
        } // from Interface

        public List<User> FindAllSeller(CancellationToken cancellation)
        {
            var allSeller = _sellerSercies.FindSellerInUser(cancellation);

            return allSeller;
        } // from Interface

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

        public async Task<int> ShowSellerWage(int UserId, CancellationToken cancellation)
        {
            var aSeller = _sellerSercies.ByUserId(UserId, cancellation);
            var allSellerWage = await _wageService.GetAllBySellerId(aSeller.Id, cancellation);
            int sellerWage = 0;

            foreach (var wage in allSellerWage)
            {
                if(wage.IsPaid == false)
                    sellerWage = sellerWage + wage.HowMuch;
            }

            return sellerWage;
        } // from Interface

        public async Task<List<ShowProductDto>> SellersProduct(int SellerId, CancellationToken cancellation)
        {
            var markProduct = new List<ShowProductDto>();
            //var aSeller = await _sellerSercies.GetById(SellerId, cancellation);
            var aShop = _shopServices.GetBySellerId(SellerId, cancellation);
            var selllerInventory = _inventoryService.GetByShopId(aShop.Id, cancellation);
            var aProduct = new Product();
            var allProductPicture = new List<ProductPicture>();
            var productCategory = new Category();
            var inventoryPrice = new Price();
            var wage = new Wage();

            if (aShop.Inventories == null)
                return null;

            foreach (var inventory in aShop.Inventories)
            {
                var aShowProductDto = new ShowProductDto();
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
                        aShowProductDto.Url = picture.Url;
                        break;
                    }

                    inventoryPrice = await _priceService.GetById(inventory.PriceId ?? default(int), cancellation);
                    wage = await _wageService.GetAllByInventoyId(inventory.Id, cancellation);

                    aShowProductDto.SellerId = SellerId;
                    aShowProductDto.ProductId = aProduct.Id;
                    aShowProductDto.InventoryId = inventory.Id;
                    aShowProductDto.ProductPrice = inventoryPrice.ProdutPrice ?? default(int);
                    aShowProductDto.ProductCategory = productCategory.Title;
                    aShowProductDto.ProductName = aProduct.Title;
                    aShowProductDto.Wage = wage.HowMuch;
                    aShowProductDto.IsDeletd = inventory.IsDeleted ?? default(bool);

                    markProduct.Add(aShowProductDto);
                }
            }

            return markProduct;
        } // from Inteface

        public string FindUserRole(int UserId, CancellationToken cancellation)
        {
            var allUserRole = _userRoleService.GetByUserId(UserId, cancellation);
            var aRole = new IdentityRole<int>();

            if(allUserRole == null)
                return "Don`t hove a role";

            foreach (var role in allUserRole)
            {
                aRole = _roleService.GetById(role.RoleId, cancellation);


                if(aRole.Name != "Owner")
                {
                    return aRole.Name;
                }
            }

            return "Don`t hove a role";
        }

        public async Task<string> FindShopName(int UserId, CancellationToken cancellation)
        {
            var aSeller = _sellerSercies.ByUserId(UserId, cancellation);
            var aShop = _shopServices.GetBySellerId(aSeller.Id, cancellation);

            return aShop.Name;
        }

        public async Task<bool> DeleteShop(int UserId, CancellationToken cancellation)
        {
            var aSeller = _sellerSercies.ByUserId(UserId, cancellation);
            var aShop = _shopServices.GetBySellerId(aSeller.Id, cancellation);

            if(aShop.IsDeleted == false)
            {
                aShop.IsDeleted = true;
            }
            else
            {
                aShop.IsDeleted = false;
            }

            await _shopServices.Update(aShop.Id, aShop, cancellation);
           
            return true;
        }

        public async Task<bool> ShopActivite(int UserId, CancellationToken cancellation)
        {
            var aSeller = _sellerSercies.ByUserId(UserId, cancellation);
            var aShop = _shopServices.GetBySellerId(aSeller.Id, cancellation);

            return aShop.IsDeleted??default(bool);
        }

        public async Task<List<ShowAllCategory>> ShowAllCategory(CancellationToken cancellation)
        {
            var allCategory = _categoryService.GetAll(cancellation);
            var aCategroyDtoList = new List<ShowAllCategory>();

            foreach(var category in allCategory)
            {
                var aCategoryDto = new ShowAllCategory();

                aCategoryDto.Title = category.Title;

                if(category.ParentId != null)
                {
                    var parent = await _categoryService.GetById(category.ParentId ?? default(int), cancellation);
                    aCategoryDto.PatentTilte = parent.Title;
                }
                else
                {
                    aCategoryDto.PatentTilte = "null";
                }

                aCategoryDto.IsDeleted = category.IsDeleted??default(bool);

                aCategroyDtoList.Add(aCategoryDto);
            }

            return aCategroyDtoList;
        }

        public async Task<bool> AddCategory(string Title, string Parent, CancellationToken cancellation)
        {
            var newCategory = new Category();

            if(Parent == null)
            {
                newCategory.Title = Title;
                newCategory.IsDeleted = false;
                newCategory.ParentId = null;

                await _categoryService.Add(newCategory, cancellation);

                return true;
            }

            newCategory.Title = Title;
            newCategory.IsDeleted = false;
            newCategory.ParentId = await FindCategoryParent(Parent, cancellation);

            await _categoryService.Add(newCategory, cancellation);


            return true;
        }

        public async Task<int> FindCategoryParent(string ParentsName, CancellationToken cancellation)
        {
            var allCategory = _categoryService.GetAll(cancellation);

            foreach(var category in allCategory)
            {
                if(category.Title == ParentsName)
                {
                    return category.Id;
                }
            }

            return 0;
        }
    }
}
