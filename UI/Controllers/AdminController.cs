using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Core.Models.Identity.Role;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    //[Authorize(Roles ="Admin")]
    //[Authorize(Roles ="Owner")]
    public class AdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IAdminAppServices _adminAppServices;
        private readonly UserManager<User> _userManager;
        public AdminController(IMapper mapper, IAdminAppServices adminAppServices, UserManager<User> userManager)
        {
            _mapper = mapper;
            _adminAppServices = adminAppServices;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        //buyer
        public async Task<IActionResult> ShowTheBuyer(CancellationToken cancellation)
        {
            var buyerDto = new List<UserDto>();
            var findBuyerFromUser = _adminAppServices.FindAllBuyer(cancellation);

            foreach (var buyer in findBuyerFromUser)
            {
                var userToDto = new UserDto
                {
                    Id = buyer.Id,
                    FirstName = buyer.FirstName,
                    LastName = buyer.LastName,
                    IsDeleted = buyer.IsDeleted
                };

                buyerDto.Add(userToDto);
            }

            return View(buyerDto);
        }

        public IActionResult BuyerComments(int Id, CancellationToken cancellation)
        {
            var findBuyerFromUser = _adminAppServices.FindBuyer(Id, cancellation);
            var findCommetnByUserId = _adminAppServices.FindCommentByUserId(findBuyerFromUser, cancellation);

            return View(findCommetnByUserId);
        }

        [HttpPost]
        public IActionResult DeleteComment(int Id, CancellationToken cancellation)
        {
            _adminAppServices.DeleteComment(Id, cancellation);

            return RedirectToAction("ShowTheBuyer");
        }

        //Seller
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
            var sellerId = _adminAppServices.FindSeller(Id, cancellation);
            var findSellerProduct = _adminAppServices.SellersProduct(sellerId, cancellation);

            return View(findSellerProduct);
        }

        [HttpPost]
        public IActionResult DeleteProduct(int Id, CancellationToken cancellation)
        {
            _adminAppServices.DeleteProduct(Id, cancellation);

            return RedirectToAction("ShowTheSeller");
        }

        public IActionResult SellersWage(int Id, CancellationToken cancellation)
        {
            var sellerId = _adminAppServices.FindSeller(Id, cancellation);
            var result = _adminAppServices.ShowSellerWage(sellerId, cancellation);
            var WageDto = new WageDtoOutput
            {
                HowMuch = result
            };

            return View(WageDto);
        }


        //Edit user
        [HttpGet]
        public IActionResult ShowAllUser()
        {
            var activeIndexDto = new List<IndexDto>();
            var models = _userManager.Users
            .Select(x => new IndexDto()
            {
                Id = x.Id.ToString(),
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                UserName = x.UserName,
                IsDeleted = x.IsDeleted

            }).ToList();

            foreach(var model in models)
            {
                if(model.IsDeleted == false)
                    activeIndexDto.Add(model);
            }

            return View(activeIndexDto);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string userName, string firstName, string lastName, bool isDeleted)
        {
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
            user.SecurityStamp = Guid.NewGuid().ToString();

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var item in result.Errors)
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
                return NotFound();

            user.IsDeleted = true;

            var result = await _userManager.UpdateAsync(user);

            //await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}
