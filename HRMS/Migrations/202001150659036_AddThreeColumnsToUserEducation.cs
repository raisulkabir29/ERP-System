namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThreeColumnsToUserEducation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserEducation", "InstitutionName", c => c.String(maxLength: 100));
            AddColumn("dbo.UserEducation", "LatestDegree", c => c.String(maxLength: 50));
            AddColumn("dbo.UserEducation", "DivisionOrGrade", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserEducation", "DivisionOrGrade");
            DropColumn("dbo.UserEducation", "LatestDegree");
            DropColumn("dbo.UserEducation", "InstitutionName");
        }
    }
}
