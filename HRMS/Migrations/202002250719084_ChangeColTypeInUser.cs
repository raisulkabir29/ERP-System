namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColTypeInUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "CustomId", c => c.String(nullable: false, maxLength: 6));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "CustomId", c => c.Int(nullable: false));
        }
    }
}
