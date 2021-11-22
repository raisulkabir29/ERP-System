namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewcolumnsToGender : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Gender", "TitleBN", c => c.String(maxLength: 20));
            AddColumn("dbo.Gender", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Gender", "AddedBy", c => c.Int());
            AddColumn("dbo.Gender", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Gender", "ModifiedBy", c => c.Int());
            AlterColumn("dbo.Gender", "Title", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Gender", "Title", c => c.String(nullable: false));
            DropColumn("dbo.Gender", "ModifiedBy");
            DropColumn("dbo.Gender", "ModifiedDate");
            DropColumn("dbo.Gender", "AddedBy");
            DropColumn("dbo.Gender", "DateAdded");
            DropColumn("dbo.Gender", "TitleBN");
        }
    }
}
