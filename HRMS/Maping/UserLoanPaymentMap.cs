using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserLoanPaymentMap : EntityTypeConfiguration<UserLoanPayment>
    {
        public UserLoanPaymentMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserLoanPayment_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.UserLoanDetails_LoanApplicationId).WithMany(o => o.UserLoanPayment_LoanApplicationIds).HasForeignKey(o => o.LoanApplicationId).WillCascadeOnDelete(false);
            Property(o => o.Description).HasMaxLength(400);
            Property(o => o.PaymentMonth).HasMaxLength(4);
            ToTable("UserLoanPayment");

        }
    }
}