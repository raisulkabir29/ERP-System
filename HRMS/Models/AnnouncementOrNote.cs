using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class AnnouncementOrNote
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Posted Date")] 
        public DateTime PostedDate { get; set; }
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [DisplayName("Department")] 
        public int? DepartmentId { get; set; }
        public virtual Department Department_DepartmentId { get; set; }
        [Required]
        [StringLength(200)] 
        [DisplayName("Summary")] 
        public string Summary { get; set; }
        [Required]
        [DisplayName("Description")] 
        public string Description { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [Required]
        [DisplayName("Is Note")] 
        public bool IsNote { get; set; }

    }
}
