using Divar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq;

namespace Divar.Views.Roles
{

    public class ManageRoleModel : PageModel
    {

        private readonly UserManager<CustomUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CustomUser CurentUser { get; set; }
        public List<IdentityRole> Roles { get; set; }
        public List<string> UserRoles { get; set; }

        public ManageRoleModel(RoleManager<IdentityRole> roleManager, UserManager<CustomUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }



        public async Task GetOne(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            UserRoles = (await _userManager.GetRolesAsync(user)).ToList();
            var AllRoles = _roleManager.Roles.ToList();

        }


    }
}
