using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserWorkExperience
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Company Name")]
        public string CompanyName { get; set; }
        [Required]
        [DisplayName("Position")]
        public string Position { get; set; }
        [DisplayName("From Date")]
        public Nullable<DateTime> FromDate { get; set; }
        [DisplayName("To Date")]
        public Nullable<DateTime> ToDate { get; set; }
        [Required]
        [DisplayName("Is Current")]
        public bool IsCurrent { get; set; }
        [StringLength(2000)]
        [DisplayName("Describe Job")]
        public string DescribeJob { get; set; }
        [DisplayName("Last Salary")]
        public int? LastSalary { get; set; }

        [DisplayName("Job Duration")]
        public int? JobDuration { get; set; }

        [DisplayName("Reason For Leave")]
        public string ReasonForLeave { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}
