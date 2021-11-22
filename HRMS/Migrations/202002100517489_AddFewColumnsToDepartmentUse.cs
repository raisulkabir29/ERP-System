namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColumnsToDepartmentUse : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DepartmentUser", "DateAdded", c => c.DateTime());
            AddColumn("dbo.DepartmentUser", "AddedBy", c => c.Int());
            AddColumn("dbo.DepartmentUser", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.DepartmentUser", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DepartmentUser", "ModifiedBy");
            DropColumn("dbo.DepartmentUser", "ModifiedDate");
            DropColumn("dbo.DepartmentUser", "AddedBy");
            DropColumn("dbo.DepartmentUser", "DateAdded");
        }
    }
}
