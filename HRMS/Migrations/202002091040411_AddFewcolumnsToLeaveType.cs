namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewcolumnsToLeaveType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LeaveType", "DateAdded", c => c.DateTime());
            AddColumn("dbo.LeaveType", "AddedBy", c => c.Int());
            AddColumn("dbo.LeaveType", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.LeaveType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LeaveType", "ModifiedBy");
            DropColumn("dbo.LeaveType", "ModifiedDate");
            DropColumn("dbo.LeaveType", "AddedBy");
            DropColumn("dbo.LeaveType", "DateAdded");
        }
    }
}
