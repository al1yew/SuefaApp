using System.ComponentModel.DataAnnotations;

namespace SuefaApp.ViewModels.UserVMs
{
    public class AppUserUpdateVM
    {
        public string Id { get; set; }

        [StringLength(9, MinimumLength = 9, ErrorMessage = "Phone must be 9 characters!")]
        [DataType(DataType.Text)]
        public string PhoneNumber { get; set; }

        public string Password { get; set; }

        public bool IsAdmin { get; set; }
    }
}
