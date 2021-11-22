namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCODonMenuPermissionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu");
            AddForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu");
            AddForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu", "Id");
        }
    }
}
