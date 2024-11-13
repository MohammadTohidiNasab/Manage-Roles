namespace Divar.Models
{
    public interface IAdminRepository
    {
        Task<List<CustomUser>> GetUsersAsync();
        Task<List<Advertisement>> GetAdvertisementsAsync();
        Task<List<Comment>> GetCommentsAsync();
        Task<CustomUser> GetUserByIdAsync(string id);
        Task DeleteUserAsync(string id, HttpContext httpContext);
    }
}
