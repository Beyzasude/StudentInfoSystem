using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using EntitiyLayer;
using ModelLayer.Academician;
using ModelLayer.Personnel;
using ModelLayer.Student;
using Newtonsoft.Json;
using StudentInfoSys.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentInfoSys.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult StudentLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult StudentLogin(string email, string password)
        {
            if (email == "")
                return Json("email boş");
            else if (password == "")
                return Json("password boş");
            else
            {
                SHA1 sha = new SHA1CryptoServiceProvider();
                StudentBLL studentBLL = new StudentBLL();
                StudentResult student = studentBLL.Login(email: email, password: Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password))));
                if (student == null)
                    return Json("kullanıcı adı veya şifre yanlış");
                else
                {
                    Session["LoginType"] = LoginType.Student;
                    Session["StudentUser"] = student;
                    return RedirectToAction("Index", "Student");
                }
            }
        }

        [HttpGet]
        public ActionResult AcademicianLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AcademicianLogin(string email, string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            AcademicianBLL academicianBLL = new AcademicianBLL();
            AcademicianResult academician = academicianBLL.Login(email: email, password: Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password))));
            if (academician == null)
                return View();
            else
            {
                Session["LoginType"] = LoginType.Academician;
                Session["AcademicianUser"] = academician;
                return RedirectToAction("Index", "Academician");
            }
        }

        [HttpGet]
        public ActionResult PersonnelLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonnelLogin(string email, string password)
        {
            SHA1 sha = new SHA1CryptoServiceProvider();
            PersonnelBLL personnelBLL = new PersonnelBLL();
            PersonnelResult personnel = personnelBLL.Login(email: email, password: Convert.ToBase64String(sha.ComputeHash(Encoding.UTF8.GetBytes(password))));
            if (personnel == null)
                return View();
            else
            {
                Session["LoginType"] = LoginType.Personnel;
                Session["PersonnelUser"] = personnel;
                return RedirectToAction("Index", "Personnel");
            }
        }

    }
}
