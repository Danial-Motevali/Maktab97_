using App.Domain.Core.Contract.AppServices;
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
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IAccountAppService accountAppService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _accountAppService = accountAppService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto input, CancellationToken cancellation)
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
                    if (input.potion == Potion.Seller)
                    {
                        _accountAppService.CreateSeller(newUser, cancellation);
                    }
                    else if (input.potion == Potion.Buyer)
                    {
                        _accountAppService.CreateBuyer(newUser, cancellation);
                    }
                }

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                foreach (var errore in result.Errors)
                {
                    ModelState.AddModelError("", errore.Description);
                }
            }
            return View(input);
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto input)
        {
            if (_signInManager.IsSignedIn(User))
                return RedirectToAction("Index", "Home");

            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(input.UserName, input.PassWord, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(input);
        }

        [HttpPost]
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
