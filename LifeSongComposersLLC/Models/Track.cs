using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LifeSongComposersLLC.Models
{
    public class Track:CreatedDateAndBy
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string Description { get; set; }
        public virtual ICollection<FilePath> FilePaths { get; set; }
        public string Url { get; set; }
        public Genre Genre { get; set; }
        public int GenreId { get; set; }
       
        
    }
}
