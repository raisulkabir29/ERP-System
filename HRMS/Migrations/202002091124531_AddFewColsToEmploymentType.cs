namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToEmploymentType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmploymentType", "DateAdded", c => c.DateTime());
            AddColumn("dbo.EmploymentType", "AddedBy", c => c.Int());
            AddColumn("dbo.EmploymentType", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.EmploymentType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmploymentType", "ModifiedBy");
            DropColumn("dbo.EmploymentType", "ModifiedDate");
            DropColumn("dbo.EmploymentType", "AddedBy");
            DropColumn("dbo.EmploymentType", "DateAdded");
        }
    }
}
