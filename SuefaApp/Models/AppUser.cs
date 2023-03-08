using Microsoft.AspNetCore.Identity;
using System;

namespace SuefaApp.Models
{
    public class AppUser : IdentityUser
    {
        public int WinTimes { get; set; }
        public bool IsAdmin { get; set; }
        public int PlayTimes { get; set; }
        public int LoginTimes { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
    }
}
