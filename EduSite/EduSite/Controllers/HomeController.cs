using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static UnivSite.Models.StudentDetails;

namespace EduSite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            StudentDetailsModel studentDetailsModel = new StudentDetailsModel();
            return View(studentDetailsModel);
        }

        public ActionResult SavePersonalDetails()
        {
            return View();
        }
        public ActionResult SaveAddressDetails()
        {
            return View();
        }
        public ActionResult SaveFeeDetails()
        {
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