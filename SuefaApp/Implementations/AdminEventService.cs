using AutoMapper;
using SuefaApp.Exceptions;
using SuefaApp.Interfaces;
using SuefaApp.Models;
using SuefaApp.ViewModels.EventVMs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SuefaApp.Implementations
{
    public class AdminEventService : IAdminEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AdminEventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IQueryable<EventGetVM>> GetAllAsync(int type, string phone)
        {
            List<EventGetVM> events = _mapper.Map<List<EventGetVM>>(await _unitOfWork.EventRepository.GetAllByExAsync(x => x.Message != null, "AppUser"));

            IQueryable<EventGetVM> query = events.AsQueryable();

            if (type == 2)
            {
                query = query.Where(x => x.HasWon);
            }

            if (type == 3)
            {
                query = query.Where(x => !x.HasWon);
            }

            if (phone != null)
            {
                query = query.Where(x => x.AppUser.UserName.Contains(phone));
            }

            return query.OrderByDescending(x => x.CreatedAt);
        }

        public async Task<EventGetVM> GetById(int? id)
        {
            if (id == null)
                throw new NotFoundException($"Id is null!");

            Event eventik = await _unitOfWork.EventRepository.GetAsync(x => x.Id == id, "AppUser");

            if (eventik == null)
                throw new NotFoundException($"Event cannot be found by id = {id}");

            return _mapper.Map<EventGetVM>(eventik);
        }

        public async Task DeleteEventAsync(int? id)
        {
            if (id == null)
                throw new NotFoundException($"Event cannot be found by id = {id}");

            Event eventik = await _unitOfWork.EventRepository.GetAsync(x => x.Id == id);

            if (eventik == null)
                throw new NotFoundException($"Event cannot be found by id = {id}");

            _unitOfWork.EventRepository.Remove(eventik);
            await _unitOfWork.CommitAsync();
        }
    }
}
