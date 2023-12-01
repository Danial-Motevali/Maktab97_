using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Admin;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Services.Services;
using Microsoft.AspNetCore.Identity;

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
        } // from Interface



        //Seller Dashbord

        public async Task<bool> DeleteProduct(int ProductId, CancellationToken cancellation)
        {
            var aProduct = await _productService.GetById(ProductId, cancellation);

            if(aProduct.IsDeleted == false)
            {
                aProduct.IsDeleted = true;
            }
            else
            {
                aProduct.IsDeleted = false;
            }

            await _productService.Update(aProduct.Id , aProduct, cancellation);

            return true;
        } // from Interface

        public List<User> FindAllSeller(CancellationToken cancellation)
        {
            var allSeller = _sellerSercies.FindSellerInUser(cancellation);
            var activeUser = new List<User>();

            foreach (var user in allSeller)
            {
                //foreach (var seller in allSeller)
                //{
                //    if (user.IsDeleted == false)
                //        activeUser.Add(user);
                //}
                activeUser.Add(user);
            }

            return activeUser;
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

        public int ShowSellerWage(int SellerId, CancellationToken cancellation)
        {
            var allSellerWage = _wageService.GetAllBySellerId(SellerId, cancellation).Result;
            int sellerWage = 0;

            foreach (var wage in allSellerWage)
            {
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
                    aShowProductDto.ProductPrice = inventoryPrice.ProdutPrice ?? default(int);
                    aShowProductDto.ProductCategory = productCategory.Title;
                    aShowProductDto.ProductName = aProduct.Title;
                    aShowProductDto.Wage = wage.HowMuch;
                    aShowProductDto.IsDeletd = aProduct.IsDeleted ?? default(bool);

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
    }
}
