namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Add3ColumnsToEmployeeAllowanceType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeAllowanceType", "OTNOT", c => c.String(maxLength: 3));
            AddColumn("dbo.EmployeeAllowanceType", "Code", c => c.String(maxLength: 10));
            AddColumn("dbo.EmployeeAllowanceType", "Value", c => c.Decimal(precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeAllowanceType", "Value");
            DropColumn("dbo.EmployeeAllowanceType", "Code");
            DropColumn("dbo.EmployeeAllowanceType", "OTNOT");
        }
    }
}
