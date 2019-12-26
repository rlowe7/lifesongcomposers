using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeSongComposersLLC.Models
{
    public class CreatedDateAndBy
    {
        public DateTime CreatedDate { get; set; }
        public String CreatedBy { get; set; }

        public CreatedDateAndBy()
        {
            this.CreatedBy = "Admin";
            this.CreatedDate = DateTime.UtcNow;
        }
    }

}
