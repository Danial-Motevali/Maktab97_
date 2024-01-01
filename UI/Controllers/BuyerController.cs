using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Entities;
using App.Domain.Core.Models.Dto.ControllerDto.Buyer;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace UI.Controllers
{
    [Authorize(Roles = "Buyer")]
    public class BuyerController : Controller
    {
        private readonly IBuyerAppService _buyerAppService;
        private readonly UserManager<User> _userManager;
        public BuyerController(IBuyerAppService buyerAppService, UserManager<User> userManager)
        {
            _buyerAppService = buyerAppService;
            _userManager = userManager;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index(CancellationToken cancellation)
        {
            try
            {
                var allProduct = await _buyerAppService.ShowAllProduct(cancellation);

                return View(allProduct);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Serach(string inputValue, CancellationToken cancellation)
        {
            try
            {
                var result = await _buyerAppService.Search(inputValue, cancellation);

                return View("Index", result);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int ProductId, int ShopId, CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = _buyerAppService.FindBuyer(userId, cancellation);
                var result = await _buyerAppService.AddToCart(buyer, ProductId, ShopId, cancellation);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> Action(CancellationToken cancellation)
        {
            try
            {
                var result = await _buyerAppService.Action(cancellation);

                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> AddNewPrice(int NewPrice, int AuctionId, CancellationToken cancellation)
        {
            try
            {
                var userId = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var result = await _buyerAppService.AddNewPrice(userId, NewPrice, AuctionId, cancellation);

                return View("Action");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Cart(CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = _buyerAppService.FindBuyer(userId, cancellation);

                var result = await _buyerAppService.Cart(buyer, cancellation);

                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Cart(List<BuyerCartDto> outputList, CancellationToken cancellation)
        {
            try
            {
                await _buyerAppService.AddOrder(outputList, cancellation);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile(CancellationToken cancellation)
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (id == null)
                    return NotFound();

                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                    return NotFound();

                var newUserDot = new BuyerUserDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    Email = user.Email,
                    UserName = user.UserName,
                };

                return View(newUserDot);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string id, string userName, string firstName, string lastName, bool isDeleted)
        {
            try
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
            catch (Exception ex)
            {
                return View(ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> ShowComment(CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = _buyerAppService.FindBuyer(userId, cancellation);

                var allComments = await _buyerAppService.ShowComment(buyer, cancellation);

                return View(allComments);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> CommentSection(CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = _buyerAppService.FindBuyer(userId, cancellation);

                var allOrder = await _buyerAppService.OrderetProdut(buyer, cancellation);

                return View(allOrder);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }


        [HttpGet]
        public async Task<IActionResult> AddComment(int InventoryId, CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var buyer = _buyerAppService.FindBuyer(userId, cancellation);

                var newComment = new Comment()
                {
                    BuyerId = buyer.Id,
                    InventoryId = InventoryId,
                    IsDeleted = false,
                    IsActive = false
                };

                return View(newComment);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(Comment input, CancellationToken cancellation)
        {
            try
            {
                await _buyerAppService.AddComment(input, cancellation);

                return RedirectToAction("CommentSection");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteComment(int CommentId, CancellationToken cancellation)
        {
            try
            {
                await _buyerAppService.DeleteComment(CommentId, cancellation);

                return RedirectToAction("ShowComment");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> ProductHistory(int CommentId, CancellationToken cancellation)
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var product = await _buyerAppService.FuildBuyerDto(int.Parse(id), cancellation);


                return View(product);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AuctionHistory(CancellationToken cancellation)
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var auction = await _buyerAppService.FuilAuctionDto(int.Parse(id), cancellation);

                return View(auction);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> OneAuctionHistory(int AuctionId, CancellationToken cancellation)
        {
            try
            {
                var auction = await _buyerAppService.AActionHistory(AuctionId, cancellation);

                return View(auction);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
