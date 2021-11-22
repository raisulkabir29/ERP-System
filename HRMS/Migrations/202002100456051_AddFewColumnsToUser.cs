namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColumnsToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "CustomId", c => c.Int(nullable: false));
            AddColumn("dbo.User", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.User", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "ModifiedBy");
            DropColumn("dbo.User", "ModifiedDate");
            DropColumn("dbo.User", "CustomId");
        }
    }
}
