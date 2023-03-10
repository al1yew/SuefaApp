using SuefaApp.DAL;
using SuefaApp.IRepositories;
using SuefaApp.Repositories;
using System.Threading.Tasks;

namespace SuefaApp
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppUserRepository _appUserRepository;
        private readonly EventRepository _eventRepository;

        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public IAppUserRepository AppUserRepository => _appUserRepository ?? new AppUserRepository(_context);
        public IEventRepository EventRepository => _eventRepository ?? new EventRepository(_context);






        public int Commit()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
