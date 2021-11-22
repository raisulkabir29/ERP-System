namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserAllocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAllocation", "DateAdded", c => c.DateTime());
            AddColumn("dbo.UserAllocation", "AddedBy", c => c.Int());
            AddColumn("dbo.UserAllocation", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserAllocation", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAllocation", "ModifiedBy");
            DropColumn("dbo.UserAllocation", "ModifiedDate");
            DropColumn("dbo.UserAllocation", "AddedBy");
            DropColumn("dbo.UserAllocation", "DateAdded");
        }
    }
}
