using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class TicketMap : EntityTypeConfiguration<Ticket> 
    {
        public TicketMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.Ticket_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(true);
             Property(o => o.Subject).HasMaxLength(100);
             Property(o => o.Description).HasMaxLength(200);
             HasOptional(c => c.Ticket2).WithMany(o => o.Ticket_ParentIds).HasForeignKey(o => o.ParentId);
             ToTable("Ticket");
 

        }
    }
}
