using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserAwardsMap : EntityTypeConfiguration<UserAwards> 
    {
        public UserAwardsMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserAwards_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.AwardType).HasMaxLength(100);
             Property(o => o.AwardName).HasMaxLength(100);
             Property(o => o.Photo).HasMaxLength(100);
             Property(o => o.Description).HasMaxLength(200);
             ToTable("UserAwards");
 

        }
    }
}
