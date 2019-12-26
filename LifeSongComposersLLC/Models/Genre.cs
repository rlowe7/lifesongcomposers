using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace LifeSongComposersLLC.Models
{
    public class Genre : CreatedDateAndBy
    {
        [Key]
        public int GenreId { get; set; }
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
