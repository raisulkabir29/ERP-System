namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeAddressTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OfficeAddress", "AddressId", "dbo.UserAddress");
            AddForeignKey("dbo.OfficeAddress", "AddressId", "dbo.UserAddress", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeAddress", "AddressId", "dbo.UserAddress");
            AddForeignKey("dbo.OfficeAddress", "AddressId", "dbo.UserAddress", "Id");
        }
    }
}
