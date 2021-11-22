using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class RoleUser
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [DisplayName("Role")]
        public int? RoleId { get; set; }
        public virtual Role Role_RoleId { get; set; }
        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

    }
}