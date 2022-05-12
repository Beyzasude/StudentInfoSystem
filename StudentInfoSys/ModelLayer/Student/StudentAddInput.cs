using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.Student
{
    public class StudentAddInput
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Tc { get; set; }
        public string Password { get; set; }
        public int Semester { get; set; }
        public int AcademicianID { get; set; }
        public string  ImageName { get; set; }
        public int DepartmentID { get; set; }
        public int SyllabusID { get; set; }
    }
}
