using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LifeSongComposersLLC.Models
{
    public class LifeSongComposersLLCContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LifeSongComposersLLCContext() : base("name=LifeSongComposersLLCContext")
        {
        }

        public System.Data.Entity.DbSet<LifeSongComposersLLC.Models.Track> Tracks { get; set; }

        public System.Data.Entity.DbSet<LifeSongComposersLLC.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<LifeSongComposersLLC.Models.FilePath> FilePaths { get; set; }
    }
}
