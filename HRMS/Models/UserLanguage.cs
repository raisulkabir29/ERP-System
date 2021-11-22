using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserLanguage
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Language")] 
        public int? LanguageId { get; set; }
        public virtual Language Language_LanguageId { get; set; }
        [DisplayName("Rate Your Self")] 
        public Nullable<int> RateYourSelf { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Modified By")] 
        public Nullable<int> ModifiedBy { get; set; }
        [DisplayName("Date Modied")] 
        public Nullable<DateTime> DateModied { get; set; }

    }
}
