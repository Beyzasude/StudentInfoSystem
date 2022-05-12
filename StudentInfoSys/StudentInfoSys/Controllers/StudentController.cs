using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Academician;
using ModelLayer.Inturn;
using ModelLayer.Lecture;
using ModelLayer.Password;
using ModelLayer.Student;
using ModelLayer.StudentLecture;
using StudentInfoSys.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    public class StudentController : StudentBaseController
    {
        AcademicianLectureViewModel std = new AcademicianLectureViewModel();
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult StudentInfo()
        {
            int id = ((StudentResult)Session["StudentUser"]).Id;
            StudentBLL studentBLL = new StudentBLL();
            StudentResult studentValues = studentBLL.GetStudent(id);
            return View(studentValues);
        }

        [HttpGet]
        public ActionResult AcademicianInfo()
        {
            int id = ((StudentResult)Session["StudentUser"]).AcademicianID;
            AcademicianBLL academicianBLL = new AcademicianBLL();
            AcademicianResult academicianValues = academicianBLL.GetAcademician(id);
            return View(academicianValues);
        }

        [HttpGet]
        public ActionResult InturnInfo()
        {
            int id = ((StudentResult)Session["StudentUser"]).Id;
            InturnBLL inturnBLL = new InturnBLL();
            List<InturnResult> inturn = inturnBLL.GetInturn(id);
            return View(inturn);
        }

        [HttpGet]
        public ActionResult ListLecture()
        {
            StudentResult studentResult = ((StudentResult)Session["StudentUser"]);
            AcademicianLectureBLL academicianLectureBLL = new AcademicianLectureBLL();
            var lectureResults = academicianLectureBLL.Get(departmentId: studentResult.DepartmentID, studentResult.Id);
            return View(lectureResults);
        }

        [HttpGet]
        public ActionResult AcademicianLectureList()
        {
            int studentId = ((StudentResult)Session["StudentUser"]).Id;
            AcademicianLectureBLL academicianLectureBLL = new AcademicianLectureBLL();
            var lectureResults = academicianLectureBLL.SelectedLectures(studentId);
            return View(lectureResults);
        }

        [HttpPost]
        public ActionResult ListLecture(List<int> Lecture)
        {
            int studentId = ((StudentResult)Session["StudentUser"]).Id;
            var stdLecture = new StudentLectureBLL();
            stdLecture.Add(Lecture, studentId);

            return RedirectToAction("AcademicianLectureList", "Student");

        }

        [HttpGet]
        public ActionResult StudentNoteList()
        {
            int studentId = ((StudentResult)Session["StudentUser"]).Id;
            StudentBLL studentBLL = new StudentBLL();
            List<StudentLectureResult> studentNoteResult = studentBLL.GetStudentNotes(studentId);
            return View(studentNoteResult);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(PasswordInput password)
        {
            try
            {
                int studentId = ((StudentResult)Session["StudentUser"]).Id;
                StudentBLL studentBLL = new StudentBLL();
                studentBLL.UpdatePassword(password, studentId);
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
            }
            return View();
        }

        [HttpGet]
        public ActionResult UpdateImage()
        {
            return View();
        }

        [HttpPost]
        public JsonResult UpdateImageFile()
        {
            try
            {
                int academicianId = ((StudentResult)Session["StudentUser"]).Id;
                StudentBLL studentBLL = new StudentBLL();
                var files = Request.Files["ImageName"];

                string extension = Path.GetExtension(files.FileName);

                string guidName = Guid.NewGuid().ToString() + extension;

                studentBLL.ImageUpdate(guidName, academicianId);

                if (!Directory.Exists(Server.MapPath("~/images/students/")))
                    Directory.CreateDirectory(Server.MapPath("~/images/students/"));
                string path = "/images/students/" + guidName;

                string savedPath = Path.Combine(Server.MapPath("~/images/students/"), guidName);

                files.SaveAs(savedPath);

                return Json(true);
            }
            catch (Exception ex)
            {
                return Json(false);
            }
        }



    }
}