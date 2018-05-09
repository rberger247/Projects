namespace resterauntWeb.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.resteraunt",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 25),
                        Street1 = c.String(),
                        City = c.String(),
                        State = c.String(),
                        Country = c.String(),
                        phone = c.String(),
                        Zipcode = c.String(),
                        AvgRating = c.Int(),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Double(nullable: false),
                        Comments = c.String(maxLength: 200),
                        Created = c.DateTime(),
                        Modified = c.DateTime(),
                        RestaurauntId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.resteraunt", t => t.RestaurauntId, cascadeDelete: true)
                .Index(t => t.RestaurauntId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "RestaurauntId", "dbo.resteraunt");
            DropIndex("dbo.Reviews", new[] { "RestaurauntId" });
            DropTable("dbo.Reviews");
            DropTable("dbo.resteraunt");
        }
    }
}
