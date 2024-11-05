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



        //create roles


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var identityRole = new IdentityRole(model.Name);

            }

            return View(model);
        }

    }
}
