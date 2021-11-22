namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNvarcharToUserLoanPayment : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserLoanPayment", "PaymentMonth", c => c.String(maxLength: 4));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLoanPayment", "PaymentMonth", c => c.Int());
        }
    }
}
