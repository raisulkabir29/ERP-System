using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Ticket
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Subject")] 
        public string Subject { get; set; }
        [Required]
        [DisplayName("Description")] 
        public string Description { get; set; }
        [DisplayName("Parent")] 
        public Nullable<int> ParentId { get; set; }
        public virtual Ticket Ticket2 { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [Required]
        [DisplayName("Is Close")] 
        public bool IsClose { get; set; }
        public virtual ICollection<Ticket> Ticket_ParentIds { get; set; }

    }
}
