using System.ComponentModel.DataAnnotations;

namespace SuefaApp.ViewModels.UserVMs
{
    public class AppUserCreateVM
    {
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone must be 9 characters!")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "{0} is required!")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "{0} is required!")]
        public string Password { get; set; }
    }
}
