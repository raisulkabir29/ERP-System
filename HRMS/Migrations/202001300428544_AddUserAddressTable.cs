namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAddressTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAddress", "UserId", "dbo.User");
            AddForeignKey("dbo.UserAddress", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAddress", "UserId", "dbo.User");
            AddForeignKey("dbo.UserAddress", "UserId", "dbo.User", "Id");
        }
    }
}
