using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserMap : EntityTypeConfiguration<User> 
    {
        public UserMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.CustomId).HasMaxLength(6);
             Property(o => o.UserName).HasMaxLength(100);
             Property(o => o.Password).HasMaxLength(100);             
             HasOptional(c => c.Gender_GenderId).WithMany(o => o.User_GenderIds).HasForeignKey(o => o.GenderId);             
             Property(o => o.BloodGroup).HasMaxLength(20);
             Property(o => o.Nationality).HasMaxLength(100);
             Property(o => o.FirstName).HasMaxLength(100);
             Property(o => o.LastName).HasMaxLength(100);
             Property(o => o.ProfilePicture).HasMaxLength(100);            
             HasOptional(c => c.Office_OfficeId).WithMany(o => o.User_OfficeIds).HasForeignKey(o => o.OfficeId);             
             Property(o => o.NationalId).HasMaxLength(17);
             ToTable("User");
        }
    }
}
