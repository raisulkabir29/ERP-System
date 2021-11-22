using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserLeaveDetails
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [DisplayName("Leave Type")]
        public int? LeaveTypeId { get; set; }
        public virtual LeaveType LeaveType_LeaveTypeId { get; set; }

        [Required]
        [DisplayName("Leave Status")]
        public int? LeaveStatusId { get; set; }
        public virtual ApplicationStatus ApplicationStatus_LeaveStatusId { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }
        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("Total Used Leaves in Month")]
        public Decimal TotUsedLeavesInMonth { get; set; }

        [DisplayName("Total Used Leaves Per Year")]
        public Decimal TotUsedLeavesPerYear { get; set; }

        [DisplayName("Total Remaining Leaves Per Year")]
        public Decimal TotRemainingLeavesPerYear { get; set; }

    }
}