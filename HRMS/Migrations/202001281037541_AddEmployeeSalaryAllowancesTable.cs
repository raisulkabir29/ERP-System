namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmployeeSalaryAllowancesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeeSalaryAllowances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        OTNOT = c.String(maxLength: 3),
                        Gross = c.Decimal(precision: 18, scale: 2),
                        HRAllowanceOT = c.Decimal(precision: 18, scale: 2),
                        HRAllowanceNOT = c.Decimal(precision: 18, scale: 2),
                        MedAllowanceOT = c.Decimal(precision: 18, scale: 2),
                        MedAllowanceNOT = c.Decimal(precision: 18, scale: 2),
                        ConAllowanceOT = c.Decimal(precision: 18, scale: 2),
                        ConAllowanceNOT = c.Decimal(precision: 18, scale: 2),
                        FoodAllowanceOT = c.Decimal(precision: 18, scale: 2),
                        FoodAllowanceNOT = c.Decimal(precision: 18, scale: 2),
                        PerAllowanceOT = c.Decimal(precision: 18, scale: 2),
                        PerAllowanceNOT = c.Decimal(precision: 18, scale: 2),
                        AttendBonOT = c.Decimal(precision: 18, scale: 2),
                        AttendBonNOT = c.Decimal(precision: 18, scale: 2),
                        BasicOT = c.Decimal(precision: 18, scale: 2),
                        BasicNOT = c.Decimal(precision: 18, scale: 2),
                        Basic = c.Decimal(precision: 18, scale: 2),
                        HouseRentAllowance = c.Decimal(precision: 18, scale: 2),
                        MedicalAllowance = c.Decimal(precision: 18, scale: 2),
                        ConveyanceAllowance = c.Decimal(precision: 18, scale: 2),
                        FoodAllowance = c.Decimal(precision: 18, scale: 2),
                        PerformanceAllowance = c.Decimal(precision: 18, scale: 2),
                        AttendanceBonus = c.Decimal(precision: 18, scale: 2),
                        SalaryPayableDate = c.DateTime(),
                        Remarks = c.String(maxLength: 400),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EmployeeSalaryAllowances", "UserId", "dbo.User");
            DropIndex("dbo.EmployeeSalaryAllowances", new[] { "UserId" });
            DropTable("dbo.EmployeeSalaryAllowances");
        }
    }
}
