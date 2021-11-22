using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserAddress
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(150)] 
        [DisplayName("Line1")] 
        public string Line1 { get; set; }
        [StringLength(150)] 
        [DisplayName("Line2")] 
        public string Line2 { get; set; }
        [StringLength(50)] 
        [DisplayName("City")] 
        public string City { get; set; }
        [StringLength(50)] 
        [DisplayName("Pin Code")] 
        public string PinCode { get; set; }
        [StringLength(100)] 
        [DisplayName("Near By")] 
        public string NearBy { get; set; }
        [Required]
        [DisplayName("Is Emergency")] 
        public bool IsEmergency { get; set; }
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        public virtual ICollection<OfficeAddress> OfficeAddress_AddressIds { get; set; }

    }
}
