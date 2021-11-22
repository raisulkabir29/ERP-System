namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTofsilWGradeNoToGrade : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Grade", "TofsilWGradeNo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Grade", "TofsilWGradeNo");
        }
    }
}
