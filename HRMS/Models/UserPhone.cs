using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserPhone
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Phone Number")] 
        public string PhoneNumber { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        [Required]
        [DisplayName("Is Emergency")] 
        public bool IsEmergency { get; set; }
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

    }
}
