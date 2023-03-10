using System.ComponentModel.DataAnnotations;

namespace SuefaApp.ViewModels.AdminAccountVMs
{
    public class AdminLoginVM
    {
        [Required(ErrorMessage = "{0} is required!")]
        [DataType(DataType.Text)]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone must be 9 characters!")]
        public string Login { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
