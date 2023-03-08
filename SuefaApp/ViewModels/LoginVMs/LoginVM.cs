using System.ComponentModel.DataAnnotations;

namespace SuefaApp.ViewModels.LoginVMs
{
    public class LoginVM
    {
        [Required(ErrorMessage = "{0} Qeyd edin!")]
        [DataType(DataType.Text)]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Nömrə 9 rəqəmdən ibarət olmalıdır!")]
        public string Login { get; set; }
    }
}
