namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAuditLogTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuditLogs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(),
                        CreatedDate = c.DateTime(nullable: false),
                        CreatedDateTime = c.DateTime(nullable: false),
                        Action = c.Int(nullable: false),
                        ModuleName = c.String(maxLength: 1024),
                        SubModuleName = c.String(maxLength: 1024),
                        ActionFrom = c.String(maxLength: 1024),
                        ActionMessage = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuditLogs", "UserId", "dbo.User");
            DropIndex("dbo.AuditLogs", new[] { "UserId" });
            DropTable("dbo.AuditLogs");
        }
    }
}
