using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
	public class SIContext : DbContext
	{
		public SIContext()
			: base("name=SIConnectionString")
		{
		}

		 
		public virtual DbSet<Interview> Interviews { get; set; }
		public virtual DbSet<Setting> Settings { get; set; }
		public virtual DbSet<JobTitle> JobTitles { get; set; }
		public virtual DbSet<FileManager> FileManagers { get; set; }
		public virtual DbSet<Ticket> Tickets { get; set; }
		public virtual DbSet<Expense> Expenses { get; set; }
		public virtual DbSet<Policy> Policys { get; set; }
		public virtual DbSet<AnnouncementOrNote> AnnouncementOrNotes { get; set; }
		public virtual DbSet<UserAwards> UserAwardss { get; set; }
		public virtual DbSet<Company> Companys { get; set; }
		public virtual DbSet<Office> Offices { get; set; }
		public virtual DbSet<Language> Languages { get; set; }
		public virtual DbSet<UserAttendence> UserAttendences { get; set; }
		public virtual DbSet<UserTermination> UserTerminations { get; set; }
		public virtual DbSet<UserTravels> UserTravelss { get; set; }
		public virtual DbSet<Gender> Genders { get; set; }
		public virtual DbSet<UserSkill> UserSkills { get; set; }
		public virtual DbSet<User> Users { get; set; }
		public virtual DbSet<Menu> Menus { get; set; }
		public virtual DbSet<University> Universitys { get; set; }
		public virtual DbSet<UserWorkExperience> UserWorkExperiences { get; set; }
		public virtual DbSet<OfficePhone> OfficePhones { get; set; }
		public virtual DbSet<Department> Departments { get; set; }
		public virtual DbSet<DepartmentUser> DepartmentUsers { get; set; }
		public virtual DbSet<Holiday> Holidays { get; set; }
		public virtual DbSet<LeaveType> LeaveTypes { get; set; }
		public virtual DbSet<Qualification> Qualifications { get; set; }
		public virtual DbSet<UserPromotion> UserPromotions { get; set; }
		public virtual DbSet<OfficeType> OfficeTypes { get; set; }
		public virtual DbSet<UserPhone> UserPhones { get; set; }
		public virtual DbSet<UserEmail> UserEmails { get; set; }
		public virtual DbSet<UserAddress> UserAddresss { get; set; }
		public virtual DbSet<Role> Roles { get; set; }
		public virtual DbSet<UserSalaryTransaction> UserSalaryTransactions { get; set; }
		public virtual DbSet<UserPayrollSalary> UserPayrollSalarys { get; set; }
		public virtual DbSet<MenuPermission> MenuPermissions { get; set; }
		public virtual DbSet<UserLeaveApplication> UserLeaveApplications { get; set; }
		public virtual DbSet<UserAllocation> UserAllocations { get; set; }
		public virtual DbSet<UserEducation> UserEducations { get; set; }
		public virtual DbSet<UserLanguage> UserLanguages { get; set; }
		public virtual DbSet<RoleUser> RoleUsers { get; set; }
		public virtual DbSet<OfficeAddress> OfficeAddresss { get; set; }
		public virtual DbSet<OfficeEmail> OfficeEmails { get; set; }
		public virtual DbSet<ApplicationStatus> ApplicationStatuss { get; set; }
        public virtual DbSet<UserDetails> UserDetailss { get; set; }
        public virtual DbSet<UserRefNominee> UserRefNominees { get; set; }
        public virtual DbSet<EmploymentType> EmploymentTypes { get; set; }
        public virtual DbSet<UserEmploymentType> UserEmploymentTypes { get; set; }
        public virtual DbSet<Grade> Grades { get; set; }
        public virtual DbSet<UserLeaveDetails> UserLeaveDetailss { get; set; }
        public virtual DbSet<UserPrAbsDetails> UserPrAbsDetailss { get; set; }
        public virtual DbSet<UserGrade> UserGrades { get; set; }
        public virtual DbSet<UserAttendanceStatus> UserAttendanceStatuss { get; set; }
        public virtual DbSet<UserAttendanceDetails> UserAttendanceDetailss { get; set; }
        public virtual DbSet<LoanType> LoanTypes { get; set; }
        public virtual DbSet<EmployeeAllowanceType> EmployeeAllowanceTypes { get; set; }
        public virtual DbSet<UserLoanApplication> UserLoanApplications { get; set; }
        public virtual DbSet<UserLoanDetails> UserLoanDetailss { get; set; }
        public virtual DbSet<UserLoanPayment> UserLoanPayments { get; set; }
        public virtual DbSet<UserOvertime> UserOvertimes { get; set; }
        public virtual DbSet<UserOvertimeDetails> UserOvertimeDetailss { get; set; }
        public virtual DbSet<EmployeeSalaryAllowances> EmployeeSalaryAllowancess { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
        public virtual DbSet<OfficeDetails> OfficeDetailss { get; set; }
        public virtual DbSet<ShiftMaster> ShiftMasters { get; set; }
        public virtual DbSet<UserShiftAllocation> UserShiftAllocations { get; set; }
        public virtual DbSet<UserSalaryIncrement> UserSalaryIncrements { get; set; }
        public virtual DbSet<EmailContact> EmailContacts { get; set; }
        public virtual DbSet<TerminationType> TerminationTypes { get; set; }
        public virtual DbSet<EmployeeTermination> EmployeeTerminations { get; set; }


        //
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			 
			modelBuilder.Configurations.Add(new HRMS.Maping.InterviewMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.SettingMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.JobTitleMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.FileManagerMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.TicketMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.ExpenseMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.PolicyMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.AnnouncementOrNoteMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserAwardsMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.CompanyMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.OfficeMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.LanguageMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserAttendenceMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserTerminationMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserTravelsMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.GenderMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserSkillMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.MenuMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UniversityMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserWorkExperienceMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.OfficePhoneMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.DepartmentMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.DepartmentUserMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.HolidayMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.LeaveTypeMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.QualificationMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserPromotionMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.OfficeTypeMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserPhoneMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserEmailMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserAddressMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.RoleMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserSalaryTransactionMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserPayrollSalaryMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.MenuPermissionMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserLeaveApplicationMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserAllocationMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserEducationMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.UserLanguageMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.RoleUserMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.OfficeAddressMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.OfficeEmailMap());
			modelBuilder.Configurations.Add(new HRMS.Maping.ApplicationStatusMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserRefNomineeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.EmploymentTypeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserEmploymentTypeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.GradeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserLeaveDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserPrAbsDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserGradeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserAttendanceStatusMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserAttendanceDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.LoanTypeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.EmployeeAllowanceTypeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserLoanApplicationMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserLoanDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserLoanPaymentMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserOvertimeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserOvertimeDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.EmployeeSalaryAllowancesMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.OfficeDetailsMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.ShiftMasterMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserShiftAllocationMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.UserSalaryIncrementMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.TerminationTypeMap());
            modelBuilder.Configurations.Add(new HRMS.Maping.EmployeeTerminationMap());

            base.OnModelCreating(modelBuilder);
		}
		//
	}
}
 
