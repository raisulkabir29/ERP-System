namespace HRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnnouncementOrNote",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        PostedDate = c.DateTime(nullable: false),
                        OfficeId = c.Int(),
                        DepartmentId = c.Int(),
                        Summary = c.String(nullable: false, maxLength: 200),
                        Description = c.String(nullable: false, maxLength: 2000),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        IsNote = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.DepartmentId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        ParentId = c.Int(),
                        OfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.ParentId)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.ParentId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.FileManager",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        FileName = c.String(maxLength: 100),
                        FileSize = c.Decimal(precision: 18, scale: 2),
                        FileExtension = c.String(maxLength: 10),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Office",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Code = c.String(),
                        CreatedOn = c.DateTime(nullable: false),
                        OfficeTypeId = c.Int(nullable: false),
                        CompanyId = c.Int(nullable: false),
                        MapLatitude = c.String(maxLength: 100),
                        MapLongitude = c.String(maxLength: 100),
                        Details = c.String(maxLength: 500),
                        Fax = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        ZipCode = c.String(maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Company", t => t.CompanyId)
                .ForeignKey("dbo.OfficeType", t => t.OfficeTypeId)
                .Index(t => t.CompanyId)
                .Index(t => t.OfficeTypeId);
            
            CreateTable(
                "dbo.Company",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        About = c.String(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        Website = c.String(maxLength: 100),
                        Phone = c.String(maxLength: 13),
                        Fax = c.String(maxLength: 15),
                        MapLatitude = c.String(maxLength: 100),
                        MapLongitude = c.String(maxLength: 100),
                        TaxNumberOrEIN = c.String(maxLength: 100),
                        Logo = c.String(maxLength: 100),
                        Address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Expense",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        PurchaseDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PurchasedBy = c.String(nullable: false, maxLength: 100),
                        BillAttachment = c.String(maxLength: 100),
                        Remarks = c.String(maxLength: 200),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Holiday",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        HolidayDate = c.DateTime(nullable: false),
                        Detail = c.String(maxLength: 100),
                        OfficeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.OfficeAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .ForeignKey("dbo.UserAddress", t => t.AddressId)
                .Index(t => t.OfficeId)
                .Index(t => t.AddressId);
            
            CreateTable(
                "dbo.UserAddress",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Line1 = c.String(nullable: false, maxLength: 150),
                        Line2 = c.String(maxLength: 150),
                        City = c.String(maxLength: 50),
                        PinCode = c.String(maxLength: 50),
                        NearBy = c.String(maxLength: 100),
                        IsEmergency = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 100),
                        Password = c.String(nullable: false, maxLength: 100),
                        GenderId = c.Int(),
                        DateOfBirth = c.DateTime(),
                        BloodGroup = c.String(maxLength: 20),
                        Nationality = c.String(maxLength: 100),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(maxLength: 100),
                        CanLogin = c.Boolean(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                        ProfilePicture = c.String(maxLength: 100),
                        OfficeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gender", t => t.GenderId)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.GenderId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Gender",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MenuPermission",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuId = c.Int(),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(),
                        SortOrder = c.Int(),
                        IsCreate = c.Boolean(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                        IsUpdate = c.Boolean(nullable: false),
                        IsDelete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.MenuId)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.MenuId)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MenuText = c.String(nullable: false, maxLength: 100),
                        MenuURL = c.String(nullable: false, maxLength: 400),
                        ParentId = c.Int(),
                        SortOrder = c.Int(),
                        MenuIcon = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Menu", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleUser",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAllocation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        JobTitleId = c.Int(nullable: false),
                        OfficeId = c.Int(nullable: false),
                        AllocationFrom = c.DateTime(nullable: false),
                        AllocationTo = c.DateTime(),
                        SuperiorUserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobTitle", t => t.JobTitleId)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .ForeignKey("dbo.User", t => t.SuperiorUserId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.JobTitleId)
                .Index(t => t.OfficeId)
                .Index(t => t.SuperiorUserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.JobTitle",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        ParentId = c.Int(),
                        IsActive = c.Boolean(),
                        OfficeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobTitle", t => t.ParentId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Interview",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CandidateName = c.String(nullable: false, maxLength: 100),
                        Email = c.String(nullable: false, maxLength: 50),
                        Mobile = c.String(nullable: false, maxLength: 15),
                        Address = c.String(maxLength: 200),
                        JobTitleId = c.Int(nullable: false),
                        InterviewDate = c.DateTime(nullable: false),
                        PlaceOfInterview = c.String(nullable: false, maxLength: 100),
                        InterviewTime = c.DateTime(nullable: false),
                        InterviewBy = c.Int(nullable: false),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        ModifiedDate = c.DateTime(),
                        InterviewRemarks = c.String(nullable: false, maxLength: 1000),
                        IsDone = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.JobTitle", t => t.JobTitleId)
                .Index(t => t.JobTitleId);
            
            CreateTable(
                "dbo.UserAttendence",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyOfficeId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        PunchIn = c.DateTime(nullable: false),
                        PunchOut = c.DateTime(nullable: false),
                        DateOfAttendence = c.DateTime(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                        AnyRemarks = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.CompanyOfficeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.CompanyOfficeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserAwards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        AwardType = c.String(nullable: false, maxLength: 100),
                        OnDate = c.DateTime(nullable: false),
                        AwardName = c.String(nullable: false, maxLength: 100),
                        Photo = c.String(maxLength: 100),
                        Description = c.String(maxLength: 200),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserEducation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        InstitutionId = c.Int(nullable: false),
                        Digree = c.Int(),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        UserId = c.Int(nullable: false),
                        TotalMarks = c.Double(),
                        OutOfMarks = c.Double(),
                        Percentage = c.Double(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Qualification", t => t.Digree)
                .ForeignKey("dbo.University", t => t.InstitutionId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.Digree)
                .Index(t => t.InstitutionId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Qualification",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.University",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEmail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        IsActive = c.Boolean(nullable: false),
                        IsEmergency = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OfficeEmail",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        EmailId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .ForeignKey("dbo.UserEmail", t => t.EmailId)
                .Index(t => t.OfficeId)
                .Index(t => t.EmailId);
            
            CreateTable(
                "dbo.UserLanguage",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LanguageId = c.Int(nullable: false),
                        RateYourSelf = c.Int(),
                        AddedBy = c.Int(),
                        DateAdded = c.DateTime(),
                        ModifiedBy = c.Int(),
                        DateModied = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Language", t => t.LanguageId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.LanguageId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Language",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Code = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLeaveApplication",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        LeaveTypeId = c.Int(nullable: false),
                        LeaveActiveFrom = c.DateTime(nullable: false),
                        LeaveActiveTo = c.DateTime(nullable: false),
                        IsApproved = c.Boolean(),
                        ApprovedBy = c.Int(),
                        DateAdded = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LeaveType", t => t.LeaveTypeId)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.LeaveTypeId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.LeaveType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserPayrollSalary",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        HouseRentAllowance = c.Decimal(precision: 18, scale: 2),
                        MedicalAllowance = c.Decimal(precision: 18, scale: 2),
                        TravellingAllowance = c.Decimal(precision: 18, scale: 2),
                        DearnessAllowance = c.Decimal(precision: 18, scale: 2),
                        Basic = c.Decimal(precision: 18, scale: 2),
                        SpecialAllowance = c.Decimal(precision: 18, scale: 2),
                        Bonus = c.Decimal(precision: 18, scale: 2),
                        ProvidentFund = c.Decimal(precision: 18, scale: 2),
                        ProfessionalTax = c.Decimal(precision: 18, scale: 2),
                        LunchRecovery = c.Decimal(precision: 18, scale: 2),
                        TransportRecovery = c.Decimal(precision: 18, scale: 2),
                        IncomeTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPhone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneNumber = c.String(nullable: false, maxLength: 15),
                        IsActive = c.Boolean(nullable: false),
                        IsEmergency = c.Boolean(nullable: false),
                        UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserPromotion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PromotionTitle = c.String(nullable: false, maxLength: 100),
                        PromotionDate = c.DateTime(nullable: false),
                        Description = c.String(maxLength: 200),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserSalaryTransaction",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        HouseRentAllowance = c.Decimal(precision: 18, scale: 2),
                        MedicalAllowance = c.Decimal(precision: 18, scale: 2),
                        TravellingAllowance = c.Decimal(precision: 18, scale: 2),
                        DearnessAllowance = c.Decimal(precision: 18, scale: 2),
                        Basic = c.Decimal(precision: 18, scale: 2),
                        SpecialAllowance = c.Decimal(precision: 18, scale: 2),
                        Bonus = c.Decimal(precision: 18, scale: 2),
                        ProvidentFund = c.Decimal(precision: 18, scale: 2),
                        ProfessionalTax = c.Decimal(precision: 18, scale: 2),
                        LunchRecovery = c.Decimal(precision: 18, scale: 2),
                        TransportRecovery = c.Decimal(precision: 18, scale: 2),
                        IncomeTax = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalDeduction = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NetAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OnDate = c.DateTime(nullable: false),
                        Remarks = c.String(nullable: false, maxLength: 200),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserSkill",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        SkillName = c.String(nullable: false, maxLength: 100),
                        RateYourSelf = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTermination",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NoticeDate = c.DateTime(nullable: false),
                        TerminationDate = c.DateTime(nullable: false),
                        TerminationReason = c.String(nullable: false, maxLength: 10),
                        Description = c.String(maxLength: 300),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        IsResignation = c.Boolean(),
                        ResignationApproveDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserTravels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        PurposeOfVisit = c.String(nullable: false, maxLength: 100),
                        PlaceOfVisit = c.String(nullable: false, maxLength: 100),
                        TravelBy = c.String(nullable: false, maxLength: 100),
                        ExpectedTravelBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ActualTravelBudget = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        Description = c.String(maxLength: 200),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserWorkExperience",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CompanyName = c.String(nullable: false, maxLength: 100),
                        Position = c.String(nullable: false),
                        FromDate = c.DateTime(),
                        ToDate = c.DateTime(),
                        IsCurrent = c.Boolean(nullable: false),
                        DescribeJob = c.String(maxLength: 2000),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OfficePhone",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        Phone = c.String(nullable: false, maxLength: 15),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.OfficeType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Level = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Policy",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        Title = c.String(nullable: false, maxLength: 100),
                        Attachment = c.String(maxLength: 100),
                        Description = c.String(nullable: false),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId)
                .Index(t => t.OfficeId);
            
            CreateTable(
                "dbo.Ticket",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        OfficeId = c.Int(nullable: false),
                        Subject = c.String(nullable: false, maxLength: 100),
                        Description = c.String(nullable: false, maxLength: 200),
                        ParentId = c.Int(),
                        DateAdded = c.DateTime(),
                        AddedBy = c.Int(),
                        IsClose = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Office", t => t.OfficeId, cascadeDelete: true)
                .ForeignKey("dbo.Ticket", t => t.ParentId)
                .Index(t => t.OfficeId)
                .Index(t => t.ParentId);
            
            CreateTable(
                "dbo.Setting",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        sKey = c.String(nullable: false, maxLength: 100),
                        sValue = c.String(nullable: false, maxLength: 2000),
                        sGroup = c.String(maxLength: 100),
                        OfficeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AnnouncementOrNote", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.AnnouncementOrNote", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.FileManager", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.Ticket", "ParentId", "dbo.Ticket");
            DropForeignKey("dbo.Ticket", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.Policy", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.Office", "OfficeTypeId", "dbo.OfficeType");
            DropForeignKey("dbo.OfficePhone", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.OfficeAddress", "AddressId", "dbo.UserAddress");
            DropForeignKey("dbo.UserAddress", "UserId", "dbo.User");
            DropForeignKey("dbo.UserWorkExperience", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTravels", "UserId", "dbo.User");
            DropForeignKey("dbo.UserTermination", "UserId", "dbo.User");
            DropForeignKey("dbo.UserSkill", "UserId", "dbo.User");
            DropForeignKey("dbo.UserSalaryTransaction", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPromotion", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPhone", "UserId", "dbo.User");
            DropForeignKey("dbo.UserPayrollSalary", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLeaveApplication", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLeaveApplication", "LeaveTypeId", "dbo.LeaveType");
            DropForeignKey("dbo.UserLanguage", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLanguage", "LanguageId", "dbo.Language");
            DropForeignKey("dbo.UserEmail", "UserId", "dbo.User");
            DropForeignKey("dbo.OfficeEmail", "EmailId", "dbo.UserEmail");
            DropForeignKey("dbo.OfficeEmail", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.UserEducation", "UserId", "dbo.User");
            DropForeignKey("dbo.UserEducation", "InstitutionId", "dbo.University");
            DropForeignKey("dbo.UserEducation", "Digree", "dbo.Qualification");
            DropForeignKey("dbo.UserAwards", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAttendence", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAttendence", "CompanyOfficeId", "dbo.Office");
            DropForeignKey("dbo.UserAllocation", "UserId", "dbo.User");
            DropForeignKey("dbo.UserAllocation", "SuperiorUserId", "dbo.User");
            DropForeignKey("dbo.UserAllocation", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.UserAllocation", "JobTitleId", "dbo.JobTitle");
            DropForeignKey("dbo.JobTitle", "ParentId", "dbo.JobTitle");
            DropForeignKey("dbo.Interview", "JobTitleId", "dbo.JobTitle");
            DropForeignKey("dbo.User", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.MenuPermission", "UserId", "dbo.User");
            DropForeignKey("dbo.MenuPermission", "RoleId", "dbo.Role");
            DropForeignKey("dbo.RoleUser", "UserId", "dbo.User");
            DropForeignKey("dbo.RoleUser", "RoleId", "dbo.Role");
            DropForeignKey("dbo.MenuPermission", "MenuId", "dbo.Menu");
            DropForeignKey("dbo.Menu", "ParentId", "dbo.Menu");
            DropForeignKey("dbo.User", "GenderId", "dbo.Gender");
            DropForeignKey("dbo.OfficeAddress", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.Holiday", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.Expense", "OfficeId", "dbo.Office");
            DropForeignKey("dbo.Office", "CompanyId", "dbo.Company");
            DropForeignKey("dbo.FileManager", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.Department", "ParentId", "dbo.Department");
            DropIndex("dbo.AnnouncementOrNote", new[] { "OfficeId" });
            DropIndex("dbo.AnnouncementOrNote", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "OfficeId" });
            DropIndex("dbo.FileManager", new[] { "OfficeId" });
            DropIndex("dbo.Ticket", new[] { "ParentId" });
            DropIndex("dbo.Ticket", new[] { "OfficeId" });
            DropIndex("dbo.Policy", new[] { "OfficeId" });
            DropIndex("dbo.Office", new[] { "OfficeTypeId" });
            DropIndex("dbo.OfficePhone", new[] { "OfficeId" });
            DropIndex("dbo.OfficeAddress", new[] { "AddressId" });
            DropIndex("dbo.UserAddress", new[] { "UserId" });
            DropIndex("dbo.UserWorkExperience", new[] { "UserId" });
            DropIndex("dbo.UserTravels", new[] { "UserId" });
            DropIndex("dbo.UserTermination", new[] { "UserId" });
            DropIndex("dbo.UserSkill", new[] { "UserId" });
            DropIndex("dbo.UserSalaryTransaction", new[] { "UserId" });
            DropIndex("dbo.UserPromotion", new[] { "UserId" });
            DropIndex("dbo.UserPhone", new[] { "UserId" });
            DropIndex("dbo.UserPayrollSalary", new[] { "UserId" });
            DropIndex("dbo.UserLeaveApplication", new[] { "UserId" });
            DropIndex("dbo.UserLeaveApplication", new[] { "LeaveTypeId" });
            DropIndex("dbo.UserLanguage", new[] { "UserId" });
            DropIndex("dbo.UserLanguage", new[] { "LanguageId" });
            DropIndex("dbo.UserEmail", new[] { "UserId" });
            DropIndex("dbo.OfficeEmail", new[] { "EmailId" });
            DropIndex("dbo.OfficeEmail", new[] { "OfficeId" });
            DropIndex("dbo.UserEducation", new[] { "UserId" });
            DropIndex("dbo.UserEducation", new[] { "InstitutionId" });
            DropIndex("dbo.UserEducation", new[] { "Digree" });
            DropIndex("dbo.UserAwards", new[] { "UserId" });
            DropIndex("dbo.UserAttendence", new[] { "UserId" });
            DropIndex("dbo.UserAttendence", new[] { "CompanyOfficeId" });
            DropIndex("dbo.UserAllocation", new[] { "UserId" });
            DropIndex("dbo.UserAllocation", new[] { "SuperiorUserId" });
            DropIndex("dbo.UserAllocation", new[] { "OfficeId" });
            DropIndex("dbo.UserAllocation", new[] { "JobTitleId" });
            DropIndex("dbo.JobTitle", new[] { "ParentId" });
            DropIndex("dbo.Interview", new[] { "JobTitleId" });
            DropIndex("dbo.User", new[] { "OfficeId" });
            DropIndex("dbo.MenuPermission", new[] { "UserId" });
            DropIndex("dbo.MenuPermission", new[] { "RoleId" });
            DropIndex("dbo.RoleUser", new[] { "UserId" });
            DropIndex("dbo.RoleUser", new[] { "RoleId" });
            DropIndex("dbo.MenuPermission", new[] { "MenuId" });
            DropIndex("dbo.Menu", new[] { "ParentId" });
            DropIndex("dbo.User", new[] { "GenderId" });
            DropIndex("dbo.OfficeAddress", new[] { "OfficeId" });
            DropIndex("dbo.Holiday", new[] { "OfficeId" });
            DropIndex("dbo.Expense", new[] { "OfficeId" });
            DropIndex("dbo.Office", new[] { "CompanyId" });
            DropIndex("dbo.FileManager", new[] { "DepartmentId" });
            DropIndex("dbo.Department", new[] { "ParentId" });
            DropTable("dbo.Setting");
            DropTable("dbo.Ticket");
            DropTable("dbo.Policy");
            DropTable("dbo.OfficeType");
            DropTable("dbo.OfficePhone");
            DropTable("dbo.UserWorkExperience");
            DropTable("dbo.UserTravels");
            DropTable("dbo.UserTermination");
            DropTable("dbo.UserSkill");
            DropTable("dbo.UserSalaryTransaction");
            DropTable("dbo.UserPromotion");
            DropTable("dbo.UserPhone");
            DropTable("dbo.UserPayrollSalary");
            DropTable("dbo.LeaveType");
            DropTable("dbo.UserLeaveApplication");
            DropTable("dbo.Language");
            DropTable("dbo.UserLanguage");
            DropTable("dbo.OfficeEmail");
            DropTable("dbo.UserEmail");
            DropTable("dbo.University");
            DropTable("dbo.Qualification");
            DropTable("dbo.UserEducation");
            DropTable("dbo.UserAwards");
            DropTable("dbo.UserAttendence");
            DropTable("dbo.Interview");
            DropTable("dbo.JobTitle");
            DropTable("dbo.UserAllocation");
            DropTable("dbo.RoleUser");
            DropTable("dbo.Role");
            DropTable("dbo.Menu");
            DropTable("dbo.MenuPermission");
            DropTable("dbo.Gender");
            DropTable("dbo.User");
            DropTable("dbo.UserAddress");
            DropTable("dbo.OfficeAddress");
            DropTable("dbo.Holiday");
            DropTable("dbo.Expense");
            DropTable("dbo.Company");
            DropTable("dbo.Office");
            DropTable("dbo.FileManager");
            DropTable("dbo.Department");
            DropTable("dbo.AnnouncementOrNote");
        }
    }
}
