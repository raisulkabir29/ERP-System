namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeColInLeaveType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.LeaveType", "NoOfLeavesPerYear", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.LeaveType", "NoOfLeavesPerYear", c => c.Int(nullable: false));
        }
    }
}
