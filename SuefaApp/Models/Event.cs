using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Models
{
    public class Event : BaseModel
    {
        public Nullable<DateTime> UpdatedAt { get; set; }
        public bool HasWon { get; set; }

        //relation
        public AppUser AppUser { get; set; }
        public string AppUserId { get; set; }

        public List<EventMessage> EventMessages { get; set; }
    }
}
