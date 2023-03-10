using SuefaApp.ViewModels.EventVMs;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Interfaces
{
    public interface IAdminEventService
    {
        Task<IQueryable<EventGetVM>> GetAllAsync(int type, string phone);

        Task<EventGetVM> GetById(int? id);

        Task DeleteEventAsync(int? id);
    }
}
