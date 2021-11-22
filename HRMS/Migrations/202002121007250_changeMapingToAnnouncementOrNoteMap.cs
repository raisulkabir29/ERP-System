namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeMapingToAnnouncementOrNoteMap : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AnnouncementOrNote", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.AnnouncementOrNote", "OfficeId", "dbo.Office");
            AddForeignKey("dbo.AnnouncementOrNote", "DepartmentId", "dbo.Department", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AnnouncementOrNote", "OfficeId", "dbo.Office", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnnouncementOrNote", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.AnnouncementOrNote", "DepartmentId", "dbo.Department");
            AddForeignKey("dbo.AnnouncementOrNote", "OfficeId", "dbo.Office", "Id");
            AddForeignKey("dbo.AnnouncementOrNote", "DepartmentId", "dbo.Department", "Id");
        }
    }
}
