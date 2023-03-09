using SuefaApp.DAL;
using SuefaApp.IRepositories;
using SuefaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(AppDbContext context) : base(context)
        {

        }
    }
}
