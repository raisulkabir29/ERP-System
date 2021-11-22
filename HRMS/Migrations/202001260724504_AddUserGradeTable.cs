namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserGradeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserGrade",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GradeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Grade", t => t.GradeId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.GradeId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserGrade", "UserId", "dbo.User");
            DropForeignKey("dbo.UserGrade", "GradeId", "dbo.Grade");
            DropIndex("dbo.UserGrade", new[] { "UserId" });
            DropIndex("dbo.UserGrade", new[] { "GradeId" });
            DropTable("dbo.UserGrade");
        }
    }
}
