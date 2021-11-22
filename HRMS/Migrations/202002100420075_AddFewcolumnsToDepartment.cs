namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewcolumnsToDepartment : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Department", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Department", "AddedBy", c => c.Int());
            AddColumn("dbo.Department", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Department", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Department", "ModifiedBy");
            DropColumn("dbo.Department", "ModifiedDate");
            DropColumn("dbo.Department", "AddedBy");
            DropColumn("dbo.Department", "DateAdded");
        }
    }
}
