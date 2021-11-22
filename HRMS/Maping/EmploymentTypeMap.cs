using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class EmploymentTypeMap : EntityTypeConfiguration<EmploymentType>
    {
        public EmploymentTypeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Name).HasMaxLength(20);
            ToTable("EmploymentType");


        }
    }
}