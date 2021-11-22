using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserLoanDetailsMap : EntityTypeConfiguration<UserLoanDetails>
    {
        public UserLoanDetailsMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserLoanDetails_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.LoanType_LoanTypeId).WithMany(o => o.UserLoanDetails_LoanTypeIds).HasForeignKey(o => o.LoanTypeId).WillCascadeOnDelete(true);
            HasRequired(c => c.UserLoanApplication_LoanApplicationId).WithMany(o => o.UserLoanDetails_LoanApplicationIds).HasForeignKey(o => o.LoanApplicationId).WillCascadeOnDelete(false);
            HasRequired(c => c.ApplicationStatus_LoanStatusId).WithMany(o => o.UserLoanDetails_LoanStatusIds).HasForeignKey(o => o.LoanStatusId).WillCascadeOnDelete(true);
            Property(o => o.Month).HasMaxLength(4);
            ToTable("UserLoanDetails");


        }
    }
}