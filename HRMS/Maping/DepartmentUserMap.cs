using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using HRMS.Models;

namespace HRMS.Maping
{
    public class DepartmentUserMap : EntityTypeConfiguration<DepartmentUser>
    {
        public DepartmentUserMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.Department_DepartmentId).WithMany(o => o.DepartmentUser_DepartmentIds).HasForeignKey(o => o.DepartmentId).WillCascadeOnDelete(true);
            HasRequired(c => c.User_UserId).WithMany(o => o.DepartmentUser_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            ToTable("DepartmentUser");
        }
    }
}