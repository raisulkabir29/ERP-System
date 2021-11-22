using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class OfficeEmailMap : EntityTypeConfiguration<OfficeEmail> 
    {
        public OfficeEmailMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.OfficeEmail_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             HasRequired(c => c.UserEmail_EmailId).WithMany(o => o.OfficeEmail_EmailIds).HasForeignKey(o => o.EmailId).WillCascadeOnDelete(false);
             ToTable("OfficeEmail");
 

        }
    }
}
