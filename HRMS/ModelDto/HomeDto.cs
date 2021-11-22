using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HRMS.ModelDto
{
    public class HomeDto
    {
        public int? User { get; set; }
        public int? Role { get; set; }
        public int? Menu { get; set; }
        public int? Offce { get; set; }
        public int?  Department{ get; set; }
        public int? Interviews { get; set; }
        public decimal Expense { get; set; }
        public int? PresentEmployee { get; set; }
        public int? AbsentEmployees { get; set; }
        public int? LeaveEmployess { get; set; }
        public int? Holidays { get; set; }
        public int? Announcement { get; set; }
        public int? Notes { get; set; }
        public int? Policy { get; set; }
    }
   
}
