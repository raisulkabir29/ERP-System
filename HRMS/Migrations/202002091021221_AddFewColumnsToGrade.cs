namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColumnsToGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grade", "TofsilBN", c => c.String(maxLength: 100));
            AddColumn("dbo.Grade", "GradeNoBN", c => c.String(maxLength: 2));
            AddColumn("dbo.Grade", "DateAdded", c => c.DateTime());
            AddColumn("dbo.Grade", "AddedBy", c => c.Int());
            AddColumn("dbo.Grade", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.Grade", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grade", "ModifiedBy");
            DropColumn("dbo.Grade", "ModifiedDate");
            DropColumn("dbo.Grade", "AddedBy");
            DropColumn("dbo.Grade", "DateAdded");
            DropColumn("dbo.Grade", "GradeNoBN");
            DropColumn("dbo.Grade", "TofsilBN");
        }
    }
}
