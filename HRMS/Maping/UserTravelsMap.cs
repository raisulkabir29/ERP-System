using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserTravelsMap : EntityTypeConfiguration<UserTravels> 
    {
        public UserTravelsMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserTravels_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.PurposeOfVisit).HasMaxLength(100);
             Property(o => o.PlaceOfVisit).HasMaxLength(100);
             Property(o => o.TravelBy).HasMaxLength(100);
             Property(o => o.Description).HasMaxLength(200);
             ToTable("UserTravels");
 

        }
    }
}
