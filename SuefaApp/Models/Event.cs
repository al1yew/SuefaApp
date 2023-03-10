using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Models
{
    public class Event : BaseModel
    {
        public bool HasWon { get; set; }
        public string Message { get; set; }

        //relations
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }
    }
}
