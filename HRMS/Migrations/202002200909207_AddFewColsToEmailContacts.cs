namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFewColsToEmailContacts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmailContacts", "ControllerName", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.EmailContacts", "ActionName", c => c.String(nullable: false, maxLength: 20));
            AddColumn("dbo.EmailContacts", "TableName", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.EmailContacts", "ApplicationId", c => c.Int(nullable: false));
            AddColumn("dbo.EmailContacts", "ApplicantId", c => c.Int(nullable: false));
            AddColumn("dbo.EmailContacts", "ApplicantName", c => c.String(maxLength: 100));
            AddColumn("dbo.EmailContacts", "ApplicantEmail", c => c.String(maxLength: 100));
            AddColumn("dbo.EmailContacts", "ApplicantContactNo", c => c.String(maxLength: 20));
            AddColumn("dbo.EmailContacts", "ForwardedToEmail", c => c.String(maxLength: 100));
            AddColumn("dbo.EmailContacts", "RecommendedByEmail", c => c.String(maxLength: 100));
            AddColumn("dbo.EmailContacts", "ApprovedByEmail", c => c.String(maxLength: 100));
            AddColumn("dbo.EmailContacts", "AddedBy", c => c.Int());
            AddColumn("dbo.EmailContacts", "DateAdded", c => c.DateTime());
            AddColumn("dbo.EmailContacts", "ModifiedBy", c => c.Int());
            AddColumn("dbo.EmailContacts", "ModifiedDate", c => c.DateTime());
            DropColumn("dbo.EmailContacts", "Name");
            DropColumn("dbo.EmailContacts", "Email");
            DropColumn("dbo.EmailContacts", "ContactNo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmailContacts", "ContactNo", c => c.String(maxLength: 20));
            AddColumn("dbo.EmailContacts", "Email", c => c.String(maxLength: 100));
            AddColumn("dbo.EmailContacts", "Name", c => c.String(maxLength: 100));
            DropColumn("dbo.EmailContacts", "ModifiedDate");
            DropColumn("dbo.EmailContacts", "ModifiedBy");
            DropColumn("dbo.EmailContacts", "DateAdded");
            DropColumn("dbo.EmailContacts", "AddedBy");
            DropColumn("dbo.EmailContacts", "ApprovedByEmail");
            DropColumn("dbo.EmailContacts", "RecommendedByEmail");
            DropColumn("dbo.EmailContacts", "ForwardedToEmail");
            DropColumn("dbo.EmailContacts", "ApplicantContactNo");
            DropColumn("dbo.EmailContacts", "ApplicantEmail");
            DropColumn("dbo.EmailContacts", "ApplicantName");
            DropColumn("dbo.EmailContacts", "ApplicantId");
            DropColumn("dbo.EmailContacts", "ApplicationId");
            DropColumn("dbo.EmailContacts", "TableName");
            DropColumn("dbo.EmailContacts", "ActionName");
            DropColumn("dbo.EmailContacts", "ControllerName");
        }
    }
}
