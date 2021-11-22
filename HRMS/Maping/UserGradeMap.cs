using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserGradeMap : EntityTypeConfiguration<UserGrade>
    {
        public UserGradeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.Grade_GradeId).WithMany(o => o.UserGrade_GradeIds).HasForeignKey(o => o.GradeId).WillCascadeOnDelete(true);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserGrade_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            ToTable("UserGrade");

        }
    }
}