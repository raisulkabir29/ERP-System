namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColInUserLeaveApplication3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserLeaveApplication", "ShortLeaveHours", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLeaveApplication", "ShortLeaveHours", c => c.String(maxLength: 5));
        }
    }
}
