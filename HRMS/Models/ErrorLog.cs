using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class ErrorLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [DisplayName("S.No")]
        public int Id { get; set; }
        //public Guid Id { get; set; }

        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime CreatedDateTime { get; set; }
        [MaxLength(1024)]
        public string ErrorFrom { get; set; }
        [MaxLength(1024)]
        public string ErrorFor { get; set; }
        [MaxLength(1024)]
        public string ErrorMessage { get; set; }
    }
}