namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserGrade", "DateAdded", c => c.DateTime());
            AddColumn("dbo.UserGrade", "AddedBy", c => c.Int());
            AddColumn("dbo.UserGrade", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserGrade", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserGrade", "ModifiedBy");
            DropColumn("dbo.UserGrade", "ModifiedDate");
            DropColumn("dbo.UserGrade", "AddedBy");
            DropColumn("dbo.UserGrade", "DateAdded");
        }
    }
}
