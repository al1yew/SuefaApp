using SuefaApp.DAL;
using SuefaApp.IRepositories;
using SuefaApp.Models;

namespace SuefaApp.Repositories
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {

        }
    }
}
