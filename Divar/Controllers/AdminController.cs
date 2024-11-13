using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Divar.Models;

public class AdminController : Controller
{
    private readonly IAdminRepository _adminRepository;

    public AdminController(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    //[Authorize(Roles = "Admin")]
    public async Task<IActionResult> Index()
    {
        var users = await _adminRepository.GetUsersAsync();
        var advertisements = await _adminRepository.GetAdvertisementsAsync();
        var comments = await _adminRepository.GetCommentsAsync();

        var viewModel = new AdminPanel
        {
            Users = users,
            Advertisements = advertisements,
            Comments = comments
        };

        return View(viewModel);
    }

   // [Authorize(Roles = "Editor")]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var user = await _adminRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }
        return View(user);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        await _adminRepository.DeleteUserAsync(id, HttpContext);
        return RedirectToAction(nameof(Index));
    }
}
