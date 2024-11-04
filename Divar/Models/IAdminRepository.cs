namespace Divar.Models
{
    public interface IAdminRepository
    {
        Task<List<CustomUser>> GetUsersAsync();
        Task<List<Advertisement>> GetAdvertisementsAsync();
        Task<List<Comment>> GetCommentsAsync();
        Task<CustomUser> GetUserByIdAsync(int id);
        Task DeleteUserAsync(int id, HttpContext httpContext);
    }
}
