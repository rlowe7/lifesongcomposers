using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeSongComposersLLC.Models
{
    public class Vocalist : CreatedDateAndBy
    {
        public int VocalistId { get; set; }
        public string FirstName  { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; }
       
    }

    public enum Gender
    {
        Male,
        Female
    }
}
