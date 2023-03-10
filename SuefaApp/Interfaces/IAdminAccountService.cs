using SuefaApp.ViewModels.AdminAccountVMs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuefaApp.Interfaces
{
    public interface IAdminAccountService
    {
        Task<List<string>> Login(AdminLoginVM adminLogin);

        Task Logout();
    }
}
