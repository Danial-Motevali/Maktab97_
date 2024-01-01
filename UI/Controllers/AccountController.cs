using App.Domain.Core.Contract.AppServices;
using App.Domain.Core.Contract.Service;
using App.Domain.Core.Models.Identity.AccountDto;
using App.Domain.Core.Models.Identity.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IAccountAppService _accountAppService;
        private readonly IUserServices _userServices;
        public AccountController(IUserServices userServices ,UserManager<User> userManager, SignInManager<User> signInManager, IAccountAppService accountAppService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountAppService = accountAppService;
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto input, CancellationToken cancellation)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newUser = new User()
                    {
                        //Id = input.Id,
                        Email = input.Email,
                        FirstName = input.FirstName,
                        LastName = input.LastName,
                        UserName = input.UserName,
                        EmailConfirmed = true
                    };

                    var result = await _userManager.CreateAsync(newUser, input.PassWord);

                    if (result.Succeeded)
                    {
                        if (input.potion == PotionDto.Seller)
                        {
                            await _accountAppService.CreateSeller(newUser, cancellation);
                        }
                        else if (input.potion == PotionDto.Buyer)
                        {
                            await _accountAppService.CreateBuyer(newUser, cancellation);
                        }
                        else if (input.potion == PotionDto.Admin)
                        {
                            await _accountAppService.CreateBuyer(newUser, cancellation);
                        }
                    }

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    }

                    foreach (var errore in result.Errors)
                    {
                        ModelState.AddModelError("", errore.Description);
                    }
                }
                return View(input);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto input, CancellationToken cancellation)
        {
            try
            {
                var result = await _signInManager.PasswordSignInAsync(input.UserName, input.PassWord, false, false);
                var allUser = _userServices.GetAll(cancellation);
                var inputUser = new User();



                if (ModelState.IsValid)
                {
                    foreach (var user in allUser)
                    {
                        if (user.UserName == input.UserName)
                        {
                            inputUser = user;
                        }
                    }
                }

                if (_signInManager.IsSignedIn(User))
                    return RedirectToAction("Index", "Home");

                if (ModelState.IsValid)
                {
                    if (result.Succeeded)
                    {
                        if (inputUser.Potion == Potion.Buyer)
                            return RedirectToAction("Index", "Home", inputUser);

                        if (inputUser.Potion == Potion.Seller)
                            return RedirectToAction("Index", "Home", inputUser);

                        if (inputUser.Potion == Potion.Admin)
                            return RedirectToAction("Index", "Home", inputUser);

                        if (inputUser.Potion == Potion.Owner)
                            return RedirectToAction("Index", "Home", inputUser);
                    }
                }
                return View(input);
            }
            catch (Exception ex)
            {
                return View(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
