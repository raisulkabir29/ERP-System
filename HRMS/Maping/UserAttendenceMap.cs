using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserAttendenceMap : EntityTypeConfiguration<UserAttendence> 
    {
        public UserAttendenceMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_CompanyOfficeId).WithMany(o => o.UserAttendence_CompanyOfficeIds).HasForeignKey(o => o.CompanyOfficeId).WillCascadeOnDelete(false);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserAttendence_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.AnyRemarks).HasMaxLength(100);
             ToTable("UserAttendence");
 

        }
    }
}
