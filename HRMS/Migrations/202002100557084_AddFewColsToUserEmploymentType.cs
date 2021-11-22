namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserEmploymentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserEmploymentType", "DateAdded", c => c.DateTime());
            AddColumn("dbo.UserEmploymentType", "AddedBy", c => c.Int());
            AddColumn("dbo.UserEmploymentType", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserEmploymentType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserEmploymentType", "ModifiedBy");
            DropColumn("dbo.UserEmploymentType", "ModifiedDate");
            DropColumn("dbo.UserEmploymentType", "AddedBy");
            DropColumn("dbo.UserEmploymentType", "DateAdded");
        }
    }
}
