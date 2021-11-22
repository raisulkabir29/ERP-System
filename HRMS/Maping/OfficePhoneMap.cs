using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class OfficePhoneMap : EntityTypeConfiguration<OfficePhone> 
    {
        public OfficePhoneMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.OfficePhone_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
             Property(o => o.Phone).HasMaxLength(15);
             ToTable("OfficePhone");
 

        }
    }
}
