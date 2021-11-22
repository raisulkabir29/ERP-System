namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNvarchar3ToUserSalaryTransaction : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserSalaryTransaction", "OTNOT", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserSalaryTransaction", "OTNOT", c => c.String());
        }
    }
}
