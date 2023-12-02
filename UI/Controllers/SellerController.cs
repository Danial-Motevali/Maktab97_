using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    public class SellerController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ISellerAppService _sellerAppService;
        private readonly ICategoryService _categoryService;
        private readonly IShopService _shopService;
        private readonly IWebHostEnvironment _env;
        public SellerController(IShopService shopService, IWebHostEnvironment env ,ICategoryService categoryService ,ISellerAppService sellerAppService, UserManager<User> userManager)
        {
            _sellerAppService = sellerAppService;
            _userManager = userManager;
            _categoryService = categoryService;
            _env = env;
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShodDashBord(CancellationToken cancellation)
        {

            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var seller = _sellerAppService.FindSeller(userId, cancellation);

            var shopDto = new ShopDashBordDto
            {
                SellerId = seller.Id,
            };

            var hasAShop = _sellerAppService.FindShop(seller.Id, cancellation);

            if (hasAShop == null) 
            {
                return View("~/Views/Seller/CreateAShop.cshtml", shopDto); 
            }

            var shopDasBordDto = _sellerAppService.FillTheDto(hasAShop, cancellation);

            return View(shopDasBordDto);
        }

        public async Task<IActionResult> AuctionDashBord(CancellationToken cancellation)
        {
            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var seller = _sellerAppService.FindSeller(userId, cancellation);
            var auctionDto = await _sellerAppService.FillAuctionDto(seller, cancellation);

            return View(auctionDto);
        }

        [HttpPost]
        public  IActionResult CreateANewShop(ShopDashBordDto shop, CancellationToken cancellation) 
        {
            var newShop = _sellerAppService.CreateAShop(shop, cancellation).Result;

            return RedirectToAction("ShodDashBord", newShop);
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == null) 
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if (user == null) 
                return NotFound();
                    

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string id, string userName, string firstName, string lastName, bool isDeleted)
        {
            //int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();

            user.Id = Convert.ToInt32(id);
            user.UserName = userName;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.IsDeleted = isDeleted;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
                return RedirectToAction("Index");

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(result);
        }

        [HttpGet]
        public IActionResult AppProduct(CancellationToken cancellation)
        {
            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var seller = _sellerAppService.FindSeller(userId, cancellation);

            var newProduct = new AddProductDto
            {
                ShopId = _shopService.GetBySellerId(seller.Id, cancellation).Id,
                category = _categoryService.GetAll(cancellation)
            };

            return View(newProduct);
        }

        [HttpPost]
        public async Task<IActionResult> AppProduct(AddProductDto productDto ,CancellationToken cancellation)
        {
            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var seller = _sellerAppService.FindSeller(userId, cancellation);

            string filename = UploadFile(productDto);
            productDto.PictureUrl = filename;

            await _sellerAppService.AddProduct(productDto, seller, cancellation);

            return RedirectToAction("ShodDashBord");
        }

        public string UploadFile(AddProductDto input)
        {
            string fileName = null;

            if (input.PictureUrlFile != null)
            {
                string uploadDir = Path.Combine(_env.WebRootPath, "Images");
                fileName = Guid.NewGuid() + "_" + input.PictureUrlFile.FileName;
                string filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    input.PictureUrlFile.CopyTo(fileStream);
                }
            }

            return fileName;
        }

        public async Task<IActionResult> AddToAcuion(int ProductId, int SellerId,int AddToAcuion,  CancellationToken cancellation)
        {
            await _sellerAppService.AddToAcuion(ProductId, SellerId, cancellation);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditAuction(int AuctionId, DateTime newDate, CancellationToken cancellation)
        {

            return View();
        } // warnign workers are working
    }
}
