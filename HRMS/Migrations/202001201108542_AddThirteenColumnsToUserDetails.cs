namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddThirteenColumnsToUserDetails : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserDeails", "FamilyMember", c => c.String(maxLength: 10));
            AddColumn("dbo.UserDeails", "EarningMemberInFamily", c => c.String(maxLength: 2));
            AddColumn("dbo.UserDeails", "Religion", c => c.String(maxLength: 10));
            AddColumn("dbo.UserDeails", "TotalExperience", c => c.String(maxLength: 50));
            AddColumn("dbo.UserDeails", "EmailAddress", c => c.String(maxLength: 50));
            AddColumn("dbo.UserDeails", "LandPhoneNo", c => c.String(maxLength: 20));
            AddColumn("dbo.UserDeails", "MbPhoneNo", c => c.String(maxLength: 20));
            AddColumn("dbo.UserDeails", "IsActive", c => c.Boolean());
            AddColumn("dbo.UserDeails", "IsEmergency", c => c.Boolean());
            AddColumn("dbo.UserDeails", "InvolvedInCrime", c => c.Boolean());
            AddColumn("dbo.UserDeails", "NoObjectionCert", c => c.Boolean());
            AddColumn("dbo.UserDeails", "AddedBy", c => c.Int());
            AddColumn("dbo.UserDeails", "DateAdded", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserDeails", "DateAdded");
            DropColumn("dbo.UserDeails", "AddedBy");
            DropColumn("dbo.UserDeails", "NoObjectionCert");
            DropColumn("dbo.UserDeails", "InvolvedInCrime");
            DropColumn("dbo.UserDeails", "IsEmergency");
            DropColumn("dbo.UserDeails", "IsActive");
            DropColumn("dbo.UserDeails", "MbPhoneNo");
            DropColumn("dbo.UserDeails", "LandPhoneNo");
            DropColumn("dbo.UserDeails", "EmailAddress");
            DropColumn("dbo.UserDeails", "TotalExperience");
            DropColumn("dbo.UserDeails", "Religion");
            DropColumn("dbo.UserDeails", "EarningMemberInFamily");
            DropColumn("dbo.UserDeails", "FamilyMember");
        }
    }
}
