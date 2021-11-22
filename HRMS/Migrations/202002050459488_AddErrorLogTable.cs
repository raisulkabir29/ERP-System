namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddErrorLogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ErrorLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        ErrorFrom = c.String(maxLength: 1024),
                        ErrorFor = c.String(maxLength: 1024),
                        ErrorMessage = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ErrorLogs", "UserId", "dbo.User");
            DropIndex("dbo.ErrorLogs", new[] { "UserId" });
            DropTable("dbo.ErrorLogs");
        }
    }
}
