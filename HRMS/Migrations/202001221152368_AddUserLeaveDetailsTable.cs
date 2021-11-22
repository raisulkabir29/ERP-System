namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLeaveDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLeaveDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LeaveTypeId = c.Int(nullable: false),
                        LeaveStatusId = c.Int(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        TotUsedLeavesInMonth = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotUsedLeavesPerYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotRemainingLeavesPerYear = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationStatus", t => t.LeaveStatusId, cascadeDelete: true)
                .ForeignKey("dbo.LeaveType", t => t.LeaveTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.LeaveStatusId)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLeaveDetails", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLeaveDetails", "LeaveTypeId", "dbo.LeaveType");
            DropForeignKey("dbo.UserLeaveDetails", "LeaveStatusId", "dbo.ApplicationStatus");
            DropIndex("dbo.UserLeaveDetails", new[] { "UserId" });
            DropIndex("dbo.UserLeaveDetails", new[] { "LeaveTypeId" });
            DropIndex("dbo.UserLeaveDetails", new[] { "LeaveStatusId" });
            DropTable("dbo.UserLeaveDetails");
        }
    }
}
