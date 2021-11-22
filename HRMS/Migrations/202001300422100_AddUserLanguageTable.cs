namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLanguageTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserLanguage", "UserId", "dbo.User");
            AddForeignKey("dbo.UserLanguage", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLanguage", "UserId", "dbo.User");
            AddForeignKey("dbo.UserLanguage", "UserId", "dbo.User", "Id");
        }
    }
}
