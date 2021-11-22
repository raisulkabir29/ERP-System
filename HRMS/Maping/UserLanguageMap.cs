using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserLanguageMap : EntityTypeConfiguration<UserLanguage> 
    {
        public UserLanguageMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserLanguage_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             HasRequired(c => c.Language_LanguageId).WithMany(o => o.UserLanguage_LanguageIds).HasForeignKey(o => o.LanguageId).WillCascadeOnDelete(false);
             ToTable("UserLanguage");
 

        }
    }
}
