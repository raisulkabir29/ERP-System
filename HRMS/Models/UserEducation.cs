using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserEducation
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }

        [DisplayName("Institution")] 
        public int? InstitutionId { get; set; }
        public virtual University University_InstitutionId { get; set; }
        [DisplayName("Digree")] 
        public int? Digree { get; set; }
        public virtual Qualification Qualification_Digree { get; set; }
        [DisplayName("From Date")] 
        public Nullable<DateTime> FromDate { get; set; }
        [DisplayName("To Date")] 
        public Nullable<DateTime> ToDate { get; set; }
        [Required]
        [DisplayName("User")] 
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        [DisplayName("Total Marks")] 
        public Nullable<double> TotalMarks { get; set; }
        [DisplayName("Out Of Marks")] 
        public Nullable<double> OutOfMarks { get; set; }
        [DisplayName("Percentage")] 
        public Nullable<double> Percentage { get; set; }
        [DisplayName("Institution Name")]
        public string InstitutionName { get; set; }

        [DisplayName("Latest Degree")]
        public string LatestDegree { get; set; }

        [DisplayName("Division Or Grade")]
        public string DivisionOrGrade { get; set; }

    }
}
