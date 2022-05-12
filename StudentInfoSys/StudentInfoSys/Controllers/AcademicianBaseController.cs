using ModelLayer.Academician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    public class AcademicianBaseController:Controller
    {
        protected AcademicianResult AcademicianCurrentUser
        {
            get { return (AcademicianResult)Session["AcademicianUser"]; }
            set { Session["AcademicianUser"] = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (AcademicianCurrentUser == null || AcademicianCurrentUser.Id == 0)
            {
                //Session["AdminAfterLoginUrl"] = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult("~/Login/AcademicianLogin");
            }
            else
                ViewBag.AcademicianCurrentUser = AcademicianCurrentUser;
        }
    }
}