namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColInTerminationType : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EmployeeTermination", "SectionId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeTermination", "SectionId", c => c.Int(nullable: false));
        }
    }
}
