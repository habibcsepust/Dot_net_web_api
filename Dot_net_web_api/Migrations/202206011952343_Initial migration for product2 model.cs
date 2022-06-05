namespace Dot_net_web_api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initialmigrationforproduct2model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Product2",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Product2");
        }
    }
}
