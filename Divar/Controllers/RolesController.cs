using Microsoft.AspNetCore.Mvc;

namespace Divar.Controllers
{
    public class RolesController : Controller

    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public IActionResult List()
        {
            var roles = _roleManager.Roles.ToList();
            return View(roles);
        }


    }
}
