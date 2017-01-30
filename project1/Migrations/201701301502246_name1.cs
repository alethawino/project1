namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.album", "band_ID", c => c.Int());
            CreateIndex("dbo.album", "band_ID");
            AddForeignKey("dbo.album", "band_ID", "dbo.bands", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.album", "band_ID", "dbo.bands");
            DropIndex("dbo.album", new[] { "band_ID" });
            DropColumn("dbo.album", "band_ID");
        }
    }
}
