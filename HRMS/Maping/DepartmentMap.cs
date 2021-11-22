using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class DepartmentMap : EntityTypeConfiguration<Department> 
    {
        public DepartmentMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(50);
             HasOptional(c => c.Department2).WithMany(o => o.Department_ParentIds).HasForeignKey(o => o.ParentId);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.Department_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             ToTable("Department");
 

        }
    }
}
