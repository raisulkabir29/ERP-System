namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLeaveApplicationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserLeaveApplication", "UserId", "dbo.User");
            AddForeignKey("dbo.UserLeaveApplication", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLeaveApplication", "UserId", "dbo.User");
            AddForeignKey("dbo.UserLeaveApplication", "UserId", "dbo.User", "Id");
        }
    }
}
