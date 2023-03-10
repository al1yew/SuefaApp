using SuefaApp.ViewModels.UserVMs;
using System;

namespace SuefaApp.ViewModels.EventVMs
{
    public class EventGetVM
    {
        public int Id { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
        public bool HasWon { get; set; }
        public string Message { get; set; }

        //relation
        public AppUserGetVM AppUser { get; set; }
        public string AppUserId { get; set; }

    }
}
