using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserDetailsMap : EntityTypeConfiguration<UserDetails> 
    {
        public UserDetailsMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.User_UserId).WithMany(o => o.UserDetails_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
             Property(o => o.FatherOrHusbandName).HasMaxLength(100);
             Property(o => o.MotherName).HasMaxLength(100);
             Property(o => o.PresentAddressVillage).HasMaxLength(50);
             Property(o => o.PresentAddressPO).HasMaxLength(50);
             Property(o => o.PresentAddressThana).HasMaxLength(50);
             Property(o => o.PresentAddressDistrict).HasMaxLength(50);
             Property(o => o.PermanentAddressVillage).HasMaxLength(50);
             Property(o => o.PermanentAddressPO).HasMaxLength(50);
             Property(o => o.PermanentAddressThana).HasMaxLength(50);
             Property(o => o.PermanentAddressDistrict).HasMaxLength(50);
             Property(o => o.Height).HasMaxLength(20);
             Property(o => o.Weight).HasMaxLength(20);
             Property(o => o.Birthmark).HasMaxLength(50);
             Property(o => o.EyeColor).HasMaxLength(8);
             Property(o => o.HairColor).HasMaxLength(8);
             Property(o => o.NoOfTeeth).HasMaxLength(2);
             Property(o => o.Beard).HasMaxLength(3);
             Property(o => o.MaritalStatus).HasMaxLength(20);
             Property(o => o.ChildNo).HasMaxLength(20);
             Property(o => o.FamilyMember).HasMaxLength(10);
             Property(o => o.EarningMemberInFamily).HasMaxLength(2);
             Property(o => o.Religion).HasMaxLength(10);
             Property(o => o.TotalExperience).HasMaxLength(50);
             Property(o => o.EmailAddress).HasMaxLength(50);
             Property(o => o.LandPhoneNo).HasMaxLength(20);
             Property(o => o.MbPhoneNo).HasMaxLength(20);
             Property(o => o.IsActive).HasMaxLength(3);
             Property(o => o.IsEmergency).HasMaxLength(3);
             Property(o => o.InvolvedInCrime).HasMaxLength(3);
             Property(o => o.NoObjectionCert).HasMaxLength(3);
            ToTable("UserDeails");
 

        }
    }
}