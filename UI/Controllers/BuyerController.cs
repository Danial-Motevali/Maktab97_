using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Services.AppServices;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IBuyerAppService _buyerAppService;
        private readonly UserManager<User> _userManager;
        public BuyerController(IBuyerAppService buyerAppService, UserManager<User> userManager)
        {
            _buyerAppService = buyerAppService;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Serach(string inputValue, CancellationToken cancellation)
        {
            var result = await _buyerAppService.Search(inputValue, cancellation);

            return View("Index", result);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int ProductId, int ShopId, CancellationToken cancellation)
        {
            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var buyer = _buyerAppService.FindBuyer(userId, cancellation);
            var result = await _buyerAppService.AddToCart(buyer, ProductId, ShopId, cancellation);

            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Action(CancellationToken cancellation)
        {
            var result = await _buyerAppService.Action(cancellation);

            return View(result);
        }

        public IActionResult AddNewPrice(int NewPrice, int AuctionId, CancellationToken cancellation)
        {
            var result = _buyerAppService.AddNewPrice(NewPrice, AuctionId, cancellation);

            return View("Action");
        }

        [HttpGet]
        public async Task<IActionResult> Cart(CancellationToken cancellation)
        {
            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var buyer = _buyerAppService.FindBuyer(userId, cancellation);

            var result = await _buyerAppService.Cart(buyer, cancellation);

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> Cart(List<BuyerCartDto> outputList, CancellationToken cancellation)
        {
            await _buyerAppService.AddOrder(outputList, cancellation);

            return RedirectToAction("Index");
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
