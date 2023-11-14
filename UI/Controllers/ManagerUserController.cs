using App.Domain.Core.Models.Identity.Entites;
using App.Domain.Core.Models.Identity.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    [Authorize(Roles = "Owner")]
    public class ManagerUserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public ManagerUserController(UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var model = _userManager.Users
                .Select(x => new IndexDto()
                {
                    Id = x.Id.ToString(),
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    UserName = x.UserName
                    
                }).ToList();

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return NotFound();
            var user = await _userManager.FindByIdAsync(id);
            if(user == null) return NotFound();

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(string id, string userName, string firstName, string lastName)
        {
            if(string.IsNullOrEmpty(id) || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
                return NotFound();

            user.UserName = userName;
            user.FirstName = firstName;
            user.LastName = lastName;

            var result = await _userManager.UpdateAsync(user);

            if(result.Succeeded) return RedirectToAction("Index");

            foreach(var item in result.Errors) 
            {
                ModelState.AddModelError(string.Empty, item.Description);
            }

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> AddUserRole(string id)
        {
            //var id = Id.ToString();
            if(string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if(user == null)
                return NotFound();
            var roles = _roleManager.Roles.ToList();

            var model = new AddUserRoleDto()
            {
                Id = id,
            };

            foreach(var role in roles)
            {
                if(!await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRole.Add(new UserRoleDto()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddUserRole(AddUserRoleDto input)
        {
            if(input == null) return
                    NotFound();

            var user = await _userManager.FindByIdAsync(input.Id);

            if (user == null)
                return NotFound();

            var requestRoles = input.UserRole.Where(x => x.IsSelected)
                .Select(x => x.RoleName)
                .ToList();

            var result = await _userManager.AddToRolesAsync(user, requestRoles);

            if(result.Succeeded) return RedirectToAction("Index");

            foreach(var errore in result.Errors)
            {
                ModelState.AddModelError(string.Empty, errore.Description);
            }

            return View(input);
        }

        [HttpGet]
        public async Task<IActionResult> RemoveUserRole(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound();
            var roles = _roleManager.Roles.ToList();

            var model = new AddUserRoleDto()
            {
                Id = id,
            };

            foreach (var role in roles)
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    model.UserRole.Add(new UserRoleDto()
                    {
                        RoleName = role.Name
                    });
                }
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveUserRole(AddUserRoleDto input)
        {
            if (input == null)
                return NotFound();

            var user = await _userManager.FindByIdAsync(input.Id);

            if (user == null) return
                    NotFound();

            var requestRoles = input.UserRole.Where(x => x.IsSelected)
                .Select(x => x.RoleName)
                .ToList();

            var result = await _userManager.RemoveFromRolesAsync(user, requestRoles);

            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var errore in result.Errors)
            {
                ModelState.AddModelError(string.Empty, errore.Description);
            }

            return View(input);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteUser(string id)
        {
            if(string.IsNullOrEmpty(id))
                return NotFound();

            var user = await _userManager.FindByIdAsync(id);
            if(user == null)
                return NotFound();

            //soft Delete
            //user.IsDeleted = true;

            await _userManager.DeleteAsync(user);

            return RedirectToAction("Index");
        }
    }
}
