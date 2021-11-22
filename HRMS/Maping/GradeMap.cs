using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class GradeMap : EntityTypeConfiguration<Grade>
    {
        public GradeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Tofsil).HasMaxLength(100);
            Property(o => o.TofsilWGradeNo).HasMaxLength(100);
            Property(o => o.OTNOT).HasMaxLength(3);
            ToTable("Grade");
        }
    }
}