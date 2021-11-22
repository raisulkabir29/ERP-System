using HRMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace HRMS.Maping
{
    public class ExpenseMap : EntityTypeConfiguration<Expense> 
    {
        public ExpenseMap()
        {
             HasKey(o => o.Id);
             Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
             HasRequired(c => c.Office_OfficeId).WithMany(o => o.Expense_OfficeIds).HasForeignKey(o => o.OfficeId).WillCascadeOnDelete(false);
             Property(o => o.Title).HasMaxLength(100);
             Property(o => o.PurchasedBy).HasMaxLength(100);
             Property(o => o.BillAttachment).HasMaxLength(100);
             Property(o => o.Remarks).HasMaxLength(200);
             ToTable("Expense");
 

        }
    }
}
