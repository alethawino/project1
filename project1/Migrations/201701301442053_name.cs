namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.song",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lyrics = c.String(),
                        Duration = c.Int(nullable: false),
                        album_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.album", t => t.album_id)
                .Index(t => t.album_id);
            
            CreateTable(
                "dbo.bands",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        genre = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.song", "album_id", "dbo.album");
            DropIndex("dbo.song", new[] { "album_id" });
            DropTable("dbo.bands");
            DropTable("dbo.song");
        }
    }
}
