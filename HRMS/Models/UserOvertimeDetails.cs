using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserOvertimeDetails
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

        [DisplayName("Total Overtime Hours")]
        public int? TotalOvertimeHours { get; set; }

        [DisplayName("Overtime Rate")]
        public Decimal OvertimeRate { get; set; }

        [DisplayName("Overtime Amount")]
        public Decimal OvertimeAmount { get; set; }
    }
}