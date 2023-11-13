using App.Domain.Core.Models.Identity.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
    public class ManagerRoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> _roleManager;
        public ManagerRoleController(RoleManager<IdentityRole<int>> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var role = _roleManager.Roles.ToList();

            return View(role);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(AddRoleDto input)
        {

            if (string.IsNullOrEmpty(input.Name)) return NotFound();
            var role = new IdentityRole<int>(input.Name);
            var result = await _roleManager.CreateAsync(role);
            if (result.Succeeded) return RedirectToAction("Index");

            foreach (var errore in result.Errors)
            {
                ModelState.AddModelError(string.Empty, errore.Description);
            }
            return View(role);

        }

        [HttpPost]
        public async Task<IActionResult> DeleteRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            await _roleManager.DeleteAsync(role);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();

            var role = await _roleManager.FindByIdAsync(id);

            if (role == null) return NotFound();
                
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> EditRole(string id, string name)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name)) return NotFound();

            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) return NotFound();
            role.Name = name;
            var result = await _roleManager.UpdateAsync(role);
            if(result.Succeeded) return RedirectToAction("Index");

            foreach (var errore in result.Errors)
            {
                ModelState.AddModelError(string.Empty, errore.Description);
            }

            return View(role);
        }
    }
}
