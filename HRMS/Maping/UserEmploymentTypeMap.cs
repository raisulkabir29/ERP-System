using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using HRMS.Models;

namespace HRMS.Maping
{
    public class UserEmploymentTypeMap : EntityTypeConfiguration<UserEmploymentType>
    {
        public UserEmploymentTypeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.EmploymentType_EmploymentTypeId).WithMany(o => o.UserEmploymentType_EmploymentTypeIds).HasForeignKey(o => o.EmploymentTypeId).WillCascadeOnDelete(true);
            HasRequired(c => c.Department_DepartmentId).WithMany(o => o.UserEmploymentType_DepartmentIds).HasForeignKey(o => o.DepartmentId).WillCascadeOnDelete(true);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserEmploymentType_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            ToTable("UserEmploymentType");
        }
    }
}