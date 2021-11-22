using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserDetails
    {
        [DisplayName("S.No")]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }
        //[DisplayName("ID Card No")]
        //public int CustomId { get; set; }
        [DisplayName("Joining Date")]
        public Nullable<DateTime> JoiningDate { get; set; }
        [DisplayName("Is Father or Husband")]
        [StringLength(10)]
        public string FatherOrHusband { get; set; }
        [DisplayName("Father Or Husband Name")]
        [StringLength(100)]
        public string FatherOrHusbandName { get; set; }
        [DisplayName("Mother Name")]
        [StringLength(100)]
        public string MotherName { get; set; }
        [DisplayName("Present Address Village")]
        [StringLength(50)]
        public string PresentAddressVillage { get; set; }
        [DisplayName("Present Address PO")]
        [StringLength(50)]
        public string PresentAddressPO { get; set; }
        [DisplayName("Present Address Thana")]
        [StringLength(50)]
        public string PresentAddressThana { get; set; }
        [DisplayName("Present Address District")]
        [StringLength(50)]
        public string PresentAddressDistrict { get; set; }
        [DisplayName("Permanent Address Village")]
        [StringLength(50)]
        public string PermanentAddressVillage { get; set; }
        [DisplayName("Permanent Address PO")]
        [StringLength(50)]
        public string PermanentAddressPO { get; set; }
        [DisplayName("Permanent Address Thana")]
        [StringLength(50)]
        public string PermanentAddressThana { get; set; }
        [DisplayName("Permanent Address District")]
        [StringLength(50)]
        public string PermanentAddressDistrict { get; set; }
        [DisplayName("Height")]
        [StringLength(20)]
        public string Height { get; set; }
        [DisplayName("Weight")]
        [StringLength(20)]
        public string Weight { get; set; }
        [DisplayName("Birthmark")]
        [StringLength(50)]
        public string Birthmark { get; set; }
        [DisplayName("Eye Color")]
        [StringLength(8)]
        public string EyeColor { get; set; }
        [DisplayName("Hair Color")]
        [StringLength(8)]
        public string HairColor { get; set; }
        [DisplayName("No Of Teeth")]
        [StringLength(2)]
        public string NoOfTeeth { get; set; }
        [DisplayName("Age")]
        public Nullable<int> Age { get; set; }
        [DisplayName("Beard")]
        [StringLength(3)]
        //public Nullable<bool> Beard { get; set; }
        public string Beard { get; set; }
        [DisplayName("Marital Status")]
        [StringLength(20)]
        public string MaritalStatus { get; set; }
        [DisplayName("Child No")]
        [StringLength(20)]
        public string ChildNo { get; set; }
        [DisplayName("Family Member")]
        [StringLength(10)]
        public string FamilyMember { get; set; }
        [DisplayName("Earning Member In Family")]
        [StringLength(2)]
        public string EarningMemberInFamily { get; set; }
        [DisplayName("Religion")]
        [StringLength(10)]
        public string Religion { get; set; }
        [DisplayName("Total Experience")]
        [StringLength(50)]
        public string TotalExperience { get; set; }
        [DisplayName("Email Address")]
        [StringLength(50)]
        public string EmailAddress { get; set; }
        [DisplayName("Land Phone No")]
        [StringLength(20)]
        public string LandPhoneNo { get; set; }
        [DisplayName("Mobile Phone No")]
        [StringLength(20)]
        public string MbPhoneNo { get; set; }
        [DisplayName("Is Active")]
        [StringLength(3)]
        //public Nullable<bool> IsActive { get; set; }
        public string IsActive { get; set; }
        [DisplayName("Is Emergency")]
        [StringLength(3)]
        //public Nullable<bool> IsEmergency { get; set; }
        public string IsEmergency { get; set; }
        [DisplayName("Involved In Crime")]
        [StringLength(3)]
        //public Nullable<bool> InvolvedInCrime { get; set; }
        public string InvolvedInCrime { get; set; }
        [DisplayName("No Objection Cert")]
        [StringLength(3)]
        //public Nullable<bool> NoObjectionCert { get; set; }
        public string NoObjectionCert { get; set; }
        [DisplayName("Added By")]
        public Nullable<int> AddedBy { get; set; }
        [DisplayName("Date Added")]
        public Nullable<DateTime> DateAdded { get; set; }

        [DisplayName("Modified Date")]
        public Nullable<DateTime> ModifiedDate { get; set; }

        [DisplayName("Modified By")]
        public int? ModifiedBy { get; set; }
    }
}