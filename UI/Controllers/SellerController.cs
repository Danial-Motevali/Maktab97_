using App.Domain.Core.Contract.AppServices;
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
        public SellerController(ISellerAppService sellerAppService, UserManager<User> userManager)
        {
            _sellerAppService = sellerAppService;
            _userManager = userManager;
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
                SellerId = seller.Id
            };

            var hasAShop = _sellerAppService.FindShop(seller.Id, cancellation);

            if (hasAShop == null) // is off
            {
                return View("~/Views/Seller/CreateAShop.cshtml", shopDto); // -> star here
            }

            var shopDasBordDto = _sellerAppService.FillTheDto(hasAShop, cancellation);

            return View(shopDasBordDto);
        }

        [HttpPost]
        public  IActionResult CreateANewShop(ShopDashBordDto shop, CancellationToken cancellation) // need repair
        {
            var newShop = _sellerAppService.CreateAShop(shop, cancellation).Result;

            return View("~/Views/Seller/ShodDashBord.cshtml", newShop);
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
    }
}
