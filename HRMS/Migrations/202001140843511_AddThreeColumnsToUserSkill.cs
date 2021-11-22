namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThreeColumnsToUserSkill : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSkill", "MachineName", c => c.String(maxLength: 100));
            AddColumn("dbo.UserSkill", "Process", c => c.String(maxLength: 100));
            AddColumn("dbo.UserSkill", "PerHourCapacity", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSkill", "PerHourCapacity");
            DropColumn("dbo.UserSkill", "Process");
            DropColumn("dbo.UserSkill", "MachineName");
        }
    }
}
