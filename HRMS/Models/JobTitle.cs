using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class JobTitle
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Parent")]
        public Nullable<int> ParentId { get; set; }
        public virtual JobTitle JobTitle2 { get; set; }
        [DisplayName("Is Active")]
        public Nullable<bool> IsActive { get; set; }
        [DisplayName("Office")]
        public Nullable<int> OfficeId { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
        public virtual ICollection<Interview> Interview_JobTitleIds { get; set; }
        public virtual ICollection<JobTitle> JobTitle_ParentIds { get; set; }
        public virtual ICollection<UserAllocation> UserAllocation_JobTitleIds { get; set; }
        public virtual ICollection<UserOvertime> UserOvertime_JobTitleIds { get; set; }

    }
}
