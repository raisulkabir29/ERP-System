namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColInEmailContacts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailContacts", "AdminEmail", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmailContacts", "AdminEmail");
        }
    }
}
