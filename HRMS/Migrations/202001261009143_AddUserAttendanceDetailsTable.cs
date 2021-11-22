namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAttendanceDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAttendanceDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        UserAttndStatusId = c.Int(nullable: false),
                        PresentDate = c.DateTime(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        CalendarDay = c.String(maxLength: 2),
                        TotalHoliDays = c.String(maxLength: 2),
                        TotalWorkingDays = c.String(maxLength: 2),
                        OvertimeHour = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PreparedBy = c.Int(),
                        CheckedBy = c.Int(),
                        AuthorizedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.UserAttendanceStatus", t => t.UserAttndStatusId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.UserAttndStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAttendanceDetails", "UserAttndStatusId", "dbo.UserAttendanceStatus");
            DropForeignKey("dbo.UserAttendanceDetails", "UserId", "dbo.User");
            DropIndex("dbo.UserAttendanceDetails", new[] { "UserAttndStatusId" });
            DropIndex("dbo.UserAttendanceDetails", new[] { "UserId" });
            DropTable("dbo.UserAttendanceDetails");
        }
    }
}
