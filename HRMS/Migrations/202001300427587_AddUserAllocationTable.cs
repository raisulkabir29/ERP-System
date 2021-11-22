namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAllocationTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAllocation", "UserId", "dbo.User");
            AddForeignKey("dbo.UserAllocation", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAllocation", "UserId", "dbo.User");
            AddForeignKey("dbo.UserAllocation", "UserId", "dbo.User", "Id");
        }
    }
}
