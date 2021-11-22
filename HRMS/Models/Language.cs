using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Language
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Name")] 
        public string Name { get; set; }
        [StringLength(12)] 
        [DisplayName("Code")] 
        public string Code { get; set; }
        public virtual ICollection<UserLanguage> UserLanguage_LanguageIds { get; set; }

    }
}
