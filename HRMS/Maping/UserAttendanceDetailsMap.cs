using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using HRMS.Models;

namespace HRMS.Maping
{
    public class UserAttendanceDetailsMap : EntityTypeConfiguration<UserAttendanceDetails>
    {
        public UserAttendanceDetailsMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserAttendanceDetails_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.UserAttendanceStatus_UserAttndStatusId).WithMany(o => o.UserAttendanceDetails_UserAttndStatusIds).HasForeignKey(o => o.UserAttndStatusId).WillCascadeOnDelete(true);
            Property(o => o.Month).HasMaxLength(4);
            Property(o => o.CalendarDay).HasMaxLength(2);
            Property(o => o.TotalHoliDays).HasMaxLength(2);
            Property(o => o.TotalWorkingDays).HasMaxLength(2);
            ToTable("UserAttendanceDetails");
        }
    }
}