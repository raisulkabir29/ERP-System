namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserOvertimeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserOvertime",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        PresentDate = c.DateTime(nullable: false),
                        JobTitleId = c.Int(nullable: false),
                        GradeId = c.Int(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        DailyOTHours = c.Int(nullable: false),
                        OvertimeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OvertimeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.JobTitle", t => t.JobTitleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.JobTitleId)
                .Index(t => t.GradeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserOvertime", "UserId", "dbo.User");
            DropForeignKey("dbo.UserOvertime", "JobTitleId", "dbo.JobTitle");
            DropForeignKey("dbo.UserOvertime", "GradeId", "dbo.Grade");
            DropIndex("dbo.UserOvertime", new[] { "GradeId" });
            DropIndex("dbo.UserOvertime", new[] { "JobTitleId" });
            DropIndex("dbo.UserOvertime", new[] { "UserId" });
            DropTable("dbo.UserOvertime");
        }
    }
}
