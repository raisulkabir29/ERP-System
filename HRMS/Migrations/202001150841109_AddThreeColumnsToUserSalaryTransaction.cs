namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThreeColumnsToUserSalaryTransaction : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserSalaryTransaction", "OTNOT", c => c.String());
            AddColumn("dbo.UserSalaryTransaction", "ConveyanceAllowance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.UserSalaryTransaction", "FoodAllowance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.UserSalaryTransaction", "PerformanceAllowance", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.UserSalaryTransaction", "AttendanceBonus", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.UserSalaryTransaction", "Stamp", c => c.Int(nullable: false));
            AddColumn("dbo.UserSalaryTransaction", "Gross", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserSalaryTransaction", "Gross");
            DropColumn("dbo.UserSalaryTransaction", "Stamp");
            DropColumn("dbo.UserSalaryTransaction", "AttendanceBonus");
            DropColumn("dbo.UserSalaryTransaction", "PerformanceAllowance");
            DropColumn("dbo.UserSalaryTransaction", "FoodAllowance");
            DropColumn("dbo.UserSalaryTransaction", "ConveyanceAllowance");
            DropColumn("dbo.UserSalaryTransaction", "OTNOT");
        }
    }
}
