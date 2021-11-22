using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class FileManagerMap : EntityTypeConfiguration<FileManager> 
    {
        public FileManagerMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.FileManager_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
             HasRequired(c => c.Department_DepartmentId).WithMany(o => o.FileManager_DepartmentIds).HasForeignKey(o => o.DepartmentId).WillCascadeOnDelete(false);
             Property(o => o.FileName).HasMaxLength(100);
             Property(o => o.FileExtension).HasMaxLength(10);
             ToTable("FileManager");
 

        }
    }
}
