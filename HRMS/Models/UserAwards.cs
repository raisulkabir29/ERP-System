using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserAwards
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Award Type")] 
        public string AwardType { get; set; }
        [Required]
        [DisplayName("On Date")] 
        public DateTime OnDate { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Award Name")] 
        public string AwardName { get; set; }
        [DisplayName("Photo")] 
        public string Photo { get; set; }
        [DisplayName("Description")] 
        public string Description { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }

    }
}
