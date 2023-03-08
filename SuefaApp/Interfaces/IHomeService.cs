using SuefaApp.ViewModels.LoginVMs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SuefaApp.Interfaces
{
    public interface IHomeService
    {
        Task<List<string>> Login(LoginVM loginVM);
    }
}
