using SuefaApp.ViewModels.AdminAccountVMs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SuefaApp.Interfaces
{
    public interface IAdminHomeService
    {
        Task<AdminHomeVM> GetData();
    }
}
