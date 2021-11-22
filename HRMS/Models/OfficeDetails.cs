using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class OfficeDetails
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [DisplayName("Office Title")]
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }

        [DisplayName("Email Address")]
        [StringLength(50)]
        public string EmailAddress { get; set; }

        [DisplayName("Land-Phone No")]
        [StringLength(20)]
        public string LandPhoneNo { get; set; }

        [DisplayName("Mobile-Phone No")]
        [StringLength(20)]
        public string MbPhoneNo { get; set; }

        [DisplayName("Address")]
        [StringLength(200)]
        public string Address { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}