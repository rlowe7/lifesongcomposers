using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LifeSongComposers.Models
{
    public class Genres : CreatedDateAndBy
    {
        public int GenresId { get; set; }
        public string Name { get; set; }
        public List<Track> Tracks { get; set; }
    }
}
