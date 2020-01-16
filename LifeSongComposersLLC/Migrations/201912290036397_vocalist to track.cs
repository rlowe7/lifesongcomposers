namespace LifeSongComposersLLC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vocalisttotrack : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vocalists",
                c => new
                    {
                        VocalistId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Description = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedBy = c.String(),
                    })
                .PrimaryKey(t => t.VocalistId);
            
            CreateTable(
                "dbo.VocalistTracks",
                c => new
                    {
                        Vocalist_VocalistId = c.Int(nullable: false),
                        Track_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Vocalist_VocalistId, t.Track_Id })
                .ForeignKey("dbo.Vocalists", t => t.Vocalist_VocalistId, cascadeDelete: true)
                .ForeignKey("dbo.Tracks", t => t.Track_Id, cascadeDelete: true)
                .Index(t => t.Vocalist_VocalistId)
                .Index(t => t.Track_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VocalistTracks", "Track_Id", "dbo.Tracks");
            DropForeignKey("dbo.VocalistTracks", "Vocalist_VocalistId", "dbo.Vocalists");
            DropIndex("dbo.VocalistTracks", new[] { "Track_Id" });
            DropIndex("dbo.VocalistTracks", new[] { "Vocalist_VocalistId" });
            DropTable("dbo.VocalistTracks");
            DropTable("dbo.Vocalists");
        }
    }
}
