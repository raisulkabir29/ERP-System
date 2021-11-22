﻿using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserSalaryIncrementMap : EntityTypeConfiguration<UserSalaryIncrement>
    {
        public UserSalaryIncrementMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserSalaryIncrement_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            Property(o => o.OTNOT).HasMaxLength(3);
            Property(o => o.Month).HasMaxLength(4);
            ToTable("UserSalaryIncrement");
        }
    }
}