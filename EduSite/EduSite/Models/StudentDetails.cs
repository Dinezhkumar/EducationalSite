using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnivSite.Models
{
    public class StudentDetails
    {
        public class PersonalDetails
        {
            public string ApplicantName { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string RegistrationNo { get; set; }
            public string NatureOfDocument { get; set; }
            public string ReasonOfApplying { get; set; }
        }
        public class AcademicDetails
        {
            public string CourseName { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string RegistrationNo { get; set; }
            public string NatureOfDocument { get; set; }
            public string ReasonOfApplying { get; set; }
        }
        public class AddressDetails
        {
            public string Address { get; set; }
            public string PhoneNumberOffice { get; set; }
            public string PhoneNumberResidence { get; set; }
            public string EmailId { get; set; }
        }
    }
}