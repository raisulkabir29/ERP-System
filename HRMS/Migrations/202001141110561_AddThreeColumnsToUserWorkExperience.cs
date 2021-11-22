namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThreeColumnsToUserWorkExperience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserWorkExperience", "LastSalary", c => c.Int());
            AddColumn("dbo.UserWorkExperience", "JobDuration", c => c.Int());
            AddColumn("dbo.UserWorkExperience", "ReasonForLeave", c => c.String(maxLength: 400));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserWorkExperience", "ReasonForLeave");
            DropColumn("dbo.UserWorkExperience", "JobDuration");
            DropColumn("dbo.UserWorkExperience", "LastSalary");
        }
    }
}
