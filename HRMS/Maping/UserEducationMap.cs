using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserEducationMap : EntityTypeConfiguration<UserEducation> 
    {
        public UserEducationMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.University_InstitutionId).WithMany(o => o.UserEducation_InstitutionIds).HasForeignKey(o => o.InstitutionId);
             HasOptional(c => c.Qualification_Digree).WithMany(o => o.UserEducation_Digrees).HasForeignKey(o => o.Digree);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserEducation_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.InstitutionName).HasMaxLength(100);
             Property(o => o.LatestDegree).HasMaxLength(50);
             Property(o => o.DivisionOrGrade).HasMaxLength(30);
             ToTable("UserEducation");
 

        }
    }
}
