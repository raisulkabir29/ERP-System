using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class PolicyMap : EntityTypeConfiguration<Policy> 
    {
        public PolicyMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.Policy_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
             Property(o => o.Title).HasMaxLength(100);
             Property(o => o.Attachment).HasMaxLength(100);
             Property(o => o.Description);
             ToTable("Policy");
 

        }
    }
}
