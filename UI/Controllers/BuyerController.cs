using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Services.AppServices;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    public class BuyerController : Controller
    {
        private readonly IBuyerAppService _buyerAppService;
        public BuyerController(IBuyerAppService buyerAppService)
        {
            _buyerAppService = buyerAppService;
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

            return View();
        }
    }
}
