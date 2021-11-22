using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserSkill
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Skill Name")]
        public string SkillName { get; set; }
        [DisplayName("Rate Your Self")]
        public Nullable<int> RateYourSelf { get; set; }
        [DisplayName("Machine Name")]
        public string MachineName { get; set; }

        [DisplayName("Process")]
        public string Process { get; set; }

        [DisplayName("Per Hour Capacity")]
        public string PerHourCapacity { get; set; }

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
