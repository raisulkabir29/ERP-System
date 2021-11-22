namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeAddressTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficeAddress", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.OfficeAddress", "OfficeId", "dbo.Office", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeAddress", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.OfficeAddress", "OfficeId", "dbo.Office", "Id");
        }
    }
}
