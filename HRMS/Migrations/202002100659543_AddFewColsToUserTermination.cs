namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserTermination : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTermination", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserTermination", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTermination", "ModifiedBy");
            DropColumn("dbo.UserTermination", "ModifiedDate");
        }
    }
}
