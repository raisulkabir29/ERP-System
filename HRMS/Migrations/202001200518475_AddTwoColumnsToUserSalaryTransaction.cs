namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTwoColumnsToUserSalaryTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSalaryTransaction", "Year", c => c.Int(nullable: false));
            AddColumn("dbo.UserSalaryTransaction", "Month", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSalaryTransaction", "Month");
            DropColumn("dbo.UserSalaryTransaction", "Year");
        }
    }
}
