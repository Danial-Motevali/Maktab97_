using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Identity.Entites;
using App.Infrastructure.Data.EF.Migrations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using Microsoft.AspNetCore.OutputCaching;
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
            int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var seller = _sellerAppService.FindSeller(userId, cancellation);



            //var shopDto = new ShopDtoOutput
            //{
            //    SellerId = seller.Id
            //};

            var hasAShop = _sellerAppService.FindShop(seller.Id, cancellation);

            //if(hasAShop == null) // is off
            //{
            //    return View("~/Views/Seller/CreateAShop.cshtml", shopDto);
            //}

            var shopDasBordDto = _sellerAppService.FillTheDto(hasAShop, cancellation);

            return View(shopDasBordDto);
        }

        [HttpPost]
        public IActionResult CreateANewShop(ShopDtoOutput shop, CancellationToken cancellation) // need repair
        {
            var newShop = _sellerAppService.CreateAShop(shop, cancellation);

            return View("~/Views/Seller/ShodDashBord.cshtml", newShop);
        }
    }
}
