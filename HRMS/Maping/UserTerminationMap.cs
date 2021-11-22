using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserTerminationMap : EntityTypeConfiguration<UserTermination> 
    {
        public UserTerminationMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserTermination_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.TerminationReason).HasMaxLength(10);
             Property(o => o.Description).HasMaxLength(300);
             ToTable("UserTermination");
 

        }
    }
}
