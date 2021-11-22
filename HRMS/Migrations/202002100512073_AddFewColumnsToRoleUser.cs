namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColumnsToRoleUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RoleUser", "DateAdded", c => c.DateTime());
            AddColumn("dbo.RoleUser", "AddedBy", c => c.Int());
            AddColumn("dbo.RoleUser", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.RoleUser", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.RoleUser", "ModifiedBy");
            DropColumn("dbo.RoleUser", "ModifiedDate");
            DropColumn("dbo.RoleUser", "AddedBy");
            DropColumn("dbo.RoleUser", "DateAdded");
        }
    }
}
