using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserLoanApplicationMap : EntityTypeConfiguration<UserLoanApplication>
    {
        public UserLoanApplicationMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserLoanApplication_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.LoanType_LoanTypeId).WithMany(o => o.UserLoanApplication_LoanTypeIds).HasForeignKey(o => o.LoanTypeId).WillCascadeOnDelete(true);
            HasRequired(c => c.ApplicationStatus_LoanStatusId).WithMany(o => o.UserLoanApplication_LoanStatusIds).HasForeignKey(o => o.LoanStatusId).WillCascadeOnDelete(true);
            Property(o => o.Description).HasMaxLength(1000);
            Property(o => o.IsApproved).HasMaxLength(3);
            ToTable("UserLoanApplication");


        }
    }
}