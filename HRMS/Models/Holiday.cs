using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Holiday
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [Required]
        [DisplayName("Holiday Date")] 
        public DateTime HolidayDate { get; set; }
        [StringLength(100)] 
        [DisplayName("Detail")] 
        public string Detail { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }

    }
}
