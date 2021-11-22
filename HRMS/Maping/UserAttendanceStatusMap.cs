using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserAttendanceStatusMap : EntityTypeConfiguration<UserAttendanceStatus>
    {
        public UserAttendanceStatusMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Code).HasMaxLength(10);
            Property(o => o.Name).HasMaxLength(10);
            Property(o => o.Description).HasMaxLength(200);
            ToTable("UserAttendanceStatus");
        }
    }
}