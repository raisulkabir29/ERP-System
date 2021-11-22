using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserTravels
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [Required]
        [DisplayName("Start Date")] 
        public DateTime StartDate { get; set; }
        [Required]
        [DisplayName("End Date")] 
        public DateTime EndDate { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Purpose Of Visit")] 
        public string PurposeOfVisit { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Place Of Visit")] 
        public string PlaceOfVisit { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Travel By")] 
        public string TravelBy { get; set; }
        [Required]
        [DisplayName("Expected Travel Budget")] 
        public Decimal ExpectedTravelBudget { get; set; }
        [Required]
        [DisplayName("Actual Travel Budget")] 
        public Decimal ActualTravelBudget { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Description")] 
        public string Description { get; set; }

    }
}
