using HRMS.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace HRMS.Maping
{
    public class TerminationTypeMap : EntityTypeConfiguration<TerminationType>
    {
        public TerminationTypeMap()
        {
            HasKey(o => o.Id);
            Property(o => o.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(o => o.Code).HasMaxLength(10);
            Property(o => o.Name).HasMaxLength(50);
            Property(o => o.Description).HasMaxLength(400);
            ToTable("TerminationType");
        }
    }
}