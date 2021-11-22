using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserShiftAllocation
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [DisplayName("Shift Name")]
        public int? ShiftId { get; set; }
        public virtual ShiftMaster ShiftMaster_ShiftMasterId { get; set; }

        [Required]
        [DisplayName("Shift From")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ShiftFrom { get; set; }

        [Required]
        [DisplayName("Shift To")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ShiftTo { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}