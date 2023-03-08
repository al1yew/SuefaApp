using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuefaApp.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        public Nullable<DateTime> CreatedAt { get; set; }
    }
}
