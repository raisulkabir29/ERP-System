namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPayrollSalaryTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserPayrollSalary", "UserId", "dbo.User");
            AddForeignKey("dbo.UserPayrollSalary", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPayrollSalary", "UserId", "dbo.User");
            AddForeignKey("dbo.UserPayrollSalary", "UserId", "dbo.User", "Id");
        }
    }
}
