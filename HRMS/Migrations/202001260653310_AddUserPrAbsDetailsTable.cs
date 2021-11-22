namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserPrAbsDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserPrAbsDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        CalenderDay = c.Int(),
                        TotalHoliDays = c.Int(),
                        TotalWorkingDays = c.Int(),
                        ADBJ = c.Int(),
                        ADBJAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ADAJ = c.Int(),
                        ADAJAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        LWP = c.Int(),
                        LWPAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAbsentDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalCasualLeaves = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalSickLeaves = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalEarnedLeaves = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPresentDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPayableDays = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserPrAbsDetails", "UserId", "dbo.User");
            DropIndex("dbo.UserPrAbsDetails", new[] { "UserId" });
            DropTable("dbo.UserPrAbsDetails");
        }
    }
}
