namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserRefNomineeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserRefNominee",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CurrentGuardianName = c.String(maxLength: 50),
                        Recommender = c.String(maxLength: 50),
                        EmergContactName = c.String(maxLength: 50),
                        EmergContactRel = c.String(maxLength: 50),
                        EmergContactAddrVillage = c.String(maxLength: 50),
                        EmergContactAddrPO = c.String(maxLength: 50),
                        EmergContactAddrThana = c.String(maxLength: 50),
                        EmergContactAddrDistrict = c.String(maxLength: 50),
                        EmergContactPhNo = c.String(maxLength: 20),
                        EmergContactMbNo = c.String(maxLength: 20),
                        Reference1Name = c.String(maxLength: 50),
                        Reference1Company = c.String(maxLength: 50),
                        Reference1Designation = c.String(maxLength: 20),
                        Reference1ContactNo = c.String(maxLength: 20),
                        Reference1AddrVillage = c.String(maxLength: 50),
                        Reference1AddrPO = c.String(maxLength: 50),
                        Reference1AddrThana = c.String(maxLength: 50),
                        Reference1AddrDistrict = c.String(maxLength: 50),
                        Reference2Name = c.String(maxLength: 50),
                        Reference2Company = c.String(maxLength: 50),
                        Reference2Designation = c.String(maxLength: 20),
                        Reference2ContactNo = c.String(maxLength: 20),
                        Reference2AddrVillage = c.String(maxLength: 50),
                        Reference2AddrPO = c.String(maxLength: 50),
                        Reference2AddrThana = c.String(maxLength: 50),
                        Reference2AddrDistrict = c.String(maxLength: 50),
                        NomineeName = c.String(maxLength: 50),
                        NomineeFatherName = c.String(maxLength: 50),
                        NomineeMotherName = c.String(maxLength: 50),
                        NomineeProfession = c.String(maxLength: 20),
                        NomineeContactPhNo = c.String(maxLength: 20),
                        NomineeRel = c.String(maxLength: 20),
                        NomineeAddrVillage = c.String(maxLength: 50),
                        NomineeAddrPO = c.String(maxLength: 50),
                        NomineeAddrUnion = c.String(maxLength: 50),
                        NomineeAddrUpazilla = c.String(maxLength: 50),
                        NomineeAddrDistrict = c.String(maxLength: 50),
                        BirthCertificate = c.Boolean(nullable: false),
                        PoliceVerification = c.Boolean(nullable: false),
                        AddedBy = c.Int(),
                        DateAdded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRefNominee", "UserId", "dbo.User");
            DropIndex("dbo.UserRefNominee", new[] { "UserId" });
            DropTable("dbo.UserRefNominee");
        }
    }
}
