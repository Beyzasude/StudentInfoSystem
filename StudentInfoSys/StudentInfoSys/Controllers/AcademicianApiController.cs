using BusinessLayer.Concrete;
using ModelLayer.Academician;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace StudentInfoSys.Controllers
{
    [System.Web.Http.RoutePrefix("api/test")]
    public class AcademicianApiController : ApiController
    {

        public AcademicianApiController()
        {

        }

        // GET: AcademicianApi
        [System.Web.Http.AllowAnonymous]
        [System.Web.Http.HttpPost]        
        [System.Web.Http.Route("AcademicianList")]
        public JsonResult<AcademicianResult> AcademicianList()
        {
            AcademicianBLL academicianBLL = new AcademicianBLL();
            AcademicianResult academicianValues = academicianBLL.GetAcademician(1);
            return Json(academicianValues);
        }
    }
}