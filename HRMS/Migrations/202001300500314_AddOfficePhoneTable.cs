namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficePhoneTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficePhone", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.OfficePhone", "OfficeId", "dbo.Office", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficePhone", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.OfficePhone", "OfficeId", "dbo.Office", "Id");
        }
    }
}
