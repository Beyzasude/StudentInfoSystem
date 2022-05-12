using ModelLayer.Academician;
using ModelLayer.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfoSys.Models
{
    public class UpdateAcademicianViewModel
    {
        public List<DepartmentResult> departments { get; set; }
        public AcademicianResult academicianResult { get; set; }
       

        public UpdateAcademicianViewModel()
        {
            departments = new List<DepartmentResult>();
            academicianResult = new AcademicianResult();
        }
    }
}