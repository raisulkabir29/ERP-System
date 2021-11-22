namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColInUserDetails : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserDeails", "Beard", c => c.String(maxLength: 3));
            AlterColumn("dbo.UserDeails", "IsActive", c => c.String(maxLength: 3));
            AlterColumn("dbo.UserDeails", "IsEmergency", c => c.String(maxLength: 3));
            AlterColumn("dbo.UserDeails", "InvolvedInCrime", c => c.String(maxLength: 3));
            AlterColumn("dbo.UserDeails", "NoObjectionCert", c => c.String(maxLength: 3));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserDeails", "NoObjectionCert", c => c.Boolean());
            AlterColumn("dbo.UserDeails", "InvolvedInCrime", c => c.Boolean());
            AlterColumn("dbo.UserDeails", "IsEmergency", c => c.Boolean());
            AlterColumn("dbo.UserDeails", "IsActive", c => c.Boolean());
            AlterColumn("dbo.UserDeails", "Beard", c => c.Boolean());
        }
    }
}
