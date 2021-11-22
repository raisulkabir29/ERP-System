namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserDetailsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserDeails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CustomId = c.Int(),
                        JoiningDate = c.DateTime(),
                        FatherOrHusbandName = c.String(maxLength: 100),
                        MotherName = c.String(maxLength: 100),
                        PresentAddressVillage = c.String(maxLength: 50),
                        PresentAddressPO = c.String(maxLength: 50),
                        PresentAddressThana = c.String(maxLength: 50),
                        PresentAddressDistrict = c.String(maxLength: 50),
                        PermanentAddressVillage = c.String(maxLength: 50),
                        PermanentAddressPO = c.String(maxLength: 50),
                        PermanentAddressThana = c.String(maxLength: 50),
                        PermanentAddressDistrict = c.String(maxLength: 50),
                        Height = c.String(maxLength: 20),
                        Weight = c.String(maxLength: 20),
                        Birthmark = c.String(maxLength: 50),
                        EyeColor = c.String(maxLength: 8),
                        HairColor = c.String(maxLength: 8),
                        NoOfTeeth = c.String(maxLength: 2),
                        Age = c.Int(),
                        Beard = c.Boolean(),
                        MaritalStatus = c.String(maxLength: 20),
                        ChildNo = c.String(maxLength: 20),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserDeails", "UserId", "dbo.User");
            DropIndex("dbo.UserDeails", new[] { "UserId" });
            DropTable("dbo.UserDeails");
        }
    }
}
