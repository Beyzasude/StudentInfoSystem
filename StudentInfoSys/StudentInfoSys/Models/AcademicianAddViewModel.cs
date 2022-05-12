using ModelLayer.Academician;
using ModelLayer.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfoSys.Models
{
    public class AcademicianAddViewModel
    {
        public AcademicianAddInput academicianAddInput { get; set; }
      
        public List<DepartmentResult> departments { get; set; }

        public AcademicianAddViewModel()
        {
            academicianAddInput = new AcademicianAddInput();
            departments = new List<DepartmentResult>();
        }
    }
}