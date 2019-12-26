using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using LifeSongComposersLLC.Models;

namespace LifeSongComposersLLC.Models
{
    public class FilePath
    {
      
            public int FilePathId { get; set; }
            [StringLength(255)]
            public string FileName { get; set; }
            public string Directory { get; set; }
            public FileType FileType { get; set; }
            public int TrackID { get; set; }
            public virtual Track Track { get; set; }
        
    }
}