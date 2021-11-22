using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserLoanDetails
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Loan Type")]
        public int? LoanTypeId { get; set; }
        public virtual LoanType LoanType_LoanTypeId { get; set; }

        [DisplayName("Loan Application")]
        public int? LoanApplicationId { get; set; }
        public virtual UserLoanApplication UserLoanApplication_LoanApplicationId { get; set; }

        [DisplayName("Loan Status")]
        public int? LoanStatusId { get; set; }
        public virtual ApplicationStatus ApplicationStatus_LoanStatusId { get; set; }

        [DisplayName("Loan Given Date")]
        public DateTime LoanGivenDate { get; set; }

        [DisplayName("Loan Given")]
        public Decimal LoanGiven { get; set; }

        [DisplayName("Stamp")]
        public int? Stamp { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }
        public virtual ICollection<UserLoanPayment> UserLoanPayment_LoanApplicationIds { get; set; }
    }
}