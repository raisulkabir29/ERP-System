using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserPromotion
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Promotion Title")]
        public string PromotionTitle { get; set; }
        [Required]
        [DisplayName("Promotion Date")]
        public DateTime PromotionDate { get; set; }
        [DisplayName("Description")]
        public string Description { get; set; }
        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }
        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

    }
}