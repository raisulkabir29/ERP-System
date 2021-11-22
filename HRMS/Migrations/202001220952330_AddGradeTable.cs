namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGradeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Grade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OTNOT = c.String(maxLength: 3),
                        Tofsil = c.String(maxLength: 5),
                        GradeNo = c.Int(),
                        GrossSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BasicSalary = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OvertimeRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Grade");
        }
    }
}
