using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserEmploymentType
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Employment")]
        public int? EmploymentTypeId { get; set; }
        public virtual EmploymentType EmploymentType_EmploymentTypeId { get; set; }

        [Required]
        [DisplayName("Department")]
        public int? DepartmentId { get; set; }
        public virtual Department Department_DepartmentId { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

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