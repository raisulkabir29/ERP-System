using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserAllocationMap : EntityTypeConfiguration<UserAllocation> 
    {
        public UserAllocationMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserAllocation_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             HasRequired(c => c.JobTitle_JobTitleId).WithMany(o => o.UserAllocation_JobTitleIds).HasForeignKey(o => o.JobTitleId).WillCascadeOnDelete(false);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.UserAllocation_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             HasRequired(c => c.User_SuperiorUserId).WithMany(o => o.UserAllocation_SuperiorUserIds).HasForeignKey(o => o.SuperiorUserId).WillCascadeOnDelete(false);
             ToTable("UserAllocation");
 

        }
    }
}
