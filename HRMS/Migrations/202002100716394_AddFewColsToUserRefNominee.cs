namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToUserRefNominee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserRefNominee", "ModifiedDate", c => c.DateTime());
            AddColumn("dbo.UserRefNominee", "ModifiedBy", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserRefNominee", "ModifiedBy");
            DropColumn("dbo.UserRefNominee", "ModifiedDate");
        }
    }
}
