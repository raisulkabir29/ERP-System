namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserEducationTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserEducation", "InstitutionId", "dbo.University");
            AddForeignKey("dbo.UserEducation", "InstitutionId", "dbo.University", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserEducation", "InstitutionId", "dbo.University");
            AddForeignKey("dbo.UserEducation", "InstitutionId", "dbo.University", "Id");
        }
    }
}
