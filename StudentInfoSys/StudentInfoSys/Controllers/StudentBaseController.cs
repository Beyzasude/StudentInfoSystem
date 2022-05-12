using EntitiyLayer;
using ModelLayer.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    public class StudentBaseController : Controller
    {
        protected StudentResult StudentCurrentUser
        {
            get { return (StudentResult)Session["StudentUser"]; }
            set { Session["StudentUser"] = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (StudentCurrentUser == null || StudentCurrentUser.Id == 0)
            {
                //Session["AdminAfterLoginUrl"] = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult("~/Login/StudentLogin");
            }
            else
                ViewBag.StudentCurrentUser = StudentCurrentUser;
        }
    }
}