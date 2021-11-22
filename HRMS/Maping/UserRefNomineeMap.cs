using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class UserRefNomineeMap : EntityTypeConfiguration<UserRefNominee> 
    {
        public UserRefNomineeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            HasRequired(c => c.User_UserId).WithMany(o => o.UserRefNominee_UserIds).HasForeignKey(o => o.UserId).WillCascadeOnDelete(true);
            Property(o => o.CurrentGuardianName).HasMaxLength(50);
            Property(o => o.Recommender).HasMaxLength(50);
            Property(o => o.EmergContactName).HasMaxLength(50);
            Property(o => o.EmergContactRel).HasMaxLength(50);
            Property(o => o.EmergContactAddrVillage).HasMaxLength(50);
            Property(o => o.EmergContactAddrPO).HasMaxLength(50);
            Property(o => o.EmergContactAddrThana).HasMaxLength(50);
            Property(o => o.EmergContactAddrDistrict).HasMaxLength(50);
            Property(o => o.EmergContactPhNo).HasMaxLength(20);
            Property(o => o.EmergContactMbNo).HasMaxLength(20);
            Property(o => o.Reference1Name).HasMaxLength(50);
            Property(o => o.Reference1Company).HasMaxLength(50);
            Property(o => o.Reference1Designation).HasMaxLength(20);
            Property(o => o.Reference1ContactNo).HasMaxLength(20);
            Property(o => o.Reference1AddrVillage).HasMaxLength(50);
            Property(o => o.Reference1AddrPO).HasMaxLength(50);
            Property(o => o.Reference1AddrThana).HasMaxLength(50);
            Property(o => o.Reference1AddrDistrict).HasMaxLength(50);
            Property(o => o.Reference2Name).HasMaxLength(50);
            Property(o => o.Reference2Company).HasMaxLength(50);
            Property(o => o.Reference2Designation).HasMaxLength(20);
            Property(o => o.Reference2ContactNo).HasMaxLength(20);
            Property(o => o.Reference2AddrVillage).HasMaxLength(50);
            Property(o => o.Reference2AddrPO).HasMaxLength(50);
            Property(o => o.Reference2AddrThana).HasMaxLength(50);
            Property(o => o.Reference2AddrDistrict).HasMaxLength(50);
            Property(o => o.NomineeName).HasMaxLength(50);
            Property(o => o.NomineeFatherName).HasMaxLength(50);
            Property(o => o.NomineeMotherName).HasMaxLength(50);
            Property(o => o.NomineeProfession).HasMaxLength(20);
            Property(o => o.NomineeContactPhNo).HasMaxLength(20);
            Property(o => o.NomineeRel).HasMaxLength(20);
            Property(o => o.NomineeAddrVillage).HasMaxLength(50);
            Property(o => o.NomineeAddrPO).HasMaxLength(50);
            Property(o => o.NomineeAddrUnion).HasMaxLength(50);
            Property(o => o.NomineeAddrUpazilla).HasMaxLength(50);
            Property(o => o.NomineeAddrDistrict).HasMaxLength(50);
            ToTable("UserRefNominee");
        }
    }
}