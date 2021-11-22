using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class ApplicationStatusMap : EntityTypeConfiguration<ApplicationStatus>
    {
        public ApplicationStatusMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Name).HasMaxLength(20);
            Property(o => o.Description).HasMaxLength(200);
            ToTable("ApplicationStatus");
        }
    }
}
