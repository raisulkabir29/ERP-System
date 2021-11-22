namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Office", "OfficeTypeId", "dbo.OfficeType");
            AddForeignKey("dbo.Office", "OfficeTypeId", "dbo.OfficeType", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Office", "OfficeTypeId", "dbo.OfficeType");
            AddForeignKey("dbo.Office", "OfficeTypeId", "dbo.OfficeType", "Id");
        }
    }
}
