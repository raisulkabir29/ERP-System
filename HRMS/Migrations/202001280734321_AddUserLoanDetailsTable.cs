namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLoanDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLoanDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                        LoanApplicationId = c.Int(nullable: false),
                        LoanStatusId = c.Int(nullable: false),
                        LoanGivenDate = c.DateTime(nullable: false),
                        LoanGiven = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Stamp = c.Int(),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationStatus", t => t.LoanStatusId, cascadeDelete: true)
                .ForeignKey("dbo.LoanType", t => t.LoanTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserLoanApplication", t => t.LoanApplicationId)
                .Index(t => t.UserId)
                .Index(t => t.LoanTypeId)
                .Index(t => t.LoanApplicationId)
                .Index(t => t.LoanStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLoanDetails", "LoanApplicationId", "dbo.UserLoanApplication");
            DropForeignKey("dbo.UserLoanDetails", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLoanDetails", "LoanTypeId", "dbo.LoanType");
            DropForeignKey("dbo.UserLoanDetails", "LoanStatusId", "dbo.ApplicationStatus");
            DropIndex("dbo.UserLoanDetails", new[] { "LoanStatusId" });
            DropIndex("dbo.UserLoanDetails", new[] { "LoanApplicationId" });
            DropIndex("dbo.UserLoanDetails", new[] { "LoanTypeId" });
            DropIndex("dbo.UserLoanDetails", new[] { "UserId" });
            DropTable("dbo.UserLoanDetails");
        }
    }
}
