using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserWorkExperienceMap : EntityTypeConfiguration<UserWorkExperience> 
    {
        public UserWorkExperienceMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserWorkExperience_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.CompanyName).HasMaxLength(100);
             Property(o => o.Position);
             Property(o => o.DescribeJob).HasMaxLength(2000);
             Property(o => o.LastSalary);
             Property(o => o.JobDuration);
             Property(o => o.ReasonForLeave).HasMaxLength(400);
             ToTable("UserWorkExperience");
        }
    }
}
