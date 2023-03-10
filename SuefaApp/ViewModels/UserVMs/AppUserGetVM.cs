using SuefaApp.ViewModels.EventVMs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SuefaApp.ViewModels.UserVMs
{
    public class AppUserGetVM
    {
        public string Id { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public int WinTimes { get; set; }
        public bool IsAdmin { get; set; }
        public int PlayTimes { get; set; }
        public int LoginTimes { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }


        //relations
        public List<EventGetVM> Events { get; set; }
    }
}
