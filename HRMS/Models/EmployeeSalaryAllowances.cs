using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class EmployeeSalaryAllowances
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [StringLength(3)]
        [DisplayName("OT/NOT")]
        public string OTNOT { get; set; }

        [DisplayName("Gross")]
        public Nullable<Decimal> Gross { get; set; }

        [DisplayName("House Rent Allowance OT")]
        public Nullable<Decimal> HRAllowanceOT { get; set; }

        [DisplayName("House Rent Allowance NOT")]
        public Nullable<Decimal> HRAllowanceNOT { get; set; }

        [DisplayName("Medical Allowance OT")]
        public Nullable<Decimal> MedAllowanceOT { get; set; }

        [DisplayName("Medical Allowance NOT")]
        public Nullable<Decimal> MedAllowanceNOT { get; set; }

        [DisplayName("Conveyance Allowance OT")]
        public Nullable<Decimal> ConAllowanceOT { get; set; }

        [DisplayName("Conveyance Allowance NOT")]
        public Nullable<Decimal> ConAllowanceNOT { get; set; }

        [DisplayName("Food Allowance OT")]
        public Nullable<Decimal> FoodAllowanceOT { get; set; }

        [DisplayName("Food Allowance NOT")]
        public Nullable<Decimal> FoodAllowanceNOT { get; set; }

        [DisplayName("Performance Allowance OT")]
        public Nullable<Decimal> PerAllowanceOT { get; set; }

        [DisplayName("Performance Allowance NOT")]
        public Nullable<Decimal> PerAllowanceNOT { get; set; }

        [DisplayName("Attendance Bonus OT")]
        public Nullable<Decimal> AttendBonOT { get; set; }

        [DisplayName("Attendance Bonus NOT")]
        public Nullable<Decimal> AttendBonNOT { get; set; }

        [DisplayName("Basic OT")]
        public Nullable<Decimal> BasicOT { get; set; }

        [DisplayName("Basic NOT")]
        public Nullable<Decimal> BasicNOT { get; set; }

        [DisplayName("Basic")]
        public Nullable<Decimal> Basic { get; set; }

        [DisplayName("House Rent Allowance")]
        public Nullable<Decimal> HouseRentAllowance { get; set; }

        [DisplayName("Medical Allowance")]
        public Nullable<Decimal> MedicalAllowance { get; set; }

        [DisplayName("Conveyance Allowance")]
        public Nullable<Decimal> ConveyanceAllowance { get; set; }

        [DisplayName("Food Allowance")]
        public Nullable<Decimal> FoodAllowance { get; set; }

        [DisplayName("Performance Allowance")]
        public Nullable<Decimal> PerformanceAllowance { get; set; }

        [DisplayName("Attendance Bonus")]
        public Nullable<Decimal> AttendanceBonus { get; set; }

        [DisplayName("Salary Payable Date")]
        public Nullable<DateTime> SalaryPayableDate { get; set; }

        [DisplayName("Remarks")]
        [StringLength(400)]
        public string Remarks { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}