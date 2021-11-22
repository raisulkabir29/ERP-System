namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPolicyTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Policy", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.Policy", "OfficeId", "dbo.Office", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Policy", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.Policy", "OfficeId", "dbo.Office", "Id");
        }
    }
}
