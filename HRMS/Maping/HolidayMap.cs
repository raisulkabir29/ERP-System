using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class HolidayMap : EntityTypeConfiguration<Holiday> 
    {
        public HolidayMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(50);
             Property(o => o.Detail).HasMaxLength(100);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.Holiday_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             ToTable("Holiday");
 

        }
    }
}
