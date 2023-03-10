using AutoMapper;
using SuefaApp.Models;
using SuefaApp.ViewModels.EventVMs;
using SuefaApp.ViewModels.UserVMs;

namespace SuefaApp.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region AppUser

            CreateMap<AppUser, AppUserGetVM>()
                .ForPath(des => des.Events, src => src.MapFrom(x => x.Events));

            CreateMap<AppUserGetVM, AppUserUpdateVM>()
                .ForMember(des => des.PhoneNumber, src => src.MapFrom(x => x.PhoneNumber.Substring(4)));

            #endregion

            #region Events

            CreateMap<Event, EventGetVM>()
                .ForPath(des => des.AppUser, src => src.MapFrom(x => x.AppUser));

            #endregion
        }
    }
}
