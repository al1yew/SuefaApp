using SuefaApp.DAL;
using SuefaApp.IRepositories;
using SuefaApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Repositories
{
    public class EventMessageRepository : Repository<EventMessage>, IEventMessageRepository
    {
        public EventMessageRepository(AppDbContext context) : base(context)
        {

        }
    }
}
