namespace LifeSongComposersLLC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        Directory = c.String(),
                        FileType = c.Int(nullable: false),
                        TrackID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.Tracks", t => t.TrackID, cascadeDelete: true)
                .Index(t => t.TrackID);
            
            CreateTable(
                "dbo.Tracks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Artist = c.String(),
                        Description = c.String(),
                        Url = c.String(),
                        GenreId = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.GenreId, cascadeDelete: true)
                .Index(t => t.GenreId);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tracks", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.FilePaths", "TrackID", "dbo.Tracks");
            DropIndex("dbo.Tracks", new[] { "GenreId" });
            DropIndex("dbo.FilePaths", new[] { "TrackID" });
            DropTable("dbo.Genres");
            DropTable("dbo.Tracks");
            DropTable("dbo.FilePaths");
        }
    }
}
