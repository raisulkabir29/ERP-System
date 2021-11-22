namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPhoneTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPhone", "UserId", "dbo.User");
            AddForeignKey("dbo.UserPhone", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPhone", "UserId", "dbo.User");
            AddForeignKey("dbo.UserPhone", "UserId", "dbo.User", "Id");
        }
    }
}
