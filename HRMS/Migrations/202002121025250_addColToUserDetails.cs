namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addColToUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDeails", "FatherOrHusband", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDeails", "FatherOrHusband");
        }
    }
}
