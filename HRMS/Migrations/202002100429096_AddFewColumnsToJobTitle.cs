namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColumnsToJobTitle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobTitle", "DateAdded", c => c.DateTime());
            AddColumn("dbo.JobTitle", "AddedBy", c => c.Int());
            AddColumn("dbo.JobTitle", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.JobTitle", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobTitle", "ModifiedBy");
            DropColumn("dbo.JobTitle", "ModifiedDate");
            DropColumn("dbo.JobTitle", "AddedBy");
            DropColumn("dbo.JobTitle", "DateAdded");
        }
    }
}
