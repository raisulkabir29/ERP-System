namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeTerminationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeTermination",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TerminationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        SectionId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        CustomId = c.Int(nullable: false),
                        OccuranceDate = c.DateTime(nullable: false),
                        DetectionDate = c.DateTime(nullable: false),
                        ShowcauseDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 400),
                        ReplyDay = c.String(maxLength: 2),
                        NotificationDay = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        IsPayable = c.String(maxLength: 3),
                        PayableAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.TerminationType", t => t.TerminationId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.TerminationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeTermination", "UserId", "dbo.User");
            DropForeignKey("dbo.EmployeeTermination", "TerminationId", "dbo.TerminationType");
            DropForeignKey("dbo.EmployeeTermination", "DepartmentId", "dbo.Department");
            DropIndex("dbo.EmployeeTermination", new[] { "UserId" });
            DropIndex("dbo.EmployeeTermination", new[] { "DepartmentId" });
            DropIndex("dbo.EmployeeTermination", new[] { "TerminationId" });
            DropTable("dbo.EmployeeTermination");
        }
    }
}
