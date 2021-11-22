using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Department
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Parent")]
        public Nullable<int> ParentId { get; set; }
        public virtual Department Department2 { get; set; }
        [Required]
        [DisplayName("Office")]
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
        public virtual ICollection<Department> Department_ParentIds { get; set; }
        public virtual ICollection<DepartmentUser> DepartmentUser_DepartmentIds { get; set; }
        public virtual ICollection<FileManager> FileManager_DepartmentIds { get; set; }
        public virtual ICollection<AnnouncementOrNote> AnnouncementOrNote_DepartmentIds { get; set; }
        public virtual ICollection<UserEmploymentType> UserEmploymentType_DepartmentIds { get; set; }
        public virtual ICollection<EmployeeTermination> EmployeeTermination_DepartmentIds { get; set; }

    }
}