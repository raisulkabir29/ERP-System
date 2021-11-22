using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class FileManager
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [DisplayName("Office")] 
        public int? OfficeId { get; set; }
        public virtual Office Office_OfficeId { get; set; }
        [Required]
        [DisplayName("Department")] 
        public int? DepartmentId { get; set; }
        public virtual Department Department_DepartmentId { get; set; }
        [DisplayName("File Name")] 
        public string FileName { get; set; }
        [DisplayName("File Size")] 
        public Nullable<Decimal> FileSize { get; set; }
        [StringLength(10)] 
        [DisplayName("File Extension")] 
        public string FileExtension { get; set; }
        [DisplayName("Date Added")] 
        public Nullable<DateTime> DateAdded { get; set; }
        [DisplayName("Added By")] 
        public Nullable<int> AddedBy { get; set; }

    }
}
