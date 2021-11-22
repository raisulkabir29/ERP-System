namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAttendenceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAttendence", "UserId", "dbo.User");
            AddForeignKey("dbo.UserAttendence", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAttendence", "UserId", "dbo.User");
            AddForeignKey("dbo.UserAttendence", "UserId", "dbo.User", "Id");
        }
    }
}
