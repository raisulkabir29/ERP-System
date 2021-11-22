namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSixColumnsToUserLeaveApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLeaveApplication", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.UserLeaveApplication", "Month", c => c.String(maxLength: 4));
            AddColumn("dbo.UserLeaveApplication", "ApplicationDate", c => c.DateTime());
            AddColumn("dbo.UserLeaveApplication", "NoOfDays", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.UserLeaveApplication", "LeavePurpose", c => c.String(maxLength: 100));
            AddColumn("dbo.UserLeaveApplication", "ApplicationStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.UserLeaveApplication", "ApplicationStatusId");
            AddForeignKey("dbo.UserLeaveApplication", "ApplicationStatusId", "dbo.ApplicationStatus", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLeaveApplication", "ApplicationStatusId", "dbo.ApplicationStatus");
            DropIndex("dbo.UserLeaveApplication", new[] { "ApplicationStatusId" });
            DropColumn("dbo.UserLeaveApplication", "ApplicationStatusId");
            DropColumn("dbo.UserLeaveApplication", "LeavePurpose");
            DropColumn("dbo.UserLeaveApplication", "NoOfDays");
            DropColumn("dbo.UserLeaveApplication", "ApplicationDate");
            DropColumn("dbo.UserLeaveApplication", "Month");
            DropColumn("dbo.UserLeaveApplication", "Year");
        }
    }
}
