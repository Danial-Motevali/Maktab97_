using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Core.Models.Identity.Role;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    //[Authorize(Roles = "Owner")]
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
                    IsDeleted = buyer.IsDeleted ?? default(bool),
                    UserName = buyer.UserName,
                    Email = buyer.Email
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
        public async Task<IActionResult> DeleteComment(int Id, CancellationToken cancellation)
        {
            await _adminAppServices.DeleteComment(Id, cancellation);

            return RedirectToAction("Index", "Home");
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
                    IsDeleted = seller.IsDeleted ?? default(bool),
                    UserName = seller.UserName,
                    Email = seller.Email,
                    Wage = await _adminAppServices.ShowSellerWage(seller.Id, cancellation),
                    ShopName = await _adminAppServices.FindShopName(seller.Id, cancellation),
                    Shop = await _adminAppServices.ShopActivite(seller.Id, cancellation)
                };

                sellerDto.Add(userToDto);
            }

            return View(sellerDto);
        }

        public async Task<IActionResult> SellersProducts(int Id, CancellationToken cancellation)
        {
            var sellerId = _adminAppServices.FindSeller(Id, cancellation);
            var findSellerProduct = await _adminAppServices.SellersProduct(sellerId, cancellation);

            return View(findSellerProduct);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int InventoryId, CancellationToken cancellation)
        {
            await _adminAppServices.DeleteProduct(InventoryId, cancellation);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> DeleteShop(int Id, CancellationToken cancellation)
        {
            await _adminAppServices.DeleteShop(Id, cancellation);

            return RedirectToAction("Index", "Home");
        }

        //Edit user
        [HttpGet]
        public IActionResult ShowAllUser(CancellationToken cancellation)
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
                IsDeleted = x.IsDeleted ?? default(bool),
                UserRole = _adminAppServices.FindUserRole(x.Id, cancellation)
            }).ToList();
            
            foreach(var model in models)
            {
                if(model.IsDeleted == false)
                    activeIndexDto.Add(model);
            }

            return View(activeIndexDto);
        }
        

        [HttpGet]
        public async Task<IActionResult> EditUser(string UserId)
        {
            var markUser = new User();

            if(UserId == null)
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (id == null)
                    return NotFound();

                var user = await _userManager.FindByIdAsync(id);


                if (user == null)
                    return NotFound();

                markUser = user;
            }
            else
            {
                var user = await _userManager.FindByIdAsync(UserId);

                if (user == null)
                    return NotFound();

                markUser = user;
            }



            return View(markUser);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string Id, string userName, string firstName, string lastName, bool isDeleted)
        {
            //var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (Id == null || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return NotFound();

            var user = await _userManager.FindByIdAsync(Id);

            if (user == null)
                return NotFound();

            user.Id = Convert.ToInt32(Id);
            user.UserName = userName;
            user.FirstName = firstName;
            user.LastName = lastName;
            user.IsDeleted = isDeleted;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded) return RedirectToAction("Index", "Home");

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

            if(user.IsDeleted == false)
            {
                user.IsDeleted = true;
            }
            else
            {
                user.IsDeleted = false;
            }

            var result = await _userManager.UpdateAsync(user);

            //await _userManager.DeleteAsync(user);

            return RedirectToAction("Index", "Home");
        }
    }
}
