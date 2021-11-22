using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class OfficeDetailsMap : EntityTypeConfiguration<OfficeDetails>
    {
        public OfficeDetailsMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.Office_OfficeId).WithMany(o => o.OfficeDetails_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
            Property(o => o.EmailAddress).HasMaxLength(50);
            Property(o => o.LandPhoneNo).HasMaxLength(20);
            Property(o => o.MbPhoneNo).HasMaxLength(20);
            Property(o => o.Address).HasMaxLength(200);
            ToTable("OfficeDetails");


        }
    }
}