using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserLeaveApplication
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
        [DisplayName("Leave Active From")] 
        public DateTime LeaveActiveFrom { get; set; }

        [Required]
        [DisplayName("Leave Active To")] 
        public DateTime LeaveActiveTo { get; set; }

        [DisplayName("SL Start Time")]
        public string StartTime { get; set; }

        [DisplayName("SL End Time")]
        public string EndTime { get; set; }

        [DisplayName("Short Leave Hours")]
        public string ShortLeaveHours { get; set; }

        [DisplayName("Approved By")] 
        public Nullable<int> ApprovedBy { get; set; }

        [DisplayName("Forwarded To")]
        public Nullable<int> ForwardedTo { get; set; }

        [DisplayName("Is Approved")]
        public Nullable<bool> IsApproved { get; set; }

        [RegularExpression("^[0-9]{1,4}$", ErrorMessage = "Year must be in 4 digit")]        
        [DisplayName("Year")]
        public int Year { get; set; }

        [DisplayName("Month")]
        public string Month { get; set; }

        [DisplayName("Application Date")]
        public Nullable<DateTime> ApplicationDate { get; set; }

        [DisplayName("No Of Days")]
        public Nullable<Decimal> NoOfDays { get; set; }

        [DisplayName("Leave Purpose")]
        public string LeavePurpose { get; set; }

        public int? ApplicationStatusId { get; set; }
        public virtual ApplicationStatus ApplicationStatus_ApplicationStatusId { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public Nullable<int> ModifiedBy { get; set; }

    }
}
