using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Interview
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Candidate Name")] 
        public string CandidateName { get; set; }
        [Required]
[RegularExpression(@"[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,4}", ErrorMessage = "Please enter correct email")]        [StringLength(50)] 
        [DisplayName("Email")] 

        public string Email { get; set; }
        [Required]
        [StringLength(15)] 
        [DisplayName("Mobile")] 
        public string Mobile { get; set; }
        [DisplayName("Address")] 
        public string Address { get; set; }
        [Required]
        [DisplayName("Job Title")] 
        public int? JobTitleId { get; set; }
        public virtual JobTitle JobTitle_JobTitleId { get; set; }
        [Required]
        [DisplayName("Interview Date")] 
        public DateTime InterviewDate { get; set; }
        [Required]
        [StringLength(100)] 
        [DisplayName("Place Of Interview")] 
        public string PlaceOfInterview { get; set; }
        [Required]
        [DisplayName("Interview Time")] 
        public DateTime InterviewTime { get; set; }
        [Required]
        [DisplayName("Interview By")] 
        public int InterviewBy { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Modified Date")] 
        public Nullable<DateTime> ModifiedDate { get; set; }
        [Required]
        [DisplayName("Interview Remarks")] 
        public string InterviewRemarks { get; set; }
        [DisplayName("Is Done")] 
        public Nullable<bool> IsDone { get; set; }

    }
}
