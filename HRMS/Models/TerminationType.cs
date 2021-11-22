using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class TerminationType
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Code")]
        [StringLength(10)]
        public string Code { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(400)]
        public string Description { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
        public virtual ICollection<EmployeeTermination> EmployeeTermination_TerminationTypeIds { get; set; }
    }
}