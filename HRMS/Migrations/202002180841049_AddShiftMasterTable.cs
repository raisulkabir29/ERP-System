namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShiftMasterTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ShiftMaster",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OTNOT = c.String(nullable: false, maxLength: 3),
                        Code = c.String(nullable: false, maxLength: 20),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 100),
                        StartTime = c.String(nullable: false, maxLength: 5),
                        EndTime = c.String(nullable: false, maxLength: 5),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        ModifiedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ShiftMaster");
        }
    }
}
