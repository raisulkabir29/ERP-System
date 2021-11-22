using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Grade
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [DisplayName("OT/NOT")]
        [StringLength(3)]
        public string OTNOT { get; set; }

        [DisplayName("Tofsil")]
        [StringLength(100)]
        public string Tofsil { get; set; }

        [DisplayName("Tofsil BN")]
        [StringLength(100)]
        public string TofsilBN { get; set; }

        [DisplayName("Grade No")]
        public int? GradeNo { get; set; }

        [DisplayName("Grade No BN")]
        [StringLength(2)]
        public string GradeNoBN { get; set; }

        [DisplayName("Tofsil w Grade No")]
        [StringLength(100)]
        public string TofsilWGradeNo { get; set; }

        [DisplayName("Gross Salary")]
        public Decimal GrossSalary { get; set; }

        [DisplayName("Basic Salary")]
        public Decimal BasicSalary { get; set; }

        [DisplayName("Overtime Rate")]
        public Decimal OvertimeRate { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        public virtual ICollection<UserGrade> UserGrade_GradeIds { get; set; }
        public virtual ICollection<UserOvertime> UserOvertime_GradeIds { get; set; }

    }
}