using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserLeaveApplicationMap : EntityTypeConfiguration<UserLeaveApplication> 
    {
        public UserLeaveApplicationMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserLeaveApplication_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             HasRequired(c => c.LeaveType_LeaveTypeId).WithMany(o => o.UserLeaveApplication_LeaveTypeIds).HasForeignKey(o => o.LeaveTypeId).WillCascadeOnDelete(false);
             Property(o => o.StartTime).HasMaxLength(5);
             Property(o => o.EndTime).HasMaxLength(5);
             Property(o => o.ShortLeaveHours).HasMaxLength(20);
             Property(o => o.Month).HasMaxLength(4);
             Property(o => o.LeavePurpose).HasMaxLength(100);
             HasRequired(c => c.ApplicationStatus_ApplicationStatusId).WithMany(o => o.UserLeaveAppStatus_ApplicationStatusIds).HasForeignKey(o => o.ApplicationStatusId).WillCascadeOnDelete(false);            
             ToTable("UserLeaveApplication");
 

        }
    }
}
