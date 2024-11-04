using System.ComponentModel.DataAnnotations;

namespace Divar.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "وارد کردن نام الزامی است")]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "وارد کردن نام خانوادگی الزامی است")]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن شماره تلفن الزامی است")]
        [MaxLength(12)]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "رمز عبور و تایید رمز عبور همخوانی ندارند.")]
        public string ConfirmPassword { get; set; }
    }
}
