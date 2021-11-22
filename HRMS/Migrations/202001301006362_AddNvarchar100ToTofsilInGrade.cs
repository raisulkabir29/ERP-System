namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNvarchar100ToTofsilInGrade : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Grade", "Tofsil", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Grade", "Tofsil", c => c.String(maxLength: 5));
        }
    }
}
