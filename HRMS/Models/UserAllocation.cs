using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserAllocation
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Job Title")]
        public int? JobTitleId { get; set; }
        public virtual JobTitle JobTitle_JobTitleId { get; set; }
        [Required]
        [DisplayName("Office")]
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [Required]
        [DisplayName("Allocation From")]
        public DateTime AllocationFrom { get; set; }
        [DisplayName("Allocation To")]
        public Nullable<DateTime> AllocationTo { get; set; }
        [Required]
        [DisplayName("Superior User")]
        public int? SuperiorUserId { get; set; }
        public virtual User User_SuperiorUserId { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

    }
}
