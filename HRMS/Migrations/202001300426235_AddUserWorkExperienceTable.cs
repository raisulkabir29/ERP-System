namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserWorkExperienceTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserWorkExperience", "UserId", "dbo.User");
            AddForeignKey("dbo.UserWorkExperience", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserWorkExperience", "UserId", "dbo.User");
            AddForeignKey("dbo.UserWorkExperience", "UserId", "dbo.User", "Id");
        }
    }
}
