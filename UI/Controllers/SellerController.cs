using App.Domain.Core.Contract.AppServices;
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

        public IActionResult ShodDashBord( CancellationToken cancellation)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }
    }
}
