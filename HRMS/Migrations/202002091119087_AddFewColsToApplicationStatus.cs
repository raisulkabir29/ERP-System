namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToApplicationStatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationStatus", "DateAdded", c => c.DateTime());
            AddColumn("dbo.ApplicationStatus", "AddedBy", c => c.Int());
            AddColumn("dbo.ApplicationStatus", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.ApplicationStatus", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationStatus", "ModifiedBy");
            DropColumn("dbo.ApplicationStatus", "ModifiedDate");
            DropColumn("dbo.ApplicationStatus", "AddedBy");
            DropColumn("dbo.ApplicationStatus", "DateAdded");
        }
    }
}
