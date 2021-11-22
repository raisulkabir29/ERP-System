using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class EmployeeTerminationMap : EntityTypeConfiguration<EmployeeTermination>
    {
        public EmployeeTerminationMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.TerminationType_TerminationId).WithMany(o => o.EmployeeTermination_TerminationTypeIds).HasForeignKey(o => o.TerminationId).WillCascadeOnDelete(true);
            HasRequired(c => c.Department_DepartmentId).WithMany(o => o.EmployeeTermination_DepartmentIds).HasForeignKey(o => o.DepartmentId).WillCascadeOnDelete(true);
            HasRequired(c => c.User_UserId).WithMany(o => o.EmployeeTermination_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            Property(o => o.Description).HasMaxLength(400);
            Property(o => o.ReplyDay).HasMaxLength(2);
            Property(o => o.Month).HasMaxLength(4);
            Property(o => o.IsPayable).HasMaxLength(3);
            ToTable("EmployeeTermination");


        }
    }
}