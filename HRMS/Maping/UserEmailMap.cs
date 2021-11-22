using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserEmailMap : EntityTypeConfiguration<UserEmail> 
    {
        public UserEmailMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.EmailAddress).HasMaxLength(50);
             HasOptional(c => c.User_UserId).WithMany(o => o.UserEmail_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            ToTable("UserEmail");
 

        }
    }
}
