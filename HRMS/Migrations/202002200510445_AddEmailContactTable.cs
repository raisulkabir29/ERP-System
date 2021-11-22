namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddEmailContactTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmailContacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                        Email = c.String(maxLength: 100),
                        ContactNo = c.String(maxLength: 20),
                        Description = c.String(maxLength: 1024),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmailContacts");
        }
    }
}
