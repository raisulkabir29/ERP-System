using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class RoleUserMap : EntityTypeConfiguration<RoleUser> 
    {
        public RoleUserMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Role_RoleId).WithMany(o => o.RoleUser_RoleIds).HasForeignKey(o => o.RoleId).WillCascadeOnDelete(true);
             HasRequired(c => c.User_UserId).WithMany(o => o.RoleUser_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             ToTable("RoleUser");
 

        }
    }
}
