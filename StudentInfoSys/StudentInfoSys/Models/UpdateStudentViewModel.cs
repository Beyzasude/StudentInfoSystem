using ModelLayer.Academician;
using ModelLayer.Department;
using ModelLayer.Student;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentInfoSys.Models
{
    public class UpdateStudentViewModel
    {
        public StudentResult studentResult { get; set; }
        public List<AcademicianResult> academicians { get; set; }
        public List<DepartmentResult> departments { get; set; }

        public UpdateStudentViewModel()
        {
            studentResult = new StudentResult();
            academicians = new List<AcademicianResult>();
            departments = new List<DepartmentResult>();
        }
    }
}