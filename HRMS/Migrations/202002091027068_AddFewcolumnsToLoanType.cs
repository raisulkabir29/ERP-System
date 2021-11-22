namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewcolumnsToLoanType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.LoanType", "DateAdded", c => c.DateTime());
            AddColumn("dbo.LoanType", "AddedBy", c => c.Int());
            AddColumn("dbo.LoanType", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.LoanType", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.LoanType", "ModifiedBy");
            DropColumn("dbo.LoanType", "ModifiedDate");
            DropColumn("dbo.LoanType", "AddedBy");
            DropColumn("dbo.LoanType", "DateAdded");
        }
    }
}
