namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSkillTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.User");
            AddForeignKey("dbo.UserSkill", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.User");
            AddForeignKey("dbo.UserSkill", "UserId", "dbo.User", "Id");
        }
    }
}
