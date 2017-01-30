namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class name3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.song", "Duration", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.song", "Duration", c => c.Int(nullable: false));
        }
    }
}
