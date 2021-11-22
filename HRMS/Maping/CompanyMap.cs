using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class CompanyMap : EntityTypeConfiguration<Company> 
    {
        public CompanyMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(100);
             Property(o => o.About);
             Property(o => o.Website).HasMaxLength(100);
             Property(o => o.Phone).HasMaxLength(13);
             Property(o => o.Fax).HasMaxLength(15);
             Property(o => o.MapLatitude).HasMaxLength(100);
             Property(o => o.MapLongitude).HasMaxLength(100);
             Property(o => o.TaxNumberOrEIN).HasMaxLength(100);
             Property(o => o.Logo).HasMaxLength(100);
             Property(o => o.Address).HasMaxLength(100);
             ToTable("Company");
 

        }
    }
}
