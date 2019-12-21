using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LifeSongComposers.Models
{
    public class Track:CreatedDateAndBy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public Genres Genres { get; set; }
        public int GenresId { get; set; }
       
        
    }
}
