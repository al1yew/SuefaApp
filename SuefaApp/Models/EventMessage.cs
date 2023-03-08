using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Models
{
    public class EventMessage : BaseModel
    {
        public string Message { get; set; }

        //relations
        public Event Event { get; set; }
        public int EventId { get; set; }
    }
}
