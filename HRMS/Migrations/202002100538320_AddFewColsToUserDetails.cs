namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDeails", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserDeails", "ModifiedBy", c => c.Int());
            DropColumn("dbo.UserDeails", "CustomId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserDeails", "CustomId", c => c.Int());
            DropColumn("dbo.UserDeails", "ModifiedBy");
            DropColumn("dbo.UserDeails", "ModifiedDate");
        }
    }
}
