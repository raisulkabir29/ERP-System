using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserPayrollSalaryMap : EntityTypeConfiguration<UserPayrollSalary> 
    {
        public UserPayrollSalaryMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserPayrollSalary_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             ToTable("UserPayrollSalary");
 

        }
    }
}
