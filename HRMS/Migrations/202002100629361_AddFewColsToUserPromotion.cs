namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserPromotion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserPromotion", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserPromotion", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserPromotion", "ModifiedBy");
            DropColumn("dbo.UserPromotion", "ModifiedDate");
        }
    }
}
