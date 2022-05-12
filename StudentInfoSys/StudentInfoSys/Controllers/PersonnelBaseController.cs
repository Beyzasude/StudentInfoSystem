using ModelLayer.Personnel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    public class PersonnelBaseController:Controller
    {
        protected PersonnelResult PersonnelCurrentUser
        {
            get { return (PersonnelResult)Session["PersonnelUser"]; }
            set { Session["PersonnelUser"] = value; }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (PersonnelCurrentUser == null || PersonnelCurrentUser.Id == 0)
            {
                //Session["AdminAfterLoginUrl"] = filterContext.HttpContext.Request.RawUrl;
                filterContext.Result = new RedirectResult("~/Login/PersonnelLogin");
            }
            else
                ViewBag.PersonnelCurrentUser = PersonnelCurrentUser;
        }
    }
}