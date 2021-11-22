using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserTermination
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Notice Date")]
        public DateTime NoticeDate { get; set; }
        [Required]
        [DisplayName("Termination Date")]
        public DateTime TerminationDate { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Termination Reason")]
        public string TerminationReason { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Is Resignation")]
        public Nullable<bool> IsResignation { get; set; }
        [DisplayName("Resignation Approve Date")]
        public Nullable<DateTime> ResignationApproveDate { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

    }
}
