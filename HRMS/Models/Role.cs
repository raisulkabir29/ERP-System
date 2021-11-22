using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class Role
    {
        [DisplayName("S.No")] 
        public int Id { get; set; }
        [Required]
        [StringLength(50)] 
        [DisplayName("Role Name")] 
        public string RoleName { get; set; }
        [Required]
        [DisplayName("Is Active")] 
        public bool IsActive { get; set; }
        public virtual ICollection<MenuPermission> MenuPermission_RoleIds { get; set; }
        public virtual ICollection<RoleUser> RoleUser_RoleIds { get; set; }

    }
}
