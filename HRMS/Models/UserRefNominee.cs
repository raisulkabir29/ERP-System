using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace HRMS.Models
{
    public class UserRefNominee
    {
        [DisplayName("S.No")]
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual User User_UserId { get; set; }

        [DisplayName("Current Guardian Name")]
        [StringLength(50)]
        public string CurrentGuardianName { get; set; }

        [DisplayName("Recommender")]
        [StringLength(50)]
        public string Recommender { get; set; }

        [DisplayName("Emergency Contact Name")]
        [StringLength(50)]
        public string EmergContactName { get; set; }

        [DisplayName("Emergency Contact Relation")]
        [StringLength(50)]
        public string EmergContactRel { get; set; }

        [DisplayName("Emergency Contact Address Village")]
        [StringLength(50)]
        public string EmergContactAddrVillage { get; set; }

        [DisplayName("Emergency Contact Address PO")]
        [StringLength(50)]
        public string EmergContactAddrPO { get; set; }

        [DisplayName("Emergency Contact Address Thana")]
        [StringLength(50)]
        public string EmergContactAddrThana { get; set; }

        [DisplayName("Emergency Contact Address District")]
        [StringLength(50)]
        public string EmergContactAddrDistrict { get; set; }

        [DisplayName("Emergency Contact Phone No")]
        [StringLength(20)]
        public string EmergContactPhNo { get; set; }

        [DisplayName("Emergency Contact Mb No")]
        [StringLength(20)]
        public string EmergContactMbNo { get; set; }

        [DisplayName("Reference1 Name")]
        [StringLength(50)]
        public string Reference1Name { get; set; }

        [DisplayName("Reference1 Company")]
        [StringLength(50)]
        public string Reference1Company { get; set; }

        [DisplayName("Reference1 Designation")]
        [StringLength(20)]
        public string Reference1Designation { get; set; }

        [DisplayName("Reference1 Contact No")]
        [StringLength(20)]
        public string Reference1ContactNo { get; set; }

        [DisplayName("Reference1 Address Village")]
        [StringLength(50)]
        public string Reference1AddrVillage { get; set; }

        [DisplayName("Reference1 Address PO")]
        [StringLength(50)]
        public string Reference1AddrPO { get; set; }

        [DisplayName("Reference1 Address Thana")]
        [StringLength(50)]
        public string Reference1AddrThana { get; set; }

        [DisplayName("Reference1 Address District")]
        [StringLength(50)]
        public string Reference1AddrDistrict { get; set; }

        [DisplayName("Reference2 Name")]
        [StringLength(50)]
        public string Reference2Name { get; set; }

        [DisplayName("Reference2 Company")]
        [StringLength(50)]
        public string Reference2Company { get; set; }

        [DisplayName("Reference2 Designation")]
        [StringLength(20)]
        public string Reference2Designation { get; set; }

        [DisplayName("Reference2 Contact No")]
        [StringLength(20)]
        public string Reference2ContactNo { get; set; }

        [DisplayName("Reference2 Address Village")]
        [StringLength(50)]
        public string Reference2AddrVillage { get; set; }

        [DisplayName("Reference2 Address PO")]
        [StringLength(50)]
        public string Reference2AddrPO { get; set; }

        [DisplayName("Reference2 Address Thana")]
        [StringLength(50)]
        public string Reference2AddrThana { get; set; }

        [DisplayName("Reference2 Address District")]
        [StringLength(50)]
        public string Reference2AddrDistrict { get; set; }

        [DisplayName("Nominee Name")]
        [StringLength(50)]
        public string NomineeName { get; set; }

        [DisplayName("Nominee Father Name")]
        [StringLength(50)]
        public string NomineeFatherName { get; set; }

        [DisplayName("Nominee Mother Name")]
        [StringLength(50)]
        public string NomineeMotherName { get; set; }

        [DisplayName("Nominee Profession")]
        [StringLength(20)]
        public string NomineeProfession { get; set; }

        [DisplayName("Nominee Contact Ph No")]
        [StringLength(20)]
        public string NomineeContactPhNo { get; set; }

        [DisplayName("Relation with Nominee")]
        [StringLength(20)]
        public string NomineeRel { get; set; }

        [DisplayName("Nominee Address Village")]
        [StringLength(50)]
        public string NomineeAddrVillage { get; set; }

        [DisplayName("Nominee Address PO")]
        [StringLength(50)]
        public string NomineeAddrPO { get; set; }

        [DisplayName("Nominee Address Union")]
        [StringLength(50)]
        public string NomineeAddrUnion { get; set; }

        [DisplayName("Nominee Address Upazilla")]
        [StringLength(50)]
        public string NomineeAddrUpazilla { get; set; }

        [DisplayName("Nominee Address District")]
        [StringLength(50)]
        public string NomineeAddrDistrict { get; set; }

        [DisplayName("Birth Certificate")]
        public bool BirthCertificate { get; set; }

        [DisplayName("Police Verification")]
        public bool PoliceVerification { get; set; }

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