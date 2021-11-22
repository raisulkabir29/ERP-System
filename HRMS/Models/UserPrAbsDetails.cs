using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserPrAbsDetails
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("CalenderDay")]
        public int? CalenderDay { get; set; }

        [DisplayName("Total HoliDays")]
        public int? TotalHoliDays { get; set; }

        [DisplayName("Total Working Days")]
        public int? TotalWorkingDays { get; set; }

        [DisplayName("Absent Day Before Joining")]
        public int? ADBJ { get; set; }

        [DisplayName("Absent Day Before Joining Amount")]
        public Decimal ADBJAmount { get; set; }

        [DisplayName("Absent Day After Joining")]
        public int? ADAJ { get; set; }

        [DisplayName("Absent Day After Joining Amount")]
        public Decimal ADAJAmount { get; set; }

        [DisplayName("Leave Without Pay")]
        public int? LWP { get; set; }

        [DisplayName("Leave Without Pay Amount")]
        public Decimal LWPAmount { get; set; }

        [DisplayName("Total Absent Days")]
        public Decimal TotalAbsentDays { get; set; }

        [DisplayName("Total Casual Leaves")]
        public Decimal TotalCasualLeaves { get; set; }

        [DisplayName("Total Sick Leaves")]
        public Decimal TotalSickLeaves { get; set; }

        [DisplayName("Total Earned Leaves")]
        public Decimal TotalEarnedLeaves { get; set; }

        [DisplayName("Total Present Days")]
        public Decimal TotalPresentDays { get; set; }

        [DisplayName("Total Payable Days")]
        public Decimal TotalPayableDays { get; set; }
    }
}