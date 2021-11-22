using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Setting
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("s Key")] 
        public string sKey { get; set; }
        [Required]
        [DisplayName("s Value")] 
        public string sValue { get; set; }
        [StringLength(100)] 
        [DisplayName("s Group")] 
        public string sGroup { get; set; }
        [DisplayName("Office")] 
        public Nullable<int> OfficeId { get; set; }

    }
}
