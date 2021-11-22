using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HRMS.Models
{
    public class UserLoanApplication
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

        [DisplayName("Loan Status")]
        public int? LoanStatusId { get; set; }
        public virtual ApplicationStatus ApplicationStatus_LoanStatusId { get; set; }

        [DisplayName("Application Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ApplicationDate { get; set; }

        [DisplayName("Possible Disburse Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PossibleDisburseDate { get; set; }

        [DisplayName("Max Amount Allowed")]
        public Decimal MaxAmountAllowed { get; set; }

        [DisplayName("Loan Amount Applied")]
        public Decimal LoanAmountApplied { get; set; }

        [DisplayName("No of Installment")]
        public int? NoOfInstallment { get; set; }

        [DisplayName("Installment Amount")]
        public Decimal InstallmentAmount { get; set; }

        [DisplayName("Description")]
        [StringLength(1000)]
        public string Description { get; set; }

        [DisplayName("Forwarded To")]
        public int? ForwardedTo { get; set; }

        [DisplayName("Recommended By")]
        public int? RecommendedBy { get; set; }

        [DisplayName("IsApproved")]
        [StringLength(3)]
        //public bool IsApproved { get; set; }
        public string IsApproved { get; set; }

        [DisplayName("Approved By")]
        public int? ApprovedBy { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        public virtual ICollection<UserLoanDetails> UserLoanDetails_LoanApplicationIds { get; set; }
    }
}