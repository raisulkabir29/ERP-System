namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserShiftAllocationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserShiftAllocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ShiftId = c.Int(nullable: false),
                        ShiftFrom = c.DateTime(nullable: false),
                        ShiftTo = c.DateTime(nullable: false),
                        Year = c.Int(),
                        Month = c.String(maxLength: 4),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShiftMaster", t => t.ShiftId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ShiftId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserShiftAllocation", "UserId", "dbo.User");
            DropForeignKey("dbo.UserShiftAllocation", "ShiftId", "dbo.ShiftMaster");
            DropIndex("dbo.UserShiftAllocation", new[] { "ShiftId" });
            DropIndex("dbo.UserShiftAllocation", new[] { "UserId" });
            DropTable("dbo.UserShiftAllocation");
        }
    }
}
