using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Policy
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [DisplayName("Attachment")] 
        public string Attachment { get; set; }
        [Required]
        [DisplayName("Description")] 
        public string Description { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }

    }
}
