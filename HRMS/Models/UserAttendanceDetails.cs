using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserAttendanceDetails
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [DisplayName("User Attndance Status")]
        public int? UserAttndStatusId { get; set; }
        public virtual UserAttendanceStatus UserAttendanceStatus_UserAttndStatusId { get; set; }

        [DisplayName("Present Date")]
        public DateTime PresentDate { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("Calendar Day")]
        [StringLength(2)]
        public string CalendarDay { get; set; }

        [DisplayName("Total Holi Days")]
        [StringLength(2)]
        public string TotalHoliDays { get; set; }

        [DisplayName("Total Working Days")]
        [StringLength(2)]
        public string TotalWorkingDays { get; set; }

        [DisplayName("Overtime Hour")]
        public Decimal OvertimeHour { get; set; }

        [DisplayName("Prepared By")]
        public int? PreparedBy { get; set; }
        //public virtual User User_PreparedBy { get; set; }

        [DisplayName("Checked By")]
        public int? CheckedBy { get; set; }
        //public virtual User User_CheckedBy { get; set; }

        [DisplayName("Authorized By")]
        public int? AuthorizedBy { get; set; }
        //public virtual User User_AuthorizedBy { get; set; }
    }
}