using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserSalaryIncrement
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [DisplayName("OT/NOT")]
        [StringLength(3)]
        public string OTNOT { get; set; }

        [Required]
        [DisplayName("GrossSalary")]
        public Decimal GrossSalary { get; set; }

        [DisplayName("BasicSalary")]
        public Nullable<Decimal> BasicSalary { get; set; }

        [DisplayName("IncrementPercentage")]
        public int? IncrementPercentage { get; set; }

        [DisplayName("Year of Increment")]
        public int? YearOfIncrement { get; set; }

        [DisplayName("Increment On")]
        public int? IncrementOnGrossOrBasic { get; set; }

        [DisplayName("New Gross Salary")]
        public Nullable<Decimal> NewGrossSalary { get; set; }

        [DisplayName("New Basic Salary")]
        public Nullable<Decimal> NewBasicSalary { get; set; }

        [DisplayName("OvertimeRate")]
        public Nullable<Decimal> OvertimeRate { get; set; }

        [Required]
        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}