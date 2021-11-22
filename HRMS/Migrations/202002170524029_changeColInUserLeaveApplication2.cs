namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColInUserLeaveApplication2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLeaveApplication", "StartTime", c => c.String(maxLength: 5));
            AddColumn("dbo.UserLeaveApplication", "EndTime", c => c.String(maxLength: 5));
            AlterColumn("dbo.UserLeaveApplication", "ShortLeaveHours", c => c.String(maxLength: 5));
            DropColumn("dbo.UserLeaveApplication", "StartingTime");
            DropColumn("dbo.UserLeaveApplication", "EndingTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserLeaveApplication", "EndingTime", c => c.DateTime());
            AddColumn("dbo.UserLeaveApplication", "StartingTime", c => c.DateTime());
            AlterColumn("dbo.UserLeaveApplication", "ShortLeaveHours", c => c.Decimal(precision: 18, scale: 2));
            DropColumn("dbo.UserLeaveApplication", "EndTime");
            DropColumn("dbo.UserLeaveApplication", "StartTime");
        }
    }
}
