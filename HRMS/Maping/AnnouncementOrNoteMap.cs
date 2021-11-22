using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class AnnouncementOrNoteMap : EntityTypeConfiguration<AnnouncementOrNote> 
    {
        public AnnouncementOrNoteMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.Title).HasMaxLength(100);
             HasOptional(c => c.Office_OfficeId).WithMany(o => o.AnnouncementOrNote_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
            HasOptional(c => c.Department_DepartmentId).WithMany(o => o.AnnouncementOrNote_DepartmentIds).HasForeignKey(o => o.DepartmentId).WillCascadeOnDelete(true);
            Property(o => o.Summary).HasMaxLength(200);
             Property(o => o.Description).HasMaxLength(2000);
             ToTable("AnnouncementOrNote");
 

        }
    }
}
