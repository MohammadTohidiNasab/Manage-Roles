using System.ComponentModel.DataAnnotations;

namespace Divar.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "وارد کردن ایمیل الزامی است")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "وارد کردن رمز عبور الزامی است")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "مرا بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }
}
