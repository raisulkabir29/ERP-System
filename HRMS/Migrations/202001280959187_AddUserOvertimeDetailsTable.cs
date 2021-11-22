namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserOvertimeDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserOvertimeDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        TotalOvertimeHours = c.Int(),
                        OvertimeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OvertimeAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserOvertimeDetails", "UserId", "dbo.User");
            DropIndex("dbo.UserOvertimeDetails", new[] { "UserId" });
            DropTable("dbo.UserOvertimeDetails");
        }
    }
}
