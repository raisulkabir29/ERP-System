namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserSkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSkill", "DateAdded", c => c.DateTime());
            AddColumn("dbo.UserSkill", "AddedBy", c => c.Int());
            AddColumn("dbo.UserSkill", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserSkill", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSkill", "ModifiedBy");
            DropColumn("dbo.UserSkill", "ModifiedDate");
            DropColumn("dbo.UserSkill", "AddedBy");
            DropColumn("dbo.UserSkill", "DateAdded");
        }
    }
}
