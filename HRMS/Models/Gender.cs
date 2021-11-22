using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Gender
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }

        [Required]
        [DisplayName("Title")]
        [StringLength(20)]
        public string Title { get; set; }

        [DisplayName("Title BN")]
        [StringLength(20)]
        public string TitleBN { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        public virtual ICollection<User> User_GenderIds { get; set; }

    }
}
