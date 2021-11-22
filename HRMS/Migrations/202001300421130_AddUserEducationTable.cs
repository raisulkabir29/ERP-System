namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEducationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEducation", "UserId", "dbo.User");
            AddForeignKey("dbo.UserEducation", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEducation", "UserId", "dbo.User");
            AddForeignKey("dbo.UserEducation", "UserId", "dbo.User", "Id");
        }
    }
}
