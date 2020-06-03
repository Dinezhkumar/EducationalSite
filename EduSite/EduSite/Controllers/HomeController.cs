using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static UnivSite.Models.StudentDetails;
using EduSite.SqlDal;
using System.Web.WebPages;

namespace EduSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StudentDetailsModel studentDetailsModel = new StudentDetailsModel();
            return View(studentDetailsModel);
        }

        [HttpPost]
        public ActionResult SavePersonalDetails(FormCollection formCollection)
        {
            PersonalDetails personalDetails = new PersonalDetails();

            if(!string.IsNullOrEmpty(formCollection["Name"]))
            {
                personalDetails.ApplicantName = formCollection["Name"].ToString();
            }
            if(!string.IsNullOrEmpty(formCollection["MotherName"]))
            {
                personalDetails.MotherName = formCollection["MotherName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FatherName"]))
            {
                personalDetails.MotherName = formCollection["FatherName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["RegistrationNo"]))
            {
                personalDetails.RegistrationNo = formCollection["RegistrationNo"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["NatureOfDocument"]))
            {
                personalDetails.RegistrationNo = formCollection["NatureOfDocument"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["ReasonOfApplying"]))
            {
                personalDetails.RegistrationNo = formCollection["ReasonOfApplying"].ToString();
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            studentDetailsDal.AddPersonalDetails(personalDetails);
            return View("PersonalDetails.cshtml", personalDetails);
        }

        [HttpPost]
        public ActionResult SaveAddressDetails(FormCollection formCollection)
        {
            AddressDetails addressDetails = new AddressDetails();
            if (!string.IsNullOrEmpty(formCollection["FullAddress"]))
            {
                addressDetails.FullAddress = formCollection["FullAddress"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PhoneNumberOffice"]))
            {
                addressDetails.PhoneNumberOffice = formCollection["PhoneNumberOffice"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PhoneNumberResidence"]))
            {
                addressDetails.PhoneNumberResidence = formCollection["PhoneNumberResidence"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["EmailId"]))
            {
                addressDetails.EmailId = formCollection["EmailId"].ToString();
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            studentDetailsDal.SaveAddressDetails(addressDetails);
            return View();
        }

        [HttpPost]
        public ActionResult SaveFeeDetails(FormCollection formCollection)
        {
            FeeDetails feeDetails = new FeeDetails();

            if (!string.IsNullOrEmpty(formCollection["StudentId"]))
            {
                feeDetails.StudentId = formCollection["StudentId"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["TransactionId"]))
            {
                feeDetails.TransactionId = formCollection["TransactionId"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["Date"]))
            {
                feeDetails.Date = formCollection["Date"].AsDateTime();
            }
            if (!string.IsNullOrEmpty(formCollection["PayeeName"]))
            {
                feeDetails.PayeeName = formCollection["PayeeName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FathersName"]))
            {
                feeDetails.FathersName = formCollection["FathersName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["DOB"]))
            {
                feeDetails.DOB = formCollection["DOB"].AsDateTime();
            }
            if (!string.IsNullOrEmpty(formCollection["PhoneNumberOffice"]))
            {
                feeDetails.PhoneNumberOffice = formCollection["PhoneNumberOffice"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDescription"]))
            {
                feeDetails.FeeDescription = formCollection["FeeDescription"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["Amount"]))
            {
                feeDetails.Amount = Convert.ToDecimal(formCollection["Amount"]);
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            studentDetailsDal.AddFeeDetails(feeDetails);
            return View();
        }

        [HttpPost]
        public ActionResult InsertAcademicDetails(AcademicDetails academicDetails)
        {
            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult UpdateAcademicDetails(AcademicDetails customer)
        {


            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteAcademicDetails(string CourserId)
        {


            return new EmptyResult();
        }

    }
}