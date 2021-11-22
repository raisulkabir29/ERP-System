namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDepartmentUserTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DepartmentUser", "UserId", "dbo.User");
            DropForeignKey("dbo.DepartmentUser", "DepartmentId", "dbo.Department");
            DropIndex("dbo.DepartmentUser", new[] { "UserId" });
            DropIndex("dbo.DepartmentUser", new[] { "DepartmentId" });
            DropTable("dbo.DepartmentUser");
        }
    }
}
