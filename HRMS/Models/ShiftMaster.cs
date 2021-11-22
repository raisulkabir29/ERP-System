using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class ShiftMaster
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("OT/NOT")]
        [StringLength(3)]
        public string OTNOT { get; set; }

        [Required]
        [DisplayName("Code")]
        [StringLength(20)]
        public string Code { get; set; }

        [Required]
        [DisplayName("Name")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Description")]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [DisplayName("StartTime")]
        [StringLength(5)]
        public string StartTime { get; set; }

        [Required]
        [DisplayName("EndTime")]
        [StringLength(5)]
        public string EndTime { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        public virtual ICollection<UserShiftAllocation> UserShiftAllocation_ShiftMasterIds { get; set; }
    }
}