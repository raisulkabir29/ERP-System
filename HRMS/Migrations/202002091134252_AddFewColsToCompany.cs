namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToCompany : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Company", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Company", "AddedBy", c => c.Int());
            AddColumn("dbo.Company", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Company", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Company", "ModifiedBy");
            DropColumn("dbo.Company", "ModifiedDate");
            DropColumn("dbo.Company", "AddedBy");
            DropColumn("dbo.Company", "DateAdded");
        }
    }
}
