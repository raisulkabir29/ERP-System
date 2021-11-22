namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMapingToMenuPermission : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MenuPermission", "UserId", "dbo.User");
            AddForeignKey("dbo.MenuPermission", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MenuPermission", "UserId", "dbo.User");
            AddForeignKey("dbo.MenuPermission", "UserId", "dbo.User", "Id");
        }
    }
}
