namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNationalIdToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.User", "NationalId", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.User", "NationalId");
        }
    }
}
