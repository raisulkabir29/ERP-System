namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _24122017_1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "AddedBy", c => c.Int());
            AddColumn("dbo.User", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "DateAdded");
            DropColumn("dbo.User", "AddedBy");
        }
    }
}
