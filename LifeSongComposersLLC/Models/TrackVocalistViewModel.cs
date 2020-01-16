using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LifeSongComposersLLC.Models
{
    public class TrackVocalistViewModel
    {
        public int VocalistId { get; set; }
        public string VocalistName { get; set; }
        public string TrackName { get; set; }
        public int TrackId { get; set; }
    }
}