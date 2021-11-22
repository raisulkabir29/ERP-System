using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class JobTitleMap : EntityTypeConfiguration<JobTitle> 
    {
        public JobTitleMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Name).HasMaxLength(100);
             HasOptional(c => c.JobTitle2).WithMany(o => o.JobTitle_ParentIds).HasForeignKey(o => o.ParentId);
             ToTable("JobTitle");
 

        }
    }
}
