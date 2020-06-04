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

            if (!string.IsNullOrEmpty(formCollection["PersonalDetails.ApplicantName"]))
            {
                personalDetails.ApplicantName = formCollection["PersonalDetails.ApplicantName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PersonalDetails.MotherName"]))
            {
                personalDetails.MotherName = formCollection["PersonalDetails.MotherName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PersonalDetails.FatherName"]))
            {
                personalDetails.FatherName = formCollection["PersonalDetails.FatherName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PersonalDetails.RegistrationNo"]))
            {
                personalDetails.RegistrationNo = formCollection["PersonalDetails.RegistrationNo"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PersonalDetails.NatureOfDocument"]))
            {
                personalDetails.NatureOfDocument = formCollection["PersonalDetails.NatureOfDocument"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["PersonalDetails.ReasonOfApplying"]))
            {
                personalDetails.ReasonOfApplying = formCollection["PersonalDetails.ReasonOfApplying"].ToString();
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            StudentDetailsModel studentDetailsModel = new StudentDetailsModel();
            studentDetailsModel.PersonalDetails = personalDetails;
            personalDetails.StudentId = studentDetailsDal.AddPersonalDetails(personalDetails);
            return PartialView("PersonalDetails", studentDetailsModel);
        }

        [HttpPost]
        public ActionResult SaveAddressDetails(FormCollection formCollection)
        {
            AddressDetails addressDetails = new AddressDetails();
            if (!string.IsNullOrEmpty(formCollection["AddressDetails.FullAddress"]))
            {
                addressDetails.FullAddress = formCollection["AddressDetails.FullAddress"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["AddressDetails.PhoneNumberOffice"]))
            {
                addressDetails.PhoneNumberOffice = formCollection["AddressDetails.PhoneNumberOffice"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["AddressDetails.PhoneNumberResidence"]))
            {
                addressDetails.PhoneNumberResidence = formCollection["AddressDetails.PhoneNumberResidence"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["AddressDetails.EmailId"]))
            {
                addressDetails.EmailId = formCollection["AddressDetails.EmailId"].ToString();
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            addressDetails.AddressDetailsId = studentDetailsDal.SaveAddressDetails(addressDetails);
            return View();
        }

        [HttpPost]
        public ActionResult SaveFeeDetails(FormCollection formCollection)
        {
            FeeDetails feeDetails = new FeeDetails();

            if (!string.IsNullOrEmpty(formCollection["FeeDetails.StudentId"]))
            {
                feeDetails.StudentId = formCollection["FeeDetails.StudentId"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.TransactionId"]))
            {
                feeDetails.TransactionId = formCollection["FeeDetails.TransactionId"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.Date"]))
            {
                feeDetails.Date = formCollection["FeeDetails.Date"].AsDateTime();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.PayeeName"]))
            {
                feeDetails.PayeeName = formCollection["FeeDetails.PayeeName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.FathersName"]))
            {
                feeDetails.FathersName = formCollection["FeeDetails.FathersName"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.DOB"]))
            {
                feeDetails.DOB = formCollection["FeeDetails.DOB"].AsDateTime();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.PhoneNumberOffice"]))
            {
                feeDetails.PhoneNumberOffice = formCollection["FeeDetails.PhoneNumberOffice"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.FeeDescription"]))
            {
                feeDetails.FeeDescription = formCollection["FeeDetails.FeeDescription"].ToString();
            }
            if (!string.IsNullOrEmpty(formCollection["FeeDetails.Amount"]))
            {
                feeDetails.Amount = Convert.ToDecimal(formCollection["FeeDetails.Amount"]);
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            feeDetails.FeeDetailsId = studentDetailsDal.AddFeeDetails(feeDetails);
            return View();
        }

        [HttpPost]
        public JsonResult InsertAcademicDetails(AcademicDetails academicDetails)
        {
            if (string.IsNullOrEmpty(academicDetails.Course) || string.IsNullOrEmpty(academicDetails.Semester) || string.IsNullOrEmpty(academicDetails.Year) || string.IsNullOrEmpty(academicDetails.CollegeName) || academicDetails.MaxMark == 0)
            {
                return Json(new { result = "Please fill all the details" });
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            if (string.IsNullOrEmpty(academicDetails.AcademicDetailsId))
                academicDetails.AcademicDetailsId = studentDetailsDal.AddAcademicDetails(academicDetails);
            else
                studentDetailsDal.UpdateAcademicDetails(academicDetails);

            //AcademicDetails academicDetails1 = new AcademicDetails();

            return Json(new { Result = academicDetails });
        }

        [HttpPost]
        public ActionResult UpdateAcademicDetails(AcademicDetails academicDetails)
        {
            if (string.IsNullOrEmpty(academicDetails.Course) || string.IsNullOrEmpty(academicDetails.Semester) || string.IsNullOrEmpty(academicDetails.Year) || string.IsNullOrEmpty(academicDetails.CollegeName) || academicDetails.MaxMark == 0)
            {
                return Json(new { result = "Please fill all the details" });
            }
            StudentDetailsDal studentDetailsDal = new StudentDetailsDal();
            if (string.IsNullOrEmpty(academicDetails.AcademicDetailsId))
                academicDetails.AcademicDetailsId = studentDetailsDal.AddAcademicDetails(academicDetails);
            else
                studentDetailsDal.UpdateAcademicDetails(academicDetails);

            return new EmptyResult();
        }

        [HttpPost]
        public ActionResult DeleteAcademicDetails(string CourserId)
        {


            return new EmptyResult();
        }

    }
}