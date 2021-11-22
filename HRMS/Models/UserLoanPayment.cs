using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserLoanPayment
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Loan Application ")]
        public int? LoanApplicationId { get; set; }
        public virtual UserLoanDetails UserLoanDetails_LoanApplicationId { get; set; }

        [DisplayName("Payment Date")]
        public Nullable<DateTime> PaymentDate { get; set; }

        [DisplayName("Payment Year")]
        public int? PaymentYear { get; set; }

        [DisplayName("Payment Month")]
        [StringLength(4)]
        public string PaymentMonth { get; set; }

        [DisplayName("Current Installment")]
        public int? CurrentInstallment { get; set; }

        [DisplayName("Current Installment Paid")]
        public Decimal CurrentInstallmentPaid { get; set; }

        [DisplayName("Remaining Installment")]
        public int? RemainingInstallment { get; set; }

        [DisplayName("Payments Due")]
        public Decimal PaymentsDue { get; set; }

        [DisplayName("Description")]
        [StringLength(400)]
        public string Description { get; set; }
    }
}