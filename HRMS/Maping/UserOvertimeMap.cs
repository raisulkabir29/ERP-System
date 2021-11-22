using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserOvertimeMap : EntityTypeConfiguration<UserOvertime>
    {
        public UserOvertimeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserOvertime_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.JobTitle_JobTitleId).WithMany(o => o.UserOvertime_JobTitleIds).HasForeignKey(o => o.JobTitleId).WillCascadeOnDelete(true);
            HasRequired(c => c.Grade_GradeId).WithMany(o => o.UserOvertime_GradeIds).HasForeignKey(o => o.GradeId).WillCascadeOnDelete(true);
            Property(o => o.Month).HasMaxLength(4);
            ToTable("UserOvertime");

        }
    }
}