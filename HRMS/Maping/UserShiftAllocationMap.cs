using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserShiftAllocationMap : EntityTypeConfiguration<UserShiftAllocation>
    {
        public UserShiftAllocationMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserShiftAllocation_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            HasRequired(c => c.ShiftMaster_ShiftMasterId).WithMany(o => o.UserShiftAllocation_ShiftMasterIds).HasForeignKey(o => o.ShiftId).WillCascadeOnDelete(true);
            Property(o => o.Month).HasMaxLength(4);
            ToTable("UserShiftAllocation");


        }
    }
}