namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewcolumnsToUserAttendanceStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAttendanceStatus", "DateAdded", c => c.DateTime());
            AddColumn("dbo.UserAttendanceStatus", "AddedBy", c => c.Int());
            AddColumn("dbo.UserAttendanceStatus", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserAttendanceStatus", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAttendanceStatus", "ModifiedBy");
            DropColumn("dbo.UserAttendanceStatus", "ModifiedDate");
            DropColumn("dbo.UserAttendanceStatus", "AddedBy");
            DropColumn("dbo.UserAttendanceStatus", "DateAdded");
        }
    }
}
