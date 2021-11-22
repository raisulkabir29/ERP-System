using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class LoanType
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [StringLength(50)]
        [DisplayName("Loan Type Name")]
        public string Name { get; set; }

        [StringLength(200)]
        [DisplayName("Description")]
        public string Description { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        public virtual ICollection<UserLoanApplication> UserLoanApplication_LoanTypeIds { get; set; }
        public virtual ICollection<UserLoanDetails> UserLoanDetails_LoanTypeIds { get; set; }
    }
}