using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserAttendence
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Company Office")] 
        public int? CompanyOfficeId { get; set; }
        public virtual Office Office_CompanyOfficeId { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Punch In")] 
        public DateTime PunchIn { get; set; }
        [Required]
        [DisplayName("Punch Out")] 
        public DateTime PunchOut { get; set; }
        [Required]
        [DisplayName("Date Of Attendence")] 
        public DateTime DateOfAttendence { get; set; }
        [Required]
        [DisplayName("Is Present")] 
        public bool IsPresent { get; set; }
        [StringLength(100)] 
        [DisplayName("Any Remarks")] 
        public string AnyRemarks { get; set; }

    }
}
