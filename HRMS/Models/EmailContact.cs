using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HRMS.Models
{
    public class EmailContact
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Controller Name")]
        [StringLength(50)]
        public string ControllerName { get; set; }

        [Required]
        [DisplayName("Action Name")]
        [StringLength(20)]
        public string ActionName { get; set; }

        [Required]
        [DisplayName("Table Name")]
        [StringLength(100)]
        public string TableName { get; set; }

        [Required]
        [DisplayName("Application Id")]
        public int ApplicationId { get; set; }

        [Required]
        [DisplayName("Applicant Id")]
        public int? ApplicantId { get; set; }

        [DisplayName("Applicant Name")]
        [StringLength(100)]
        public string ApplicantName { get; set; }

        [DisplayName("Applicant Email")]
        [StringLength(100)]
        public string ApplicantEmail { get; set; }

        [DisplayName("Applicant Contact No")]
        [StringLength(20)]
        public string ApplicantContactNo { get; set; }

        [DisplayName("ForwardedTo Email")]
        [StringLength(100)]
        public string ForwardedToEmail { get; set; }

        [DisplayName("RecommendedBy Email")]
        [StringLength(100)]
        public string RecommendedByEmail { get; set; }

        [DisplayName("ApprovedBy Email")]
        [StringLength(100)]
        public string ApprovedByEmail { get; set; }

        [DisplayName("Admin Email")]
        [StringLength(100)]
        public string AdminEmail { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        [DisplayName("Added By")]
        public int? AddedBy { get; set; }

        [DisplayName("Date Added")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }

        [DisplayName("Modified Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public Nullable<DateTime> ModifiedDate { get; set; }
    }
}