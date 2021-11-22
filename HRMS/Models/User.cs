using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class User
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [DisplayName("ID Card No")]
        [StringLength(6)]
        //public int CustomId { get; set; }
        public string CustomId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("User Name")]
        public string UserName { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Password")]
        public string Password { get; set; }        
        [DisplayName("Gender")]
        public int? GenderId { get; set; }
        public virtual Gender Gender_GenderId { get; set; }
        [DisplayName("Date Of Birth")]
        public Nullable<DateTime> DateOfBirth { get; set; }
        [StringLength(20)]
        [DisplayName("Blood Group")]
        public string BloodGroup { get; set; }
        [StringLength(100)]
        [DisplayName("Nationality")]
        public string Nationality { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("First Name")]
        public string FirstName { get; set; }
        [StringLength(100)]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("Can Login")]
        public bool CanLogin { get; set; }
        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [DisplayName("Profile Picture")]
        public string ProfilePicture { get; set; }
        [DisplayName("Office")]
        public int? OfficeId { get; set; }
        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("National ID")]
        [RegularExpression("^[0-9]{1,17}$", ErrorMessage = "National ID must be numeric")]
        public string NationalId { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public Nullable<int> ModifiedBy { get; set; }

        public virtual Office Office_OfficeId { get; set; }
        public virtual ICollection<RoleUser> RoleUser_UserIds { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUser_UserIds { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_UserIds { get; set; }
        public virtual ICollection<UserPayrollSalary> UserPayrollSalary_UserIds { get; set; }
        public virtual ICollection<UserAllocation> UserAllocation_UserIds { get; set; }
        public virtual ICollection<UserTermination> UserTermination_UserIds { get; set; }
        public virtual ICollection<UserAwards> UserAwards_UserIds { get; set; }
        public virtual ICollection<UserTravels> UserTravels_UserIds { get; set; }
        public virtual ICollection<UserSkill> UserSkill_UserIds { get; set; }
        public virtual ICollection<UserAddress> UserAddress_UserIds { get; set; }
        public virtual ICollection<UserPhone> UserPhone_UserIds { get; set; }
        public virtual ICollection<UserEmail> UserEmail_UserIds { get; set; }
        public virtual ICollection<UserEducation> UserEducation_UserIds { get; set; }
        public virtual ICollection<UserAttendence> UserAttendence_UserIds { get; set; }
        public virtual ICollection<UserLeaveApplication> UserLeaveApplication_UserIds { get; set; }
        public virtual ICollection<UserLanguage> UserLanguage_UserIds { get; set; }
        public virtual ICollection<UserWorkExperience> UserWorkExperience_UserIds { get; set; }
        public virtual ICollection<UserAllocation> UserAllocation_SuperiorUserIds { get; set; }
        public virtual ICollection<UserSalaryTransaction> UserSalaryTransaction_UserIds { get; set; }
        public virtual ICollection<UserPromotion> UserPromotion_UserIds { get; set; }
        public virtual ICollection<UserDetails> UserDetails_UserIds { get; set; }
        public virtual ICollection<UserRefNominee> UserRefNominee_UserIds { get; set; }
        public virtual ICollection<UserEmploymentType> UserEmploymentType_UserIds { get; set; }
        public virtual ICollection<UserLeaveDetails> UserLeaveDetails_UserIds { get; set; }
        public virtual ICollection<UserPrAbsDetails> UserPrAbsDetails_UserIds { get; set; }
        public virtual ICollection<UserGrade> UserGrade_UserIds { get; set; }
        public virtual ICollection<UserAttendanceDetails> UserAttendanceDetails_UserIds { get; set; }
        public virtual ICollection<UserLoanApplication> UserLoanApplication_UserIds { get; set; }
        public virtual ICollection<UserLoanDetails> UserLoanDetails_UserIds { get; set; }
        public virtual ICollection<UserLoanPayment> UserLoanPayment_UserIds { get; set; }
        public virtual ICollection<UserOvertime> UserOvertime_UserIds { get; set; }
        public virtual ICollection<UserOvertimeDetails> UserOvertimeDetails_UserIds { get; set; }
        public virtual ICollection<EmployeeSalaryAllowances> EmployeeSalaryAllowances_UserIds { get; set; }
        public virtual ICollection<UserShiftAllocation> UserShiftAllocation_UserIds { get; set; }
        public virtual ICollection<UserSalaryIncrement> UserSalaryIncrement_UserIds { get; set; }
        public virtual ICollection<EmployeeTermination> EmployeeTermination_UserIds { get; set; }
    }
}
