namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNvarchar17ToNationalIdToUser : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.User", "NationalId", c => c.String(maxLength: 17));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.User", "NationalId", c => c.String(maxLength: 100));
        }
    }
}
