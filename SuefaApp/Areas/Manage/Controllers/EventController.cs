using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuefaApp.Interfaces;
using SuefaApp.ViewModels;
using SuefaApp.ViewModels.EventVMs;
using System.Linq;
using System.Threading.Tasks;


namespace SuefaApp.Areas.Manage.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Manage")]
    public class EventController : Controller
    {
        private readonly IAdminEventService _adminEventService;
        private readonly IMapper _mapper;
        public EventController(IAdminEventService adminEventService, IMapper mapper)
        {
            _adminEventService = adminEventService;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(int select, int type, string phone, int page = 1)
        {
            IQueryable<EventGetVM> events = await _adminEventService.GetAllAsync(type, phone);

            if (select <= 0)
            {
                select = 10;
            }

            if (type <= 0)
            {
                type = 1;
            }

            ViewBag.Select = select;
            ViewBag.Page = page;
            ViewBag.Phone = phone;
            ViewBag.Type = type;
            ViewBag.WhereWeAre = "Events";

            return View(PaginationList<EventGetVM>.Create(events, page, select));
        }

        public async Task<IActionResult> DeleteEvent(int? id, int select, int type, string phone, int page)
        {
            ViewBag.Select = select;
            ViewBag.Page = page;
            ViewBag.Phone = phone;
            ViewBag.Type = type;
            ViewBag.WhereWeAre = "Events";

            await _adminEventService.DeleteEventAsync(id);

            IQueryable<EventGetVM> events = await _adminEventService.GetAllAsync(type, phone);

            return PartialView("_EventIndexPartial", PaginationList<EventGetVM>.Create(events, page, select));
        }
    }
}
