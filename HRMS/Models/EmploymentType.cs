using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class EmploymentType
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        [DisplayName("Name")]
        public string Name { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        public virtual ICollection<UserEmploymentType> UserEmploymentType_EmploymentTypeIds { get; set; }
    }
}