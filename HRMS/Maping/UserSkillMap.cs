using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserSkillMap : EntityTypeConfiguration<UserSkill> 
    {
        public UserSkillMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserSkill_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.SkillName).HasMaxLength(100);
             Property(o => o.MachineName).HasMaxLength(100);
             Property(o => o.Process).HasMaxLength(100);
             Property(o => o.PerHourCapacity).HasMaxLength(20);
             ToTable("UserSkill");
        }
    }
}
