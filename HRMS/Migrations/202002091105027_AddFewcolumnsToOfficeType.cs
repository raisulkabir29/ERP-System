namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewcolumnsToOfficeType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OfficeType", "DateAdded", c => c.DateTime());
            AddColumn("dbo.OfficeType", "AddedBy", c => c.Int());
            AddColumn("dbo.OfficeType", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.OfficeType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OfficeType", "ModifiedBy");
            DropColumn("dbo.OfficeType", "ModifiedDate");
            DropColumn("dbo.OfficeType", "AddedBy");
            DropColumn("dbo.OfficeType", "DateAdded");
        }
    }
}
