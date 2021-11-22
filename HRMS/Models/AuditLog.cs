using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class AuditLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("S.No")]
        public int Id { get; set; }

        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public int Action { get; set; }

        [MaxLength(1024)]
        public string ModuleName { get; set; }

        [MaxLength(1024)]
        public string SubModuleName { get; set; }

        [MaxLength(1024)]
        public string ActionFrom { get; set; }

        [MaxLength(1024)]
        public string ActionMessage { get; set; }
    }
}