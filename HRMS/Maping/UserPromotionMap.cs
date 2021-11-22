using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserPromotionMap : EntityTypeConfiguration<UserPromotion> 
    {
        public UserPromotionMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.PromotionTitle).HasMaxLength(100);
             Property(o => o.Description).HasMaxLength(200);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserPromotion_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             ToTable("UserPromotion");
 

        }
    }
}
