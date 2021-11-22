using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class OfficeAddress
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [Required]
        [DisplayName("Address")] 
        public int? AddressId { get; set; }
        public virtual UserAddress UserAddress_AddressId { get; set; }

    }
}
