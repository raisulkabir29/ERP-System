using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Company
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Name")]
        public string Name { get; set; }
        [Required]
        [DisplayName("About")]
        public string About { get; set; }
        [Required]
        [DisplayName("Is Active")]
        public bool IsActive { get; set; }
        [StringLength(100)]
        [DisplayName("Website")]
        public string Website { get; set; }
        [StringLength(13)]
        [DisplayName("Phone")]
        public string Phone { get; set; }
        [StringLength(15)]
        [DisplayName("Fax")]
        public string Fax { get; set; }
        [StringLength(100)]
        [DisplayName("Map Latitude")]
        public string MapLatitude { get; set; }
        [StringLength(100)]
        [DisplayName("Map Longitude")]
        public string MapLongitude { get; set; }
        [StringLength(100)]
        [DisplayName("Tax Number Or E I N")]
        public string TaxNumberOrEIN { get; set; }
        [DisplayName("Logo")]
        public string Logo { get; set; }
        [StringLength(100)]
        [DisplayName("Address")]
        public string Address { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
        public virtual ICollection<Office> Office_CompanyIds { get; set; }

    }
}
