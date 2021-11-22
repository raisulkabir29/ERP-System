namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserLoanApplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserLoanApplication", "ForwardedTo", c => c.Int());
            AddColumn("dbo.UserLoanApplication", "RecommendedBy", c => c.Int());
            AddColumn("dbo.UserLoanApplication", "ModifiedBy", c => c.Int());
            AddColumn("dbo.UserLoanApplication", "ModifiedDate", c => c.DateTime());
            AlterColumn("dbo.UserLoanApplication", "IsApproved", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserLoanApplication", "IsApproved", c => c.Boolean(nullable: false));
            DropColumn("dbo.UserLoanApplication", "ModifiedDate");
            DropColumn("dbo.UserLoanApplication", "ModifiedBy");
            DropColumn("dbo.UserLoanApplication", "RecommendedBy");
            DropColumn("dbo.UserLoanApplication", "ForwardedTo");
        }
    }
}
