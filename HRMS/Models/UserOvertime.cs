using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserOvertime
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Present Date")]
        public DateTime PresentDate { get; set; }

        [Required]
        [DisplayName("Job Title")]
        public int? JobTitleId { get; set; }
        public virtual JobTitle JobTitle_JobTitleId { get; set; }

        [Required]
        [DisplayName("Grade")]
        public int? GradeId { get; set; }
        public virtual Grade Grade_GradeId { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("Daily Overtime Hours")]
        public int DailyOTHours { get; set; }

        [DisplayName("Overtime Rate")]
        public Decimal OvertimeRate { get; set; }

        [DisplayName("Overtime Amount")]
        public Decimal OvertimeAmount { get; set; }
    }
}