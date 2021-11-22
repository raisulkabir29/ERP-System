namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEmailTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEmail", "UserId", "dbo.User");
            AddForeignKey("dbo.UserEmail", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEmail", "UserId", "dbo.User");
            AddForeignKey("dbo.UserEmail", "UserId", "dbo.User", "Id");
        }
    }
}
