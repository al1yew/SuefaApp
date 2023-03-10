using SuefaApp.IRepositories;
using System.Threading.Tasks;

namespace SuefaApp
{
    public interface IUnitOfWork
    {
        IAppUserRepository AppUserRepository { get; }
        IEventRepository EventRepository { get; }

        Task<int> CommitAsync();
        int Commit();
    }
}
