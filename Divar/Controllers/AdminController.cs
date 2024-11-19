﻿public class AdminController : Controller
{
    private readonly IAdminRepository _adminRepository;

    public AdminController(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }


     //لیست اگهی ها 
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


    //حذف کاربر
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



    // نمایش صفحه تأیید حذف کامنت
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _adminRepository.GetCommentsAsync(); // فهرست کامنت‌ها برای یافتن کامنت با آیدی مشخص
        var commentToDelete = comment.FirstOrDefault(c => c.Id == id);

        if (commentToDelete == null)
        {
            return NotFound();
        }

        return View(commentToDelete);
    }

    // تأیید حذف کامنت
    [HttpPost, ActionName("DeleteConfirmedComment")]
    public async Task<IActionResult> DeleteConfirmedComment(int id)
    {
        await _adminRepository.DeleteComment(id, HttpContext);
        return RedirectToAction(nameof(Index));
    }




    //جزییات اگهی
    public async Task<IActionResult> AdvertisementDetail(int id)
    {
        var advertisement = await _adminRepository.GetAdvertisementsAsync();
        var adDetail = advertisement.FirstOrDefault(ad => ad.Id == id);

        if (adDetail == null)
        {
            return NotFound();
        }

        return View(adDetail);
    }
}
