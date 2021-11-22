using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserPayrollSalary
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

    }
}
