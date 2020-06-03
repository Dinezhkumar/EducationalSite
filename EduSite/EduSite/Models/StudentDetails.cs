using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Web;

namespace UnivSite.Models
{
    public class StudentDetails
    {
        public class StudentDetailsModel
        {
            public PersonalDetails PersonalDetails { get; set; }
            public IEnumerable<AcademicDetails> AcademicDetails { get; set; }
            public AddressDetails AddressDetails { get; set; }
            public FeeDetails FeeDetails { get; set; }

        }

        public class PersonalDetails
        {
            public string StudentId { get; set; }
            public string ApplicantName { get; set; }
            public string FatherName { get; set; }
            public string MotherName { get; set; }
            public string RegistrationNo { get; set; }
            public string NatureOfDocument { get; set; }
            public string ReasonOfApplying { get; set; }
        }
        public class AcademicDetails
        {
            public string AcademicDetailsId { get; set; }
            public string StudentId { get; set; }
            public string Course { get; set; }
            public string Semester { get; set; }
            public string Year { get; set; }
            public string CollegeName { get; set; }
            public string MarksScored { get; set; }
            public string MaxMark { get; set; }
            public string UploadFile { get; set; }

        }
        public class AddressDetails
        {
            public string AddressDetailsDetailsId { get; set; }
            public string StudentId { get; set; }
            public string FullAddress { get; set; }
            public string PhoneNumberOffice { get; set; }
            public string PhoneNumberResidence { get; set; }
            public string EmailId { get; set; }
        }
        public class FeeDetails
        {
            public string FeeDetailsId { get; set; }
            public string StudentId { get; set; }
            public string TransactionId { get; set; }
            public DateTime Date { get; set; }
            public String PayeeName { get; set; }
            public string FathersName { get; set; }
            public DateTime DOB { get; set; }
            public string PhoneNumberOffice { get; set; }
            public string FeeCode { get; set; }
            public string FeeDetail { get; set; }
            public string FeeDescription { get; set; }
            public decimal Amount { get; set; }
        }
    }
}