using App.Domain.Core.Contract.AppServices;
using Microsoft.AspNetCore.Mvc;

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

        public async Task<IActionResult> Serach(string search, CancellationToken cancellation)
        {
            var result = await _buyerAppService.Search(search, cancellation);

            return View("Index", result);
        }
    }
}
