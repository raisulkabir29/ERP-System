using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserSalaryTransaction
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [DisplayName("House Rent Allowance")] 
        public Nullable<Decimal> HouseRentAllowance { get; set; }
        [DisplayName("Medical Allowance")] 
        public Nullable<Decimal> MedicalAllowance { get; set; }
        [DisplayName("Travelling Allowance")] 
        public Nullable<Decimal> TravellingAllowance { get; set; }
        [DisplayName("Dearness Allowance")] 
        public Nullable<Decimal> DearnessAllowance { get; set; }
        [DisplayName("Basic")] 
        public Nullable<Decimal> Basic { get; set; }
        [DisplayName("Special Allowance")] 
        public Nullable<Decimal> SpecialAllowance { get; set; }
        [DisplayName("Bonus")] 
        public Nullable<Decimal> Bonus { get; set; }
        [DisplayName("Provident Fund")] 
        public Nullable<Decimal> ProvidentFund { get; set; }
        [DisplayName("Professional Tax")] 
        public Nullable<Decimal> ProfessionalTax { get; set; }
        [DisplayName("Lunch Recovery")] 
        public Nullable<Decimal> LunchRecovery { get; set; }
        [DisplayName("Transport Recovery")] 
        public Nullable<Decimal> TransportRecovery { get; set; }
        [Required]
        [DisplayName("Income Tax")] 
        public Decimal IncomeTax { get; set; }
        [Required]
        [DisplayName("Total Amount")] 
        public Decimal TotalAmount { get; set; }
        [Required]
        [DisplayName("Total Deduction")] 
        public Decimal TotalDeduction { get; set; }
        [Required]
        [DisplayName("Net Amount")] 
        public Decimal NetAmount { get; set; }
        [Required]
        [DisplayName("On Date")] 
        public DateTime OnDate { get; set; }
        [Required]
        [DisplayName("Remarks")] 
        public string Remarks { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }

        [DisplayName("OT Or NOT")]
        public string OTNOT { get; set; }

        [DisplayName("Conveyance Allowance")]
        public Nullable<Decimal> ConveyanceAllowance { get; set; }

        [DisplayName("Food Allowance")]
        public Nullable<Decimal> FoodAllowance { get; set; }

        [DisplayName("Performance Allowance")]
        public Nullable<Decimal> PerformanceAllowance { get; set; }

        [DisplayName("Attendance Bonus")]
        public Nullable<Decimal> AttendanceBonus { get; set; }

        [DisplayName("Stamp")]
        public int Stamp { get; set; }

        [DisplayName("Gross")]
        public Nullable<Decimal> Gross { get; set; }
        [DisplayName("Year")]
        [RegularExpression("^[0-9]{1,4}$", ErrorMessage = "Year must be in 4 digit")]
        public int Year { get; set; }
        [DisplayName("Month")]
        public string Month { get; set; }
    }
}
