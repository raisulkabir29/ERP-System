namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserWorkExperience : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserWorkExperience", "DateAdded", c => c.DateTime());
            AddColumn("dbo.UserWorkExperience", "AddedBy", c => c.Int());
            AddColumn("dbo.UserWorkExperience", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserWorkExperience", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserWorkExperience", "ModifiedBy");
            DropColumn("dbo.UserWorkExperience", "ModifiedDate");
            DropColumn("dbo.UserWorkExperience", "AddedBy");
            DropColumn("dbo.UserWorkExperience", "DateAdded");
        }
    }
}
