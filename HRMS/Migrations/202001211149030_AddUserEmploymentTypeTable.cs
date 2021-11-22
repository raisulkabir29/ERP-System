namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEmploymentTypeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserEmploymentType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmploymentTypeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.EmploymentType", t => t.EmploymentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.EmploymentTypeId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEmploymentType", "UserId", "dbo.User");
            DropForeignKey("dbo.UserEmploymentType", "EmploymentTypeId", "dbo.EmploymentType");
            DropForeignKey("dbo.UserEmploymentType", "DepartmentId", "dbo.Department");
            DropIndex("dbo.UserEmploymentType", new[] { "UserId" });
            DropIndex("dbo.UserEmploymentType", new[] { "EmploymentTypeId" });
            DropIndex("dbo.UserEmploymentType", new[] { "DepartmentId" });
            DropTable("dbo.UserEmploymentType");
        }
    }
}
