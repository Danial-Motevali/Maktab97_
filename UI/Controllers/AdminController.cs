using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly ISellerService _sellerService;
        private readonly IAdminAppServices _adminAppServices;
        public AdminController(ISellerService sellerService, IMapper mapper, IAdminAppServices adminAppServices)
        {
            _sellerService = sellerService;
            _mapper = mapper;
            _adminAppServices = adminAppServices;
        }

        public async Task<IActionResult> ShowTheSeller(CancellationToken cancellation)
        {
            var sellerDto = new List<UserDto>();
            var findSellerFromUser = _adminAppServices.FindAllSeller(cancellation);

            foreach (var seller in findSellerFromUser)
            {
                var userToDto = new UserDto
                {
                    Id = seller.Id,
                    FirstName = seller.FirstName,
                    LastName = seller.LastName,
                    IsDeleted = seller.IsDeleted
                };

                sellerDto.Add(userToDto);
            }

            return View(sellerDto);
        }

        public IActionResult SellersProducts(int Id, CancellationToken cancellation)
        {
            var findSellerFromUser = _adminAppServices.FindSeller(Id, cancellation);
            var shopSId = _adminAppServices.FindSellerShop(findSellerFromUser, cancellation);
            var sellerInventory = _adminAppServices.FindInventoryByShopId(shopSId ,cancellation);
            var findProduct = _adminAppServices.FindProductByProductId(sellerInventory, cancellation);

            return View(findProduct);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int Id, CancellationToken cancellation)
        {
            _adminAppServices.DeleteProduct(Id, cancellation);

            return RedirectToAction("SellersProducts");
        }

    }
}
