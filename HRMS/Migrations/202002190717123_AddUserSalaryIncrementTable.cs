namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserSalaryIncrementTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserSalaryIncrement",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        OTNOT = c.String(nullable: false, maxLength: 3),
                        GrossSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BasicSalary = c.Decimal(precision: 18, scale: 2),
                        IncrementPercentage = c.Int(),
                        YearOfIncrement = c.Int(),
                        IncrementOnGrossOrBasic = c.Int(),
                        NewGrossSalary = c.Decimal(precision: 18, scale: 2),
                        NewBasicSalary = c.Decimal(precision: 18, scale: 2),
                        OvertimeRate = c.Decimal(precision: 18, scale: 2),
                        Year = c.Int(nullable: false),
                        Month = c.String(maxLength: 4),
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
            DropForeignKey("dbo.UserSalaryIncrement", "UserId", "dbo.User");
            DropIndex("dbo.UserSalaryIncrement", new[] { "UserId" });
            DropTable("dbo.UserSalaryIncrement");
        }
    }
}
