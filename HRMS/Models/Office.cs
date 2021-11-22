using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Office
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [DisplayName("Title")]
        public string Title { get; set; }
        [DisplayName("Code")]
        public string Code { get; set; }
        [Required]
        [DisplayName("Created On")]
        public DateTime CreatedOn { get; set; }
        [Required]
        [DisplayName("Office Type")]
        public int? OfficeTypeId { get; set; }
        public virtual OfficeType OfficeType_OfficeTypeId { get; set; }
        [Required]
        [DisplayName("Company")]
        public int? CompanyId { get; set; }
        public virtual Company Company_CompanyId { get; set; }
        [StringLength(100)]
        [DisplayName("Map Latitude")]
        public string MapLatitude { get; set; }
        [StringLength(100)]
        [DisplayName("Map Longitude")]
        public string MapLongitude { get; set; }
        [StringLength(500)]
        [DisplayName("Details")]
        public string Details { get; set; }
        [StringLength(50)]
        [DisplayName("Fax")]
        public string Fax { get; set; }
        [StringLength(50)]
        [DisplayName("Country")]
        public string Country { get; set; }
        [StringLength(50)]
        [DisplayName("City")]
        public string City { get; set; }
        [StringLength(15)]
        [DisplayName("Zip Code")]
        public string ZipCode { get; set; }

        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
        public virtual ICollection<UserAllocation> UserAllocation_OfficeIds { get; set; }
        public virtual ICollection<OfficeAddress> OfficeAddress_OfficeIds { get; set; }
        public virtual ICollection<OfficeEmail> OfficeEmail_OfficeIds { get; set; }
        public virtual ICollection<OfficePhone> OfficePhone_OfficeIds { get; set; }
        public virtual ICollection<UserAttendence> UserAttendence_CompanyOfficeIds { get; set; }
        public virtual ICollection<AnnouncementOrNote> AnnouncementOrNote_OfficeIds { get; set; }
        public virtual ICollection<Expense> Expense_OfficeIds { get; set; }
        public virtual ICollection<Policy> Policy_OfficeIds { get; set; }
        public virtual ICollection<Ticket> Ticket_OfficeIds { get; set; }
        public virtual ICollection<FileManager> FileManager_OfficeIds { get; set; }
        public virtual ICollection<Department> Department_OfficeIds { get; set; }
        public virtual ICollection<Holiday> Holiday_OfficeIds { get; set; }
        public virtual ICollection<User> User_OfficeIds { get; set; }
        public virtual ICollection<OfficeDetails> OfficeDetails_OfficeIds { get; set; }

    }
}
