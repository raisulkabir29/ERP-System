namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToEmployeeAllowanceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAllowanceType", "DateAdded", c => c.DateTime());
            AddColumn("dbo.EmployeeAllowanceType", "AddedBy", c => c.Int());
            AddColumn("dbo.EmployeeAllowanceType", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.EmployeeAllowanceType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeAllowanceType", "ModifiedBy");
            DropColumn("dbo.EmployeeAllowanceType", "ModifiedDate");
            DropColumn("dbo.EmployeeAllowanceType", "AddedBy");
            DropColumn("dbo.EmployeeAllowanceType", "DateAdded");
        }
    }
}
