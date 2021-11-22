using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace HRMS.Models
{
    public class EmployeeTermination
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Termination Name")]
        public int? TerminationId { get; set; }
        public virtual TerminationType TerminationType_TerminationId { get; set; }

        [Required]
        [DisplayName("Department Name")]
        public int? DepartmentId { get; set; }
        public virtual Department Department_DepartmentId { get; set; }

        [DisplayName("Sub.Department Name")]
        public int? SectionId { get; set; }

        [Required]
        [DisplayName("User")]
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [Required]
        [DisplayName("ID Card No")]
        public int CustomId { get; set; }

        [DisplayName("Occurance Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime OccuranceDate { get; set; }

        [DisplayName("Detection Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DetectionDate { get; set; }

        [DisplayName("Showcause Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ShowcauseDate { get; set; }

        [DisplayName("Description")]
        [StringLength(400)]
        public string Description { get; set; }

        [DisplayName("Reply Day")]
        [StringLength(2)]
        public string ReplyDay { get; set; }

        [DisplayName("Notification Day")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime NotificationDay { get; set; }

        [DisplayName("Termination Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime TerminationDate { get; set; }

        [DisplayName("Year")]
        public int? Year { get; set; }

        [DisplayName("Month")]
        [StringLength(4)]
        public string Month { get; set; }

        [DisplayName("IsPayable")]
        [StringLength(3)]
        public string IsPayable { get; set; }

        [DisplayName("PayableAmount")]
        public decimal PayableAmount { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}