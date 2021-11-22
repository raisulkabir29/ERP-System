using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserPhoneMap : EntityTypeConfiguration<UserPhone> 
    {
        public UserPhoneMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.PhoneNumber).HasMaxLength(15);
             HasOptional(c => c.User_UserId).WithMany(o => o.UserPhone_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            ToTable("UserPhone");
 

        }
    }
}
