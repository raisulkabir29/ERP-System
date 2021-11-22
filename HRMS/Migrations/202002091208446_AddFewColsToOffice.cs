namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToOffice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Office", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Office", "AddedBy", c => c.Int());
            AddColumn("dbo.Office", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Office", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Office", "ModifiedBy");
            DropColumn("dbo.Office", "ModifiedDate");
            DropColumn("dbo.Office", "AddedBy");
            DropColumn("dbo.Office", "DateAdded");
        }
    }
}
