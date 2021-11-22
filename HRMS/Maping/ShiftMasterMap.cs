using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class ShiftMasterMap : EntityTypeConfiguration<ShiftMaster>
    {
        public ShiftMasterMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.OTNOT).HasMaxLength(3);
            Property(o => o.Code).HasMaxLength(20);
            Property(o => o.Name).HasMaxLength(50);
            Property(o => o.Description).HasMaxLength(100);
            Property(o => o.StartTime).HasMaxLength(5);
            Property(o => o.EndTime).HasMaxLength(5);
            ToTable("ShiftMaster");
        }
    }
}