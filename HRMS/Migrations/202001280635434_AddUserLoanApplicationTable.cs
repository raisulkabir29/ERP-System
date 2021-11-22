namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLoanApplicationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLoanApplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LoanTypeId = c.Int(nullable: false),
                        LoanStatusId = c.Int(nullable: false),
                        ApplicationDate = c.DateTime(nullable: false),
                        PossibleDisburseDate = c.DateTime(nullable: false),
                        MaxAmountAllowed = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LoanAmountApplied = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NoOfInstallment = c.Int(),
                        InstallmentAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 1000),
                        IsApproved = c.Boolean(nullable: false),
                        ApprovedBy = c.Int(),
                        AddedBy = c.Int(),
                        DateAdded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationStatus", t => t.LoanStatusId, cascadeDelete: true)
                .ForeignKey("dbo.LoanType", t => t.LoanTypeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.LoanTypeId)
                .Index(t => t.LoanStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLoanApplication", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLoanApplication", "LoanTypeId", "dbo.LoanType");
            DropForeignKey("dbo.UserLoanApplication", "LoanStatusId", "dbo.ApplicationStatus");
            DropIndex("dbo.UserLoanApplication", new[] { "LoanStatusId" });
            DropIndex("dbo.UserLoanApplication", new[] { "LoanTypeId" });
            DropIndex("dbo.UserLoanApplication", new[] { "UserId" });
            DropTable("dbo.UserLoanApplication");
        }
    }
}
