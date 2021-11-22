using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class OfficeAddressMap : EntityTypeConfiguration<OfficeAddress> 
    {
        public OfficeAddressMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.OfficeAddress_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
             HasRequired(c => c.UserAddress_AddressId).WithMany(o => o.OfficeAddress_AddressIds).HasForeignKey(o => o.AddressId).WillCascadeOnDelete(true);
             ToTable("OfficeAddress");
 

        }
    }
}
