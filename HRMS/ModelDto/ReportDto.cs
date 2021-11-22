using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.ModelDto
{
    public class IndexDto
    {
       public int Id { get; set; }
        public string Title { get; set; }
    //    public string Code { get; set; }
    //    public DateTime CreatedOn { get; set; }
    //    public string OfficeType { get; set; }
    //    public string CompanyTitle { get; set; }
    //    public string MapLatitude { get; set; }
    //    public string MapLongitude { get; set; }
        public string Details { get; set; }
    //    public string Fax { get; set; }
    //    public string Country { get; set; }
    //    public string City { get; set; }
    //    public string ZipCode { get; set; }
    //    //Users
    //    public string UserName { get; set; }
    //    public string Password { get; set; }
    //    public string Gender { get; set; }
    //    public Nullable<DateTime> DateOfBirth { get; set; }
    //    public string BloodGroup { get; set; }
    //    public string Nationality { get; set; }
    //    public string FirstName { get; set; }
    //    public string LastName { get; set; }
    //    public bool CanLogin { get; set; }
        public bool IsActive { get; set; }
    //    public string ProfilePicture { get; set; }
    //    public int? OfficeId { get; set; }
    //    public string AddressList { get; set; }
    //    public string SkillList { get; set; }
    //    public string LanguageList { get; set; }
    //    public string PhoneList { get; set; }
    //    public string EmailList { get; set; }
        public string Name { get; set; }
    //    public DateTime HolidayDate { get; set; }
        public string parent { get; set; }
          public string officeTitle { get; set; }
    //    public DateTime postedDate { get; set; }
    //    public string DepartmentName { get; set; }
    //    public string Summary { get; set; }
          public string filename { get; set; }
    //    public DateTime DateAdded { get; set; }
    //    public int AddedBy { get; set; }
    //    public DateTime InterViewdate { get; set; }
    //    public DateTime InterViewTime { get; set; }
    //    public string PlacceofInterview { get; set; }
    //    public string InterviewBy { get; set; }
          public string status { get; set; }
          public DateTime FromDate { get; set; }
          public DateTime ToDate { get; set; }
          public string ApprovedBy { get; set; }
    //    public string ImageName { get; set; }
        public DateTime dateEntity { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime PunchOut { get; set; }
        public UserAllocation usrAllocate { get; set; }
        public UserPromotion[] promote { get; set; }
        public UserAwards[] awd { get; set; }
        public User usr { get; set; }
        public UserSkill[] skill { get; set; }
        public UserPhone[] usrPhone { get; set; }
        public UserAddress[] userAddress { get; set; }
        public UserPhone[] userPhone { get; set; }
        public UserEmail[] userEmail { get; set; }
        public UserEducation[] userEducation { get; set; }
        public UserLanguage[] userLanguage { get; set; }
        public UserTravels[] usertravels { get; set; }
        public UserWorkExperience[] usrExperience { get; set; }
        public UserTermination[] usrTermination { get; set; }
    }
}