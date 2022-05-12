using EntitiyLayer;
using ModelLayer.Academician;
using ModelLayer.Department;
using ModelLayer.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfoSys.Models
{
    public class StudentAddViewModel
    {
        public StudentAddInput studentAddInput { get; set; }
        public List<AcademicianResult> academicians { get; set; }
        public List<DepartmentResult> departments { get; set; }

        public StudentAddViewModel()
        {
            studentAddInput = new StudentAddInput();
            academicians = new List<AcademicianResult>();
            departments = new List<DepartmentResult>();
        }
    }
}