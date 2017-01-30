namespace project1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.album",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        names = c.String(),
                        yearReleased = c.Int(nullable: false),
                        producer = c.String(),
                        recodLabel = c.String(),
                        price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.album");
        }
    }
}
