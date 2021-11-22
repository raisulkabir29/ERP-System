namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddOfficeDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OfficeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        EmailAddress = c.String(maxLength: 50),
                        LandPhoneNo = c.String(maxLength: 20),
                        MbPhoneNo = c.String(maxLength: 20),
                        Address = c.String(maxLength: 200),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.OfficeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OfficeDetails", "OfficeId", "dbo.Office");
            DropIndex("dbo.OfficeDetails", new[] { "OfficeId" });
            DropTable("dbo.OfficeDetails");
        }
    }
}
