namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserLoanPaymentTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLoanPayment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LoanApplicationId = c.Int(nullable: false),
                        PaymentDate = c.DateTime(),
                        PaymentYear = c.Int(),
                        PaymentMonth = c.Int(),
                        CurrentInstallment = c.Int(),
                        CurrentInstallmentPaid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RemainingInstallment = c.Int(),
                        PaymentsDue = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(maxLength: 400),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserLoanDetails", t => t.LoanApplicationId)
                .Index(t => t.UserId)
                .Index(t => t.LoanApplicationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserLoanPayment", "LoanApplicationId", "dbo.UserLoanDetails");
            DropForeignKey("dbo.UserLoanPayment", "UserId", "dbo.User");
            DropIndex("dbo.UserLoanPayment", new[] { "LoanApplicationId" });
            DropIndex("dbo.UserLoanPayment", new[] { "UserId" });
            DropTable("dbo.UserLoanPayment");
        }
    }
}
