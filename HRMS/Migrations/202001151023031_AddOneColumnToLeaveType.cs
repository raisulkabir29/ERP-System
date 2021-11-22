namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOneColumnToLeaveType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveType", "NoOfLeavesPerYear", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveType", "NoOfLeavesPerYear");
        }
    }
}
