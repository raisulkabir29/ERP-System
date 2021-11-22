using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Expense
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Title")] 
        public string Title { get; set; }
        [Required]
        [DisplayName("Purchase Date")] 
        public DateTime PurchaseDate { get; set; }
        [Required]
        [DisplayName("Amount")] 
        public Decimal Amount { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Purchased By")] 
        public string PurchasedBy { get; set; }
        [DisplayName("Bill Attachment")] 
        public string BillAttachment { get; set; }
        [DisplayName("Remarks")] 
        public string Remarks { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }

    }
}
