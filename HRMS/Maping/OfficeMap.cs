using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class OfficeMap : EntityTypeConfiguration<Office> 
    {
        public OfficeMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             Property(o => o.Code);
             HasRequired(c => c.OfficeType_OfficeTypeId).WithMany(o => o.Office_OfficeTypeIds).HasForeignKey(o => o.OfficeTypeId).WillCascadeOnDelete(true);
             HasRequired(c => c.Company_CompanyId).WithMany(o => o.Office_CompanyIds).HasForeignKey(o => o.CompanyId).WillCascadeOnDelete(false);
             Property(o => o.MapLatitude).HasMaxLength(100);
             Property(o => o.MapLongitude).HasMaxLength(100);
             Property(o => o.Details).HasMaxLength(500);
             Property(o => o.Fax).HasMaxLength(50);
             Property(o => o.Country).HasMaxLength(50);
             Property(o => o.City).HasMaxLength(50);
             Property(o => o.ZipCode).HasMaxLength(15);
             ToTable("Office");
 

        }
    }
}
