using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Divar.Models
{
    public static class RoleInitializer
    {
        public static async Task InitializeAsync(RoleManager<IdentityRole> roleManager)
        {
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (await roleManager.FindByNameAsync("Editor") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Editor"));
            }

            if (await roleManager.FindByNameAsync("Reader") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("Reader"));
            }
        }
    }
}
