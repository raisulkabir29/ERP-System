using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserAddressMap : EntityTypeConfiguration<UserAddress> 
    {
        public UserAddressMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Line1).HasMaxLength(150);
             Property(o => o.Line2).HasMaxLength(150);
             Property(o => o.City).HasMaxLength(50);
             Property(o => o.PinCode).HasMaxLength(50);
             Property(o => o.NearBy).HasMaxLength(100);
             HasOptional(c => c.User_UserId).WithMany(o => o.UserAddress_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            ToTable("UserAddress");
 

        }
    }
}
