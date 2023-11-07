using App.Domain.Core.Models.Dto;
using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Core.Models.IdentityDto.Account;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto input)
        {
            if (ModelState.IsValid)
            {
                var newUser = new IdentityUser()
                {
                    //Id = input.Id,
                    Email = input.Email,
                    UserName = input.UserName,
                    EmailConfirmed = true
                };

                var result = await _userManager.CreateAsync(newUser, input.PassWord);

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
