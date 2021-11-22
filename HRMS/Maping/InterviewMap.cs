using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class InterviewMap : EntityTypeConfiguration<Interview> 
    {
        public InterviewMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             Property(o => o.CandidateName).HasMaxLength(100);
             Property(o => o.Email).HasMaxLength(50);
             Property(o => o.Mobile).HasMaxLength(15);
             Property(o => o.Address).HasMaxLength(200);
             HasRequired(c => c.JobTitle_JobTitleId).WithMany(o => o.Interview_JobTitleIds).HasForeignKey(o => o.JobTitleId).WillCascadeOnDelete(false);
             Property(o => o.PlaceOfInterview).HasMaxLength(100);
             Property(o => o.InterviewRemarks).HasMaxLength(1000);
             ToTable("Interview");
 

        }
    }
}
