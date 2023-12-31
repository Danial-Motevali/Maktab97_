﻿using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Repository;
using App.Domain.Core.Contract.Services;
using App.Domain.Core.Models.Dto.ControllerDto;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Security.Claims;

namespace UI.Controllers
{
    [Authorize(Roles = "Seller")]
    public class SellerController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ISellerAppService _sellerAppService;
        private readonly ICategoryService _categoryService;
        private readonly IShopService _shopService;
        private readonly IWebHostEnvironment _env;
        public SellerController(IShopService shopService, IWebHostEnvironment env ,ICategoryService categoryService ,ISellerAppService sellerAppService, UserManager<User> userManager)
        {
            _sellerAppService = sellerAppService;
            _userManager = userManager;
            _categoryService = categoryService;
            _env = env;
            _shopService = shopService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShodDashBord(CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var seller = _sellerAppService.FindSeller(userId, cancellation);

                var shopDto = new ShopDashBordDto
                {
                    SellerId = seller.Id,
                };

                var hasAShop = _sellerAppService.FindShop(seller.Id, cancellation);

                if (hasAShop == null)
                {
                    return View("~/Views/Seller/CreateAShop.cshtml", shopDto);
                }

                var shopDasBordDto = _sellerAppService.FillTheDto(hasAShop, cancellation);

                return View(shopDasBordDto);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public async Task<IActionResult> AuctionDashBord(CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var seller = _sellerAppService.FindSeller(userId, cancellation);
                var auctionDto = await _sellerAppService.FillAuctionDto(seller, cancellation);

                return View(auctionDto);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> AuctionHistory(int AuctionId, CancellationToken cancellation)
        {
            try
            {
                var result = await _sellerAppService.AuctionHistory(AuctionId, cancellation);

                return View(result);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public  IActionResult CreateANewShop(ShopDashBordDto shop, CancellationToken cancellation) 
        {
            try
            {
                var newShop = _sellerAppService.CreateAShop(shop, cancellation).Result;

                return RedirectToAction("ShodDashBord", newShop);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditProfile()
        {
            try
            {
                var id = User.FindFirstValue(ClaimTypes.NameIdentifier);

                if (id == null)
                    return NotFound();

                var user = await _userManager.FindByIdAsync(id);

                if (user == null)
                    return NotFound();


                return View(user);
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
        public IActionResult AppProduct(CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var seller = _sellerAppService.FindSeller(userId, cancellation);

                var newProduct = new AddProductDto
                {
                    ShopId = _shopService.GetBySellerId(seller.Id, cancellation).Id,
                    category = _categoryService.GetAll(cancellation)
                };

                return View(newProduct);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AppProduct(AddProductDto productDto ,CancellationToken cancellation)
        {
            try
            {
                int userId = Int32.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
                var seller = _sellerAppService.FindSeller(userId, cancellation);

                string filename = UploadFile(productDto);
                productDto.PictureUrl = filename;

                await _sellerAppService.AddProduct(productDto, seller, cancellation);

                return RedirectToAction("ShodDashBord");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        public string UploadFile(AddProductDto input)
        {
            try
            {
                string fileName = null;

                if (input.PictureUrlFile != null)
                {
                    string uploadDir = Path.Combine(_env.WebRootPath, "Images");
                    fileName = Guid.NewGuid() + "_" + input.PictureUrlFile.FileName;
                    string filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        input.PictureUrlFile.CopyTo(fileStream);
                    }
                }

                return fileName;
            }
            catch (Exception ex)
            {
                return "null";
            }
        }

        public async Task<IActionResult> AddToAcuion(int ProductId, int SellerId,int Days,  CancellationToken cancellation)
        {
            try
            {
                await _sellerAppService.AddToAcuion(ProductId, SellerId, Days, cancellation);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }
    }
}
