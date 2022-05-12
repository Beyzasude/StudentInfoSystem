using BusinessLayer.Concrete;
using EntitiyLayer;
using ModelLayer;
using ModelLayer.Academician;
using ModelLayer.Password;
using ModelLayer.Student;
using ModelLayer.StudentLecture;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    public class AcademicianController : AcademicianBaseController
    {
        // GET: Academician
        StudentBLL studentBLL = new StudentBLL();
        AcademicianLectureBLL academicianLectureBLL = new AcademicianLectureBLL();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AcademicianInfo()
        {
            int id = ((AcademicianResult)Session["AcademicianUser"]).Id;
            AcademicianBLL academicianBLL = new AcademicianBLL();
            AcademicianResult academicianValues = academicianBLL.GetAcademician(id);
            return View(academicianValues);
        }

        [HttpPost]
        public ActionResult GetListAcademicianInfo()
        {
            int id = ((AcademicianResult)Session["AcademicianUser"]).Id;
            AcademicianBLL academicianBLL = new AcademicianBLL();
            AcademicianResult academicianValues = academicianBLL.GetAcademician(id);
            return Json(academicianValues);
        }


        [HttpGet]
        public ActionResult GetStudents(int id)
        {
            int academicianId = ((AcademicianResult)Session["AcademicianUser"]).Id;
            List<StudentLectureResult> studentValues = studentBLL.GetListStudents(academicianId, id);
            return View(studentValues);
        }

        [HttpGet]
        public ActionResult GetStudentInfo(int id)
        {
            StudentResult studentValues = studentBLL.GetStudent(id);
            return View(studentValues);
        }

        [HttpPost]
        public ActionResult GetStudentInfoPopUp(int id)
        {
            StudentResult studentValues = studentBLL.GetStudent(id);
            return Json(studentValues);
        }


        [HttpGet]
        public ActionResult NoteInfo(int id)
        {
            int academicianid = ((AcademicianResult)Session["AcademicianUser"]).Id;
            List<StudentLectureResult> studentValues = studentBLL.GetListStudents(academicianid, id);
            return View(studentValues);
        }

        [HttpPost]
        public ActionResult GetNoteInfo(int id)
        {
            int academicianid = ((AcademicianResult)Session["AcademicianUser"]).Id;
            List<StudentLectureResult> studentValues = studentBLL.GetListStudents(academicianid, id);
            return Json(studentValues);
        }
        [HttpPost]
        public void AddNoteInfo(List<StudentLectureInput> model)
        {
            StudentLectureBLL.AddNote(model);

        }

        [HttpGet]
        public ActionResult ListAcademicianLecture()
        {
            int id = ((AcademicianResult)Session["AcademicianUser"]).Id;
            List<AcademicianLectureResult> academicianLectures = academicianLectureBLL.AcademicianLectures(id);
            return View(academicianLectures);
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
                int academicianId = ((AcademicianResult)Session["AcademicianUser"]).Id;
                AcademicianBLL studentBLL = new AcademicianBLL();
                studentBLL.UpdatePassword(password, academicianId);

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
                int academicianId = ((AcademicianResult)Session["AcademicianUser"]).Id;
                AcademicianBLL academicianBLL = new AcademicianBLL();
                var files = Request.Files["ImageName"];

                string extension = Path.GetExtension(files.FileName);

                string guidName = Guid.NewGuid().ToString() + extension;

                academicianBLL.ImageUpdate(guidName, academicianId);

                if (!Directory.Exists(Server.MapPath("~/images/academicians/")))
                    Directory.CreateDirectory(Server.MapPath("~/images/academicians/"));
                string path = "/images/academicians/" + guidName;

                string savedPath = Path.Combine(Server.MapPath("~/images/academicians/"), guidName);

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