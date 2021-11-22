using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserLeaveDetailsMap : EntityTypeConfiguration<UserLeaveDetails>
    {
        public UserLeaveDetailsMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserLeaveDetails_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.LeaveType_LeaveTypeId).WithMany(o => o.UserLeaveDetails_LeaveTypeIds).HasForeignKey(o => o.LeaveTypeId).WillCascadeOnDelete(true);
            HasRequired(c => c.ApplicationStatus_LeaveStatusId).WithMany(o => o.UserLeaveDetails_LeaveStatusIds).HasForeignKey(o => o.LeaveStatusId).WillCascadeOnDelete(true);
            ToTable("UserLeaveDetails");
        }
    }
}