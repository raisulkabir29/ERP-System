namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColInUserLeaveApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLeaveApplication", "StartingTime", c => c.DateTime());
            AddColumn("dbo.UserLeaveApplication", "EndingTime", c => c.DateTime());
            AddColumn("dbo.UserLeaveApplication", "ShortLeaveHours", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.UserLeaveApplication", "ForwardedTo", c => c.Int());
            AddColumn("dbo.UserLeaveApplication", "AddedBy", c => c.Int());
            AddColumn("dbo.UserLeaveApplication", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserLeaveApplication", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.UserLeaveApplication", "NoOfDays", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLeaveApplication", "NoOfDays", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.UserLeaveApplication", "ModifiedBy");
            DropColumn("dbo.UserLeaveApplication", "ModifiedDate");
            DropColumn("dbo.UserLeaveApplication", "AddedBy");
            DropColumn("dbo.UserLeaveApplication", "ForwardedTo");
            DropColumn("dbo.UserLeaveApplication", "ShortLeaveHours");
            DropColumn("dbo.UserLeaveApplication", "EndingTime");
            DropColumn("dbo.UserLeaveApplication", "StartingTime");
        }
    }
}
