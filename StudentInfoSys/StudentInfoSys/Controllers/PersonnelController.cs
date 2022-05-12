using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Academician;
using ModelLayer.Password;
using ModelLayer.Personnel;
using ModelLayer.Student;
using StudentInfoSys.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    public class PersonnelController : PersonnelBaseController
    {
        // GET: Personnel

        StudentBLL studentBLL = new StudentBLL();
        PersonnelBLL personnelBLL = new PersonnelBLL();
        AcademicianBLL academicianBLL = new AcademicianBLL();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult PersonnelInfo()
        {
            int id = ((PersonnelResult)Session["PersonnelUser"]).Id;
            PersonnelResult personnelValues = personnelBLL.GetPersonnel(id);
            return View(personnelValues);
        }

        [HttpGet]
        public ActionResult StudentGetList()
        {
            List<StudentResult> studentValues = studentBLL.GetList();

            return View(studentValues);
        }

        [HttpGet]
        public ActionResult AddStudent()
        {
            StudentAddViewModel studentAddViewModel = new StudentAddViewModel();

            DepartmentBLL departmentBLL = new DepartmentBLL();
            studentAddViewModel.departments = departmentBLL.GetList();

            return View(studentAddViewModel);
        }

        [HttpPost]
        public JsonResult AddStudent(StudentAddInput studentAddInput)
        {
            try
            {
                var files = Request.Files["ImageName"];

                string extension = Path.GetExtension(files.FileName);

                string guidName = Guid.NewGuid().ToString() + extension;

                studentBLL.StudentAdd(studentAddInput, guidName);

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

        [HttpPost]
        public JsonResult GetAcademisionDropdown(int departmentId)
        {
            List<AcademicianResult> result = academicianBLL.Get(departmentId: departmentId);
            return Json(result);
        }

        [HttpGet]
        public ActionResult UpdateStudent(int id)
        {
            UpdateStudentViewModel updateStudentViewModel = new UpdateStudentViewModel();

            updateStudentViewModel.studentResult = studentBLL.GetStudent(id);
            DepartmentBLL departmentBLL = new DepartmentBLL();
            updateStudentViewModel.departments = departmentBLL.GetList();
            updateStudentViewModel.academicians = academicianBLL.Get(departmentId: updateStudentViewModel.studentResult.DepartmentID);

            return View(updateStudentViewModel);

        }

        [HttpPost]
        public JsonResult UpdateStudent(StudentResult studentResult)
        {
            try
            {
                StudentBLL studentBLL = new StudentBLL();
                studentBLL.StudentUpdate(studentResult: studentResult);
                return Json(true);
            }
            catch(Exception ex)
            {
                return Json(false);
            }
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            studentBLL.StudentDelete(id);
            return RedirectToAction("StudentGetList");
        }


        [HttpGet]
        public ActionResult UpdateAcademician(int id)
        {
            UpdateAcademicianViewModel updateAcademicianViewModel = new UpdateAcademicianViewModel();

            DepartmentBLL departmentBLL = new DepartmentBLL();
            updateAcademicianViewModel.departments = departmentBLL.GetList();
            updateAcademicianViewModel.academicianResult = academicianBLL.GetAcademician(id);
            return View(updateAcademicianViewModel);
        }

        [HttpPost]
        public ActionResult UpdateAcademician(AcademicianResult academicianResult)
        {
            AcademicianBLL academicianBLL = new AcademicianBLL();
            academicianBLL.AcademicianUpdate(academicianResult: academicianResult);
            return RedirectToAction("AcademicianGetList");
        }

        [HttpGet]
        public ActionResult DeleteAcademician(int id)
        {
            academicianBLL.AcademicianDelete(id);
            return RedirectToAction("AcademicianGetList");
        }


        [HttpGet]
        public ActionResult AcademicianGetList()
        {
            List<AcademicianResult> academicianValues = academicianBLL.GetList();

            return View(academicianValues);
        }


        [HttpGet]
        public ActionResult AddAcademician()
        {
            AcademicianAddViewModel academicianAddViewModel = new AcademicianAddViewModel();

            DepartmentBLL departmentBLL = new DepartmentBLL();
            academicianAddViewModel.departments = departmentBLL.GetList();
            return View(academicianAddViewModel);
        }


        [HttpPost]
        public ActionResult AddAcademician(AcademicianAddInput academicianAddInput)
        {
            try
            {

                var files = Request.Files["ImageName"];

                string extension = Path.GetExtension(files.FileName);

                string guidName = Guid.NewGuid().ToString() + extension;

                academicianBLL.AcademicianAdd(academicianAddInput, guidName);

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
                int personnelId = ((PersonnelResult)Session["PersonnelUser"]).Id;
                PersonnelBLL personnelBLL = new PersonnelBLL();
                personnelBLL.UpdatePassword(password, personnelId);
            }
            catch (Exception exception)
            {
                ViewBag.Error = exception.Message;
            }
            return View();
        }



    }
}